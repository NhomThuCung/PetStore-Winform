using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class KhachHangDAO
    {
        private Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();

        public DataTable DanhSach()
        {
            string sql = "SELECT MaKH, HoTen, Email, DiaChi, DienThoai FROM KhachHang";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach2()
        {
            string sql = "SELECT * FROM KhachHang";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach2(string tuKhoa)
        {
            string sql = "SELECT * FROM KhachHang WHERE HoTen LIKE N'%" + tuKhoa + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_TenKH(string tenKH)
        {
            string sql = "SELECT MaKH, HoTen, Email, DiaChi, DienThoai FROM KhachHang WHERE HoTen LIKE '%" + tenKH + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_SoDT(string soDT)
        {
            string sql = "SELECT MaKH, HoTen, Email, DiaChi, DienThoai FROM KhachHang WHERE DienThoai LIKE '%" + soDT + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable DsKHTheoSDT(string soDT)
        {
            string sql = "SELECT MaKH, HoTen, Email, DiaChi, DienThoai FROM KhachHang WHERE DienThoai = " + soDT + "";
            return data.QuerySQL(sql);
        }

        //Load KhachHang Linq
        public List<KhachHang> DanhSachLinq()
        {
            return db.KhachHangs.Select(t => t).ToList();
        }

        //Thêm Linq
        public bool ThemLinq(string hoTen, string taiKhoan, string matKhau, string email, string diaChi, string dienThoai, string gioiTinh, DateTime ngaySinh, DateTime createdDate)
        {
            try
            {
                KhachHang kh = new KhachHang();
                kh.HoTen = hoTen;
                kh.TaiKhoan = taiKhoan;
                kh.MatKhau = matKhau;
                kh.Email = email;
                kh.DiaChi = diaChi;
                kh.DienThoai = dienThoai;
                kh.GioiTinh = gioiTinh;
                kh.NgaySinh = ngaySinh;
                kh.CreatedDate = createdDate;

                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int maKH)
        {
            try
            {
                var xoa = db.KhachHangs.Single(t => t.MaKH == maKH);
                db.KhachHangs.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int maKH, string hoTen, string taiKhoan, string matKhau, string email, string diaChi, string dienThoai, string gioiTinh, DateTime ngaySinh, DateTime createdDate)
        {
            try
            {
                var update = db.KhachHangs.Single(t => t.MaKH == maKH);
                update.HoTen = hoTen;
                update.TaiKhoan = taiKhoan;
                update.MatKhau = matKhau;
                update.Email = email;
                update.DiaChi = diaChi;
                update.DienThoai = dienThoai;
                update.GioiTinh = gioiTinh;
                update.NgaySinh = ngaySinh;
                update.CreatedDate = createdDate;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Them(KhachHangDTO info)
        {
            string sql = "INSERT INTO KhachHang(HoTen, TaiKhoan, MatKhau, Email, DiaChi, DienThoai, GioiTinh, NgaySinh, CreatedDate) " +
                "VALUES(N'" + info.HoTen + "', '" + info.TaiKhoan + "', '" + info.MatKhau + "', N'" + info.Email + "'" +
                ", N'" + info.DiaChi + "', N'" + info.Phone + "', N'" + info.GioiTinh + "', N'" + info.NgaySinh.ToString("yyyy-MM-dd") + "', N'" + info.CreateDate.ToString("yyyy-MM-dd") + "')";
            data.ExecuteSQL(sql);
        }

        public void Sua(KhachHangDTO info, int maKhach)
        {
            string sql = "UPDATE KhachHang SET HoTen = N'" + info.HoTen + "', TaiKhoan = '" + info.TaiKhoan + "'" +
                ", MatKhau = '" + info.MatKhau + "', Email = N'" + info.Email + "', DiaChi = N'" + info.DiaChi + "', DienThoai = N'" + info.Phone + "'" +
                ", GioiTinh = N'" + info.GioiTinh + "', NgaySinh = N'" + info.NgaySinh.ToString("yyyy-MM-dd") + "', CreatedDate = N'" + info.CreateDate.ToString("yyyy-MM-dd") + "' WHERE MaKH = " + maKhach;
            data.ExecuteSQL(sql);
        }

        public void Xoa(KhachHangDTO info)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKH = " + info.MaKH;
            data.ExecuteSQL(sql);
        }
    }
}
