using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL;
using BLL;

namespace DoAn_DotNet.GUI
{
    public partial class frmSell : Form
    {
        ChiTietDonHangBLL bllCTDH = new ChiTietDonHangBLL();
        ThuCungDAO tc = new ThuCungDAO();
        KhachHangBLL bllKhachHang = new KhachHangBLL();
        DonHangBLL bllDonHang = new DonHangBLL();
        LoaiBLL bllLoai = new LoaiBLL();
        GiongBLL bllGiong = new GiongBLL();
        string anh = "";
        string ma = "";
        decimal giaBan = 0;
        int maNV = UserAdminBLL.frmDonHangmaNV;
        frmKhachHang fKH = null;
        DonHangBLL dhBLL = new DonHangBLL();
        DataTable dt = new DataTable();
        int soLuongTC = 0;

        public frmSell()
        {
            InitializeComponent();
        }

        private void frmSell_Load(object sender, EventArgs e)
        {
            //Load Số Thú Cưng
            lblSoLuongTC.Text = tc.DanhSachTCSell().Rows.Count.ToString();
            //Load Time
            HienThiThoiGian();

            //Load Thú Cưng
            LoadThuCung();

            //Mã Nhân Viên
            txtMaNV.Text = maNV.ToString();

            //Đặt tên cho cột trong datagirdview
            dt.Columns.Add("MaTC", typeof(int));
            dt.Columns.Add("TenTC", typeof(String));
            dt.Columns.Add("GiaBan", typeof(Decimal));

            //Load cbo
            LoadCboThuCung();


        }

        public void LoadThuCung()
        {
            //Gọi Thú Cưng in pnBtnThuCung
            int StartY = 10;
            int x = 20;
            int y = 210;
            int StartX = 20;
            int dem = 0;
            Button[] btn = new Button[tc.DanhSachTCSell().Rows.Count];

            Button[] hinh = new Button[tc.DanhSachTCSell().Rows.Count];
            for (int i = 0; i < tc.DanhSachTCSell().Rows.Count; i++)
            {
                btn[i] = new Button();

                hinh[i] = new Button();

                anh = tc.DanhSachTCSell().Rows[i][3].ToString();
                //anh = dataGridView3.Rows[i].Cells["Column9"].FormattedValue.ToString();
                ma = tc.DanhSachTCSell().Rows[i][0].ToString();
                giaBan = Convert.ToDecimal(tc.DanhSachTCSell().Rows[i][2].ToString());
                //ma = dataGridView3.Rows[i].Cells["MaTC"].FormattedValue.ToString();
                //btn[i].BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dataGridView3.Rows[i].Cells["Column9"].FormattedValue.ToString() + "");
                btn[i].BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + anh + "");
                btn[i].BackgroundImageLayout = ImageLayout.Stretch;

                //hinh[i].BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + anh + "");
                //hinh[i].BackgroundImageLayout = ImageLayout.Stretch;

                btn[i].Size = new System.Drawing.Size(200, 200);

                hinh[i].Size = new System.Drawing.Size(200, 50);

                if (dem == 5)
                {
                    dem = 0;
                    StartY += 270;
                    StartX = 20;

                    x = 20;
                    y += 270;
                }
                btn[i].Location = new Point(StartX, StartY);

                hinh[i].Location = new Point(x, y);
                StartX += 210;

                x += 210;

                btn[i].Name = ma;
                hinh[i].Name = ma;
                string chu = "Thú Cưng " + ma + "\n Giá Bán: " + giaBan + "";
                //btn[i].Text = chu;

                hinh[i].Text = chu;
                //btn[i].ImageAlign = ContentAlignment.TopCenter;
                btn[i].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                //btn[i].TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
                hinh[i].Click += new System.EventHandler(this.btnProductPet_Click);
                btn[i].UseVisualStyleBackColor = true;
                pnBtnThuCung.Controls.Add(btn[i]);
                pnBtnThuCung.Controls.Add(hinh[i]);

                dem++;
            }
        }

        public void LoadCboThuCung()
        {
            cboLoaiTC.DataSource = bllLoai.DanhSachLinq();
            cboLoaiTC.DisplayMember = "TenLoai";
            cboLoaiTC.ValueMember = "MaLoai";

        }


