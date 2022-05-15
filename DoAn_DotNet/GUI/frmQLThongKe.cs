using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DTO;
using DoAn_DotNet.Custom;
using System.Runtime.InteropServices;
using System.Globalization;

namespace DoAn_DotNet.GUI
{
    public partial class frmQLThongKe : Form
    {
        public frmQLThongKe()
        {
            InitializeComponent();
        }
        private void DoanhThuCuaHang()
        {
            lsvDoanhThu.Items.Clear();
            chart1.Series[0].Points.Clear();
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            try
            {
                DataTable dt = new DataTable();
                DonHangDAO ds = new DonHangDAO();

                dt = ds.ThongKeDoanhThuCuaHang(dtpFrmDate.Value, dtpToDate.Value);
                if (dt != null)
                {
                    CultureInfo info = new CultureInfo("vi-VN");
                    int i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        DateTime t = (DateTime)row["NgayBan"];
                        item.Text = i.ToString();
                        item.SubItems.Add(t.ToString("dd-MM-yyyy"));
                        decimal doanhthu = (decimal)row["DoanhThu"];
                        item.SubItems.Add(doanhthu.ToString("c0", info));
                        chart1.Series[0].Points.AddXY(t.ToString("dd-MM-yyyy"), doanhthu.ToString("c0", info));
                        lsvDoanhThu.Items.Add(item);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadThongKeDonHang()
        {
            lsvThongKeDonHang.Items.Clear();
            DataTable dt = new DataTable();
            try
            {
                DonHangDAO ds = new DonHangDAO();
                dt = ds.ThongKeDonHang(dtpFrmDate.Value, dtpToDate.Value);
                if (dt != null)
                {
                    int i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = i.ToString();
                        string maDH = row["MaDH"].ToString();
                        DateTime ntao = (DateTime)row["CreatedDate"];
                        string sl = row["SoLuongBan"].ToString();
                        decimal tongtien = (decimal)row["DoanhThu"];
                        CultureInfo info = new CultureInfo("vi-VN");
                        item.SubItems.AddRange(new string[]
                        {
                            maDH,ntao.ToString("dd-MM-yyyy"),sl,tongtien.ToString("c0",info)
                        });
                        lsvThongKeDonHang.Items.Add(item);
                        i++;

                    }
                }
            }
            catch
            {
                lsvThongKeDonHang.Items.Clear();
            }
        }

        private void LoadSachBanChayThang()
        {
            lsvThongKeThuCungBC.Items.Clear();
            DataTable dt = new DataTable();
            try
            {
                ThuCungDAO ds = new ThuCungDAO();
                dt = ds.ThongKeThuCungBanChay(dtpFrmDate.Value, dtpToDate.Value);
                if (dt != null)
                {
                    int i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = i.ToString();
                        string maTC = row["MaTC"].ToString();
                        string tenTC = row["TenTC"].ToString();
                        decimal giaBan = (decimal)row["GiaBan"];
                        string slBan = row["SoLuongBan"].ToString();
                        string slTon = row["SoLuongTon"].ToString();
                        CultureInfo info = new CultureInfo("vi-VN");
                        item.SubItems.AddRange(new string[]
                        {
                            maTC, tenTC, giaBan.ToString("c0",info), slBan, slTon
                        });
                        lsvThongKeThuCungBC.Items.Add(item);
                        i++;
                    }
                }
            }
            catch
            {
                lsvThongKeThuCungBC.Items.Clear();
            }
        }

        private void frmQLThongKe_Load(object sender, EventArgs e)
        {
            DoanhThuCuaHang();
            LoadThongKeDonHang();
            LoadSachBanChayThang();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmQLThongKe_Load(sender,e);
        }
    }
}
