using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanTraSua.BS_Layer
{
    class QueryCaLam
    {
        public bool Regis_Shift(string maNV, string maCa, string tgian, ref string err)
        {
            string[] tg = tgian.Split('-');
            DateTime dt = new DateTime(Int32.Parse(tg[0]), Int32.Parse(tg[1]), Int32.Parse(tg[2]));

            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tsb = (from p in qlbhEntity.QUANLYLUONGs where p.ThoiGian == dt && p.MaNV.Trim() == maNV && p.MaCa.Trim() == maCa select p).SingleOrDefault();
            
            if (tsb != null)
            {
                return false;
            }

            QUANLYLUONG ql = new QUANLYLUONG();
            ql.ThoiGian = dt;
            ql.MaNV = maNV;
            ql.MaCa = maCa;
            ql.MucDoHoanThanh = 0;
            ql.Luong = 0;
            qlbhEntity.QUANLYLUONGs.InsertOnSubmit(ql);
            qlbhEntity.QUANLYLUONGs.Context.SubmitChanges();
            return true;
        }

        private double TienLuongca(string maCa)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tsb = (from p in qlbhEntity.CALAMs where p.MaCa.Trim() == maCa select p).SingleOrDefault();
            return tsb.LuongTheoGio;
        }

        public Dictionary<string, List<TimeSpan>> ThoiGianLam()
        {
            Dictionary<string, List<TimeSpan>> list_time_ca= new Dictionary<string, List<TimeSpan>>();
            
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tsb = from p in qlbhEntity.CALAMs select p;

            string ca;
            TimeSpan start, end;
            List<TimeSpan> tempt= new List<TimeSpan>();

            foreach(var r in tsb)
            {
                tempt = new List<TimeSpan>();

                start = (TimeSpan)r.ThoiGianBatDau;
                end = (TimeSpan)r.ThoiGianKetThuc;

                tempt.Add(start);
                tempt.Add(end);
                ca = r.MaCa.Trim();
                list_time_ca[ca] = tempt;
            }
            return list_time_ca;
        }

        public Dictionary<string, int> Max_nv()
        {
            Dictionary<string, int> list_max_ca = new Dictionary<string, int>();
            

            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tsb = from p in qlbhEntity.CALAMs select p;


            foreach (var r in tsb)
                list_max_ca.Add(r.MaCa.Trim(), (int)r.NhanVienToiDa);
            return list_max_ca;
        }

        public bool Finish_work(string maNV, string tgian, string maCa, int rate, ref string err)
        {
            double luong = 4 * TienLuongca(maCa) * rate;
            string[] tg = tgian.Split('-');
            DateTime dt = new DateTime(Int32.Parse(tg[0]), Int32.Parse(tg[1]), Int32.Parse(tg[2]));

            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tsb = (from p in qlbhEntity.QUANLYLUONGs where p.ThoiGian==dt && p.MaNV.Trim()==maNV && p.MaCa.Trim()==maCa select p).SingleOrDefault();
            if (tsb!=null)
            {
                tsb.MucDoHoanThanh = rate;
                tsb.Luong = (float)luong;
                return true;
            }
            return false;

        }
        private DataTable GetRegisList(DateTime start, DateTime end)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tsb = from p in qlbhEntity.QUANLYLUONGs
                      where p.ThoiGian >= start && p.ThoiGian <= end
                      select p;

            DataTable tb = new DataTable();
            tb.Columns.Add("ThoiGian");
            tb.Columns.Add("MaNV");
            tb.Columns.Add("MaCa");
            tb.Columns.Add("MucDoHoanThanh");
            tb.Columns.Add("Luong");

            foreach (var p in tsb)
                tb.Rows.Add(p.ThoiGian, p.MaNV, p.MaCa, p.MucDoHoanThanh, p.Luong);
            return tb;
        }

        private string Get_shift_code(DataRow row)
        {
            return ((string)row["MaCa"]).Trim() + "-" + (DateTime.Parse((string)row["ThoiGian"])).ToString("dd/MM");
        }

        private string GetName(string MaNV)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            var tsb = (from p in qlbhEntity.NHANVIENs
                      where p.MaNV==MaNV
                      select p).SingleOrDefault();

            string name = tsb.TenNV;
            string[] list_name = name.Split(' ');
            return list_name[list_name.Length - 1];
        }

        public List<List<string>> LoadTimeTable(DateTime start, DateTime end)
        {
            List<List<string>> list_ca=new List<List<string>>();
            DataTable tb = GetRegisList(start, end);
            DataRow[] list_row = tb.Select();
            List<string> temp = new List<string>();
            foreach (DataRow row in list_row)
            {
                temp = new List<string>();
                temp.Add(Get_shift_code(row));
                temp.Add((string)row["MaNV"]);
                temp.Add(GetName((string)row["MaNV"]));
                list_ca.Add(temp);
            }
            return list_ca;
        }

    }
}
