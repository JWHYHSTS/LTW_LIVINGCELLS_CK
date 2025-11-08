using System;
using System.Windows.Forms;
using QuanLyQuanTraSua.Properties;
using QuanLyQuanTraSua.BS_Layer;

namespace QuanLyQuanTraSua
{
    public partial class SignIn : Form
    {
        public CheckBox cb = new CheckBox();
        public string userID = "role";
        public string userName = "name";
        QueryDangNhap ac = new QueryDangNhap();

        public SignIn()
        {
            InitializeComponent();

            // Ẩn/khởi tạo checkbox tín hiệu như cũ
            cb.Visible = false;
            cb.Checked = false;
            this.Controls.Add(cb);

            // Đảm bảo ô mật khẩu hiển thị dạng **** ngay từ đầu
            try { password.UseSystemPasswordChar = true; } catch { /* giữ nguyên nếu control chưa sẵn sàng */ }
        }

        private void hide_pass_Click(object sender, EventArgs e)
        {
            if (password.UseSystemPasswordChar == true)
            {
                hide_pass.Image = Resources.open;
                password.UseSystemPasswordChar = false;
            }
            else
            {
                hide_pass.Image = Resources.hiden;
                password.UseSystemPasswordChar = true;
            }
        }

        bool Login_QL(string Username, string pass)
        {
            // Giữ nguyên luồng, chỉ bọc try để tránh crash nếu DB lỗi
            try
            {
                return ac.checkTaiKhoan_QL(Username, pass, out userID, out userName);
            }
            catch
            {
                return false;
            }
        }

        bool Login_NV(string Username, string pass)
        {
            try
            {
                return ac.checkTaiKhoan_NV(Username, pass, out userID, out userName);
            }
            catch
            {
                return false;
            }
        }

        private void sign_in_btn_Click(object sender, EventArgs e)
        {
            // Khoá nút để tránh double-click
            sign_in_btn.Enabled = false;

            try
            {
                string user = (username.Text ?? "").Trim();
                string pass = (password.Text ?? "").Trim();

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Thử đăng nhập theo thứ tự cũ
                if (Login_QL(user, pass))
                {
                    cb.Checked = true;
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                if (Login_NV(user, pass))
                {
                    cb.Checked = true;
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                // Sai TK/MK
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Không làm sập form nếu có lỗi bất ngờ
                MessageBox.Show("Không thể đăng nhập lúc này.\nChi tiết: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Mở khoá nút nếu chưa đóng form
                if (!this.IsDisposed) sign_in_btn.Enabled = true;
            }
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            // Giữ nguyên theo cấu trúc cũ
        }
    }
}
