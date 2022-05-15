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

namespace DoAn_DotNet.GUI
{
    public partial class frmQLUserAdmin : Form
    {
        private bool isThem = false;
        private bool isThemQuyen = false;
        private string maNV = ""; // Mã nhân viên cũ
        UserAdminBLL userBLL = new UserAdminBLL();

        private string maQuyen = ""; // Mã Quyền cũ
        PhanQuyenBLL pBLL = new PhanQuyenBLL();
        public frmQLUserAdmin()
        {
            InitializeComponent();
        }

        private void frmUserAdmin_Load(object sender, EventArgs e)
        {
            BatTat(false);
            BatTatQuyen(false);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            //load cbo
            userBLL.HienThiVaoComboBox(cboMaQuyen);
            //load bảng User
            userBLL.HienThiVaoDGV(bN, dataGridView1, txtID, txtTaiKhoan, txtMatKhau, txtHoTen, txtCMND, dtpNgaySinh, dtpNgayTao, txtDiaChi, txtEmail, txtDienThoai, cboMaQuyen, txtTienLuong, "");
            dataGridView1.Columns["Column12"].DefaultCellStyle.Format = "c0";
            //load bảng phân quyền
            pBLL.HienThiVaoDGV(bN1, dataGridView2, txtMaQuyen, txtTenQuyen, "");
        }
        public void BatTat(bool tt)
        {

            txtID.Enabled = tt;
            txtHoTen.Enabled = tt;
            txtTaiKhoan.Enabled = tt;
            txtMatKhau.Enabled = tt;
            dtpNgayTao.Enabled = tt;
            dtpNgaySinh.Enabled = tt;
            txtEmail.Enabled = tt;
            txtDienThoai.Enabled = tt;
            txtDiaChi.Enabled = tt;
            txtTienLuong.Enabled = tt;
            txtMaQuyen.Enabled = tt;
            txtCMND.Enabled = tt;
            cboMaQuyen.Enabled = tt;

            btnLuu.Enabled = tt;
            btnHuy.Enabled = tt;

            btnThem.Enabled = !tt;
            btnSua.Enabled = !tt;
            btnXoa.Enabled = !tt;
        }

        public void BatTatQuyen(bool tt)
        {

            txtMaQuyen.Enabled = tt;
            txtTenQuyen.Enabled = tt;

            btnLuuQuyen.Enabled = tt;
            btnHuyQuyen.Enabled = tt;

            btnThemQuyen.Enabled = !tt;
            btnSuaQuyen.Enabled = !tt;
            btnXoaQuyen.Enabled = !tt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtID.Enabled = false;
            txtID.Text = "";
            dtpNgayTao.Enabled = false;

            txtHoTen.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtCMND.Text = "";
            dtpNgayTao.Value = DateTime.Now;
            dtpNgaySinh.Value = DateTime.Now;
            txtEmail.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtTienLuong.Text = "3000000";
            cboMaQuyen.SelectedIndex = 0;


            txtHoTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maNV = txtID.Text;
            txtID.Enabled = false;
            dtpNgayTao.Enabled = false;

            txtTienLuong.DataBindings[0].FormattingEnabled = false;

            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa user " + txtHoTen.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                UserAdmin info = new UserAdmin();
                info.Id = Convert.ToInt32(txtID.Text);
                userBLL.Xoa(info);
                MessageBox.Show("Xoá khách user công", "Xoá", MessageBoxButtons.OK);
            }

