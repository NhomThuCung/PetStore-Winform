using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class UserAdminDAO
    {
        private Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM UserAdmin";
            return data.QuerySQL(sql);
        }

        //Load Danh Sách UserAdmin Linq
        public List<UserAdmin> DanhSachLinq()
        {
            return db.UserAdmins.Select(t => t).ToList();
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

        //Thêm Linq
        public bool ThemLinq(string userName, string password, string name, string cmnd, DateTime ngaySinh, string address, string email, string phone, DateTime createDate, int maQuyen, decimal tienLuong)
        {
            try
            {
                UserAdmin user = new UserAdmin();
                user.UserName = userName;
                user.Password = password;
                user.Name = name;
                user.CMND = cmnd;
                user.NgaySinh = ngaySinh;
                user.Address = address;
                user.Email = email;
                user.Phone = phone;
                user.CreateDate = createDate;
                user.MaQuyen = maQuyen;
                user.TienLuong = tienLuong;
                db.UserAdmins.InsertOnSubmit(user);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int id)
        {
            try
            {
                var xoa = db.UserAdmins.Single(t => t.ID == id);
                db.UserAdmins.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int id, string userName, string password, string name, string cmnd, DateTime ngaySinh, string address, string email, string phone, DateTime createDate, int maQuyen, decimal tienLuong)
        {
            try
            {
                var update = db.UserAdmins.Single(t => t.ID == id);
                update.UserName = userName;
                update.Password = password;
                update.Name = name;
                update.CMND = cmnd;
                update.NgaySinh = ngaySinh;
                update.Address = address;
                update.Email = email;
                update.Phone = phone;
                update.CreateDate = createDate;
                update.MaQuyen = maQuyen;
                update.TienLuong = tienLuong;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false; 
            }
        }



        public void Them(UserAdminDTO info)
        {
            string sql = "INSERT INTO UserAdmin(UserName, Password, Name, CMND, NgaySinh, Address, Email, Phone, CreateDate, MaQuyen, TienLuong) " +
                "VALUES(N'" + info.UserName + "', N'" + info.Password + "', N'" + info.HoTen + "', '" + info.Cmnd + "'" +
                ", N'" + info.NgaySinh.ToString("yyyy-MM-dd") + "', N'" + info.DiaChi + "', N'" + info.Email + "', N'" + info.Phone + "', N'" + info.CreateDate.ToString("yyyy-MM-dd") + "', " + info.MaQuyen + ", " + info.TienLuong + ")";
            data.ExecuteSQL(sql);
        }

        public void Sua(UserAdminDTO info, int maNV)
        {
            string sql = "UPDATE UserAdmin SET UserName = N'" + info.UserName + "', Password = N'" + info.Password + "'" +
                ", Name = N'" + info.HoTen + "', CMND = '" + info.Cmnd + "', NgaySinh = N'" + info.NgaySinh.ToString("yyyy-MM-dd") + "', Address = N'" + info.DiaChi + "'" +
                ", Email = N'" + info.Email + "', Phone = N'" + info.Phone + "', CreateDate = N'" + info.CreateDate.ToString("yyyy-MM-dd") + "', MaQuyen = " + info.MaQuyen + ", TienLuong = " + info.TienLuong + " WHERE ID = " + maNV;
            data.ExecuteSQL(sql);
        }

        public void Xoa(UserAdminDTO info)
        {
            string sql = "DELETE FROM UserAdmin WHERE ID = " + info.Id;
            data.ExecuteSQL(sql);
        }
    }
}
