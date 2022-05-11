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
using DoAn_DotNet.BLL;
using DoAn_DotNet.DTO;
using DoAn_DotNet.Custom;
using System.Globalization;

namespace DoAn_DotNet.GUI
{
    public partial class frmQLDonHang : Form
    {
        private string maDH = ""; // Mã đơn hàng cũ
        private string maDHCT = "";
        DonHangBLL dhBLL = new DonHangBLL();

        ChiTietDonHangBLL ctBLL = new ChiTietDonHangBLL();
        public frmQLDonHang()
        {
            InitializeComponent();
        }

        private void frmQLDonHang_Load(object sender, EventArgs e)
        {
            //Bảng đơn hàng
            BatTat(false);
            dhBLL.HienThiVaoDGV3(bN, dataGridView1,txtMaDH,
                                txtID,dtpNgayTao,txtMaKH,
                                txtHoTen,txtEmail,txtDienThoai,
                                txtDiaChi,txtTongTien,checkBox1,"");
            //Bảng chi tiết hoá đơn
            BatTatCT(false);
            ctBLL.HienThiVaoComboBox(cboDH, cboThuCung);
            ctBLL.HienThiVaoDGV2(bindingNavigator1, dataGridView2, cboDH, cboThuCung, txtGiaBan, txtSoLuong, txtThanhTien, "");
            dataGridView1.Columns["Column9"].DefaultCellStyle.Format = "c0";
        }

        public void BatTat(bool tt)
        {
            txtMaDH.Enabled = tt;
            txtMaKH.Enabled = tt;
            txtID.Enabled = tt;
            txtHoTen.Enabled = tt;
            txtEmail.Enabled = tt;
            txtDienThoai.Enabled = tt;
            txtDiaChi.Enabled = tt;
            dtpNgayTao.Enabled = tt;
            txtTongTien.Enabled = tt;
            checkBox1.Enabled = tt;

            btnLuu.Enabled = tt;
            btnHuy.Enabled = tt;

            btnSua.Enabled = !tt;
            btnXoa.Enabled = !tt;
        }

        public void BatTatCT(bool tt)
        {
            cboDH.Enabled = tt;
            cboThuCung.Enabled = tt;
            txtGiaBan.Enabled = tt;
            txtSoLuong.Enabled = tt;
            txtThanhTien.Enabled = tt;

            btnLuuCT.Enabled = tt;
            btnHuyCT.Enabled = tt;

            btnSuaCT.Enabled = !tt;
            btnXoaCT.Enabled = !tt;
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            maDH = txtMaDH.Text;
            txtMaDH.Enabled = false;
            txtID.Enabled = false;
            txtMaKH.Enabled = false;
            txtTongTien.Enabled = false;


            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá đơn hàng " + txtMaDH.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DonHang info = new DonHang();
                info.MaDH = Convert.ToInt32(txtMaDH.Text);
                dhBLL.Xoa(info);
                MessageBox.Show("Xoá đơn hàng thành công", "Xoá Đơn Hàng", MessageBoxButtons.OK);
            }