            // Tải lại lưới
            frmUserAdmin_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
            txtTienLuong.DataBindings[0].FormattingEnabled = true;
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
            if (txtHoTen.Text.Trim() == "")
                MessageBox.Show("Tên user không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtHoTen.Text.Length > 50)
                MessageBox.Show("Tên user không vượt quá 50 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTaiKhoan.Text.Trim() == "")
                MessageBox.Show("Tài khoản không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtMatKhau.Text.Length < 8)
                MessageBox.Show("Mật khẩu phải từ 8 ký tự trở lên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDiaChi.Text.Trim() == "")
                MessageBox.Show("Địa chỉ không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (IsValidEmail(txtEmail.Text) == false)
                MessageBox.Show("Email không đúng định dạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDienThoai.Text.Trim() == "")
                MessageBox.Show("Số điện thoại không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDienThoai.Text.Length < 9 || txtDienThoai.Text.Length > 15)
                MessageBox.Show("Số điện thoại phải từ 10 đến 14 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtCMND.Text.Length > 15)
                MessageBox.Show("Số CMND không vượt quá 15 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtCMND.Text.Trim() == "")
                MessageBox.Show("Số CMND không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboMaQuyen.Text.Trim() == "")
                MessageBox.Show("Bạn chưa chọn quyền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                UserAdmin info = new UserAdmin();
                UserAdminBLL tk = new UserAdminBLL();
                string encrypt_pass = Encrypt.Instance.MD5Encrypt(txtMatKhau.Text);

                info.HoTen = txtHoTen.Text.Trim();
                info.UserName = txtTaiKhoan.Text.Trim();
                info.Password = encrypt_pass;
                info.NgaySinh = dtpNgaySinh.Value;
                info.Cmnd = txtCMND.Text.Trim();
                info.CreateDate = dtpNgayTao.Value;
                info.Email = txtEmail.Text.Trim();
                info.Phone = txtDienThoai.Text.Trim();
                info.MaQuyen = Convert.ToInt32(cboMaQuyen.SelectedValue);
                info.DiaChi = txtDiaChi.Text.Trim();
                info.TienLuong = Convert.ToDecimal(txtTienLuong.Text);

                if (isThem)
                {
                    userBLL.Them(info);
                    MessageBox.Show("Thêm user thành công", "Thêm User", MessageBoxButtons.OK);
                    txtTienLuong.DataBindings[0].FormattingEnabled = true;
                }
                else
                {
                    userBLL.Sua(info, Convert.ToInt32(maNV));
                    MessageBox.Show("Sửa user thành công", "Sửa User", MessageBoxButtons.OK);
                    txtTienLuong.DataBindings[0].FormattingEnabled = true;
                }

                // Tải lại lưới
                frmUserAdmin_Load(sender, e);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmUserAdmin_Load(sender, e);
            MessageBox.Show("Load bảng user thành công", "Load Bảng user");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            userBLL.HienThiVaoDGV(bN, dataGridView1, txtID, txtTaiKhoan, txtMatKhau, txtHoTen, txtCMND, dtpNgaySinh, dtpNgayTao, txtDiaChi, txtEmail, txtDienThoai, cboMaQuyen, txtTienLuong, txtTuKhoa.Text);
        }

        private void txtTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _Application excel = new Microsoft.Office.Interop.Excel.Application();
                _Workbook workbook = excel.Workbooks.Open(file.FileName);
                _Worksheet sheet = workbook.ActiveSheet;

                // Dòng bắt đầu là dòng 2 (trừ tiêu đề)
                int cellRowIndex = 2;
                do
                {
                    UserAdminBLL uaBLL = new UserAdminBLL();
                    UserAdmin ua = new UserAdmin();
                    ua.Id = Convert.ToInt32(sheet.Cells[cellRowIndex, 1].Value);
                    ua.UserName = sheet.Cells[cellRowIndex, 2].Value;
                    ua.Password = sheet.Cells[cellRowIndex, 3].Value;
                    ua.HoTen = sheet.Cells[cellRowIndex, 4].Value;
                    ua.Cmnd = sheet.Cells[cellRowIndex, 5].Value.ToString();
                    ua.NgaySinh = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 6].Value));
                    ua.DiaChi = sheet.Cells[cellRowIndex, 7].Value;
                    ua.Email = sheet.Cells[cellRowIndex, 8].Value;
                    ua.Phone = sheet.Cells[cellRowIndex, 9].Value.ToString();
                    ua.CreateDate = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 10].Value));
                    ua.MaQuyen = Convert.ToInt32(sheet.Cells[cellRowIndex, 11].Value);
                    ua.TienLuong = Convert.ToDecimal(sheet.Cells[cellRowIndex, 12].Value);

                    uaBLL.Them(ua);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmUserAdmin_Load(sender, e);
                MessageBox.Show("Đã nhập thành công dữ liệu từ tập tin Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSUserAdmin";

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
                MessageBox.Show("Danh sách đã được xuất ra tập tin Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "QUẢN LÝ USER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        //Bảng phân quyền============================================

        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            BatTatQuyen(true);
            isThemQuyen = true;
            txtMaQuyen.Enabled = false;
            txtMaQuyen.Text = "";
            txtTenQuyen.Text = "";

            txtTenQuyen.Focus();
        }

        private void btnSuaQuyen_Click(object sender, EventArgs e)
        {
            BatTatQuyen(true);
            isThemQuyen = false;
            maQuyen = txtMaQuyen.Text;
            txtMaQuyen.Enabled = false;
            txtTenQuyen.Focus();
        }

        private void btnXoaQuyen_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá quyền " + txtTenQuyen.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                PhanQuyen info = new PhanQuyen();
                info.MaQuyen = Convert.ToInt32(txtMaQuyen.Text);
                pBLL.Xoa(info);
                MessageBox.Show("Xoá quyền thành công", "Xoá Quyền", MessageBoxButtons.OK);
            }

            // Tải lại lưới
            frmUserAdmin_Load(sender, e);
        }

        private void btnHuyQuyen_Click(object sender, EventArgs e)
        {
            BatTatQuyen(false);
        }

        private void btnLuuQuyen_Click(object sender, EventArgs e)
        {
            if (txtTenQuyen.Text.Trim() == "")
                MessageBox.Show("Bạn chưa nhập tên quyền", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                PhanQuyen info = new PhanQuyen();
                info.TenQuyen = txtTenQuyen.Text.Trim();

                if (isThemQuyen)
                {
                    pBLL.Them(info);
                    MessageBox.Show("Thêm quyền thành công", "Thêm Quyền", MessageBoxButtons.OK);
                }
                else
                {
                    pBLL.Sua(info, Convert.ToInt32(maQuyen));
                    MessageBox.Show("Sửa quyền thành công", "Sửa Quyền", MessageBoxButtons.OK);
                }


                // Tải lại lưới
                frmUserAdmin_Load(sender, e);
            }
        }

        private void btnTaiLaiQuyen_Click(object sender, EventArgs e)
        {
            frmUserAdmin_Load(sender, e);
            MessageBox.Show("Load bảng quyền thành công", "Load Bảng Quyền", MessageBoxButtons.OK);
        }

        private void btnTimKiemQuyen_Click(object sender, EventArgs e)
        {
            pBLL.HienThiVaoDGV(bN1, dataGridView2, txtMaQuyen, txtTenQuyen, txtTuKhoaQuyen.Text);
        }

        private void txtTuKhoaQuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemQuyen_Click(sender, e);
            }
        }

        private void btnNhapExcelQuyen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _Application excel = new Microsoft.Office.Interop.Excel.Application();
                _Workbook workbook = excel.Workbooks.Open(file.FileName);
                _Worksheet sheet = workbook.ActiveSheet;

                // Dòng bắt đầu là dòng 2 (trừ tiêu đề)
                int cellRowIndex = 2;
                do
                {
                    PhanQuyenBLL quyenBLL = new PhanQuyenBLL();
                    PhanQuyen quyen = new PhanQuyen();
                    quyen.MaQuyen = Convert.ToInt32(sheet.Cells[cellRowIndex, 1].Value);
                    quyen.TenQuyen = sheet.Cells[cellRowIndex, 2].Value;

                    quyenBLL.Them(quyen);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmUserAdmin_Load(sender, e);
                MessageBox.Show("Đã nhập thành công dữ liệu từ tập tin Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatExcelQuyen_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSPhanQuyen";

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
                MessageBox.Show("Danh sách đã được xuất ra tập tin Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDongQuyen_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "QUẢN LÝ USER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column11")
            {
                if (e.Value.ToString() == "1")
                    e.Value = "Quản Lý";
                else
                    e.Value = "Nhân Viên";
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column3")
            {
                e.Value = "••••••••••";
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
