using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanPhuKienMayTinh.View
{
    public partial class uctQuanLyTaiKhoan : UserControl
    {
        static int seepassword = 2;
        public uctQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        public static uctQuanLyTaiKhoan uctQLTK = new uctQuanLyTaiKhoan();
        //Khai báo biến để phân biệt lúc THÊM và SỬA
        int flag = 0;

        private void uctQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            HienThiDanhSachTaiKhoan();
            dis_end(false);
            bingding();
        }
        //Khai báo hàm hiển thị DSHH - để đổ dữ liệu vào dataGridView
        public void HienThiDanhSachTaiKhoan()
        {
            //trỏ tới data Hàng Hóa
            dgvTaiKhoan.DataSource = Model.QuanLyTaiKhoanMod.FilldatasetTaiKhoan().Tables[0];
            DoiTen();
            dgvTaiKhoan.Dock = DockStyle.Fill;
            dgvTaiKhoan.BorderStyle = BorderStyle.Fixed3D;
            dgvTaiKhoan.RowHeadersVisible = false;
            txtPassword.Text = "";
        }
        void DoiTen()
        {
            dgvTaiKhoan.Columns[0].HeaderText = "IDTK";
            dgvTaiKhoan.Columns[1].HeaderText = "Loại Tài Khoản";
        }
        void nhung(Control ctr, Panel panel)
        {
            pnlDSTaiKhoan.Controls.Clear();
            pnlDSTaiKhoan.BorderStyle = BorderStyle.Fixed3D;
            ctr.Dock = DockStyle.Fill;
            panel.Controls.Add(ctr);
            panel.Show();
        }
        void bingding()
        {
            //lưu ý cần trỏ đến tham số mà chúng ta khai báo
            txtIDTK.DataBindings.Clear();
            txtIDTK.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "IDTK");
            txtPassword.DataBindings.Clear();
            cbPhanQuyen.DataBindings.Clear();
            cbPhanQuyen.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "LoaiTK");
        }
        void dis_end(bool e)
        {
            txtIDTK.Enabled = e;
            txtPassword.Enabled = e;
            cbPhanQuyen.Enabled = e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }
        void loadcontrol()
        {
            cbPhanQuyen.Items.Clear();
            cbPhanQuyen.Items.Add("Quản Lý");
            cbPhanQuyen.Items.Add("Nhân Viên");
        }
        void clearData()
        {
            txtIDTK.Text = "";
            txtPassword.Text = "";
            cbPhanQuyen.Text = "";
            loadcontrol();//Gọi vào để load loại tài khoản
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            //load lại 
            uctQuanLyTaiKhoan_Load(sender, e);
            dis_end(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // lúc click sửa sẽ mặc định cho flag = 1;
            flag = 1;
            dis_end(true); //lúc này các nút thêm sửa xóa sẽ ẩn đi, chỉ còn nút lưu và hủy
            txtIDTK.Enabled = false;
            loadcontrol();
            bingding();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            clearData();
            dis_end(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // khai báo các biến
            string _IDTK = "";
            try
            {
                _IDTK = txtIDTK.Text;
            }
            catch { }
            string _Password = "";
            try
            {
                _Password = txtPassword.Text;
            }
            catch { }
            string _LoaiTK = "";
            try
            {
                _LoaiTK = cbPhanQuyen.Text;
            }
            catch { }
            if (flag == 0)
            {
                //Thêm mới
                if (_IDTK == "" || _Password == "" || _LoaiTK == "")
                    MessageBox.Show("Hãy nhập đầy đủ thông tin ");
                else if (_LoaiTK != "Quản Lý" && _LoaiTK != "Nhân Viên")
                    MessageBox.Show("Chỉ được chọn Quản lý hoặc nhân viên");
                else
                {
                    int i = 0;
                    i = Controller.QuanLyTaiKhoanCtrl.InsertTaiKhoan(_IDTK, _Password, _LoaiTK);
                    if (i > 0)
                    {
                        MessageBox.Show("Thêm mới thành công !");
                        HienThiDanhSachTaiKhoan();
                    }
                    else
                    {
                        MessageBox.Show("Trùng IDTK", "Thêm mới thất bại !");
                    }
                }
            }
            else
            {
                //sửa
                int i = 0;
                i = Controller.QuanLyTaiKhoanCtrl.UpdateTaiKhoan(_IDTK, _Password, _LoaiTK);
                if (i > 0)
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDanhSachTaiKhoan();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại !");
                }
            }
            uctQuanLyTaiKhoan_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string _IDTK = "";
            try
            {
                _IDTK = txtIDTK.Text;
            }
            catch
            { }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controller.QuanLyTaiKhoanCtrl.DeleteTaiKhoan(_IDTK);
                if (i > 0)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDanhSachTaiKhoan();
                    uctQuanLyTaiKhoan_Load(sender, e);
                }
                else
                    MessageBox.Show("Xóa thông tin không thành công !");
            }
            else
                return;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            uctSearchTaiKhoan uct5 = new uctSearchTaiKhoan();
            nhung(uct5, pnlDSTaiKhoan);
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            pnlDSTaiKhoan.Controls.Clear();
            pnlDSTaiKhoan.BorderStyle = BorderStyle.None;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            seepassword += 1;
            if(seepassword % 2 == 1)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
