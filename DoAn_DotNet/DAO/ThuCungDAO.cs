using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn_DotNet.DTO;
using System.Data;

namespace DoAn_DotNet.DAO
{
    class ThuCungDAO
    {
        private Connect data = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM ThuCung";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSachTC()
        {
            string sql = "SELECT MaTC, TenTC, GiaBan, SoLuongTon, Moi FROM ThuCung";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSachTC(string tenTC)
        {
            string sql = "SELECT MaTC, TenTC, GiaBan, SoLuongTon, Moi FROM ThuCung WHERE TenTC LIKE '%" + tenTC + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_MaTC(string tenTC)
        {
            string sql = "SELECT * FROM ThuCung WHERE TenTC LIKE '%" + tenTC + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable ThongKeThuCungBanChay(DateTime frmdate, DateTime todate)
        {
            string sql = "EXEC sp_ThongKeThuCungBanChay '" + frmdate.ToString("yyyy-MM-dd") + "', '" + todate.ToString("yyyy-MM-dd") + "'";
            return data.QuerySQL(sql);
        }

        public void Them(ThuCung info)
        {
            string sql = "INSERT INTO ThuCung(TenTC, GiaBan, MoTa, Anh, NgayCapNhat, SoLuongTon, MaGiong, MaLoai, Moi) " +
                "VALUES(N'" + info.TenTC + "', " + info.GiaBan + ", N'" + info.MoTa + "', N'" + info.Anh + "'" +
                ", N'" + info.NgayCapNhat.ToString("yyyy-MM-dd") + "', " + info.SoLuongTon + ", " + info.MaGiong + ", " + info.MaLoai + ", '" + info.Moi + "')";
            data.ExecuteSQL(sql);
        }

        public void Sua(ThuCung info, int maTC)
        {
            string sql = "UPDATE ThuCung SET TenTC = N'" + info.TenTC + "', GiaBan = " + info.GiaBan + "" +
                ", MoTa = N'" + info.MoTa + "', Anh = N'" + info.Anh + "', NgayCapNhat = N'" + info.NgayCapNhat.ToString("yyyy-MM-dd") + "', SoLuongTon = " + info.SoLuongTon + "" +
                ", MaGiong = " + info.MaGiong + ", MaLoai = " + info.MaLoai + ", Moi = '" + info.Moi + "' WHERE MaTC = " + maTC;
            data.ExecuteSQL(sql);
        }

        public void Xoa(ThuCung info)
        {
            string sql = "DELETE FROM ThuCung WHERE MaTC = " + info.MaTC;
            data.ExecuteSQL(sql);
        }
    }
}
