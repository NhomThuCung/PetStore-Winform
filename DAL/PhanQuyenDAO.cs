using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;


namespace DAL
{
    public class PhanQuyenDAO
    {
        private Connect data = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM PhanQuyen";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_TenQuyen(string tenQuyen)
        {
            string sql = "SELECT * FROM PhanQuyen Where TenQuyen LIKE N'%" + tenQuyen + "%'";
            return data.QuerySQL(sql);
        }

        public void Them(PhanQuyen info)
        {
            string sql = "INSERT INTO PhanQuyen(TenQuyen) VALUES (N'" + info.TenQuyen + "')";
            data.ExecuteSQL(sql);
        }

        public void Sua(PhanQuyen info, int maQuyen)
        {
            string sql = "UPDATE PhanQuyen SET TenQuyen = N'" + info.TenQuyen + "' WHERE MaQuyen = " + maQuyen;
            data.ExecuteSQL(sql);
        }

        public void Xoa(PhanQuyen info)
        {
            string sql = "DELETE FROM PhanQuyen WHERE MaQuyen = " + info.MaQuyen;
            data.ExecuteSQL(sql);
        }
    }
}
