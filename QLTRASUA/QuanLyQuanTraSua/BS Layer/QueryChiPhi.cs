using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace QuanLyQuanTraSua.BS_Layer
{
    class QueryChiPhi
    {
        public DataTable LayChiPhi()
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = from p in qlbhEntity.CHIs
                      select p;

            DataTable tb = new DataTable();
            tb.Columns.Add("Nam");
            tb.Columns.Add("Thang");
            tb.Columns.Add("LuongNV");
            tb.Columns.Add("PhiNguyenLieu");
            tb.Columns.Add("TienDien");
            tb.Columns.Add("TienNuoc");
            tb.Columns.Add("PhiVeSinh");
            tb.Columns.Add("Tong");

            foreach (var p in tsb)
                tb.Rows.Add(p.Nam, p.Thang, p.LuongNV, p.PhiNguyenLieu, p.TienDien, p.TienNuoc, p.PhiVeSinh, p.Tong);
            return tb;
            //return qlbhEntity.CHIs;
            
        }

        public bool CapNhatChiPhi(string Year, string Month, string LuongNV, string PNL, string tiendien, string tiennuoc, string pvs, string tong, ref string err)
        {
            int year = Int32.Parse(Year);
            int thang = Int32.Parse(Month);

            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = (from p in qlbhEntity.CHIs
                      where p.Nam == year && p.Thang==thang
                      select p).SingleOrDefault();

            if (tsb!=null)
            {
                tsb.LuongNV = (float)(Double.Parse(LuongNV));
                tsb.PhiNguyenLieu = (float)(Double.Parse(PNL));
                tsb.TienDien = (float)(Double.Parse(tiendien));
                tsb.TienNuoc = (float)(Double.Parse(tiennuoc));
                tsb.PhiVeSinh = (float)(Double.Parse(pvs));

                qlbhEntity.SubmitChanges();
            }
            return true;


        }
        public bool ThemChiPhi(string Year, string Month, string LuongNV, string PNL, string tiendien, string tiennuoc, string pvs, string tong, ref string err)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            CHI c = new CHI();
            c.Nam = Int32.Parse(Year);
            c.Thang = Int32.Parse(Month);
            c.LuongNV = (float)(Double.Parse(LuongNV));
            c.PhiNguyenLieu = (float)(Double.Parse(PNL));
            c.TienDien= (float)(Double.Parse(tiendien));
            c.TienNuoc= (float)(Double.Parse(tiennuoc));
            c.PhiVeSinh = (float)(Double.Parse(pvs));

            qlbhEntity.CHIs.InsertOnSubmit(c);
            qlbhEntity.CHIs.Context.SubmitChanges();
            return true;

        }
        public DataTable LayThongTin(string year)
        {
            int Year = Int32.Parse(year);
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = from p in qlbhEntity.CHIs
                      where p.Nam==Year
                      select p;

            DataTable tb = new DataTable();
            tb.Columns.Add("Nam");
            tb.Columns.Add("Thang");
            tb.Columns.Add("LuongNV");
            tb.Columns.Add("PhiNguyenLieu");
            tb.Columns.Add("TienDien");
            tb.Columns.Add("TienNuoc");
            tb.Columns.Add("PhiVeSinh");
            tb.Columns.Add("Tong");

            foreach (var p in tsb)
                tb.Rows.Add(p.Nam, p.Thang,p.LuongNV, p.PhiNguyenLieu, p.TienDien, p.TienNuoc, p.PhiVeSinh, p.Tong);
            return tb;
           
        }
        public DataTable Kiemtra(string year, string month)
        {
            int Year = Int32.Parse(year);
            int Month = Int32.Parse(month);
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = from p in qlbhEntity.CHIs
                      where p.Nam == Year && p.Nam==Month
                      select p;

            DataTable tb = new DataTable();
            tb.Columns.Add("Nam");
            tb.Columns.Add("Thang");
            tb.Columns.Add("LuongNV");
            tb.Columns.Add("PhiNguyenLieu");
            tb.Columns.Add("TienDien");
            tb.Columns.Add("TienNuoc");
            tb.Columns.Add("PhiVeSinh");
            tb.Columns.Add("Tong");

            foreach (var p in tsb)
                tb.Rows.Add(p.Nam, p.Thang, p.LuongNV, p.PhiNguyenLieu, p.TienDien, p.TienNuoc, p.PhiVeSinh, p.Tong);
            return tb;
        }
        public string CapNhatChiPhiHienTai(DateTime today)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = (from p in qlbhEntity.QUANLYLUONGs where p.ThoiGian.Year == today.Year && p.ThoiGian.Month == today.Month select p)
                      .GroupBy(c => new { c.ThoiGian.Year })
                      .Select(g => new { LuongTam = g.Sum(x => x.Luong)}).SingleOrDefault();
            if (tsb!=null)
                return (tsb.LuongTam).ToString();
            return "0";
        }


    }
}
