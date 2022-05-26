using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class GiongDAO
    {
        private Connect data = new Connect();
        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM Giong";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_TenGiong(string tenGiong)
        {
            string sql = "SELECT * FROM Giong WHERE TenGiong LIKE '%" + tenGiong + "%'";
            return data.QuerySQL(sql);
        }

        public void Them(GiongDTO info)
        {
            string sql = "INSERT INTO Giong(MaLoai, TenGiong, SoLuongTon, MoTa)" +
                " VALUES (" + info.MaLoai + ", N'"+ info.TenGiong + "', " + info.SoLuongTon + ", N'" + info.MoTa + "')";
            data.ExecuteSQL(sql);
        }

        public void Sua(GiongDTO info, int maGiong)
        {
            string sql = "UPDATE Giong SET MaLoai = '" + info.MaLoai + "', TenGiong = N'" + info.TenGiong +"', SoLuongTon = '" + info.SoLuongTon + "', MoTa = N'" + info.MoTa + "' WHERE MaGiong = " + maGiong;
            data.ExecuteSQL(sql);
        }

        public void Xoa(GiongDTO info)
        {
            string sql = "DELETE FROM Giong WHERE MaGiong = " + info.MaGiong;
            data.ExecuteSQL(sql);
        }
    }
}
