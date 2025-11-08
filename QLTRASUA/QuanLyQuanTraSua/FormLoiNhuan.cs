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
    public partial class FormLoiNhuan : Form
    {
        DataTable dtloinhuan = null;
        bool Them;
        string err;
        int len;
        QueryLoiNhuan dbLN = new QueryLoiNhuan();

        public FormLoiNhuan()
        {
            InitializeComponent();
        }

        private void profit_view_btn_Click(object sender, EventArgs e)
        {
            profit_panel.Visible = true;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            // Giữ nguyên cấu trúc cũ, không cần set gì thêm ở đây
        }

        void LoadData()
        {
            try
            {
                dtloinhuan = new DataTable();
                dtloinhuan = dbLN.LayLoiNhuanTuDTCP(); // DataTable đã build từ BLL
                len = (dtloinhuan != null) ? dtloinhuan.Rows.Count : 0;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không tải được dữ liệu lợi nhuận từ CSDL.", "Lỗi");
                dtloinhuan = new DataTable();
                len = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
                dtloinhuan = new DataTable();
                len = 0;
            }
        }

        void KiemTra_Primary(int i)
        {
            if (dtloinhuan == null || i < 0 || i >= dtloinhuan.Rows.Count)
            {
                Them = true; // không có dữ liệu → coi như cần thêm
                return;
            }

            string y = dtloinhuan.Rows[i]["Nam"]?.ToString() ?? "";
            string m = dtloinhuan.Rows[i]["Thang"]?.ToString() ?? "";

            try
            {
                DataTable dt = dbLN.Kiemtra(y, m);
                Them = !(dt != null && dt.Rows.Count == 1);
            }
            catch (SqlException)
            {
                // Nếu lỗi truy vấn thì không phá luồng, giả định chưa có → thêm
                Them = true;
            }
        }

        void ThemLN_TuDTCP()
        {
            if (dtloinhuan == null || dtloinhuan.Rows.Count == 0) return;

            // Snapshot các dòng để tránh thay đổi collection khi thêm/cập nhật CSDL
            var rows = dtloinhuan.Select();

            for (int i = 0; i < rows.Length; i++)
            {
                // Tạo biến cục bộ an toàn
                string y = rows[i]["Nam"]?.ToString() ?? "";
                string m = rows[i]["Thang"]?.ToString() ?? "";
                string dt = rows[i]["DoanhThu"]?.ToString() ?? "0";
                string cp = rows[i]["ChiPhi"]?.ToString() ?? "0";
                string ln = rows[i]["LoiNhuan"]?.ToString() ?? "0";

                // Dùng KiemTra_Primary gốc dựa theo index hiện tại (vẫn hợp lệ với snapshot)
                KiemTra_Primary(i);

                try
                {
                    var blLN = new QueryLoiNhuan();
                    if (Them)
                    {
                        blLN.ThemLoiNhuan(y, m, dt, cp, ln, ref err);
                    }
                    else
                    {
                        blLN.CapNhatLoiNhuan(y, m, dt, cp, ln, ref err);
                    }
                }
                catch (SqlException)
                {
                    // Thông báo nhẹ cho từng dòng lỗi, không dừng toàn bộ
                    MessageBox.Show($"Không lưu được LN tháng {m}/{y}.", "Lỗi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu LN {m}/{y}: {ex.Message}", "Lỗi");
                }
            }

            // Sau khi xử lý hết, LoadData lại một lần
            LoadData();
        }

        private void dsloinhuan_bt_Click(object sender, EventArgs e)
        {
            LoadData();
            ThemLN_TuDTCP();

            try
            {
                // nam: DateTimePicker (hoặc control tương đương) -> lấy Year
                this.LOINHUANTableAdapter.Fill(this.QuanLi.LOINHUAN, nam.Value.Year);
                this.reportViewer1.RefreshReport();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không tải được báo cáo lợi nhuận từ CSDL.", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được báo cáo lợi nhuận: " + ex.Message, "Lỗi");
            }
        }

        private void FormLoiNhuan_Load(object sender, EventArgs e)
        {
            // Giữ nguyên, không auto fill để tránh nặng form
            // Có thể set min/max cho 'nam' nếu cần ở Designer
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            // Giữ nguyên
        }
    }
}
