
namespace QuanLyQuanTraSua
{
    partial class FormShowHoaDon
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLi = new QuanLyQuanTraSua.QuanLi();
            this.BangChiTietHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BangHoaDonTableAdapter = new QuanLyQuanTraSua.QuanLiTableAdapters.BangHoaDonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BangChiTietHoaDonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BangChiTietHoaDonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.ReportDetailHoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(22, 27);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(965, 559);
            this.reportViewer1.TabIndex = 0;
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
            // BangHoaDonTableAdapter
            // 
            this.BangHoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // FormShowHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 615);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormShowHoaDon";
            this.Text = "FormShowHoaDon";
            this.Load += new System.EventHandler(this.FormShowHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BangChiTietHoaDonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BangChiTietHoaDonBindingSource;
        private QuanLi QuanLi;
        private QuanLiTableAdapters.BangHoaDonTableAdapter BangHoaDonTableAdapter;
    }
}