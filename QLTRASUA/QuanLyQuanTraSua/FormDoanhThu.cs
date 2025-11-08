using QuanLyQuanTraSua.BS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
// using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder; // không dùng trong WinForms này
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;    // OK nếu mờ: file này không dùng LINQ trực tiếp
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanTraSua
{
    public partial class FormDoanhThu : Form
    {
        QueryDoanhThu dbDT = new QueryDoanhThu();
        DateTime today = DateTime.Now;

        public FormDoanhThu()
        {
            InitializeComponent();

            // Thiết lập NumericUpDown sau khi InitializeComponent để tránh Overflow
            num_year.Minimum = 2000;
            num_year.Maximum = DateTime.Now.Year + 10;
            num_year.Value = DateTime.Now.Year;
        }

        private void profit_view_btn_Click(object sender, EventArgs e)
        {
            profit_panel.Visible = true;

            var now = DateTime.Now;
            this_month.Text = now.ToString("MM/yyyy");
            this_day.Text = now.ToString("dd/MM");

            CapNhatDoanhThu();
        }

        private void CapNhatDoanhThu()
        {
            try
            {
                float doanhthu = 0f;
                int donhang = 0;

                // Cập nhật dữ liệu doanh thu tháng trước (nếu chưa có bản ghi)
                dbDT.CapNhatDoanhThu(today);

                // Lấy doanh thu tạm tính tháng hiện tại
                dbDT.CapNhatDoanhThuThang(today, out doanhthu, out donhang);

                now_order.Text = donhang.ToString();
                // Định dạng đẹp mắt, không đổi kiểu dữ liệu
                now_income.Text = doanhthu.ToString("#,0.##");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể cập nhật doanh thu từ CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi khi cập nhật doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị báo cáo theo năm đã chọn
                this.DOANHTHUTableAdapter.FillBy(this.QuanLi.DOANHTHU, (int)num_year.Value);
                this.reportViewer1.RefreshReport();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không tải được báo cáo từ CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDoanhThu_Load(object sender, EventArgs e)
        {
            // để trống theo cấu trúc hiện tại
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            // để trống theo cấu trúc hiện tại
        }

        private void num_year_ValueChanged(object sender, EventArgs e)
        {
            // để trống theo cấu trúc hiện tại
        }
    }
}
