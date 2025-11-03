
namespace QuanLyQuanTraSua
{
    partial class FormLoiNhuan
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
            this.nam = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsloinhuan_bt = new System.Windows.Forms.Button();
            this.profit_view_btn = new System.Windows.Forms.Button();
            this.LOINHUANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLi = new QuanLyQuanTraSua.QuanLi();
            this.LOINHUANTableAdapter = new QuanLyQuanTraSua.QuanLiTableAdapters.LOINHUANTableAdapter();
            this.windows.SuspendLayout();
            this.profit_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LOINHUANBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).BeginInit();
            this.SuspendLayout();
            // 
            // windows
            // 
            this.windows.Controls.Add(this.profit_panel);
            this.windows.Controls.Add(this.profit_view_btn);
            this.windows.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windows.Location = new System.Drawing.Point(12, 12);
            this.windows.Name = "windows";
            this.windows.Size = new System.Drawing.Size(1450, 660);
            this.windows.TabIndex = 1;
            // 
            // profit_panel
            // 
            this.profit_panel.Controls.Add(this.nam);
            this.profit_panel.Controls.Add(this.reportViewer1);
            this.profit_panel.Controls.Add(this.dsloinhuan_bt);
            this.profit_panel.Location = new System.Drawing.Point(13, 53);
            this.profit_panel.Name = "profit_panel";
            this.profit_panel.Size = new System.Drawing.Size(1424, 592);
            this.profit_panel.TabIndex = 4;
            this.profit_panel.Visible = false;
            // 
            // nam
            // 
            this.nam.CustomFormat = "yyyy";
            this.nam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nam.Location = new System.Drawing.Point(423, 25);
            this.nam.MaxDate = new System.DateTime(2023, 12, 31, 0, 0, 0, 0);
            this.nam.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.nam.Name = "nam";
            this.nam.ShowUpDown = true;
            this.nam.Size = new System.Drawing.Size(126, 31);
            this.nam.TabIndex = 15;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.LOINHUANBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.ReportLoiNhuan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(22, 69);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1380, 508);
            this.reportViewer1.TabIndex = 14;
            // 
            // dsloinhuan_bt
            // 
            this.dsloinhuan_bt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dsloinhuan_bt.ForeColor = System.Drawing.Color.Red;
            this.dsloinhuan_bt.Location = new System.Drawing.Point(22, 22);
            this.dsloinhuan_bt.Name = "dsloinhuan_bt";
            this.dsloinhuan_bt.Size = new System.Drawing.Size(395, 41);
            this.dsloinhuan_bt.TabIndex = 12;
            this.dsloinhuan_bt.Text = "Lợi Nhuận Các Tháng Năm";
            this.dsloinhuan_bt.UseVisualStyleBackColor = false;
            this.dsloinhuan_bt.Click += new System.EventHandler(this.dsloinhuan_bt_Click);
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
            this.profit_view_btn.Text = "Xem lợi nhuận";
            this.profit_view_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.profit_view_btn.UseVisualStyleBackColor = true;
            this.profit_view_btn.Click += new System.EventHandler(this.profit_view_btn_Click);
            // 
            // LOINHUANBindingSource
            // 
            this.LOINHUANBindingSource.DataMember = "LOINHUAN";
            this.LOINHUANBindingSource.DataSource = this.QuanLi;
            // 
            // QuanLi
            // 
            this.QuanLi.DataSetName = "QuanLi";
            this.QuanLi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LOINHUANTableAdapter
            // 
            this.LOINHUANTableAdapter.ClearBeforeFill = true;
            // 
            // FormLoiNhuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.windows);
            this.Name = "FormLoiNhuan";
            this.Text = "FormLoiNhuan";
            this.Load += new System.EventHandler(this.FormLoiNhuan_Load);
            this.windows.ResumeLayout(false);
            this.profit_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LOINHUANBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel windows;
        private System.Windows.Forms.Panel profit_panel;
        private System.Windows.Forms.Button profit_view_btn;
        private System.Windows.Forms.Button dsloinhuan_bt;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker nam;
        private System.Windows.Forms.BindingSource LOINHUANBindingSource;
        private QuanLi QuanLi;
        private QuanLiTableAdapters.LOINHUANTableAdapter LOINHUANTableAdapter;
    }
}