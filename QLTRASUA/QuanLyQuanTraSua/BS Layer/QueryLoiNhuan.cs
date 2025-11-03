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
    class QueryLoiNhuan
    {

        public Table<LOINHUAN> LayLoiNhuan()
        {
            
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            return qlbhEntity.LOINHUANs;
        }
        public bool ThemLoiNhuan(string Year, string Month, string doanhthu, string chiphi, string loinhuan, ref string err)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            int year = Int32.Parse(Year);
            int thang = Int32.Parse(Month);

            LOINHUAN ln = new LOINHUAN();
            ln.Nam = Int32.Parse(Year);
            ln.Thang = Int32.Parse(Month);
            ln.DoanhThu = (float?)double.Parse(doanhthu);
            ln.ChiPhi = (float?)double.Parse(chiphi);
            ln.LoiNhuan1= (float?)double.Parse(loinhuan);

            qlbhEntity.LOINHUANs.InsertOnSubmit(ln);
            qlbhEntity.LOINHUANs.Context.SubmitChanges();

            return true;
        }

        public bool CapNhatLoiNhuan(string Year, string Month, string doanhthu, string chiphi, string loinhuan, ref string err)
        {
            int year = Int32.Parse(Year);
            int thang = Int32.Parse(Month);
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tsb = (from p in qlbhEntity.LOINHUANs
                       where p.Nam == year && p.Thang == thang
                       select p).SingleOrDefault();

            if (tsb != null)
            {
                tsb.DoanhThu = (float)(Double.Parse(doanhthu));
                tsb.ChiPhi = (float)(Double.Parse(chiphi));
                tsb.LoiNhuan1 = (float)(Double.Parse(loinhuan));
                qlbhEntity.SubmitChanges();
            }
            return true;
        }
        public DataTable LayLoiNhuanTuDTCP()
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = from p in qlbhEntity.DOANHTHUs
                       join sa in qlbhEntity.CHIs on new { Nam = p.Nam, Thang = p.Thang } equals new { Nam = sa.Nam, Thang = sa.Thang}
                       select new
                       {
                           Nam = p.Nam,
                           Thang = p.Thang,
                           DoanhThu = p.DoanhThu1,
                           ChiPhi = sa.Tong,
                           LoiNhuan = p.DoanhThu1 - sa.Tong
                       };

            DataTable tb = new DataTable();
            tb.Columns.Add("Nam");
            tb.Columns.Add("Thang");
            tb.Columns.Add("DoanhThu");
            tb.Columns.Add("ChiPhi");
            tb.Columns.Add("LoiNhuan");

            foreach (var p in tsb)
                tb.Rows.Add(p.Nam, p.Thang, p.DoanhThu, p.ChiPhi, p.LoiNhuan);
            return tb;
        }

        public DataTable Kiemtra(string year, string month)
        {
            int Year = Int32.Parse(year);
            int Thang = Int32.Parse(month);
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = (from p in qlbhEntity.LOINHUANs
                       where p.Nam == Year && p.Thang == Thang
                       select p).SingleOrDefault();
           
            DataTable tb = new DataTable();
            tb.Columns.Add("Nam");
            tb.Columns.Add("Thang");
            tb.Columns.Add("DoanhThu");
            tb.Columns.Add("ChiPhi");
            tb.Columns.Add("LoiNhuan");
                
            tb.Rows.Add(tsb.Nam, tsb.Thang, tsb.DoanhThu, tsb.ChiPhi, tsb.LoiNhuan1);
            return tb;
            
          
        }

    }
}
