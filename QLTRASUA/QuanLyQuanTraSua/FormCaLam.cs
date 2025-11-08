using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;               // OK nếu bị mờ: file này không dùng LINQ trực tiếp
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyQuanTraSua.BS_Layer;

namespace QuanLyQuanTraSua
{
    public partial class FormCaLam : Form
    {
        DateTime today = DateTime.Now;
        DateTime monday = new DateTime();
        DateTime sunday = new DateTime();

        List<string> shift_code = new List<string>();
        public string UserCode = "NV001";
        List<Control> bechecked = new List<Control>();
        int signal = 1;
        string err;
        QueryCaLam dbCaLam = new QueryCaLam();
        Dictionary<string, int> list_max;
        public TimeSpan start_time = new TimeSpan();
        Dictionary<string, List<TimeSpan>> list_ca_lam;

        public FormCaLam()
        {
            InitializeComponent();

            year_num.Minimum = today.Year - 5;
            year_num.Maximum = today.Year + 5;
            year_num.Value = today.Year;

            month_num.Minimum = 1;
            month_num.Maximum = 12;
            month_num.Value = today.Month;

            week_num.Minimum = 1;
            week_num.Maximum = GetWeekNumberOfMonth(new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)));
            week_num.Value = GetWeekNumberOfMonth(new DateTime(today.Year, today.Month, today.Day));

            // Lấy khung giờ ca làm từ BLL
            list_ca_lam = dbCaLam.ThoiGianLam();

