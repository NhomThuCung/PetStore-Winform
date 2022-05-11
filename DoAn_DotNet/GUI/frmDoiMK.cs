using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_DotNet.BLL;
using DoAn_DotNet.DTO;
using DoAn_DotNet.Custom;

namespace DoAn_DotNet.GUI
{
    public partial class frmDoiMK : Form
    {
        frmDangNhap fDN = new frmDangNhap();

        public static string taiKhoan = "";
        public static int maNV = 0;

        public frmDoiMK()
        {
            InitializeComponent();
        }
        private void LamMoi()
        {
            txtMatKhauCu.Text = txtMatKhauMoi.Text = txtXacNhan.Text = "";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "Đổi Mật Khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtMatKhauCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Kiểm tra đầu vào Enter
            {
                txtMatKhauMoi.Focus();
            }
        }

        private void txtXacNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Kiểm tra đầu vào Enter
            {
                btnCapNhat.PerformClick();
            }
        }

        private void txtMatKhauMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Kiểm tra đầu vào Enter
            {
                txtXacNhan.Focus();
            }
        }

        private void frmThayDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMatKhauMoi.Text == txtXacNhan.Text)
                {
                    UserAdminBLL tk = new UserAdminBLL();
                    string encrypt_mkcu = Encrypt.Instance.MD5Encrypt(txtMatKhauCu.Text);
                    if (tk.DangNhap(taiKhoan, encrypt_mkcu))
                    {
                        if (MessageBox.Show("Bạn có muốn thay đổi Mật khẩu?", "Thông báo", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string encrypt_mkmoi = Encrypt.Instance.MD5Encrypt(txtMatKhauMoi.Text);
                            if (tk.DoiMK(maNV, encrypt_mkmoi))
                            {
                                MessageBox.Show("Thay đổi Mật khẩu thành công", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                LamMoi();
                                txtMatKhauCu.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Thay đổi Mật khẩu thất bại", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không khớp", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

    }
}
