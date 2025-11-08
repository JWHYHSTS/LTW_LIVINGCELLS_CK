using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 

        string err;
        QueryKhachHang dbTP = new QueryKhachHang();
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void diemtichluyKH_lb_Click(object sender, EventArgs e)
        {

        }

        private void view_btn_Click(object sender, EventArgs e)
        {
            modify_infor_panel.Visible = false;
            report_panel.Visible = true;
            report_panel.BringToFront();

            reportViewer3.Visible = true;
            reportViewer1.Visible = false;
            reportViewer2.Visible = false;

            reportViewer3.BringToFront();

            this.KHACHHANGTableAdapter.Fill(this.QuanLi.KHACHHANG);
            this.reportViewer3.RefreshReport();

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
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                dtKhachHang = dbTP.LayKhachHang();
               
                // Đưa dữ liệu lên DataGridView 
                KhachHang_dtg.DataSource = dtKhachHang;
                // Thay đổi độ rộng cột 
                KhachHang_dtg.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel 
                this.diachiKH_tb.ResetText();
                this.sdtKH_tb.ResetText();
                this.tenKH_tb.ResetText();

                // Không cho thao tác trên các nút Lưu / Hủy 
                panel3.Enabled = false;
                this.save_btn.Enabled = false;

                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.fix_btn.Enabled = true;

                //
                KhachHang_dtg_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KhachHang. Lỗi rồi!!!");
            }

        }

        void LoadDataTimKiem(string makh)
        {
            try
            {
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                dtKhachHang = dbTP.LayThongTin(makh);
                //dtKhachHang = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView 
                KhachHang_dtg.DataSource = dtKhachHang;
                // Thay đổi độ rộng cột 
                KhachHang_dtg.AutoResizeColumns();

                panel3.Enabled = false;
                this.save_btn.Enabled = false;

                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.fix_btn.Enabled = true;

                //
                KhachHang_dtg_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KhachHang. Lỗi rồi!!!");
            }

        }

        private void fix_btn_Click(object sender, EventArgs e)
        {
            
            panel3.Enabled = true;

            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            save_btn.Enabled = true;

            tenKH_tb.Focus();
        }

        private void KhachHang_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Thứ tự dòng hiện hành 
            int r = KhachHang_dtg.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            maKH_lb.Text = KhachHang_dtg.Rows[r].Cells[0].Value.ToString();
            tenKH_tb.Text = KhachHang_dtg.Rows[r].Cells[1].Value.ToString();
            sdtKH_tb.Text = KhachHang_dtg.Rows[r].Cells[2].Value.ToString();
            diachiKH_tb.Text = KhachHang_dtg.Rows[r].Cells[3].Value.ToString();
            diemtichluyKH_lb.Text = KhachHang_dtg.Rows[r].Cells[4].Value.ToString();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            // Thực hiện lệnh 
            QueryKhachHang blTp = new QueryKhachHang();
            blTp.CapNhatKhachHang(this.maKH_lb.Text, this.tenKH_tb.Text, this.diachiKH_tb.Text, this.sdtKH_tb.Text, ref err);

            // Load lại dữ liệu trên DataGridView 
            LoadData();
            // Thông báo 
            MessageBox.Show("Đã sửa xong!");
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void timkiem_bt_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLi.BangTongQuatKhachHang' table. You can move, or remove it, as needed.
            this.TongQuatKhachHangTableAdapter.Fill(this.QuanLi.BangTongQuatKhachHang, maKH_tk.Text);
            this.BangChiTietKhachHangTableAdapter.Fill(this.QuanLi.BangChiTietKhachHang, maKH_tk.Text);
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();

            reportViewer3.Visible = false;
            reportViewer1.Visible = true;
            reportViewer2.Visible = false;

            reportViewer1.BringToFront();
        }

        private void chitiet_bt_Click(object sender, EventArgs e)
        {
            reportViewer3.Visible = false;
            this.reportViewer1.Visible = false;
            reportViewer2.Visible = true;

            this.BangChiTietKhachHangTableAdapter.Fill(this.QuanLi.BangChiTietKhachHang, maKH_tk.Text);
            this.reportViewer2.RefreshReport();
            reportViewer2.BringToFront();
        }

        private void all_KH_btn_Click(object sender, EventArgs e)
        {
            reportViewer3.Visible = true;
            reportViewer1.Visible = false;
            reportViewer2.Visible = false;

            reportViewer3.BringToFront();
            // TODO: This line of code loads data into the 'QuanLi.KHACHHANG' table. You can move, or remove it, as needed.
            this.KHACHHANGTableAdapter.Fill(this.QuanLi.KHACHHANG);
            this.reportViewer3.RefreshReport();

        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            KhachHang_dtg.DataSource = dbTP.LocKhachHang(search_tb.Text);
            KhachHang_dtg.AutoResizeColumns();
        }
    }
}
