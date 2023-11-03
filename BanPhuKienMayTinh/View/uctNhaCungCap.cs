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
    public partial class uctNhaCungCap : UserControl
    {
        public uctNhaCungCap()
        {
            InitializeComponent();
        }

        public static uctNhaCungCap uctNCC = new uctNhaCungCap();

        //Khai báo biến để phân biệt lúc THÊM và SỬA
        int flag = 0;

        public void HienThiDanhSachNhaCungCap()
        {
            //trỏ tới data nhà cung cấp
            dgvNhaCungCap.DataSource = Model.NhaCungCapMod.FilldatasetNhaCungCap().Tables[0];
            DoiTen();
            dgvNhaCungCap.Dock = DockStyle.Fill;
            dgvNhaCungCap.BorderStyle = BorderStyle.Fixed3D;
            dgvNhaCungCap.RowHeadersVisible = false;
        }
        void DoiTen()
        {
            dgvNhaCungCap.Columns[0].HeaderText = "Mã Nhà Cung Cấp";
            dgvNhaCungCap.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
            dgvNhaCungCap.Columns[2].HeaderText = "Địa Chỉ";
            dgvNhaCungCap.Columns[3].HeaderText = "Điện Thoại";
        }
        void nhung(Control ctr)
        {
            pnlDSNhaCungCap.Controls.Clear();
            pnlDSNhaCungCap.BorderStyle = BorderStyle.Fixed3D;
            ctr.Dock = DockStyle.Fill;
            pnlDSNhaCungCap.Controls.Add(ctr);
            pnlDSNhaCungCap.Show();
        }


        private void uctNhaCungCap_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNhaCungCap();
            dis_end(false);
            bingding();
        }

        void bingding()
        {
            //lưu ý cần trỏ đến tham số mà chúng ta khai báo
            txtMaNhaCungCap.DataBindings.Clear();
            txtMaNhaCungCap.DataBindings.Add("Text", dgvNhaCungCap.DataSource, "MaNhaCungCap");
            txtTenNhaCungCap.DataBindings.Clear();
            txtTenNhaCungCap.DataBindings.Add("Text", dgvNhaCungCap.DataSource, "TenNhaCungCap");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvNhaCungCap.DataSource, "DiaChi");
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", dgvNhaCungCap.DataSource, "SoDienThoai");
        }

        // Hàm dis-end các button khi load lên
        void dis_end(bool e)
        {
            txtMaNhaCungCap.Enabled = e;
            txtTenNhaCungCap.Enabled = e;
            txtDiaChi.Enabled = e;
            txtDienThoai.Enabled = e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        //Hàm xóa dữ liệu ở textbox lúc ta nhấn vào button
        void clearData()
        {
            txtMaNhaCungCap.Text = "";
            txtTenNhaCungCap.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //load lại 
            uctNhaCungCap_Load(sender, e);
            dis_end(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // lúc click sửa sẽ mặc định cho flag = 1;
            flag = 1;
            dis_end(true); //lúc này các nút thêm sửa xóa sẽ ẩn đi, chỉ còn nút lưu và hủy
            txtMaNhaCungCap.Enabled = false;
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
            string _MaNhaCungCap = "";
            try
            {
                _MaNhaCungCap = txtMaNhaCungCap.Text;
            }
            catch { }
            string _TenNhaCungCap = "";
            try
            {
                _TenNhaCungCap = txtTenNhaCungCap.Text;
            }
            catch { }
            string _DiaChi = "";
            try
            {
                _DiaChi = txtDiaChi.Text;
            }
            catch { }
            string _DienThoai = "";
            try
            {
                _DienThoai = txtDienThoai.Text;
            }
            catch { }
            if (flag == 0)
            {
                //Thêm mới
                if (_MaNhaCungCap == "" || _TenNhaCungCap == "")
                    MessageBox.Show("Hãy nhập đầy đủ thông tin ");
                else
                {
                    int i = 0;
                    i = Controller.NhaCungCapCtrl.InsertNhaCungCap(_MaNhaCungCap, _TenNhaCungCap, _DiaChi, _DienThoai);
                    if (i > 0)
                    {
                        MessageBox.Show("Thêm mới thành công !");
                        HienThiDanhSachNhaCungCap();
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
                i = Controller.NhaCungCapCtrl.UpdateNhaCungCap(_MaNhaCungCap, _TenNhaCungCap, _DiaChi, _DienThoai);
                if (i > 0)
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDanhSachNhaCungCap();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại !");
                }
            }
            uctNhaCungCap_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string _MaNhaCungCap = "";
            try
            {
                _MaNhaCungCap = txtMaNhaCungCap.Text;
            }
            catch
            { }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controller.NhaCungCapCtrl.DeleteNhaCungCap(_MaNhaCungCap);
                if (i > 0)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDanhSachNhaCungCap();
                    uctNhaCungCap_Load(sender, e);
                }
                else
                    MessageBox.Show("Xóa thông tin thành công !");
            }
            else
                return;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            uctSearchNhaCungCap uct5 = new uctSearchNhaCungCap();
            nhung(uct5);
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            pnlDSNhaCungCap.Controls.Clear();
            pnlDSNhaCungCap.BorderStyle = BorderStyle.None;
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDienThoai_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
