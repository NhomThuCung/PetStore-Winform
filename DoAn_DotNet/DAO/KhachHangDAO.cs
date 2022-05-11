using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAn_DotNet.DTO;

namespace DoAn_DotNet.DAO
{
    class KhachHangDAO
    {
        private Connect data = new Connect();

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

        public void Them(KhachHang info)
        {
            string sql = "INSERT INTO KhachHang(HoTen, TaiKhoan, MatKhau, Email, DiaChi, DienThoai, GioiTinh, NgaySinh, CreatedDate) " +
                "VALUES(N'" + info.HoTen + "', '" + info.TaiKhoan + "', '" + info.MatKhau + "', N'" + info.Email + "'" +
                ", N'" + info.DiaChi + "', N'" + info.Phone + "', N'" + info.GioiTinh + "', N'" + info.NgaySinh.ToString("yyyy-MM-dd") + "', N'" + info.CreateDate.ToString("yyyy-MM-dd") + "')";
            data.ExecuteSQL(sql);
        }

        public void Sua(KhachHang info, int maKhach)
        {
            string sql = "UPDATE KhachHang SET HoTen = N'" + info.HoTen + "', TaiKhoan = '" + info.TaiKhoan + "'" +
                ", MatKhau = '" + info.MatKhau + "', Email = N'" + info.Email + "', DiaChi = N'" + info.DiaChi + "', DienThoai = N'" + info.Phone + "'" +
                ", GioiTinh = N'" + info.GioiTinh + "', NgaySinh = N'" + info.NgaySinh.ToString("yyyy-MM-dd") + "', CreatedDate = N'" + info.CreateDate.ToString("yyyy-MM-dd") + "' WHERE MaKH = " + maKhach;
            data.ExecuteSQL(sql);
        }

        public void Xoa(KhachHang info)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKH = " + info.MaKH;
            data.ExecuteSQL(sql);
        }
    }
}
