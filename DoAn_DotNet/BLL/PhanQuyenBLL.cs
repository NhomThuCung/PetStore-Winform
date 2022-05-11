using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn_DotNet.DAO;
using DoAn_DotNet.DTO;
using DoAn_DotNet.GUI;
using System.Windows.Forms;

namespace DoAn_DotNet.BLL
{
    class PhanQuyenBLL
    {
        PhanQuyenDAO data = new PhanQuyenDAO();

        public void HienThiVaoDGV(BindingNavigator bN,
                                  DataGridView dGV,
                                  TextBox txtMaQuyen,
                                  TextBox txtTenQuyen,
                                  string tuKhoa)
        {
            BindingSource bS1 = new BindingSource();

            if (tuKhoa == "")
                bS1.DataSource = data.DanhSach();
            else
                bS1.DataSource = data.DanhSach_TenQuyen(tuKhoa);

            txtMaQuyen.DataBindings.Clear();
            txtMaQuyen.DataBindings.Add("Text", bS1, "MaQuyen", false, DataSourceUpdateMode.Never);

            txtTenQuyen.DataBindings.Clear();
            txtTenQuyen.DataBindings.Add("Text", bS1, "TenQuyen", false, DataSourceUpdateMode.Never);


            bN.BindingSource = bS1;
            dGV.DataSource = bS1;
        }
        public void Them(PhanQuyen info)
        {
            data.Them(info);
        }

        public void Sua(PhanQuyen info, int maQuyen)
        {
            data.Sua(info, maQuyen);
        }

        public void Xoa(PhanQuyen info)
        {
            data.Xoa(info);
        }
    }
}
