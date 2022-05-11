using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAn_DotNet.DTO;

namespace DoAn_DotNet.DAO
{
    class GiongDAO
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

        public void Them(Giong info)
        {
            string sql = "INSERT INTO Giong(MaLoai, TenGiong, MoTa)" +
                " VALUES (" + info.MaLoai + ", N'"+ info.TenGiong + "', N'" + info.MoTa + "')";
            data.ExecuteSQL(sql);
        }

        public void Sua(Giong info, int maGiong)
        {
            string sql = "UPDATE Giong SET MaLoai = '" + info.MaLoai + "', TenGiong = N'" + info.TenGiong +"', MoTa = N'" + info.MoTa + "' WHERE MaGiong = " + maGiong;
            data.ExecuteSQL(sql);
        }

        public void Xoa(Giong info)
        {
            string sql = "DELETE FROM Giong WHERE MaGiong = " + info.MaGiong;
            data.ExecuteSQL(sql);
        }
    }
}
