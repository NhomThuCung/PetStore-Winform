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
using System.IO;
using System.Drawing.Imaging;

namespace DoAn_DotNet.GUI
{
    public partial class frmQLThuCung : Form
    {
        private bool isThem = false;
        private string maTC = ""; // Mã Thú Cưng cũ
        ThuCungBLL tcBLL = new ThuCungBLL();


        public frmQLThuCung()
        {
            InitializeComponent();
        }

        private void frmQLThuCung_Load(object sender, EventArgs e)
        {
            BatTat(false);
            dataGridView1.AutoGenerateColumns = false;

            //Load cbo
            tcBLL.HienThiVaoComboBox(cboMaLoai, cboMaGiong);

            //Load bảng thú cưng
            tcBLL.HienThiVaoDGV2(bN, dataGridView1, cboMaLoai, cboMaGiong,
                                txtMaTC, txtTenTC, txtGiaBan,
                                txtAnh, dtpNgayThem, 
                                chkMoi, txtMoTa, "");
            dataGridView1.Columns["Column3"].DefaultCellStyle.Format = "c0";
        }

        public void BatTat(bool tt)
        {
            cboMaLoai.Enabled = tt;
            cboMaGiong.Enabled = tt;
            txtMaTC.Enabled = tt;
            txtTenTC.Enabled = tt;
            txtAnh.Enabled = tt;
            txtGiaBan.Enabled = tt;
            txtMoTa.Enabled = tt;
            numSoLuongTon.Enabled = tt;
            dtpNgayThem.Enabled = tt;
            chkMoi.Enabled = tt;

            btnLuu.Enabled = tt;
            btnHuy.Enabled = tt;
            btnThemAnh.Enabled = tt;

            btnThem.Enabled = !tt;
            btnSua.Enabled = !tt;
            btnXoa.Enabled = !tt;
        }

        public void nhapHinhAnh()
        {
            //BMP, GIF, JPEG, EXIF, PNG và TIFF, ICO...
            openFileDialog1.Filter = "All Image (*.jpg)|*.jpg|All Image (*.png)|*.png|All Image (*.gif)|*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picThuCung.Image = Image.FromFile(openFileDialog1.FileName.ToString());

                string[] name = openFileDialog1.FileName.Split('\\');
                string tenFile = name[name.Length - 1].ToString().Trim();

                txtAnh.Text = tenFile;
            }
        }

        public void luuHinhAnh(string tenFile)
        {
            bool kt = File.Exists(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile);
            if (kt == false)
                picThuCung.Image.Save(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile, ImageFormat.Png);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtMaTC.Enabled = false;
            dtpNgayThem.Enabled = false;
            txtAnh.Enabled = false;
            txtMaTC.Text = "";
            txtTenTC.Text = "";
            txtAnh.Text = "";
            txtGiaBan.Text = "";
            numSoLuongTon.Value = 0;
            chkMoi.Checked = false;
            cboMaLoai.SelectedIndex = 0;
            cboMaGiong.SelectedIndex = 0;
            dtpNgayThem.Value = DateTime.Now;
            txtMoTa.Text = "";

            txtTenTC.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maTC = txtMaTC.Text;
            txtMaTC.Enabled = false;
            txtAnh.Enabled = false;
            txtGiaBan.DataBindings[0].FormattingEnabled = false;

            txtTenTC.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá thú cưng " + txtTenTC.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ThuCungDTO info = new ThuCungDTO();
                info.MaTC = Convert.ToInt32(txtMaTC.Text);
                tcBLL.Xoa(info);
            }