            // Đảm bảo progress bar chuẩn 0..100
            try { progressShift.Maximum = 100; } catch { /* ignore if already set */ }
        }

        private int check_Weekday_Index(string name)
        {
            if (name == "mon") return 0;
            else if (name == "tue") return 1;
            else if (name == "wed") return 2;
            else if (name == "thu") return 3;
            else if (name == "fri") return 4;
            else if (name == "sat") return 5;
            else return 6;
        }

        private int GetWeekNumberOfMonth(DateTime date)
        {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);

            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }

            return ((date - firstMonthMonday).Days / 7 + 1);
        }

        private void Get_time_span(DateTime date)
        {
            DateTime temp;
            for (int i = 0; i < 7; i++)
            {
                temp = date.AddDays(-i);
                if ((int)temp.DayOfWeek == 1)
                {
                    monday = temp;
                    sunday = monday.AddDays(6);
                    break;
                }
            }
        }

        private void Get_time_span(int week, int month, int year)
        {
            DateTime dt = new DateTime(year, month, 1);
            DateTime start_week1_date = dt;
            DayOfWeek firstDayOfWeekofMonth = dt.DayOfWeek;
            int myWeekNumInMonth = week;

            if ((int)firstDayOfWeekofMonth == 0)
            {
                start_week1_date = dt;
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    if ((int)dt.AddDays(i).DayOfWeek == 1)
                    {
                        start_week1_date = dt.AddDays(i);
                        break;
                    }
                }
            }

            monday = start_week1_date.AddDays(7 * (myWeekNumInMonth - 1));
            sunday = monday.AddDays(6);
        }

        private void finish_btn_Click(object sender, EventArgs e)
        {
            string maCa, tgian;
            analys_code(now_shift.Text, out maCa, out tgian);
            bool check = dbCaLam.Finish_work(UserCode, tgian, maCa, progressShift.Value, ref err);
            if (check)
                MessageBox.Show("Đã xác nhận ca làm thành công", "Xác nhận ca làm");
            else
                MessageBox.Show("Bạn chưa đăng ký ca làm này", "Xác nhận ca làm");
        }

        private void show_Table_btn_Click(object sender, EventArgs e)
        {
            refresh_table();
            Load_Timetable();
        }

        private void Load_Timetable()
        {
            // Bảo vệ: nếu chưa có list_max thì nạp
            if (list_max == null) list_max = dbCaLam.Max_nv();

            string temp, maca;
            var timetableData = dbCaLam.LoadTimeTable(monday, sunday);

            Clear_Listbox();

            foreach (var item in timetableData)
            {
                foreach (Control h in Timetable.Controls)
                {
                    var tagH = h.Tag as string;
                    if (tagH == "Shift")
                    {
                        temp = Get_Shift_code(h);
                        maca = temp.Split('-')[0];
                        if (temp == item[0])
                        {
                            foreach (Control k in h.Controls)
                            {
                                var tagK = k.Tag as string;
                                if (tagK == "List_nv")
                                {
                                    var lb = k as ListBox;
                                    if (lb == null) continue;

                                    if (list_max.ContainsKey(maca) && lb.Items.Count < list_max[maca])
                                        lb.Items.Add(item[2]);

                                    if (list_max.ContainsKey(maca) && lb.Items.Count == list_max[maca])
                                        h.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Clear_Listbox()
        {
            foreach (Control h in Timetable.Controls)
            {
                var tagH = h.Tag as string;
                if (tagH == "Shift")
                {
                    foreach (Control x in h.Controls)
                    {
                        var tagX = x.Tag as string;
                        if (tagX == "List_nv")
                        {
                            var lb = x as ListBox;
                            if (lb != null) lb.Items.Clear();
                        }
                    }
                }
            }
        }

        private void regis_shift_btn_Click(object sender, EventArgs e)
        {
            shift_history_panel.Visible = false;
            regis_shift_panel.Visible = true;
            regis_shift_panel.BringToFront();
            list_max = dbCaLam.Max_nv();
            refresh_table();
            Load_Timetable();
        }

        private void history_btn_Click(object sender, EventArgs e)
        {
            regis_shift_panel.Visible = false;
            shift_history_panel.Visible = true;
            shift_history_panel.BringToFront();
        }

        private void year_num_ValueChanged(object sender, EventArgs e)
        {
            // intentionally left blank (giữ cấu trúc cũ)
        }

        private void month_num_ValueChanged(object sender, EventArgs e)
        {
            week_num.Maximum = GetWeekNumberOfMonth(new DateTime((int)year_num.Value, (int)month_num.Value, DateTime.DaysInMonth((int)year_num.Value, (int)month_num.Value)));
            week_num.Value = 1;
        }

        private void refresh_table()
        {
            Get_time_span((int)week_num.Value, (int)month_num.Value, (int)year_num.Value);

            day_span_lb.Text = monday.ToString("dd/MM/yyyy") + "-" + sunday.ToString("dd/MM/yyyy");

            foreach (Control ctrl in Timetable.Controls)
            {
                var tagC = ctrl.Tag as string;
                if (tagC == "Weekday")
                {
                    int i = check_Weekday_Index(ctrl.Name);
                    foreach (Control ctrlt in ctrl.Controls)
                    {
                        var tagT = ctrlt.Tag as string;
                        if (tagT == "Time")
                        {
                            ctrlt.Text = monday.AddDays(i).ToString("dd/MM");
                        }
                    }
                }
            }

            // Vô hiệu hóa ô đã qua ngày
            foreach (Control h in Timetable.Controls)
            {
                var tagH = h.Tag as string;
                if (tagH == "Shift")
                {
                    string code = Get_Shift_code(h);
                    string[] code_time = ((code.Split('-'))[1]).Split('/');
                    DateTime temp = new DateTime((int)year_num.Value, Int32.Parse(code_time[1]), Int32.Parse(code_time[0]));
                    h.Enabled = temp.Date >= today.Date;
                }
            }
        }

        private string Get_Shift_code(Control h)
        {
            string code = "";

            foreach (Control k in Timetable.Controls)
            {
                var tagK = k.Tag as string;
                if (tagK == "ca")
                {
                    if (h.Location.Y == k.Location.Y)
                        code = k.Name;
                }
            }

            foreach (Control l in Timetable.Controls)
            {
                var tagL = l.Tag as string;
                if (tagL == "Weekday")
                {
                    if (h.Location.X == l.Location.X)
                    {
                        foreach (Control x in l.Controls)
                        {
                            var tagX = x.Tag as string;
                            if (tagX == "Time")
                                code += "-" + x.Text;
                        }
                    }
                }
            }
            return code;
        }

        private void progress_timer_Tick(object sender, EventArgs e)
        {
            int total_time = 4 * 60; // phút
            string ca = "";
            int progress = 0;
            TimeSpan min_dif = new TimeSpan(24, 0, 0);

            foreach (var item in list_ca_lam)
            {
                if (start_time > item.Value[0])
                {
                    var dif = start_time.Subtract(item.Value[0]);
                    if (dif < min_dif)
                    {
                        ca = item.Key.Trim();
                        min_dif = dif;
                    }
                }
            }

            if (ca != "" && start_time < list_ca_lam[ca][1])
            {
                TimeSpan present = DateTime.Now.TimeOfDay;
                if (present > list_ca_lam[ca][1]) present = list_ca_lam[ca][1];

                TimeSpan diff = present.Subtract(start_time);

                progress = (int)((diff.TotalMinutes / total_time) * 100);
                progress = Math.Max(0, Math.Min(100, progress));
            }
            else
            {
                progress = 0;
            }

            now_shift.Text = ca + "-" + DateTime.Now.ToString("dd/MM");
            percentShift.Text = progress.ToString() + "%";
            try { progressShift.Value = progress; } catch { /* ignore set if out-of-range */ }
        }

        private void send_signal(object sender, EventArgs e)
        {
            if (signal == 1)
            {
                string code;
                CheckBox h = sender as CheckBox;
                code = Get_Shift_code(h.Parent);
                if (h.Checked == true)
                {
                    shift_code.Add(code);
                    bechecked.Add(h);
                }
                else
                {
                    shift_code.Remove(code);
                    bechecked.Remove(h);
                }
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            signal = 0;
            foreach (Control h in bechecked)
            {
                var cb = h as CheckBox;
                if (cb != null)
                {
                    cb.Checked = false;
                    cb.Enabled = false;
                }
            }
            signal = 1;
        }

        private void analys_code(string code, out string maCa, out string tgian)
        {
            string[] tach = code.Split('-');
            maCa = tach[0];
            string[] tach2 = tach[1].Split('/');
            tgian = year_num.Value.ToString() + "-" + tach2[1] + "-" + tach2[0];
        }

        private void regis_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng ký ca?\n Khi đã đăng ký thì không thể hủy", "Notice", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string maCa, tgian;
                foreach (string code in shift_code)
                {
                    analys_code(code, out maCa, out tgian);
                    bool check = dbCaLam.Regis_Shift(UserCode, maCa, tgian, ref err);
                    // Không cần Load_Timetable() tại đây
                }

                // Cập nhật lại bảng 1 lần cho nhẹ
                Load_Timetable();

                // Clear chọn
                clear_btn_Click(null, null);

                MessageBox.Show("Đăng ký thành công");
            }
        }

        private void FormCaLam_Load(object sender, EventArgs e)
        {
            // giữ nguyên (nếu cần có thể set progressShift.Maximum = 100 ở đây)
        }

        private void show_report_btn_Click(object sender, EventArgs e)
        {
            DateTime start_h = new DateTime();
            DateTime end_h = new DateTime();
            DateTime filter;

            if (show_all_rdb.Checked == true)
            {
                start_h = new DateTime(2020, 1, 1);
                end_h = new DateTime(2025, 1, 1);
            }
            else if (filter_rdb.Checked == true)
            {
                filter = filter_date.Value;
                start_h = new DateTime(filter.Year, filter.Month, 1);
                end_h = new DateTime(filter.Year, filter.Month, DateTime.DaysInMonth(filter.Year, filter.Month));
            }

            // TODO: This line of code loads data into the 'QuanLi.QUANLYLUONG' table. You can move, or remove it, as needed.
            this.QUANLYLUONGTableAdapter.FillBy(this.QuanLi.QUANLYLUONG, UserCode, start_h.ToString("yyyy-MM-dd"), end_h.ToString("yyyy-MM-dd"));
            this.reportViewer1.RefreshReport();
        }

        private void Timetable_Enter(object sender, EventArgs e)
        {
            // giữ nguyên để không thay đổi luồng cũ
        }
    }
}
