using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanTraSua.BS_Layer
{
    class QueryCaLam
    {
        public bool Regis_Shift(string maNV, string maCa, string tgian, ref string err)
        {
            try
            {
                // tgian dạng "yyyy-MM-dd" hoặc "yyyy-M-d"
                string[] tg = tgian.Split('-');
                var dt = new DateTime(int.Parse(tg[0]), int.Parse(tg[1]), int.Parse(tg[2]));

                using (var db = new QUANLYQUANTRADataContext())
                {
                    var existed = db.QUANLYLUONGs
                        .SingleOrDefault(p => p.ThoiGian == dt
                                           && p.MaNV.Trim() == maNV
                                           && p.MaCa.Trim() == maCa);
                    if (existed != null) return false;

                    var ql = new QUANLYLUONG
                    {
                        ThoiGian = dt,
                        MaNV = maNV,
                        MaCa = maCa,
                        MucDoHoanThanh = 0,
                        Luong = 0
                    };
                    db.QUANLYLUONGs.InsertOnSubmit(ql);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        private double TienLuongca(string maCa)
        {
            // Trả về 0 nếu không tìm thấy ca để tránh NullReference
            if (string.IsNullOrWhiteSpace(maCa)) return 0;

            using (var db = new QUANLYQUANTRADataContext())
            {
                var ca = db.CALAMs.SingleOrDefault(p => p.MaCa.Trim() == maCa.Trim());
                return ca != null ? ca.LuongTheoGio : 0;
            }
        }

        public Dictionary<string, List<TimeSpan>> ThoiGianLam()
        {
            var list = new Dictionary<string, List<TimeSpan>>(StringComparer.OrdinalIgnoreCase);

            using (var db = new QUANLYQUANTRADataContext())
            {
                var query = from p in db.CALAMs select p;

                foreach (var r in query)
                {
                    var start = (TimeSpan)r.ThoiGianBatDau;
                    var end = (TimeSpan)r.ThoiGianKetThuc;

                    list[r.MaCa.Trim()] = new List<TimeSpan> { start, end };
                }
            }
            return list;
        }

        public Dictionary<string, int> Max_nv()
        {
            var result = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            using (var db = new QUANLYQUANTRADataContext())
            {
                var query = from p in db.CALAMs select p;

                foreach (var r in query)
                {
                    result[r.MaCa.Trim()] = (int)r.NhanVienToiDa;
                }
            }
            return result;
        }

        public bool Finish_work(string maNV, string tgian, string maCa, int rate, ref string err)
        {
            try
            {
                // Tính lương: 4 giờ * lương theo giờ * hệ số hoàn thành
                double luong = 4 * TienLuongca(maCa) * rate;

                string[] tg = tgian.Split('-');
                var dt = new DateTime(int.Parse(tg[0]), int.Parse(tg[1]), int.Parse(tg[2]));

                using (var db = new QUANLYQUANTRADataContext())
                {
                    var row = db.QUANLYLUONGs
                                .SingleOrDefault(p => p.ThoiGian == dt
                                                   && p.MaNV.Trim() == maNV
                                                   && p.MaCa.Trim() == maCa);
                    if (row == null)
                    {
                        err = "Không tìm thấy đăng ký ca để chốt công.";
                        return false;
                    }

                    row.MucDoHoanThanh = rate;
                    row.Luong = (float)luong;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        private DataTable GetRegisList(DateTime start, DateTime end)
        {
            var tb = new DataTable();
            tb.Columns.Add("ThoiGian", typeof(DateTime));
            tb.Columns.Add("MaNV", typeof(string));
            tb.Columns.Add("MaCa", typeof(string));
            tb.Columns.Add("MucDoHoanThanh", typeof(float));  // đổi sang float
            tb.Columns.Add("Luong", typeof(float));

            using (var db = new QUANLYQUANTRADataContext())
            {
                var query = db.QUANLYLUONGs
                              .Where(p => p.ThoiGian >= start && p.ThoiGian <= end);

                foreach (var p in query)
                {
                    float mdht = p.MucDoHoanThanh.HasValue ? p.MucDoHoanThanh.Value : 0f;
                    float luong = p.Luong.HasValue ? p.Luong.Value : 0f;

                    tb.Rows.Add(p.ThoiGian, p.MaNV, p.MaCa, mdht, luong);
                }
            }
            return tb;
        }

        private string Get_shift_code(DataRow row)
        {
            var maCa = ((string)row["MaCa"]).Trim();
            var dt = (DateTime)row["ThoiGian"];
            return string.Format("{0}-{1:dd/MM}", maCa, dt);
        }

        private string GetName(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV)) return "";

            using (var db = new QUANLYQUANTRADataContext())
            {
                var nv = db.NHANVIENs.SingleOrDefault(p => p.MaNV == maNV);
                if (nv == null || string.IsNullOrWhiteSpace(nv.TenNV))
                    return "";

                string[] parts = nv.TenNV.Trim().Split(' ');
                // C# 7.3: không dùng ^1
                return parts.Length == 0 ? "" : parts[parts.Length - 1];
            }
        }

        public List<List<String>> LoadTimeTable(DateTime start, DateTime end)
        {
            var result = new List<List<string>>();
            var tb = GetRegisList(start, end);

            foreach (DataRow row in tb.Rows)
            {
                var maNV = (string)row["MaNV"];
                result.Add(new List<string>
                {
                    Get_shift_code(row),
                    maNV,
                    GetName(maNV)
                });
            }
            return result;
        }
    }
}
