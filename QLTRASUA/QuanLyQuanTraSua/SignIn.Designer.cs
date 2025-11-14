
namespace QuanLyQuanTraSua
{
    partial class SignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            this.windows = new System.Windows.Forms.Panel();
            this.eye = new System.Windows.Forms.Panel();
            this.hide_pass = new System.Windows.Forms.PictureBox();
            this.sign_in_btn = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.windows.SuspendLayout();
            this.eye.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hide_pass)).BeginInit();
            this.SuspendLayout();
            // 
            // windows
            // 
            this.windows.BackgroundImage = global::QuanLyQuanTraSua.Properties.Resources.bk1;
            this.windows.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.windows.Controls.Add(this.eye);
            this.windows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windows.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windows.Location = new System.Drawing.Point(0, 0);
            this.windows.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.windows.Name = "windows";
            this.windows.Size = new System.Drawing.Size(1598, 822);
            this.windows.TabIndex = 0;
            this.windows.Paint += new System.Windows.Forms.PaintEventHandler(this.windows_Paint);
            // 
            // eye
            // 
            this.eye.BackColor = System.Drawing.Color.PaleTurquoise;
            this.eye.Controls.Add(this.hide_pass);
            this.eye.Controls.Add(this.sign_in_btn);
            this.eye.Controls.Add(this.password);
            this.eye.Controls.Add(this.username);
            this.eye.Controls.Add(this.label3);
            this.eye.Controls.Add(this.label2);
            this.eye.Controls.Add(this.label1);
            this.eye.Location = new System.Drawing.Point(647, 134);
            this.eye.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eye.Name = "eye";
            this.eye.Size = new System.Drawing.Size(735, 379);
            this.eye.TabIndex = 0;
            // 
            // hide_pass
            // 
            this.hide_pass.BackColor = System.Drawing.Color.White;
            this.hide_pass.Image = global::QuanLyQuanTraSua.Properties.Resources.hiden;
            this.hide_pass.Location = new System.Drawing.Point(617, 202);
            this.hide_pass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hide_pass.Name = "hide_pass";
            this.hide_pass.Size = new System.Drawing.Size(33, 29);
            this.hide_pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hide_pass.TabIndex = 6;
            this.hide_pass.TabStop = false;
            this.hide_pass.Click += new System.EventHandler(this.hide_pass_Click);
            // 
            // sign_in_btn
            // 
            this.sign_in_btn.BackColor = System.Drawing.Color.Orange;
            this.sign_in_btn.FlatAppearance.BorderSize = 0;
            this.sign_in_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.sign_in_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.sign_in_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sign_in_btn.Location = new System.Drawing.Point(315, 276);
            this.sign_in_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sign_in_btn.Name = "sign_in_btn";
            this.sign_in_btn.Size = new System.Drawing.Size(165, 55);
            this.sign_in_btn.TabIndex = 5;
            this.sign_in_btn.Text = "Đăng nhập";
            this.sign_in_btn.UseVisualStyleBackColor = false;
            this.sign_in_btn.Click += new System.EventHandler(this.sign_in_btn_Click);
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.Black;
            this.password.Location = new System.Drawing.Point(315, 202);
            this.password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(337, 30);
            this.password.TabIndex = 4;
            this.password.UseSystemPasswordChar = true;
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(315, 126);
            this.username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(337, 30);
            this.username.TabIndex = 3;
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(85, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(45, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đăng nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(211, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trà sữa I.102";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this.eye;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 15;
            this.guna2Elipse2.TargetControl = this.sign_in_btn;
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1598, 822);
            this.Controls.Add(this.windows);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "git";
            this.Load += new System.EventHandler(this.SignIn_Load);
            this.windows.ResumeLayout(false);
            this.eye.ResumeLayout(false);
            this.eye.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hide_pass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel windows;
        private System.Windows.Forms.Panel eye;
        private System.Windows.Forms.Button sign_in_btn;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox hide_pass;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
    }
}