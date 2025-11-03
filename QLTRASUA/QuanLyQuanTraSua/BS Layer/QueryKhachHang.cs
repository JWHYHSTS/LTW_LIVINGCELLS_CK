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
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            
            var tsb = from p in qlbhEntity.KHACHHANGs select p;
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

        public bool CapNhatKhachHang(string MaKhachHang, string TenKH, string DiaChi, string DienThoai, ref string err)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tsb = (from p in qlbhEntity.KHACHHANGs where p.MaKH.Trim()==MaKhachHang select p).SingleOrDefault();
            if (tsb!=null)
            {
                tsb.TenKH = TenKH;
                tsb.DiaChi = DiaChi;
                tsb.SDT = DienThoai;
                qlbhEntity.SubmitChanges();
                
            }
            return true;
            
        }
        public DataTable LayThongTin(string makh)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tsb = (from p in qlbhEntity.KHACHHANGs where p.MaKH.Trim() == makh select p).SingleOrDefault();
            DataTable tb = new DataTable();
            tb.Columns.Add("MaKH");
            tb.Columns.Add("TenKH");
            tb.Columns.Add("SDT");
            tb.Columns.Add("DiaChi");
            tb.Columns.Add("DiemTichLuy");
            
            tb.Rows.Add(tsb.MaKH, tsb.TenKH, tsb.SDT, tsb.DiaChi, tsb.DiemTichLuy);

            return tb;

        }

        public DataTable LocKhachHang(string text)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();
            var tsb = from p in qlbhEntity.KHACHHANGs where p.TenKH.Trim().Contains(text) || p.MaKH.Trim().Contains(text) || p.SDT.Trim().Contains(text) || p.DiaChi.Trim().Contains(text) || p.DiemTichLuy.ToString().Contains(text)
                      select p;

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

}

