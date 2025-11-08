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
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                return qlbhEntity.LOINHUANs;
            }
        }

        public bool ThemLoiNhuan(string Year, string Month, string doanhthu, string chiphi, string loinhuan, ref string err)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                int year = Int32.Parse(Year);
                int thang = Int32.Parse(Month);

                var ln = new LOINHUAN
                {
                    Nam = year,
                    Thang = thang,
                    DoanhThu = (float?)double.Parse(doanhthu),
                    ChiPhi = (float?)double.Parse(chiphi),
                    LoiNhuan1 = (float?)double.Parse(loinhuan)
                };

                qlbhEntity.LOINHUANs.InsertOnSubmit(ln);
                qlbhEntity.LOINHUANs.Context.SubmitChanges();
                return true;
            }
        }

        public bool CapNhatLoiNhuan(string Year, string Month, string doanhthu, string chiphi, string loinhuan, ref string err)
        {
            int year = Int32.Parse(Year);
            int thang = Int32.Parse(Month);

            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.LOINHUANs
                                    .Where(p => p.Nam == year && p.Thang == thang)
                                    .SingleOrDefault();

                if (tsb != null)
                {
                    tsb.DoanhThu = (float)Double.Parse(doanhthu);
                    tsb.ChiPhi = (float)Double.Parse(chiphi);
                    tsb.LoiNhuan1 = (float)Double.Parse(loinhuan);
                    qlbhEntity.SubmitChanges();
                }
                return true;
            }
        }

        public DataTable LayLoiNhuanTuDTCP()
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.DOANHTHUs
                    .Join(qlbhEntity.CHIs,
                          p => new { p.Nam, p.Thang },
                          sa => new { sa.Nam, sa.Thang },
                          (p, sa) => new
                          {
                              Nam = p.Nam,
                              Thang = p.Thang,
                              DoanhThu = p.DoanhThu1,
                              ChiPhi = sa.Tong,
                              LoiNhuan = p.DoanhThu1 - sa.Tong
                          });

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
        }

        public DataTable Kiemtra(string year, string month)
        {
            int Year = Int32.Parse(year);
            int Thang = Int32.Parse(month);

            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.LOINHUANs
                                    .Where(p => p.Nam == Year && p.Thang == Thang)
                                    .SingleOrDefault();

                DataTable tb = new DataTable();
                tb.Columns.Add("Nam");
                tb.Columns.Add("Thang");
                tb.Columns.Add("DoanhThu");
                tb.Columns.Add("ChiPhi");
                tb.Columns.Add("LoiNhuan");

                if (tsb != null)
                    tb.Rows.Add(tsb.Nam, tsb.Thang, tsb.DoanhThu, tsb.ChiPhi, tsb.LoiNhuan1);

                return tb;
            }
        }
    }
}
