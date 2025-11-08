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
    public partial class FormLoiNhuan : Form
    {
        DataTable dtloinhuan = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
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
        }

        void LoadData()
        {
            try
            {
                dtloinhuan = new DataTable();
                dtloinhuan.Clear();
                dtloinhuan = dbLN.LayLoiNhuanTuDTCP();
                len = dtloinhuan.Rows.Count;
            }
            catch (SqlException)
            {
                MessageBox.Show(" Lỗi rồi!!!");
            }
        }

        void KiemTra_Primary(int i)
        {

            DataTable dt = dbLN.Kiemtra(dtloinhuan.Rows[i]["Nam"].ToString(), dtloinhuan.Rows[i]["Thang"].ToString());
        
            if (dt.Rows.Count == 1)
            {
                Them = false;
            }
            else
            {
                Them = true;
            }
        }

        void ThemLN_TuDTCP()
        {
            for (int i = 0; i < len; i++)
            {
                KiemTra_Primary(i);
                if (Them)
                {
                    try
                    {
                        // Thực hiện lệnh 
                        QueryLoiNhuan blLN = new QueryLoiNhuan();
                        blLN.ThemLoiNhuan(dtloinhuan.Rows[i]["Nam"].ToString(), dtloinhuan.Rows[i]["Thang"].ToString(), dtloinhuan.Rows[i]["DoanhThu"].ToString(), dtloinhuan.Rows[i]["ChiPhi"].ToString(), dtloinhuan.Rows[i]["LoiNhuan"].ToString(), ref err);
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");
                    }
                }
                else
                {
                    QueryLoiNhuan blLN = new QueryLoiNhuan();
                    blLN.CapNhatLoiNhuan(dtloinhuan.Rows[i]["Nam"].ToString(), dtloinhuan.Rows[i]["Thang"].ToString(), dtloinhuan.Rows[i]["DoanhThu"].ToString(), dtloinhuan.Rows[i]["ChiPhi"].ToString(), dtloinhuan.Rows[i]["LoiNhuan"].ToString(), ref err);
                    // Load lại dữ liệu trên DataGridView 
                    LoadData();

                }
            }
        }

        private void dsloinhuan_bt_Click(object sender, EventArgs e)
        {
            LoadData();
            ThemLN_TuDTCP();
            this.LOINHUANTableAdapter.Fill(this.QuanLi.LOINHUAN, nam.Value.Year);
            this.reportViewer1.RefreshReport();
           
        }

        private void FormLoiNhuan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLi.LOINHUAN' table. You can move, or remove it, as needed.
            //this.LOINHUANTableAdapter.Fill(this.QuanLi.LOINHUAN);

        }
        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
