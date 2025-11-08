using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanTraSua.BS_Layer;
using System.Data.SqlClient;

namespace QuanLyQuanTraSua
{
    public partial class FormNhanVien : Form
    {
        QueryNhanVien dbNhanVien = new QueryNhanVien();
        DateTime today = DateTime.Now;

        DataTable dtNhanVien = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        string err;
        QueryNhanVien dbNV = new QueryNhanVien();
        public FormNhanVien()
        {
            InitializeComponent();
            reportViewer1.Visible = true;
            reportViewer2.Visible = false;
            reportViewer3.Visible = false;
            reportViewer1.BringToFront();
        }

        private void view_btn_Click(object sender, EventArgs e)
        {
            report_panel.Visible = true;
            modify_infor_panel.Visible = false;
            salary_report_panel.Visible = false;
            report_panel.BringToFront();
            this.NHANVIENTableAdapter.Fill(this.QuanLi.NHANVIEN);
            this.reportViewer4.RefreshReport();
        }

        private void modify_btn_Click(object sender, EventArgs e)
        {
            report_panel.Visible = false;
            modify_infor_panel.Visible = true;
            salary_report_panel.Visible = false;
            modify_infor_panel.BringToFront();
            LoadData();
        }

        private void salary_btn_Click(object sender, EventArgs e)
        {
            report_panel.Visible = false;
            modify_infor_panel.Visible = false;
            salary_report_panel.Visible = true;
            salary_report_panel.BringToFront();
            ht.Text = today.ToString("dd/MM");
            TinhLuong(today.Year, today.Month);
        }

        void LoadData()
        {
            try
            {
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                dtNhanVien = dbNV.LayNhanVien();
               
                // Đưa dữ liệu lên DataGridView 
                NhanVien_dtg.DataSource = dtNhanVien;
                // Thay đổi độ rộng cột 
                NhanVien_dtg.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel 
                this.maNV_tb.ResetText();
                this.tenNV_tb.ResetText();
                this.sdtNV_tb.ResetText();
                this.diachiNV_tb.ResetText();
                this.cmndNV_tb.ResetText();

                // Không cho thao tác trên các nút Lưu / Hủy 
                this.save_btn.Enabled = false;
                AddNV_btn.Enabled = true;
                this.AddNV_btn.Enabled = true;
                this.fix_btn.Enabled = true;
                this.DeleteNV_btn.Enabled = true;
                this.panel3.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.search_btn.Enabled = true;
                this.view_btn.Enabled = true;

                //
                //NhanVien_dtg_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KhachHang. Lỗi rồi!!!");
            }
        }

        private void TinhLuong(int year, int month)
        {
            dbNhanVien.CapNhatBangLuong();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            if (rdb_this_month.Checked == true)
            {
                DateTime today = DateTime.Now;
                // TODO: This line of code loads data into the 'QuanLi.QUANLYLUONG' table. You can move, or remove it, as needed.
                this.QUANLYLUONGTableAdapter.Fill(this.QuanLi.QUANLYLUONG, new DateTime(today.Year, today.Month, 1).ToString("yyyy-MM-dd"), new DateTime(today.Year, today.Month, today.Day).ToString("yyyy-MM-dd"));
                this.reportViewer1.RefreshReport();

                reportViewer1.Visible = true;
                reportViewer2.Visible = false;
                reportViewer3.Visible = false;
                reportViewer1.BringToFront();
            }
            else if (rbt_old_month.Checked == true)
            {
                reportViewer1.Visible = false;
                reportViewer2.Visible = true;
                reportViewer3.Visible = false;

                reportViewer2.BringToFront();

                // TODO: This line of code loads data into the 'QuanLi.QUANLYLUONG' table. You can move, or remove it, as needed.
                this.BangLuongThangTableAdapter.Fill(this.QuanLi.BangLuongThang, time1.Value.Year, time1.Value.Month);
                this.reportViewer2.RefreshReport();

            }
            else if (search_NV.Checked == true)
            {
                // TODO: This line of code loads data into the 'QuanLi.QUANLYLUONG' table. You can move, or remove it, as needed.
                this.BangChiTietLuongNVTableAdapter.Fill(this.QuanLi.BangChiTietLuongNV, new DateTime(time2.Value.Year, time2.Value.Month, 1).ToString("yyyy-MM-dd"), new DateTime(time2.Value.Year, time2.Value.Month, DateTime.DaysInMonth(time2.Value.Year, time2.Value.Month)).ToString("yyyy-MM-dd"), maNV_txt.Text);
                this.reportViewer3.RefreshReport();

                reportViewer1.Visible = false;
                reportViewer2.Visible = false;
                reportViewer3.Visible = true;
                reportViewer3.BringToFront();
            }
            else if (temp_salary.Checked==true)
            {
                DataTable tb=dbNhanVien.TinhLuongTam(today.Year, today.Month, today.Day);
                temp_salary_dtg.DataSource = tb;

                reportViewer1.Visible = false;
                reportViewer2.Visible = false;
                reportViewer3.Visible = false;

                temp_salary_dtg.BringToFront();

            }
        }

