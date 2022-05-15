using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class LoaiDAO
    {
        private Connect data = new Connect();
        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM Loai";
            return data.QuerySQL(sql);
        }
        public DataTable DanhSach_TenLoai(string tenLoai)
        {
            string sql = "SELECT * FROM Loai WHERE TenLoai LIKE '%" + tenLoai + "%'";
            return data.QuerySQL(sql);
        }

        public void Them(Loai info)
        {
            string sql = "INSERT INTO Loai(TenLoai)" +
                " VALUES (N'" + info.TenLoai + "')";
            data.ExecuteSQL(sql);
        }

        public void Sua(Loai info, int maLoai)
        {
            string sql = "UPDATE Loai SET TenLoai = N'" + info.TenLoai + "' WHERE MaLoai = " + maLoai;
            data.ExecuteSQL(sql);
        }

        public void Xoa(Loai info)
        {
            string sql = "DELETE FROM Loai WHERE MaLoai = " + info.MaLoai;
            data.ExecuteSQL(sql);
        }
    }
}
