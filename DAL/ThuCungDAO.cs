using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class ThuCungDAO
    {
        private Connect data = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM ThuCung";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSachTC()
        {
            string sql = "SELECT MaTC, TenTC, GiaBan, TrangThai FROM ThuCung";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSachTC(string tenTC)
        {
            string sql = "SELECT MaTC, TenTC, GiaBan, TrangThai FROM ThuCung WHERE TenTC LIKE '%" + tenTC + "%'";
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

        //InsertThemLinq
        public bool ThemLinq(string tenTC, decimal giaBan, string moTa, string anh, DateTime ngayCapNhap, int maGiong, int maLoai, bool trangThai)
        {
            QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();
            try
            {
                ThuCung tc = new ThuCung();
                tc.TenTC = tenTC;
                tc.GiaBan = giaBan;
                tc.MoTa = moTa;
                tc.Anh = anh;
                tc.NgayCapNhat = ngayCapNhap;
                tc.MaGiong = maGiong;
                tc.MaLoai = maLoai;
                tc.TrangThai = trangThai;
                db.ThuCungs.InsertOnSubmit(tc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }


        public void Them(ThuCungDTO info)
        {
            string sql = "INSERT INTO ThuCung(TenTC, GiaBan, MoTa, Anh, NgayCapNhat, MaGiong, MaLoai, Moi) " +
                "VALUES(N'" + info.TenTC + "', " + info.GiaBan + ", N'" + info.MoTa + "', N'" + info.Anh + "'" +
                ", N'" + info.NgayCapNhat.ToString("yyyy-MM-dd") + "', " + info.MaGiong + ", " + info.MaLoai + ", '" + info.Moi + "')";
            data.ExecuteSQL(sql);
        }

        public void Sua(ThuCungDTO info, int maTC)
        {
            string sql = "UPDATE ThuCung SET TenTC = N'" + info.TenTC + "', GiaBan = " + info.GiaBan + "" +
                ", MoTa = N'" + info.MoTa + "', Anh = N'" + info.Anh + "', NgayCapNhat = N'" + info.NgayCapNhat.ToString("yyyy-MM-dd") + "', " +
                " MaGiong = " + info.MaGiong + ", MaLoai = " + info.MaLoai + ", Moi = '" + info.Moi + "' WHERE MaTC = " + maTC;
            data.ExecuteSQL(sql);
        }

        public void Xoa(ThuCungDTO info)
        {
            string sql = "DELETE FROM ThuCung WHERE MaTC = " + info.MaTC;
            data.ExecuteSQL(sql);
        }
    }
}
