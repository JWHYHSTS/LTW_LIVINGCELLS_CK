using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // OK nếu mờ: file này không dùng LINQ trực tiếp
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

            try
            {
                this.NHANVIENTableAdapter.Fill(this.QuanLi.NHANVIEN);
                this.reportViewer4.RefreshReport(); // giữ nguyên theo project của bạn
            }
            catch (SqlException)
            {
                MessageBox.Show("Không tải được báo cáo nhân viên từ CSDL.", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi");
            }
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

                NhanVien_dtg.AutoGenerateColumns = true;
                NhanVien_dtg.DataSource = dtNhanVien;
                NhanVien_dtg.AutoResizeColumns();

                maNV_tb.ResetText();
                tenNV_tb.ResetText();
                sdtNV_tb.ResetText();
                diachiNV_tb.ResetText();
                cmndNV_tb.ResetText();

                save_btn.Enabled = false;
                AddNV_btn.Enabled = true;
                fix_btn.Enabled = true;
                DeleteNV_btn.Enabled = true;
                panel3.Enabled = false;

                search_btn.Enabled = true;
                view_btn.Enabled = true;

                // Hiển thị dòng đầu nếu có dữ liệu
                if (NhanVien_dtg.Rows.Count > 0)
                    NhanVien_dtg_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu nhân viên từ CSDL.", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void TinhLuong(int year, int month)
        {
            try
            {
                dbNhanVien.CapNhatBangLuong();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể cập nhật bảng lương.", "Lỗi");
            }
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            // giữ nguyên
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdb_this_month.Checked == true)
                {
                    DateTime d = DateTime.Now;
                    this.QUANLYLUONGTableAdapter.Fill(
                        this.QuanLi.QUANLYLUONG,
                        new DateTime(d.Year, d.Month, 1).ToString("yyyy-MM-dd"),
                        new DateTime(d.Year, d.Month, d.Day).ToString("yyyy-MM-dd"));
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

                    this.BangLuongThangTableAdapter.Fill(this.QuanLi.BangLuongThang, time1.Value.Year, time1.Value.Month);
                    this.reportViewer2.RefreshReport();
                }
                else if (search_NV.Checked == true)
                {
                    this.BangChiTietLuongNVTableAdapter.Fill(
                        this.QuanLi.BangChiTietLuongNV,
                        new DateTime(time2.Value.Year, time2.Value.Month, 1).ToString("yyyy-MM-dd"),
                        new DateTime(time2.Value.Year, time2.Value.Month, DateTime.DaysInMonth(time2.Value.Year, time2.Value.Month)).ToString("yyyy-MM-dd"),
                        maNV_txt.Text);

                    this.reportViewer3.RefreshReport();

                    reportViewer1.Visible = false;
                    reportViewer2.Visible = false;
                    reportViewer3.Visible = true;
                    reportViewer3.BringToFront();
                }
                else if (temp_salary.Checked == true)
                {
                    DataTable tb = dbNhanVien.TinhLuongTam(today.Year, today.Month, today.Day);
                    temp_salary_dtg.AutoGenerateColumns = true;
                    temp_salary_dtg.DataSource = tb;

                    reportViewer1.Visible = false;
                    reportViewer2.Visible = false;
                    reportViewer3.Visible = false;
                    temp_salary_dtg.BringToFront();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không tải được báo cáo lương từ CSDL.", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị báo cáo: " + ex.Message, "Lỗi");
            }
        }

        private void AddNV_btn_Click(object sender, EventArgs e)
        {
            Them = true;

            maNV_tb.ResetText();
            tenNV_tb.ResetText();
            sdtNV_tb.ResetText();
            diachiNV_tb.ResetText();
            cmndNV_tb.ResetText();
            ngayNV_dtp.ResetText();

            maNV_tb.Enabled = false;
            try
            {
                maNV_tb.Text = dbNhanVien.GetLastIndex();
            }
            catch { /* nếu lỗi lấy mã mới thì để trống */ }

            save_btn.Enabled = true;
            panel3.Enabled = true;

            AddNV_btn.Enabled = false;
            fix_btn.Enabled = false;
            DeleteNV_btn.Enabled = false;

            tenNV_tb.Focus();
        }

        private void DeleteNV_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (NhanVien_dtg.CurrentCell == null)
                {
                    MessageBox.Show("Chưa chọn nhân viên.", "Thông báo");
                    return;
                }

                int r = NhanVien_dtg.CurrentCell.RowIndex;
                if (r < 0 || r >= NhanVien_dtg.Rows.Count)
                {
                    MessageBox.Show("Dòng không hợp lệ.", "Thông báo");
                    return;
                }

                string strNHANVIEN = NhanVien_dtg.Rows[r].Cells[0].Value?.ToString();
                if (string.IsNullOrWhiteSpace(strNHANVIEN))
                {
                    MessageBox.Show("Không xác định được Mã nhân viên.", "Thông báo");
                    return;
                }

                var traloi = MessageBox.Show("Chắc xóa nhân viên này không?", "Trả lời",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == DialogResult.Yes)
                {
                    dbNhanVien.XoaNhanVien(ref err, strNHANVIEN);
                    LoadData();
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa Nhân viên!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi CSDL!", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được: " + ex.Message, "Lỗi");
            }
        }

        private void fix_btn_Click(object sender, EventArgs e)
        {
            Them = false;

            panel3.Enabled = true;
            save_btn.Enabled = true;

            AddNV_btn.Enabled = false;
            fix_btn.Enabled = false;
            DeleteNV_btn.Enabled = false;

            maNV_tb.Enabled = false;
            tenNV_tb.Focus();
        }

        private void NhanVien_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (NhanVien_dtg.CurrentCell == null) return;

            int r = NhanVien_dtg.CurrentCell.RowIndex;
            if (r < 0 || r >= NhanVien_dtg.Rows.Count) return;

            try
            {
                if (NhanVien_dtg.Rows[r].Cells[0].Value != null)
                {
                    maNV_tb.Text = NhanVien_dtg.Rows[r].Cells[0].Value?.ToString();
                    tenNV_tb.Text = NhanVien_dtg.Rows[r].Cells[1].Value?.ToString();
                    sdtNV_tb.Text = NhanVien_dtg.Rows[r].Cells[2].Value?.ToString();
                    diachiNV_tb.Text = NhanVien_dtg.Rows[r].Cells[3].Value?.ToString();

                    // Ngày NV ở cột 4
                    DateTime parsed;
                    if (DateTime.TryParse(NhanVien_dtg.Rows[r].Cells[4].Value?.ToString(), out parsed))
                        ngayNV_dtp.Value = parsed;

                    // CMND ở cột 5
                    cmndNV_tb.Text = NhanVien_dtg.Rows[r].Cells[5].Value?.ToString();
                }

                save_btn.Enabled = false;
                AddNV_btn.Enabled = true;
                panel3.Enabled = false;

                search_btn.Enabled = true;
                view_btn.Enabled = true;
                AddNV_btn.Enabled = true;
                fix_btn.Enabled = true;
                DeleteNV_btn.Enabled = true;
                Them = false;
            }
            catch
            {
                // bỏ qua để tránh crash nếu dữ liệu ô không hợp lệ
            }
        }

        private bool CheckInfor()
        {
            foreach (Control h in panel3.Controls)
            {
                if ((string)h.Tag == "infor")
                {
                    if (string.IsNullOrWhiteSpace(h.Text))
                    {
                        MessageBox.Show("Cần điền đầy đủ thông tin!", "Error");
                        return false;
                    }
                }
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
                    if (check == false) return;

                    var blTp = new QueryNhanVien();
                    blTp.ThemNhanVien(
                        maNV_tb.Text,
                        tenNV_tb.Text,
                        sdtNV_tb.Text,
                        diachiNV_tb.Text,
                        ngayNV_dtp.Text,
                        cmndNV_tb.Text,
                        ref err);

                    LoadData();
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi CSDL!", "Lỗi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thêm được: " + ex.Message, "Lỗi");
                }
            }
            else
            {
                try
                {
                    var blTp = new QueryNhanVien();
                    blTp.CapNhatNhanVien(
                        maNV_tb.Text,
                        tenNV_tb.Text,
                        sdtNV_tb.Text,
                        diachiNV_tb.Text,
                        ngayNV_dtp.Text,
                        cmndNV_tb.Text,
                        ref err);

                    LoadData();
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi CSDL!", "Lỗi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không sửa được: " + ex.Message, "Lỗi");
                }
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            // giữ nguyên cấu trúc cũ (để trống)
        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NhanVien_dtg.AutoGenerateColumns = true;
                NhanVien_dtg.DataSource = dbNhanVien.LocNhanVien(search_tb.Text);
                NhanVien_dtg.AutoResizeColumns();
            }
            catch (SqlException)
            {
                // không sập UI nếu query lỗi
            }
        }
    }
}
