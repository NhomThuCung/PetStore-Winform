using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using BLL;
using DTO;
using DAL;
using DoAn_DotNet.Custom;

namespace DoAn_DotNet.GUI
{
    public partial class frmDonHang : Form
    {
        KhachHangBLL khBLL = new KhachHangBLL();
        KhachHangDAO khDAO = new KhachHangDAO();

        ThuCungBLL tcBLL = new ThuCungBLL();
        ThuCungDAO tcDAO = new ThuCungDAO();

        DonHangBLL dhBLL = new DonHangBLL();
        DonHangDAO dhDAO = new DonHangDAO();

        ChiTietDonHangBLL ctdhBLL = new ChiTietDonHangBLL();

        frmKhachHang fKH = null;
        frmThanhToan fTT = null;

        public static double tongTien = 0;

        public static int tienNhan = 0;

        private bool isThem = false;
        int maNV = BLL.UserAdminBLL.frmDonHangmaNV;
        public static int maDH = 0;

        public static int soTC = 0;

        public frmDonHang()
        {
            InitializeComponent();
        }


        private void frmDonHang_Load(object sender, EventArgs e)
        {
            
            txtMaNV.Text = maNV.ToString();
            BatTat(false);
            khBLL.HienThiVaoDGV(dataGridView1, txtSoDT.Text);
            tcBLL.HienThiVaoDGV(dataGridView2, txtTenTC.Text);
            dhBLL.HienThiVaoDGV(dataGridView4);
            dhBLL.HienThiVaoDGV2(dataGridView5, dateTimePicker2, dateTimePicker3);
            dataGridView2.Columns["GiaBan"].DefaultCellStyle.Format = "c0";
            dataGridView5.Columns["Column15"].DefaultCellStyle.Format = "c0";
        }

        public void BatTat(bool tt)
        {
            txtSoDT.Enabled = !tt;
            dataGridView1.Enabled = !tt;

            txtTenTC.Enabled = tt;
            dataGridView2.Enabled = tt;
    
            txtTenKH.Enabled = !tt;
            txtEmail.Enabled = !tt;
            txtSDT.Enabled = !tt;
            txtDiaChi.Enabled = !tt;

            numSoLuong.Enabled = tt;

            btnThemDon.Enabled = !tt;
            btnXoaDon.Enabled = tt;
            btnThem.Enabled = tt;
            btnXoa.Enabled = tt;
            btnThanhToan.Enabled = tt;

            dataGridView4.Enabled = tt;
            dataGridView3.Enabled = tt;
            txtTienNhan.Enabled = tt;
        }

