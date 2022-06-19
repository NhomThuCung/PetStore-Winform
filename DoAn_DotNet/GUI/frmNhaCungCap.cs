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
using System.Text.RegularExpressions;
using System.Globalization;

namespace DoAn_DotNet.GUI
{
    public partial class frmNhaCungCap : Form
    {
        private bool isThem = false;
        private string maNCC = ""; // Mã NCC cũ
        NhaCungCapBLL NCCbll = new NhaCungCapBLL();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            BatTat(false);
            dataGridView1.AutoGenerateColumns = false;
            NCCbll.HienThiVaoDGV(bN, dataGridView1, txtMaNCC, txtTenNCC, txtEmail, txtSDT, txtDiaChi,"");
        }

        public void BatTat(bool tt)
        {

            txtMaNCC.Enabled = tt;
            txtTenNCC.Enabled = tt;
            txtEmail.Enabled = tt;
            txtSDT.Enabled = tt;
            txtDiaChi.Enabled = tt;

            btnLuu.Enabled = tt;
            btnHuy.Enabled = tt;

            dataGridView1.Enabled = !tt;
            btnThem.Enabled = !tt;
            btnSua.Enabled = !tt;
            btnXoa.Enabled = !tt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtMaNCC.Enabled = false;
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTenNCC.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maNCC = txtMaNCC.Text;
            txtMaNCC.Enabled = false;


            txtTenNCC.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp " + txtTenNCC.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NCCbll.XoaLinq(Convert.ToInt32(txtMaNCC.Text)))
                {
                    MessageBox.Show("Xoá nhà cung cấp thành công", "Xoá", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Xoá nhà cung cấp không thành công", "Lỗi", MessageBoxButtons.OK);

                }
            }

            // Tải lại lưới
            frmNhaCungCap_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
        }

        private bool IsValidEmail(string eMail)
        {
            if (string.IsNullOrWhiteSpace(eMail))
                return false;

            try
            {
                //Đọc tên miền email
                eMail = Regex.Replace(eMail, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                //Kiểm tra miền của email và chuẩn hoá nó
                string DomainMapper(Match match)
                {
                    // Sử dụng lớp IdnMapping để chuyển đổi tên miền Unicode.
                    var idn = new IdnMapping();
                    // Kéo ra và xử lý tên miền (ném ArgumentException vào không hợp lệ)
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(eMail,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text.Trim() == "")
                MessageBox.Show("Tên nhà cung cấp không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenNCC.Text.Length > 200)
                MessageBox.Show("Tên nhà cung cấp không vượt quá 200 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDiaChi.Text.Trim() == "")
                MessageBox.Show("Địa chỉ không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (IsValidEmail(txtEmail.Text) == false)
                MessageBox.Show("Email không đúng định dạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtEmail.Text.Trim() == "")
                MessageBox.Show("Email không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtSDT.Text.Trim() == "")
                MessageBox.Show("Số điện thoại không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtSDT.Text.Length > 15)
                MessageBox.Show("Số điện thoại không vượt quá 15 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (isThem)
                {
                    if (NCCbll.ThemLinq(txtTenNCC.Text, txtSDT.Text, txtEmail.Text, txtDiaChi.Text))
                    {
                        MessageBox.Show("Thêm nhà cung cấp thành công", "Thêm Nhà Cung Cấp", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    if (NCCbll.UpdateLinq(Convert.ToInt32(maNCC), txtTenNCC.Text, txtSDT.Text, txtEmail.Text, txtDiaChi.Text))
                    {
                        MessageBox.Show("Cập nhật nhà cung cấp thành công", "Cập nhật nhà Cung Cấp", MessageBoxButtons.OK);
                    }
                }

                // Tải lại lưới
                frmNhaCungCap_Load(sender, e);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            // Tải lại lưới
            frmNhaCungCap_Load(sender, e);
            MessageBox.Show("Load bảng nhà cung cấp thành công", "Load Bảng nhà cung cấp");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            NCCbll.HienThiVaoDGV(bN, dataGridView1, txtMaNCC, txtTenNCC, txtEmail, txtSDT, txtDiaChi, txtTuKhoa.Text);
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
                    NhaCungCapBLL nccBLL = new NhaCungCapBLL();
                    NhaCungCapDTO ncc = new NhaCungCapDTO();
                    ncc.MaNCC = Convert.ToInt32(sheet.Cells[cellRowIndex, 1].Value);
                    ncc.TenNCC = sheet.Cells[cellRowIndex, 2].Value;
                    ncc.Phone = sheet.Cells[cellRowIndex, 3].Value.ToString();
                    ncc.Email = sheet.Cells[cellRowIndex, 4].Value;
                    ncc.Address = sheet.Cells[cellRowIndex, 5].Value;
                    

                    nccBLL.Them(ncc);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmNhaCungCap_Load(sender, e);
                MessageBox.Show("Đã nhập thành công dữ liệu từ tập tin Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSNhaCungCap";

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

        private void txtTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
