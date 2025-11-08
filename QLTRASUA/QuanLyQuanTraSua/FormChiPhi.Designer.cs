
namespace QuanLyQuanTraSua
{
    partial class FormChiPhi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChiPhi));
            this.CHIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLi = new QuanLyQuanTraSua.QuanLi();
            this.windows = new System.Windows.Forms.Panel();
            this.expense_his_btn = new System.Windows.Forms.Button();
            this.profit_view_btn = new System.Windows.Forms.Button();
            this.modify_infor_panel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.search_tb = new System.Windows.Forms.TextBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.fix_btn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tong_tb = new System.Windows.Forms.TextBox();
            this.thoigian_tb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pvs_tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tiennuoc_tb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tiendien_tb = new System.Windows.Forms.TextBox();
            this.pnvl_tb = new System.Windows.Forms.TextBox();
            this.luongnv_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ChiTieu_dtg = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spent_his_panel = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label13 = new System.Windows.Forms.Label();
            this.CHITableAdapter = new QuanLyQuanTraSua.QuanLiTableAdapters.CHITableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CHIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).BeginInit();
            this.windows.SuspendLayout();
            this.modify_infor_panel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChiTieu_dtg)).BeginInit();
            this.spent_his_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CHIBindingSource
            // 
            this.CHIBindingSource.DataMember = "CHI";
            this.CHIBindingSource.DataSource = this.QuanLi;
            // 
            // QuanLi
            // 
            this.QuanLi.DataSetName = "QuanLi";
            this.QuanLi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // windows
            // 
            this.windows.Controls.Add(this.expense_his_btn);
            this.windows.Controls.Add(this.profit_view_btn);
            this.windows.Controls.Add(this.modify_infor_panel);
            this.windows.Controls.Add(this.spent_his_panel);
            this.windows.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windows.Location = new System.Drawing.Point(18, 19);
            this.windows.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.windows.Name = "windows";
            this.windows.Size = new System.Drawing.Size(2175, 1031);
            this.windows.TabIndex = 1;
            // 
            // expense_his_btn
            // 
            this.expense_his_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.expense_his_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.expense_his_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expense_his_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.History_icon;
            this.expense_his_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.expense_his_btn.Location = new System.Drawing.Point(1036, 5);
            this.expense_his_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.expense_his_btn.Name = "expense_his_btn";
            this.expense_his_btn.Size = new System.Drawing.Size(386, 69);
            this.expense_his_btn.TabIndex = 5;
            this.expense_his_btn.Text = "Lịch sử chi tiêu";
            this.expense_his_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.expense_his_btn.UseVisualStyleBackColor = true;
            this.expense_his_btn.Click += new System.EventHandler(this.expense_his_btn_Click);
            // 
            // profit_view_btn
            // 
            this.profit_view_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.profit_view_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.profit_view_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profit_view_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.History_icon;
            this.profit_view_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profit_view_btn.Location = new System.Drawing.Point(642, 5);
            this.profit_view_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.profit_view_btn.Name = "profit_view_btn";
            this.profit_view_btn.Size = new System.Drawing.Size(386, 69);
            this.profit_view_btn.TabIndex = 3;
            this.profit_view_btn.Text = "Cập nhật chi phí";
            this.profit_view_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.profit_view_btn.UseVisualStyleBackColor = true;
            this.profit_view_btn.Click += new System.EventHandler(this.profit_view_btn_Click);
            // 
            // modify_infor_panel
            // 
            this.modify_infor_panel.Controls.Add(this.label9);
            this.modify_infor_panel.Controls.Add(this.textBox1);
            this.modify_infor_panel.Controls.Add(this.label2);
            this.modify_infor_panel.Controls.Add(this.label1);
            this.modify_infor_panel.Controls.Add(this.save_btn);
            this.modify_infor_panel.Controls.Add(this.search_tb);
            this.modify_infor_panel.Controls.Add(this.search_btn);
            this.modify_infor_panel.Controls.Add(this.fix_btn);
            this.modify_infor_panel.Controls.Add(this.panel3);
            this.modify_infor_panel.Controls.Add(this.ChiTieu_dtg);
            this.modify_infor_panel.Location = new System.Drawing.Point(21, 83);
            this.modify_infor_panel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.modify_infor_panel.Name = "modify_infor_panel";
            this.modify_infor_panel.Size = new System.Drawing.Size(2136, 944);
            this.modify_infor_panel.TabIndex = 9;
            this.modify_infor_panel.Visible = false;
            this.modify_infor_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.modify_infor_panel_Paint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1904, 69);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 33);
            this.label9.TabIndex = 45;
            this.label9.Text = "Nhập năm";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(314, 59);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(430, 45);
            this.textBox1.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 37);
            this.label2.TabIndex = 30;
            this.label2.Text = "Tính đến ngày: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 37);
            this.label1.TabIndex = 29;
            this.label1.Text = "Bảng doanh thu tháng này: ";
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.save_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.save_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.check;
            this.save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save_btn.Location = new System.Drawing.Point(434, 819);
            this.save_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(364, 91);
            this.save_btn.TabIndex = 28;
            this.save_btn.Text = "Lưu thông tin";
            this.save_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // search_tb
            // 
            this.search_tb.Location = new System.Drawing.Point(1436, 59);
            this.search_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.search_tb.Name = "search_tb";
            this.search_tb.Size = new System.Drawing.Size(457, 45);
            this.search_tb.TabIndex = 27;
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.Color.LightSlateGray;
            this.search_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.search_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.search_flat;
            this.search_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.search_btn.Location = new System.Drawing.Point(1155, 47);
            this.search_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(248, 69);
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
            this.fix_btn.Location = new System.Drawing.Point(66, 819);
            this.fix_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fix_btn.Name = "fix_btn";
            this.fix_btn.Size = new System.Drawing.Size(358, 91);
            this.fix_btn.TabIndex = 25;
            this.fix_btn.Text = "Cập nhật chi tiêu";
            this.fix_btn.UseVisualStyleBackColor = false;
            this.fix_btn.Click += new System.EventHandler(this.fix_btn_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tong_tb);
            this.panel3.Controls.Add(this.thoigian_tb);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.pvs_tb);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.tiennuoc_tb);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.tiendien_tb);
            this.panel3.Controls.Add(this.pnvl_tb);
            this.panel3.Controls.Add(this.luongnv_tb);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(26, 170);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(857, 610);
            this.panel3.TabIndex = 24;
            // 
            // tong_tb
            // 
            this.tong_tb.Location = new System.Drawing.Point(254, 462);
            this.tong_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tong_tb.Name = "tong_tb";
            this.tong_tb.Size = new System.Drawing.Size(487, 45);
            this.tong_tb.TabIndex = 43;
            // 
            // thoigian_tb
            // 
            this.thoigian_tb.Location = new System.Drawing.Point(332, 97);
            this.thoigian_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thoigian_tb.Name = "thoigian_tb";
            this.thoigian_tb.Size = new System.Drawing.Size(486, 45);
            this.thoigian_tb.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 475);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 37);
            this.label7.TabIndex = 40;
            this.label7.Text = "Tổng cộng: ";
            // 
            // pvs_tb
            // 
            this.pvs_tb.Location = new System.Drawing.Point(332, 389);
            this.pvs_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pvs_tb.Name = "pvs_tb";
            this.pvs_tb.Size = new System.Drawing.Size(487, 45);
            this.pvs_tb.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 394);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 37);
            this.label6.TabIndex = 38;
            this.label6.Text = "Phí vệ sinh:";
            // 
            // tiennuoc_tb
            // 
            this.tiennuoc_tb.Location = new System.Drawing.Point(332, 328);
            this.tiennuoc_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tiennuoc_tb.Name = "tiennuoc_tb";
            this.tiennuoc_tb.Size = new System.Drawing.Size(487, 45);
            this.tiennuoc_tb.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 333);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 37);
            this.label8.TabIndex = 36;
            this.label8.Text = "Tiền nước:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 37);
            this.label5.TabIndex = 35;
            this.label5.Text = "Thời gian: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(341, 37);
            this.label4.TabIndex = 34;
            this.label4.Text = "THÔNG TIN CHI TIÊU";
            // 
            // tiendien_tb
            // 
            this.tiendien_tb.Location = new System.Drawing.Point(332, 270);
            this.tiendien_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tiendien_tb.Name = "tiendien_tb";
            this.tiendien_tb.Size = new System.Drawing.Size(486, 45);
            this.tiendien_tb.TabIndex = 29;
            // 
            // pnvl_tb
            // 
            this.pnvl_tb.Location = new System.Drawing.Point(332, 212);
            this.pnvl_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnvl_tb.Name = "pnvl_tb";
            this.pnvl_tb.Size = new System.Drawing.Size(486, 45);
            this.pnvl_tb.TabIndex = 28;
            // 
            // luongnv_tb
            // 
            this.luongnv_tb.Location = new System.Drawing.Point(332, 155);
            this.luongnv_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.luongnv_tb.Name = "luongnv_tb";
            this.luongnv_tb.Size = new System.Drawing.Size(486, 45);
            this.luongnv_tb.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 275);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 37);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tiền điện:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 217);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(305, 37);
            this.label11.TabIndex = 25;
            this.label11.Text = "Phí nguyên liệu:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 159);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(305, 37);
            this.label12.TabIndex = 24;
            this.label12.Text = "Lương Nhân viên:";
            // 
            // ChiTieu_dtg
            // 
            this.ChiTieu_dtg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ChiTieu_dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChiTieu_dtg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column8,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.ChiTieu_dtg.Location = new System.Drawing.Point(932, 170);
            this.ChiTieu_dtg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChiTieu_dtg.Name = "ChiTieu_dtg";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ChiTieu_dtg.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ChiTieu_dtg.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ChiTieu_dtg.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ChiTieu_dtg.RowTemplate.Height = 24;
            this.ChiTieu_dtg.Size = new System.Drawing.Size(1180, 712);
            this.ChiTieu_dtg.TabIndex = 7;
            this.ChiTieu_dtg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChiTieu_dtg_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Nam";
            this.Column1.HeaderText = "Năm";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 116;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Thang";
            this.Column8.HeaderText = "Tháng";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 152;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "LuongNV";
            this.Column2.HeaderText = "Lương NV";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 157;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "PhiNguyenLieu";
            this.Column3.HeaderText = "Phí nguyên liệu";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 303;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TienDien";
            this.Column4.HeaderText = "Tiền điện";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 141;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TienNuoc";
            this.Column5.HeaderText = "Tiền nước";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 141;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "PhiVeSinh";
            this.Column6.HeaderText = "Phí vệ sinh";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 173;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Tong";
            this.Column7.HeaderText = "Tổng";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 134;
            // 
            // spent_his_panel
            // 
            this.spent_his_panel.Controls.Add(this.reportViewer1);
            this.spent_his_panel.Controls.Add(this.label13);
            this.spent_his_panel.Location = new System.Drawing.Point(21, 83);
            this.spent_his_panel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.spent_his_panel.Name = "spent_his_panel";
            this.spent_his_panel.Size = new System.Drawing.Size(2136, 944);
            this.spent_his_panel.TabIndex = 10;
            this.spent_his_panel.Visible = false;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CHIBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.ReportChiPhi.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(212, 105);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1733, 766);
            this.reportViewer1.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 16);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(305, 37);
            this.label13.TabIndex = 0;
            this.label13.Text = "Lịch sử chi tiêu";
            // 
            // CHITableAdapter
            // 
            this.CHITableAdapter.ClearBeforeFill = true;
            // 
            // FormChiPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2223, 1177);
            this.Controls.Add(this.windows);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormChiPhi";
            this.Text = "FormChiPhi";
            this.Load += new System.EventHandler(this.FormChiPhi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CHIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).EndInit();
            this.windows.ResumeLayout(false);
            this.modify_infor_panel.ResumeLayout(false);
            this.modify_infor_panel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChiTieu_dtg)).EndInit();
            this.spent_his_panel.ResumeLayout(false);
            this.spent_his_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel windows;
        private System.Windows.Forms.Button profit_view_btn;
        private System.Windows.Forms.Button expense_his_btn;
        private System.Windows.Forms.Panel modify_infor_panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.TextBox search_tb;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button fix_btn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tiendien_tb;
        private System.Windows.Forms.TextBox pnvl_tb;
        private System.Windows.Forms.TextBox luongnv_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView ChiTieu_dtg;
        private System.Windows.Forms.Panel spent_his_panel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox pvs_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tiennuoc_tb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox thoigian_tb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tong_tb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CHIBindingSource;
        private QuanLi QuanLi;
        private QuanLiTableAdapters.CHITableAdapter CHITableAdapter;
    }
}