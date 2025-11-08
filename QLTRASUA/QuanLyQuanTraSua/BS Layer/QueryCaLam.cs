using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanTraSua.BS_Layer
{
    class QueryCaLam
    {
        public bool Regis_Shift(string maNV, string maCa, string tgian, ref string err)
        {
            string[] tg = tgian.Split('-');
            DateTime dt = new DateTime(Int32.Parse(tg[0]), Int32.Parse(tg[1]), Int32.Parse(tg[2]));

            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var tsb = ctx.QUANLYLUONGs
                             .SingleOrDefault(p => p.ThoiGian == dt
                                                && p.MaNV.Trim() == maNV
                                                && p.MaCa.Trim() == maCa);
                if (tsb != null) return false;

                var ql = new QUANLYLUONG
                {
                    ThoiGian = dt,
                    MaNV = maNV,
                    MaCa = maCa,
                    MucDoHoanThanh = 0,
                    Luong = 0
                };
                ctx.QUANLYLUONGs.InsertOnSubmit(ql);
                ctx.SubmitChanges();
                return true;
            }
        }

        private double TienLuongca(string maCa)
        {
            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var ca = ctx.CALAMs.SingleOrDefault(p => p.MaCa.Trim() == maCa);
                return ca?.LuongTheoGio ?? 0.0;
            }
        }

        public Dictionary<string, List<TimeSpan>> ThoiGianLam()
        {
            var list_time_ca = new Dictionary<string, List<TimeSpan>>();

            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var tsb = ctx.CALAMs.Select(p => new
                {
                    p.MaCa,
                    p.ThoiGianBatDau,
                    p.ThoiGianKetThuc
                });

                foreach (var r in tsb)
                {
                    var start = (TimeSpan)r.ThoiGianBatDau;
                    var end = (TimeSpan)r.ThoiGianKetThuc;

                    list_time_ca[r.MaCa.Trim()] = new List<TimeSpan> { start, end };
                }
            }
            return list_time_ca;
        }

        public Dictionary<string, int> Max_nv()
        {
            var list_max_ca = new Dictionary<string, int>();

            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var tsb = ctx.CALAMs.Select(p => new { p.MaCa, p.NhanVienToiDa });
                foreach (var r in tsb)
                {
                    list_max_ca[r.MaCa.Trim()] = (int)r.NhanVienToiDa;
                }
            }
            return list_max_ca;
        }

        public bool Finish_work(string maNV, string tgian, string maCa, int rate, ref string err)
        {
            double luong = 4 * TienLuongca(maCa) * rate;

            string[] tg = tgian.Split('-');
            DateTime dt = new DateTime(Int32.Parse(tg[0]), Int32.Parse(tg[1]), Int32.Parse(tg[2]));

            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var tsb = ctx.QUANLYLUONGs
                             .SingleOrDefault(p => p.ThoiGian == dt
                                                && p.MaNV.Trim() == maNV
                                                && p.MaCa.Trim() == maCa);
                if (tsb != null)
                {
                    tsb.MucDoHoanThanh = rate;
                    tsb.Luong = (float)luong;
                    ctx.SubmitChanges();               // BỔ SUNG: commit thay đổi
                    return true;
                }
                return false;
            }
        }

        private DataTable GetRegisList(DateTime start, DateTime end)
        {
            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var tsb = ctx.QUANLYLUONGs
                             .Where(p => p.ThoiGian >= start && p.ThoiGian <= end)
                             .Select(p => new
                             {
                                 p.ThoiGian,
                                 p.MaNV,
                                 p.MaCa,
                                 p.MucDoHoanThanh,
                                 p.Luong
                             });

                DataTable tb = new DataTable();
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

        private string Get_shift_code(DataRow row)
        {
            // Cột ThoiGian đang là DateTime trong DataTable → ép kiểu trực tiếp
            var maCa = ((string)row["MaCa"]).Trim();
            DateTime dt = (DateTime)row["ThoiGian"];
            return maCa + "-" + dt.ToString("dd/MM");
        }

        private string GetName(string MaNV)
        {
            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var nv = ctx.NHANVIENs.SingleOrDefault(p => p.MaNV == MaNV);
                var name = nv?.TenNV ?? string.Empty;
                var parts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return parts.Length > 0 ? parts[parts.Length - 1] : string.Empty;
            }
        }

        public List<List<string>> LoadTimeTable(DateTime start, DateTime end)
        {
            var list_ca = new List<List<string>>();
            DataTable tb = GetRegisList(start, end);
            DataRow[] list_row = tb.Select();

            foreach (DataRow row in list_row)
            {
                var temp = new List<string>();
                temp.Add(Get_shift_code(row));
                temp.Add((string)row["MaNV"]);
                temp.Add(GetName((string)row["MaNV"]));
                list_ca.Add(temp);
            }
            return list_ca;
        }
    }
}
