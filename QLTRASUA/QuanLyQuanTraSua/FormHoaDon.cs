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
           
            item_dgv.Columns[1].ValueType = typeof(int);
            item_dgv.Columns[2].ValueType = typeof(int);
            item_dgv.Columns[3].ValueType = typeof(int);

            dtMenu = new DataTable();
            dtMenu.Clear();
            cbbMenu = dbMenu.LoadComboBox(cbbMenu);

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

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
            total=0;
           
            bool check = false;
            string sdt = sdtKH_tb.Text.Trim();
            string maKH;
            check=dbMenu.CheckKhachHang(sdt, out maKH);
            if (check == true)
                infor = dbMenu.GetKhachInfor(maKH);
            else
            {
                MessageBox.Show("Khách hàng mới. Thông tin khách sẽ được lưu", "Thêm khách");
                check = dbMenu.ThemKhach(tenKH_tb.Text, sdtKH_tb.Text, diachiKH_tb.Text, ref err, out infor);
            }

            maKH_lb.Text = infor[0];
            diemtichluyKH_lb.Text = infor[1];
            nhanvien_lb.Text = UserName;
            date_lb.Text = (DateTime.Now).ToString("dd/MM/yyyy");
            int tamtinh=Checkgia();
            CheckCoupon(tamtinh, Int32.Parse(infor[1]));
        }

        private int Checkgia()
        {
            int cost=0, value=0, sl=0, temp_cost=0;
            foreach (DataGridViewRow row in item_dgv.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    dbMenu.GetGia(row.Cells[0].Value.ToString().Trim(), out cost, out value);
                    sl = Int32.Parse(row.Cells[1].Value.ToString());
                    row.Cells[2].Value = (value * sl);
                    row.Cells[3].Value = (cost * sl);
                    temp_cost += cost * sl;
                    total_point += value * sl;
                }
            }
            return temp_cost;
        }
        private void CheckCoupon(int cost, int point)
        {
            float discount = 0;
            coupon_infor = new List<string>();
            discount=dbMenu.CheckCoupon(cost, point, out coupon_infor);
            if (discount!=0)
            {
                discount_lb.Text = "-" + discount.ToString();
                coupon_lb.Text = coupon_infor[0] + ":" + coupon_infor[1];
            }
            else
            {
                discount_lb.Text = "0";
                coupon_lb.Text = "None";
                coupon_infor.Add("Null");
                coupon_infor.Add("Null");
            }
            total = cost - discount;
            total_lb.Text = total.ToString();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            dbMenu.UpdateKhachHang(infor[0], total_point, ref err);
            string next_id=dbMenu.LuuHoaDon(infor[0], UserCode, total, DateTime.Now, coupon_infor[0], ref err);
            maHoaDon = next_id;
            dbMenu.LuuChiTietHD(next_id, item_dgv, ref err);
            MessageBox.Show("Đã lưu đơn hàng thành công");

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
            else if (filter_rdb.Checked==true)
            {
                filter = filter_date.Value;
                start = new DateTime(filter.Year, filter.Month, 1);
                end = new DateTime(filter.Year, filter.Month, DateTime.DaysInMonth(filter.Year, filter.Month));
            }

            reportViewer_chung.Visible = true;
            reportViewer_chung.BringToFront();
            reportViewer_detail.Visible = false;

            // TODO: This line of code loads data into the 'QuanLi.HOADON' table. You can move, or remove it, as needed.
            this.HOADONTableAdapter.Fill(this.QuanLi.HOADON, start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"));

            this.reportViewer_chung.RefreshReport();
        }

        private void detail_btn_Click(object sender, EventArgs e)
        {
            if (maHD_txt.Text!="")
            {
                reportViewer_chung.Visible = false;
                reportViewer_detail.BringToFront();
                reportViewer_detail.Visible = true;
                // TODO: This line of code loads data into the 'QuanLi.BangChiTietHoaDon' table. You can move, or remove it, as needed.
                
                int num= this.BangHoaDonTableAdapter.Fill(this.QuanLi.BangChiTietHoaDon, maHD_txt.Text);
                if (num==0)
                    this.BangHoaDonTableAdapter.FillBy(this.QuanLi.BangChiTietHoaDon, maHD_txt.Text);

                this.reportViewer_detail.RefreshReport();
            }
        }
        private void print_order_btn_Click(object sender, EventArgs e)
        {
            FormShowHoaDon f = new FormShowHoaDon();
            f.maDon = maHoaDon;
            f.ShowDialog();
        }
    }
}
