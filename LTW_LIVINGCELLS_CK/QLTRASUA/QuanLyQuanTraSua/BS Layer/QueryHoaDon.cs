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
        public DataGridViewComboBoxColumn LoadComboBox(DataGridViewComboBoxColumn cbbMH)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tps = qlbhEntity.MENUs.Select(p => p);

                DataTable dt = new DataTable();
                dt.Columns.Add("MaMH");
                dt.Columns.Add("TenMH");

                foreach (var p in tps)
                    dt.Rows.Add(p.MaMH, p.TenMH);

                cbbMH.DataSource = dt;
                cbbMH.DisplayMember = "TenMH";
                cbbMH.ValueMember = "MaMH";
                return cbbMH;
            }
        }

        public bool CheckKhachHang(string sdt, out string maKH)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tps = qlbhEntity.KHACHHANGs
                    .Where(p => p.SDT.Trim() == sdt)
                    .SingleOrDefault();

                if (tps != null)
                {
                    maKH = tps.MaKH;
                    return true;
                }
                maKH = "";
                return false;
            }
        }

        public List<string> GetKhachInfor(string maKH)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tps = qlbhEntity.KHACHHANGs
                    .Where(p => p.MaKH.Trim() == maKH)
                    .SingleOrDefault();

                List<string> infor = new List<string>();
                infor.Add(tps.MaKH.Trim());
                infor.Add(tps.DiemTichLuy.ToString());
                return infor;
            }
        }

        public bool ThemKhach(string name, string sdt, string diachi, ref string err, out List<string> infor)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var all = qlbhEntity.KHACHHANGs.Select(p => p).ToList();
                int count = all.Count;

                if (count == 0)
                {
                    infor = new List<string> { "KH0001", "0" };
                    return true;
                }

                string id = all.Last().MaKH.Trim();
                string[] listcode = id.Split('H');
                int index = Int32.Parse(listcode[1]);
                string next_id = "KH" + (index + 1).ToString().PadLeft(4, '0');

                KHACHHANG kh = new KHACHHANG
                {
                    MaKH = next_id,
                    TenKH = name,
                    SDT = sdt,
                    DiaChi = diachi,
                    DiemTichLuy = 0
                };

                qlbhEntity.KHACHHANGs.InsertOnSubmit(kh);
                qlbhEntity.KHACHHANGs.Context.SubmitChanges();

                infor = new List<string> { next_id, "0" };
                return true;
            }
        }

        public void GetGia(string idMH, out int cost, out int plus)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tps = qlbhEntity.MENUs
                    .Where(p => p.MaMH.Trim() == idMH)
                    .SingleOrDefault();

                cost = (int)tps.GiaTien;
                plus = tps.DiemTichLuy;
            }
        }

        private string LocNgay(string datetime)
        {
            string[] list_time = datetime.Split(' ');
            string[] list_date = list_time[0].Split('/');
            DateTime date = new DateTime(Int32.Parse(list_date[2]), Int32.Parse(list_date[0]), Int32.Parse(list_date[1]));
            return date.ToString("yyyy-MM-dd");
        }

        public float CheckCoupon(int cost, int point, out List<string> coupon_infor)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                coupon_infor = new List<string>();
                DateTime today = DateTime.Now;
                var cp = qlbhEntity.COUPONs.Select(p => p);

                string start, end, now = today.ToString("yyyy-MM-dd");
                float discount = 0, rate, max;
                int point_rate;

                foreach (var p in cp)
                {
                    start = LocNgay(p.NgayBatDau.ToString());
                    end = LocNgay(p.NgayKetThuc.ToString());
                    rate = (float)p.MucGiam;
                    point_rate = (int)p.DiemApDung;
                    max = (float)p.GiamToiDa;

                    if (String.Compare(start, now) <= 0 && String.Compare(now, end) <= 0)
                    {
                        if (point >= point_rate)
                        {
                            discount = cost * rate;
                            if (discount > max)
                                discount = max;

                            coupon_infor.Add(p.MaCP);
                            coupon_infor.Add(p.MoTa);
                            break;
                        }
                    }
                }
                return discount;
            }
        }

        public bool UpdateKhachHang(string maKH, int point, ref string err)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tps = qlbhEntity.KHACHHANGs
                    .Where(p => p.MaKH.Trim() == maKH)
                    .SingleOrDefault();

                if (tps != null)
                {
                    tps.DiemTichLuy += point;
                    qlbhEntity.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public string LuuHoaDon(string maKH, string maNV, float total_cost, DateTime ngayXHD, string maCP, ref string err)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var all = qlbhEntity.HOADONs.Select(p => p).ToList();
                int count = all.Count;

                if (count == 0)
                    return "HD0001";

                string id = all.Last().MaHD.Trim();
                string[] listcode = id.Split('D');
                int index = Int32.Parse(listcode[1]);
                string next_id = "HD" + (index + 1).ToString().PadLeft(4, '0');

                HOADON hd = new HOADON
                {
                    MaHD = next_id,
                    MaKH = maKH,
                    MaNV = maNV,
                    ThanhTien = total_cost,
                    NgayXuatHD = ngayXHD,
                    MaCP = (maCP != "Null") ? maCP : null
                };

                qlbhEntity.HOADONs.InsertOnSubmit(hd);
                qlbhEntity.HOADONs.Context.SubmitChanges();

                return next_id;
            }
        }

        public void LuuChiTietHD(string maHD, DataGridView table_item, ref string err)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                foreach (DataGridViewRow row in table_item.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        var ct = new CHITIETHOADON
                        {
                            MaHD = maHD,
                            MaMH = row.Cells[0].Value.ToString().Trim(),
                            SoLuong = (int)row.Cells[1].Value,
                            DiemTichLuy = (int)row.Cells[2].Value,
                            Tien = (int)row.Cells[3].Value
                        };

                        qlbhEntity.CHITIETHOADONs.InsertOnSubmit(ct);
                        qlbhEntity.CHITIETHOADONs.Context.SubmitChanges();
                    }
                }
            }
        }
    }
}
