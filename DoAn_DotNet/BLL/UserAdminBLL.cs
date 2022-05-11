using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DoAn_DotNet.DAO;
using DoAn_DotNet.DTO;
using DoAn_DotNet.GUI;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_DotNet.BLL
{
    class UserAdminBLL
    {
        UserAdminDAO data = new UserAdminDAO();
        PhanQuyenDAO dataPhanQuyen = new PhanQuyenDAO();

        public void HienThiVaoDGV(BindingNavigator bN, 
                                  DataGridView dGV,
                                  TextBox txtID,
                                  TextBox txtUserName,
                                  TextBox txtPassword,
                                  TextBox txtHoTen,
                                  TextBox txtCMND,
                                  DateTimePicker dtpNgaySinh,
                                  DateTimePicker dtpNgayTao,
                                  TextBox txtDiaChi,
                                  TextBox txtEmail,
                                  TextBox txtDienThoai,
                                  ComboBox cboMaQuyen,
                                  TextBox txtTienLuong,
                                  string tuKhoa)
        {
            BindingSource bS = new BindingSource();

            if (tuKhoa == "")
                bS.DataSource = data.DanhSach();
            else
                bS.DataSource = data.DanhSach_Ten(tuKhoa);

            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", bS, "ID", false, DataSourceUpdateMode.Never);

            txtUserName.DataBindings.Clear();
            txtUserName.DataBindings.Add("Text", bS, "UserName", false, DataSourceUpdateMode.Never);

            txtPassword.DataBindings.Clear();
            txtPassword.DataBindings.Add("Text", bS, "Password", false, DataSourceUpdateMode.Never);

            txtHoTen.DataBindings.Clear();
            txtHoTen.DataBindings.Add("Text", bS, "Name", false, DataSourceUpdateMode.Never);

            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("Text", bS, "CMND", false, DataSourceUpdateMode.Never);

            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Value", bS, "NgaySinh", false, DataSourceUpdateMode.Never);

            dtpNgayTao.DataBindings.Clear();
            dtpNgayTao.DataBindings.Add("Value", bS, "CreateDate", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bS, "Address", false, DataSourceUpdateMode.Never);

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", bS, "Email", false, DataSourceUpdateMode.Never);

            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bS, "Phone", false, DataSourceUpdateMode.Never);

            cboMaQuyen.DataBindings.Clear();
            cboMaQuyen.DataBindings.Add("SelectedValue", bS, "MaQuyen", false, DataSourceUpdateMode.Never);

            txtTienLuong.DataBindings.Clear();
            txtTienLuong.DataBindings.Add("Text", bS, "TienLuong", false, DataSourceUpdateMode.Never);
            txtTienLuong.DataBindings[0].FormattingEnabled = true;
            txtTienLuong.DataBindings[0].FormatString = "c0";

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public void HienThiVaoComboBox(ComboBox cboQuyen)
        {
            cboQuyen.DataSource = dataPhanQuyen.DanhSach();
            cboQuyen.ValueMember = "MaQuyen";
            cboQuyen.DisplayMember = "TenQuyen";

        }

        public bool DangNhap(string tenDangNhap, string matKhau)
        {
            var tK = data.ChiTiet(tenDangNhap, matKhau);
            if (tK.Rows.Count > 0)
            {
                frmMain.hoVaTen = tK.Rows[0]["Name"].ToString();
                frmMain.quyenHan = int.Parse(tK.Rows[0]["MaQuyen"].ToString());
                frmMain.maNV = int.Parse(tK.Rows[0]["ID"].ToString());
                frmDonHang.maNV = int.Parse(tK.Rows[0]["ID"].ToString());
                frmDoiMK.maNV = int.Parse(tK.Rows[0]["ID"].ToString());
                frmDoiMK.taiKhoan = tK.Rows[0]["UserName"].ToString();
                frmDetailUser.maNV = int.Parse(tK.Rows[0]["ID"].ToString());
                frmDetailUser.hoTen = tK.Rows[0]["Name"].ToString();
                frmDetailUser.maQuyen = int.Parse(tK.Rows[0]["MaQuyen"].ToString());
                frmDetailUser.ngaySinh = DateTime.Parse(tK.Rows[0]["NgaySinh"].ToString());
                frmDetailUser.taiKhoan = tK.Rows[0]["UserName"].ToString();
                frmDetailUser.tienLuong = int.Parse(tK.Rows[0]["TienLuong"].ToString());
                frmDetailUser.cmnd = tK.Rows[0]["CMND"].ToString();
                frmKhachHang.maQuyen = int.Parse(tK.Rows[0]["MaQuyen"].ToString());
                return true;
            }
            else
                return false;
        }

        //public static List<DTO.UserAdmin> DangNhap2(string tenDangNhap, string matKhau)
        //{
        //    DatabaseDataContext data = new DatabaseDataContext();
        //    List<DTO.UserAdmin> lst = null;
        //    lst = (from user in data.UserAdmins
        //           where user.UserName == tenDangNhap && user.Password == matKhau
        //           select new DTO.UserAdmin
        //           {
        //               Id = user.ID,
        //               UserName = user.UserName,
        //               Password = user.Password,
        //               HoTen = user.Name,
        //               Cmnd = user.CMND,
        //               NgaySinh = Convert.ToDateTime(user.NgaySinh),
        //               DiaChi = user.Address,
        //               Email = user.Email,
        //               Phone = user.Phone,
        //               CreateDate = Convert.ToDateTime(user.CreateDate),
        //               MaQuyen = user.MaQuyen,
        //               TienLuong = Convert.ToDecimal(user.TienLuong)

        //           }).ToList();
        //    if (lst.Count > 0)
        //    {
        //        DTO.UserAdmin tK = new DTO.UserAdmin();
        //        frmMain.hoVaTen = tK.HoTen;
        //        frmMain.quyenHan = tK.MaQuyen;
        //        frmMain.maNV = tK.Id;
        //        frmDonHang.maNV = tK.Id;
        //        frmDoiMK.maNV = tK.Id;
        //        frmDoiMK.taiKhoan = tK.UserName;
        //        frmDetailUser.maNV = tK.Id;
        //        frmDetailUser.hoTen = tK.HoTen;
        //        frmDetailUser.maQuyen = tK.MaQuyen;
        //        frmDetailUser.ngaySinh = tK.NgaySinh;
        //        frmDetailUser.taiKhoan = tK.UserName;
        //        frmDetailUser.tienLuong = Convert.ToInt32(tK.TienLuong);
        //        frmDetailUser.cmnd = tK.Cmnd;
        //        frmKhachHang.maQuyen = tK.MaQuyen;
        //        return true;
        //    }
        //    else
        //        return false;
        //    return lst;

        //    //var tK = data.ChiTiet(tenDangNhap, matKhau);
            
        //}



        public bool DoiMK(int manv, string matkhaumoi)
        {
            var tK = data.DoiMatKhau(manv, matkhaumoi);
            if (tK.Rows.Count > 0)
            {
                return false;
            }
            else
                return true;
        }

        public bool LayThongTinTong(int manv, int thang, int nam)
        {
            var tt = data.LayThongTinTong(manv, thang, nam);
            if (tt.Rows.Count > 0)
            {
                return false;
            }
            else
                return true;
        }

        public void Them(UserAdmin info)
        {
            data.Them(info);
        }

        public void Sua(UserAdmin info, int maNV)
        {
            data.Sua(info, maNV);
        }

        public void Xoa(UserAdmin info)
        {
            data.Xoa(info);
        }
    }
}
