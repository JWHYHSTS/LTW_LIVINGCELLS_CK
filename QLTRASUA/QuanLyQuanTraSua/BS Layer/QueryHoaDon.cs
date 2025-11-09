using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace QuanLyQuanTraSua.BS_Layer
{
    class QueryHoaDon
    {
        // ==================== Helpers ====================
        private static string Normalize(string s) => (s ?? string.Empty).Trim();

        // Lấy phần số ở cuối mã có prefix 2 ký tự (VD: KH0001 -> 1)
        private static int ExtractNumberSuffix(string code, int prefixLength)
        {
            if (string.IsNullOrWhiteSpace(code) || code.Length <= prefixLength) return 0;
            var num = code.Substring(prefixLength);
            return int.TryParse(num, out var n) ? n : 0;
        }

        private static string NextCode(IEnumerable<string> allCodes, string prefix, int digits)
        {
            var max = allCodes
                .Select(c => ExtractNumberSuffix(Normalize(c), prefix.Length))
                .DefaultIfEmpty(0)
                .Max();
            return prefix + (max + 1).ToString("D" + digits);
        }

        // ==================== UI datasource ====================
        public DataGridViewComboBoxColumn LoadComboBox(DataGridViewComboBoxColumn cbbMH)
        {
            using (var db = new QUANLYQUANTRADataContext())
            {
                // Lấy tất cả món từ MENU
                var data = db.MENUs
                             .Select(m => new { m.MaMH, m.TenMH })
                             .ToList();

                var dt = new DataTable();
                dt.Columns.Add("MaMH");
                dt.Columns.Add("TenMH");
                data.ForEach(x => dt.Rows.Add(x.MaMH, x.TenMH));

                cbbMH.DataSource = dt;
                cbbMH.DisplayMember = "TenMH";
                cbbMH.ValueMember = "MaMH";
                return cbbMH;
            }
        }

        // ==================== Khách hàng ====================
        public bool CheckKhachHang(string sdt, out string maKH)
        {
            var phone = Normalize(sdt);
            using (var db = new QUANLYQUANTRADataContext())
            {
                var kh = db.KHACHHANGs
                           .FirstOrDefault(k => k.SDT.Trim() == phone);

                if (kh != null)
                {
                    maKH = Normalize(kh.MaKH);
                    return true;
                }
                maKH = string.Empty;
                return false;
            }
        }

        public List<string> GetKhachInfor(string maKH)
        {
            using (var db = new QUANLYQUANTRADataContext())
            {
                var kh = db.KHACHHANGs
                           .FirstOrDefault(k => k.MaKH.Trim() == Normalize(maKH));

                // Trả về an toàn khi null
                if (kh == null) return new List<string> { string.Empty, "0" };

                return new List<string>
                {
                    Normalize(kh.MaKH),
                    (kh.DiemTichLuy ?? 0).ToString()
                };
            }
        }

        public bool ThemKhach(string name, string sdt, string diachi, ref string err, out List<string> infor)
        {
            using (var db = new QUANLYQUANTRADataContext())
            {
                // Tạo mã KH mới dựa trên Max phần số
                var allCodes = db.KHACHHANGs.Select(k => k.MaKH).ToList();
                var nextId = allCodes.Any()
                    ? NextCode(allCodes, "KH", 4)
                    : "KH0001";

                var kh = new KHACHHANG
                {
                    MaKH = nextId,
                    TenKH = Normalize(name),
                    SDT = Normalize(sdt),
                    DiaChi = Normalize(diachi),
                    DiemTichLuy = 0
                };

                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();

                infor = new List<string> { nextId, "0" };
                return true;
            }
        }

        public void GetGia(string idMH, out int cost, out int plus)
        {
            using (var db = new QUANLYQUANTRADataContext())
            {
                var mh = db.MENUs
                           .FirstOrDefault(m => m.MaMH.Trim() == Normalize(idMH));

                if (mh == null)
                {
                    cost = 0;
                    plus = 0;
                    return;
                }

                cost = (int)mh.GiaTien;   // GiaTien là float → ép kiểu sang int
                plus = mh.DiemTichLuy;    // DiemTichLuy là int
            }
        }



        // ==================== Coupon ====================
        // So sánh DateTime trực tiếp (không parse chuỗi)
        public float CheckCoupon(int cost, int point, out List<string> coupon_infor)
        {
            using (var db = new QUANLYQUANTRADataContext())
            {
                coupon_infor = new List<string>();
                var today = DateTime.Today;

                // Lọc các coupon đang hiệu lực & đủ điểm, chọn ưu đãi tốt nhất
                var candidates = db.COUPONs
                    .Where(c => c.NgayBatDau.Date <= today && today <= c.NgayKetThuc.Date
                                && point >= (c.DiemApDung ?? 0))
                    .Select(c => new
                    {
                        c.MaCP,
                        c.MoTa,
                        Rate = (float)(c.MucGiam ?? 0),
                        Max = (float)(c.GiamToiDa ?? 0)
                    })
                    .ToList();

                if (!candidates.Any()) return 0f;

                // Tính mức giảm và chọn cái giảm nhiều nhất (sau khi áp dụng trần Max)
                var best = candidates
                    .Select(c =>
                    {
                        var d = cost * c.Rate;
                        if (d > c.Max) d = c.Max;
                        return new { Coupon = c, Discount = d };
                    })
                    .OrderByDescending(x => x.Discount)
                    .First();

                if (best.Discount > 0)
                {
                    coupon_infor.Add(Normalize(best.Coupon.MaCP));
                    coupon_infor.Add(Normalize(best.Coupon.MoTa));
                }

                return (float)best.Discount;
            }
        }

        // ==================== Update điểm KH ====================
        public bool UpdateKhachHang(string maKH, int point, ref string err)
        {
            using (var db = new QUANLYQUANTRADataContext())
            {
                var kh = db.KHACHHANGs
                           .FirstOrDefault(k => k.MaKH.Trim() == Normalize(maKH));

                if (kh == null) return false;

                kh.DiemTichLuy = (kh.DiemTichLuy ?? 0) + point;
                db.SubmitChanges();
                return true;
            }
        }

        // ==================== Lưu hoá đơn ====================
        public string LuuHoaDon(string maKH, string maNV, float total_cost, DateTime ngayXHD, string maCP, ref string err)
        {
            using (var db = new QUANLYQUANTRADataContext())
            {
                // Sinh mã HD mới theo Max phần số
                var allCodes = db.HOADONs.Select(h => h.MaHD).ToList();
                var nextId = allCodes.Any()
                    ? NextCode(allCodes, "HD", 4)
                    : "HD0001";

                var hd = new HOADON
                {
                    MaHD = nextId,
                    MaKH = Normalize(maKH),
                    MaNV = Normalize(maNV),
                    ThanhTien = total_cost,
                    NgayXuatHD = ngayXHD,
                    MaCP = Normalize(maCP) != "Null" ? Normalize(maCP) : null
                };

                db.HOADONs.InsertOnSubmit(hd);
                db.SubmitChanges(); // tạo HD trước để còn lưu chi tiết
                return nextId;
            }
        }

        // ==================== Lưu chi tiết hoá đơn ====================
        public void LuuChiTietHD(string maHD, DataGridView table_item, ref string err)
        {
            using (var db = new QUANLYQUANTRADataContext())
            {
                var details = new List<CHITIETHOADON>();

                foreach (DataGridViewRow row in table_item.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells[0].Value == null) continue;

                    var maMH = Normalize(row.Cells[0].Value?.ToString());

                    int soLuong = 0, diem = 0, tien = 0;
                    int.TryParse(Normalize(row.Cells[1].Value?.ToString()), out soLuong);
                    int.TryParse(Normalize(row.Cells[2].Value?.ToString()), out diem);
                    int.TryParse(Normalize(row.Cells[3].Value?.ToString()), out tien);

                    // Bỏ những dòng rỗng
                    if (string.IsNullOrEmpty(maMH) || soLuong <= 0) continue;

                    details.Add(new CHITIETHOADON
                    {
                        MaHD = Normalize(maHD),
                        MaMH = maMH,
                        SoLuong = soLuong,
                        DiemTichLuy = diem,
                        Tien = tien
                    });
                }

                if (details.Any())
                {
                    db.CHITIETHOADONs.InsertAllOnSubmit(details);
                    db.SubmitChanges(); // submit 1 lần cho toàn bộ chi tiết
                }
            }
        }
    }
}
