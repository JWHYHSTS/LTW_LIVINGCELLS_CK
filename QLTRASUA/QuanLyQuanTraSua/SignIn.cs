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
using QuanLyQuanTraSua.BS_Layer;

namespace QuanLyQuanTraSua
{
    public partial class SignIn : Form
    {
        
        public CheckBox cb = new CheckBox();
        public string userID ="role";
        public string userName="name";
        QueryDangNhap ac = new QueryDangNhap();
        public SignIn()
        {
            InitializeComponent();
            cb.Visible = false;
            cb.Checked = false;
            this.Controls.Add(cb);
        }

        private void hide_pass_Click(object sender, EventArgs e)
        {
            if (password.UseSystemPasswordChar==true)
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
            return (ac.checkTaiKhoan_QL(Username, pass, out userID, out userName));
        }

        bool Login_NV(string Username, string pass)
        {
            return (ac.checkTaiKhoan_NV(Username, pass, out userID, out userName));
        }

        private void sign_in_btn_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;
            if (Login_QL(user, pass) == true) 
            {
                cb.Checked = true;
                MessageBox.Show("Đăng nhập thành công!!!");
                this.Close();
            }
            else if(Login_NV(user, pass) == true)
            {
                cb.Checked = true;
                MessageBox.Show("Đăng nhập thành công!!!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hặc mật khẩu!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            
        }
    }
}
