using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace QuanLyQuanTraSua.BS_Layer
{
    class QueryHoaDon
    {

        public DataGridViewComboBoxColumn LoadComboBox(DataGridViewComboBoxColumn cbbMH)
        {
            
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tps = from p in qlbhEntity.MENUs select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("MaMH");
            dt.Columns.Add("TenMH");
            foreach (var p in tps)
                dt.Rows.Add(p.MaMH, p.TenMH);
            cbbMH.DataSource = dt;
            cbbMH.DisplayMember = "TenMH";
            cbbMH.ValueMember = "MaMH";
            return cbbMH;
        }

        public bool CheckKhachHang(string sdt, out string maKH)
        {
            
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tps = (from p in qlbhEntity.KHACHHANGs
                      where p.SDT.Trim() == sdt
                      select p).SingleOrDefault();

            if (tps != null)
            {
                maKH = tps.MaKH;
                return true;
            }
            maKH = "";
            return false;
        }

        public List<string> GetKhachInfor(string maKH)
        {
            
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tps = (from p in qlbhEntity.KHACHHANGs
                       where p.MaKH.Trim() == maKH
                       select p).SingleOrDefault();

            List<string> infor = new List<string>();
            infor.Add(tps.MaKH.Trim());
            infor.Add(tps.DiemTichLuy.ToString());
            return infor;

        }


        public bool ThemKhach(string name, string sdt, string diachi, ref string err, out List<string> infor)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tps = from p in qlbhEntity.KHACHHANGs select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("MaKH");

            foreach (var p in tps)
                dt.Rows.Add(p.MaKH);

            int count = tps.Count();
            DataRow lastrow = dt.Rows[count - 1];
            string id = lastrow["MaKH"].ToString().Trim();
            string[] listcode = id.Split('H');
            int index = Int32.Parse(listcode[1]);
            string next_id = "KH";
            next_id = next_id + (index + 1).ToString().PadLeft(4, '0');

            KHACHHANG kh = new KHACHHANG();
            kh.MaKH = next_id;
            kh.TenKH = name;
            kh.SDT = sdt;
            kh.DiaChi = diachi;
            kh.DiemTichLuy = 0;

            qlbhEntity.KHACHHANGs.InsertOnSubmit(kh);
            qlbhEntity.KHACHHANGs.Context.SubmitChanges();
            infor = new List<string>();
            infor.Add(next_id);
            infor.Add("0");
            return true;

        }

        public void GetGia(string idMH, out int cost, out int plus)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tps = (from p in qlbhEntity.MENUs
                       where p.MaMH.Trim() == idMH
                       select p).SingleOrDefault();

            cost = (int)tps.GiaTien;
            plus = tps.DiemTichLuy;

        }

        private string LocNgay(string datetime)
        {
            string[] list_time = datetime.Split(' ');
            string[] list_date = list_time[0].Split('/');
            DateTime date = new DateTime(Int32.Parse(list_date[2]), Int32.Parse(list_date[0]), Int32.Parse(list_date[1]));
            string result = date.ToString("yyyy-MM-dd");
            return result;
        }


        public float CheckCoupon(int cost, int point, out List<string> coupon_infor)
        {
            
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            coupon_infor = new List<string>();
            DateTime today = DateTime.Now;
            var cp = from p in qlbhEntity.COUPONs select p;
            
            string start, end, now;
            now = today.ToString("yyyy-MM-dd");
            float discount = 0, rate, max = 0;
            int point_rate = 0;
            foreach (var p in cp)
            {
                start = LocNgay(p.NgayBatDau.ToString());
                end = LocNgay(p.NgayKetThuc.ToString());
                rate = (float)p.MucGiam;
                point_rate = (int)p.DiemApDung;
                max = (float)p.GiamToiDa;
                if (String.Compare(start, now) <= 0 && String.Compare(now, end) <= 0)
                    if (point >= point_rate)
                    {
                        discount = cost * rate;
                        if (discount > max)
                            discount = max;
                        coupon_infor.Add(p.MaCP);
                        coupon_infor.Add(p.MoTa);
                        break;
                    }
            }
            
            return discount;
        }




        public bool UpdateKhachHang(string maKH, int point, ref string err)
        {
            
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tps = (from p in qlbhEntity.KHACHHANGs
                       where p.MaKH.Trim() == maKH
                       select p).SingleOrDefault();
            if (tps!=null)
            {
                tps.DiemTichLuy = tps.DiemTichLuy + point;
                qlbhEntity.SubmitChanges();
                return true;
            }
            return false;
        }


        public string LuuHoaDon(string maKH, string maNV, float total_cost, DateTime ngayXHD, string maCP, ref string err)
        {
            
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var cp = from p in qlbhEntity.HOADONs select p;
            DataTable tb = new DataTable();
            tb.Columns.Add("MaHD");
          
            foreach (var p in cp)
                tb.Rows.Add(p.MaHD);
            DataRow[] filter = tb.Select();
            int count = filter.Length;
            DataRow lastrow = filter[count - 1];
            string id = lastrow["MaHD"].ToString().Trim();
            string[] listcode = id.Split('D');
            int index = Int32.Parse(listcode[1]);
            string next_id = "HD";
            next_id = next_id + (index + 1).ToString().PadLeft(4, '0');

            HOADON hd = new HOADON();
            hd.MaHD = next_id;
            hd.MaKH = maKH;
            hd.MaNV = maNV;
            hd.ThanhTien = total_cost;
            hd.NgayXuatHD = ngayXHD;
            if (maCP != "Null")
                hd.MaCP = maCP;
            else
                hd.MaCP = null;

            qlbhEntity.HOADONs.InsertOnSubmit(hd);
            qlbhEntity.HOADONs.Context.SubmitChanges();

            return next_id;
        }

     
        public void LuuChiTietHD(string maHD, DataGridView table_item, ref string err)
        {
            
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            CHITIETHOADON ct = new CHITIETHOADON();
            foreach (DataGridViewRow row in table_item.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    ct = new CHITIETHOADON();
                    ct.MaHD = maHD;
                    ct.MaMH = row.Cells[0].Value.ToString().Trim();
                    ct.SoLuong = (int)row.Cells[1].Value;
                    ct.DiemTichLuy = (int)row.Cells[2].Value;
                    ct.Tien = (int)row.Cells[3].Value;

                    qlbhEntity.CHITIETHOADONs.InsertOnSubmit(ct);
                    qlbhEntity.CHITIETHOADONs.Context.SubmitChanges();
                }
            }
        }
    }
}
