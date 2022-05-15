﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using DoAn_DotNet.Custom;
using System.Globalization;

namespace DoAn_DotNet.GUI
{
    public partial class frmDetailUser : Form
    {
        public static string taiKhoan = BLL.UserAdminBLL.frmDetailUsertaiKhoan;
        public static string hoTen = BLL.UserAdminBLL.frmDetailUserhoTen;
        public static string cmnd = BLL.UserAdminBLL.frmDetailUsercmnd;
        public static DateTime ngaySinh = BLL.UserAdminBLL.frmDetailUserngaySinh;
        public static int maQuyen = BLL.UserAdminBLL.frmDetailUsermaQuyen;
        public static int maNV = BLL.UserAdminBLL.frmDetailUsermaNV;
        public static int tienLuong = BLL.UserAdminBLL.frmDetailUsertienLuong;

        public frmDetailUser()
        {
            InitializeComponent();
        }

        private void LayThongTinNhanVien()
        {
            try
            {
                UserAdminBLL tk = new UserAdminBLL();

                txtMaNV.Text = maNV.ToString();
                txtHoTen.Text = hoTen;
                txtUserName.Text = taiKhoan;
                txtCMND.Text = cmnd;
                dtpNgaySinh.Value = ngaySinh;
                if (maQuyen == 1)
                {
                    lblChucVu.Text =  "Chức Vụ: Quản lý";
                }
                else
                    lblChucVu.Text = "Chức Vụ: Nhân Viên";

                CultureInfo info = new CultureInfo("vi-VN");
                lblLuong.Text = "Tiền Lương: " + tienLuong.ToString("c0",info);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void frmDetailUser_Load(object sender, EventArgs e)
        {
            LayThongTinNhanVien();
        }
    }
}
