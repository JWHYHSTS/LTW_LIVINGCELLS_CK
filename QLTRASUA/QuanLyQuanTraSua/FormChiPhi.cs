using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // OK nếu bị mờ: file này không dùng LINQ trực tiếp
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
        bool Them;
        string err;

        QueryChiPhi dbTP = new QueryChiPhi();

        public FormChiPhi()
        {
            InitializeComponent();
        }

        public string Get_Day() => DateTime.Now.Day.ToString().Trim();
        public string Get_Month() => DateTime.Now.Month.ToString().Trim();
        public string Get_Year() => DateTime.Now.Year.ToString().Trim();

        void LoadData()
        {
            try
            {
                panel3.Enabled = false;

                dtPhi = new DataTable();
                dtPhi.Clear();

                ChiTieu_dtg.AutoGenerateColumns = true;
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
                MessageBox.Show("Lỗi kết nối CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

            // Lương NV tạm tính từ QUANLYLUONG (BLL đã tính)
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

            save_btn.Enabled = true;
            luongnv_tb.Focus();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;

            if (!TrySplitMonthYear(thoigian_tb.Text, out var monthStr, out var yearStr))
            {
                MessageBox.Show("Thời gian không hợp lệ. Định dạng đúng: MM/YYYY", "Cảnh báo");
                return;
            }

            // Tính tổng an toàn (mặc định 0 nếu rỗng/không hợp lệ)
            float fLuong = ParseFloat(luongnv_tb.Text);
            float fPNL = ParseFloat(pnvl_tb.Text);
            float fDien = ParseFloat(tiendien_tb.Text);
            float fNuoc = ParseFloat(tiennuoc_tb.Text);
            float fVS = ParseFloat(pvs_tb.Text);

            float tong = fLuong + fPNL + fDien + fNuoc + fVS;
            tong_tb.Text = tong.ToString();

            // Kiểm tra tồn tại bản ghi -> quyết định Thêm/Sửa
            KiemTra_Primary();

            try
            {
                var blTp = new QueryChiPhi();

                if (Them)
                {
                    blTp.ThemChiPhi(yearStr, monthStr,
                                    fLuong.ToString(), fPNL.ToString(), fDien.ToString(), fNuoc.ToString(), fVS.ToString(),
                                    tong.ToString(), ref err);

                    MessageBox.Show("Thêm Thành Công", "Thông Báo");
                }
                else
                {
                    blTp.CapNhatChiPhi(yearStr, monthStr,
                                       fLuong.ToString(), fPNL.ToString(), fDien.ToString(), fNuoc.ToString(), fVS.ToString(),
                                       tong.ToString(), ref err);

                    MessageBox.Show("Sửa Thành Công", "Thông Báo");
                }

                LoadData();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lưu được. Lỗi CSDL!", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lưu được. " + ex.Message, "Lỗi");
            }
        }

        void KiemTra_Primary()
        {
            if (!TrySplitMonthYear(thoigian_tb.Text, out var monthStr, out var yearStr))
            {
                Them = true;
                return;
            }

            dtPhi = dbTP.Kiemtra(yearStr, monthStr);
            Them = !(dtPhi != null && dtPhi.Rows.Count == 1);
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            panel3.Enabled = false;

            if (string.IsNullOrWhiteSpace(search_tb.Text))
            {
                LoadData();
                return;
            }

            try
            {
                dtPhi = dbTP.LayThongTin(search_tb.Text);
                ChiTieu_dtg.AutoGenerateColumns = true;
                ChiTieu_dtg.DataSource = dtPhi;
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi truy vấn CSDL!", "Lỗi");
            }
        }

        private void ChiTieu_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ChiTieu_dtg.CurrentCell == null) return;
            if (ChiTieu_dtg.CurrentCell.RowIndex < 0) return;

            int r = ChiTieu_dtg.CurrentCell.RowIndex;
            if (r >= ChiTieu_dtg.Rows.Count) return;

            try
            {
                var row = ChiTieu_dtg.Rows[r];
                // cột: Nam(0) | Thang(1) | LuongNV(2) | PhiNguyenLieu(3) | TienDien(4) | TienNuoc(5) | PhiVeSinh(6) | Tong(7)
                thoigian_tb.Text = $"{row.Cells[1].Value}/{row.Cells[0].Value}";
                luongnv_tb.Text = row.Cells[2].Value?.ToString();
                pnvl_tb.Text = row.Cells[3].Value?.ToString();
                tiendien_tb.Text = row.Cells[4].Value?.ToString();
                tiennuoc_tb.Text = row.Cells[5].Value?.ToString();
                pvs_tb.Text = row.Cells[6].Value?.ToString();
                tong_tb.Text = row.Cells[7].Value?.ToString();
            }
            catch { /* bỏ qua nếu có lỗi dữ liệu ô */ }
        }

        private void FormChiPhi_Load(object sender, EventArgs e)
        {
            // Báo cáo lịch sử
            this.CHITableAdapter.Fill(this.QuanLi.CHI);
            this.reportViewer1.RefreshReport();
        }

        // ===== Helpers =====
        private static float ParseFloat(string s)
        {
            if (float.TryParse(s, out var v)) return v;
            return 0f;
        }

        private static bool TrySplitMonthYear(string mmYYYY, out string month, out string year)
        {
            month = year = "";
            if (string.IsNullOrWhiteSpace(mmYYYY)) return false;

            var parts = mmYYYY.Split('/');
            if (parts.Length != 2) return false;

            month = parts[0].Trim();
            year = parts[1].Trim();

            // kiểm tra số hợp lệ
            if (!int.TryParse(month, out var m)) return false;
            if (!int.TryParse(year, out var y)) return false;
            if (m < 1 || m > 12) return false;
            if (y < 1) return false;

            return true;
        }
    }
}
