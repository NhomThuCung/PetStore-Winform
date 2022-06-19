using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using BLL;
using DTO;
using DoAn_DotNet.Custom;
using System.Globalization;

namespace DoAn_DotNet.GUI
{
    public partial class frmQLNhapHang : Form
    {
        private bool isThem;
        private bool isThemCT;
        PhieuNhapBLL bllPhieuNhap = new PhieuNhapBLL();
        ChiTietPNBLL bllChiTietPN = new ChiTietPNBLL();
        ThuCungBLL bllThuCung = new ThuCungBLL();
        GiongBLL bllGiong = new GiongBLL();
        LoaiBLL bllLoai = new LoaiBLL();
        DonDatMuaBLL bllDonDatMua = new DonDatMuaBLL();
        System.Data.DataTable dt;

        int maPN;
        int maTC;
        int maTCClick;
        int maLoai;

        int maNV = NhanVienBLL.frmDonHangmaNV;

        public frmQLNhapHang()
        {
            InitializeComponent();
        }

        private void frmQLNhapHang_Load(object sender, EventArgs e)
        {
            pnTab.Visible = false;
            dGVPhieuNhap.DataSource = bllPhieuNhap.PhieuNhap();

            cboMaGiong.DataSource = bllGiong.DanhSach();
            cboMaGiong.ValueMember = "MaGiong";
            cboMaGiong.DisplayMember = "TenGiong";

            cboMaDDM.DataSource = bllDonDatMua.DsDDM();
            cboMaDDM.ValueMember = "MaDDM";
            cboMaDDM.DisplayMember = "MaDDM";

            dtpNgayCN.Value = DateTime.Now;

            //Format tiền cho dataGridView1
            dGVPhieuNhap.Columns["Column5"].DefaultCellStyle.Format = "c0";
            dGVChiTietPN.Columns["Column8"].DefaultCellStyle.Format = "c0";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            pnTab.Visible = true;
            isThem = true;
            BatTat(true);

            dtpNgayNhap.Enabled = false;
            dtpNgayCN.Enabled = false;

            dtpNgayNhap.Value = DateTime.Now;
            dtpNgayCN.Value = DateTime.Now;

            //txtMaDDM.Visible = false;
            txtMaDDM.Text = "";
            txtTenTC.Text = "";
            txtGiaNhap.Text = "";
            txtNoiDung.Text = "";

            dt = new System.Data.DataTable();
            dGVChiTietPN.DataSource = null;

            maTC = Convert.ToInt32(bllThuCung.DanhSachTCTheoMa().Rows[0][0].ToString());
        }
        public void BatTat(bool tt)
        {
            txtTenTC.Enabled = tt;
            txtGiaNhap.Enabled = tt;
            txtNoiDung.Enabled = tt;
            btnThemChiTiet.Enabled = tt;

            cboMaDDM.Visible = tt;
            txtMaDDM.Visible = !tt;

            cboMaGiong.Visible = tt;
            txtMaGiong.Visible = !tt;

            dtpNgayNhap.Visible = tt;
            dtpNgayCN.Visible = tt;
            txtNgayCapNhat.Visible = !tt;
            txtNgayNhap.Visible = !tt;

            btnSua.Enabled = !tt;
            btnThem.Enabled = !tt;
            btnLuu.Enabled = tt;
            btnHuy.Enabled = tt;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            BatTat(true);

            dtpNgayCN.Enabled = false;
            dtpNgayNhap.Enabled = false;

        }

