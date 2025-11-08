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
    public partial class FormChiPhi : Form
    {
        DataTable dtPhi = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        string err;

        QueryChiPhi dbTP = new QueryChiPhi();

        public FormChiPhi()
        {
            InitializeComponent();

            // [ADD] Khóa input: chỉ cho phép số ở các ô chi phí
            if (luongnv_tb != null) luongnv_tb.KeyPress += OnlyNumber_KeyPress;
            if (pnvl_tb != null) pnvl_tb.KeyPress += OnlyNumber_KeyPress;
            if (tiendien_tb != null) tiendien_tb.KeyPress += OnlyNumber_KeyPress;
            if (tiennuoc_tb != null) tiennuoc_tb.KeyPress += OnlyNumber_KeyPress;
            if (pvs_tb != null) pvs_tb.KeyPress += OnlyNumber_KeyPress;
        }

        // ====== [ADD] Helpers: thời gian hiện tại ======
        public string Get_Day() => DateTime.Now.Day.ToString().Trim();
        public string Get_Month() => DateTime.Now.Month.ToString().Trim();
        public string Get_Year() => DateTime.Now.Year.ToString().Trim();

        // ====== [ADD] Chặn nhập chữ: chỉ cho phép số và phím điều khiển ======
        private void OnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // ====== [ADD] Đọc số nguyên an toàn từ TextBox ======
        private bool TryReadInt(TextBox tb, string fieldLabel, out int value)
        {
            value = 0;
            string s = tb?.Text?.Trim();

            if (string.IsNullOrEmpty(s))
            {
                MessageBox.Show("PHẢI ĐIỀN ĐẦY ĐỦ THÔNG TIN", "Thiếu dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb?.Focus();
                return false;
            }

            // Cho phép 12,000 hoặc 12.000 (xóa dấu để parse)
            s = s.Replace(",", "").Replace(".", "");

            if (!int.TryParse(s, out value) || value < 0)
            {
                MessageBox.Show($"{fieldLabel} phải là số nguyên không âm.", "Sai dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb?.Focus();
                return false;
            }
            return true;
        }

        // ====== [ADD] Kiểm tra toàn bộ các ô số ======
        private bool ValidateAllNumeric(out int luong, out int pnvl, out int dien, out int nuoc, out int pvs)
        {
            luong = pnvl = dien = nuoc = pvs = 0;
            if (!TryReadInt(luongnv_tb, "Lương NV", out luong)) return false;
            if (!TryReadInt(pnvl_tb, "Phí nguyên liệu", out pnvl)) return false;
            if (!TryReadInt(tiendien_tb, "Tiền điện", out dien)) return false;
            if (!TryReadInt(tiennuoc_tb, "Tiền nước", out nuoc)) return false;
            if (!TryReadInt(pvs_tb, "Phí vệ sinh", out pvs)) return false;
            return true;
        }

        // ====== Load data ======
        void LoadData()
        {
            try
            {
                panel3.Enabled = false;

                dtPhi = new DataTable();
                dtPhi.Clear();

                ChiTieu_dtg.DataSource = dbTP.LayChiPhi();

                thoigian_tb.ResetText();
                luongnv_tb.ResetText();
                tiendien_tb.ResetText();
                tiennuoc_tb.ResetText();
                pnvl_tb.ResetText();
                pvs_tb.ResetText();
                tong_tb.ResetText();

                ChiTieu_dtg.AutoResizeColumns();

                thoigian_tb.Enabled = false;
                tong_tb.Enabled = false;
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi tải dữ liệu chi phí!");
            }
        }

        // ====== Sự kiện giao diện gốc (giữ nguyên) ======
        private void label1_Click(object sender, EventArgs e) { }
        private void modify_infor_panel_Paint(object sender, PaintEventArgs e) { }

        private void profit_view_btn_Click(object sender, EventArgs e)
        {
            modify_infor_panel.Visible = true;
            spent_his_panel.Visible = false;
            modify_infor_panel.BringToFront();
            panel3.Enabled = false;

            LoadData();

            textBox1.Text = DateTime.Now.ToString().Trim();
            textBox1.Enabled = false;

            thoigian_tb.Text = Get_Month() + "/" + Get_Year();
            thoigian_tb.Enabled = false;

            // Gợi ý lương NV hiện tại (nếu BL có hỗ trợ)
            luongnv_tb.Text = dbTP.CapNhatChiPhiHienTai(DateTime.Now);
        }

        private void expense_his_btn_Click(object sender, EventArgs e)
        {
            modify_infor_panel.Visible = false;
            spent_his_panel.Visible = true;
            spent_his_panel.BringToFront();
            this.CHITableAdapter.Fill(this.QuanLi.CHI);
            this.reportViewer1.RefreshReport();
        }

        private void fix_btn_Click(object sender, EventArgs e)
        {
            thoigian_tb.Enabled = false;
            tong_tb.Enabled = false;
            panel3.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            save_btn.Enabled = true;
            luongnv_tb.Focus();
        }

        // ====== SAVE: đã thêm đầy đủ ràng buộc ======
        private void save_btn_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;

            // 1) Kiểm tra khóa chính (Tháng/Năm)
            string tg = thoigian_tb.Text?.Trim();
            if (string.IsNullOrEmpty(tg) || !tg.Contains("/"))
            {
                MessageBox.Show("PHẢI ĐIỀN THÔNG TIN (Tháng/Năm).", "Thiếu dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] parts = tg.Split('/');
            if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
            {
                MessageBox.Show("PHẢI ĐIỀN THÔNG TIN (Tháng/Năm).", "Thiếu dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string thang = parts[0].Trim();
            string nam = parts[1].Trim();

            // 2) Kiểm tra các ô số
            if (!ValidateAllNumeric(out int luong, out int pnvl, out int dien, out int nuoc, out int pvs))
                return;

            // 3) Tính tổng & hiển thị
            float tong = luong + pnvl + dien + nuoc + pvs;
            tong_tb.Text = tong.ToString();

            // 4) Xác định Thêm/Sửa theo khóa (nếu đã tồn tại bản ghi tháng/năm → Sửa)
            dtPhi = dbTP.Kiemtra(nam, thang);
            Them = dtPhi.Rows.Count != 1; // true: chưa có → Thêm; false: đã có → Sửa

            // 5) Lưu
            try
            {
                QueryChiPhi blTp = new QueryChiPhi();

                if (Them)
                {
                    blTp.ThemChiPhi(
                        nam, thang,
                        luong.ToString(), pnvl.ToString(), dien.ToString(),
                        nuoc.ToString(), pvs.ToString(), tong_tb.Text, ref err
                    );
                    LoadData();
                    MessageBox.Show("Thêm Thành Công", "Thông Báo");
                }
                else
                {
                    blTp.CapNhatChiPhi(
                        nam, thang,
                        luong.ToString(), pnvl.ToString(), dien.ToString(),
                        nuoc.ToString(), pvs.ToString(), tong_tb.Text, ref err
                    );
                    MessageBox.Show("Sửa Thành Công", "Thông Báo");
                    LoadData();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lưu được. Lỗi CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====== Kiểm tra khóa chính an toàn (giữ + bổ sung) ======
        void KiemTra_Primary()
        {
            string a = thoigian_tb.Text?.Trim();

            if (string.IsNullOrEmpty(a) || !a.Contains("/"))
            {
                MessageBox.Show("PHẢI ĐIỀN THÔNG TIN", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Them = false;
                return;
            }

            String[] strlist = a.Split('/');
            if (strlist.Length < 2 || string.IsNullOrEmpty(strlist[0]) || string.IsNullOrEmpty(strlist[1]))
            {
                MessageBox.Show("PHẢI ĐIỀN ĐẦY ĐỦ THÔNG TIN", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Them = false;
                return;
            }

            dtPhi = dbTP.Kiemtra(strlist[1], strlist[0]);
            Them = dtPhi.Rows.Count != 1;
        }

        // ====== Tìm kiếm ======
        private void search_btn_Click(object sender, EventArgs e)
        {
            panel3.Enabled = false;
            dtPhi = new DataTable();
            dtPhi.Clear();

            if (string.IsNullOrWhiteSpace(search_tb.Text))
            {
                LoadData();
                return;
            }

            dtPhi = dbTP.LayThongTin(search_tb.Text.Trim());
            ChiTieu_dtg.DataSource = dtPhi;
        }

        // ====== Click vào dòng để đẩy dữ liệu lên panel ======
        private void ChiTieu_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ChiTieu_dtg.CurrentCell == null) return;

            int r = ChiTieu_dtg.CurrentCell.RowIndex;
            if (r < 0 || r >= ChiTieu_dtg.Rows.Count) return;

            try
            {
                thoigian_tb.Text = $"{ChiTieu_dtg.Rows[r].Cells[1].Value}/{ChiTieu_dtg.Rows[r].Cells[0].Value}";
                luongnv_tb.Text = ChiTieu_dtg.Rows[r].Cells[2].Value?.ToString();
                pnvl_tb.Text = ChiTieu_dtg.Rows[r].Cells[3].Value?.ToString();
                tiendien_tb.Text = ChiTieu_dtg.Rows[r].Cells[4].Value?.ToString();
                tiennuoc_tb.Text = ChiTieu_dtg.Rows[r].Cells[5].Value?.ToString();
                pvs_tb.Text = ChiTieu_dtg.Rows[r].Cells[6].Value?.ToString();
                tong_tb.Text = ChiTieu_dtg.Rows[r].Cells[7].Value?.ToString();
            }
            catch
            {
                // bỏ qua lỗi mapping cột
            }
        }

        private void FormChiPhi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLi.CHI' table. You can move, or remove it, as needed.
            this.CHITableAdapter.Fill(this.QuanLi.CHI);
            this.reportViewer1.RefreshReport();
        }
    }
}
