﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class ChiTietDonHangDAO
    {
        private Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();
        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM ChiTietDonHang";
            return data.QuerySQL(sql);
        }

        public DataTable Sell()
        {
            string sql = "SELECT MaDH, TC.TenTC, ThanhTien FROM ChiTietDonHang CTDH, ThuCung TC where  CTDH.MaTC = TC.MaTC";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_KetHop()
        {
            string sql = "SELECT CT.*, TC.TenTC, TC.GiaBan FROM ChiTietDonHang CT, ThuCung TC where CT.MaTC = TC.MaTC";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_KetHop(string maDH)
        {
            string sql = "SELECT CT.*, TC.TenTC, TC.GiaBan FROM ChiTietDonHang CT, ThuCung TC where CT.MaTC = TC.MaTC AND MaDH = " + maDH + "";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_MaDH(int maDH)
        {
            string sql = "SELECT CT.*,TC.TenTC FROM ChiTietDonHang CT, ThuCung TC where CT.MaTC = TC.MaTC AND MaDH = " + maDH + "";
            return data.QuerySQL(sql);
        }

        //Load ChiTietDonHang Linq
        public List<ChiTietDonHang> DanhSachLinq()
        {
            return db.ChiTietDonHangs.Select(t => t).ToList();
        }

        //Thêm Linq
        public bool ThemLinq(int maDH, int maTC, decimal thanhTien)
        {
            try
            {
                ChiTietDonHang ctdh = new ChiTietDonHang();
                ctdh.MaDH = maDH;
                ctdh.MaTC = maTC;
                ctdh.ThanhTien = thanhTien;


                db.ChiTietDonHangs.InsertOnSubmit(ctdh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int maDH)
        {
            try
            {
                var xoa = db.ChiTietDonHangs.Single(t => t.MaDH == maDH);
                db.ChiTietDonHangs.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int maDH, int maTC, decimal thanhTien)
        { 
            try
            {
                var update = db.ChiTietDonHangs.Single(t => t.MaDH == maDH);
                update.MaTC = maTC;
                update.ThanhTien = thanhTien;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public void Them(ChiTietDonHangDTO info)
        {
            string sql = "INSERT INTO ChiTietDonHang(MaDH, MaTC, ThanhTien)" +
                " VALUES (" + info.MaDH + ", " + info.MaTC + ", " + info.ThanhTien + ") ";
            data.ExecuteSQL(sql);
        }

        public void Sua(ChiTietDonHangDTO info, int maDH)
        {
            string sql = "UPDATE ChiTietDonHang SET MaTC = " + info.MaTC + ", ThanhTien = " + info.ThanhTien + " WHERE MaDH = " + maDH;
            data.ExecuteSQL(sql);
        }

        //public void SuaChiTiet(ChiTietDonHangDTO info, int maTC, int maHD)
        //{
        //    string sql = "UPDATE ChiTietDonHang SET SoLuong = " + info.SoLuong + " WHERE MaTC = " + maTC + " AND MaDH = "+ maHD +"";
        //    data.ExecuteSQL(sql);
        //}

        public void Xoa(ChiTietDonHangDTO info)
        {
            string sql = "DELETE FROM ChiTietDonHang WHERE MaDH = " + info.MaDH;
            data.ExecuteSQL(sql);
        }

        public void XoaChiTiet(ChiTietDonHangDTO info)
        {
            string sql = "DELETE FROM ChiTietDonHang WHERE MaDH = " + info.MaDH + " AND MaTC = " + info.MaTC;
            data.ExecuteSQL(sql);
        }
    }
}
