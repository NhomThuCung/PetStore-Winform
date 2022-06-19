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
using DoAn_DotNet.Custom;
using DTO;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Office.Interop.Excel;



namespace DoAn_DotNet.GUI
{
    public partial class frmProduct : Form
    {
        private bool isThem = false;
        GiongBLL bllGiong = new GiongBLL();
        LoaiBLL bllLoai = new LoaiBLL();
        ThuCungBLL bllThuCung = new ThuCungBLL();
        public frmProduct()
        {
            InitializeComponent();
        }

        public void frmProduct_Load(object sender, EventArgs e)
        {
            //dt.Columns.Add("AnhTC", Type.GetType("System.Byte[]"));
            //dt.Columns.Add("TThai", Type.GetType("System.Byte[]"));
            //foreach (DataRow row in dt.Rows)
            //{

            //    row["Anh"] = File.ReadAllBytes("img\\" + row["Anh"]);
            //}
            ////foreach (DataRow row in dt.Rows)
            ////{
            ////    if (row["TrangThai"].ToString() == "True")
            ////    {
            ////        row["TrangThai"] = File.ReadAllBytes("\\HocTap\\HK6\\QuanLyThuCung\\DoAn_DotNet\\Images\\edit-16.png");
            ////    }
            ////    else
            ////    {
            ////        row["TrangThai"] = File.ReadAllBytes("\\HocTap\\HK6\\QuanLyThuCung\\DoAn_DotNet\\Images\\error-16.png");
            ////    }

            ////}
            //guna2DataGridView1.DataSource = dt;
            pnTabThongTin.Visible = false;
            loadDanhSachThuCung();
            
        }

        public void loadDanhSachThuCung()
        {
            guna2ShadowPanel5.Controls.Clear();

            System.Data.DataTable dt = bllThuCung.DanhSach();
            Category[] listitem = new Category[dt.Rows.Count];
            for (int i = 0; i < listitem.Length; i++)
            {
                listitem[i] = new Category();
                listitem[i].MaTC = Convert.ToInt32(dt.Rows[i][0].ToString());
                listitem[i].Dock = DockStyle.Top;
                if (dt.Rows[i][4].ToString() == "NULL")
                {
                    listitem[i].Anh = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\cho.png");
                }
                listitem[i].Anh = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dt.Rows[i][4].ToString() + "");
                listitem[i].TenTC = dt.Rows[i][1].ToString();
                listitem[i].MoTa = dt.Rows[i][3].ToString();
                listitem[i].GiaBan = Convert.ToDecimal(dt.Rows[i][2].ToString());
                listitem[i].TrangThai = Convert.ToInt32(dt.Rows[i][10].ToString());
                guna2ShadowPanel5.Controls.Add(listitem[i]);
                listitem[i].Click += new EventHandler(this.onclick);
            }
        }

        void onclick(object sender, EventArgs e)
        {
            Category cate = (Category)sender;

            //Gọi panel ra
            pnTabThongTin.Visible = true;
            //guna2Transition1.HideSync(guna2ShadowPanel2);
            //guna2Transition1.ShowSync(guna2ShadowPanel2);

            System.Data.DataTable dt = bllThuCung.DanhSachTCTheoMa(cate.MaTC);

            BatTat(false);
            BatTatCustom(true);
            if (dt.Rows[0][4].ToString() == "NULL")
            {
                pic_TC.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\cho.png");
            }
            pic_TC.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dt.Rows[0][4].ToString() + "");
            txtMaTC.Text = dt.Rows[0][0].ToString();
            txtTenTC.Text = dt.Rows[0][1].ToString();
            txtGiaBan.Text = dt.Rows[0][2].ToString();
            txtMoTa.Text = dt.Rows[0][3].ToString();
            txtAnh.Text = dt.Rows[0][4].ToString();
            txtNgayTao.Text = dt.Rows[0][5].ToString();
            txtNgayCapNhat.Text = dt.Rows[0][6].ToString();
            txtNgayBan.Text = dt.Rows[0][7].ToString();
            txtMaGiong.Text = dt.Rows[0][8].ToString();
            txtMaLoai.Text = dt.Rows[0][9].ToString();
            txtTrangThai.Text = dt.Rows[0][10].ToString();

