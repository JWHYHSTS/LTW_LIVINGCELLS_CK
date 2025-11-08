
namespace QuanLyQuanTraSua
{
    partial class FormHoaDon
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.HOADONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLi = new QuanLyQuanTraSua.QuanLi();
            this.BangChiTietHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.windows = new System.Windows.Forms.Panel();
            this.history_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.order_his_panel = new System.Windows.Forms.Panel();
            this.maHD_txt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.detail_btn = new System.Windows.Forms.Button();
            this.show_report_btn = new System.Windows.Forms.Button();
            this.reportViewer_chung = new Microsoft.Reporting.WinForms.ReportViewer();
            this.filter_rdb = new System.Windows.Forms.RadioButton();
            this.show_all_rdb = new System.Windows.Forms.RadioButton();
            this.filter_date = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.reportViewer_detail = new Microsoft.Reporting.WinForms.ReportViewer();
            this.add_panel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.date_lb = new System.Windows.Forms.Label();
            this.nhanvien_lb = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.total_lb = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.discount_lb = new System.Windows.Forms.Label();
            this.coupon_lb = new System.Windows.Forms.Label();
            this.diemtichluyKH_lb = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.maKH_lb = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.item_dgv = new System.Windows.Forms.DataGridView();
            this.cbbMenu = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.diachiKH_tb = new System.Windows.Forms.TextBox();
            this.sdtKH_tb = new System.Windows.Forms.TextBox();
            this.tenKH_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.print_order_btn = new System.Windows.Forms.Button();
            this.check_don_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.HOADONTableAdapter = new QuanLyQuanTraSua.QuanLiTableAdapters.HOADONTableAdapter();
            this.BangHoaDonTableAdapter = new QuanLyQuanTraSua.QuanLiTableAdapters.BangHoaDonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BangChiTietHoaDonBindingSource)).BeginInit();
            this.windows.SuspendLayout();
            this.order_his_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.add_panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.item_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // HOADONBindingSource
            // 
            this.HOADONBindingSource.DataMember = "HOADON";
            this.HOADONBindingSource.DataSource = this.QuanLi;
            // 
            // QuanLi
            // 
            this.QuanLi.DataSetName = "QuanLi";
            this.QuanLi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BangChiTietHoaDonBindingSource
            // 
            this.BangChiTietHoaDonBindingSource.DataMember = "BangChiTietHoaDon";
            this.BangChiTietHoaDonBindingSource.DataSource = this.QuanLi;
            // 
            // windows
            // 
            this.windows.Controls.Add(this.history_btn);
            this.windows.Controls.Add(this.add_btn);
            this.windows.Controls.Add(this.add_panel);
            this.windows.Controls.Add(this.order_his_panel);
            this.windows.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windows.Location = new System.Drawing.Point(12, 12);
            this.windows.Name = "windows";
            this.windows.Size = new System.Drawing.Size(1450, 660);
            this.windows.TabIndex = 0;
            // 
            // history_btn
            // 
            this.history_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.history_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.history_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.history_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.History_icon;
            this.history_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.history_btn.Location = new System.Drawing.Point(716, 3);
            this.history_btn.Name = "history_btn";
            this.history_btn.Size = new System.Drawing.Size(269, 44);
            this.history_btn.TabIndex = 1;
            this.history_btn.Text = "Lịch sử đơn hàng";
            this.history_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.history_btn.UseVisualStyleBackColor = true;
            this.history_btn.Click += new System.EventHandler(this.history_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.add_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.add_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.add;
            this.add_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add_btn.Location = new System.Drawing.Point(537, 3);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(173, 44);
            this.add_btn.TabIndex = 0;
            this.add_btn.Text = "Thêm đơn";
            this.add_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // order_his_panel
            // 
            this.order_his_panel.Controls.Add(this.maHD_txt);
            this.order_his_panel.Controls.Add(this.label13);
            this.order_his_panel.Controls.Add(this.detail_btn);
            this.order_his_panel.Controls.Add(this.show_report_btn);
            this.order_his_panel.Controls.Add(this.reportViewer_chung);
            this.order_his_panel.Controls.Add(this.filter_rdb);
            this.order_his_panel.Controls.Add(this.show_all_rdb);
            this.order_his_panel.Controls.Add(this.filter_date);
            this.order_his_panel.Controls.Add(this.pictureBox1);
            this.order_his_panel.Controls.Add(this.label12);
            this.order_his_panel.Controls.Add(this.label11);
            this.order_his_panel.Controls.Add(this.reportViewer_detail);
            this.order_his_panel.Location = new System.Drawing.Point(15, 53);
            this.order_his_panel.Name = "order_his_panel";
            this.order_his_panel.Size = new System.Drawing.Size(1424, 604);
            this.order_his_panel.TabIndex = 7;
            this.order_his_panel.Visible = false;
            // 
            // maHD_txt
            // 
            this.maHD_txt.Location = new System.Drawing.Point(914, 49);
            this.maHD_txt.Name = "maHD_txt";
            this.maHD_txt.Size = new System.Drawing.Size(233, 31);
            this.maHD_txt.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(832, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 23);
            this.label13.TabIndex = 12;
            this.label13.Text = "Mã HD:";
            // 
            // detail_btn
            // 
            this.detail_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.detail_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.detail_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detail_btn.Location = new System.Drawing.Point(1164, 50);
            this.detail_btn.Name = "detail_btn";
            this.detail_btn.Size = new System.Drawing.Size(233, 32);
            this.detail_btn.TabIndex = 11;
            this.detail_btn.Text = "Hiển thị chi tiết";
            this.detail_btn.UseVisualStyleBackColor = true;
            this.detail_btn.Click += new System.EventHandler(this.detail_btn_Click);
            // 
            // show_report_btn
            // 
            this.show_report_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.show_report_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.show_report_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_report_btn.Location = new System.Drawing.Point(506, 49);
            this.show_report_btn.Name = "show_report_btn";
            this.show_report_btn.Size = new System.Drawing.Size(161, 32);
            this.show_report_btn.TabIndex = 10;
            this.show_report_btn.Text = "Hiển thị";
            this.show_report_btn.UseVisualStyleBackColor = true;
            this.show_report_btn.Click += new System.EventHandler(this.show_report_btn_Click);
            // 
            // reportViewer_chung
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.HOADONBindingSource;
            this.reportViewer_chung.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer_chung.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.ReportAllOrder.rdlc";
            this.reportViewer_chung.Location = new System.Drawing.Point(100, 90);
            this.reportViewer_chung.Name = "reportViewer_chung";
            this.reportViewer_chung.ServerReport.BearerToken = null;
            this.reportViewer_chung.Size = new System.Drawing.Size(1225, 490);
            this.reportViewer_chung.TabIndex = 9;
            // 
            // filter_rdb
            // 
            this.filter_rdb.AutoSize = true;
            this.filter_rdb.Location = new System.Drawing.Point(289, 55);
            this.filter_rdb.Name = "filter_rdb";
            this.filter_rdb.Size = new System.Drawing.Size(17, 16);
            this.filter_rdb.TabIndex = 8;
            this.filter_rdb.UseVisualStyleBackColor = true;
            // 
            // show_all_rdb
            // 
            this.show_all_rdb.AutoSize = true;
            this.show_all_rdb.Checked = true;
            this.show_all_rdb.Location = new System.Drawing.Point(40, 55);
            this.show_all_rdb.Name = "show_all_rdb";
            this.show_all_rdb.Size = new System.Drawing.Size(17, 16);
            this.show_all_rdb.TabIndex = 7;
            this.show_all_rdb.TabStop = true;
            this.show_all_rdb.UseVisualStyleBackColor = true;
            // 
            // filter_date
            // 
            this.filter_date.CustomFormat = "MM/yyyy";
            this.filter_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.filter_date.Location = new System.Drawing.Point(352, 49);
            this.filter_date.MaxDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.filter_date.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.filter_date.Name = "filter_date";
            this.filter_date.ShowUpDown = true;
            this.filter_date.Size = new System.Drawing.Size(148, 31);
            this.filter_date.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyQuanTraSua.Properties.Resources.loc;
            this.pictureBox1.Location = new System.Drawing.Point(312, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(54, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(175, 23);
            this.label12.TabIndex = 1;
            this.label12.Text = "Tất cả đơn hàng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(186, 23);
            this.label11.TabIndex = 0;
            this.label11.Text = "Lịch sử đơn hàng";
            // 
            // reportViewer_detail
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.BangChiTietHoaDonBindingSource;
            this.reportViewer_detail.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer_detail.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.ReportDetailHoaDon.rdlc";
            this.reportViewer_detail.Location = new System.Drawing.Point(100, 90);
            this.reportViewer_detail.Name = "reportViewer_detail";
            this.reportViewer_detail.ServerReport.BearerToken = null;
            this.reportViewer_detail.Size = new System.Drawing.Size(1225, 490);
            this.reportViewer_detail.TabIndex = 14;
            this.reportViewer_detail.Visible = false;
            // 
            // add_panel
            // 
            this.add_panel.Controls.Add(this.groupBox1);
            this.add_panel.Controls.Add(this.print_order_btn);
            this.add_panel.Controls.Add(this.check_don_btn);
            this.add_panel.Controls.Add(this.save_btn);
            this.add_panel.Location = new System.Drawing.Point(13, 48);
            this.add_panel.Name = "add_panel";
            this.add_panel.Size = new System.Drawing.Size(1424, 604);
            this.add_panel.TabIndex = 6;
            this.add_panel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.date_lb);
            this.groupBox1.Controls.Add(this.nhanvien_lb);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.total_lb);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.discount_lb);
            this.groupBox1.Controls.Add(this.coupon_lb);
            this.groupBox1.Controls.Add(this.diemtichluyKH_lb);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.maKH_lb);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.item_dgv);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.diachiKH_tb);
            this.groupBox1.Controls.Add(this.sdtKH_tb);
            this.groupBox1.Controls.Add(this.tenKH_tb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(19, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1051, 586);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đơn hàng";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // date_lb
            // 
            this.date_lb.AutoSize = true;
            this.date_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_lb.Location = new System.Drawing.Point(758, 547);
            this.date_lb.Name = "date_lb";
            this.date_lb.Size = new System.Drawing.Size(109, 23);
            this.date_lb.TabIndex = 20;
            this.date_lb.Text = "Not check";
            // 
            // nhanvien_lb
            // 
            this.nhanvien_lb.AutoSize = true;
            this.nhanvien_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanvien_lb.Location = new System.Drawing.Point(305, 547);
            this.nhanvien_lb.Name = "nhanvien_lb";
            this.nhanvien_lb.Size = new System.Drawing.Size(109, 23);
            this.nhanvien_lb.TabIndex = 19;
            this.nhanvien_lb.Text = "Not check";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(578, 547);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 23);
            this.label10.TabIndex = 18;
            this.label10.Text = "Ngày xuất HĐ: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 547);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(252, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Nhân viên thanh toán: ";
            // 
            // total_lb
            // 
            this.total_lb.AutoSize = true;
            this.total_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_lb.Location = new System.Drawing.Point(857, 511);
            this.total_lb.Name = "total_lb";
            this.total_lb.Size = new System.Drawing.Size(109, 23);
            this.total_lb.TabIndex = 16;
            this.total_lb.Text = "Not check";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 511);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Thành tiền: ";
            // 
            // discount_lb
            // 
            this.discount_lb.AutoSize = true;
            this.discount_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discount_lb.Location = new System.Drawing.Point(857, 473);
            this.discount_lb.Name = "discount_lb";
            this.discount_lb.Size = new System.Drawing.Size(109, 23);
            this.discount_lb.TabIndex = 14;
            this.discount_lb.Text = "Not check";
            // 
            // coupon_lb
            // 
            this.coupon_lb.AutoSize = true;
            this.coupon_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coupon_lb.Location = new System.Drawing.Point(141, 473);
            this.coupon_lb.Name = "coupon_lb";
            this.coupon_lb.Size = new System.Drawing.Size(109, 23);
            this.coupon_lb.TabIndex = 13;
            this.coupon_lb.Text = "Not check";
            // 
            // diemtichluyKH_lb
            // 
            this.diemtichluyKH_lb.AutoSize = true;
            this.diemtichluyKH_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diemtichluyKH_lb.Location = new System.Drawing.Point(700, 147);
            this.diemtichluyKH_lb.Name = "diemtichluyKH_lb";
            this.diemtichluyKH_lb.Size = new System.Drawing.Size(109, 23);
            this.diemtichluyKH_lb.TabIndex = 12;
            this.diemtichluyKH_lb.Text = "Not check";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(397, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(274, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "Điểm tích lũy hiện tại: ";
            // 
            // maKH_lb
            // 
            this.maKH_lb.AutoSize = true;
            this.maKH_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maKH_lb.Location = new System.Drawing.Point(225, 147);
            this.maKH_lb.Name = "maKH_lb";
            this.maKH_lb.Size = new System.Drawing.Size(109, 23);
            this.maKH_lb.TabIndex = 10;
            this.maKH_lb.Text = "Not check";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Mã Khách Hàng : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 473);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Coupon: ";
            // 
            // item_dgv
            // 
            this.item_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.item_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.item_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbbMenu,
            this.soluong,
            this.grade,
            this.cost});
            this.item_dgv.Location = new System.Drawing.Point(41, 236);
            this.item_dgv.Name = "item_dgv";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.item_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.item_dgv.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.item_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.item_dgv.RowTemplate.Height = 24;
            this.item_dgv.Size = new System.Drawing.Size(995, 225);
            this.item_dgv.TabIndex = 7;
            // 
            // cbbMenu
            // 
            this.cbbMenu.HeaderText = "Mặt hàng";
            this.cbbMenu.MinimumWidth = 6;
            this.cbbMenu.Name = "cbbMenu";
            this.cbbMenu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cbbMenu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // soluong
            // 
            this.soluong.HeaderText = "Số lượng";
            this.soluong.MinimumWidth = 6;
            this.soluong.Name = "soluong";
            // 
            // grade
            // 
            this.grade.HeaderText = "Điểm tích lũy";
            this.grade.MinimumWidth = 6;
            this.grade.Name = "grade";
            this.grade.ReadOnly = true;
            // 
            // cost
            // 
            this.cost.HeaderText = "Tạm tính";
            this.cost.MinimumWidth = 6;
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Đơn hàng";
            // 
            // diachiKH_tb
            // 
            this.diachiKH_tb.Location = new System.Drawing.Point(625, 101);
            this.diachiKH_tb.Name = "diachiKH_tb";
            this.diachiKH_tb.Size = new System.Drawing.Size(400, 31);
            this.diachiKH_tb.TabIndex = 5;
            // 
            // sdtKH_tb
            // 
            this.sdtKH_tb.Location = new System.Drawing.Point(229, 96);
            this.sdtKH_tb.MaxLength = 10;
            this.sdtKH_tb.Name = "sdtKH_tb";
            this.sdtKH_tb.Size = new System.Drawing.Size(204, 31);
            this.sdtKH_tb.TabIndex = 4;
            // 
            // tenKH_tb
            // 
            this.tenKH_tb.Location = new System.Drawing.Point(229, 45);
            this.tenKH_tb.Name = "tenKH_tb";
            this.tenKH_tb.Size = new System.Drawing.Size(316, 31);
            this.tenKH_tb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số điện thoại : ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Khách Hàng: ";
            // 
            // print_order_btn
            // 
            this.print_order_btn.BackColor = System.Drawing.Color.CadetBlue;
            this.print_order_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.print_order_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.print_order_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print_order_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.printing_icon_9;
            this.print_order_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.print_order_btn.Location = new System.Drawing.Point(1188, 533);
            this.print_order_btn.Name = "print_order_btn";
            this.print_order_btn.Size = new System.Drawing.Size(222, 58);
            this.print_order_btn.TabIndex = 4;
            this.print_order_btn.Text = "Xuất hóa đơn";
            this.print_order_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.print_order_btn.UseVisualStyleBackColor = false;
            this.print_order_btn.Click += new System.EventHandler(this.print_order_btn_Click);
            // 
            // check_don_btn
            // 
            this.check_don_btn.BackColor = System.Drawing.Color.DarkSalmon;
            this.check_don_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.check_don_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.check_don_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_don_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.check;
            this.check_don_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.check_don_btn.Location = new System.Drawing.Point(1092, 35);
            this.check_don_btn.Name = "check_don_btn";
            this.check_don_btn.Size = new System.Drawing.Size(292, 58);
            this.check_don_btn.TabIndex = 3;
            this.check_don_btn.Text = "Kiểm tra đơn hàng";
            this.check_don_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.check_don_btn.UseVisualStyleBackColor = false;
            this.check_don_btn.Click += new System.EventHandler(this.check_don_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.LemonChiffon;
            this.save_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.save_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.save;
            this.save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save_btn.Location = new System.Drawing.Point(1092, 104);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(292, 58);
            this.save_btn.TabIndex = 5;
            this.save_btn.Text = "Lưu đơn hàng";
            this.save_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // HOADONTableAdapter
            // 
            this.HOADONTableAdapter.ClearBeforeFill = true;
            // 
            // BangHoaDonTableAdapter
            // 
            this.BangHoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // FormHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.windows);
            this.Name = "FormHoaDon";
            this.Text = "FormHoaDon";
            this.Load += new System.EventHandler(this.FormHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HOADONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BangChiTietHoaDonBindingSource)).EndInit();
            this.windows.ResumeLayout(false);
            this.order_his_panel.ResumeLayout(false);
            this.order_his_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.add_panel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.item_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button history_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tenKH_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button check_don_btn;
        private System.Windows.Forms.Label date_lb;
        private System.Windows.Forms.Label nhanvien_lb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label total_lb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label discount_lb;
        private System.Windows.Forms.Label coupon_lb;
        private System.Windows.Forms.Label diemtichluyKH_lb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label maKH_lb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView item_dgv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox diachiKH_tb;
        private System.Windows.Forms.TextBox sdtKH_tb;
        private System.Windows.Forms.Button print_order_btn;
        public System.Windows.Forms.Panel windows;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Panel order_his_panel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel add_panel;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbbMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker filter_date;
        private System.Windows.Forms.RadioButton filter_rdb;
        private System.Windows.Forms.RadioButton show_all_rdb;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_chung;
        private System.Windows.Forms.BindingSource HOADONBindingSource;
        private QuanLi QuanLi;
        private QuanLiTableAdapters.HOADONTableAdapter HOADONTableAdapter;
        private System.Windows.Forms.Button show_report_btn;
        private System.Windows.Forms.TextBox maHD_txt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button detail_btn;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_detail;
        private System.Windows.Forms.BindingSource BangChiTietHoaDonBindingSource;
        private QuanLiTableAdapters.BangHoaDonTableAdapter BangHoaDonTableAdapter;
    }
}