        private void dGVPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1);
            if (validClick)
            {
                BatTat(false);
                pnTab.Visible = true;

                maPN = Convert.ToInt32(dGVPhieuNhap.Rows[e.RowIndex].Cells[0].Value.ToString());

                txtMaDDM.Text = dGVPhieuNhap.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboMaDDM.SelectedValue = Convert.ToInt32(dGVPhieuNhap.Rows[e.RowIndex].Cells[1].Value.ToString());

                txtNgayNhap.Text = dGVPhieuNhap.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtpNgayNhap.Value = Convert.ToDateTime(dGVPhieuNhap.Rows[e.RowIndex].Cells[3].Value.ToString());
                txtNgayCapNhat.Text = dGVPhieuNhap.Rows[e.RowIndex].Cells[4].Value.ToString();

                txtNoiDung.Text = dGVPhieuNhap.Rows[e.RowIndex].Cells[5].Value.ToString();

                dGVChiTietPN.DataSource = bllChiTietPN.ChiTietPhieuNhap(Convert.ToInt32(dGVPhieuNhap.Rows[e.RowIndex].Cells[0].Value.ToString()));

            }
        }

        private void dGVChiTietPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1);
            if (validClick)
            {
                maTCClick = Convert.ToInt32(dGVChiTietPN.Rows[e.RowIndex].Cells[1].Value.ToString());

                txtMaGiong.Text = dGVChiTietPN.Rows[e.RowIndex].Cells[0].Value.ToString();
                cboMaGiong.SelectedValue = Convert.ToInt32(dGVChiTietPN.Rows[e.RowIndex].Cells[0].Value.ToString());

                txtTenTC.Text = bllThuCung.LayTenTC(Convert.ToInt32(dGVChiTietPN.Rows[e.RowIndex].Cells[1].Value.ToString())).ToString();
                txtGiaNhap.Text = dGVChiTietPN.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
            if (isThemCT)
            {
                dGVChiTietPN.DataSource = null;
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                isThemCT = true;
                if (!dt.Columns.Contains("MaGiong") && !dt.Columns.Contains("MaTC") && !dt.Columns.Contains("TenTC") && !dt.Columns.Contains("GiaNhap"))
                {
                    //Đặt tên cho cột trong datagirdview
                    dt.Columns.Add("MaGiong", typeof(int));
                    dt.Columns.Add("MaTC", typeof(int));
                    dt.Columns.Add("TenTC", typeof(string));
                    dt.Columns.Add("GiaNhap", typeof(decimal));
                }

                if (txtTenTC.Text.Trim() == "")
                    MessageBox.Show("Tên thú cưng không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtGiaNhap.Text == "")
                    MessageBox.Show("Giá nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    maTC++;
                    dt.Rows.Add(cboMaGiong.SelectedValue, maTC, txtTenTC.Text, Convert.ToDecimal(txtGiaNhap.Text));
                    dGVChiTietPN.DataSource = dt;
                }
            }
            else
            {
                if (txtTenTC.Text.Trim() == "")
                    MessageBox.Show("Tên thú cưng không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtGiaNhap.Text == "")
                    MessageBox.Show("Giá nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    DateTime ngay = DateTime.Now;

                    ThuCungDTO info = new ThuCungDTO();
                    info.TenTC = txtTenTC.Text;
                    info.GiaBan = Convert.ToDecimal(txtGiaNhap.Text);
                    info.Anh = "cho.png";
                    info.CreateDate = ngay;
                    info.NgayCapNhat = ngay;
                    info.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue.ToString());
                    info.MaLoai = Convert.ToInt32(bllGiong.LayMaLoai(Convert.ToInt32(cboMaGiong.SelectedValue.ToString())).Rows[0][0].ToString());
                    info.TrangThai = 0;

                    if (bllThuCung.ThemTCChiTiet(info))
                    {
                        ChiTietPhieuNhapDTO ctpn = new ChiTietPhieuNhapDTO();
                        ctpn.MaPN = maPN;
                        ctpn.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue.ToString());
                        ctpn.MaTC = Convert.ToInt32(bllThuCung.DanhSachTCTheoMa().Rows[0][0].ToString());
                        ctpn.GiaNhap = Convert.ToDecimal(txtGiaNhap.Text);

                        if (bllChiTietPN.Them(ctpn))
                        {
                            MessageBox.Show("Thêm chi tiết phiếu nhập thành công!", "Thêm chi tiết phiếu nhập", MessageBoxButtons.OK);
                        }
                        else
                            MessageBox.Show("Thêm chi tiết phiếu nhập thất bại!", "Thêm chi tiết phiếu nhập", MessageBoxButtons.OK);
                        dGVChiTietPN.DataSource = bllChiTietPN.ChiTietPhieuNhap(Convert.ToInt32(maPN));
                        dGVPhieuNhap.DataSource = bllPhieuNhap.PhieuNhap();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thú cưng thất bại!", "Thêm thú cưng", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                if (dt.Rows.Count > 0)
                {
                    DateTime ngay = DateTime.Now;
                    PhieuNhapDTO info = new PhieuNhapDTO();
                    info.MaDDM = Convert.ToInt32(cboMaDDM.SelectedValue.ToString());
                    info.MaNV = maNV;
                    info.NgayNhap = ngay;
                    info.NgayCapNhat = ngay;
                    info.NoiDung = txtNoiDung.Text;
                    if (bllPhieuNhap.Them(info))
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DateTime ngayCT = DateTime.Now;

                            ThuCungDTO tc = new ThuCungDTO();
                            tc.TenTC = dt.Rows[i][2].ToString();
                            tc.GiaBan = decimal.Parse(dt.Rows[i][3].ToString());
                            tc.Anh = "cho.png";
                            tc.CreateDate = ngayCT;
                            tc.NgayCapNhat = ngayCT;
                            tc.MaGiong = int.Parse(dt.Rows[i][0].ToString());
                            tc.MaLoai = Convert.ToInt32(bllGiong.LayMaLoai(tc.MaGiong).Rows[0][0].ToString());
                            tc.TrangThai = 0;

                            if (bllThuCung.ThemTCChiTiet(tc))
                            {
                                ChiTietPhieuNhapDTO ctpn = new ChiTietPhieuNhapDTO();
                                ctpn.MaPN = Convert.ToInt32(bllPhieuNhap.LayMaPNTheoNgay(ngay).Rows[0][0].ToString());
                                ctpn.MaGiong = tc.MaGiong;
                                ctpn.MaTC = Convert.ToInt32(bllThuCung.DanhSachTCTheoMa().Rows[0][0].ToString());
                                ctpn.GiaNhap = tc.GiaBan;
                                bllChiTietPN.Them(ctpn);
                            }
                        }
                        MessageBox.Show("Thêm chi tiết phiếu nhập thành công!", "Thêm chi tiết phiếu nhập", MessageBoxButtons.OK);
                        dGVPhieuNhap.DataSource = bllPhieuNhap.PhieuNhap();
                        dGVChiTietPN.DataSource = bllChiTietPN.ChiTietPhieuNhapTheoNgay(ngay);
                    }
                    else
                    {
                        MessageBox.Show("Thêm phiếu nhập thất bại!", "Thêm phiếu nhập", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng thêm chi tiết phiếu nhập", "Thêm chi tiết phiếu nhập", MessageBoxButtons.OK);
                }
                
            }
            else
            {
                if (txtTenTC.Text.Trim() == "")
                    MessageBox.Show("Tên thú cưng không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtGiaNhap.Text == "")
                    MessageBox.Show("Giá nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    DateTime ngay = DateTime.Now;
                    PhieuNhapDTO info = new PhieuNhapDTO();
                    info.MaPN = maPN;
                    info.MaDDM = Convert.ToInt32(cboMaDDM.SelectedValue.ToString());
                    info.MaNV = maNV;
                    info.NgayCapNhat = ngay;
                    info.NoiDung = txtNoiDung.Text;

                    if (bllPhieuNhap.Sua(info, info.MaPN))
                    {
                        ChiTietPhieuNhapDTO ctpn = new ChiTietPhieuNhapDTO();
                        ctpn.MaPN = info.MaPN;
                        ctpn.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue.ToString());
                        ctpn.MaTC = maTCClick;
                        ctpn.GiaNhap = Convert.ToDecimal(txtGiaNhap.Text);

                        if (bllChiTietPN.Sua(ctpn, ctpn.MaTC))
                        {
                            DateTime ngayCT = DateTime.Now;
                            ThuCungDTO tc = new ThuCungDTO();
                            tc.MaTC = maTCClick;
                            tc.TenTC = txtTenTC.Text;
                            tc.GiaBan = Convert.ToDecimal(txtGiaNhap.Text);
                            tc.Anh = "cho.png";
                            tc.NgayCapNhat = ngayCT;
                            tc.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue.ToString());
                            tc.MaLoai = Convert.ToInt32(bllGiong.LayMaLoai(Convert.ToInt32(cboMaGiong.SelectedValue.ToString())).Rows[0][0].ToString());

                            if (bllThuCung.SuaThuCungChiTiet(tc, tc.MaTC))
                            {
                                MessageBox.Show("Sửa chi tiết phiếu nhập thành công!", "Sửa chi tiết phiếu nhập", MessageBoxButtons.OK);
                                dGVChiTietPN.DataSource = bllChiTietPN.ChiTietPhieuNhap(maPN);
                                dGVPhieuNhap.DataSource = bllPhieuNhap.PhieuNhap();
                                BatTat(false);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sửa chi tiết phiếu nhập thất bại!", "Sửa chi tiết phiếu nhập", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btnDongTab_Click(object sender, EventArgs e)
        {
            pnTab.Visible = false;
        }
    }
}
