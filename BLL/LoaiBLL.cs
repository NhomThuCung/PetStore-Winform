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
    public class LoaiBLL
    {
        LoaiDAO data = new LoaiDAO();

        public void HienThiVaoDGV(BindingNavigator bN,
                                  DataGridView dGV,
                                  TextBox txtMaLoai,
                                  TextBox txtTenLoai,
                                  string tuKhoa)
        {
            BindingSource bS1 = new BindingSource();

            if (tuKhoa == "")
                bS1.DataSource = data.DanhSach();
            else
                bS1.DataSource = data.DanhSach_TenLoai(tuKhoa);

            txtMaLoai.DataBindings.Clear();
            txtMaLoai.DataBindings.Add("Text", bS1, "MaLoai", false, DataSourceUpdateMode.Never);

            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("Text", bS1, "TenLoai", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS1;
            dGV.DataSource = bS1;
        }
        public void Them(Loai info)
        {
            data.Them(info);
        }

        public void Sua(Loai info, int maLoai)
        {
            data.Sua(info, maLoai);
        }

        public void Xoa(Loai info)
        {
            data.Xoa(info);
        }
    }
}
