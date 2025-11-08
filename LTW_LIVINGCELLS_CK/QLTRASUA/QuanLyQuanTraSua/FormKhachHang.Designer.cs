
namespace QuanLyQuanTraSua
{
    partial class FormKhachHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.KHACHHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLi = new QuanLyQuanTraSua.QuanLi();
            this.BangChiTietKhachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BangTongQuatKhachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.windows = new System.Windows.Forms.Panel();
            this.modify_btn = new System.Windows.Forms.Button();
            this.view_btn = new System.Windows.Forms.Button();
            this.modify_infor_panel = new System.Windows.Forms.Panel();
            this.save_btn = new System.Windows.Forms.Button();
            this.search_tb = new System.Windows.Forms.TextBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.fix_btn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.diemtichluyKH_lb = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.maKH_lb = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.diachiKH_tb = new System.Windows.Forms.TextBox();
            this.sdtKH_tb = new System.Windows.Forms.TextBox();
            this.tenKH_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.KhachHang_dtg = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.report_panel = new System.Windows.Forms.Panel();
            this.all_KH_btn = new System.Windows.Forms.Button();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.chitiet_bt = new System.Windows.Forms.Button();
            this.timkiem_bt = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.maKH_tk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TongQuatKhachHangTableAdapter = new QuanLyQuanTraSua.QuanLiTableAdapters.TongQuatKhachHangTableAdapter();
            this.BangChiTietKhachHangTableAdapter = new QuanLyQuanTraSua.QuanLiTableAdapters.BangChiTietKhachHangTableAdapter();
            this.KHACHHANGTableAdapter = new QuanLyQuanTraSua.QuanLiTableAdapters.KHACHHANGTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.KHACHHANGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BangChiTietKhachHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BangTongQuatKhachHangBindingSource)).BeginInit();
            this.windows.SuspendLayout();
            this.modify_infor_panel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KhachHang_dtg)).BeginInit();
            this.report_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // KHACHHANGBindingSource
            // 
            this.KHACHHANGBindingSource.DataMember = "KHACHHANG";
            this.KHACHHANGBindingSource.DataSource = this.QuanLi;
            // 
            // QuanLi
            // 
            this.QuanLi.DataSetName = "QuanLi";
            this.QuanLi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BangChiTietKhachHangBindingSource
            // 
            this.BangChiTietKhachHangBindingSource.DataMember = "BangChiTietKhachHang";
            this.BangChiTietKhachHangBindingSource.DataSource = this.QuanLi;
            // 
            // BangTongQuatKhachHangBindingSource
            // 
            this.BangTongQuatKhachHangBindingSource.DataMember = "BangTongQuatKhachHang";
            this.BangTongQuatKhachHangBindingSource.DataSource = this.QuanLi;
            // 
            // windows
            // 
            this.windows.Controls.Add(this.modify_btn);
            this.windows.Controls.Add(this.view_btn);
            this.windows.Controls.Add(this.modify_infor_panel);
            this.windows.Controls.Add(this.report_panel);
            this.windows.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windows.Location = new System.Drawing.Point(12, 12);
            this.windows.Name = "windows";
            this.windows.Size = new System.Drawing.Size(1450, 660);
            this.windows.TabIndex = 0;
            // 
            // modify_btn
            // 
            this.modify_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.modify_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.modify_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modify_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.History_icon;
            this.modify_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modify_btn.Location = new System.Drawing.Point(738, 6);
            this.modify_btn.Name = "modify_btn";
            this.modify_btn.Size = new System.Drawing.Size(366, 44);
            this.modify_btn.TabIndex = 5;
            this.modify_btn.Text = "Sửa thông tin khách hàng";
            this.modify_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.modify_btn.UseVisualStyleBackColor = true;
            this.modify_btn.Click += new System.EventHandler(this.modify_btn_Click);
            // 
            // view_btn
            // 
            this.view_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.view_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.view_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.view_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.History_icon;
            this.view_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.view_btn.Location = new System.Drawing.Point(358, 6);
            this.view_btn.Name = "view_btn";
            this.view_btn.Size = new System.Drawing.Size(374, 44);
            this.view_btn.TabIndex = 2;
            this.view_btn.Text = "Xem danh sách khách hàng";
            this.view_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.view_btn.UseVisualStyleBackColor = true;
            this.view_btn.Click += new System.EventHandler(this.view_btn_Click);
            // 
            // modify_infor_panel
            // 
            this.modify_infor_panel.Controls.Add(this.save_btn);
            this.modify_infor_panel.Controls.Add(this.search_tb);
            this.modify_infor_panel.Controls.Add(this.search_btn);
            this.modify_infor_panel.Controls.Add(this.fix_btn);
            this.modify_infor_panel.Controls.Add(this.panel3);
            this.modify_infor_panel.Controls.Add(this.label2);
            this.modify_infor_panel.Controls.Add(this.KhachHang_dtg);
            this.modify_infor_panel.Location = new System.Drawing.Point(12, 56);
            this.modify_infor_panel.Name = "modify_infor_panel";
            this.modify_infor_panel.Size = new System.Drawing.Size(1424, 604);
            this.modify_infor_panel.TabIndex = 7;
            this.modify_infor_panel.Visible = false;
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.save_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.save_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.check;
            this.save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save_btn.Location = new System.Drawing.Point(245, 524);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(243, 58);
            this.save_btn.TabIndex = 28;
            this.save_btn.Text = "Lưu thông tin";
            this.save_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // search_tb
            // 
            this.search_tb.Location = new System.Drawing.Point(957, 38);
            this.search_tb.Name = "search_tb";
            this.search_tb.Size = new System.Drawing.Size(306, 31);
            this.search_tb.TabIndex = 27;
            this.search_tb.TextChanged += new System.EventHandler(this.search_tb_TextChanged);
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.Color.LightSlateGray;
            this.search_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.search_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.search_flat;
            this.search_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.search_btn.Location = new System.Drawing.Point(770, 30);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(165, 44);
            this.search_btn.TabIndex = 26;
            this.search_btn.Text = "Tìm kiếm";
            this.search_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // fix_btn
            // 
            this.fix_btn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.fix_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.fix_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.fix_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fix_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fix_btn.Location = new System.Drawing.Point(44, 524);
            this.fix_btn.Name = "fix_btn";
            this.fix_btn.Size = new System.Drawing.Size(193, 58);
            this.fix_btn.TabIndex = 25;
            this.fix_btn.Text = "Sửa thông tin";
            this.fix_btn.UseVisualStyleBackColor = false;
            this.fix_btn.Click += new System.EventHandler(this.fix_btn_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.diemtichluyKH_lb);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.maKH_lb);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.diachiKH_tb);
            this.panel3.Controls.Add(this.sdtKH_tb);
            this.panel3.Controls.Add(this.tenKH_tb);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(44, 109);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(653, 391);
            this.panel3.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // diemtichluyKH_lb
            // 
            this.diemtichluyKH_lb.AutoSize = true;
            this.diemtichluyKH_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diemtichluyKH_lb.Location = new System.Drawing.Point(353, 277);
            this.diemtichluyKH_lb.Name = "diemtichluyKH_lb";
            this.diemtichluyKH_lb.Size = new System.Drawing.Size(109, 23);
            this.diemtichluyKH_lb.TabIndex = 33;
            this.diemtichluyKH_lb.Text = "Not check";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(274, 23);
            this.label7.TabIndex = 32;
            this.label7.Text = "Điểm tích lũy hiện tại: ";
            // 
            // maKH_lb
            // 
            this.maKH_lb.AutoSize = true;
            this.maKH_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maKH_lb.Location = new System.Drawing.Point(353, 248);
            this.maKH_lb.Name = "maKH_lb";
            this.maKH_lb.Size = new System.Drawing.Size(109, 23);
            this.maKH_lb.TabIndex = 31;
            this.maKH_lb.Text = "Not check";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 23);
            this.label6.TabIndex = 30;
            this.label6.Text = "Mã Khách Hàng : ";
            // 
            // diachiKH_tb
            // 
            this.diachiKH_tb.Location = new System.Drawing.Point(164, 152);
            this.diachiKH_tb.Name = "diachiKH_tb";
            this.diachiKH_tb.Size = new System.Drawing.Size(400, 31);
            this.diachiKH_tb.TabIndex = 29;
            // 
            // sdtKH_tb
            // 
            this.sdtKH_tb.Location = new System.Drawing.Point(239, 115);
            this.sdtKH_tb.Name = "sdtKH_tb";
            this.sdtKH_tb.Size = new System.Drawing.Size(204, 31);
            this.sdtKH_tb.TabIndex = 28;
            // 
            // tenKH_tb
            // 
            this.tenKH_tb.Location = new System.Drawing.Point(239, 78);
            this.tenKH_tb.Name = "tenKH_tb";
            this.tenKH_tb.Size = new System.Drawing.Size(316, 31);
            this.tenKH_tb.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Địa chỉ: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(186, 23);
            this.label11.TabIndex = 25;
            this.label11.Text = "Số điện thoại : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(47, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(186, 23);
            this.label12.TabIndex = 24;
            this.label12.Text = "Tên Khách Hàng: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sửa thông tin khách hàng";
            // 
            // KhachHang_dtg
            // 
            this.KhachHang_dtg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.KhachHang_dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KhachHang_dtg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.KhachHang_dtg.Location = new System.Drawing.Point(770, 109);
            this.KhachHang_dtg.Name = "KhachHang_dtg";
            this.KhachHang_dtg.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.KhachHang_dtg.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.KhachHang_dtg.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.KhachHang_dtg.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.KhachHang_dtg.RowTemplate.Height = 24;
            this.KhachHang_dtg.Size = new System.Drawing.Size(614, 456);
            this.KhachHang_dtg.TabIndex = 7;
            this.KhachHang_dtg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.KhachHang_dtg_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaKH";
            this.Column1.HeaderText = "Mã KH";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 67;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenKH";
            this.Column2.HeaderText = "Tên KH";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 77;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SDT";
            this.Column3.HeaderText = "SĐT";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 72;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DiaChi";
            this.Column4.HeaderText = "Địa chỉ";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 77;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DiemTichLuy";
            this.Column5.HeaderText = "Điểm tích lũy";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 136;
            // 
            // report_panel
            // 
            this.report_panel.Controls.Add(this.all_KH_btn);
            this.report_panel.Controls.Add(this.reportViewer3);
            this.report_panel.Controls.Add(this.reportViewer2);
            this.report_panel.Controls.Add(this.reportViewer1);
            this.report_panel.Controls.Add(this.chitiet_bt);
            this.report_panel.Controls.Add(this.timkiem_bt);
            this.report_panel.Controls.Add(this.label8);
            this.report_panel.Controls.Add(this.maKH_tk);
            this.report_panel.Controls.Add(this.label1);
            this.report_panel.Location = new System.Drawing.Point(12, 56);
            this.report_panel.Name = "report_panel";
            this.report_panel.Size = new System.Drawing.Size(1424, 604);
            this.report_panel.TabIndex = 6;
            this.report_panel.Visible = false;
            // 
            // all_KH_btn
            // 
            this.all_KH_btn.Location = new System.Drawing.Point(119, 51);
            this.all_KH_btn.Name = "all_KH_btn";
            this.all_KH_btn.Size = new System.Drawing.Size(277, 31);
            this.all_KH_btn.TabIndex = 19;
            this.all_KH_btn.Text = "Toàn bộ khách hàng";
            this.all_KH_btn.UseVisualStyleBackColor = true;
            this.all_KH_btn.Click += new System.EventHandler(this.all_KH_btn_Click);
            // 
            // reportViewer3
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.KHACHHANGBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.ReportAllKhachHang.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(119, 109);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(1164, 456);
            this.reportViewer3.TabIndex = 18;
            // 
            // reportViewer2
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.BangChiTietKhachHangBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.ReportChiTietKH.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(119, 109);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1164, 456);
            this.reportViewer2.TabIndex = 17;
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.BangTongQuatKhachHangBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.ReportTongQuatKH.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(119, 109);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1164, 456);
            this.reportViewer1.TabIndex = 16;
            // 
            // chitiet_bt
            // 
            this.chitiet_bt.Location = new System.Drawing.Point(1117, 46);
            this.chitiet_bt.Name = "chitiet_bt";
            this.chitiet_bt.Size = new System.Drawing.Size(166, 31);
            this.chitiet_bt.TabIndex = 15;
            this.chitiet_bt.Text = "Chi Tiết";
            this.chitiet_bt.UseVisualStyleBackColor = true;
            this.chitiet_bt.Click += new System.EventHandler(this.chitiet_bt_Click);
            // 
            // timkiem_bt
            // 
            this.timkiem_bt.Location = new System.Drawing.Point(941, 46);
            this.timkiem_bt.Name = "timkiem_bt";
            this.timkiem_bt.Size = new System.Drawing.Size(165, 31);
            this.timkiem_bt.TabIndex = 14;
            this.timkiem_bt.Text = "Tìm Kiếm";
            this.timkiem_bt.UseVisualStyleBackColor = true;
            this.timkiem_bt.Click += new System.EventHandler(this.timkiem_bt_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(699, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "Mã KH";
            // 
            // maKH_tk
            // 
            this.maKH_tk.Location = new System.Drawing.Point(770, 47);
            this.maKH_tk.Name = "maKH_tk";
            this.maKH_tk.Size = new System.Drawing.Size(150, 31);
            this.maKH_tk.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Report";
            // 
            // TongQuatKhachHangTableAdapter
            // 
            this.TongQuatKhachHangTableAdapter.ClearBeforeFill = true;
            // 
            // BangChiTietKhachHangTableAdapter
            // 
            this.BangChiTietKhachHangTableAdapter.ClearBeforeFill = true;
            // 
            // KHACHHANGTableAdapter
            // 
            this.KHACHHANGTableAdapter.ClearBeforeFill = true;
            // 
            // FormKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.windows);
            this.Name = "FormKhachHang";
            this.Text = "FormKhachHang";
            this.Load += new System.EventHandler(this.FormKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KHACHHANGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BangChiTietKhachHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BangTongQuatKhachHangBindingSource)).EndInit();
            this.windows.ResumeLayout(false);
            this.modify_infor_panel.ResumeLayout(false);
            this.modify_infor_panel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KhachHang_dtg)).EndInit();
            this.report_panel.ResumeLayout(false);
            this.report_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel report_panel;
        private System.Windows.Forms.Button modify_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button view_btn;
        private System.Windows.Forms.Panel modify_infor_panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView KhachHang_dtg;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label diemtichluyKH_lb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label maKH_lb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox diachiKH_tb;
        private System.Windows.Forms.TextBox sdtKH_tb;
        private System.Windows.Forms.TextBox tenKH_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button fix_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.TextBox search_tb;
        public System.Windows.Forms.Panel windows;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button chitiet_bt;
        private System.Windows.Forms.Button timkiem_bt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox maKH_tk;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource BangTongQuatKhachHangBindingSource;
        private QuanLi QuanLi;
        private QuanLiTableAdapters.TongQuatKhachHangTableAdapter TongQuatKhachHangTableAdapter;
        private System.Windows.Forms.BindingSource BangChiTietKhachHangBindingSource;
        private QuanLiTableAdapters.BangChiTietKhachHangTableAdapter BangChiTietKhachHangTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.BindingSource KHACHHANGBindingSource;
        private QuanLiTableAdapters.KHACHHANGTableAdapter KHACHHANGTableAdapter;
        private System.Windows.Forms.Button all_KH_btn;
    }
}