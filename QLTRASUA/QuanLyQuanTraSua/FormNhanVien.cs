using Microsoft.Reporting.WinForms;
using QuanLyQuanTraSua.BS_Layer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanTraSua
{
    public partial class FormNhanVien : Form
    {
        // Giữ nguyên các biến của bạn
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

        // ===== Helpers =====
        private static string Nz(string s) => (s ?? string.Empty).Trim();

        private void SetButtonsDefaultState()
        {
            this.save_btn.Enabled = false;
            this.AddNV_btn.Enabled = true;
            this.fix_btn.Enabled = true;
            this.DeleteNV_btn.Enabled = true;
            this.panel3.Enabled = false;
            this.search_btn.Enabled = true;
            this.view_btn.Enabled = true;
        }

        private string NextMaNV()
        {
            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var maxNum = ctx.NHANVIENs
                    .Select(n => n.MaNV)
                    .ToList()
                    .Select(code =>
                    {
                        if (string.IsNullOrWhiteSpace(code) || code.Length < 3) return 0;
                        var numPart = code.Substring(2);
                        int num; return int.TryParse(numPart, out num) ? num : 0;
                    })
                    .DefaultIfEmpty(0)
                    .Max();

                return "NV" + (maxNum + 1).ToString("D4");
            }
        }

        // ====== Xem danh sách (Report người dùng) ======
        private void view_btn_Click(object sender, EventArgs e)
        {
            report_panel.Visible = true;
            modify_infor_panel.Visible = false;
            salary_report_panel.Visible = false;
            report_panel.BringToFront();

            // Nạp Report bằng LINQ thay vì TableAdapter
            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var src = ctx.NHANVIENs
                    .Select(nv => new
                    {
                        nv.MaNV,
                        nv.TenNV,
                        nv.SDT,
                        nv.DiaChi,
                        nv.NgayNV,     // cột đúng
                        nv.CMND
                    })
                    .OrderBy(x => x.MaNV)
                    .ToList();

                reportViewer4.ProcessingMode = ProcessingMode.Local;
                reportViewer4.LocalReport.DataSources.Clear();

                // RDLC đang yêu cầu DataSet1 → buộc tên là DataSet1
                reportViewer4.LocalReport.DataSources.Add(
                    new ReportDataSource("DataSet1", src)
                );

                // Nếu RDLC là EmbeddedResource thì set lại đúng đường dẫn:
                // reportViewer4.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.Reports.ReportNhanVien.rdlc";
                // hoặc dùng file path:
                // reportViewer4.LocalReport.ReportPath = Application.StartupPath + @"\Reports\ReportNhanVien.rdlc";

                reportViewer4.RefreshReport();
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

            ht.Text = today.ToString("dd/MM/yyyy");
            TinhLuong(today.Year, today.Month);
        }

        void LoadData()
        {
            try
            {
                using (var ctx = new QUANLYQUANTRADataContext())
                {
                    var data = ctx.NHANVIENs
                        .Select(nv => new
                        {
                            nv.MaNV,
                            nv.TenNV,
                            nv.SDT,
                            nv.DiaChi,
                            nv.NgayNV,
                            nv.CMND
                        })
                        .OrderBy(n => n.MaNV)
                        .ToList();

                    NhanVien_dtg.DataSource = data;
                    NhanVien_dtg.AutoResizeColumns();
                    NhanVien_dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }

                this.maNV_tb.ResetText();
                this.tenNV_tb.ResetText();
                this.sdtNV_tb.ResetText();
                this.diachiNV_tb.ResetText();
                this.cmndNV_tb.ResetText();
                this.ngayNV_dtp.Value = DateTime.Now;

                SetButtonsDefaultState();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KhachHang. Lỗi rồi!!!");
            }
        }

        private void TinhLuong(int year, int month)
        {
            // Nếu bạn cần tổng hợp lương tự động, giữ phương thức cũ
            dbNhanVien.CapNhatBangLuong();
        }

        private void FormNhanVien_Load(object sender, EventArgs e) { }

        // ====== Báo cáo lương (3 chế độ) bằng LINQ ======
        private void show_btn_Click(object sender, EventArgs e)
        {
            if (rdb_this_month.Checked == true)
            {
                var now = DateTime.Now;
                var s = new DateTime(now.Year, now.Month, 1);
                var e2 = new DateTime(now.Year, now.Month, now.Day);

                using (var ctx = new QUANLYQUANTRADataContext())
                {
                    var src = ctx.QUANLYLUONGs
                        .Where(q => q.ThoiGian >= s && q.ThoiGian <= e2)
                        .Select(q => new
                        {
                            q.ThoiGian,
                            q.MaNV,
                            q.MaCa,
                            q.MucDoHoanThanh,
                            q.Luong
                        })
                        .OrderBy(q => q.ThoiGian).ThenBy(q => q.MaNV)
                        .ToList();

                    reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", src));
                    // reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.Reports.ReportLuongThangNay.rdlc";
                    reportViewer1.RefreshReport();
                }

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

                var y = time1.Value.Year;
                var m = time1.Value.Month;
                var s = new DateTime(y, m, 1);
                var e2 = new DateTime(y, m, DateTime.DaysInMonth(y, m));

                using (var ctx = new QUANLYQUANTRADataContext())
                {
                    var src = ctx.QUANLYLUONGs
                        .Where(q => q.ThoiGian >= s && q.ThoiGian <= e2)
                        .GroupBy(q => q.MaNV)
                        .Select(g => new
                        {
                            MaNV = g.Key,
                            TongCa = g.Count(),
                            TongTien = g.Sum(x => (double)x.Luong),
                            TuNgay = s,
                            DenNgay = e2
                        })
                        .OrderBy(x => x.MaNV)
                        .ToList();

                    reportViewer2.ProcessingMode = ProcessingMode.Local;
                    reportViewer2.LocalReport.DataSources.Clear();
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", src));
                    // reportViewer2.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.Reports.ReportBangLuongThang.rdlc";
                    reportViewer2.RefreshReport();
                }
            }
            else if (search_NV.Checked == true)
            {
                var y = time2.Value.Year;
                var m = time2.Value.Month;
                var s = new DateTime(y, m, 1);
                var e2 = new DateTime(y, m, DateTime.DaysInMonth(y, m));
                var id = Nz(maNV_txt.Text);

                using (var ctx = new QUANLYQUANTRADataContext())
                {
                    var src = ctx.QUANLYLUONGs
                        .Where(q => q.ThoiGian >= s && q.ThoiGian <= e2 && q.MaNV == id)
                        .Select(q => new
                        {
                            q.ThoiGian,
                            q.MaNV,
                            q.MaCa,
                            q.MucDoHoanThanh,
                            q.Luong
                        })
                        .OrderBy(q => q.ThoiGian)
                        .ToList();

                    reportViewer3.ProcessingMode = ProcessingMode.Local;
                    reportViewer3.LocalReport.DataSources.Clear();
                    reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", src));
                    // reportViewer3.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.Reports.ReportLuongNhanVien.rdlc";
                    reportViewer3.RefreshReport();
                }

                reportViewer1.Visible = false;
                reportViewer2.Visible = false;
                reportViewer3.Visible = true;
                reportViewer3.BringToFront();
            }
            else if (temp_salary.Checked == true)
            {
                using (var ctx = new QUANLYQUANTRADataContext())
                {
                    var now = today;
                    var s = new DateTime(now.Year, now.Month, 1);
                    var e2 = new DateTime(now.Year, now.Month, now.Day);

                    var tb = ctx.QUANLYLUONGs
                        .Where(q => q.ThoiGian >= s && q.ThoiGian <= e2)
                        .GroupBy(q => q.MaNV)
                        .Select(g => new
                        {
                            MaNV = g.Key,
                            TongCa = g.Count(),
                            TongLuong = g.Sum(x => (double)x.Luong)
                        })
                        .OrderBy(x => x.MaNV)
                        .ToList();

                    temp_salary_dtg.DataSource = tb;
                    temp_salary_dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }

                reportViewer1.Visible = false;
                reportViewer2.Visible = false;
                reportViewer3.Visible = false;
                temp_salary_dtg.BringToFront();
            }
        }

        // ====== CRUD (LINQ) ======
        private void AddNV_btn_Click(object sender, EventArgs e)
        {
            Them = true;

            this.maNV_tb.ResetText();
            this.tenNV_tb.ResetText();
            this.sdtNV_tb.ResetText();
            this.diachiNV_tb.ResetText();
            this.cmndNV_tb.ResetText();
            this.ngayNV_dtp.ResetText();

            this.maNV_tb.Enabled = false;
            this.maNV_tb.Text = NextMaNV();

            this.save_btn.Enabled = true;
            this.panel3.Enabled = true;

            this.AddNV_btn.Enabled = false;
            this.fix_btn.Enabled = false;
            this.DeleteNV_btn.Enabled = false;
            this.tenNV_tb.Focus();
        }

        private void DeleteNV_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int r = NhanVien_dtg.CurrentCell.RowIndex;
                string strNHANVIEN = NhanVien_dtg.Rows[r].Cells[0].Value.ToString();

                DialogResult traloi = MessageBox.Show("Chắc xóa nhân viên này không?", "Trả lời",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == DialogResult.Yes)
                {
                    using (var ctx = new QUANLYQUANTRADataContext())
                    {
                        var nv = ctx.NHANVIENs.FirstOrDefault(x => x.MaNV == strNHANVIEN);
                        if (nv != null)
                        {
                            ctx.NHANVIENs.DeleteOnSubmit(nv);
                            ctx.SubmitChanges();
                        }
                    }

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
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void fix_btn_Click(object sender, EventArgs e)
        {
            Them = false;

            this.panel3.Enabled = true;
            this.save_btn.Enabled = true;

            this.AddNV_btn.Enabled = false;
            this.fix_btn.Enabled = false;
            this.DeleteNV_btn.Enabled = false;

            this.maNV_tb.Enabled = false;
            this.tenNV_tb.Focus();
        }

        private void NhanVien_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = NhanVien_dtg.CurrentCell.RowIndex;

            if (NhanVien_dtg.Rows[r].Cells[0].Value != null)
            {
                this.maNV_tb.Text = NhanVien_dtg.Rows[r].Cells[0].Value.ToString();
                this.tenNV_tb.Text = NhanVien_dtg.Rows[r].Cells[1].Value.ToString();
                this.sdtNV_tb.Text = NhanVien_dtg.Rows[r].Cells[2].Value.ToString();
                this.diachiNV_tb.Text = NhanVien_dtg.Rows[r].Cells[3].Value.ToString();
                this.cmndNV_tb.Text = NhanVien_dtg.Rows[r].Cells[5].Value.ToString();

                DateTime d;
                if (!DateTime.TryParse(Convert.ToString(NhanVien_dtg.Rows[r].Cells[4].Value), out d))
                    d = DateTime.Now;
                this.ngayNV_dtp.Value = d;
            }

            this.save_btn.Enabled = false;
            this.AddNV_btn.Enabled = true;

            this.panel3.Enabled = false;

            this.search_btn.Enabled = true;
            this.view_btn.Enabled = true;
            this.AddNV_btn.Enabled = true;
            this.fix_btn.Enabled = true;
            this.DeleteNV_btn.Enabled = true;
            Them = false;
        }

        private bool CheckInfor()
        {
            foreach (Control h in panel3.Controls)
                if ((string)h.Tag == "infor")
                    if (string.IsNullOrWhiteSpace(h.Text))
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
                    if (check == false) return;

                    var id = this.maNV_tb.Text;
                    var ten = this.tenNV_tb.Text;
                    var sdt = this.sdtNV_tb.Text;
                    var diachi = this.diachiNV_tb.Text;
                    var cmnd = this.cmndNV_tb.Text;
                    var ngay = this.ngayNV_dtp.Value;

                    using (var ctx = new QUANLYQUANTRADataContext())
                    {
                        if (string.IsNullOrWhiteSpace(id))
                            id = NextMaNV();

                        if (ctx.NHANVIENs.Any(x => x.MaNV == id))
                        {
                            MessageBox.Show("Mã nhân viên đã tồn tại!");
                            return;
                        }

                        var nv = new NHANVIEN
                        {
                            MaNV = id,
                            TenNV = ten,
                            SDT = sdt,
                            DiaChi = diachi,
                            NgayNV = ngay, // đúng cột
                            CMND = cmnd
                        };
                        ctx.NHANVIENs.InsertOnSubmit(nv);
                        ctx.SubmitChanges();
                    }

                    LoadData();
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            else
            {
                try
                {
                    var id = this.maNV_tb.Text;
                    var ten = this.tenNV_tb.Text;
                    var sdt = this.sdtNV_tb.Text;
                    var diachi = this.diachiNV_tb.Text;
                    var cmnd = this.cmndNV_tb.Text;
                    var ngay = this.ngayNV_dtp.Value;

                    using (var ctx = new QUANLYQUANTRADataContext())
                    {
                        var nv = ctx.NHANVIENs.FirstOrDefault(x => x.MaNV == id);
                        if (nv == null)
                        {
                            MessageBox.Show("Không tìm thấy nhân viên để cập nhật!");
                            return;
                        }

                        nv.TenNV = ten;
                        nv.SDT = sdt;
                        nv.DiaChi = diachi;
                        nv.NgayNV = ngay; // đúng cột
                        nv.CMND = cmnd;

                        ctx.SubmitChanges();
                    }

                    LoadData();
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }
            }
        }

        private void search_btn_Click(object sender, EventArgs e) { }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            var key = Nz(search_tb.Text).ToLowerInvariant();

            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var data = ctx.NHANVIENs
                    .Where(nv =>
                        nv.MaNV.ToLower().Contains(key) ||
                        (nv.TenNV ?? "").ToLower().Contains(key) ||
                        (nv.SDT ?? "").ToLower().Contains(key) ||
                        (nv.DiaChi ?? "").ToLower().Contains(key) ||
                        (nv.CMND ?? "").ToLower().Contains(key))
                    .Select(nv => new
                    {
                        nv.MaNV,
                        nv.TenNV,
                        nv.SDT,
                        nv.DiaChi,
                        nv.NgayNV,
                        nv.CMND
                    })
                    .OrderBy(n => n.MaNV)
                    .ToList();

                NhanVien_dtg.DataSource = data;
                NhanVien_dtg.AutoResizeColumns();
                NhanVien_dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
    }
}
