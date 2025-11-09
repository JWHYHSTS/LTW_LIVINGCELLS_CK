using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanTraSua.BS_Layer
{
    class QueryCaLam
    {
        // ===== Helpers =====
        private static DateTime ParseDate(string s)
        {
            // Hỗ trợ các định dạng phổ biến để tránh lỗi culture
            string[] fmts = { "yyyy-MM-dd", "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/M/d", "d/M/yyyy" };
            if (DateTime.TryParseExact(s.Trim(), fmts, System.Globalization.CultureInfo.InvariantCulture,
                                       System.Globalization.DateTimeStyles.None, out var dt))
                return dt;
            // Dự phòng: cố gắng Parse thường
            return DateTime.Parse(s);
        }

        private static string Nz(string s) => (s ?? string.Empty).Trim();

        // ===== Đăng ký ca =====
        public bool Regis_Shift(string maNV, string maCa, string tgian, ref string err)
        {
            try
            {
                DateTime dt = ParseDate(tgian);

                using (var ctx = new QUANLYQUANTRADataContext())
                {
                    bool existed = ctx.QUANLYLUONGs.Any(p =>
                        p.ThoiGian == dt &&
                        p.MaNV.Trim() == Nz(maNV) &&
                        p.MaCa.Trim() == Nz(maCa));

                    if (existed) return false;

                    var ql = new QUANLYLUONG
                    {
                        ThoiGian = dt,
                        MaNV = Nz(maNV),
                        MaCa = Nz(maCa),
                        MucDoHoanThanh = 0,
                        Luong = 0
                    };
                    ctx.QUANLYLUONGs.InsertOnSubmit(ql);
                    ctx.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        // ===== Lương/giờ cho ca =====
        private double TienLuongca(string maCa)
        {
            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var ca = ctx.CALAMs.FirstOrDefault(p => p.MaCa.Trim() == Nz(maCa));
                // LuongTheoGio có thể là double?/float?
                return ca == null ? 0.0 : Convert.ToDouble(ca.LuongTheoGio);
            }
        }

        // ===== Khung giờ làm của từng ca =====
        public Dictionary<string, List<TimeSpan>> ThoiGianLam()
        {
            var list_time_ca = new Dictionary<string, List<TimeSpan>>();
            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var tsb = ctx.CALAMs.Select(p => new { p.MaCa, p.ThoiGianBatDau, p.ThoiGianKetThuc }).ToList();
                foreach (var r in tsb)
                {
                    var start = (TimeSpan)r.ThoiGianBatDau;
                    var end = (TimeSpan)r.ThoiGianKetThuc;
                    list_time_ca[Nz(r.MaCa)] = new List<TimeSpan> { start, end };
                }
            }
            return list_time_ca;
        }

        // ===== Số NV tối đa mỗi ca =====
        public Dictionary<string, int> Max_nv()
        {
            var list_max_ca = new Dictionary<string, int>();
            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var tsb = ctx.CALAMs.Select(p => new { p.MaCa, p.NhanVienToiDa }).ToList();
                foreach (var r in tsb)
                    list_max_ca[Nz(r.MaCa)] = Convert.ToInt32(r.NhanVienToiDa ?? 0);
            }
            return list_max_ca;
        }

        // ===== Chốt ca (cập nhật mức độ hoàn thành & lương) =====
        public bool Finish_work(string maNV, string tgian, string maCa, int rate, ref string err)
        {
            try
            {
                // Công thức cũ của bạn: 4 * lương/giờ * rate
                double luong = 4 * TienLuongca(maCa) * rate;
                DateTime dt = ParseDate(tgian);

                using (var ctx = new QUANLYQUANTRADataContext())
                {
                    var tsb = ctx.QUANLYLUONGs.FirstOrDefault(p =>
                        p.ThoiGian == dt &&
                        p.MaNV.Trim() == Nz(maNV) &&
                        p.MaCa.Trim() == Nz(maCa));

                    if (tsb == null) return false;

                    tsb.MucDoHoanThanh = rate;
                    tsb.Luong = (float)luong;
                    ctx.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        // ===== Danh sách đăng ký trong khoảng ngày =====
        private DataTable GetRegisList(DateTime start, DateTime end)
        {
            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var tsb = ctx.QUANLYLUONGs
                    .Where(p => p.ThoiGian >= start && p.ThoiGian <= end)
                    .Select(p => new { p.ThoiGian, p.MaNV, p.MaCa, p.MucDoHoanThanh, p.Luong })
                    .ToList();

                var tb = new DataTable();
                tb.Columns.Add("ThoiGian", typeof(DateTime));
                tb.Columns.Add("MaNV", typeof(string));
                tb.Columns.Add("MaCa", typeof(string));
                tb.Columns.Add("MucDoHoanThanh", typeof(int));
                tb.Columns.Add("Luong", typeof(float));

                foreach (var p in tsb)
                    tb.Rows.Add(p.ThoiGian, p.MaNV, p.MaCa, p.MucDoHoanThanh, p.Luong);

                return tb;
            }
        }

        // → Nếu bạn muốn mã ca hiển thị cả năm, đổi "dd/MM" thành "dd/MM/yyyy"
        private string Get_shift_code(DataRow row)
        {
            string maCa = Nz((string)row["MaCa"]);
            DateTime dt = (DateTime)row["ThoiGian"];
            return $"{maCa}-{dt:dd/MM/yyyy}";
        }

        private string GetName(string MaNV)
        {
            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var nv = ctx.NHANVIENs.FirstOrDefault(p => p.MaNV == MaNV);
                var name = Nz(nv?.TenNV);
                var parts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return parts.Length > 0 ? parts[parts.Length - 1] : string.Empty;

            }
        }

        public List<List<string>> LoadTimeTable(DateTime start, DateTime end)
        {
            var list_ca = new List<List<string>>();
            var tb = GetRegisList(start, end);
            foreach (DataRow row in tb.Select())
            {
                var temp = new List<string>
                {
                    Get_shift_code(row),                 // có cả năm
                    Nz((string)row["MaNV"]),
                    GetName(Nz((string)row["MaNV"]))
                };
                list_ca.Add(temp);
            }
            return list_ca;
        }
    }
}
