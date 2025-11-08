using System;
using System.Windows.Forms;

namespace QuanLyQuanTraSua
{
    public partial class Intro : Form
    {
        private int count = 0;

        public Intro()
        {
            InitializeComponent();
        }

        private void pos_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                count++;

                // Nếu Timer chạy khoảng 15–20ms, thì 265 tick ~ 4–5 giây
                if (count >= 265)
                {
                    pos_timer.Stop();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                pos_timer.Stop();
                MessageBox.Show("Đã xảy ra lỗi trong màn hình giới thiệu:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}

