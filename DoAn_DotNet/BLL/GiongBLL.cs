using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_DotNet.DAO;
using DoAn_DotNet.DTO;
using DoAn_DotNet.GUI;

namespace DoAn_DotNet.BLL
{
    class GiongBLL
    {
        GiongDAO data = new GiongDAO();
        LoaiDAO dataLoai = new LoaiDAO();

        public void HienThiVaoDGV(BindingNavigator bN,
                                  DataGridView dGV,
                                  ComboBox cboMaLoai,
                                  TextBox txtMaGiong,
                                  TextBox txtTenGiong,
                                  RichTextBox txtMoTa,
                                  string tuKhoa)
        {
            BindingSource bS1 = new BindingSource();

            if (tuKhoa == "")
                bS1.DataSource = data.DanhSach();
            else
                bS1.DataSource = data.DanhSach_TenGiong(tuKhoa);

            cboMaLoai.DataBindings.Clear();
            cboMaLoai.DataBindings.Add("SelectedValue", bS1, "MaLoai", false, DataSourceUpdateMode.Never);

            txtMaGiong.DataBindings.Clear();
            txtMaGiong.DataBindings.Add("Text", bS1, "MaGiong", false, DataSourceUpdateMode.Never);

            txtTenGiong.DataBindings.Clear();
            txtTenGiong.DataBindings.Add("Text", bS1, "TenGiong", false, DataSourceUpdateMode.Never);

            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", bS1, "MoTa", false, DataSourceUpdateMode.Never);


            bN.BindingSource = bS1;
            dGV.DataSource = bS1;
        }

        public void HienThiVaoComboBox(ComboBox cboGiong)
        {
            cboGiong.DataSource = dataLoai.DanhSach();
            cboGiong.ValueMember = "MaLoai";
            cboGiong.DisplayMember = "TenLoai";

        }

        public void Them(Giong info)
        {
            data.Them(info);
        }

        public void Sua(Giong info,int maGiong)
        {
            data.Sua(info, maGiong);
        }

        public void Xoa(Giong info)
        {
            data.Xoa(info);
        }
    }
}
