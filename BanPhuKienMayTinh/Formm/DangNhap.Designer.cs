namespace BanPhuKienMayTinh.Formm
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnQuenmatkhau = new System.Windows.Forms.Button();
            this.dgvTaiKhoancheck = new System.Windows.Forms.DataGridView();
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.lblTenCongty = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoancheck)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtUserName.Location = new System.Drawing.Point(360, 131);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(270, 29);
            this.txtUserName.TabIndex = 26;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtPassword.Location = new System.Drawing.Point(360, 171);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(270, 29);
            this.txtPassword.TabIndex = 36;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDangNhap.ForeColor = System.Drawing.Color.Red;
            this.btnDangNhap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDangNhap.Location = new System.Drawing.Point(279, 256);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(119, 42);
            this.btnDangNhap.TabIndex = 52;
            this.btnDangNhap.Text = "ĐĂNG NHẬP";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnThoat.Location = new System.Drawing.Point(496, 256);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(119, 42);
            this.btnThoat.TabIndex = 57;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnQuenmatkhau
            // 
            this.btnQuenmatkhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnQuenmatkhau.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuenmatkhau.ForeColor = System.Drawing.Color.Red;
            this.btnQuenmatkhau.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnQuenmatkhau.Location = new System.Drawing.Point(82, 254);
            this.btnQuenmatkhau.Name = "btnQuenmatkhau";
            this.btnQuenmatkhau.Size = new System.Drawing.Size(105, 42);
            this.btnQuenmatkhau.TabIndex = 64;
            this.btnQuenmatkhau.Text = "QUÊN MẬT KHẨU";
            this.btnQuenmatkhau.UseVisualStyleBackColor = false;
            this.btnQuenmatkhau.Click += new System.EventHandler(this.btnQuenmatkhau_Click);
            // 
            // dgvTaiKhoancheck
            // 
            this.dgvTaiKhoancheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoancheck.Location = new System.Drawing.Point(402, 68);
            this.dgvTaiKhoancheck.Name = "dgvTaiKhoancheck";
            this.dgvTaiKhoancheck.Size = new System.Drawing.Size(155, 57);
            this.dgvTaiKhoancheck.TabIndex = 69;
            this.dgvTaiKhoancheck.Visible = false;
            // 
            // txtCheck
            // 
            this.txtCheck.BackColor = System.Drawing.Color.Honeydew;
            this.txtCheck.Location = new System.Drawing.Point(557, 305);
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.Size = new System.Drawing.Size(0, 20);
            this.txtCheck.TabIndex = 68;
            // 
            // lblTenCongty
            // 
            this.lblTenCongty.AutoSize = true;
            this.lblTenCongty.Font = new System.Drawing.Font("Algerian", 24F, System.Drawing.FontStyle.Bold);
            this.lblTenCongty.ForeColor = System.Drawing.Color.Green;
            this.lblTenCongty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTenCongty.Location = new System.Drawing.Point(274, 30);
            this.lblTenCongty.Name = "lblTenCongty";
            this.lblTenCongty.Size = new System.Drawing.Size(359, 35);
            this.lblTenCongty.TabIndex = 67;
            this.lblTenCongty.Text = "Công ty Green Star";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblPassword.ForeColor = System.Drawing.Color.Red;
            this.lblPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPassword.Location = new System.Drawing.Point(246, 171);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(102, 24);
            this.lblPassword.TabIndex = 66;
            this.lblPassword.Text = "Password :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblUserName.ForeColor = System.Drawing.Color.Red;
            this.lblUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUserName.Location = new System.Drawing.Point(245, 131);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(115, 24);
            this.lblUserName.TabIndex = 65;
            this.lblUserName.Text = "User Name :";
            // 
            // DangNhap
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(678, 331);
            this.Controls.Add(this.dgvTaiKhoancheck);
            this.Controls.Add(this.txtCheck);
            this.Controls.Add(this.lblTenCongty);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnQuenmatkhau);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Đăng Nhập";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoancheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnQuenmatkhau;
        private System.Windows.Forms.DataGridView dgvTaiKhoancheck;
        private System.Windows.Forms.TextBox txtCheck;
        private System.Windows.Forms.Label lblTenCongty;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
    }
}