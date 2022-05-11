using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAn_DotNet.DTO;

namespace DoAn_DotNet.DAO
{
    class DonHangDAO
    {
        Connect data = new Connect();

        public DataTable DonHang()
        {
            string sql = "SELECT * FROM DonHang";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang_CTDH()
        {
            string sql = "SELECT DH.*, CTDH.SoLuong, CTDH.MaTC, TC.TenTC FROM DonHang DH, ChiTietDonHang CTDH, ThuCung TC where DH.MaDH = CTDH.MaDH AND TC.MaTC = CTDH.MaTC";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang_CTDH(DateTime ngaydau, DateTime ngaycuoi)
        {
            string sql = "SELECT DH.*, CTDH.SoLuong, CTDH.MaTC, TC.TenTC FROM DonHang DH, ChiTietDonHang CTDH, ThuCung TC where DH.MaDH = CTDH.MaDH AND TC.MaTC = CTDH.MaTC AND DH.CreatedDate >= N'" + ngaydau.ToString("yyyy-MM-dd") + "' AND DH.CreatedDate <= N'" + ngaycuoi.ToString("yyyy-MM-dd") + "' ";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang_MaDH()
        {
            string sql = "SELECT MaDH, CreatedDate FROM DonHang";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang_Report(int maDH)
        {
            string sql = "SELECT ChiTietDonHang.MaDH, ThuCung.TenTC, ThuCung.GiaBan, ChiTietDonHang.SoLuong, ChiTietDonHang.ThanhTien FROM ChiTietDonHang INNER JOIN ThuCung ON ChiTietDonHang.MaTC = ThuCung.MaTC AND ChiTietDonHang.MaDH = " + maDH + "";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang_SoDT(string soDT)
        {
            string sql = "SELECT * FROM DonHang where SoDT LIKE '%" + soDT + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang(string maNV)
        {
            string sql = "SELECT * FROM DonHang where MADH = " + maNV + "";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang_maKH(string maKH)
        {
            string sql = "SELECT * FROM DonHang where MAKH = " + maKH + "";
            return data.QuerySQL(sql);
        }

        public DataTable ThongKeDonHang(DateTime frmdate, DateTime todate)
        {
            string sql = "EXEC sp_ThongKeDonHang '" + frmdate.ToString("yyyy-MM-dd") + "', '" + todate.ToString("yyyy-MM-dd") + "'";
            return data.QuerySQL(sql);
        }

        public DataTable ThongKeDoanhThuCuaHang(DateTime frmdate, DateTime todate)
        {
            string sql = "EXEC sp_ThongKeDoanhThuCuaHang '" + frmdate.ToString("yyyy-MM-dd") + "', '" + todate.ToString("yyyy-MM-dd") + "'";
            return data.QuerySQL(sql);
        }


        public void Them(DonHang info)
        {
            string sql = "INSERT INTO DonHang(ID, CreatedDate, MaKH, NguoiNhan, Email, SoDT, DiaChi, TongTien, Status)" +
                " VALUES(" + info.Id + ", '" + info.CreatedDate.ToString("yyyy-MM-dd") + "'," + info.MaKH + ", N'" + info.NguoiNhan + "', N'" + info.Email + "', N'" + info.SoDT + "', N'" + info.DiaChi + "', CAST(N'" + info.TongTien + "'AS Decimal(18, 0)), '" + info.Status + "')";
            data.ExecuteSQL(sql);
        }

        public void SuaDonHang(DonHang info, int maDH)
        {
            string sql = "UPDATE DonHang SET ID =" + info.Id + ", CreatedDate = '"+ info.CreatedDate.ToString("yyyy-MM-dd") + "', MaKH = " + info.MaKH + ", NguoiNhan = N'" + info.NguoiNhan + "', Email =  N'" + info.Email + "',SoDT = N'" + info.SoDT + "', DiaChi= N'" + info.DiaChi + "', TongTien = CAST(N'" + info.TongTien + "'AS Decimal(18, 0)), Status = '" + info.Status + "' WHERE MaDH = " + maDH;
            data.ExecuteSQL(sql);
        }

        public void Sua(DonHang info, int maDH)
        {
            string sql = "UPDATE DonHang SET Status = '" + info.Status + "' WHERE MaDH = " + maDH;
            data.ExecuteSQL(sql);
        }

        public void Xoa(DonHang info)
        {
            string sql = "DELETE FROM DonHang WHERE MaDH = " + info.MaDH;
            data.ExecuteSQL(sql);
        }
    }
}
