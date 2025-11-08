using System;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace QuanLyQuanTraSua.BS_Layer
{
    class QueryDoanhThu
    {
        public void LayDoanhThuTudonHang(int year, int month, out float doanhthu, out int sdh, int day = 32)
        {
            doanhthu = 0;
            sdh = 0;

            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.HOADONs
                    .Where(p => p.NgayXuatHD.Day < day)
                    .GroupBy(c => new { c.NgayXuatHD.Year, c.NgayXuatHD.Month })
                    .Select(g => new
                    {
                        Nam = g.Key.Year,
                        Thang = g.Key.Month,
                        DoanhThu = g.Sum(x => x.ThanhTien),
                        SoDonHang = g.Select(x => x.MaHD).Count()
                    });

                var tsb1 = tsb
                    .Where(p => p.Nam == year && p.Thang == month)
                    .Select(p => new
                    {
                        DoanhThu = p.DoanhThu,
                        SoDonHang = p.SoDonHang
                    })
                    .SingleOrDefault();

                if (tsb1 != null)
                {
                    doanhthu = tsb1.DoanhThu;
                    sdh = tsb1.SoDonHang;
                }
            }
        }

        public bool ThemDoanhThu(int Year, int Month, float doanhthu, int sdh)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var dt = new DOANHTHU
                {
                    Nam = Year,
                    Thang = Month,
                    DoanhThu1 = doanhthu,
                    SoDonHang = sdh
                };

                qlbhEntity.DOANHTHUs.InsertOnSubmit(dt);
                qlbhEntity.DOANHTHUs.Context.SubmitChanges();
                return true;
            }
        }

        public void CapNhatDoanhThu(DateTime today)
        {
            int year = today.Year;
            int month = today.Month;
            int last_month = month > 1 ? month - 1 : 12;
            if (month == 1) year--;

            bool check = Kiemtra(year, last_month);
            if (check) return;

            LayDoanhThuTudonHang(year, last_month, out float doanhthu, out int donhang);
            ThemDoanhThu(year, last_month, doanhthu, donhang);
        }

        public void CapNhatDoanhThuThang(DateTime today, out float doanhthu, out int donhang)
        {
            int year = today.Year;
            int month = today.Month;

            doanhthu = 0;
            donhang = 0;

            LayDoanhThuTudonHang(year, month, out doanhthu, out donhang);
        }

        private bool Kiemtra(int Year, int Month)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.DOANHTHUs
                    .Where(p => p.Nam == Year && p.Thang == Month)
                    .SingleOrDefault();

                return tsb != null;
            }
        }
    }
}
