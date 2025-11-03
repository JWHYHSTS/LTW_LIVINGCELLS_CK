using System;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace QuanLyQuanTraSua.BS_Layer
{
    class QueryDoanhThu
    {
        public void LayDoanhThuTudonHang(int year, int month, out float doanhthu, out int sdh, int day=32)
        {
            doanhthu = 0;
            sdh = 0;
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = (from p in qlbhEntity.HOADONs where p.NgayXuatHD.Day<day select p)
                       .GroupBy(c => new { c.NgayXuatHD.Year, c.NgayXuatHD.Month })
                       .Select(g => new { Nam=g.Key.Year, Thang=g.Key.Month , DoanhThu = g.Sum(x => x.ThanhTien), SoDonHang = g.Select(x=>x.MaHD).Count()});

            var tsb1 = (from p in tsb
                       where p.Nam == year && p.Thang == month
                       select new
                       {
                           DoanhThu = p.DoanhThu,
                           SoDonHang= p.SoDonHang
                       }).SingleOrDefault();

           if (tsb1!=null)
            {
                doanhthu = tsb1.DoanhThu;
                sdh = tsb1.SoDonHang;
            }
            
        }

        
        public bool ThemDoanhThu(int Year, int Month, float doanhthu, int sdh)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            
            DOANHTHU dt = new DOANHTHU();
            dt.Nam = Year;
            dt.Thang = Month;
            dt.DoanhThu1 = doanhthu;
            dt.SoDonHang = sdh;

            qlbhEntity.DOANHTHUs.InsertOnSubmit(dt);
            qlbhEntity.DOANHTHUs.Context.SubmitChanges();

            return true;
        }

        public void CapNhatDoanhThu(DateTime today)
        {
            int year = today.Year;
            int month = today.Month;
            int last_month = 1;
            float doanhthu = 0 ;
            int donhang = 0;
    
            if (month > 1)
                last_month = month - 1;
            else
            {
                last_month = 12;
                year = year - 1;
            }
            bool check = Kiemtra(year, last_month);
            if (check == true)
                return;
            else
            {
                LayDoanhThuTudonHang(year, last_month, out doanhthu, out donhang);
                ThemDoanhThu(year, last_month, doanhthu, donhang);
            }

        }

        public void CapNhatDoanhThuThang(DateTime today, out float doanhthu, out int donhang)
        {
            int year = today.Year;
            int month = today.Month;
            int day = today.Day;
            doanhthu = 0;
            donhang = 0;
            LayDoanhThuTudonHang(year, month, out doanhthu, out donhang);
        }

        private bool Kiemtra(int Year, int Month)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            
            var tsb = (from p in qlbhEntity.DOANHTHUs
                       where p.Nam == Year && p.Thang == Month
                       select p).SingleOrDefault();
            if (tsb != null)
                return true;
            return false;
        }


    }
}
