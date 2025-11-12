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
        // Giữ nguyên các biến bạn đang dùng
        private readonly QueryNhanVien dbNhanVien = new QueryNhanVien();
        private readonly DateTime today = DateTime.Now;

        private bool Them;
        private readonly QueryNhanVien dbNV = new QueryNhanVien();

        public FormNhanVien()
        {
            InitializeComponent();

            // Trạng thái mặc định vùng báo cáo lương
            reportViewer1.Visible = true;
            reportViewer2.Visible = false;
            reportViewer3.Visible = false;
            reportViewer1.BringToFront();
        }

        // ===== Helpers =====
        private static string Nz(string s) => (s ?? string.Empty).Trim();

        private void SetButtonsDefaultState()
        {
            save_btn.Enabled = false;
            AddNV_btn.Enabled = true;
            fix_btn.Enabled = true;
            DeleteNV_btn.Enabled = true;
            panel3.Enabled = false;
            search_btn.Enabled = true;
            view_btn.Enabled = true;
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
                        return int.TryParse(numPart, out var num) ? num : 0;
                    })
                    .DefaultIfEmpty(0)
                    .Max();

                return "NV" + (maxNum + 1).ToString("D3");
            }
        }

        // ====== Xem danh sách (Report người dùng) ======
        private void view_btn_Click(object sender, EventArgs e)
        {
            report_panel.Visible = true;
            modify_infor_panel.Visible = false;
            salary_report_panel.Visible = false;
            report_panel.BringToFront();

            // Nạp Report danh sách nhân viên bằng LINQ
            using (var ctx = new QUANLYQUANTRADataContext())
            {
                var src = ctx.NHANVIENs
                    .Select(nv => new
                    {
                        nv.MaNV,
                        nv.TenNV,
                        nv.SDT,
                        nv.DiaChi,
                        nv.NgayNV,
                        nv.CMND
                    })
                    .OrderBy(x => x.MaNV)
                    .ToList();

                reportViewer4.ProcessingMode = ProcessingMode.Local;
                reportViewer4.LocalReport.DataSources.Clear();
                reportViewer4.LocalReport.DataSources.Add(
                    new ReportDataSource("DataSet1", src));

                // reportViewer4.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.Reports.ReportNhanVien.rdlc";
                // hoặc:
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

        private void LoadData()
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

                maNV_tb.ResetText();
                tenNV_tb.ResetText();
                sdtNV_tb.ResetText();
                diachiNV_tb.ResetText();
                cmndNV_tb.ResetText();
                ngayNV_dtp.Value = DateTime.Now;

                SetButtonsDefaultState();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng Nhân viên.\nLỗi: " + ex.Message, "Lỗi SQL");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu.\n" + ex.Message, "Lỗi");
            }
        }

        private void TinhLuong(int year, int month)
        {
            // Nếu bạn có bước tổng hợp lương trước khi xem báo cáo
            dbNhanVien.CapNhatBangLuong();
        }

        private void FormNhanVien_Load(object sender, EventArgs e) { }

        // ====== Báo cáo lương (3 chế độ) bằng LINQ ======
        private void show_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdb_this_month.Checked)
                {
                    // Tháng này: [đầu tháng ; ngày mai) - cận trên mở
                    var now = DateTime.Now;
                    var s = new DateTime(now.Year, now.Month, 1);
                    var e2 = DateTime.Today.AddDays(1);

                    using (var ctx = new QUANLYQUANTRADataContext())
                    {
                        var src = ctx.QUANLYLUONGs
                            .Where(q => q.ThoiGian >= s && q.ThoiGian < e2)
                            .Select(q => new
                            {
                                q.ThoiGian,
                                MaNV = q.MaNV.Trim(),
                                q.MaCa,
                                q.MucDoHoanThanh,
                                // ✅ thêm alias TienLuong để RDLC dùng ổn định
                                Luong = (double)(q.Luong ?? 0f),
                                TienLuong = (double)(q.Luong ?? 0f)
                            })
                            .OrderBy(q => q.ThoiGian).ThenBy(q => q.MaNV)
                            .ToList();

                        // Dataset phụ: NHANVIEN (để RDLC Lookup tên NV)
                        var dsNV = ctx.NHANVIENs
                                      .Select(n => new { MaNV = n.MaNV.Trim(), TenNV = (n.TenNV ?? "").Trim() })
                                      .ToList();

                        reportViewer1.ProcessingMode = ProcessingMode.Local;
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("DataSet1", src));   // dataset chính của report
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("dsNV", dsNV));      // dataset phụ để Lookup tên NV

                        // reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.Reports.ReportLuongThangNay.rdlc";

                        reportViewer1.ZoomMode = ZoomMode.PageWidth;
                        reportViewer1.RefreshReport();
                    }

                    reportViewer1.Visible = true;
                    reportViewer2.Visible = false;
                    reportViewer3.Visible = false;
                    reportViewer1.BringToFront();
                }
                else if (rbt_old_month.Checked)
                {
                    // Tháng cũ: gộp theo nhân viên, join để có TenNV luôn
                    reportViewer1.Visible = false;
                    reportViewer2.Visible = true;
                    reportViewer3.Visible = false;
                    reportViewer2.BringToFront();

                    var y = time1.Value.Year;
                    var m = time1.Value.Month;
                    var s = new DateTime(y, m, 1);
                    var e2 = s.AddMonths(1); // cận trên mở

                    using (var ctx = new QUANLYQUANTRADataContext())
                    {
                        var src = (from q in ctx.QUANLYLUONGs
                                   where q.ThoiGian >= s && q.ThoiGian < e2
                                   join n in ctx.NHANVIENs on q.MaNV.Trim() equals n.MaNV.Trim()
                                   group new { q, n } by new { n.MaNV } into g
                                   orderby g.Key.MaNV
                                   select new
                                   {
                                       MaNV = g.Key.MaNV,
                                       TenNV = g.Max(x => x.n.TenNV),            // lấy tên
                                       TongCa = g.Count(),
                                       // ✅ trả về cả hai tên field để tương thích RDLC
                                       TienLuong = g.Sum(x => (double)(x.q.Luong ?? 0f)),
                                       TongTien = g.Sum(x => (double)(x.q.Luong ?? 0f)),
                                       TuNgay = s,
                                       DenNgay = e2.AddDays(-1)
                                   }).ToList();

                        reportViewer2.ProcessingMode = ProcessingMode.Local;
                        reportViewer2.LocalReport.DataSources.Clear();
                        reportViewer2.LocalReport.DataSources.Add(
                            new ReportDataSource("DataSet1", src));

                        // reportViewer2.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.Reports.ReportBangLuongThang.rdlc";

                        reportViewer2.ZoomMode = ZoomMode.PageWidth;
                        reportViewer2.RefreshReport();
                    }
                }
                else if (search_NV.Checked)
                {
                    // Tìm theo 1 nhân viên trong 1 tháng
                    var y = time2.Value.Year;
                    var m = time2.Value.Month;
                    var s = new DateTime(y, m, 1);
                    var e2 = s.AddMonths(1); // cận trên mở
                    var id = Nz(maNV_txt.Text).Trim();

                    using (var ctx = new QUANLYQUANTRADataContext())
                    {
                        var src = ctx.QUANLYLUONGs
                            .Where(q => q.ThoiGian >= s && q.ThoiGian < e2 && q.MaNV.Trim() == id)
                            .Select(q => new
                            {
                                q.ThoiGian,
                                MaNV = q.MaNV.Trim(),
                                q.MaCa,
                                q.MucDoHoanThanh,
                                // ✅ thêm alias TienLuong
                                Luong = (double)(q.Luong ?? 0f),
                                TienLuong = (double)(q.Luong ?? 0f)
                            })
                            .OrderBy(q => q.ThoiGian)
                            .ToList();

                        // Dataset phụ cho Lookup tên
                        var dsNV = ctx.NHANVIENs
                                      .Select(n => new { MaNV = n.MaNV.Trim(), TenNV = (n.TenNV ?? "").Trim() })
                                      .ToList();

                        reportViewer3.ProcessingMode = ProcessingMode.Local;
                        reportViewer3.LocalReport.DataSources.Clear();
                        reportViewer3.LocalReport.DataSources.Add(
                            new ReportDataSource("DataSet1", src));
                        reportViewer3.LocalReport.DataSources.Add(
                            new ReportDataSource("dsNV", dsNV));

                        // reportViewer3.LocalReport.ReportEmbeddedResource = "QuanLyQuanTraSua.Reports.ReportLuongNhanVien.rdlc";

                        reportViewer3.ZoomMode = ZoomMode.PageWidth;
                        reportViewer3.RefreshReport();
                    }

                    reportViewer1.Visible = false;
                    reportViewer2.Visible = false;
                    reportViewer3.Visible = true;
                    reportViewer3.BringToFront();
                }
                else if (temp_salary.Checked)
                {
                    using (var ctx = new QUANLYQUANTRADataContext())
                    {
                        var now = today;
                        var s = new DateTime(now.Year, now.Month, 1);
                        var e2 = DateTime.Today.AddDays(1); // cận trên mở

                        var tb = ctx.QUANLYLUONGs
                            .Where(q => q.ThoiGian >= s && q.ThoiGian < e2)
                            .GroupBy(q => q.MaNV)
                            .Select(g => new
                            {
                                MaNV = g.Key,
                                TongCa = g.Count(),
                                TongLuong = g.Sum(x => (double)(x.Luong ?? 0f))
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
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể hiển thị báo cáo lương.\nLỗi SQL: " + ex.Message, "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị báo cáo lương.\n" + ex.Message, "Lỗi");
            }
        }

        // ====== CRUD (LINQ) ======
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
            maNV_tb.Text = NextMaNV();

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
                    MessageBox.Show("Chưa chọn nhân viên để xóa.");
                    return;
                }

                var r = NhanVien_dtg.CurrentCell.RowIndex;
                var strNHANVIEN = Convert.ToString(NhanVien_dtg.Rows[r].Cells[0].Value);

                var traloi = MessageBox.Show("Chắc xóa nhân viên này không?", "Xác nhận",
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
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không xóa được. Lỗi SQL:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được. Lỗi:\n" + ex.Message);
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
            var r = NhanVien_dtg.CurrentCell.RowIndex;

            if (NhanVien_dtg.Rows[r].Cells[0].Value != null)
            {
                maNV_tb.Text = Convert.ToString(NhanVien_dtg.Rows[r].Cells[0].Value);
                tenNV_tb.Text = Convert.ToString(NhanVien_dtg.Rows[r].Cells[1].Value);
                sdtNV_tb.Text = Convert.ToString(NhanVien_dtg.Rows[r].Cells[2].Value);
                diachiNV_tb.Text = Convert.ToString(NhanVien_dtg.Rows[r].Cells[3].Value);
                cmndNV_tb.Text = Convert.ToString(NhanVien_dtg.Rows[r].Cells[5].Value);

                if (!DateTime.TryParse(Convert.ToString(NhanVien_dtg.Rows[r].Cells[4].Value), out var d))
                    d = DateTime.Now;
                ngayNV_dtp.Value = d;
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

        private bool CheckInfor()
        {
            foreach (Control c in panel3.Controls)
            {
                if ((string)c.Tag == "infor" && string.IsNullOrWhiteSpace(c.Text))
                {
                    MessageBox.Show("Cần điền đầy đủ thông tin!", "Thiếu dữ liệu");
                    return false;
                }
            }
            return true;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    if (!CheckInfor()) return;

                    var id = Nz(maNV_tb.Text);
                    var ten = Nz(tenNV_tb.Text);
                    var sdt = Nz(sdtNV_tb.Text);
                    var diachi = Nz(diachiNV_tb.Text);
                    var cmnd = Nz(cmndNV_tb.Text);
                    var ngay = ngayNV_dtp.Value;

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
                            NgayNV = ngay,
                            CMND = cmnd
                        };
                        ctx.NHANVIENs.InsertOnSubmit(nv);
                        ctx.SubmitChanges();
                    }

                    LoadData();
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Không thêm được (SQL).\n" + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thêm được.\n" + ex.Message);
                }
            }
            else
            {
                try
                {
                    var id = Nz(maNV_tb.Text);
                    var ten = Nz(tenNV_tb.Text);
                    var sdt = Nz(sdtNV_tb.Text);
                    var diachi = Nz(diachiNV_tb.Text);
                    var cmnd = Nz(cmndNV_tb.Text);
                    var ngay = ngayNV_dtp.Value;

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
                        nv.NgayNV = ngay;
                        nv.CMND = cmnd;

                        ctx.SubmitChanges();
                    }

                    LoadData();
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Không cập nhật được (SQL).\n" + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không cập nhật được.\n" + ex.Message);
                }
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            // Cho trải nghiệm tốt hơn: gọi lại filter ngay khi bấm nút
            search_tb_TextChanged(sender, e);
        }

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