        private void txtSoDT_TextChanged(object sender, EventArgs e)
        {
            khBLL.HienThiVaoDGV(dataGridView1, txtSoDT.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridView1.CurrentRow.Selected = true;
            txtMaKH.Text = dataGridView1.Rows[e.RowIndex].Cells["MaKH"].FormattedValue.ToString();
            txtTenKH.Text = dataGridView1.Rows[e.RowIndex].Cells["HoTen"].FormattedValue.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
            txtSDT.Text = dataGridView1.Rows[e.RowIndex].Cells["DienThoai"].FormattedValue.ToString();
            txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells["DiaChi"].FormattedValue.ToString();

        }

        private void txtTenTC_TextChanged(object sender, EventArgs e)
        {
            tcBLL.HienThiVaoDGV(dataGridView2, txtTenTC.Text);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridView2.CurrentRow.Selected = true;
            txtMaTC.Text = dataGridView2.Rows[e.RowIndex].Cells["MaTC"].FormattedValue.ToString();
            soTC = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["SoLuongTon"].FormattedValue.ToString());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            
            if (txtDH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã hoá đơn cần thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtMaTC.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã thú cưng cần thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numSoLuong.Value == 0)
                MessageBox.Show("Số lượng thú cưng phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (numSoLuong.Value > soTC)
                MessageBox.Show("Số lượng thú cưng mua phải nhỏ hơn số lượng tồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (dataGridView4 != null)
                {
                    ChiTietDonHang ctdh = new ChiTietDonHang();
                    ctdh.MaDH = Convert.ToInt32(txtDH.Text);
                    ctdh.MaTC = Convert.ToInt32(txtMaTC.Text);
                    ctdh.SoLuong = Convert.ToInt32(numSoLuong.Value);
                    ctdh.ThanhTien = Convert.ToDecimal(null);
                    string ma = "";
                    for (int i = 0; i < dataGridView3.Rows.Count; ++i)
                    {
                        ma = dataGridView3.Rows[i].Cells["Column1"].Value.ToString();
                        if (txtMaTC.Text == ma)
                        {
                            ctdhBLL.SuaChiTiet(ctdh,Convert.ToInt32(txtMaTC.Text), Convert.ToInt32(txtDH.Text));
                            MessageBox.Show("Sửa Hoá Đơn Thành Công", "Thông Báo");
                            isThem = false;
                        }
                    }
                    if (isThem == true)
                    {
                        ctdhBLL.Them(ctdh);
                        MessageBox.Show("Thêm Hoá Đơn Thành Công", "Thông Báo");
                    }
                    // Tải lại lưới
                    ctdhBLL.HienThiVaoDGV(dataGridView3, Convert.ToInt32(txtDH.Text));
                    double total = 0;
                    for (int i = 0; i < dataGridView3.Rows.Count; ++i)
                    {
                        total += Convert.ToDouble(dataGridView3.Rows[i].Cells["Column3"].Value);
                    }

                    tongTien = total;

                    txtTongTien.Text = total.ToString();
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    decimal value = decimal.Parse(txtTongTien.Text, System.Globalization.NumberStyles.AllowThousands);
                    txtTongTien.Text = String.Format(culture, "{0:N0}", value);
                    txtTongTien.Select(txtTongTien.Text.Length, 0);

                    frmDonHang_Load(sender, e);
                    if (dataGridView3.Rows.Count == 0)
                    {
                        BatTat(true);
                    }
                    else
                    {
                        BatTat(true);
                        btnXoaDon.Enabled = false;
                        maDH = Convert.ToInt32(txtDH.Text);
                    }
                    dataGridView4.Enabled = false;
                }
                
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridView4.CurrentRow.Selected = true;
            txtDH.Text = dataGridView4.Rows[e.RowIndex].Cells["MaDH"].FormattedValue.ToString();
        }

        private bool IsValidEmail(string eMail)
        {
            bool Result = false;

            try
            {
                var eMailValidator = new System.Net.Mail.MailAddress(eMail);

                Result = (eMail.LastIndexOf(".") > eMail.LastIndexOf("@"));
            }
            catch
            {
                Result = false;
            };

            return Result;
        }

        private void btnThemDon_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim() == "")
                MessageBox.Show("Vui lòng nhập tên khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtEmail.Text.Trim() == "")
                MessageBox.Show("Vui lòng nhập email khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtSDT.Text.Trim() == "")
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDiaChi.Text.Trim() == "")
                MessageBox.Show("Vui lòng nhập địa chỉ khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtSDT.Text.Length > 15)
                MessageBox.Show("Số điện thoại không vượt quá 15 số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (IsValidEmail(txtEmail.Text) == false)
                MessageBox.Show("Email không đúng định dạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            if (MessageBox.Show("Bạn có muốn thêm đơn mới không?", "Thêm Đơn Mới", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DonHang dh = new DonHang();
                dh.Id = Convert.ToInt32(txtMaNV.Text);
                dh.CreatedDate = dateTimePicker1.Value;
                dh.MaKH = Convert.ToInt32(txtMaKH.Text);
                dh.NguoiNhan = txtTenKH.Text;
                dh.Email = txtEmail.Text;
                dh.SoDT = txtSDT.Text;
                dh.DiaChi = txtDiaChi.Text;
                dh.TongTien = Convert.ToDecimal(null);
                dh.Status = Convert.ToBoolean(0);

                dhBLL.Them(dh);
                MessageBox.Show("Thêm Thành Công", "Đơn Hàng");
                frmDonHang_Load(sender, e);
                if (dataGridView3.Rows.Count == 0)
                {
                    BatTat(true);
                }
                else
                {
                    BatTat(true);
                    btnXoaDon.Enabled = false;
                    maDH = Convert.ToInt32(txtDH.Text);
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtTongTien.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn hoá đơn cần thành toán", "Thanh Toán");
            }
            else 
            if (txtTienNhan.TextLength != 0)
            {
                if ( Convert.ToDouble(txtTienNhan.Text) >= tongTien)
                {
                    if (MessageBox.Show("Bạn có muốn thanh toán hoá đơn không?", "Thanh Toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        DonHang dh = new DonHang();
                        dh.MaDH = Convert.ToInt32(txtDH.Text);
                        dh.Status = Convert.ToBoolean(1);

                        CultureInfo info = new CultureInfo("vi-VN");

                        double tienThua = Convert.ToDouble(txtTienNhan.Text) - tongTien;
                        txtTienThua.Text = tienThua.ToString("c0", info);


                        dhBLL.Sua(dh, dh.MaDH);
                        MessageBox.Show("Thanh toán thành công", "Thanh Toán");

                        maDH = Convert.ToInt32(txtDH.Text);

                        frmDonHang_Load(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tiền nhận lớn hơn tổng tiền", "Thanh Toán");
                }
            }
            else
                MessageBox.Show("Vui lòng nhập tiền nhận từ khách", "Thanh Toán");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtDH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã hoá đơn cần xoá?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtMaTC.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã thú cưng cần xoá?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            if (MessageBox.Show("Bạn có muốn xoá hoá đơn không?", "Chi tiết hoá đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ChiTietDonHang ctdh = new ChiTietDonHang();
                ctdh.MaDH = Convert.ToInt32(txtDH.Text);
                ctdh.MaTC = Convert.ToInt32(txtMaTC.Text);
                ctdhBLL.XoaChiTiet(ctdh);
                MessageBox.Show("Xoá Thành Công", "Chi tiết hoá đơn");
                ctdhBLL.HienThiVaoDGV(dataGridView3, Convert.ToInt32(txtDH.Text));
                int total = 0;
                for (int i = 0; i < dataGridView3.Rows.Count; ++i)
                {
                    total += Convert.ToInt32(dataGridView3.Rows[i].Cells["Column3"].Value);
                }
                txtTongTien.Text = total.ToString();

                frmDonHang_Load(sender, e);
                if (dataGridView3.Rows.Count == 0)
                {
                    BatTat(true);
                }
                else
                {
                    BatTat(true);
                    btnXoaDon.Enabled = false;
                }
                dataGridView4.Enabled = false;

            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridView3.CurrentRow.Selected = true;
            txtDH.Text = dataGridView3.Rows[e.RowIndex].Cells["col"].FormattedValue.ToString();
            txtMaTC.Text = dataGridView3.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
        }

        //private void txtTienNhan_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        //    {
        //        MessageBox.Show("Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void txtSoDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemDate_Click(object sender, EventArgs e)
        {
            dhBLL.HienThiVaoDGV2(dataGridView5, dateTimePicker2, dateTimePicker3);
        }

        private void btnXoaDon_Click(object sender, EventArgs e)
        {
            if (txtDH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn mã hoá đơn cần xoá?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            if (MessageBox.Show("Bạn có muốn xoá đơn hàng không?", "Đơn Hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DonHang dh = new DonHang();
                dh.MaDH = Convert.ToInt32(txtDH.Text);
                dhBLL.Xoa(dh);
                MessageBox.Show("Xoá Thành Công", "Đơn Hàng");
                frmDonHang_Load(sender, e);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Tải lại lưới
            frmDonHang_Load(sender, e);
        }

        private void btnQLTKKhachHang_Click(object sender, EventArgs e)
        {
            if (fKH == null || fKH.IsDisposed)
            {
                fKH = new frmKhachHang();
                fKH.Show();
            }
            else
                fKH.Activate();
        }

        //private void txtTienNhan_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtTienNhan.Text.Equals("0"))
        //            return;
        //        double temp = Convert.ToDouble(txtTienNhan.Text);
        //        tienNhan = Convert.ToInt32(txtTienNhan.Text);
        //        txtTienNhan.Text = temp.ToString("#,###");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Vui lòng nhập tiền theo định dạng số!");
        //    }
        //}

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (fTT == null || fTT.IsDisposed)
            {
                fTT = new frmThanhToan();
                loadMaDH.maDH = maDH;
                fTT.Show();
            }
            else
                fTT.Activate();
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Moi")
            {
                if (e.Value.ToString() == "True")
                    e.Value = "Mới thêm";
                else
                    e.Value = "Thú cưng cũ";
            }
        }

        private void dataGridView5_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView5.Columns[e.ColumnIndex].Name == "Column16")
            {
                if (e.Value.ToString() == "True")
                    e.Value = "Đã thanh toán";
                else
                    e.Value = "Chưa thanh toán";
            }
        }
    }
}
