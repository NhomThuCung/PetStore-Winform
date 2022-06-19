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
    public partial class frmDonDatMua : Form
    {
        private bool isThem;
        private bool isThemCT;
        DonDatMuaBLL bllDonDatMua = new DonDatMuaBLL();
        ChiTietDDMBLL bllCTDDM = new ChiTietDDMBLL();
        NhaCungCapBLL bllNCC = new NhaCungCapBLL();
        GiongBLL bllGiong = new GiongBLL();
        System.Data.DataTable dt;
        int maNV = NhanVienBLL.frmDonHangmaNV;
        public frmDonDatMua()
        {
            InitializeComponent();
        }

        private void frmDonDatMua_Load(object sender, EventArgs e)
        {
            pnTab.Visible = false;
            dGVDonDatMua.DataSource = bllDonDatMua.DonDatMua();

            cboMaNCC.DataSource = bllNCC.NhaCungCap();
            cboMaNCC.ValueMember = "MaNCC";
            cboMaNCC.DisplayMember = "TenNCC";

            cboMaGiong.DataSource = bllGiong.DanhSach();
            cboMaGiong.ValueMember = "MaGiong";
            cboMaGiong.DisplayMember = "TenGiong";
            BatTat(false);
            Custom(false);

            dtpNgayCN.Value = DateTime.Now;

            //Format tiền cho dataGridView1
            dGVDonDatMua.Columns["Column5"].DefaultCellStyle.Format = "c0";
            dGVChiTietDDM.Columns["Column7"].DefaultCellStyle.Format = "c0";
        }
        public void BatTat(bool tt)
        {
            txtMaNCC.Enabled = tt;
            txtMaDDM.Enabled = tt;
            txtGiaMua.Enabled = tt;
            txtMaGiong.Enabled = tt;
            numSoLuong.Enabled = tt;
            txtNoiDung.Enabled = tt;

            dtpNgayTao.Enabled = tt;
            dtpNgayCN.Enabled = tt;

            //btnSua.Enabled = tt;
            btnHuy.Enabled = tt;
            btnThemChiTiet.Enabled = tt;
            btnLuu.Enabled = tt;
        }

        public void Custom(bool tt)
        {
            cboMaGiong.Visible = tt;
            cboMaNCC.Visible = tt;

            txtMaGiong.Visible = !tt;
            txtMaNCC.Visible = !tt;
        }

        private void dGVDonDatMua_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1);
            if (validClick)
            {
                pnTab.Visible = true;
                BatTat(false);
                Custom(false);
                btnSua.Enabled = true;
                dGVChiTietDDM.DataSource = bllCTDDM.ChiTietDDM(Convert.ToInt32(dGVDonDatMua.Rows[e.RowIndex].Cells[0].Value.ToString()));

                //Hien thi thong tin 
                txtMaNCC.Text = dGVDonDatMua.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMaDDM.Text = dGVDonDatMua.Rows[e.RowIndex].Cells[0].Value.ToString();
                dtpNgayTao.Value = Convert.ToDateTime(dGVDonDatMua.Rows[e.RowIndex].Cells[2].Value.ToString());
            }    
        }

        private void dGVChiTietDDM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnSua.Enabled = true;
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1);
            if (validClick)
            {
                txtMaGiong.Text = dGVChiTietDDM.Rows[e.RowIndex].Cells[0].Value.ToString();
                cboMaGiong.SelectedValue = Convert.ToInt32(txtMaGiong.Text);
                txtGiaMua.Text = dGVChiTietDDM.Rows[e.RowIndex].Cells[1].Value.ToString();
                numSoLuong.Value = Convert.ToInt32(dGVChiTietDDM.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
        }

        private void btnDongTab_Click(object sender, EventArgs e)
        {
            pnTab.Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            pnTab.Visible = true;
            dt = new System.Data.DataTable();
            dGVChiTietDDM.DataSource = null;
            isThem = true;
            BatTat(true);
            Custom(true);

            txtMaDDM.Enabled = false;
            dtpNgayTao.Enabled = false;
            dtpNgayCN.Enabled = false;


            dtpNgayTao.Value = DateTime.Now;
            dtpNgayCN.Value = DateTime.Now;

            txtGiaMua.Text = "";
            numSoLuong.Value = 0;

            btnSua.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
            Custom(false);
            btnSua.Enabled = true;
            if (isThemCT)
            {
                dGVChiTietDDM.DataSource = null;
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                isThemCT = true;
                if (!dt.Columns.Contains("MaGiong") && !dt.Columns.Contains("GiaMua") && !dt.Columns.Contains("SoLuongMua"))
                {
                    //Đặt tên cho cột trong datagirdview
                    dt.Columns.Add("MaGiong", typeof(int));
                    dt.Columns.Add("GiaMua", typeof(decimal));
                    dt.Columns.Add("SoLuongMua", typeof(int));
                }
                if (txtGiaMua.Text.Trim() == "")
                    MessageBox.Show("Vui lòng nhập giá mua!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (numSoLuong.Value <= 0)
                    MessageBox.Show("Vui lòng nhập số lượng giống cần mua!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    bool kt = true;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (cboMaGiong.SelectedValue.ToString() == dt.Rows[i][0].ToString())
                        {
                            MessageBox.Show("Vui lòng chọn giống khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (MessageBox.Show("Bạn có cập nhật không ?", "Đơn Đặt Mua", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                dt.Rows[i][2] = numSoLuong.Value;
                                dt.Rows[i][1] = Convert.ToDecimal(txtGiaMua.Text);
                                kt = false;
                            }
                            else
                            {
                                kt = false;
                            }
                        }
                    }
                    if (kt == true)
                    {
                        dt.Rows.Add(cboMaGiong.SelectedValue, Convert.ToDecimal(txtGiaMua.Text), numSoLuong.Value);
                        dGVChiTietDDM.DataSource = dt;
                    }
                }
            }
            else
            {
                if (txtGiaMua.Text.Trim() == "")
                    MessageBox.Show("Vui lòng nhập giá mua!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (numSoLuong.Value <= 0)
                    MessageBox.Show("Vui lòng nhập số lượng giống cần mua!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    ChiTietDDMDTO info = new ChiTietDDMDTO();
                    info.MaDDM = Convert.ToInt32(txtMaDDM.Text);
                    info.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue);
                    info.GiaMua = Convert.ToDecimal(txtGiaMua.Text);
                    info.SoLuongMua=  Convert.ToInt32(numSoLuong.Value);
                    bool kt = true;
                    for (int i = 0; i < bllCTDDM.ChiTietDDM(info.MaDDM).Rows.Count; i++)
                    {
                        if (bllCTDDM.ChiTietDDM(info.MaDDM).Rows[i][0].ToString() == info.MaGiong.ToString())
                        {
                            if (MessageBox.Show("Bạn có muốn sửa chi tiết đơn đặt hàng không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (bllCTDDM.Sua(info, info.MaDDM, info.MaGiong))
                                {
                                    MessageBox.Show("Thêm chi tiết đơn đặt mua thành công!", "Thêm chi tiết đơn đặt mua", MessageBoxButtons.OK);
                                    dGVChiTietDDM.DataSource = bllCTDDM.ChiTietDDM(Convert.ToInt32(txtMaDDM.Text));
                                    frmDonDatMua_Load(sender, e);
                                }
                                else
                                {
                                    MessageBox.Show("Thêm chi tiết đơn đặt mua thất bại!", "Thêm chi tiết đơn đặt mua", MessageBoxButtons.OK);
                                }
                            }
                            kt = false;
                        }
                    }
                    if (kt == true)
                    {
                        if (bllCTDDM.Them(info))
                        {
                            MessageBox.Show("Thêm chi tiết đơn đặt mua thành công!", "Thêm chi tiết đơn đặt mua", MessageBoxButtons.OK);
                            frmDonDatMua_Load(sender, e);
                        }
                    }
                    

                    //if (bllCTDDM.UpdateLinq(Convert.ToInt32(txtMaDDM.Text), Convert.ToInt32(cboMaGiong.SelectedValue),Convert.ToDecimal(txtGiaMua.Text),Convert.ToInt32(numSoLuong.Value)))
                    //{
                    //    MessageBox.Show("Thêm chi tiết đơn đặt mua thành công!", "Thêm chi tiết đơn đặt mua", MessageBoxButtons.OK);
                    //    dGVChiTietDDM.DataSource = bllCTDDM.ChiTietDDM(Convert.ToInt32(txtMaDDM.Text));
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Thêm chi tiết đơn đặt mua thất bại!", "Thêm chi tiết đơn đặt mua", MessageBoxButtons.OK);
                    //}
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            
            BatTat(true);
            Custom(true);
            btnSua.Enabled = false;

            txtMaDDM.Enabled = false;
            dtpNgayTao.Enabled = false;
            dtpNgayCN.Enabled = false;

            cboMaNCC.SelectedValue = Convert.ToInt32(txtMaNCC.Text);
            //if (txtMaGiong.Text.Trim() == "")
            //{
            //    MessageBox.Show("Vui lòng chọn giống cần sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    cboMaGiong.SelectedValue = Convert.ToInt32(txtMaGiong.Text);
            //}
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                if (dt.Rows.Count > 0)
                {
                    DateTime ngay = DateTime.Now;
                    DonDatMuaDTO info = new DonDatMuaDTO();
                    info.MaNCC = Convert.ToInt32(cboMaNCC.SelectedValue);
                    info.MaNV = maNV;
                    info.CreateDate = ngay;
                    info.NgayCapNhat = ngay;
                    info.NoiDung = txtNoiDung.Text;

                    if (bllDonDatMua.Them(info))
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ChiTietDDMDTO ctddm = new ChiTietDDMDTO();
                            ctddm.MaDDM = Convert.ToInt32(bllDonDatMua.LayMaDDMMoiNhat().Rows[0][0].ToString());
                            ctddm.MaGiong = Convert.ToInt32(dt.Rows[i][0].ToString());
                            ctddm.GiaMua = Convert.ToDecimal(dt.Rows[i][1].ToString());
                            ctddm.SoLuongMua = Convert.ToInt32(dt.Rows[i][2].ToString());
                            if (bllCTDDM.Them(ctddm))
                            {
                                MessageBox.Show("Thêm đơn đặt mua thành công!", "Thêm đơn đặt mua", MessageBoxButtons.OK);
                                frmDonDatMua_Load(sender, e);
                            }
                        }
                    }

                    //if (bllDonDatMua.ThemLinq(Convert.ToInt32(cboMaNCC.SelectedValue), maNV, DateTime.Now, DateTime.Now, txtNoiDung.Text))
                    //{
                    //    for (int i = 0; i < dt.Rows.Count; i++)
                    //    {
                    //        int maGiong = Convert.ToInt32(dt.Rows[i][0].ToString());
                    //        decimal giaMua = Convert.ToDecimal(dt.Rows[i][1].ToString());
                    //        int soLuongMua = Convert.ToInt32(dt.Rows[i][2].ToString());
                    //        int maDDMMoiNhat = Convert.ToInt32(bllDonDatMua.LayMaDDMMoiNhat().Rows[0][0].ToString());
                    //        if (bllCTDDM.ThemLinq(maDDMMoiNhat, maGiong, giaMua,soLuongMua))
                    //        {
                    //            MessageBox.Show("Thêm đơn đặt mua thành công!", "Thêm đơn đặt mua", MessageBoxButtons.OK);
                    //            frmDonDatMua_Load(sender, e);
                    //        }
                    //    }
                    //}
                    else
                    {
                        MessageBox.Show("Thêm đơn đặt mua thất bại!", "Thêm đơn đặt mua", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                //if (bllDonDatMua.UpdateLinq(Convert.ToInt32(txtMaDDM.Text),Convert.ToInt32(cboMaNCC.SelectedValue),maNV, dtpNgayTao.Value, DateTime.Now, txtNoiDung.Text))
                //{
                    bool kt = false;
                    for (int i = 0; i < bllCTDDM.ChiTietDDM(Convert.ToInt32(txtMaDDM.Text)).Rows.Count; i++)
                    {
                        if (bllCTDDM.ChiTietDDM(Convert.ToInt32(txtMaDDM.Text)).Rows[i][0].ToString() == cboMaGiong.SelectedValue.ToString())
                        {
                            ChiTietDDMDTO info = new ChiTietDDMDTO();
                            info.MaDDM = Convert.ToInt32(txtMaDDM.Text);
                            info.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue);
                            info.GiaMua = Convert.ToDecimal(txtGiaMua.Text);
                            info.SoLuongMua = Convert.ToInt32(numSoLuong.Value);

                            if (bllCTDDM.Sua(info, info.MaDDM, info.MaGiong))
                            {
                                kt = true;
                                DateTime ngay = DateTime.Now;
                                DonDatMuaDTO ddm = new DonDatMuaDTO();
                                ddm.MaDDM = Convert.ToInt32(txtMaDDM.Text);
                                ddm.MaNCC = Convert.ToInt32(cboMaNCC.SelectedValue);
                                ddm.MaNV = maNV;
                                ddm.CreateDate = dtpNgayTao.Value;
                                ddm.NgayCapNhat = ngay;
                                ddm.NoiDung = txtNoiDung.Text;

                                if (bllDonDatMua.Sua(ddm, ddm.MaDDM))
                                {
                                    MessageBox.Show("Cập nhật đơn đặt mua thành công", "Thêm đơn đặt mua", MessageBoxButtons.OK);
                                    frmDonDatMua_Load(sender, e);
                                }
                                else
                                {
                                    MessageBox.Show("Cập nhật đơn đặt mua thất bại", "Thêm đơn đặt mua", MessageBoxButtons.OK);
                                }
                            }
                            
                            //if (bllCTDDM.UpdateLinq(Convert.ToInt32(txtMaDDM.Text), Convert.ToInt32(cboMaGiong.SelectedValue), Convert.ToDecimal(txtGiaMua.Text), Convert.ToInt32(numSoLuong.Value)))
                            //{
                            //    kt = true;
                            //    if (bllDonDatMua.UpdateLinq(Convert.ToInt32(txtMaDDM.Text), Convert.ToInt32(cboMaNCC.SelectedValue), maNV, dtpNgayTao.Value, DateTime.Now, txtNoiDung.Text))
                            //    {
                            //        MessageBox.Show("Cập nhật đơn đặt mua thành công", "Thêm đơn đặt mua", MessageBoxButtons.OK);
                            //        frmDonDatMua_Load(sender, e);
                            //    }
                            //    else
                            //    {
                            //        MessageBox.Show("Cập nhật đơn đặt mua thất bại", "Thêm đơn đặt mua", MessageBoxButtons.OK);
                            //    }
                                
                            //}
                        }
                    }
                    if (kt == false)
                    {
                        ChiTietDDMDTO info = new ChiTietDDMDTO();
                        info.MaDDM = Convert.ToInt32(txtMaDDM.Text);
                        info.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue);
                        info.GiaMua = Convert.ToDecimal(txtGiaMua.Text);
                        info.SoLuongMua = Convert.ToInt32(numSoLuong.Value);

                        if (bllCTDDM.Them(info))
                        {
                            MessageBox.Show("Thêm chi tiết đơn đặt mua thành công!", "Thêm chi tiết đơn đặt mua", MessageBoxButtons.OK);
                            frmDonDatMua_Load(sender, e);
                        }

                        //if (bllCTDDM.ThemLinq(Convert.ToInt32(txtMaDDM.Text), Convert.ToInt32(cboMaGiong.SelectedValue), Convert.ToDecimal(txtGiaMua.Text), Convert.ToInt32(numSoLuong.Value)))
                        //{
                        //    MessageBox.Show("Thêm chi tiết đơn đặt mua thành công!", "Thêm chi tiết đơn đặt mua", MessageBoxButtons.OK);
                        //    frmDonDatMua_Load(sender, e);
                        //}

                    }
                //}
                //else
                //{
                    //    MessageBox.Show("Cập nhật đơn đặt mua thất bại", "Thêm đơn đặt mua", MessageBoxButtons.OK);
                    //}
            }
        }
    }
}
