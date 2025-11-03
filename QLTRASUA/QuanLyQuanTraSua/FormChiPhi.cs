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

    
    public partial class FormChiPhi : Form
    {
        DataTable dtPhi = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        string err;

        QueryChiPhi dbTP = new QueryChiPhi();
        public FormChiPhi()
        {
            InitializeComponent();
        }

        public string Get_Day()
        {
            string str = DateTime.Now.Day.ToString().Trim();

            return str;
        }
        public string Get_Month()
        {
            string str = DateTime.Now.Month.ToString().Trim();

            return str;
        }
        public string Get_Year()
        {
            string str = DateTime.Now.Year.ToString().Trim();

            return str;
        }

        void LoadData()
        {

            try
            {
                panel3.Enabled = false;
                //int year = dateTimePicker1.Value.Year;
                dtPhi = new DataTable();
                dtPhi.Clear();

              
                //DataSet ds = dbTP.LayDoanhThuTudonHang(Get_Year(),Get_Month(),Get_Day());
                //dtPhi = ds.Tables[0];
                //dtDoanhThu .Rows[0]["DoanhThu"].ToString()
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
                // this.DOANHTHUTableAdapter.FillBy(this.DataSet1.DOANHTHU,year,month,day);

            }
            catch (SqlException)
            {
                MessageBox.Show(" Lỗi rồi!!!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void modify_infor_panel_Paint(object sender, PaintEventArgs e)
        {

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
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            save_btn.Enabled = true;
            luongnv_tb.Focus();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            KiemTra_Primary();
            string a = thoigian_tb.Text;
            String[] strlist = a.Split('/');

            float tong = Convert.ToInt32(luongnv_tb.Text) + Convert.ToInt32(pnvl_tb.Text) + Convert.ToInt32(tiendien_tb.Text) + Convert.ToInt32(tiennuoc_tb.Text) + Convert.ToInt32(pvs_tb.Text);
            tong_tb.Text = tong.ToString();

            if (Them)
            {
                try
                {
                    // Thực hiện lệnh 
                    QueryChiPhi blTp = new QueryChiPhi();
                    blTp.ThemChiPhi(strlist[1], strlist[0], luongnv_tb.Text, pnvl_tb.Text, tiendien_tb.Text, tiennuoc_tb.Text, pvs_tb.Text, tong_tb.Text, ref err);
                    // Load lại dữ liệu trên DataGridView 
                    LoadData();
                    // Thông báo 
                    MessageBox.Show("Thêm Thành Công", "Thông Báo");

                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            else
            {
                // Thực hiện lệnh 
                QueryChiPhi blTp = new QueryChiPhi();
                blTp.CapNhatChiPhi(strlist[1], strlist[0], luongnv_tb.Text, pnvl_tb.Text, tiendien_tb.Text, tiennuoc_tb.Text, pvs_tb.Text, tong_tb.Text, ref err);
                MessageBox.Show("Sửa Thành Công", "Thông Báo");
                // Load lại dữ liệu trên DataGridView 
                LoadData();
            }
            // Đóng kết nối 
        }

        void KiemTra_Primary()
        {
            string a = thoigian_tb.Text;
            String[] strlist = a.Split('/');

            dtPhi = dbTP.Kiemtra(strlist[1], strlist[0]);
            //dtPhi = kt.Tables[0];

            if (dtPhi.Rows.Count == 1)
            {
                Them = false;
            }
            else
            {
                Them = true;
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            panel3.Enabled = false;
            //int year = dateTimePicker1.Value.Year;
            dtPhi = new DataTable();
            dtPhi.Clear();
            if (search_tb.Text == "")
            {
                LoadData();
                return;
            }
            dtPhi = dbTP.LayThongTin(search_tb.Text);
            //DataSet ds = dbTP.LayDoanhThuTudonHang(Get_Year(),Get_Month(),Get_Day());
            //dtPhi = ds.Tables[0];
            //dtDoanhThu .Rows[0]["DoanhThu"].ToString()
            ChiTieu_dtg.DataSource = dtPhi;
        }

        private void ChiTieu_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = ChiTieu_dtg.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            thoigian_tb.Text = ChiTieu_dtg.Rows[r].Cells[1].Value.ToString() + "/" + ChiTieu_dtg.Rows[r].Cells[0].Value.ToString();
            luongnv_tb.Text = ChiTieu_dtg.Rows[r].Cells[2].Value.ToString();
            pnvl_tb.Text = ChiTieu_dtg.Rows[r].Cells[3].Value.ToString();
            tiendien_tb.Text = ChiTieu_dtg.Rows[r].Cells[4].Value.ToString();
            tiennuoc_tb.Text = ChiTieu_dtg.Rows[r].Cells[5].Value.ToString();
            pvs_tb.Text = ChiTieu_dtg.Rows[r].Cells[6].Value.ToString();
            tong_tb.Text = ChiTieu_dtg.Rows[r].Cells[7].Value.ToString();
        }

        private void FormChiPhi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLi.CHI' table. You can move, or remove it, as needed.
            this.CHITableAdapter.Fill(this.QuanLi.CHI);

            this.reportViewer1.RefreshReport();
        }
    }
}
