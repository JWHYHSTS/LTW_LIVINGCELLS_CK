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
    public partial class FormHoaDon : Form
    {
        DataTable dtMenu = null;
        QueryHoaDon dbMenu = new QueryHoaDon();
        public string UserCode = "NV001";
        public string UserName = "Trần Hà Cẩm Chi";
        string err;
        float total = 0;
        int total_point = 0;
        List<string> infor = new List<string>();
        List<string> coupon_infor;
        string maHoaDon = "";

        public FormHoaDon()
        {
            InitializeComponent();
            LoadMenu();
        }

        private void LoadMenu()
        {
            try
            {
                // Ép kiểu cột số để tránh cast lỗi khi set value
                if (item_dgv.Columns.Count >= 4)
                {
                    item_dgv.Columns[1].ValueType = typeof(int); // Số lượng
                    item_dgv.Columns[2].ValueType = typeof(int); // Điểm tích luỹ
                    item_dgv.Columns[3].ValueType = typeof(int); // Thành tiền
                }

                dtMenu = new DataTable();
                dtMenu.Clear();

                // Cột combobox tên "cbbMenu" đã được tạo trong Designer
                // Hàm này gắn DataSource = (MaMH, TenMH)
                cbbMenu = dbMenu.LoadComboBox(cbbMenu);
            }
            catch (Exception)
            {
                // Không chặn form nếu lỗi, chỉ thông báo nhẹ
                MessageBox.Show("Không tải được danh mục món. Vui lòng kiểm tra kết nối.", "Thông báo");
            }
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox sen = sender as GroupBox;
            ControlPaint.DrawBorder(e.Graphics, sen.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            order_his_panel.Visible = false;
            add_panel.Visible = true;
            add_panel.BringToFront();
        }

        private void history_btn_Click(object sender, EventArgs e)
        {
            add_panel.Visible = false;
            order_his_panel.Visible = true;
            order_his_panel.BringToFront();
        }

        private void check_don_btn_Click(object sender, EventArgs e)
        {
            total_point = 0;
            total = 0;

            // Kiểm tra input tối thiểu
            var sdt = sdtKH_tb.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập SĐT khách hàng.", "Thiếu thông tin");
                return;
            }

            bool check = false;
            string maKH;
            check = dbMenu.CheckKhachHang(sdt, out maKH);

            if (check == true)
            {
                // Đã có KH
                infor = dbMenu.GetKhachInfor(maKH); // [MaKH, DiemTichLuy]
            }
            else
            {
                // KH mới → yêu cầu tên/sđt địa chỉ tối thiểu
                if (string.IsNullOrWhiteSpace(tenKH_tb.Text))
                {
                    MessageBox.Show("Khách hàng mới cần nhập Tên.", "Thiếu thông tin");
                    return;
                }

                MessageBox.Show("Khách hàng mới. Thông tin khách sẽ được lưu", "Thêm khách");
                check = dbMenu.ThemKhach(tenKH_tb.Text, sdtKH_tb.Text, diachiKH_tb.Text, ref err, out infor);
                if (!check || infor == null || infor.Count < 2)
                {
                    MessageBox.Show("Không thể lưu khách hàng mới.", "Lỗi");
                    return;
                }
            }

            // Hiển thị info
            maKH_lb.Text = infor[0];
            diemtichluyKH_lb.Text = (infor.Count > 1 ? infor[1] : "0");
            nhanvien_lb.Text = UserName;
            date_lb.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Tính tạm tính và coupon
            int tamtinh = Checkgia();
            int diemTL = 0;
            int.TryParse(diemtichluyKH_lb.Text, out diemTL);
            CheckCoupon(tamtinh, diemTL);
        }

        private int Checkgia()
        {
            int temp_cost = 0;

            foreach (DataGridViewRow row in item_dgv.Rows)
            {
                if (row.Cells[0].Value != null) // đã chọn mã món
                {
                    // Lấy giá/điểm của món
                    int cost, value;
                    dbMenu.GetGia(row.Cells[0].Value.ToString().Trim(), out cost, out value);

                    // Số lượng: nếu rỗng → 0
                    int sl = 0;
                    if (row.Cells[1].Value != null)
                        int.TryParse(row.Cells[1].Value.ToString(), out sl);

                    // Cập nhật điểm/tiền từng dòng
                    int diem = value * sl;
                    int tien = cost * sl;

                    row.Cells[2].Value = diem;
                    row.Cells[3].Value = tien;

                    temp_cost += tien;
                    total_point += diem;
                }
                else
                {
                    // Nếu chưa chọn món, set các cột tính toán về 0 (tránh rác)
                    if (row.Cells.Count >= 4)
                    {
                        row.Cells[2].Value = 0;
                        row.Cells[3].Value = 0;
                    }
                }
            }

            return temp_cost;
            // Lưu ý: total_point là biến field, đã cộng dồn ở trên.
        }

        private void CheckCoupon(int cost, int point)
        {
            float discount = 0;
            coupon_infor = new List<string>();

            try
            {
                discount = dbMenu.CheckCoupon(cost, point, out coupon_infor);
            }
            catch
            {
                // Nếu lỗi coupon → không áp dụng
                discount = 0;
                coupon_infor = new List<string> { "Null", "Null" };
            }

            if (discount != 0)
            {
                discount_lb.Text = "-" + discount.ToString("#,0.##");
                if (coupon_infor != null && coupon_infor.Count >= 2)
                    coupon_lb.Text = coupon_infor[0] + ":" + coupon_infor[1];
                else
                    coupon_lb.Text = "Coupon";
            }
            else
            {
                discount_lb.Text = "0";
                coupon_lb.Text = "None";
                if (coupon_infor == null || coupon_infor.Count == 0)
                {
                    coupon_infor = new List<string> { "Null", "Null" };
                }
            }

            total = (float)(cost - discount);
            if (total < 0) total = 0;
            total_lb.Text = total.ToString("#,0.##");
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (infor == null || infor.Count < 1)
                {
                    MessageBox.Show("Chưa có thông tin khách hàng. Vui lòng kiểm tra đơn trước khi lưu.", "Thiếu thông tin");
                    return;
                }

                if (coupon_infor == null || coupon_infor.Count < 1)
                {
                    coupon_infor = new List<string> { "Null", "Null" };
                }

                // Cập nhật điểm tích luỹ KH
                dbMenu.UpdateKhachHang(infor[0], total_point, ref err);

                // Lưu hoá đơn
                string next_id = dbMenu.LuuHoaDon(infor[0], UserCode, total, DateTime.Now, coupon_infor[0], ref err);
                maHoaDon = next_id;

                // Lưu chi tiết
                dbMenu.LuuChiTietHD(next_id, item_dgv, ref err);

                MessageBox.Show("Đã lưu đơn hàng thành công");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể lưu hoá đơn (lỗi CSDL).", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu hoá đơn: " + ex.Message, "Lỗi");
            }
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
        }

        private void show_report_btn_Click(object sender, EventArgs e)
        {
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            DateTime filter;

            if (show_all_rdb.Checked == true)
            {
                start = new DateTime(2020, 1, 1);
                end = new DateTime(2025, 1, 1);
            }
            else if (filter_rdb.Checked == true)
            {
                filter = filter_date.Value;
                start = new DateTime(filter.Year, filter.Month, 1);
                end = new DateTime(filter.Year, filter.Month, DateTime.DaysInMonth(filter.Year, filter.Month));
            }

            reportViewer_chung.Visible = true;
            reportViewer_chung.BringToFront();
            reportViewer_detail.Visible = false;

            try
            {
                // Tải báo cáo tổng hợp theo khoảng ngày
                this.HOADONTableAdapter.Fill(this.QuanLi.HOADON, start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"));
                this.reportViewer_chung.RefreshReport();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không tải được báo cáo từ CSDL.", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được báo cáo: " + ex.Message, "Lỗi");
            }
        }

        private void detail_btn_Click(object sender, EventArgs e)
        {
            if (maHD_txt.Text != "")
            {
                reportViewer_chung.Visible = false;
                reportViewer_detail.BringToFront();
                reportViewer_detail.Visible = true;

                try
                {
                    // Tải chi tiết theo Mã HĐ
                    int num = this.BangHoaDonTableAdapter.Fill(this.QuanLi.BangChiTietHoaDon, maHD_txt.Text);
                    if (num == 0)
                        this.BangHoaDonTableAdapter.FillBy(this.QuanLi.BangChiTietHoaDon, maHD_txt.Text);

                    this.reportViewer_detail.RefreshReport();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không tải được chi tiết hoá đơn (CSDL).", "Lỗi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không tải được chi tiết hoá đơn: " + ex.Message, "Lỗi");
                }
            }
        }

        private void print_order_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maHoaDon))
            {
                MessageBox.Show("Chưa lưu hoá đơn nên không thể in.", "Thông báo");
                return;
            }

            FormShowHoaDon f = new FormShowHoaDon
            {
                maDon = maHoaDon
            };
            f.ShowDialog();
        }
    }
}
