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
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = from p in qlbhEntity.BANGLUONGs
                      where p.Nam == year && p.Thang == last_month
                      select p;
            
            if (tsb==null)
            {
                CapNhatLuong(last_month, year);
            }
        }

        private void CapNhatLuong(int month, int year)
        {
            
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            DateTime start = new DateTime(year, month, 1);
            DateTime end = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            var tsb1 = from p in qlbhEntity.QUANLYLUONGs where p.ThoiGian >= start && p.ThoiGian <= end select p;

            var tsb2 = tsb1.GroupBy(x => x.MaNV).Select(g => new { MaNV = g.Key, LuongThang = g.Sum(x => x.Luong) });
            BANGLUONG bl = new BANGLUONG();
            foreach (var p in tsb2)
            {
                bl = new BANGLUONG();
                bl.Nam = year;
                bl.Thang = month;
                bl.MaNV = p.MaNV;
                bl.TienLuong = p.LuongThang;

                qlbhEntity.BANGLUONGs.InsertOnSubmit(bl);
                qlbhEntity.BANGLUONGs.Context.SubmitChanges();
            }
        }

        public DataTable TinhLuongTam(int year, int month, int day)
        {
            
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            DateTime start = new DateTime(year, month, 1);
            DateTime end = new DateTime(year, month, day);
            var tsb1 = from p in qlbhEntity.QUANLYLUONGs where p.ThoiGian >= start && p.ThoiGian <= end select p;

            var tsb2 = from p in tsb1
                       join sa in qlbhEntity.NHANVIENs on p.MaNV equals sa.MaNV
                       select new
                       {
                           MaNV = p.MaNV,
                           TenNV = sa.TenNV,
                           MaCa = p.MaCa,
                           Luong = p.Luong
                       };

            var tsb3=tsb2.GroupBy(c => new
             {
                 c.MaNV,
                 c.TenNV,
                
             })
            .Select(gcs => new 
            {
                MaNV = gcs.Key.MaNV,
                TenNV = gcs.Key.TenNV,
                LuongThang = gcs.Sum(x=>x.Luong)
                
            });

            DataTable tb = new DataTable();
            tb.Columns.Add("MaNV");
            tb.Columns.Add("TenNV");
            tb.Columns.Add("LuongThang");

            foreach (var p in tsb3)
                tb.Rows.Add(p.MaNV, p.TenNV, p.LuongThang);

            return tb;
        }

        public DataTable LayNhanVien()
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = from p in qlbhEntity.NHANVIENs
                      where p.ConLam == true
                      select new
                      {
                          MaNV = p.MaNV,
                          TenNV = p.TenNV,
                          SDT = p.SDT,
                          DiaChi = p.DiaChi,
                          NgayNV = p.NgayNV,
                          CMND = p.CMND
                      };

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

        public bool ThemNhanVien(string MaNhanVien, string TenNhanVien, string sdt, string diaChi, string ngayNV, string cmnd, ref string err)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            NHANVIEN nv = new NHANVIEN();
            nv.MaNV = MaNhanVien;
            nv.TenNV = TenNhanVien;
            nv.SDT = sdt;
            nv.DiaChi = diaChi;
            nv.NgayNV = DateTime.Parse(ngayNV);
            nv.CMND = cmnd;
            nv.ConLam = true;

            qlbhEntity.NHANVIENs.InsertOnSubmit(nv);
            qlbhEntity.NHANVIENs.Context.SubmitChanges();
            return true;
        }
        public bool XoaNhanVien(ref string err, string MaNhanVien)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = from p in qlbhEntity.NHANVIENs where p.MaNV.Trim() == MaNhanVien select p;
            XoaDangNhap(MaNhanVien, ref err);
            return true;
        }
        private bool XoaDangNhap(string MaNhanVien, ref string err)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = from p in qlbhEntity.NHANVIENs where p.MaNV.Trim() == MaNhanVien select p;

            qlbhEntity.NHANVIENs.DeleteAllOnSubmit(tsb);
            qlbhEntity.SubmitChanges();

            return true;
        }
        public bool CapNhatNhanVien(string MaNhanVien, string TenNhanVien, string sdt, string diaChi, string ngayNV, string cmnd, ref string err)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = (from p in qlbhEntity.NHANVIENs where p.MaNV.Trim() == MaNhanVien select p).SingleOrDefault();
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

        public DataTable LocNhanVien(string text)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = from p in qlbhEntity.NHANVIENs where p.TenNV.Trim().Contains(text) || p.MaNV.Trim().Contains(text) || p.SDT.Trim().Contains(text) || p.DiaChi.Trim().Contains(text) || p.CMND.Trim().Contains(text) || p.NgayNV.ToString().Contains(text)
                      select p;

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

        public string GetLastIndex()
        {
            
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var cp = from p in qlbhEntity.NHANVIENs select p;
            DataTable tb = new DataTable();
            tb.Columns.Add("MaNV");

            foreach (var p in cp)
                tb.Rows.Add(p.MaNV);
            DataRow[] filter = tb.Select();
            int count = filter.Length;
            DataRow lastrow = filter[count - 1];
            string id = lastrow["MaNV"].ToString().Trim();
            string[] listcode = id.Split('V');
            int index = Int32.Parse(listcode[1]);
            string next_id = "NV";
            next_id = next_id + (index + 1).ToString().PadLeft(3, '0');
            return next_id;
        }

    }
}
