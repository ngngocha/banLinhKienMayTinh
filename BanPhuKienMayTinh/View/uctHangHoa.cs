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
    public partial class uctHangHoa : UserControl
    {
        public static int countThemLoaiHangHoa = 2;
        public uctHangHoa()
        {
            InitializeComponent();
        }


        //Khai báo biến để phân biệt lúc THÊM và SỬA
        int flag = 0;

        public static uctHangHoa uctHH = new uctHangHoa();

        //Khai báo hàm hiển thị DSHH - để đổ dữ liệu vào dataGridView
        public void HienThiDanhSachHangHoa()
        {
            //trỏ tới data Hàng Hóa
            dgvHangHoa.DataSource = Model.HangHoaMod.FilldatasetHangHoa().Tables[0];
            DoiTen();
            dgvHangHoa.Dock = DockStyle.Fill;
            dgvHangHoa.BorderStyle = BorderStyle.Fixed3D;
            dgvHangHoa.RowHeadersVisible = false;
        }
        void DoiTen()
        {
            dgvHangHoa.Columns[0].HeaderText = "Mã Hàng Hóa";
            dgvHangHoa.Columns[1].HeaderText = "Tên Hàng Hóa";
            dgvHangHoa.Columns[2].HeaderText = "Mã Nhóm Loại";
            dgvHangHoa.Columns[3].HeaderText = "Giá Bán";
            dgvHangHoa.Columns[4].HeaderText = "Đơn Vị Tính";
            dgvHangHoa.Columns[5].HeaderText = "Số Lượng Tồn";
            dgvHangHoa.Columns[6].HeaderText = "Mô tả";
        }


        void nhung(Control ctr, Panel panel)
        {
            pnlDSHangHoa.Controls.Clear();
            pnlDSHangHoa.BorderStyle = BorderStyle.Fixed3D;
            ctr.Dock = DockStyle.Fill;
            panel.Controls.Add(ctr);
            panel.Show();
        }

        private void uctHangHoa_Load(object sender, EventArgs e)
        {
            HienThiDanhSachHangHoa();
            dis_end(false);
            bingding();
        }
        void bingding()
        {
            //lưu ý cần trỏ đến tham số mà chúng ta khai báo
            txtMaHang.DataBindings.Clear();
            txtMaHang.DataBindings.Add("Text", dgvHangHoa.DataSource, "MaHH");
            txtTenHang.DataBindings.Clear();
            txtTenHang.DataBindings.Add("Text", dgvHangHoa.DataSource, "TenHH");
            cbNhomLoaiHangHoa.DataBindings.Clear();
            cbNhomLoaiHangHoa.DataBindings.Add("Text", dgvHangHoa.DataSource, "MaNhomLoai");
            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", dgvHangHoa.DataSource, "GiaBan");
            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", dgvHangHoa.DataSource, "MoTa");
            cbDonViTinh.DataBindings.Clear();
            cbDonViTinh.DataBindings.Add("Text", dgvHangHoa.DataSource, "DVTinh");
        }

        // Hàm dis-end các button khi load lên
        void dis_end(bool e)
        {
            txtMaHang.Enabled = e;
            txtTenHang.Enabled = e;
            txtGiaBan.Enabled = e;
            cbNhomLoaiHangHoa.Enabled = e;
            txtMoTa.Enabled = e;
            cbDonViTinh.Enabled = e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }
        // Hàm load đơn vị tính cho Hàng Hóa
        void loadcontrol()
        {
            cbDonViTinh.Items.Clear();
            cbDonViTinh.Items.Add("Cái");
            cbDonViTinh.Items.Add("Đôi");
            cbDonViTinh.Items.Add("Hộp");
            cbNhomLoaiHangHoa.DataSource = Model.HangHoaMod.dataSet_getMaNhomLoai().Tables[0];
            cbNhomLoaiHangHoa.DisplayMember = "MaNhomLoai";
            cbNhomLoaiHangHoa.ValueMember = "MaNhomLoai";
        }
        //Hàm xóa dữ liệu ở textbox lúc ta nhấn vào button
        void clearData()
        {
            txtMaHang.Text = Model.ConnectionToSQL.ExcuteScalar(string.Format(" select MaHH=dbo.fcgetIdHangHoa()"));
            txtTenHang.Text = "";
            txtGiaBan.Text = "";
            cbNhomLoaiHangHoa.Text = "";
            txtMoTa.Text = "";
            cbDonViTinh.Text = "";
            loadcontrol();//Gọi vào để load giới tính
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //load lại 
            uctHangHoa_Load(sender, e);
            dis_end(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // lúc click sửa sẽ mặc định cho flag = 1;
            flag = 1;
            dis_end(true); //lúc này các nút thêm sửa xóa sẽ ẩn đi, chỉ còn nút lưu và hủy
            loadcontrol();
            txtMaHang.Enabled = false;
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
            string _MaHH = "";
            try
            {
                _MaHH = txtMaHang.Text;
            }
            catch { }
            string _TenHH = "";
            try
            {
                _TenHH = txtTenHang.Text;
            }
            catch { }
            string _MaNhomLoai = "";
            try
            {
                _MaNhomLoai = cbNhomLoaiHangHoa.Text;
            }
            catch { }
            string _GiaBan = "";
            try
            {
                _GiaBan = txtGiaBan.Text;
            }
            catch { }
            string _DVTinh = "";
            try
            {
                _DVTinh = cbDonViTinh.Text;
            }
            catch { }
            string _MoTa = "";
            try
            {
                _MoTa = txtMoTa.Text;
            }
            catch { }
            if (flag == 0)
            {
                //Thêm mới
                if (_MaHH == "" || _TenHH == "" || _GiaBan == "")
                    MessageBox.Show("Hãy nhập đầy đủ thông tin ");
                else
                {
                    int i = 0;
                    i = Controller.HangHoaCtrl.InsertHangHoa(_MaHH, _TenHH, _MaNhomLoai, _GiaBan, _DVTinh, _MoTa);
                    if (i > 0)
                    {
                        MessageBox.Show("Thêm mới thành công !");
                        HienThiDanhSachHangHoa();
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
                i = Controller.HangHoaCtrl.UpdateHangHoa(_MaHH, _TenHH, _MaNhomLoai, _GiaBan, _DVTinh, _MoTa);
                if (i > 0)
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDanhSachHangHoa();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại !");
                }
            }
            uctHangHoa_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string _MaHH = "";
            try
            {
                _MaHH = txtMaHang.Text;
            }
            catch
            { }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controller.HangHoaCtrl.DeleteHangHoa(_MaHH);
                if (i > 0)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDanhSachHangHoa();
                    uctHangHoa_Load(sender, e);
                }
                else
                    MessageBox.Show("Xóa thông tin thành công !");
            }
            else
                return;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            uctSearchHangHoa uct5 = new uctSearchHangHoa();
            nhung(uct5, pnlDSHangHoa);
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            pnlDSHangHoa.Controls.Clear();
            pnlDSHangHoa.BorderStyle = BorderStyle.None;
        }
        private void btnThemLoaiHang_Click(object sender, EventArgs e)
        {
            countThemLoaiHangHoa++;
            uctSearchHangHoa uct5 = new uctSearchHangHoa();
            nhung(uct5, pnlDSHangHoa);
            //if (countThemLoaiHangHoa % 2 == 1)
            //{
            //    uctThemLoaiHang uct10 = new uctThemLoaiHang();
            //    nhung(uct10, pnlThemLoaiHang);
            //}
            //else
            //{
            //    pnlThemLoaiHang.Controls.Clear();
            //    pnlThemLoaiHang.BorderStyle = BorderStyle.None;
            //}
        }

    }
}
