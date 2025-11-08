
namespace QuanLyQuanTraSua
{
    partial class FormDoanhThu
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
            this.windows = new System.Windows.Forms.Panel();
            this.profit_panel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.this_month = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.now_income = new System.Windows.Forms.Label();
            this.now_order = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.this_day = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.show_btn = new System.Windows.Forms.Button();
            this.by_year = new System.Windows.Forms.RadioButton();
            this.num_year = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.profit_view_btn = new System.Windows.Forms.Button();
            this.DOANHTHUBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLi = new QuanLyQuanTraSua.QuanLi();
            this.DOANHTHUTableAdapter = new QuanLyQuanTraSua.QuanLiTableAdapters.DOANHTHUTableAdapter();
            this.windows.SuspendLayout();
            this.profit_panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOANHTHUBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).BeginInit();
            this.SuspendLayout();
            // 
            // windows
            // 
            this.windows.Controls.Add(this.profit_panel);
            this.windows.Controls.Add(this.profit_view_btn);
            this.windows.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windows.Location = new System.Drawing.Point(20, 25);
            this.windows.Name = "windows";
            this.windows.Size = new System.Drawing.Size(1450, 660);
            this.windows.TabIndex = 0;
            // 
            // profit_panel
            // 
            this.profit_panel.Controls.Add(this.groupBox1);
            this.profit_panel.Controls.Add(this.reportViewer1);
            this.profit_panel.Controls.Add(this.show_btn);
            this.profit_panel.Controls.Add(this.by_year);
            this.profit_panel.Controls.Add(this.num_year);
            this.profit_panel.Controls.Add(this.label3);
            this.profit_panel.Location = new System.Drawing.Point(14, 53);
            this.profit_panel.Name = "profit_panel";
            this.profit_panel.Size = new System.Drawing.Size(1424, 640);
            this.profit_panel.TabIndex = 4;
            this.profit_panel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.this_month);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.now_income);
            this.groupBox1.Controls.Add(this.now_order);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.this_day);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(46, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1297, 101);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doanh thu tháng này";
            // 
            // this_month
            // 
            this.this_month.AutoSize = true;
            this.this_month.Location = new System.Drawing.Point(143, 29);
            this.this_month.Name = "this_month";
            this.this_month.Size = new System.Drawing.Size(76, 23);
            this.this_month.TabIndex = 36;
            this.this_month.Text = "label2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 23);
            this.label6.TabIndex = 35;
            this.label6.Text = "Tháng: ";
            // 
            // now_income
            // 
            this.now_income.AutoSize = true;
            this.now_income.Location = new System.Drawing.Point(661, 62);
            this.now_income.Name = "now_income";
            this.now_income.Size = new System.Drawing.Size(76, 23);
            this.now_income.TabIndex = 33;
            this.now_income.Text = "label2";
            // 
            // now_order
            // 
            this.now_order.AutoSize = true;
            this.now_order.Location = new System.Drawing.Point(661, 29);
            this.now_order.Name = "now_order";
            this.now_order.Size = new System.Drawing.Size(76, 23);
            this.now_order.TabIndex = 32;
            this.now_order.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(506, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "Doanh thu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(506, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 29;
            this.label1.Text = "Số đơn hàng:";
            // 
            // this_day
            // 
            this.this_day.AutoSize = true;
            this.this_day.Location = new System.Drawing.Point(231, 62);
            this.this_day.Name = "this_day";
            this.this_day.Size = new System.Drawing.Size(76, 23);
            this.this_day.TabIndex = 28;
            this.this_day.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tính đến ngày: ";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DOANHTHUBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.ReportDoanhThuNam.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(46, 189);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1297, 415);
            this.reportViewer1.TabIndex = 22;
            // 
            // show_btn
            // 
            this.show_btn.BackColor = System.Drawing.Color.PaleGreen;
            this.show_btn.Location = new System.Drawing.Point(461, 130);
            this.show_btn.Name = "show_btn";
            this.show_btn.Size = new System.Drawing.Size(140, 53);
            this.show_btn.TabIndex = 21;
            this.show_btn.Text = "Hiển thị";
            this.show_btn.UseVisualStyleBackColor = false;
            this.show_btn.Click += new System.EventHandler(this.show_btn_Click);
            // 
            // by_year
            // 
            this.by_year.AutoSize = true;
            this.by_year.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by_year.Location = new System.Drawing.Point(271, 143);
            this.by_year.Name = "by_year";
            this.by_year.Size = new System.Drawing.Size(64, 27);
            this.by_year.TabIndex = 19;
            this.by_year.TabStop = true;
            this.by_year.Text = "Năm";
            this.by_year.UseVisualStyleBackColor = true;
            // 
            // num_year
            // 
            this.num_year.Location = new System.Drawing.Point(341, 143);
            this.num_year.Maximum = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.num_year.Minimum = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.num_year.Name = "num_year";
            this.num_year.Size = new System.Drawing.Size(80, 31);
            this.num_year.TabIndex = 16;
            this.num_year.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.num_year.ValueChanged += new System.EventHandler(this.num_year_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Thống kê doanh thu:";
            // 
            // profit_view_btn
            // 
            this.profit_view_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.profit_view_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.profit_view_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profit_view_btn.Image = global::QuanLyQuanTraSua.Properties.Resources.History_icon;
            this.profit_view_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profit_view_btn.Location = new System.Drawing.Point(601, 3);
            this.profit_view_btn.Name = "profit_view_btn";
            this.profit_view_btn.Size = new System.Drawing.Size(257, 44);
            this.profit_view_btn.TabIndex = 3;
            this.profit_view_btn.Text = "Xem doanh thu";
            this.profit_view_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.profit_view_btn.UseVisualStyleBackColor = true;
            this.profit_view_btn.Click += new System.EventHandler(this.profit_view_btn_Click);
            // 
            // DOANHTHUBindingSource
            // 
            this.DOANHTHUBindingSource.DataMember = "DOANHTHU";
            this.DOANHTHUBindingSource.DataSource = this.QuanLi;
            // 
            // QuanLi
            // 
            this.QuanLi.DataSetName = "QuanLi";
            this.QuanLi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DOANHTHUTableAdapter
            // 
            this.DOANHTHUTableAdapter.ClearBeforeFill = true;
            // 
            // FormDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.windows);
            this.Name = "FormDoanhThu";
            this.Text = "FormDoanhThu";
            this.Load += new System.EventHandler(this.FormDoanhThu_Load);
            this.windows.ResumeLayout(false);
            this.profit_panel.ResumeLayout(false);
            this.profit_panel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOANHTHUBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button profit_view_btn;
        public System.Windows.Forms.Panel windows;
        private System.Windows.Forms.Panel profit_panel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_year;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button show_btn;
        private System.Windows.Forms.RadioButton by_year;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label this_month;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label now_income;
        private System.Windows.Forms.Label now_order;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label this_day;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource DOANHTHUBindingSource;
        private QuanLi QuanLi;
        private QuanLiTableAdapters.DOANHTHUTableAdapter DOANHTHUTableAdapter;
    }
}