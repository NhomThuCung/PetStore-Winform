using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAn_DotNet.DTO;

namespace DoAn_DotNet.DAO
{
    class UserAdminDAO
    {
        private Connect data = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM UserAdmin";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_Ten(string tenNV)
        {
            string sql = "SELECT * FROM UserAdmin where Name LIKE '%" + tenNV + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable ChiTiet(string userName, string password)
        {
            string sql = "SELECT * FROM UserAdmin WHERE UserName = '" + userName + "' AND Password = '" + password + "'";
            return data.QuerySQL(sql);
        }

        public DataTable DoiMatKhau(int manv, string matkhaumoi)
        {

            string sql = "EXEC sp_DoiMatKhau " + manv + ", N'" + matkhaumoi + "'";
            return data.QuerySQL(sql);
        }

        public DataTable LayThongTinTong(int manv, int thang, int nam)
        {
            string sql = "EXEC sp_LayThongTinTong " + manv + ", " + thang + ", " + nam + "";
            return data.QuerySQL(sql);
        }

        public DataTable BaoCaoDoanhThuCuaHang(int manv, int thang, int nam)
        {
            string sql = "EXEC sp_BaoCaoDoanhThuCuaHang  " + manv + ", " + thang + ", " + nam + "";
            return data.QuerySQL(sql);
        }

        public void Them(UserAdmin info)
        {
            string sql = "INSERT INTO UserAdmin(UserName, Password, Name, CMND, NgaySinh, Address, Email, Phone, CreateDate, MaQuyen, TienLuong) " +
                "VALUES(N'" + info.UserName + "', N'" + info.Password + "', N'" + info.HoTen + "', '" + info.Cmnd + "'" +
                ", N'" + info.NgaySinh.ToString("yyyy-MM-dd") + "', N'" + info.DiaChi + "', N'" + info.Email + "', N'" + info.Phone + "', N'" + info.CreateDate.ToString("yyyy-MM-dd") + "', " + info.MaQuyen + ", " + info.TienLuong + ")";
            data.ExecuteSQL(sql);
        }

        public void Sua(UserAdmin info, int maNV)
        {
            string sql = "UPDATE UserAdmin SET UserName = N'" + info.UserName + "', Password = N'" + info.Password + "'" +
                ", Name = N'" + info.HoTen + "', CMND = '" + info.Cmnd + "', NgaySinh = N'" + info.NgaySinh.ToString("yyyy-MM-dd") + "', Address = N'" + info.DiaChi + "'" +
                ", Email = N'" + info.Email + "', Phone = N'" + info.Phone + "', CreateDate = N'" + info.CreateDate.ToString("yyyy-MM-dd") + "', MaQuyen = " + info.MaQuyen + ", TienLuong = " + info.TienLuong + " WHERE ID = " + maNV;
            data.ExecuteSQL(sql);
        }

        public void Xoa(UserAdmin info)
        {
            string sql = "DELETE FROM UserAdmin WHERE ID = " + info.Id;
            data.ExecuteSQL(sql);
        }
    }
}