        private void AddNV_btn_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;
            // Xóa trống các đối tượng trong Panel 
            this.maNV_tb.ResetText();
            this.tenNV_tb.ResetText();
            this.sdtNV_tb.ResetText();
            this.diachiNV_tb.ResetText();
            this.cmndNV_tb.ResetText();
            this.ngayNV_dtp.ResetText();
            this.maNV_tb.Enabled = false;
            this.maNV_tb.Text=dbNhanVien.GetLastIndex();
            // Cho thao tác trên các nút Lưu / Panel 
            this.save_btn.Enabled = true;
            this.panel3.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa  
            this.AddNV_btn.Enabled = false;
            this.fix_btn.Enabled = false;
            this.DeleteNV_btn.Enabled = false;
            this.tenNV_tb.Focus();
        }

        private void DeleteNV_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh 
                // Lấy thứ tự record hiện hành 
                int r = NhanVien_dtg.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strNHANVIEN = NhanVien_dtg.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL 
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Chắc xóa nhân viên này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                if (traloi == DialogResult.Yes)
                {
                    dbNhanVien.XoaNhanVien(ref err, strNHANVIEN);
                    // Cập nhật lại DataGridView 
                    LoadData();
                    // Thông báo 
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa Nhân viên!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void fix_btn_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel3.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.save_btn.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.AddNV_btn.Enabled = false;
            this.fix_btn.Enabled = false;
            this.DeleteNV_btn.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH 
            this.maNV_tb.Enabled = false;
            this.tenNV_tb.Focus();
        }

        private void NhanVien_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = NhanVien_dtg.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            if (NhanVien_dtg.Rows[r].Cells[0].Value != null)
            {
                this.maNV_tb.Text = NhanVien_dtg.Rows[r].Cells[0].Value.ToString();
                this.tenNV_tb.Text = NhanVien_dtg.Rows[r].Cells[1].Value.ToString();
                this.sdtNV_tb.Text = NhanVien_dtg.Rows[r].Cells[2].Value.ToString();
                this.diachiNV_tb.Text = NhanVien_dtg.Rows[r].Cells[3].Value.ToString();
                this.cmndNV_tb.Text = NhanVien_dtg.Rows[r].Cells[5].Value.ToString();
                this.ngayNV_dtp.Value = Convert.ToDateTime(NhanVien_dtg.Rows[r].Cells[4].Value.ToString());
            }
            // Không cho thao tác trên các nút Lưu / Hủy 
            this.save_btn.Enabled = false;
            AddNV_btn.Enabled = true;

            this.panel3.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
            this.search_btn.Enabled = true;
            this.view_btn.Enabled = true;
            this.AddNV_btn.Enabled = true;
            this.fix_btn.Enabled = true;
            this.DeleteNV_btn.Enabled = true;
            Them = false;
        }

        private bool CheckInfor()
        {
            foreach(Control h in panel3.Controls)
                if((string)h.Tag=="infor")
                    if (h.Text=="" || h.Text==null)
                    {
                        MessageBox.Show("Cần điền đầy đủ thông tin!", "Error");
                        return false;
                    }
            return true;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (Them)
            {
                try
                {
                    check = CheckInfor();
                    if (check == false)
                        return;
                    // Thực hiện lệnh 
                    QueryNhanVien blTp = new QueryNhanVien();
                    blTp.ThemNhanVien(this.maNV_tb.Text, this.tenNV_tb.Text, this.sdtNV_tb.Text, this.diachiNV_tb.Text,
                        this.ngayNV_dtp.Text, this.cmndNV_tb.Text, ref err);
                    // Load lại dữ liệu trên DataGridView 
                    LoadData();
                    // Thông báo 
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            else
            {
                // Thực hiện lệnh 
                QueryNhanVien blTp = new QueryNhanVien();
                blTp.CapNhatNhanVien(this.maNV_tb.Text, this.tenNV_tb.Text, this.sdtNV_tb.Text, this.diachiNV_tb.Text, this.ngayNV_dtp.Text, this.cmndNV_tb.Text, ref err);
                // Load lại dữ liệu trên DataGridView 
                LoadData();
                // Thông báo 
                MessageBox.Show("Đã sửa xong!");
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {

        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            NhanVien_dtg.DataSource=dbNhanVien.LocNhanVien(search_tb.Text);
            NhanVien_dtg.AutoResizeColumns();
        }
    }
}