            pic_Test.Image = null;
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\img\\" + dt.Rows[0][0].ToString() + ""))
            {
                pic_Test.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dt.Rows[0][0].ToString() + "");
            }
            

            //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("vi-vn");
            //decimal value = decimal.Parse(txtGiaBan.Text, System.Globalization.NumberStyles.AllowThousands);
            //txtGiaBan.Text = String.Format(culture, "{0:C0}", value);
        }


        public void BatTat(bool tt)
        {
            btnThemAnh.Enabled = tt;
            btnLuu.Enabled = tt;
            btnHuy.Enabled = tt;
            btnXoa.Enabled = !tt;
            btnSua.Enabled = !tt;
            txtTenTC.Enabled = tt;
            txtGiaBan.Enabled = tt;
            txtMoTa.Enabled = tt;
            txtNgayTao.Enabled = tt;
            txtNgayCapNhat.Enabled = tt;

            dtpNgayTao.Visible = tt;
            dtpNgayCN.Visible = tt;

            txtMaGiong.Enabled = tt;
            txtMaLoai.Enabled = tt;
            cboMaGiong.Visible = tt;
            cboMaLoai.Visible = tt;

            dtpNgayCN.Enabled = !tt;
            dtpNgayTao.Enabled = !tt;

            txtTrangThai.Enabled = tt;
        }
        public void BatTatCustom(bool tt)
        {
            txtNgayTao.Visible = tt;
            txtNgayCapNhat.Visible = tt;

            txtMaGiong.Visible = tt;
            txtMaLoai.Visible = tt;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            BatTatCustom(false);
            isThem = false;

            dtpNgayTao.Value = Convert.ToDateTime(txtNgayTao.Text);

            cboMaLoai.DataSource = bllLoai.LoadCboLoai(Convert.ToInt32(txtMaLoai.Text));
            cboMaLoai.ValueMember = "MaLoai";
            cboMaLoai.DisplayMember = "TenLoai";

            cboMaGiong.DataSource = bllGiong.DanhSach(Convert.ToInt32(txtMaGiong.Text));
            cboMaGiong.ValueMember = "MaGiong";
            cboMaGiong.DisplayMember = "TenGiong";
        }

        private void cboMaLoai_DropDownClosed(object sender, EventArgs e)
        {
            cboMaGiong.DataSource = bllGiong.LoadCboGiong(Convert.ToInt32(cboMaLoai.SelectedValue.ToString()));
            cboMaGiong.ValueMember = "MaGiong";
            cboMaGiong.DisplayMember = "TenGiong";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenTC.Text.Trim() == "")
                MessageBox.Show("Tên thú cưng không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtGiaBan.Text.Trim() == "")
                MessageBox.Show("Giá bán không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtAnh.Text.Trim() == "")
                MessageBox.Show("Vui lòng nhập chọn ảnh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboMaLoai.Text.Trim() == "")
                MessageBox.Show("Vui lòng chọn loài!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboMaGiong.Text.Trim() == "")
                MessageBox.Show("Vui lòng chọn giống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtMoTa.Text.Trim() == "")
                MessageBox.Show("Mô Tả không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (MessageBox.Show("Bạn có muốn lưu " + txtTenTC.Text + " không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ThuCungDTO info = new ThuCungDTO();
                string url = txtAnh.Text;
                
                info.TenTC = txtTenTC.Text;
                info.GiaBan = Convert.ToDecimal(txtGiaBan.Text);
                info.MoTa = txtMoTa.Text;
                info.Anh = url;
                info.CreateDate = dtpNgayTao.Value;
                info.NgayCapNhat = dtpNgayCN.Value;
                info.MaLoai = Convert.ToInt32(cboMaLoai.SelectedValue);
                info.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue);
                info.TrangThai = 0;
                
                if (isThem)
                {
                    //InsertThuCungLinq
                    if (bllThuCung.ThemLinq(info.TenTC, info.GiaBan, info.MoTa, info.Anh, info.CreateDate, info.NgayCapNhat, info.MaGiong, info.MaLoai, info.TrangThai) == true)
                    {
                        int ma = Convert.ToInt32(bllThuCung.DanhSachTCTheoMa().Rows[0][0].ToString());
                        //Thêm qrcode()
                        QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                        var mydata = QG.CreateQrCode(ma.ToString(), QRCoder.QRCodeGenerator.ECCLevel.H);
                        var code = new QRCoder.QRCode(mydata);
                        Bitmap qrcode = code.GetGraphic(50);

                        luuAnhQRCODE(qrcode, ma.ToString());

                        MessageBox.Show("Thêm thú cưng thành công!", "Thêm thú cưng", MessageBoxButtons.OK);
                        luuHinhAnh(url);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thú cưng thất bại!", "Thêm thú cưng", MessageBoxButtons.OK);
                    }
                    //txtGiaBan.DataBindings[0].FormattingEnabled = true;
                    
                }
                else
                {
                    info.MaTC = Convert.ToInt32(txtMaTC.Text);
                    if (bllThuCung.UpdateLinq(info.MaTC, info.TenTC, info.GiaBan, info.MoTa, info.Anh, info.CreateDate, info.NgayCapNhat, info.MaGiong, info.MaLoai, info.TrangThai) == true)
                    {
                        MessageBox.Show("Cập nhập thú cưng thành công!", "Cập nhập thú cưng", MessageBoxButtons.OK);
                        luuHinhAnh(url);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhập thú cưng thất bại!", "Cập nhập thú cưng", MessageBoxButtons.OK);
                    }
                    //txtGiaBan.DataBindings[0].FormattingEnabled = true;
                    
                }
                // Tải lại lưới
                frmProduct_Load(sender, e);
            }
        }

        public void luuAnhQRCODE(Bitmap hinh, string tenFile)
        {
            bool kt = File.Exists(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile);
            if (kt == false)
                hinh.Save(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile, ImageFormat.Jpeg);
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            nhapHinhAnh();
        }

        public void anhDefault(string tenFile)
        {
            pic_TC.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile);
            txtAnh.Text = tenFile;
        }

        public void luuHinhAnh(string tenFile)
        {
            bool kt = File.Exists(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile);
            if (kt == false)
                pic_TC.Image.Save(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile, ImageFormat.Png);
        }
        public void nhapHinhAnh()
        {
            //BMP, GIF, JPEG, EXIF, PNG và TIFF, ICO...
            openFileDialog1.Filter = "All Image (*.jpg)|*.jpg|All Image (*.png)|*.png|All Image (*.gif)|*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pic_TC.Image = Image.FromFile(openFileDialog1.FileName.ToString());

                string[] name = openFileDialog1.FileName.Split('\\');
                string tenFile = name[name.Length - 1].ToString().Trim();

                txtAnh.Text = tenFile;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
            BatTatCustom(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;

            BatTat(true);
            BatTatCustom(false);

            pic_TC.Image = null;
            txtMaTC.Text = "";
            txtTenTC.Text = "";
            txtGiaBan.Text = "";
            txtAnh.Text = "";
            txtNgayBan.Text = "";
            txtTrangThai.Text = "0";
            txtMoTa.Text = "";

            dtpNgayCN.Value = DateTime.Now;
            dtpNgayTao.Value = DateTime.Now;

            cboMaLoai.DataSource = bllLoai.DanhSach();
            cboMaLoai.ValueMember = "MaLoai";
            cboMaLoai.DisplayMember = "TenLoai";

            pnTabThongTin.Visible = true;


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá thú cưng " + txtTenTC.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (bllThuCung.XoaLinq(Convert.ToInt32(txtMaTC.Text)) == true)
                {
                    MessageBox.Show("Xoá thú cưng thành công", "Xoá thú cưng", MessageBoxButtons.OK);
                    // Tải lại lưới
                    frmProduct_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xoá thú cưng thất bại", "Xoá thú cưng", MessageBoxButtons.OK);
                }
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    ThuCungBLL thuBLL = new ThuCungBLL();
                    ThuCungDTO tc = new ThuCungDTO();
                    tc.MaTC = Convert.ToInt32(sheet.Cells[cellRowIndex, 1].Value);
                    tc.TenTC = sheet.Cells[cellRowIndex, 2].Value;
                    tc.GiaBan = Convert.ToDecimal(sheet.Cells[cellRowIndex, 3].Value);
                    tc.MoTa = sheet.Cells[cellRowIndex, 4].Value;
                    tc.Anh = sheet.Cells[cellRowIndex, 5].Value;
                    tc.CreateDate = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 6].Value));
                    tc.NgayCapNhat = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 7].Value));
                    tc.NgayBan = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 8].Value));
                    tc.MaLoai = Convert.ToInt32(sheet.Cells[cellRowIndex, 9].Value);
                    tc.MaGiong = Convert.ToInt32(sheet.Cells[cellRowIndex, 10].Value);
                    tc.TrangThai = Convert.ToInt32(sheet.Cells[cellRowIndex, 11].Value);

                    thuBLL.Them(tc);
                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmProduct_Load(sender, e);
                MessageBox.Show("Đã nhập thành công dữ liệu từ tập tin Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DataGridView dt = new DataGridView();
            dt.DataSource = bllThuCung.DanhSach();

            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSThuCung";

            // Thêm dòng tiêu đề
            for (int c = 0; c < dt.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = dt.Columns[c].HeaderText;
            }

            // Thêm các dòng nội dung
            int cellRowIndex = 2;
            int cellColIndex = 1;
            for (int d = 0; d < dt.Rows.Count; d++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    sheet.Cells[cellRowIndex, cellColIndex] = dt.Rows[d].Cells[c].Value.ToString();
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

        private void txtTimKiem_IconLeftClick(object sender, EventArgs e)
        {
            guna2ShadowPanel5.Controls.Clear();

            System.Data.DataTable dt = bllThuCung.DanhSachTCTheoMaTen(txtTimKiem.Text);
            Category[] listitem = new Category[dt.Rows.Count];
            for (int i = 0; i < listitem.Length; i++)
            {
                listitem[i] = new Category();
                listitem[i].MaTC = Convert.ToInt32(dt.Rows[i][0].ToString());
                listitem[i].Dock = DockStyle.Top;
                listitem[i].Anh = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dt.Rows[i][4].ToString() + "");
                listitem[i].TenTC = dt.Rows[i][1].ToString();
                listitem[i].MoTa = dt.Rows[i][3].ToString();
                listitem[i].GiaBan = Convert.ToDecimal(dt.Rows[i][2].ToString());
                listitem[i].TrangThai = Convert.ToInt32(dt.Rows[i][10].ToString());
                guna2ShadowPanel5.Controls.Add(listitem[i]);
                listitem[i].Click += new EventHandler(this.onclick);
            }
        }

        private void btnDongTab_Click(object sender, EventArgs e)
        {
            pnTabThongTin.Visible = false;
        }
    }

}
