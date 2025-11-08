using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanTraSua.BS_Layer
{
    class QueryChiPhi
    {
        public DataTable LayChiPhi()
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.CHIs
                                    .Select(p => p);

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
        }

        public bool CapNhatChiPhi(string Year, string Month, string LuongNV, string PNL, string tiendien, string tiennuoc, string pvs, string tong, ref string err)
        {
            int year = Int32.Parse(Year);
            int thang = Int32.Parse(Month);

            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.CHIs
                                    .SingleOrDefault(p => p.Nam == year && p.Thang == thang);

                if (tsb != null)
                {
                    tsb.LuongNV = (float)Double.Parse(LuongNV);
                    tsb.PhiNguyenLieu = (float)Double.Parse(PNL);
                    tsb.TienDien = (float)Double.Parse(tiendien);
                    tsb.TienNuoc = (float)Double.Parse(tiennuoc);
                    tsb.PhiVeSinh = (float)Double.Parse(pvs);
                    // tsb.Tong có thể do DB trigger/tính khác; giữ nguyên nếu bạn không set ở đây.

                    qlbhEntity.SubmitChanges();
                }
            }
            return true;
        }

        public bool ThemChiPhi(string Year, string Month, string LuongNV, string PNL, string tiendien, string tiennuoc, string pvs, string tong, ref string err)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var c = new CHI
                {
                    Nam = Int32.Parse(Year),
                    Thang = Int32.Parse(Month),
                    LuongNV = (float)Double.Parse(LuongNV),
                    PhiNguyenLieu = (float)Double.Parse(PNL),
                    TienDien = (float)Double.Parse(tiendien),
                    TienNuoc = (float)Double.Parse(tiennuoc),
                    PhiVeSinh = (float)Double.Parse(pvs)
                    // c.Tong nếu cần thì set thêm
                };

                qlbhEntity.CHIs.InsertOnSubmit(c);
                qlbhEntity.CHIs.Context.SubmitChanges();
                return true;
            }
        }

        public DataTable LayThongTin(string year)
        {
            int Year;
            if (!Int32.TryParse(year, out Year))
            {
                MessageBox.Show($"Giá trị năm không hợp lệ: '{year}'", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null; // hoặc return DataTable rỗng nếu bạn muốn
            }
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.CHIs
                                    .Where(p => p.Nam == Year)
                                    .Select(p => p);

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
        }

        public DataTable Kiemtra(string year, string month)
        {
            int Year = Int32.Parse(year);
            int Month = Int32.Parse(month);

            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.CHIs
                                    .Where(p => p.Nam == Year && p.Thang == Month)   // sửa điều kiện đúng cột
                                    .Select(p => p);

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
        }

        public string CapNhatChiPhiHienTai(DateTime today)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.QUANLYLUONGs
                                    .Where(p => p.ThoiGian.Year == today.Year && p.ThoiGian.Month == today.Month)
                                    .GroupBy(c => c.ThoiGian.Year)
                                    .Select(g => new { LuongTam = g.Sum(x => x.Luong) })
                                    .SingleOrDefault();

                if (tsb != null)
                    return tsb.LuongTam.ToString();

                return "0";
            }
        }
    }
}
