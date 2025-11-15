
namespace QuanLyQuanTraSua
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.date_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.date_timer = new System.Windows.Forms.Timer(this.components);
            this.task_timer = new System.Windows.Forms.Timer(this.components);
            this.task_panel = new System.Windows.Forms.Panel();
            this.iconUser = new Guna.UI2.WinForms.Guna2PictureBox();
            this.staff_mana_btn = new System.Windows.Forms.Button();
            this.iconAdmin = new Guna.UI2.WinForms.Guna2PictureBox();
            this.sale_mana_btn = new System.Windows.Forms.Button();
            this.sign_in_btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.profit_mana_btn = new System.Windows.Forms.Button();
            this.shift_mana_btn = new System.Windows.Forms.Button();
            this.expense_mana_btn = new System.Windows.Forms.Button();
            this.customer_mana_btn = new System.Windows.Forms.Button();
            this.order_mana_btn = new System.Windows.Forms.Button();
            this.sign_out_btn = new System.Windows.Forms.Button();
            this.exit_btn = new System.Windows.Forms.Button();
            this.task_screen = new Guna.UI2.WinForms.Guna2GroupBox();
            this.role = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.task_icon = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse4 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse5 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse6 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse7 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse8 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse9 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse10 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.task_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconAdmin)).BeginInit();
            this.task_screen.SuspendLayout();
            this.panel1.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::QuanLyQuanTraSua.Properties.Resources.panda;
            this.pictureBox1.Location = new System.Drawing.Point(40, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_label.Location = new System.Drawing.Point(4, 2);
            this.date_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(74, 32);
            this.date_label.TabIndex = 4;
            this.date_label.Text = "Date";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.date_label);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 1274);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2310, 48);
            this.panel2.TabIndex = 5;
            // 
            // date_timer
            // 
            this.date_timer.Enabled = true;
            this.date_timer.Tick += new System.EventHandler(this.date_timer_Tick);
            // 
            // task_timer
            // 
            this.task_timer.Enabled = true;
            this.task_timer.Interval = 1;
            this.task_timer.Tick += new System.EventHandler(this.task_timer_Tick);
            // 
            // task_panel
            // 
            this.task_panel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.task_panel.Controls.Add(this.iconUser);
            this.task_panel.Controls.Add(this.staff_mana_btn);
            this.task_panel.Controls.Add(this.iconAdmin);
            this.task_panel.Controls.Add(this.sale_mana_btn);
            this.task_panel.Controls.Add(this.sign_in_btn);
            this.task_panel.Controls.Add(this.profit_mana_btn);
            this.task_panel.Controls.Add(this.shift_mana_btn);
            this.task_panel.Controls.Add(this.expense_mana_btn);
            this.task_panel.Controls.Add(this.customer_mana_btn);
            this.task_panel.Controls.Add(this.order_mana_btn);
            this.task_panel.Controls.Add(this.sign_out_btn);
            this.task_panel.Controls.Add(this.exit_btn);
            this.task_panel.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.task_panel.Location = new System.Drawing.Point(0, 62);
            this.task_panel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.task_panel.Name = "task_panel";
            this.task_panel.Size = new System.Drawing.Size(404, 932);
            this.task_panel.TabIndex = 6;
            // 
            // iconUser
            // 
            this.iconUser.FillColor = System.Drawing.Color.Transparent;
            this.iconUser.Image = global::QuanLyQuanTraSua.Properties.Resources.user;
            this.iconUser.ImageRotate = 0F;
            this.iconUser.Location = new System.Drawing.Point(76, 100);
            this.iconUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.iconUser.Name = "iconUser";
            this.iconUser.Size = new System.Drawing.Size(261, 203);
            this.iconUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconUser.TabIndex = 11;
            this.iconUser.TabStop = false;
            this.iconUser.Click += new System.EventHandler(this.iconUser_Click);
            // 
            // staff_mana_btn
            // 
            this.staff_mana_btn.BackColor = System.Drawing.Color.Wheat;
            this.staff_mana_btn.FlatAppearance.BorderSize = 0;
            this.staff_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.staff_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.staff_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staff_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.staff_mana_btn.Location = new System.Drawing.Point(4, 288);
            this.staff_mana_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.staff_mana_btn.Name = "staff_mana_btn";
            this.staff_mana_btn.Size = new System.Drawing.Size(388, 73);
            this.staff_mana_btn.TabIndex = 8;
            this.staff_mana_btn.Tag = "task_button";
            this.staff_mana_btn.Text = "Quản lý nhân viên";
            this.staff_mana_btn.UseVisualStyleBackColor = false;
            this.staff_mana_btn.Click += new System.EventHandler(this.staff_mana_btn_Click);
            // 
            // iconAdmin
            // 
            this.iconAdmin.FillColor = System.Drawing.Color.Transparent;
            this.iconAdmin.Image = global::QuanLyQuanTraSua.Properties.Resources.administrator;
            this.iconAdmin.ImageRotate = 0F;
            this.iconAdmin.Location = new System.Drawing.Point(76, 89);
            this.iconAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.iconAdmin.Name = "iconAdmin";
            this.iconAdmin.Size = new System.Drawing.Size(261, 203);
            this.iconAdmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconAdmin.TabIndex = 7;
            this.iconAdmin.TabStop = false;
            this.iconAdmin.Click += new System.EventHandler(this.iconAdmin_Click);
            // 
            // sale_mana_btn
            // 
            this.sale_mana_btn.BackColor = System.Drawing.Color.Wheat;
            this.sale_mana_btn.FlatAppearance.BorderSize = 0;
            this.sale_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sale_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.sale_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sale_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.sale_mana_btn.Location = new System.Drawing.Point(4, 370);
            this.sale_mana_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sale_mana_btn.Name = "sale_mana_btn";
            this.sale_mana_btn.Size = new System.Drawing.Size(388, 73);
            this.sale_mana_btn.TabIndex = 6;
            this.sale_mana_btn.Tag = "task_button";
            this.sale_mana_btn.Text = "Quản lý doanh thu";
            this.sale_mana_btn.UseVisualStyleBackColor = false;
            this.sale_mana_btn.Click += new System.EventHandler(this.sale_mana_btn_Click);
            // 
            // sign_in_btn
            // 
            this.sign_in_btn.BorderRadius = 10;
            this.sign_in_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.sign_in_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.sign_in_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.sign_in_btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.sign_in_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.sign_in_btn.FillColor = System.Drawing.Color.Blue;
            this.sign_in_btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sign_in_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sign_in_btn.ForeColor = System.Drawing.Color.White;
            this.sign_in_btn.HoverState.FillColor = System.Drawing.Color.DeepPink;
            this.sign_in_btn.HoverState.FillColor2 = System.Drawing.Color.SeaShell;
            this.sign_in_btn.Location = new System.Drawing.Point(6, 12);
            this.sign_in_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sign_in_btn.Name = "sign_in_btn";
            this.sign_in_btn.ShadowDecoration.BorderRadius = 5;
            this.sign_in_btn.ShadowDecoration.Color = System.Drawing.Color.Yellow;
            this.sign_in_btn.Size = new System.Drawing.Size(387, 70);
            this.sign_in_btn.TabIndex = 9;
            this.sign_in_btn.Text = "Đăng nhập";
            this.sign_in_btn.Click += new System.EventHandler(this.sign_in_btn_Click);
            // 
            // profit_mana_btn
            // 
            this.profit_mana_btn.BackColor = System.Drawing.Color.Wheat;
            this.profit_mana_btn.FlatAppearance.BorderSize = 0;
            this.profit_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.profit_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.profit_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profit_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.profit_mana_btn.Location = new System.Drawing.Point(4, 536);
            this.profit_mana_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.profit_mana_btn.Name = "profit_mana_btn";
            this.profit_mana_btn.Size = new System.Drawing.Size(388, 73);
            this.profit_mana_btn.TabIndex = 10;
            this.profit_mana_btn.Tag = "task_button";
            this.profit_mana_btn.Text = "Quản lý lợi nhuận";
            this.profit_mana_btn.UseVisualStyleBackColor = false;
            this.profit_mana_btn.Click += new System.EventHandler(this.profit_mana_btn_Click);
            // 
            // shift_mana_btn
            // 
            this.shift_mana_btn.BackColor = System.Drawing.Color.Wheat;
            this.shift_mana_btn.FlatAppearance.BorderSize = 0;
            this.shift_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.shift_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.shift_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shift_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.shift_mana_btn.Location = new System.Drawing.Point(4, 498);
            this.shift_mana_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.shift_mana_btn.Name = "shift_mana_btn";
            this.shift_mana_btn.Size = new System.Drawing.Size(388, 73);
            this.shift_mana_btn.TabIndex = 9;
            this.shift_mana_btn.Tag = "task_button";
            this.shift_mana_btn.Text = "Quản lý ca làm";
            this.shift_mana_btn.UseVisualStyleBackColor = false;
            this.shift_mana_btn.Click += new System.EventHandler(this.shift_mana_btn_Click);
            // 
            // expense_mana_btn
            // 
            this.expense_mana_btn.BackColor = System.Drawing.Color.Wheat;
            this.expense_mana_btn.FlatAppearance.BorderSize = 0;
            this.expense_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.expense_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.expense_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expense_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.expense_mana_btn.Location = new System.Drawing.Point(4, 456);
            this.expense_mana_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.expense_mana_btn.Name = "expense_mana_btn";
            this.expense_mana_btn.Size = new System.Drawing.Size(388, 73);
            this.expense_mana_btn.TabIndex = 7;
            this.expense_mana_btn.Tag = "task_button";
            this.expense_mana_btn.Text = "Quản lý khoản chi";
            this.expense_mana_btn.UseVisualStyleBackColor = false;
            this.expense_mana_btn.Click += new System.EventHandler(this.expense_mana_btn_Click);
            // 
            // customer_mana_btn
            // 
            this.customer_mana_btn.BackColor = System.Drawing.Color.Wheat;
            this.customer_mana_btn.FlatAppearance.BorderSize = 0;
            this.customer_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customer_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.customer_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customer_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.customer_mana_btn.Location = new System.Drawing.Point(4, 412);
            this.customer_mana_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.customer_mana_btn.Name = "customer_mana_btn";
            this.customer_mana_btn.Size = new System.Drawing.Size(388, 73);
            this.customer_mana_btn.TabIndex = 5;
            this.customer_mana_btn.Tag = "task_button";
            this.customer_mana_btn.Text = "Quản lý khách hàng";
            this.customer_mana_btn.UseVisualStyleBackColor = false;
            this.customer_mana_btn.Click += new System.EventHandler(this.customer_mana_btn_Click);
            // 
            // order_mana_btn
            // 
            this.order_mana_btn.BackColor = System.Drawing.Color.Wheat;
            this.order_mana_btn.FlatAppearance.BorderSize = 0;
            this.order_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.order_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.order_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.order_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.order_mana_btn.Location = new System.Drawing.Point(4, 333);
            this.order_mana_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.order_mana_btn.Name = "order_mana_btn";
            this.order_mana_btn.Size = new System.Drawing.Size(388, 73);
            this.order_mana_btn.TabIndex = 4;
            this.order_mana_btn.Tag = "task_button";
            this.order_mana_btn.Text = "Quản lý đơn hàng";
            this.order_mana_btn.UseVisualStyleBackColor = false;
            this.order_mana_btn.Click += new System.EventHandler(this.order_mana_btn_Click);
            // 
            // sign_out_btn
            // 
            this.sign_out_btn.BackColor = System.Drawing.Color.Orange;
            this.sign_out_btn.FlatAppearance.BorderSize = 0;
            this.sign_out_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sign_out_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.sign_out_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sign_out_btn.ForeColor = System.Drawing.Color.Black;
            this.sign_out_btn.Location = new System.Drawing.Point(4, 760);
            this.sign_out_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sign_out_btn.Name = "sign_out_btn";
            this.sign_out_btn.Size = new System.Drawing.Size(388, 73);
            this.sign_out_btn.TabIndex = 3;
            this.sign_out_btn.Tag = "task_button";
            this.sign_out_btn.Text = "Đăng xuất";
            this.sign_out_btn.UseVisualStyleBackColor = false;
            this.sign_out_btn.Click += new System.EventHandler(this.sign_out_btn_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exit_btn.FlatAppearance.BorderSize = 0;
            this.exit_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exit_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_btn.ForeColor = System.Drawing.Color.Black;
            this.exit_btn.Location = new System.Drawing.Point(4, 853);
            this.exit_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(388, 73);
            this.exit_btn.TabIndex = 1;
            this.exit_btn.Tag = "task_button";
            this.exit_btn.Text = "Thoát";
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // task_screen
            // 
            this.task_screen.BackColor = System.Drawing.Color.White;
            this.task_screen.BackgroundImage = global::QuanLyQuanTraSua.Properties.Resources.bk1;
            this.task_screen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.task_screen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.task_screen.Controls.Add(this.task_panel);
            this.task_screen.CustomBorderColor = System.Drawing.Color.Cyan;
            this.task_screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.task_screen.FillColor = System.Drawing.Color.Transparent;
            this.task_screen.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.task_screen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.task_screen.Location = new System.Drawing.Point(0, 203);
            this.task_screen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.task_screen.Name = "task_screen";
            this.task_screen.Size = new System.Drawing.Size(2310, 1071);
            this.task_screen.TabIndex = 11;
            this.task_screen.Text = "Welcome";
            this.task_screen.Click += new System.EventHandler(this.guna2GroupBox1_Enter);
            // 
            // role
            // 
            this.role.AutoSize = true;
            this.role.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.role.ForeColor = System.Drawing.Color.White;
            this.role.Location = new System.Drawing.Point(1572, 42);
            this.role.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(0, 46);
            this.role.TabIndex = 9;
            // 
            // ten
            // 
            this.ten.AutoSize = true;
            this.ten.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(1688, 109);
            this.ten.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(0, 46);
            this.ten.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.guna2CustomGradientPanel1);
            this.panel1.Controls.Add(this.ten);
            this.panel1.Controls.Add(this.role);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2310, 203);
            this.panel1.TabIndex = 3;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.task_icon);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2CustomGradientPanel1.Controls.Add(this.pictureBox1);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Lavender;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.RoyalBlue;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(2310, 203);
            this.guna2CustomGradientPanel1.TabIndex = 7;
            // 
            // task_icon
            // 
            this.task_icon.BackColor = System.Drawing.Color.Transparent;
            this.task_icon.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.task_icon.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.task_icon.Image = global::QuanLyQuanTraSua.Properties.Resources.burger_menu1;
            this.task_icon.ImageOffset = new System.Drawing.Point(0, 0);
            this.task_icon.ImageRotate = 0F;
            this.task_icon.Location = new System.Drawing.Point(102, 119);
            this.task_icon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.task_icon.Name = "task_icon";
            this.task_icon.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.task_icon.Size = new System.Drawing.Size(72, 72);
            this.task_icon.TabIndex = 8;
            this.task_icon.Click += new System.EventHandler(this.task_icon_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe Script", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Red;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(824, 25);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(3980, 344);
            this.guna2HtmlLabel1.TabIndex = 7;
            this.guna2HtmlLabel1.Text = "Have a nice day!! Friends";
            this.guna2HtmlLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this.staff_mana_btn;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 15;
            this.guna2Elipse2.TargetControl = this.sale_mana_btn;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 15;
            this.guna2Elipse3.TargetControl = this.expense_mana_btn;
            // 
            // guna2Elipse4
            // 
            this.guna2Elipse4.BorderRadius = 15;
            this.guna2Elipse4.TargetControl = this.profit_mana_btn;
            // 
            // guna2Elipse5
            // 
            this.guna2Elipse5.BorderRadius = 15;
            this.guna2Elipse5.TargetControl = this.order_mana_btn;
            // 
            // guna2Elipse6
            // 
            this.guna2Elipse6.BorderRadius = 15;
            this.guna2Elipse6.TargetControl = this.customer_mana_btn;
            // 
            // guna2Elipse7
            // 
            this.guna2Elipse7.BorderRadius = 15;
            this.guna2Elipse7.TargetControl = this.shift_mana_btn;
            // 
            // guna2Elipse8
            // 
            this.guna2Elipse8.BorderRadius = 15;
            this.guna2Elipse8.TargetControl = this.exit_btn;
            // 
            // guna2Elipse9
            // 
            this.guna2Elipse9.BorderRadius = 15;
            this.guna2Elipse9.TargetControl = this.sign_out_btn;
            // 
            // guna2Elipse10
            // 
            this.guna2Elipse10.BorderRadius = 15;
            this.guna2Elipse10.TargetControl = this.task_panel;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::QuanLyQuanTraSua.Properties.Resources.bk1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(2310, 1322);
            this.Controls.Add(this.task_screen);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trà sữa I.102";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.task_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconAdmin)).EndInit();
            this.task_screen.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label date_label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer date_timer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer task_timer;
        private System.Windows.Forms.Panel task_panel;
        private System.Windows.Forms.Button profit_mana_btn;
        private System.Windows.Forms.Button shift_mana_btn;
        private System.Windows.Forms.Button staff_mana_btn;
        private System.Windows.Forms.Button expense_mana_btn;
        private System.Windows.Forms.Button sale_mana_btn;
        private System.Windows.Forms.Button customer_mana_btn;
        private System.Windows.Forms.Button order_mana_btn;
        private System.Windows.Forms.Button sign_out_btn;
        private System.Windows.Forms.Button exit_btn;
        private Guna.UI2.WinForms.Guna2GroupBox task_screen;
        private System.Windows.Forms.Label role;
        private System.Windows.Forms.Label ten;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ImageButton task_icon;
        private Guna.UI2.WinForms.Guna2GradientButton sign_in_btn;
        private Guna.UI2.WinForms.Guna2PictureBox iconAdmin;
        private Guna.UI2.WinForms.Guna2PictureBox iconUser;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse4;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse5;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse6;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse7;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse8;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse9;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse10;
    }
}

