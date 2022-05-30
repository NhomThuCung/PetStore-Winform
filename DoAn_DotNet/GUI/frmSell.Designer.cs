
namespace DoAn_DotNet.GUI
{
    partial class frmSell
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSell));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnBtnThuCung = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimKiemTC = new System.Windows.Forms.Button();
            this.lblGiaMin = new System.Windows.Forms.Label();
            this.lblGiaMax = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.cboLoaiTC = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSoLuongTC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtTienThua = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTienNhan = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtMaTC = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnThemKH = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.btnXoaDon = new System.Windows.Forms.Button();
            this.btnThemDon = new System.Windows.Forms.Button();
            this.txtDH = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnBtnThuCung);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 670);
            this.panel1.TabIndex = 0;
            // 
            // pnBtnThuCung
            // 
            this.pnBtnThuCung.AutoScroll = true;
            this.pnBtnThuCung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBtnThuCung.Location = new System.Drawing.Point(0, 170);
            this.pnBtnThuCung.Name = "pnBtnThuCung";
            this.pnBtnThuCung.Size = new System.Drawing.Size(580, 500);
            this.pnBtnThuCung.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(580, 170);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaTC";
            this.Column1.HeaderText = "Mã Thú Cưng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenTC";
            this.Column2.HeaderText = "Tên Thú Cưng";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "GiaBan";
            this.Column3.HeaderText = "Thành Tiền";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(580, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 670);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiemTC);
            this.groupBox1.Controls.Add(this.lblGiaMin);
            this.groupBox1.Controls.Add(this.lblGiaMax);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.cboLoaiTC);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblSoLuongTC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 235);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thú Cưng";
            // 
            // btnTimKiemTC
            // 
            this.btnTimKiemTC.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTimKiemTC.FlatAppearance.BorderSize = 0;
            this.btnTimKiemTC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemTC.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiemTC.Image")));
            this.btnTimKiemTC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiemTC.Location = new System.Drawing.Point(293, 174);
            this.btnTimKiemTC.Name = "btnTimKiemTC";
            this.btnTimKiemTC.Size = new System.Drawing.Size(110, 30);
            this.btnTimKiemTC.TabIndex = 33;
            this.btnTimKiemTC.Text = "Tìm Kiếm";
            this.btnTimKiemTC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiemTC.UseVisualStyleBackColor = false;
            this.btnTimKiemTC.Click += new System.EventHandler(this.btnTimKiemTC_Click);
            // 
            // lblGiaMin
            // 
            this.lblGiaMin.AutoSize = true;
            this.lblGiaMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGiaMin.Location = new System.Drawing.Point(9, 135);
            this.lblGiaMin.Name = "lblGiaMin";
            this.lblGiaMin.Size = new System.Drawing.Size(24, 25);
            this.lblGiaMin.TabIndex = 8;
            this.lblGiaMin.Text = "0";
            // 
            // lblGiaMax
            // 
            this.lblGiaMax.AutoSize = true;
            this.lblGiaMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGiaMax.Location = new System.Drawing.Point(253, 135);
            this.lblGiaMax.Name = "lblGiaMax";
            this.lblGiaMax.Size = new System.Drawing.Size(24, 25);
            this.lblGiaMax.TabIndex = 7;
            this.lblGiaMax.Text = "0";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(39, 135);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(208, 56);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // cboLoaiTC
            // 
            this.cboLoaiTC.FormattingEnabled = true;
            this.cboLoaiTC.Location = new System.Drawing.Point(157, 57);
            this.cboLoaiTC.Name = "cboLoaiTC";
            this.cboLoaiTC.Size = new System.Drawing.Size(246, 24);
            this.cboLoaiTC.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Loại Thú Cưng:";
            // 
            // lblSoLuongTC
            // 
            this.lblSoLuongTC.AutoSize = true;
            this.lblSoLuongTC.Location = new System.Drawing.Point(154, 28);
            this.lblSoLuongTC.Name = "lblSoLuongTC";
            this.lblSoLuongTC.Size = new System.Drawing.Size(97, 17);
            this.lblSoLuongTC.TabIndex = 1;
            this.lblSoLuongTC.Text = "lblSoLuongTC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số Lượng Thú Cưng:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtTongTien);
            this.panel6.Controls.Add(this.txtTienThua);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.txtTienNhan);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 555);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(417, 115);
            this.panel6.TabIndex = 2;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(103, 7);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(300, 22);
            this.txtTongTien.TabIndex = 6;
            // 
            // txtTienThua
            // 
            this.txtTienThua.Enabled = false;
            this.txtTienThua.Location = new System.Drawing.Point(102, 78);
            this.txtTienThua.Name = "txtTienThua";
            this.txtTienThua.Size = new System.Drawing.Size(301, 22);
            this.txtTienThua.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 81);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 17);
            this.label17.TabIndex = 4;
            this.label17.Text = "Tiền Thừa:";
            // 
            // txtTienNhan
            // 
            this.txtTienNhan.Location = new System.Drawing.Point(103, 44);
            this.txtTienNhan.Name = "txtTienNhan";
            this.txtTienNhan.Size = new System.Drawing.Size(300, 22);
            this.txtTienNhan.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 17);
            this.label16.TabIndex = 2;
            this.label16.Text = "Tiền nhận: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "Tổng tiền:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTime);
            this.panel5.Controls.Add(this.txtSDT);
            this.panel5.Controls.Add(this.txtMaTC);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.btnThemKH);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.btnInHoaDon);
            this.panel5.Controls.Add(this.btnXoaDon);
            this.panel5.Controls.Add(this.btnThemDon);
            this.panel5.Controls.Add(this.txtDH);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.btnThanhToan);
            this.panel5.Controls.Add(this.btnXoa);
            this.panel5.Controls.Add(this.btnThem);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.txtDiaChi);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.txtEmail);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.txtMaKH);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.txtTenKH);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.txtMaNV);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(417, 320);
            this.panel5.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(273, 50);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(46, 17);
            this.lblTime.TabIndex = 40;
            this.lblTime.Text = "label1";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(102, 20);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(257, 22);
            this.txtSDT.TabIndex = 39;
            this.txtSDT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSDT_KeyDown);
            // 
            // txtMaTC
            // 
            this.txtMaTC.Enabled = false;
            this.txtMaTC.Location = new System.Drawing.Point(276, 162);
            this.txtMaTC.Name = "txtMaTC";
            this.txtMaTC.Size = new System.Drawing.Size(107, 22);
            this.txtMaTC.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(194, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Mã TC:";
            // 
            // btnThemKH
            // 
            this.btnThemKH.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThemKH.FlatAppearance.BorderSize = 0;
            this.btnThemKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemKH.Image = ((System.Drawing.Image)(resources.GetObject("btnThemKH.Image")));
            this.btnThemKH.Location = new System.Drawing.Point(365, 20);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(38, 24);
            this.btnThemKH.TabIndex = 38;
            this.btnThemKH.UseVisualStyleBackColor = false;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "Số ĐT:";
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.BackColor = System.Drawing.Color.SteelBlue;
            this.btnInHoaDon.FlatAppearance.BorderSize = 0;
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInHoaDon.Location = new System.Drawing.Point(197, 284);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(80, 30);
            this.btnInHoaDon.TabIndex = 34;
            this.btnInHoaDon.Text = "In ĐH";
            this.btnInHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnXoaDon
            // 
            this.btnXoaDon.BackColor = System.Drawing.Color.SteelBlue;
            this.btnXoaDon.FlatAppearance.BorderSize = 0;
            this.btnXoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDon.Image")));
            this.btnXoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDon.Location = new System.Drawing.Point(12, 284);
            this.btnXoaDon.Name = "btnXoaDon";
            this.btnXoaDon.Size = new System.Drawing.Size(110, 30);
            this.btnXoaDon.TabIndex = 33;
            this.btnXoaDon.Text = "Xoá Đơn";
            this.btnXoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaDon.UseVisualStyleBackColor = false;
            // 
            // btnThemDon
            // 
            this.btnThemDon.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThemDon.FlatAppearance.BorderSize = 0;
            this.btnThemDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDon.Image = ((System.Drawing.Image)(resources.GetObject("btnThemDon.Image")));
            this.btnThemDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemDon.Location = new System.Drawing.Point(12, 248);
            this.btnThemDon.Name = "btnThemDon";
            this.btnThemDon.Size = new System.Drawing.Size(110, 30);
            this.btnThemDon.TabIndex = 32;
            this.btnThemDon.Text = "Thêm Đơn";
            this.btnThemDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemDon.UseVisualStyleBackColor = false;
            this.btnThemDon.Click += new System.EventHandler(this.btnThemDon_Click);
            // 
            // txtDH
            // 
            this.txtDH.Enabled = false;
            this.txtDH.Location = new System.Drawing.Point(102, 190);
            this.txtDH.Name = "txtDH";
            this.txtDH.Size = new System.Drawing.Size(83, 22);
            this.txtDH.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 193);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 17);
            this.label15.TabIndex = 30;
            this.label15.Text = "Mã ĐH:";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Image = ((System.Drawing.Image)(resources.GetObject("btnThanhToan.Image")));
            this.btnThanhToan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThanhToan.Location = new System.Drawing.Point(283, 284);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(120, 30);
            this.btnThanhToan.TabIndex = 29;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.SteelBlue;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(303, 248);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 30);
            this.btnXoa.TabIndex = 28;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(197, 249);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 30);
            this.btnThem.TabIndex = 27;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 17);
            this.label10.TabIndex = 13;
            this.label10.Text = "Địa Chỉ:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(103, 134);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(300, 22);
            this.txtDiaChi.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Email: ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(103, 106);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 22);
            this.txtEmail.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tên KH:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Enabled = false;
            this.txtMaKH.Location = new System.Drawing.Point(102, 50);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(83, 22);
            this.txtMaKH.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày Tạo:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(102, 78);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(301, 22);
            this.txtTenKH.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã KH:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Location = new System.Drawing.Point(102, 162);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(83, 22);
            this.txtMaNV.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mã NV:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmSell
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(997, 670);
            this.Controls.Add(this.panel1);
            this.Name = "frmSell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bán Thú Cưng";
            this.Load += new System.EventHandler(this.frmSell_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.Button btnXoaDon;
        private System.Windows.Forms.Button btnThemDon;
        private System.Windows.Forms.TextBox txtDH;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaTC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtTienThua;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTienNhan;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnBtnThuCung;
        private System.Windows.Forms.Button btnThemKH;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblSoLuongTC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLoaiTC;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblGiaMin;
        private System.Windows.Forms.Label lblGiaMax;
        private System.Windows.Forms.Button btnTimKiemTC;
    }
}