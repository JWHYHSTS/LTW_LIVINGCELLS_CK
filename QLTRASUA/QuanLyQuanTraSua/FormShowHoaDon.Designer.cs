
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShowHoaDon));
            this.BangChiTietHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLi = new QuanLyQuanTraSua.QuanLi();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BangHoaDonTableAdapter = new QuanLyQuanTraSua.QuanLiTableAdapters.BangHoaDonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BangChiTietHoaDonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).BeginInit();
            this.SuspendLayout();
            // 
            // BangChiTietHoaDonBindingSource
            // 
            this.BangChiTietHoaDonBindingSource.DataMember = "BangChiTietHoaDon";
            this.BangChiTietHoaDonBindingSource.DataSource = this.QuanLi;
            // 
            // QuanLi
            // 
            this.QuanLi.DataSetName = "QuanLi";
            this.QuanLi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BangChiTietHoaDonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.ReportDetailHoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(33, 42);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1446, 872);
            this.reportViewer1.TabIndex = 0;
            // 
            // BangHoaDonTableAdapter
            // 
            this.BangHoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // FormShowHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 961);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormShowHoaDon";
            this.Text = "FormShowHoaDon";
            this.Load += new System.EventHandler(this.FormShowHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BangChiTietHoaDonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BangChiTietHoaDonBindingSource;
        private QuanLi QuanLi;
        private QuanLiTableAdapters.BangHoaDonTableAdapter BangHoaDonTableAdapter;
    }
}