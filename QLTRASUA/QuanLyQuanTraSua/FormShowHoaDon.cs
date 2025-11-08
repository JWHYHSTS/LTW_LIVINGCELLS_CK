using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanTraSua
{
    public partial class FormShowHoaDon : Form
    {
        public string maDon = "";
        public FormShowHoaDon()
        {
            InitializeComponent();
        }

        private void FormShowHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLi.BangChiTietHoaDon' table. You can move, or remove it, as needed.
            int num=this.BangHoaDonTableAdapter.Fill(this.QuanLi.BangChiTietHoaDon, maDon);
            if (num==0)
                this.BangHoaDonTableAdapter.FillBy(this.QuanLi.BangChiTietHoaDon, maDon);
            this.reportViewer1.RefreshReport();
        }
    }
}
