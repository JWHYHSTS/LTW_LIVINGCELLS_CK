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
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                userID = "";
                name = "";

                var tps = qlbhEntity.DANGNHAPs
                    .Join(qlbhEntity.QUANLies,
                          dn => dn.MaND,
                          ql => ql.MaQL,
                          (dn, ql) => new { dn, ql })
                    .Where(x => x.dn.TenDangNhap.Trim() == username && x.dn.MatKhau.Trim() == pass)
                    .Select(x => new
                    {
                        maND = x.dn.MaND,
                        tenQL = x.ql.TenQL
                    })
                    .SingleOrDefault();

                if (tps != null)
                {
                    userID = tps.maND;
                    name = tps.tenQL;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool checkTaiKhoan_NV(string username, string pass, out string userID, out string name)
        {
            using (var qlbhEntity = new QUANLYQUANTRADataContext())
            {
                userID = "";
                name = "";

                var tps = qlbhEntity.DANGNHAP2s
                    .Join(qlbhEntity.NHANVIENs,
                          dn => dn.MaND,
                          nv => nv.MaNV,
                          (dn, nv) => new { dn, nv })
                    .Where(x => x.dn.TenDangNhap.Trim() == username && x.dn.MatKhau.Trim() == pass)
                    .Select(x => new
                    {
                        maND = x.dn.MaND,
                        tenNV = x.nv.TenNV
                    })
                    .SingleOrDefault();

                if (tps != null)
                {
                    userID = tps.maND;
                    name = tps.tenNV;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
