namespace BanPhuKienMayTinh.View
{
    partial class uctBaoHanh
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctBaoHanh));
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.btnTimKiem = new DevComponents.DotNetBar.ButtonX();
            this.btnHuy = new DevComponents.DotNetBar.ButtonX();
            this.btnAn = new DevComponents.DotNetBar.ButtonX();
            this.btnXoa = new DevComponents.DotNetBar.ButtonX();
            this.btnThem = new DevComponents.DotNetBar.ButtonX();
            this.pnlDSHangHoa = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.grbDanhSachNhanVien = new System.Windows.Forms.GroupBox();
            this.dgvBaoHanh = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSua = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.grbQLyNhanVien = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMaNhomLoai = new System.Windows.Forms.ComboBox();
            this.txtThoiGianBaoHanh = new System.Windows.Forms.TextBox();
            this.grbDanhSachNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoHanh)).BeginInit();
            this.grbQLyNhanVien.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Location = new System.Drawing.Point(261, 321);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuu.TabIndex = 35;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTimKiem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.Location = new System.Drawing.Point(461, 321);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTimKiem.TabIndex = 36;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHuy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(343, 321);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnHuy.TabIndex = 37;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnAn
            // 
            this.btnAn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAn.Image = ((System.Drawing.Image)(resources.GetObject("btnAn.Image")));
            this.btnAn.Location = new System.Drawing.Point(542, 321);
            this.btnAn.Name = "btnAn";
            this.btnAn.Size = new System.Drawing.Size(75, 23);
            this.btnAn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAn.TabIndex = 38;
            this.btnAn.Text = "Ẩn";
            this.btnAn.Click += new System.EventHandler(this.btnAn_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageTextSpacing = 5;
            this.btnXoa.Location = new System.Drawing.Point(177, 321);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXoa.TabIndex = 39;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(14, 321);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThem.TabIndex = 41;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // pnlDSHangHoa
            // 
            this.pnlDSHangHoa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlDSHangHoa.Location = new System.Drawing.Point(14, 381);
            this.pnlDSHangHoa.Name = "pnlDSHangHoa";
            this.pnlDSHangHoa.Size = new System.Drawing.Size(1226, 247);
            this.pnlDSHangHoa.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(582, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(426, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Danh Sách Độ Dài Bảo Hành Theo Nhóm Loại Hàng";
            // 
            // grbDanhSachNhanVien
            // 
            this.grbDanhSachNhanVien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grbDanhSachNhanVien.Controls.Add(this.dgvBaoHanh);
            this.grbDanhSachNhanVien.Location = new System.Drawing.Point(424, 52);
            this.grbDanhSachNhanVien.Name = "grbDanhSachNhanVien";
            this.grbDanhSachNhanVien.Size = new System.Drawing.Size(819, 254);
            this.grbDanhSachNhanVien.TabIndex = 33;
            this.grbDanhSachNhanVien.TabStop = false;
            // 
            // dgvBaoHanh
            // 
            this.dgvBaoHanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoHanh.BackgroundColor = System.Drawing.Color.PaleGreen;
            this.dgvBaoHanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoHanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoHanh.GridColor = System.Drawing.Color.Black;
            this.dgvBaoHanh.Location = new System.Drawing.Point(3, 16);
            this.dgvBaoHanh.Name = "dgvBaoHanh";
            this.dgvBaoHanh.Size = new System.Drawing.Size(813, 235);
            this.dgvBaoHanh.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã Nhóm Loại :";
            // 
            // btnSua
            // 
            this.btnSua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageTextSpacing = 5;
            this.btnSua.Location = new System.Drawing.Point(95, 321);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSua.TabIndex = 40;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Quản Lý Bảo Hành";
            // 
            // grbQLyNhanVien
            // 
            this.grbQLyNhanVien.Controls.Add(this.txtThoiGianBaoHanh);
            this.grbQLyNhanVien.Controls.Add(this.cbMaNhomLoai);
            this.grbQLyNhanVien.Controls.Add(this.label5);
            this.grbQLyNhanVien.Controls.Add(this.label3);
            this.grbQLyNhanVien.Location = new System.Drawing.Point(2, 52);
            this.grbQLyNhanVien.Name = "grbQLyNhanVien";
            this.grbQLyNhanVien.Size = new System.Drawing.Size(416, 254);
            this.grbQLyNhanVien.TabIndex = 32;
            this.grbQLyNhanVien.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Thời Gian Bảo Hành :";
            // 
            // cbMaNhomLoai
            // 
            this.cbMaNhomLoai.FormattingEnabled = true;
            this.cbMaNhomLoai.Location = new System.Drawing.Point(136, 104);
            this.cbMaNhomLoai.Name = "cbMaNhomLoai";
            this.cbMaNhomLoai.Size = new System.Drawing.Size(259, 21);
            this.cbMaNhomLoai.TabIndex = 2;
            // 
            // txtThoiGianBaoHanh
            // 
            this.txtThoiGianBaoHanh.Location = new System.Drawing.Point(136, 131);
            this.txtThoiGianBaoHanh.Name = "txtThoiGianBaoHanh";
            this.txtThoiGianBaoHanh.Size = new System.Drawing.Size(259, 20);
            this.txtThoiGianBaoHanh.TabIndex = 3;
            // 
            // uctBaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnAn);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.pnlDSHangHoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grbDanhSachNhanVien);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbQLyNhanVien);
            this.Name = "uctBaoHanh";
            this.Size = new System.Drawing.Size(1245, 647);
            this.Load += new System.EventHandler(this.uctBaoHanh_Load);
            this.grbDanhSachNhanVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoHanh)).EndInit();
            this.grbQLyNhanVien.ResumeLayout(false);
            this.grbQLyNhanVien.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.ButtonX btnTimKiem;
        private DevComponents.DotNetBar.ButtonX btnHuy;
        private DevComponents.DotNetBar.ButtonX btnAn;
        private DevComponents.DotNetBar.ButtonX btnXoa;
        private DevComponents.DotNetBar.ButtonX btnThem;
        private System.Windows.Forms.Panel pnlDSHangHoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbDanhSachNhanVien;
        private System.Windows.Forms.DataGridView dgvBaoHanh;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnSua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbQLyNhanVien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMaNhomLoai;
        private System.Windows.Forms.TextBox txtThoiGianBaoHanh;
    }
}
