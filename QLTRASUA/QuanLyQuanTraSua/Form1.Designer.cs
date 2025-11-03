
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ten = new System.Windows.Forms.Label();
            this.role = new System.Windows.Forms.Label();
            this.task_icon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.date_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.date_timer = new System.Windows.Forms.Timer(this.components);
            this.task_panel = new System.Windows.Forms.Panel();
            this.profit_mana_btn = new System.Windows.Forms.Button();
            this.shift_mana_btn = new System.Windows.Forms.Button();
            this.staff_mana_btn = new System.Windows.Forms.Button();
            this.expense_mana_btn = new System.Windows.Forms.Button();
            this.sale_mana_btn = new System.Windows.Forms.Button();
            this.customer_mana_btn = new System.Windows.Forms.Button();
            this.order_mana_btn = new System.Windows.Forms.Button();
            this.sign_out_btn = new System.Windows.Forms.Button();
            this.exit_btn = new System.Windows.Forms.Button();
            this.sign_in_btn = new System.Windows.Forms.Button();
            this.task_timer = new System.Windows.Forms.Timer(this.components);
            this.task_screen = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.task_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.ten);
            this.panel1.Controls.Add(this.role);
            this.panel1.Controls.Add(this.task_icon);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1482, 123);
            this.panel1.TabIndex = 3;
            // 
            // ten
            // 
            this.ten.AutoSize = true;
            this.ten.Location = new System.Drawing.Point(1125, 70);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(0, 28);
            this.ten.TabIndex = 10;
            this.ten.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            // 
            // role
            // 
            this.role.AutoSize = true;
            this.role.ForeColor = System.Drawing.Color.White;
            this.role.Location = new System.Drawing.Point(1048, 27);
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(0, 28);
            this.role.TabIndex = 9;
            this.role.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            // 
            // task_icon
            // 
            this.task_icon.BackColor = System.Drawing.Color.Transparent;
            this.task_icon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Bisque;
            this.task_icon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.task_icon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.task_icon.Image = global::QuanLyQuanTraSua.Properties.Resources.task2;
            this.task_icon.Location = new System.Drawing.Point(44, 70);
            this.task_icon.Name = "task_icon";
            this.task_icon.Size = new System.Drawing.Size(50, 52);
            this.task_icon.TabIndex = 7;
            this.task_icon.UseVisualStyleBackColor = false;
            this.task_icon.Click += new System.EventHandler(this.task_icon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 60);
            this.label1.TabIndex = 8;
            this.label1.Text = "Have a nice day!! Friends";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyQuanTraSua.Properties.Resources.panda;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_label.Location = new System.Drawing.Point(3, 2);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(45, 20);
            this.date_label.TabIndex = 4;
            this.date_label.Text = "Date";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.date_label);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 803);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1482, 30);
            this.panel2.TabIndex = 5;
            // 
            // date_timer
            // 
            this.date_timer.Enabled = true;
            this.date_timer.Tick += new System.EventHandler(this.date_timer_Tick);
            // 
            // task_panel
            // 
            this.task_panel.BackColor = System.Drawing.Color.DarkGray;
            this.task_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.task_panel.Controls.Add(this.profit_mana_btn);
            this.task_panel.Controls.Add(this.shift_mana_btn);
            this.task_panel.Controls.Add(this.staff_mana_btn);
            this.task_panel.Controls.Add(this.expense_mana_btn);
            this.task_panel.Controls.Add(this.sale_mana_btn);
            this.task_panel.Controls.Add(this.customer_mana_btn);
            this.task_panel.Controls.Add(this.order_mana_btn);
            this.task_panel.Controls.Add(this.sign_out_btn);
            this.task_panel.Controls.Add(this.exit_btn);
            this.task_panel.Controls.Add(this.sign_in_btn);
            this.task_panel.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.task_panel.Location = new System.Drawing.Point(0, 129);
            this.task_panel.Name = "task_panel";
            this.task_panel.Size = new System.Drawing.Size(268, 668);
            this.task_panel.TabIndex = 6;
            // 
            // profit_mana_btn
            // 
            this.profit_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.profit_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.profit_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profit_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.profit_mana_btn.Location = new System.Drawing.Point(3, 448);
            this.profit_mana_btn.Name = "profit_mana_btn";
            this.profit_mana_btn.Size = new System.Drawing.Size(260, 47);
            this.profit_mana_btn.TabIndex = 10;
            this.profit_mana_btn.Tag = "task_button";
            this.profit_mana_btn.Text = "Quản lý lợi nhuận";
            this.profit_mana_btn.UseVisualStyleBackColor = true;
            this.profit_mana_btn.Click += new System.EventHandler(this.profit_mana_btn_Click);
            // 
            // shift_mana_btn
            // 
            this.shift_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.shift_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.shift_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shift_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.shift_mana_btn.Location = new System.Drawing.Point(3, 188);
            this.shift_mana_btn.Name = "shift_mana_btn";
            this.shift_mana_btn.Size = new System.Drawing.Size(260, 47);
            this.shift_mana_btn.TabIndex = 9;
            this.shift_mana_btn.Tag = "task_button";
            this.shift_mana_btn.Text = "Quản lý ca làm";
            this.shift_mana_btn.UseVisualStyleBackColor = true;
            this.shift_mana_btn.Click += new System.EventHandler(this.shift_mana_btn_Click);
            // 
            // staff_mana_btn
            // 
            this.staff_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.staff_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.staff_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staff_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.staff_mana_btn.Location = new System.Drawing.Point(3, 289);
            this.staff_mana_btn.Name = "staff_mana_btn";
            this.staff_mana_btn.Size = new System.Drawing.Size(260, 47);
            this.staff_mana_btn.TabIndex = 8;
            this.staff_mana_btn.Tag = "task_button";
            this.staff_mana_btn.Text = "Quản lý nhân viên";
            this.staff_mana_btn.UseVisualStyleBackColor = true;
            this.staff_mana_btn.Click += new System.EventHandler(this.staff_mana_btn_Click);
            // 
            // expense_mana_btn
            // 
            this.expense_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.expense_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.expense_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expense_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.expense_mana_btn.Location = new System.Drawing.Point(3, 395);
            this.expense_mana_btn.Name = "expense_mana_btn";
            this.expense_mana_btn.Size = new System.Drawing.Size(260, 47);
            this.expense_mana_btn.TabIndex = 7;
            this.expense_mana_btn.Tag = "task_button";
            this.expense_mana_btn.Text = "Quản lý khoản chi";
            this.expense_mana_btn.UseVisualStyleBackColor = true;
            this.expense_mana_btn.Click += new System.EventHandler(this.expense_mana_btn_Click);
            // 
            // sale_mana_btn
            // 
            this.sale_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sale_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.sale_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sale_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.sale_mana_btn.Location = new System.Drawing.Point(3, 342);
            this.sale_mana_btn.Name = "sale_mana_btn";
            this.sale_mana_btn.Size = new System.Drawing.Size(260, 47);
            this.sale_mana_btn.TabIndex = 6;
            this.sale_mana_btn.Tag = "task_button";
            this.sale_mana_btn.Text = "Quản lý doanh thu";
            this.sale_mana_btn.UseVisualStyleBackColor = true;
            this.sale_mana_btn.Click += new System.EventHandler(this.sale_mana_btn_Click);
            // 
            // customer_mana_btn
            // 
            this.customer_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customer_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.customer_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customer_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.customer_mana_btn.Location = new System.Drawing.Point(3, 135);
            this.customer_mana_btn.Name = "customer_mana_btn";
            this.customer_mana_btn.Size = new System.Drawing.Size(260, 47);
            this.customer_mana_btn.TabIndex = 5;
            this.customer_mana_btn.Tag = "task_button";
            this.customer_mana_btn.Text = "Quản lý khách hàng";
            this.customer_mana_btn.UseVisualStyleBackColor = true;
            this.customer_mana_btn.Click += new System.EventHandler(this.customer_mana_btn_Click);
            // 
            // order_mana_btn
            // 
            this.order_mana_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.order_mana_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.order_mana_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.order_mana_btn.ForeColor = System.Drawing.Color.Black;
            this.order_mana_btn.Location = new System.Drawing.Point(3, 82);
            this.order_mana_btn.Name = "order_mana_btn";
            this.order_mana_btn.Size = new System.Drawing.Size(260, 47);
            this.order_mana_btn.TabIndex = 4;
            this.order_mana_btn.Tag = "task_button";
            this.order_mana_btn.Text = "Quản lý đơn hàng";
            this.order_mana_btn.UseVisualStyleBackColor = true;
            this.order_mana_btn.Click += new System.EventHandler(this.order_mana_btn_Click);
            // 
            // sign_out_btn
            // 
            this.sign_out_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sign_out_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.sign_out_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sign_out_btn.ForeColor = System.Drawing.Color.Black;
            this.sign_out_btn.Location = new System.Drawing.Point(3, 561);
            this.sign_out_btn.Name = "sign_out_btn";
            this.sign_out_btn.Size = new System.Drawing.Size(260, 47);
            this.sign_out_btn.TabIndex = 3;
            this.sign_out_btn.Tag = "task_button";
            this.sign_out_btn.Text = "Đăng xuất";
            this.sign_out_btn.UseVisualStyleBackColor = true;
            this.sign_out_btn.Click += new System.EventHandler(this.sign_out_btn_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exit_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_btn.ForeColor = System.Drawing.Color.Black;
            this.exit_btn.Location = new System.Drawing.Point(3, 614);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(260, 47);
            this.exit_btn.TabIndex = 1;
            this.exit_btn.Tag = "task_button";
            this.exit_btn.Text = "Thoát";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // sign_in_btn
            // 
            this.sign_in_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sign_in_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.sign_in_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sign_in_btn.ForeColor = System.Drawing.Color.Black;
            this.sign_in_btn.Location = new System.Drawing.Point(3, 7);
            this.sign_in_btn.Name = "sign_in_btn";
            this.sign_in_btn.Size = new System.Drawing.Size(260, 47);
            this.sign_in_btn.TabIndex = 0;
            this.sign_in_btn.Tag = "task_button";
            this.sign_in_btn.Text = "Đăng nhập";
            this.sign_in_btn.UseVisualStyleBackColor = true;
            this.sign_in_btn.Click += new System.EventHandler(this.sign_in_btn_Click);
            // 
            // task_timer
            // 
            this.task_timer.Enabled = true;
            this.task_timer.Interval = 1;
            this.task_timer.Tick += new System.EventHandler(this.task_timer_Tick);
            // 
            // task_screen
            // 
            this.task_screen.BackColor = System.Drawing.Color.Transparent;
            this.task_screen.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.task_screen.Location = new System.Drawing.Point(4, 133);
            this.task_screen.Name = "task_screen";
            this.task_screen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.task_screen.Size = new System.Drawing.Size(1466, 664);
            this.task_screen.TabIndex = 7;
            this.task_screen.TabStop = false;
            this.task_screen.Text = "Welcome";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImage = global::QuanLyQuanTraSua.Properties.Resources.bk1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1482, 833);
            this.Controls.Add(this.task_panel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.task_screen);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.task_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label date_label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer date_timer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel task_panel;
        private System.Windows.Forms.Button sign_in_btn;
        private System.Windows.Forms.Timer task_timer;
        private System.Windows.Forms.Button task_icon;
        private System.Windows.Forms.Button expense_mana_btn;
        private System.Windows.Forms.Button sale_mana_btn;
        private System.Windows.Forms.Button customer_mana_btn;
        private System.Windows.Forms.Button order_mana_btn;
        private System.Windows.Forms.Button sign_out_btn;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.GroupBox task_screen;
        private System.Windows.Forms.Button profit_mana_btn;
        private System.Windows.Forms.Button shift_mana_btn;
        private System.Windows.Forms.Button staff_mana_btn;
        private System.Windows.Forms.Label ten;
        private System.Windows.Forms.Label role;
    }
}

