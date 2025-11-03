using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;



namespace QuanLyQuanTraSua
{
    class QueryDangNhap
    {
        
        public bool checkTaiKhoan_QL(string username, string pass, out string userID, out string name)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            userID = "";
            name = "";
            var tps = (from p in qlbhEntity.DANGNHAPs
                       join sa in qlbhEntity.QUANLies on p.MaND equals sa.MaQL
                       where p.TenDangNhap.Trim() == username && p.MatKhau.Trim() == pass
                       select new
                       {
                           maND = p.MaND,
                           tenQL= sa.TenQL
                       }).SingleOrDefault();

            if (tps != null)
            {
                userID = tps.maND;
                name = tps.tenQL;
                return true;
            }
            else
                return false;
        }

        public bool checkTaiKhoan_NV(string username, string pass, out string userID, out string name)
        {
            QUANLYQUANTRADataContext qlbhEntity = new QUANLYQUANTRADataContext();

            userID = "";
            name = "";
            var tps = (from p in qlbhEntity.DANGNHAP2s
                       join sa in qlbhEntity.NHANVIENs on p.MaND equals sa.MaNV
                       where p.TenDangNhap.Trim() == username && p.MatKhau.Trim() == pass
                       select new
                       {
                           maND = p.MaND,
                           tenNV = sa.TenNV
                       }).SingleOrDefault();

            if (tps != null)
            {
                userID = tps.maND;
                name = tps.tenNV;
                return true;
            }
            else
                return false;
        }

    }
}
