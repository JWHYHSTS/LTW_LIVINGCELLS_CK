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
    class QueryKhachHang
    {
        public DataTable LayKhachHang()
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.KHACHHANGs.Select(p => p);

                DataTable tb = new DataTable();
                tb.Columns.Add("MaKH");
                tb.Columns.Add("TenKH");
                tb.Columns.Add("SDT");
                tb.Columns.Add("DiaChi");
                tb.Columns.Add("DiemTichLuy");

                foreach (var p in tsb)
                    tb.Rows.Add(p.MaKH, p.TenKH, p.SDT, p.DiaChi, p.DiemTichLuy);

                return tb;
            }
        }

        public bool CapNhatKhachHang(string MaKhachHang, string TenKH, string DiaChi, string DienThoai, ref string err)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.KHACHHANGs
                                    .Where(p => p.MaKH.Trim() == MaKhachHang)
                                    .SingleOrDefault();

                if (tsb != null)
                {
                    tsb.TenKH = TenKH;
                    tsb.DiaChi = DiaChi;
                    tsb.SDT = DienThoai;
                    qlbhEntity.SubmitChanges();
                }
                return true;
            }
        }

        public DataTable LayThongTin(string makh)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                var tsb = qlbhEntity.KHACHHANGs
                                    .Where(p => p.MaKH.Trim() == makh)
                                    .SingleOrDefault();

                DataTable tb = new DataTable();
                tb.Columns.Add("MaKH");
                tb.Columns.Add("TenKH");
                tb.Columns.Add("SDT");
                tb.Columns.Add("DiaChi");
                tb.Columns.Add("DiemTichLuy");

                if (tsb != null)
                    tb.Rows.Add(tsb.MaKH, tsb.TenKH, tsb.SDT, tsb.DiaChi, tsb.DiemTichLuy);

                return tb;
            }
        }

        public DataTable LocKhachHang(string text)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                // NOTE: Để giữ nguyên hành vi ".ToString().Contains(text)" trên DiemTichLuy (vốn khó dịch sang SQL),
                // mình load về bộ nhớ rồi lọc (tránh NotSupportedException). Không đổi logic tìm kiếm.
                var all = qlbhEntity.KHACHHANGs.Select(p => p).ToList();

                var filtered = all.Where(p =>
                        (p.TenKH ?? string.Empty).Trim().Contains(text)
                     || (p.MaKH ?? string.Empty).Trim().Contains(text)
                     || (p.SDT ?? string.Empty).Trim().Contains(text)
                     || (p.DiaChi ?? string.Empty).Trim().Contains(text)
                     || p.DiemTichLuy.ToString().Contains(text)
                );

                DataTable tb = new DataTable();
                tb.Columns.Add("MaKH");
                tb.Columns.Add("TenKH");
                tb.Columns.Add("SDT");
                tb.Columns.Add("DiaChi");
                tb.Columns.Add("DiemTichLuy");

                foreach (var p in filtered)
                    tb.Rows.Add(p.MaKH, p.TenKH, p.SDT, p.DiaChi, p.DiemTichLuy);

                return tb;
            }
        }
    }
}