            // Tải lại lưới
            frmQLDonHang_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "")
                MessageBox.Show("Mã nhân viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtMaKH.Text.Trim() == "")
                MessageBox.Show("Mã khách hàng không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtHoTen.Text.Trim() == "")
                MessageBox.Show("Tên khách hàng không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtEmail.Text.Trim() == "")
                MessageBox.Show("Email không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (IsValidEmail(txtEmail.Text) == false)
                MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDiaChi.Text.Trim() == "")
                MessageBox.Show("Địa chỉ không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDienThoai.Text.Trim() == "")
                MessageBox.Show("Số điện thoại không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDienThoai.Text.Length < 9 || txtDienThoai.Text.Length > 15)
                MessageBox.Show("Số điện thoại phải từ 10 đến 14 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTongTien.Text.Trim() == "")
                MessageBox.Show("Tổng tiền không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else

            {
                DonHang info = new DonHang();

                info.Id = Convert.ToInt32(txtID.Text);
                info.CreatedDate = dtpNgayTao.Value;
                info.MaKH = Convert.ToInt32(txtMaKH.Text);
                info.NguoiNhan = txtHoTen.Text;
                info.Email = txtEmail.Text;
                info.SoDT = txtDienThoai.Text;
                info.DiaChi = txtDiaChi.Text;
                info.TongTien = Convert.ToDecimal(null);
                info.Status = checkBox1.Checked ? true : false;

                dhBLL.SuaDonHang(info, Convert.ToInt32(maDH));
                MessageBox.Show("Sửa hoá đơn thành công", "Sửa hoá đơn", MessageBoxButtons.OK);

                // Tải lại lưới
                frmQLDonHang_Load(sender, e);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmQLDonHang_Load(sender, e);
            MessageBox.Show("Load bảng đơn hàng thành công", "Load Bảng Đơn Hàng");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            dhBLL.HienThiVaoDGV3(bN, dataGridView1, txtMaDH,
                                txtID, dtpNgayTao, txtMaKH,
                                txtHoTen, txtEmail, txtDienThoai,
                                txtDiaChi, txtTongTien, checkBox1, txtTuKhoa.Text);
        }

        private void txtTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }


        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSDonHang";

            // Thêm dòng tiêu đề
            for (int c = 0; c < dataGridView1.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = dataGridView1.Columns[c].HeaderText;
            }

            // Thêm các dòng nội dung
            int cellRowIndex = 2;
            int cellColIndex = 1;
            for (int d = 0; d < dataGridView1.Rows.Count; d++)
            {
                for (int c = 0; c < dataGridView1.Columns.Count; c++)
                {
                    sheet.Cells[cellRowIndex, cellColIndex] = dataGridView1.Rows[d].Cells[c].Value.ToString();
                    cellColIndex++;
                }
                cellColIndex = 1;
                cellRowIndex++;
            }

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workbook.SaveAs(file.FileName);
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Danh sách đã được xuất ra tập tin Excel!", "Xuất Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "QUẢN LÝ DƠN HÀNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        //Bảng chi tiết hoá đơn

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            BatTatCT(true);
            maDHCT = cboDH.SelectedValue.ToString();

            cboDH.Enabled = false;
            txtGiaBan.Enabled = false;
            txtThanhTien.Enabled = false;
            cboThuCung.Enabled = false;

            txtSoLuong.Focus();
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá chi tiết đơn hàng " + cboDH.SelectedValue + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ChiTietDonHang info = new ChiTietDonHang();
                info.MaDH = Convert.ToInt32(cboDH.SelectedValue);
                info.MaTC = Convert.ToInt32(cboThuCung.SelectedValue);
                ctBLL.XoaChiTiet(info);
                MessageBox.Show("Xoá chi tiết đơn hàng thành công", "Xoá Chi Tiết Đơn Hàng", MessageBoxButtons.OK);
            }

            // Tải lại lưới
            frmQLDonHang_Load(sender, e);
        }

        private void btnHuyCT_Click(object sender, EventArgs e)
        {
            BatTatCT(false);
        }

        private void btnLuuCT_Click(object sender, EventArgs e)
        {
            if (cboDH.Text.Trim() == "")
                MessageBox.Show("Vui lòng chọn đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboThuCung.Text.Trim() == "")
                MessageBox.Show("Vui lòng chọn thú cưng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtSoLuong.Text.Trim() == "")
                MessageBox.Show("Số lượng không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtThanhTien.Text.Trim() == "")
                MessageBox.Show("Thành tiền không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ChiTietDonHang info = new ChiTietDonHang();
                info.SoLuong = Convert.ToInt32(txtSoLuong.Text);

                ctBLL.SuaChiTiet(info, Convert.ToInt32(cboThuCung.SelectedValue), Convert.ToInt32(maDHCT));
                MessageBox.Show("Sửa chi tiết đơn hàng thành công", "Sửa Chi Tiết Đơn Hàng", MessageBoxButtons.OK);

                // Tải lại lưới
                frmQLDonHang_Load(sender, e);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            frmQLDonHang_Load(sender, e);
            MessageBox.Show("Load bảng chi tiết đơn hàng thành công", "Load Bảng Chi Tiết Đơn Hàng");
        }

        private void btnTimKiemCT_Click(object sender, EventArgs e)
        {
            ctBLL.HienThiVaoDGV2(bindingNavigator1, dataGridView2, cboDH, cboThuCung, txtGiaBan, txtSoLuong, txtThanhTien, txtTuKhoaCT.Text);

        }

        private void txtTuKhoaCT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemCT_Click(sender, e);
            }
        }

        private void btnXuatExcelCT_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSChiTietDonHang";

            // Thêm dòng tiêu đề
            for (int c = 0; c < dataGridView2.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = dataGridView2.Columns[c].HeaderText;
            }

            // Thêm các dòng nội dung
            int cellRowIndex = 2;
            int cellColIndex = 1;
            for (int d = 0; d < dataGridView2.Rows.Count; d++)
            {
                for (int c = 0; c < dataGridView2.Columns.Count; c++)
                {
                    sheet.Cells[cellRowIndex, cellColIndex] = dataGridView2.Rows[d].Cells[c].Value.ToString();
                    cellColIndex++;
                }
                cellColIndex = 1;
                cellRowIndex++;
            }

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workbook.SaveAs(file.FileName);
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Danh sách đã được xuất ra tập tin Excel!", "Xuất Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDongCT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "QUẢN LÝ DƠN HÀNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column10")
            {
                if (e.Value.ToString() == "True")
                    e.Value = "Đã thanh toán";
                else
                    e.Value = "Chưa thanh toán";
            }
        }
    }
}
