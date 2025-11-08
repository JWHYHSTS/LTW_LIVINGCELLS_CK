using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace QuanLyQuanTraSua.BS_Layer
{
    class QueryNhanVien
    {
        DateTime today = DateTime.Now;

        public void CapNhatBangLuong()
        {
            int last_month, year;
            if (today.Month > 1)
            {
                last_month = today.Month - 1;
                year = today.Year;
            }
            else
            {
                last_month = 12;
                year = today.Year - 1;
            }

            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.BANGLUONGs
                    .Where(p => p.Nam == year && p.Thang == last_month)
                    .Select(p => p)
                    .ToList();

                if (tsb == null || tsb.Count == 0)
                {
                    CapNhatLuong(last_month, year);
                }
            }
        }

        private void CapNhatLuong(int month, int year)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                DateTime start = new DateTime(year, month, 1);
                DateTime end = new DateTime(year, month, DateTime.DaysInMonth(year, month));

                var tsb2 = qlbhEntity.QUANLYLUONGs
                    .Where(p => p.ThoiGian >= start && p.ThoiGian <= end)
                    .GroupBy(x => x.MaNV)
                    .Select(g => new
                    {
                        MaNV = g.Key,
                        LuongThang = g.Sum(x => x.Luong)
                    })
                    .ToList();

                foreach (var p in tsb2)
                {
                    var bl = new BANGLUONG
                    {
                        Nam = year,
                        Thang = month,
                        MaNV = p.MaNV,
                        TienLuong = p.LuongThang
                    };
                    qlbhEntity.BANGLUONGs.InsertOnSubmit(bl);
                    qlbhEntity.BANGLUONGs.Context.SubmitChanges();
                }
            }
        }

        public DataTable TinhLuongTam(int year, int month, int day)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                DateTime start = new DateTime(year, month, 1);
                DateTime end = new DateTime(year, month, day);

                var tsb3 = qlbhEntity.QUANLYLUONGs
                    .Where(p => p.ThoiGian >= start && p.ThoiGian <= end)
                    .Join(qlbhEntity.NHANVIENs,
                          p => p.MaNV,
                          nv => nv.MaNV,
                          (p, nv) => new { p.MaNV, nv.TenNV, p.MaCa, p.Luong })
                    .GroupBy(c => new { c.MaNV, c.TenNV })
                    .Select(g => new
                    {
                        MaNV = g.Key.MaNV,
                        TenNV = g.Key.TenNV,
                        LuongThang = g.Sum(x => x.Luong)
                    })
                    .ToList();

                DataTable tb = new DataTable();
                tb.Columns.Add("MaNV");
                tb.Columns.Add("TenNV");
                tb.Columns.Add("LuongThang");

                foreach (var p in tsb3)
                    tb.Rows.Add(p.MaNV, p.TenNV, p.LuongThang);

                return tb;
            }
        }

        public DataTable LayNhanVien()
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.NHANVIENs
                    .Where(p => p.ConLam == true)
                    .Select(p => new
                    {
                        p.MaNV,
                        p.TenNV,
                        p.SDT,
                        p.DiaChi,
                        p.NgayNV,
                        p.CMND
                    })
                    .ToList();

                DataTable tb = new DataTable();
                tb.Columns.Add("MaNV");
                tb.Columns.Add("TenNV");
                tb.Columns.Add("SDT");
                tb.Columns.Add("DiaChi");
                tb.Columns.Add("NgayNV");
                tb.Columns.Add("CMND");

                foreach (var p in tsb)
                    tb.Rows.Add(p.MaNV, p.TenNV, p.SDT, p.DiaChi, p.NgayNV, p.CMND);

                return tb;
            }
        }

        public bool ThemNhanVien(string MaNhanVien, string TenNhanVien, string sdt, string diaChi, string ngayNV, string cmnd, ref string err)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var nv = new NHANVIEN
                {
                    MaNV = MaNhanVien,
                    TenNV = TenNhanVien,
                    SDT = sdt,
                    DiaChi = diaChi,
                    NgayNV = DateTime.Parse(ngayNV),
                    CMND = cmnd,
                    ConLam = true
                };

                qlbhEntity.NHANVIENs.InsertOnSubmit(nv);
                qlbhEntity.NHANVIENs.Context.SubmitChanges();
                return true;
            }
        }

        public bool XoaNhanVien(ref string err, string MaNhanVien)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.NHANVIENs
                    .Where(p => p.MaNV.Trim() == MaNhanVien)
                    .ToList();

                XoaDangNhap(MaNhanVien, ref err);
                return true;
            }
        }

        private bool XoaDangNhap(string MaNhanVien, ref string err)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.NHANVIENs
                    .Where(p => p.MaNV.Trim() == MaNhanVien);

                qlbhEntity.NHANVIENs.DeleteAllOnSubmit(tsb);
                qlbhEntity.SubmitChanges();
                return true;
            }
        }

        public bool CapNhatNhanVien(string MaNhanVien, string TenNhanVien, string sdt, string diaChi, string ngayNV, string cmnd, ref string err)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.NHANVIENs
                    .Where(p => p.MaNV.Trim() == MaNhanVien)
                    .SingleOrDefault();

                if (tsb != null)
                {
                    tsb.TenNV = TenNhanVien;
                    tsb.SDT = sdt;
                    tsb.DiaChi = diaChi;
                    tsb.NgayNV = DateTime.Parse(ngayNV);
                    tsb.CMND = cmnd;
                    qlbhEntity.SubmitChanges();
                }
                return true;
            }
        }

        public DataTable LocNhanVien(string text)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var all = qlbhEntity.NHANVIENs.ToList();
                var tsb = all.Where(p =>
                    (p.TenNV ?? "").Trim().Contains(text) ||
                    (p.MaNV ?? "").Trim().Contains(text) ||
                    (p.SDT ?? "").Trim().Contains(text) ||
                    (p.DiaChi ?? "").Trim().Contains(text) ||
                    (p.CMND ?? "").Trim().Contains(text) ||
                    p.NgayNV.ToString().Contains(text)
                );

                DataTable tb = new DataTable();
                tb.Columns.Add("MaNV");
                tb.Columns.Add("TenNV");
                tb.Columns.Add("SDT");
                tb.Columns.Add("DiaChi");
                tb.Columns.Add("NgayNV");
                tb.Columns.Add("CMND");

                foreach (var p in tsb)
                    tb.Rows.Add(p.MaNV, p.TenNV, p.SDT, p.DiaChi, p.NgayNV, p.CMND);

                return tb;
            }
        }

        public string GetLastIndex()
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var all = qlbhEntity.NHANVIENs
                    .Select(p => p.MaNV)
                    .ToList();

                if (all.Count == 0)
                    return "NV001";

                string id = all.Last().Trim();
                string[] listcode = id.Split('V');
                int index = Int32.Parse(listcode[1]);
                string next_id = "NV" + (index + 1).ToString().PadLeft(3, '0');
                return next_id;
            }
        }
    }
}
