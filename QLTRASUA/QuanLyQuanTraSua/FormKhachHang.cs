using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // OK nếu mờ: file này không dùng LINQ trực tiếp
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using QuanLyQuanTraSua.BS_Layer;

namespace QuanLyQuanTraSua
{
    public partial class FormKhachHang : Form
    {
        DataTable dtKhachHang = null;
        string err;
        QueryKhachHang dbTP = new QueryKhachHang();

        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void diemtichluyKH_lb_Click(object sender, EventArgs e) { }

        private void view_btn_Click(object sender, EventArgs e)
        {
            modify_infor_panel.Visible = false;
            report_panel.Visible = true;
            report_panel.BringToFront();

            reportViewer3.Visible = true;
            reportViewer1.Visible = false;
            reportViewer2.Visible = false;
            reportViewer3.BringToFront();

            try
            {
                this.KHACHHANGTableAdapter.Fill(this.QuanLi.KHACHHANG);
                this.reportViewer3.RefreshReport();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không tải được dữ liệu khách hàng từ CSDL.", "Lỗi");
            }
        }

        private void modify_btn_Click(object sender, EventArgs e)
        {
            modify_infor_panel.Visible = true;
            report_panel.Visible = false;
            modify_infor_panel.BringToFront();
            LoadData();
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            LoadDataTimKiem(search_tb.Text);
        }

        void LoadData()
        {
            try
            {
                dtKhachHang = dbTP.LayKhachHang();

                KhachHang_dtg.AutoGenerateColumns = true;
                KhachHang_dtg.DataSource = dtKhachHang;
                KhachHang_dtg.AutoResizeColumns();

                diachiKH_tb.ResetText();
                sdtKH_tb.ResetText();
                tenKH_tb.ResetText();

                panel3.Enabled = false;
                save_btn.Enabled = false;
                fix_btn.Enabled = true;

                // Hiển thị bản ghi đầu tiên nếu có
                if (KhachHang_dtg.Rows.Count > 0)
                    KhachHang_dtg_CellClick(null, null);
                else
                {
                    maKH_lb.Text = "";
                    diemtichluyKH_lb.Text = "0";
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng KHACHHANG.", "Lỗi");
            }
        }

        void LoadDataTimKiem(string makh)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(makh))
                {
                    LoadData();
                    return;
                }

                dtKhachHang = dbTP.LayThongTin(makh);

                KhachHang_dtg.AutoGenerateColumns = true;
                KhachHang_dtg.DataSource = dtKhachHang;
                KhachHang_dtg.AutoResizeColumns();

                panel3.Enabled = false;
                save_btn.Enabled = false;
                fix_btn.Enabled = true;

                if (KhachHang_dtg.Rows.Count > 0)
                    KhachHang_dtg_CellClick(null, null);
                else
                {
                    // Clear form nếu không có kết quả
                    maKH_lb.Text = "";
                    tenKH_tb.Text = "";
                    sdtKH_tb.Text = "";
                    diachiKH_tb.Text = "";
                    diemtichluyKH_lb.Text = "0";
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng KHACHHANG.", "Lỗi");
            }
        }

        private void fix_btn_Click(object sender, EventArgs e)
        {
            panel3.Enabled = true;
            save_btn.Enabled = true;
            tenKH_tb.Focus();
        }

        private void KhachHang_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (KhachHang_dtg.CurrentCell == null) return;
            int r = KhachHang_dtg.CurrentCell.RowIndex;
            if (r < 0 || r >= KhachHang_dtg.Rows.Count) return;

            try
            {
                var row = KhachHang_dtg.Rows[r];
                // Cột: MaKH(0) | TenKH(1) | SDT(2) | DiaChi(3) | DiemTichLuy(4)
                maKH_lb.Text = row.Cells[0].Value?.ToString() ?? "";
                tenKH_tb.Text = row.Cells[1].Value?.ToString() ?? "";
                sdtKH_tb.Text = row.Cells[2].Value?.ToString() ?? "";
                diachiKH_tb.Text = row.Cells[3].Value?.ToString() ?? "";
                diemtichluyKH_lb.Text = row.Cells[4].Value?.ToString() ?? "0";
            }
            catch
            {
                // Nếu có lỗi dữ liệu ô thì bỏ qua tránh crash
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maKH_lb.Text))
            {
                MessageBox.Show("Chưa chọn khách hàng.", "Thông báo");
                return;
            }

            try
            {
                var blTp = new QueryKhachHang();
                blTp.CapNhatKhachHang(maKH_lb.Text, tenKH_tb.Text, diachiKH_tb.Text, sdtKH_tb.Text, ref err);

                LoadData();
                MessageBox.Show("Đã sửa xong!", "Thông báo");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không cập nhật được khách hàng. Lỗi CSDL!", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không cập nhật được khách hàng: " + ex.Message, "Lỗi");
            }
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            // để trống theo cấu trúc cũ
        }

        private void timkiem_bt_Click(object sender, EventArgs e)
        {
            try
            {
                this.TongQuatKhachHangTableAdapter.Fill(this.QuanLi.BangTongQuatKhachHang, maKH_tk.Text);
                this.BangChiTietKhachHangTableAdapter.Fill(this.QuanLi.BangChiTietKhachHang, maKH_tk.Text);

                this.reportViewer1.RefreshReport();
                this.reportViewer2.RefreshReport();

                reportViewer3.Visible = false;
                reportViewer1.Visible = true;
                reportViewer2.Visible = false;
                reportViewer1.BringToFront();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không tải được báo cáo khách hàng từ CSDL.", "Lỗi");
            }
        }

        private void chitiet_bt_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewer3.Visible = false;
                reportViewer1.Visible = false;
                reportViewer2.Visible = true;

                this.BangChiTietKhachHangTableAdapter.Fill(this.QuanLi.BangChiTietKhachHang, maKH_tk.Text);
                this.reportViewer2.RefreshReport();
                reportViewer2.BringToFront();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không tải được báo cáo chi tiết từ CSDL.", "Lỗi");
            }
        }

        private void all_KH_btn_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewer3.Visible = true;
                reportViewer1.Visible = false;
                reportViewer2.Visible = false;
                reportViewer3.BringToFront();

                this.KHACHHANGTableAdapter.Fill(this.QuanLi.KHACHHANG);
                this.reportViewer3.RefreshReport();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không tải được danh sách khách hàng từ CSDL.", "Lỗi");
            }
        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                KhachHang_dtg.AutoGenerateColumns = true;
                KhachHang_dtg.DataSource = dbTP.LocKhachHang(search_tb.Text);
                KhachHang_dtg.AutoResizeColumns();
            }
            catch (SqlException)
            {
                // Nếu lỗi truy vấn, không crash UI
            }
        }
    }
}
