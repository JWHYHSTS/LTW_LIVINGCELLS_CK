using System;
using System.Windows.Forms;

namespace QuanLyQuanTraSua
{
    public partial class FormShowHoaDon : Form
    {
        public string maDon = "";

        public FormShowHoaDon()
        {
            InitializeComponent();
        }

        private void FormShowHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maDon))
                {
                    MessageBox.Show("Không có mã hóa đơn để hiển thị.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // TODO: This line of code loads data into the 'QuanLi.BangChiTietHoaDon' table. You can move, or remove it, as needed.
                int num = this.BangHoaDonTableAdapter.Fill(this.QuanLi.BangChiTietHoaDon, maDon);

                // Nếu thủ tục Fill chính không có dữ liệu, thử FillBy (dự phòng)
                if (num == 0)
                {
                    try
                    {
                        this.BangHoaDonTableAdapter.FillBy(this.QuanLi.BangChiTietHoaDon, maDon);
                    }
                    catch
                    {
                        // Bỏ qua nếu không có FillBy hoặc lỗi: vẫn refresh để UI không sập
                    }
                }

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải báo cáo hóa đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
