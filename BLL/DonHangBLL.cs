using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Windows.Forms;

namespace BLL
{
    public class DonHangBLL
    {
        DonHangDAO data = new DonHangDAO();
        ThuCungDAO ctDAO = new ThuCungDAO();
        public void HienThiVaoDGV(
                                  DataGridView dGV
                                  )
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DonHang_MaDH();

            dGV.DataSource = bS;
        }

        public void HienThiVaoDGV2(
                                  DataGridView dGV,
                                  DateTimePicker frmDate,
                                  DateTimePicker toDate
                                  )
        {
            BindingSource bS = new BindingSource();
            if (frmDate.ToString() == "" && frmDate.ToString() == "")
            {
                bS.DataSource = data.DonHang_CTDH();
            }
            else
                bS.DataSource = data.DonHang_CTDH(frmDate.Value,toDate.Value);


            dGV.DataSource = bS;
        }

        public void HienThiVaoDGV3(BindingNavigator bN,
                                  DataGridView dGV,
                                  TextBox txtMaDH,
                                  TextBox txtMaNV,
                                  DateTimePicker dtpNgayTao,
                                  TextBox txtMaKH,
                                  TextBox txtNguoiNhan,
                                  TextBox txtEmail,
                                  TextBox txtSDT,
                                  TextBox txtDiaChi,
                                  TextBox txtTongTien,
                                  CheckBox chkTinhTrang,
                                   string tuKhoa)
        {
            BindingSource bS = new BindingSource();
            if (tuKhoa == "")
                bS.DataSource = data.DonHang();
            else
                bS.DataSource = data.DonHang_SoDT(tuKhoa);

            txtMaDH.DataBindings.Clear();
            txtMaDH.DataBindings.Add("Text", bS, "MaDH", false, DataSourceUpdateMode.Never);

            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", bS, "ID", false, DataSourceUpdateMode.Never);

            dtpNgayTao.DataBindings.Clear();
            dtpNgayTao.DataBindings.Add("Value", bS, "CreatedDate", false, DataSourceUpdateMode.Never);

            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", bS, "MaKH", false, DataSourceUpdateMode.Never);

            txtNguoiNhan.DataBindings.Clear();
            txtNguoiNhan.DataBindings.Add("Text", bS, "NguoiNhan", false, DataSourceUpdateMode.Never);

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", bS, "Email", false, DataSourceUpdateMode.Never);

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", bS, "SoDT", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bS, "DiaChi", false, DataSourceUpdateMode.Never);

            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("Text", bS, "TongTien", false, DataSourceUpdateMode.Never);
            txtTongTien.DataBindings[0].FormattingEnabled = true;
            txtTongTien.DataBindings[0].FormatString = "c0";

            chkTinhTrang.DataBindings.Clear();
            Binding gt = new Binding("Checked", bS, "Status", false, DataSourceUpdateMode.Never);
            gt.Format += (s, e) =>
            {
                e.Value = 1;
            };
            chkTinhTrang.DataBindings.Add(gt);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }


        public void Them(DonHang info)
        {
            data.Them(info);
        }

        public void Sua(DonHang info, int maDH)
        {
            data.Sua(info, maDH);
        }

        public void SuaDonHang(DonHang info, int maDH)
        {
            data.SuaDonHang(info, maDH);
        }

        public void Xoa(DonHang info)
        {
            data.Xoa(info);
        }

    }
}
