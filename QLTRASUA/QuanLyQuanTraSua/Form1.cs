using QuanLyQuanTraSua.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanTraSua
{
    public partial class Form1 : Form
    {
        bool showTask = false;
        Panel my_work;
        TimeSpan sign_in_time;
        List<Control> staff_task = new List<Control>();
        List<Control> manager_task = new List<Control>();
        string userID = "";
        string userName = "";
        CheckBox cb = new CheckBox();
        Control h = new Control();
        int signal = 1;

        // ================== [ADD] Ảnh thay thế nút đăng nhập ==================
        private PictureBox _picAfterLogin; // tạo động để không đụng designer
        // ======================================================================

        // ================== [ADD] Nhãn 2 dòng thay thế nút đăng nhập ===========
        private Label _loginInfoLabel;
        // ======================================================================

        public Form1()
        {
            InitializeComponent();
            //Intro intro_form = new Intro();
            //intro_form.ShowDialog();
            task_panel.Location = new Point(-205, 105);
            cb.Checked = false;
            cb.Visible = false;
            cb.CheckStateChanged += Cb_CheckStateChanged;
            this.Controls.Add(cb);

            foreach (Control t in task_panel.Controls)
                if ((string)t.Tag == "task_button")
                    t.Click += new System.EventHandler(this.task_button_Click);

            staff_task.Add(order_mana_btn);
            staff_task.Add(customer_mana_btn);
            staff_task.Add(shift_mana_btn);
            staff_task.Add(sign_out_btn);

            manager_task.Add(staff_mana_btn);
            manager_task.Add(sale_mana_btn);
            manager_task.Add(expense_mana_btn);
            manager_task.Add(profit_mana_btn);
            manager_task.Add(sign_out_btn);

            // ================== [ADD] Khởi tạo PictureBox thay nút ==================
            _picAfterLogin = new PictureBox();
            _picAfterLogin.Visible = false;
            _picAfterLogin.SizeMode = PictureBoxSizeMode.Zoom;

            // đặt ảnh nếu có file .\images\loggedin.png, không có thì dùng icon mặc định
            try
            {
                string p = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "loggedin.png");
                if (File.Exists(p)) _picAfterLogin.Image = Image.FromFile(p);
                else _picAfterLogin.Image = SystemIcons.Information.ToBitmap();
            }
            catch { /* bỏ qua nếu không load được ảnh */ }

            // gắn PictureBox vào cùng parent với nút đăng nhập, trùng vị trí/kích thước
            Control parent = (sign_in_btn != null && sign_in_btn.Parent != null) ? sign_in_btn.Parent : (Control)this;
            _picAfterLogin.Location = sign_in_btn.Location;
            _picAfterLogin.Size = sign_in_btn.Size;
            parent.Controls.Add(_picAfterLogin);
            _picAfterLogin.BringToFront();

            // có thể gán Click để làm gì đó (tùy chọn)
            _picAfterLogin.Click += (s, e) => { /* ví dụ: mở hồ sơ nhân viên */ };
            // =======================================================================

            // ================== [ADD] Khởi tạo Label 2 dòng thay nút đăng nhập ====
            _loginInfoLabel = new Label();
            _loginInfoLabel.Visible = false;
            _loginInfoLabel.AutoSize = false;
            _loginInfoLabel.TextAlign = ContentAlignment.MiddleCenter;
            _loginInfoLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            _loginInfoLabel.BackColor = Color.FromArgb(235, 235, 235); // nhẹ nhàng như nền nút
            _loginInfoLabel.ForeColor = Color.Black;
            _loginInfoLabel.BorderStyle = BorderStyle.FixedSingle;

            _loginInfoLabel.Location = sign_in_btn.Location;
            _loginInfoLabel.Size = sign_in_btn.Size;
            parent.Controls.Add(_loginInfoLabel);
            _loginInfoLabel.BringToFront();
            // =======================================================================
        }

        private void Cb_CheckStateChanged(object sender, EventArgs e)
        {
            if (signal == 1)
            {
                SignIn k = h as SignIn;
                userID = k.userID;
                userName = k.userName;
                if (userID.Contains("NV"))
                {
                    role.Text = "Nhân viên";
                    foreach (Control t in staff_task)
                        t.Visible = true;

                }
                else
                {
                    role.Text = "Quản lý";
                    foreach (Control t in manager_task)
                        t.Visible = true;
                }
                ten.Text = userName;
                role.Visible = true;
                ten.Visible = true;
                sign_in_btn.Enabled = false;
                sign_in_btn.Visible = false;

                // ================== [ADD] Ẩn ảnh nếu đang dùng =======================
                _picAfterLogin.Visible = false;
                // =====================================================================

                // ================== [ADD] Ẩn phần thông tin góc trên bên phải =======
                ten.Visible = false;
                role.Visible = false;
                // =====================================================================

                // ================== [ADD] Hiện nhãn 2 dòng thay thế nút =============
                _loginInfoLabel.Location = sign_in_btn.Location; // đề phòng layout thay đổi
                _loginInfoLabel.Size = sign_in_btn.Size;
                // Nội dung 2 dòng: Họ và tên / Chức vụ
                _loginInfoLabel.Text = $"{userName}\r\n{role.Text}";
                _loginInfoLabel.Visible = true;
                // =====================================================================

                clear_old();
                signal = 0;
            }
        }

        private void date_timer_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            date_label.Text = datetime.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control h in staff_task)
                h.Visible = false;
            foreach (Control k in manager_task)
                k.Visible = false;

            // ================== [ADD] đảm bảo ẩn ảnh & nhãn lúc mở app =============
            if (_picAfterLogin != null) _picAfterLogin.Visible = false;
            if (_loginInfoLabel != null) _loginInfoLabel.Visible = false;
            // =======================================================================
        }

        private void task_timer_Tick(object sender, EventArgs e)
        {

            if (showTask == true)
            {

                if (task_panel.Location.X < 0)
                {
                    task_panel.Location = new Point(task_panel.Location.X + 10, task_panel.Location.Y);
                }
            }
            else
            {
                if (task_panel.Location.X > -205)
                    task_panel.Location = new Point(task_panel.Location.X - 30, task_panel.Location.Y);
            }
        }

        private void task_icon_Click(object sender, EventArgs e)
        {
            showTask = true;
        }

        private void task_button_Click(object sender, EventArgs e)
        {
            showTask = false;
            Button btn = sender as Button;
            task_screen.Text = btn.Text;
        }

        private void clear_old()
        {
            task_screen.Controls.Remove(my_work);
        }

        private void order_mana_btn_Click(object sender, EventArgs e)
        {
            clear_old();
            FormHoaDon f = new FormHoaDon();
            f.UserCode = userID;
            f.UserName = userName;
            my_work = f.windows;

            task_screen.Controls.Add(my_work);
            f.windows.Location = new Point(5, 5);
        }

        private void customer_mana_btn_Click(object sender, EventArgs e)
        {
            clear_old();
            FormKhachHang f = new FormKhachHang();
            my_work = f.windows;
            task_screen.Controls.Add(my_work);
            f.windows.Location = new Point(5, 5);
        }

        private void shift_mana_btn_Click(object sender, EventArgs e)
        {
            clear_old();
            FormCaLam f = new FormCaLam();
            f.start_time = sign_in_time;
            f.UserCode = userID;
            my_work = f.windows;
            task_screen.Controls.Add(my_work);
            f.windows.Location = new Point(5, 5);

        }

        private void staff_mana_btn_Click(object sender, EventArgs e)
        {
            clear_old();
            FormNhanVien f = new FormNhanVien();
            my_work = f.windows;
            task_screen.Controls.Add(my_work);
            f.windows.Location = new Point(5, 5);
        }

        private void sale_mana_btn_Click(object sender, EventArgs e)
        {
            clear_old();
            FormDoanhThu f = new FormDoanhThu();
            my_work = f.windows;
            task_screen.Controls.Add(my_work);
            f.windows.Location = new Point(5, 5);
        }

        private void expense_mana_btn_Click(object sender, EventArgs e)
        {
            clear_old();
            FormChiPhi f = new FormChiPhi();
            my_work = f.windows;
            task_screen.Controls.Add(my_work);
            f.windows.Location = new Point(5, 5);
        }

        private void profit_mana_btn_Click(object sender, EventArgs e)
        {
            clear_old();
            FormLoiNhuan f = new FormLoiNhuan();
            my_work = f.windows;
            task_screen.Controls.Add(my_work);
            f.windows.Location = new Point(5, 5);
        }

        private void sign_in_btn_Click(object sender, EventArgs e)
        {

            clear_old();
            h = new SignIn();
            SignIn f = h as SignIn;
            f.cb = cb;
            my_work = f.windows;
            task_screen.Controls.Add(my_work);
            f.windows.Location = new Point(5, 5);
            sign_in_time = DateTime.Now.TimeOfDay;

        }

        private void sign_out_btn_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo);
            if (dia == DialogResult.Yes)
            {
                clear_old();
                foreach (Control k in staff_task)
                    k.Visible = false;
                foreach (Control k in manager_task)
                    k.Visible = false;
                sign_in_btn.Enabled = true;

                // ================== [ADD] hiện lại nút & ẩn ảnh/nhãn =================
                sign_in_btn.Visible = true;
                if (_picAfterLogin != null) _picAfterLogin.Visible = false;
                if (_loginInfoLabel != null) _loginInfoLabel.Visible = false;
                // ====================================================================

                // ================== [ADD] Hiện lại phần góc phải nếu cần ============
                ten.Visible = true;
                role.Visible = true;
                // ====================================================================

                userID = "";
                userName = "";
                cb.Checked = false;
                signal = 1;
                ten.Text = "";
                role.Text = "";
            }
        }
        private void exit_btn_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (dia == DialogResult.Yes)
                this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void pictureLoggedIn_Click(object sender, EventArgs e)
        //{
        //    Visible = false;
        //    pictureLoggedIn.SizeMode = PictureBoxSizeMode.Zoom;
        //}
    }
}