        private void btnProductPet_Click(object sender, EventArgs e)
        {

            Button pic = (Button)sender;
            txtMaTC.Text = pic.Name;

            bool kt = false;
            ThuCung tc = bllDonHang.LayTCTheoMa(int.Parse(pic.Name));
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (tc.MaTC.ToString() == dataGridView1.Rows[i].Cells[0].Value.ToString())
                {
                    kt = true;
                }
            }
            if (kt == false)
            {
                dt.Rows.Add(tc.MaTC, tc.TenTC, tc.GiaBan);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Thú cưng đã được thêm vào giỏ hàng!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



            ChiTietDonHang ctdh = new ChiTietDonHang();

            ctdh.MaTC = tc.MaTC; ;
            ctdh.ThanhTien = tc.GiaBan;


            //var giohang = new List<GioHangDTO>();
            //giohang.Add(gh);
            //foreach (var item in giohang)
            //{
            //    item.MaTC = tc.MaTC.ToString(); ;
            //    item.TenTC = tc.TenTC;
            //    item.GiaBan = tc.GiaBan;
            //}


        }

        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (bllKhachHang.DsKHTheoSDT(txtSDT.Text).Rows.Count > 0)
                {
                    txtMaKH.Text = bllKhachHang.DsKHTheoSDT(txtSDT.Text).Rows[0][0].ToString();
                    txtTenKH.Text = bllKhachHang.DsKHTheoSDT(txtSDT.Text).Rows[0][1].ToString();
                    txtEmail.Text = bllKhachHang.DsKHTheoSDT(txtSDT.Text).Rows[0][2].ToString();
                    txtDiaChi.Text = bllKhachHang.DsKHTheoSDT(txtSDT.Text).Rows[0][3].ToString();
                }
                else
                {
                    MessageBox.Show("Số điện thoại khách hàng chưa có!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (fKH == null || fKH.IsDisposed)
            {
                fKH = new frmKhachHang();
                fKH.Show();
            }
            else
                fKH.Activate();
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
                DonHangDTO dh = new DonHangDTO();
                dh.Id = Convert.ToInt32(txtMaNV.Text);
                dh.CreatedDate = DateTime.Now;
                string gio = DateTime.Now.ToString();
                dh.MaKH = Convert.ToInt32(txtMaKH.Text);
                dh.NguoiNhan = txtTenKH.Text;
                dh.Email = txtEmail.Text;
                dh.SoDT = txtSDT.Text;
                dh.DiaChi = txtDiaChi.Text;
                dh.TongTien = Convert.ToDecimal(null);
                dh.Status = Convert.ToBoolean(0);


                dhBLL.Them(dh);

                //dhBLL.ThemLinq(Convert.ToInt32(txtMaNV.Text), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.000"),
                //    Convert.ToInt32(txtMaKH.Text), txtTenKH.Text, txtEmail.Text, txtSDT.Text, txtDiaChi.Text,
                //    Convert.ToDecimal(null), Convert.ToBoolean(0));

                txtDH.Text = dhBLL.DonHangSell(Convert.ToInt32(txtMaKH.Text), DateTime.Parse(gio), Convert.ToInt32(txtMaNV.Text)).Rows[0][0].ToString();
                MessageBox.Show("Thêm Thành Công", "Đơn Hàng");
                frmSell_Load(sender, e);

                //if (dataGridView3.Rows.Count == 0)
                //{
                //    BatTat(true);
                //}
                //else
                //{
                //    BatTat(true);
                //    btnXoaDon.Enabled = false;
                //    maDH = Convert.ToInt32(txtDH.Text);
                //}
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HienThiThoiGian();
        }

        private void HienThiThoiGian()
        {
            DateTime t = DateTime.Now;
            lblTime.Text = t.ToString("HH:mm:ss dd-MM-yyyy");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblGiaMax.Text = trackBar1.Value.ToString() + "0.000.000VND";
        }

        private void btnTimKiemTC_Click(object sender, EventArgs e)
        {
            int maThuCung = int.Parse(cboLoaiTC.SelectedValue.ToString());
            decimal tien = 10000000;
            decimal giaBanThuCung = trackBar1.Value * tien;
            pnBtnThuCung.Controls.Clear();
            groupBox1.Controls.Remove(lblSoLuongTC);

            if (trackBar1.Value == 0)
            {
                //Gọi Thú Cưng in pnBtnThuCung
                int StartY = 10;
                int x = 20;
                int y = 210;
                int StartX = 20;
                int dem = 0;
                soLuongTC = tc.DanhSachTCSell(maThuCung).Rows.Count;
                lblSoLuongTC.Text = soLuongTC.ToString();
                groupBox1.Controls.Add(lblSoLuongTC);
                Button[] btn = new Button[tc.DanhSachTCSell(maThuCung).Rows.Count];

                Button[] hinh = new Button[tc.DanhSachTCSell(maThuCung).Rows.Count];
                for (int i = 0; i < tc.DanhSachTCSell(maThuCung).Rows.Count; i++)
                {
                    btn[i] = new Button();

                    hinh[i] = new Button();

                    anh = tc.DanhSachTCSell(maThuCung).Rows[i][3].ToString();
                    //anh = dataGridView3.Rows[i].Cells["Column9"].FormattedValue.ToString();
                    ma = tc.DanhSachTCSell(maThuCung).Rows[i][0].ToString();
                    giaBan = Convert.ToDecimal(tc.DanhSachTCSell(maThuCung).Rows[i][2].ToString());
                    //ma = dataGridView3.Rows[i].Cells["MaTC"].FormattedValue.ToString();
                    //btn[i].BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dataGridView3.Rows[i].Cells["Column9"].FormattedValue.ToString() + "");
                    btn[i].BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + anh + "");
                    btn[i].BackgroundImageLayout = ImageLayout.Stretch;

                    //hinh[i].BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + anh + "");
                    //hinh[i].BackgroundImageLayout = ImageLayout.Stretch;

                    btn[i].Size = new System.Drawing.Size(200, 200);

                    hinh[i].Size = new System.Drawing.Size(200, 50);

                    if (dem == 5)
                    {
                        dem = 0;
                        StartY += 270;
                        StartX = 20;

                        x = 20;
                        y += 270;
                    }
                    btn[i].Location = new Point(StartX, StartY);

                    hinh[i].Location = new Point(x, y);
                    StartX += 210;

                    x += 210;

                    btn[i].Name = ma;
                    hinh[i].Name = ma;

                    string chu = "Thú Cưng " + ma + "\n Giá Bán: " + giaBan + "";
                    //btn[i].Text = chu;

                    hinh[i].Text = chu;
                    //btn[i].ImageAlign = ContentAlignment.TopCenter;
                    btn[i].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    //btn[i].TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
                    hinh[i].Click += new System.EventHandler(this.btnProductPet_Click);
                    btn[i].UseVisualStyleBackColor = true;
                    pnBtnThuCung.Controls.Add(btn[i]);
                    pnBtnThuCung.Controls.Add(hinh[i]);

                    dem++;
                }
            }
            else
            {
                //Gọi Thú Cưng in pnBtnThuCung
                int StartY = 10;
                int x = 20;
                int y = 210;
                int StartX = 20;
                int dem = 0;

                soLuongTC = tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows.Count;
                lblSoLuongTC.Text = soLuongTC.ToString();
                groupBox1.Controls.Add(lblSoLuongTC);

                Button[] btn = new Button[tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows.Count];

                Button[] hinh = new Button[tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows.Count];
                for (int i = 0; i < tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows.Count; i++)
                {
                    btn[i] = new Button();

                    hinh[i] = new Button();

                    anh = tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows[i][3].ToString();
                    //anh = dataGridView3.Rows[i].Cells["Column9"].FormattedValue.ToString();
                    ma = tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows[i][0].ToString();
                    giaBan = Convert.ToDecimal(tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows[i][2].ToString());
                    //ma = dataGridView3.Rows[i].Cells["MaTC"].FormattedValue.ToString();
                    //btn[i].BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dataGridView3.Rows[i].Cells["Column9"].FormattedValue.ToString() + "");
                    btn[i].BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + anh + "");
                    btn[i].BackgroundImageLayout = ImageLayout.Stretch;

                    //hinh[i].BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + anh + "");
                    //hinh[i].BackgroundImageLayout = ImageLayout.Stretch;

                    btn[i].Size = new System.Drawing.Size(200, 200);

                    hinh[i].Size = new System.Drawing.Size(200, 50);

                    if (dem == 5)
                    {
                        dem = 0;
                        StartY += 270;
                        StartX = 20;

                        x = 20;
                        y += 270;
                    }
                    btn[i].Location = new Point(StartX, StartY);

                    hinh[i].Location = new Point(x, y);
                    StartX += 210;

                    x += 210;

                    btn[i].Name = ma;
                    hinh[i].Name = ma;
                    string chu = "Thú Cưng " + ma + "\n Giá Bán: " + giaBan + "";
                    //btn[i].Text = chu;

                    hinh[i].Text = chu;
                    //btn[i].ImageAlign = ContentAlignment.TopCenter;
                    btn[i].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    //btn[i].TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
                    hinh[i].Click += new System.EventHandler(this.btnProductPet_Click);
                    btn[i].UseVisualStyleBackColor = true;
                    pnBtnThuCung.Controls.Add(btn[i]);
                    pnBtnThuCung.Controls.Add(hinh[i]);

                    dem++;
                }
            }

        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            if (dt.Rows.Count > int.Parse(txtMaTC.Text))
            {
                dt.Rows[int.Parse(txtMaTC.Text)].Delete();
                dt.AcceptChanges();
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng bạn muốn xoá!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridView1.CurrentRow.Selected = true;
            txtMaTC.Text = e.RowIndex.ToString();
            //txtMaTC.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenu ctx = new ContextMenu();
            MenuItem mItem = new MenuItem();
            mItem.Text = "Xoá";
            mItem.Click += new System.EventHandler(this.menuItem1_Click);
            ctx.MenuItems.Add(mItem);

            //MenuItem mItem2 = new MenuItem();
            //mItem2.Text = "Item.2";
            //ctx.MenuItems.Add(mItem2);

            if (e.Button == MouseButtons.Right)
            {
                Point pt = new Point(e.X, e.Y);
                ctx.Show(dataGridView1, pt);
            }
        }
    }
}
