using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Drawing;

namespace BLL
{
    public class ThuCungBLL
    {
        ThuCungDAO data = new ThuCungDAO();

        GiongDAO dataGiong = new GiongDAO();
        LoaiDAO dataLoai = new LoaiDAO();

        
        public void HienThiVaoDGV(
                                  DataGridView dGV,
                                  string tenTC)
        {
            BindingSource bS = new BindingSource();

            if (tenTC == "")
                bS.DataSource = data.DanhSachTC();
            else
                bS.DataSource = data.DanhSachTC(tenTC);

            dGV.DataSource = bS;
        }

        public void HienThiVaoDGV2(BindingNavigator bN,
                                  DataGridView dGV,
                                  ComboBox cboMaLoai,
                                  ComboBox cboMaGiong,
                                  TextBox txtMaTC,
                                  TextBox txtTenTC,
                                  TextBox txtGiaBan,
                                  TextBox txtAnh,
                                  DateTimePicker dtpNgayThem,
                                  //NumericUpDown numSoLuongTon,
                                  CheckBox chkMoi,
                                  RichTextBox txtMoTa,
                                  string tuKhoa)
        {
            BindingSource bS1 = new BindingSource();

            if (tuKhoa == "")
                bS1.DataSource = data.DanhSach();
            else
                bS1.DataSource = data.DanhSach_MaTC(tuKhoa);

            cboMaLoai.DataBindings.Clear();
            cboMaLoai.DataBindings.Add("SelectedValue", bS1, "MaLoai", false, DataSourceUpdateMode.Never);

            cboMaGiong.DataBindings.Clear();
            cboMaGiong.DataBindings.Add("SelectedValue", bS1, "MaGiong", false, DataSourceUpdateMode.Never);

            txtMaTC.DataBindings.Clear();
            txtMaTC.DataBindings.Add("Text", bS1, "MaTC", false, DataSourceUpdateMode.Never);

            txtTenTC.DataBindings.Clear();
            txtTenTC.DataBindings.Add("Text", bS1, "TenTC", false, DataSourceUpdateMode.Never);


            CultureInfo info = new CultureInfo("vi-VN");
            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", bS1, "GiaBan", false, DataSourceUpdateMode.Never);
            txtGiaBan.DataBindings[0].FormattingEnabled = true;
            txtGiaBan.DataBindings[0].FormatString = "c0";

            txtAnh.DataBindings.Clear();
            txtAnh.DataBindings.Add("Text", bS1, "Anh", false, DataSourceUpdateMode.Never);

            chkMoi.DataBindings.Clear();
            Binding gt = new Binding("Checked", bS1, "TrangThai", false, DataSourceUpdateMode.Never);
            gt.Format += (s, e) =>
            {
                e.Value = 1;
            };
            chkMoi.DataBindings.Add(gt);

            dtpNgayThem.DataBindings.Clear();
            dtpNgayThem.DataBindings.Add("Value", bS1, "NgayCapNhat", false, DataSourceUpdateMode.Never);

            //numSoLuongTon.DataBindings.Clear();
            //numSoLuongTon.DataBindings.Add("Value", bS1, "SoLuongTon", false, DataSourceUpdateMode.Never);

            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", bS1, "MoTa", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS1;
            dGV.DataSource = bS1;
        }

        public void HienThiVaoComboBox(ComboBox cboLoai, ComboBox cboGiong)
        {
            cboLoai.DataSource = dataLoai.DanhSach();
            cboLoai.ValueMember = "MaLoai";
            cboLoai.DisplayMember = "TenLoai";

            cboGiong.DataSource = dataGiong.DanhSach();
            cboGiong.ValueMember = "MaGiong";
            cboGiong.DisplayMember = "TenGiong";
        }

        //InsertThuCung Linq
        public bool ThemLinq(string tenTC, decimal giaBan, string moTa, string anh, DateTime ngayCapNhap, int maGiong, int maLoai, bool trangThai)
        {
            if (data.ThemLinq(tenTC, giaBan, moTa, anh, ngayCapNhap, maGiong, maLoai, trangThai) == true)
            {
                return true;
            }
            return false;
        }

        public void Them(ThuCungDTO info)
        {
            data.Them(info);
        }

        public void Sua(ThuCungDTO info, int maTC)
        {
            data.Sua(info, maTC);
        }

        public void Xoa(ThuCungDTO info)
        {
            data.Xoa(info);
        }
    }
}
