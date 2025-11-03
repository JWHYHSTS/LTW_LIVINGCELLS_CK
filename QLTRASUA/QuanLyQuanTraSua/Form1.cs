using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanTraSua.Properties;

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
        Control h= new Control();
        int signal = 1;
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
            DialogResult dia=MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (dia == DialogResult.Yes)
                this.Close();
        }
    }
}
