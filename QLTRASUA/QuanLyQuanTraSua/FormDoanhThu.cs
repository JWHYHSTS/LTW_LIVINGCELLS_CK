using QuanLyQuanTraSua.BS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanTraSua
{
    public partial class FormDoanhThu : Form
    {

        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        QueryDoanhThu dbDT = new QueryDoanhThu();
        DateTime today = DateTime.Now;
        public FormDoanhThu()
        {
            InitializeComponent();
            num_year.Minimum = 2000;
            num_year.Maximum = DateTime.Now.Year + 10; // luôn đủ lớn
            num_year.Value = DateTime.Now.Year;      // gán sau khi set min/max
        }

        private void profit_view_btn_Click(object sender, EventArgs e)
        {
            profit_panel.Visible = true;
            DateTime now = DateTime.Now;
            this_month.Text = now.ToString("MM/yyyy");
            this_day.Text = now.ToString("dd/MM");

            // Không cần gán num_year.Value ở đây nữa
            CapNhatDoanhThu();
        }

        private void CapNhatDoanhThu()
        {
            float doanhthu = 0;
            int donhang = 0;
            dbDT.CapNhatDoanhThu(today);
            dbDT.CapNhatDoanhThuThang(today, out doanhthu,out donhang);
            now_order.Text = donhang.ToString();
            now_income.Text = doanhthu.ToString();
        }

        private void FormDoanhThu_Load(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            try
            {
                this.DOANHTHUTableAdapter.FillBy(this.QuanLi.DOANHTHU, (int)num_year.Value);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void num_year_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
