using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BLL
{
    public class KhachHangBLL
    {
        KhachHangDAO data = new KhachHangDAO();

        public void HienThiVaoDGV(
                                  DataGridView dGV,
                                  string soDT)
        {
            BindingSource bS = new BindingSource();

            if (soDT == "")
                bS.DataSource = data.DanhSach();
            else
                bS.DataSource = data.DanhSach_SoDT(soDT);

            dGV.DataSource = bS;
        }

        public void HienThiVaoDGV2(BindingNavigator bN,
                                  DataGridView dGV,
                                  TextBox txtMaKH,
                                  TextBox txtTenKH,
                                  TextBox txtTaiKhoan,
                                  TextBox txtMatKhau,
                                  DateTimePicker dtpNgaySinh,
                                  DateTimePicker dtpNgayTao,
                                  CheckBox chkGioiTinh,
                                  TextBox txtEmail,
                                  TextBox txtSDT,
                                  TextBox txtDiaChi,
                                  string tuKhoa)
        {
            BindingSource bS1 = new BindingSource();

            if (tuKhoa == "")
                bS1.DataSource = data.DanhSach2();
            else
                bS1.DataSource = data.DanhSach2(tuKhoa);

            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", bS1, "MaKH", false, DataSourceUpdateMode.Never);

            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", bS1, "HoTen", false, DataSourceUpdateMode.Never);

            txtTaiKhoan.DataBindings.Clear();
            txtTaiKhoan.DataBindings.Add("Text", bS1, "TaiKhoan", false, DataSourceUpdateMode.Never);

            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add("Text", bS1, "MatKhau", false, DataSourceUpdateMode.Never);

            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Value", bS1, "NgaySinh", false, DataSourceUpdateMode.Never);

            dtpNgayTao.DataBindings.Clear();
            dtpNgayTao.DataBindings.Add("Value", bS1, "CreatedDate", false, DataSourceUpdateMode.Never);

            chkGioiTinh.DataBindings.Clear();
            Binding gt = new Binding("Checked", bS1, "GioiTinh", false, DataSourceUpdateMode.Never);
            gt.Format += (s, e) =>
            {
                e.Value = (string)e.Value == "Nữ";
            };
            chkGioiTinh.DataBindings.Add(gt);

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", bS1, "Email", false, DataSourceUpdateMode.Never);

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", bS1, "DienThoai", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bS1, "DiaChi", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS1;
            dGV.DataSource = bS1;
        }

        public void Them(KhachHangDTO info)
        {
            data.Them(info);
        }

        public void Sua(KhachHangDTO info, int maKhach)
        {
            data.Sua(info, maKhach);
        }

        public void Xoa(KhachHangDTO info)
        {
            data.Xoa(info);
        }
    }
}
