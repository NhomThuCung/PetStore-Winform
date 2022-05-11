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
    class ChiTietDonHangBLL
    {

        ChiTietDonHangDAO data = new ChiTietDonHangDAO();
        DonHangDAO dhDAO = new DonHangDAO();
        ThuCungDAO tcDAO = new ThuCungDAO();

        public void HienThiVaoDGV(DataGridView dGV,
                                  int maDH)
        {
            BindingSource bS = new BindingSource();
                bS.DataSource = data.DanhSach_MaDH(maDH);

            dGV.DataSource = bS;
        }

        public void HienThiVaoDGV2(BindingNavigator bN,
                                  DataGridView dGV,
                                  ComboBox cboMaDH,
                                  ComboBox cboThuCung,
                                  TextBox txtGiaBan,
                                  TextBox txtSoLuong,
                                  TextBox txtThanhTien,
                                  string maDH)
        {
            BindingSource bS = new BindingSource();

            if (maDH.ToString() == "")
                bS.DataSource = data.DanhSach_KetHop();
            else
                bS.DataSource = data.DanhSach_KetHop(maDH);

            cboMaDH.DataBindings.Clear();
            cboMaDH.DataBindings.Add("SelectedValue", bS, "MaDH", false, DataSourceUpdateMode.Never);

            cboThuCung.DataBindings.Clear();
            cboThuCung.DataBindings.Add("SelectedValue", bS, "MaTC", false, DataSourceUpdateMode.Never);

            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", bS, "GiaBan", false, DataSourceUpdateMode.Never);
            txtGiaBan.DataBindings[0].FormattingEnabled = true;
            txtGiaBan.DataBindings[0].FormatString = "c0";

            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", bS, "SoLuong", false, DataSourceUpdateMode.Never);

            txtThanhTien.DataBindings.Clear();
            txtThanhTien.DataBindings.Add("Text", bS, "ThanhTien", false, DataSourceUpdateMode.Never);
            txtThanhTien.DataBindings[0].FormattingEnabled = true;
            txtThanhTien.DataBindings[0].FormatString = "c0";

            dGV.DataSource = bS;
        }

        public void HienThiVaoComboBox(ComboBox cboMaDH, ComboBox cboThuCung)
        {
            cboMaDH.DataSource = dhDAO.DonHang();
            cboMaDH.ValueMember = "MaDH";
            cboMaDH.DisplayMember = "MaDH";

            cboThuCung.DataSource = tcDAO.DanhSach();
            cboThuCung.ValueMember = "MaTC";
            cboThuCung.DisplayMember = "TenTC";
        }

        public void Them(ChiTietDonHang info)
        {
            data.Them(info);
        }

        public void Sua(ChiTietDonHang info, int maDH)
        {
            data.Sua(info, maDH);
        }
        public void SuaChiTiet(ChiTietDonHang info, int maTC, int maHD)
        {
            data.SuaChiTiet(info, maTC, maHD);
        }

        public void Xoa(ChiTietDonHang info)
        {
            data.Xoa(info);
        }

        public void XoaChiTiet(ChiTietDonHang info)
        {
            data.XoaChiTiet(info);
        }
    }
}