            // Tải lại lưới
            frmQLThuCung_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
            txtGiaBan.DataBindings[0].FormattingEnabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboMaLoai.Text.Trim() == "")
                MessageBox.Show("Chưa chọn loài!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboMaGiong.Text.Trim() == "")
                MessageBox.Show("Chưa chọn giống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(txtTenTC.Text.Trim() == "")
                MessageBox.Show("Tên thú cưng không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtMoTa.Text.Trim() == "")
                MessageBox.Show("Mô Tả không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenTC.Text.Length > 200)
                MessageBox.Show("Tên giống không vượt quá 200 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtAnh.Text.Trim() == "")
                MessageBox.Show("Ảnh không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtGiaBan.Text.Trim() == "")
                MessageBox.Show("Giá bán không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuongTon.Value == 0)
                MessageBox.Show("Số lượng phải khác 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ThuCungDTO info = new ThuCungDTO();
                string url = txtAnh.Text;

                info.MaLoai = Convert.ToInt32(cboMaLoai.SelectedValue);
                info.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue);
                info.TenTC = txtTenTC.Text.Trim();
                info.GiaBan = Convert.ToDecimal(txtGiaBan.Text.Trim());
                info.Anh = txtAnh.Text.Trim();
                info.NgayCapNhat = dtpNgayThem.Value;
                //info.SoLuongTon = Convert.ToInt32(numSoLuongTon.Value);
                info.Moi = chkMoi.Checked ? true : false;
                info.MoTa = txtMoTa.Text.Trim();

                if (isThem)
                {

                    //InsertThuCungLinq
                    if (tcBLL.ThemLinq(info.TenTC, info.GiaBan, info.MoTa, info.Anh, info.NgayCapNhat, info.MaGiong, info.MaLoai, info.Moi) == true)
                    {
                        MessageBox.Show("Thêm thú cưng thành công", "Thêm thú cưng", MessageBoxButtons.OK);
                    }
                    

                    //tcBLL.Them(info);
                    //MessageBox.Show("Thêm thú cưng thành công", "Thêm thú cưng", MessageBoxButtons.OK);
                    txtGiaBan.DataBindings[0].FormattingEnabled = true;
                    luuHinhAnh(url);
                }
                else
                {
                    tcBLL.Sua(info, Convert.ToInt32(maTC));
                    MessageBox.Show("Sửa thú cưng thành công", "Sửa thú cưng", MessageBoxButtons.OK);
                    txtGiaBan.DataBindings[0].FormattingEnabled = true;
                    luuHinhAnh(url);
                }

                // Tải lại lưới
                frmQLThuCung_Load(sender, e);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmQLThuCung_Load(sender, e);
            MessageBox.Show("Load bảng thú cưng thành công", "Load Bảng Thú Cưng");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            tcBLL.HienThiVaoDGV2(bN, dataGridView1, cboMaLoai, cboMaGiong,
                    txtMaTC, txtTenTC, txtGiaBan,
                    txtAnh, dtpNgayThem,
                    chkMoi, txtMoTa, txtTuKhoa.Text);
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
                    ThuCungBLL thuBLL = new ThuCungBLL();
                    ThuCungDTO tc = new ThuCungDTO();
                    tc.MaTC = Convert.ToInt32(sheet.Cells[cellRowIndex, 1].Value);
                    tc.TenTC = sheet.Cells[cellRowIndex, 2].Value;
                    tc.GiaBan = Convert.ToDecimal(sheet.Cells[cellRowIndex, 3].Value);
                    tc.NgayCapNhat = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 4].Value));
                    //tc.SoLuongTon = Convert.ToInt32(sheet.Cells[cellRowIndex, 5].Value);
                    tc.MaLoai = Convert.ToInt32(sheet.Cells[cellRowIndex, 5].Value);
                    tc.MaGiong = Convert.ToInt32(sheet.Cells[cellRowIndex, 6].Value);
                    tc.Moi = sheet.Cells[cellRowIndex, 7].Value;
                    tc.Anh = sheet.Cells[cellRowIndex, 8].Value;
                    tc.MoTa = sheet.Cells[cellRowIndex, 9].Value;

                    thuBLL.Them(tc);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmQLThuCung_Load(sender, e);
                MessageBox.Show("Đã nhập thành công dữ liệu từ tập tin Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSThuCung";

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
            if (MessageBox.Show("Bạn có muốn đóng không ?", "QUẢN LÝ THÚ CƯNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column8")
            {
                if (e.Value.ToString() == "True")
                    e.Value = "Đã bán";
                else
                    e.Value = "Chưa bán";
            }
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            nhapHinhAnh();
        }

        public void anhDefault(string tenFile)
        {
           picThuCung.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile);
            txtAnh.Text = tenFile;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridView1.CurrentRow.Selected = true;
            bool ktFileTonTai = File.Exists(System.Windows.Forms.Application.StartupPath + "\\img\\" + dataGridView1.Rows[e.RowIndex].Cells["Column9"].FormattedValue.ToString());
            if (ktFileTonTai == true)
            {
                picThuCung.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dataGridView1.Rows[e.RowIndex].Cells["Column9"].FormattedValue.ToString() + "");
            }
            else
                anhDefault("cho.png");
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
