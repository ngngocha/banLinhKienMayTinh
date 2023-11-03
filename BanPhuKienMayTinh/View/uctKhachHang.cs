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
    public partial class uctKhachHang : UserControl
    {
        public uctKhachHang()
        {
            InitializeComponent();
        }
        //Khai báo biến để phân biệt lúc THÊM và SỬA
        int flag = 0;
        public static uctKhachHang uctKH = new uctKhachHang();
        //Khai báo hàm hiển thị DSKH - để đổ dữ liệu vào dataGridView
        public void HienThiDanhSachKhachHang()
        {
            //trỏ tới data Khách Hàng
            dgvKhachHang.DataSource = Model.KhachHangMod.FilldatasetKhachHang().Tables[0];
            DoiTen();
            dgvKhachHang.Dock = DockStyle.Fill;
            dgvKhachHang.BorderStyle = BorderStyle.Fixed3D;
            dgvKhachHang.RowHeadersVisible = false;
        }
        void DoiTen()
        {
            dgvKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns[2].HeaderText = "Ngày Sinh";
            dgvKhachHang.Columns[3].HeaderText = "Điện Thoại";
            dgvKhachHang.Columns[4].HeaderText = "Email";
            dgvKhachHang.Columns[5].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns[6].HeaderText = "Giới Tính";
        }
        void nhung(Control ctr)
        {
            pnlDSKhachHang.Controls.Clear();
            pnlDSKhachHang.BorderStyle = BorderStyle.Fixed3D;
            ctr.Dock = DockStyle.Fill;
            pnlDSKhachHang.Controls.Add(ctr);
            pnlDSKhachHang.Show();
        }
        private void uctKhachHang_Load(object sender, EventArgs e)
        {
            HienThiDanhSachKhachHang();
            dis_end(false);
            bingding();
        }
        // ta tạo hàm để trỏ đến dữ liệu trên datagridview
        void bingding()
        {
            //lưu ý cần trỏ đến tham số mà chúng ta khai báo
            txtMaKhachHang.DataBindings.Clear();
            txtMaKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "MaKhachHang");
            txtHoLot.DataBindings.Clear();
            txtHoLot.DataBindings.Add("Text", dgvKhachHang.DataSource, "TenKhachHang");
            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Text", dgvKhachHang.DataSource, "NgaySinh");
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", dgvKhachHang.DataSource, "DienThoai");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgvKhachHang.DataSource, "Email");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvKhachHang.DataSource, "DiaChi");
            cbGioiTinh.DataBindings.Clear();
            cbGioiTinh.DataBindings.Add("Text", dgvKhachHang.DataSource, "GioiTinh");
        }

        // Hàm dis-end các button khi load lên
        void dis_end(bool e)
        {
            txtHoLot.Enabled = e;
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
        // Hàm load giới tính cho Khách Hàng
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
            txtMaKhachHang.Text = Model.ConnectionToSQL.ExcuteScalar(string.Format(" select MaKhachHang=dbo.fcgetIdKhachHang()"));
            txtHoLot.Text = "";
            txtHoLot.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            loadcontrol();//Gọi vào để load giới tính
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //load lại 
            uctKhachHang_Load(sender, e);
            dis_end(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // lúc click sửa sẽ mặc định cho flag = 1;
            flag = 1;
            dis_end(true); //lúc này các nút thêm sửa xóa sẽ ẩn đi, chỉ còn nút lưu và hủy
            loadcontrol();
            txtMaKhachHang.Enabled = false;
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
            string _MaKhachHang = "";
            try
            {
                _MaKhachHang = txtMaKhachHang.Text;
            }
            catch { }
            string _HoLotKhachHang = "";
            try
            {
                _HoLotKhachHang = txtHoLot.Text;
            }
            catch { }
            DateTime _NgaySinhKhachHang = dtpNgaySinh.Value;
            try
            {

            }
            catch { }
            string _GioiTinhKhachHang = "";
            try
            {
                _GioiTinhKhachHang = cbGioiTinh.Text;
            }
            catch { }
            string _EmailKhachHang = "";
            try
            {
                _EmailKhachHang = txtEmail.Text;
            }
            catch { }
            string _DienThoaiKhachHang = "";
            try
            {
                _DienThoaiKhachHang = txtDienThoai.Text;
            }
            catch { }
            string _DiaChiKhachHang = "";
            try
            {
                _DiaChiKhachHang = txtDiaChi.Text;
            }
            catch { }
            if (flag == 0)
            {
                //Thêm mới
                if (_MaKhachHang == "" || _HoLotKhachHang == "")
                    MessageBox.Show("Hãy nhập đầy đủ thông tin ");
                else
                {
                    int i = 0;
                    i = Controller.KhachHangCtrl.InsertKhachHang(_MaKhachHang, _HoLotKhachHang, _NgaySinhKhachHang, _GioiTinhKhachHang, _DienThoaiKhachHang, _EmailKhachHang, _DiaChiKhachHang);
                    if (i > 0)
                    {
                        MessageBox.Show("Thêm mới thành công !");
                        HienThiDanhSachKhachHang();
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
                i = Controller.KhachHangCtrl.UpdateKhachHang(_MaKhachHang, _HoLotKhachHang, _NgaySinhKhachHang, _GioiTinhKhachHang, _DienThoaiKhachHang, _EmailKhachHang, _DiaChiKhachHang);
                if (i > 0)
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDanhSachKhachHang();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại !");
                }
            }
            uctKhachHang_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string _MaKhachHang = "";
            try
            {
                _MaKhachHang = txtMaKhachHang.Text;
            }
            catch
            { }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controller.KhachHangCtrl.DeleteKhachHang(_MaKhachHang);
                if (i > 0)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDanhSachKhachHang();
                    uctKhachHang_Load(sender, e);
                }
                else
                    MessageBox.Show("Xóa thông tin thành công !");
            }
            else
                return;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            uctSearchKhachHang uct5 = new uctSearchKhachHang();
            nhung(uct5);
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            pnlDSKhachHang.Controls.Clear();
            pnlDSKhachHang.BorderStyle = BorderStyle.None;
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
