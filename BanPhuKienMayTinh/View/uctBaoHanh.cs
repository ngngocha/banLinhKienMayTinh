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
    public partial class uctBaoHanh : UserControl
    {
        int flag = 0;
        public uctBaoHanh()
        {
            InitializeComponent();
        }

        public static uctBaoHanh uctBH = new uctBaoHanh();

        private void uctBaoHanh_Load(object sender, EventArgs e)
        {
            HienThiDanhSachBaoHanh();
            dis_end(false);
            bingding();
        }

        void nhung(Control ctr, Panel panel)
        {
            pnlDSHangHoa.Controls.Clear();
            pnlDSHangHoa.BorderStyle = BorderStyle.Fixed3D;
            ctr.Dock = DockStyle.Fill;
            panel.Controls.Add(ctr);
            panel.Show();
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Resources.uctSearchBaoHanh uct5 = new Resources.uctSearchBaoHanh();
            nhung(uct5, pnlDSHangHoa);
        }

        void dis_end(bool e)
        {
            cbMaNhomLoai.Enabled = e;
            txtThoiGianBaoHanh.Enabled = e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        public void HienThiDanhSachBaoHanh()
        {
            //trỏ tới data Hàng Hóa
            dgvBaoHanh.DataSource = Model.BaoHanhMod.FillDataset_getBaoHanh().Tables[0];
            DoiTen();
            dgvBaoHanh.Dock = DockStyle.Fill;
            dgvBaoHanh.BorderStyle = BorderStyle.Fixed3D;
            dgvBaoHanh.RowHeadersVisible = false;
        }

        void DoiTen()
        {
            dgvBaoHanh.Columns[0].HeaderText = "Mã Nhóm Loại";
            dgvBaoHanh.Columns[1].HeaderText = "Thời Gian Bảo Hành";
        }
        
        // ta tạo hàm để trỏ đến dữ liệu trên datagridview
        void bingding()
        {
            //lưu ý cần trỏ đến tham số mà chúng ta khai báo
            cbMaNhomLoai.DataBindings.Clear();
            cbMaNhomLoai.DataBindings.Add("Text", dgvBaoHanh.DataSource, "MaNhomLoai");
            txtThoiGianBaoHanh.DataBindings.Clear();
            txtThoiGianBaoHanh.DataBindings.Add("Text", dgvBaoHanh.DataSource, "ThoiGianBaoHanh");
        }
        
        // Hàm load giới tính cho Khách Hàng
        void loadcontrol()
        {
            cbMaNhomLoai.DataSource = Model.BaoHanhMod.GetMaNhomLoaiHangHoa().Tables[0];
            cbMaNhomLoai.DisplayMember = "MaNhomLoai";
            cbMaNhomLoai.ValueMember = "MaNhomLoai";
        }
        //Hàm xóa dữ liệu ở textbox lúc ta nhấn vào button
        void clearData()
        {
            cbMaNhomLoai.Text = "";
            txtThoiGianBaoHanh.Text = "";
            loadcontrol();//Gọi vào để load giới tính
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //load lại 
            uctBaoHanh_Load(sender, e);
            dis_end(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // lúc click sửa sẽ mặc định cho flag = 1;
            flag = 1;
            dis_end(true); //lúc này các nút thêm sửa xóa sẽ ẩn đi, chỉ còn nút lưu và hủy
            cbMaNhomLoai.Enabled = false;
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
            string _MaNhomLoai = "";
            try
            {
                _MaNhomLoai = cbMaNhomLoai.Text;
            }
            catch { }
            string _NgayBaoHanh = "";
            try
            {
                _NgayBaoHanh = txtThoiGianBaoHanh.Text;
            }
            catch { }
            if (flag == 0)
            {
                //Thêm mới
                if (_MaNhomLoai == "" || _NgayBaoHanh == "")
                    MessageBox.Show("Hãy nhập đầy đủ thông tin ");
                else
                {
                    int i = 0;
                    i = Controller.BaoHanhCtrl.InsertBaoHanh(_MaNhomLoai, _NgayBaoHanh);
                    if (i > 0)
                    {
                        MessageBox.Show("Thêm mới thành công !");
                        HienThiDanhSachBaoHanh();
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
                i = Controller.BaoHanhCtrl.UpdateBaoHanh(_MaNhomLoai, _NgayBaoHanh);
                if (i > 0)
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDanhSachBaoHanh();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại !");
                }
            }
            uctBaoHanh_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string _MaNhomLoai = "";
            try
            {
                _MaNhomLoai = cbMaNhomLoai.Text;
            }
            catch
            { }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controller.BaoHanhCtrl.DeleteBaoHanh(_MaNhomLoai);
                if (i > 0)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDanhSachBaoHanh();
                    uctBaoHanh_Load(sender, e);
                }
                else
                    MessageBox.Show("Xóa thông tin không thành công !");
            }
            else
                return;
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            pnlDSHangHoa.Controls.Clear();
            pnlDSHangHoa.BorderStyle = BorderStyle.None;
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
