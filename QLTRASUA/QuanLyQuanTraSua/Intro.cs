using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanTraSua
{
    public partial class Intro : Form
    {
        int count = 0;
        public Intro()
        {
            InitializeComponent();
        }

        private void pos_timer_Tick(object sender, EventArgs e)
        {
            count++;
            if (count % 265 == 0)
            {
                pos_timer.Stop();
                this.Close();
            }
        }
    }
}
