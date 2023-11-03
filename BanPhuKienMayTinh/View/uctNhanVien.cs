using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.View
{
    public partial class uctNhanVien : UserControl
    {
        public uctNhanVien()
        {
            InitializeComponent();
        }
        //Khai báo biến để phân biệt lúc THÊM và SỬA
        int flag = 0;
        public static uctNhanVien uctNV = new uctNhanVien();
        //Khai báo hàm hiển thị DSNV - để đổ dữ liệu vào dataGridView
        public void HienThiDanhSachNhanVien()
        {
            //trỏ tới data nhân viên
            dgvNhanVien.DataSource = Model.NhanVienMod.FilldatasetNhanVien().Tables[0];
            DoiTen();
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.BorderStyle = BorderStyle.Fixed3D;
            dgvNhanVien.RowHeadersVisible = false;
        }
        void DoiTen()
        {
            dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvNhanVien.Columns[1].HeaderText = "Họ và tên";
            dgvNhanVien.Columns[2].HeaderText = "Ngày Sinh";
            dgvNhanVien.Columns[3].HeaderText = "Điện Thoại";
            dgvNhanVien.Columns[4].HeaderText = "Email";
            dgvNhanVien.Columns[5].HeaderText = "Địa Chỉ";
            dgvNhanVien.Columns[6].HeaderText = "Giới Tính";
        }
        void nhung(Control ctr)
        {
            pnlDSNhanVien.Controls.Clear();
            pnlDSNhanVien.BorderStyle = BorderStyle.Fixed3D;
            ctr.Dock = DockStyle.Fill;
            pnlDSNhanVien.Controls.Add(ctr);
            pnlDSNhanVien.Show();
        }
        private void uctNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNhanVien();
            dis_end(false);
            bingding();
        }
        // ta tạo hàm để trỏ đến dữ liệu trên datagridview
        void bingding()
        {
            //lưu ý cần trỏ đến tham số mà chúng ta khai báo
            txtMaNhanVien.DataBindings.Clear();
            txtMaNhanVien.DataBindings.Add("Text", dgvNhanVien.DataSource, "MaNhanVien");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dgvNhanVien.DataSource, "TenNhanVien");
            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Text", dgvNhanVien.DataSource, "NgaySinh");
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", dgvNhanVien.DataSource, "DienThoai");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgvNhanVien.DataSource, "Email");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvNhanVien.DataSource, "DiaChi");
            cbGioiTinh.DataBindings.Clear();
            cbGioiTinh.DataBindings.Add("Text", dgvNhanVien.DataSource, "GioiTinh");
        }

        // Hàm dis-end các button khi load lên
        void dis_end(bool e)
        {
            txtTen.Enabled = e;
            dtpNgaySinh.Enabled = e;
            cbGioiTinh.Enabled = e;
            txtDiaChi.Enabled = e;
            txtDienThoai.Enabled = e;
            txtEmail.Enabled = e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }
        // Hàm load giới tính cho nhân viên
        void loadcontrol()
        {
            cbGioiTinh.Items.Clear();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.Items.Add("Khác");
        }
        //Hàm xóa dữ liệu ở textbox lúc ta nhấn vào button
        void clearData()
        {
            txtMaNhanVien.Text = Model.ConnectionToSQL.ExcuteScalar(string.Format(" select MaNhanVien=dbo.fcgetIdNhanVien()"));
            txtTen.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            loadcontrol();//Gọi vào để load giới tính
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //load lại 
            uctNhanVien_Load(sender, e);
            dis_end(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // lúc click sửa sẽ mặc định cho flag = 1;
            flag = 1;
            dis_end(true); //lúc này các nút thêm sửa xóa sẽ ẩn đi, chỉ còn nút lưu và hủy
            loadcontrol();
            txtMaNhanVien.Enabled = false;
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
            string _MaNhanVien = "";
            try
            {
                _MaNhanVien = txtMaNhanVien.Text;
            }
            catch { }
            string _HoTenNhanVien = "";
            try
            {
                _HoTenNhanVien = txtTen.Text;
            }
            catch { }
            DateTime _NgaysinhNhanVien = dtpNgaySinh.Value;
            try
            {

            }
            catch { }
            string _GioiTinhNhanVien = "";
            try
            {
                _GioiTinhNhanVien = cbGioiTinh.Text;
            }
            catch { }
            string _EmailNhanVien = "";
            try
            {
                _EmailNhanVien = txtEmail.Text;
            }
            catch { }
            string _DienThoaiNhanVien = "";
            try
            {
                _DienThoaiNhanVien = txtDienThoai.Text;
            }
            catch { }
            string _DiachiNhanVien = "";
            try
            {
                _DiachiNhanVien = txtDiaChi.Text;
            }
            catch { }
            if (flag == 0)
            {
                //Thêm mới
                if (_MaNhanVien == "" || _HoTenNhanVien == "")
                    MessageBox.Show("Hãy nhập đầy đủ thông tin ");
                else
                {
                    int i = 0;
                    i = Controller.NhanVienCtrl.InsertNhanVien(_MaNhanVien, _HoTenNhanVien, _NgaysinhNhanVien, _GioiTinhNhanVien, _DienThoaiNhanVien, _EmailNhanVien, _DiachiNhanVien);
                    if (i > 0)
                    {
                        MessageBox.Show("Thêm mới thành công !");
                        HienThiDanhSachNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại !");
                    }
                }
            }
            else
            {
                //sửa
                int i = 0;
                i = Controller.NhanVienCtrl.UpdateNhanVien(_MaNhanVien, _HoTenNhanVien, _NgaysinhNhanVien, _GioiTinhNhanVien, _DienThoaiNhanVien, _EmailNhanVien, _DiachiNhanVien);
                if (i > 0)
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại !");
                }
            }
            uctNhanVien_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string _MaNhanVien = "";
            try
            {
                _MaNhanVien = txtMaNhanVien.Text;
            }
            catch
            { }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controller.NhanVienCtrl.DeleteNhanVien(_MaNhanVien);
                if (i > 0)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDanhSachNhanVien();
                    uctNhanVien_Load(sender, e);
                }
                else
                    MessageBox.Show("Xóa thông tin thành công !");
            }
            else
                return;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            uctSearchNhanVien uct5 = new uctSearchNhanVien();
            nhung(uct5);
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            pnlDSNhanVien.Controls.Clear();
            pnlDSNhanVien.BorderStyle = BorderStyle.None;
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
