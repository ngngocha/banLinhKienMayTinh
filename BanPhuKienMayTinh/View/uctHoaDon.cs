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
    public partial class uctHoaDon : UserControl
    {
        public uctHoaDon()
        {
            InitializeComponent();
        }
        //Khai báo biến để phân biệt lúc THÊM và SỬA
        int flag = 0;
        string _ChiTietKhuyenMai = "";
        string _IDKhuyenMai = "";
        int GiamGia = 0;
        public static uctHoaDon uctHD = new uctHoaDon();
        
        //Khai báo hàm hiển thị DSHD - để đổ dữ liệu vào dataGridView
        public void HienThiDanhSachHoaDon()
        {
            //trỏ tới data nhân viên
            dgvHoaDon.DataSource = Model.HoaDonMod.FilldatasetHoaDon().Tables[0];
            DoiTen();
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.BorderStyle = BorderStyle.Fixed3D;
            dgvHoaDon.RowHeadersVisible = false;
            //Bảng DSHH
            dgvDSHH.DataSource = Model.CTDHMod.getCTHDHangHoa().Tables[0];
            DoiTen1();
            dgvDSHH.Dock = DockStyle.Fill;
            dgvDSHH.BorderStyle = BorderStyle.Fixed3D;
            dgvDSHH.RowHeadersVisible = false;
        }
        private void thanhtien()
        {
            
        }
        void DoiTen()
        {
            dgvHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvHoaDon.Columns[1].HeaderText = "Ngày Lập";
            dgvHoaDon.Columns[2].HeaderText = "Tên Nhân Viên";
            dgvHoaDon.Columns[3].HeaderText = "Tên Khách Hàng";
            dgvHoaDon.Columns[4].HeaderText = "Tổng Tiền";
        }
        void DoiTen1()
        {
            dgvDSHH.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvDSHH.Columns[1].HeaderText = "Tên Hàng Hóa";
            dgvDSHH.Columns[2].HeaderText = "Số Lượng";
            dgvDSHH.Columns[3].HeaderText = "Đơn Giá";
            dgvDSHH.Columns[4].HeaderText = "Thành Tiền";
            dgvDSHH.Columns[5].HeaderText = "Thời Gian Bảo Hành";
            dgvDSHH.Columns[6].HeaderText = "IMEI";
            dgvDSHH.Columns[7].HeaderText = "ID Khuyến Mãi";
        }
        private void uctHoaDon_Load(object sender, EventArgs e)
        {
            lbPhanTramGiamGia.Visible = false;
            cbHinhThucKhuyenMai.Enabled = false;
            txtThoiLuongBaoHanh.Enabled = false;
            btnHangKhuyenMai.Enabled = false;
            cbIDKhuyenMai.Text = "";
            cbIDKhuyenMai.Enabled = false;
            txtMa.Enabled = false;
            btnChiTietKhuyenMai.Enabled = false;
            HienThiDanhSachHoaDon();
            txtDonGia.Enabled = false;
            dis_end(false);
            bingding();
            thanhtien();
        }
        void bingding()
        {
            //lưu ý cần trỏ đến tham số mà chúng ta khai báo
            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", dgvHoaDon.DataSource, "MaHD");
            dtpNgayLap.DataBindings.Clear();
            dtpNgayLap.DataBindings.Add("Text", dgvHoaDon.DataSource, "NgayLapHoaDon");
            cbNhanVien.DataBindings.Clear();
            cbNhanVien.DataBindings.Add("Text", dgvHoaDon.DataSource, "TenNhanVien");
            cbKhachHang.DataBindings.Clear();
            cbKhachHang.DataBindings.Add("Text", dgvHoaDon.DataSource, "TenKhachHang");
            cbHH.DataBindings.Clear();
            cbHH.DataBindings.Add("Text", dgvDSHH.DataSource, "TenHH");
            txtSoLuongDeXoa.DataBindings.Clear();
            txtSoLuongDeXoa.DataBindings.Add("Text", dgvDSHH.DataSource, "SoLuong");
        }

        // Hàm dis-end các button khi load lên
        void dis_end(bool e)
        {
            dtpThoiGianBaoHanh.Enabled = e;
            txtIMEI.Enabled = e;
            dtpNgayLap.Enabled = e;
            cbNhanVien.Enabled = e;
            cbKhachHang.Enabled = e;
            cbHH.Enabled = e;
            txtSL.Enabled = e;
            btnThem.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnADD.Enabled = e;
            btnInHD.Enabled = e;
            btnXoa.Enabled = !e;
            btnLess.Enabled = e;
        }
        void loadcontrol()
        {
            //gọi lại hàm thông qua HD mod
            cbKhachHang.DataSource = Model.HoaDonMod.getTenKhachHang().Tables[0];
            //Dùng biến MaKH để hiển thị (Lấy giá trị TenKH)
            cbKhachHang.DisplayMember = "TenKhachHang";
            cbKhachHang.ValueMember = "TenKhachHang";
            //gọi lại hàm thông qua HD mod
            cbNhanVien.DataSource = Model.HoaDonMod.getTenNhanVien().Tables[0];
            //Dùng biến MaKH để hiển thị (Lấy giá trị TenKH)
            cbNhanVien.DisplayMember = "TenNhanVien";
            cbNhanVien.ValueMember = "TenNhanVien";
            cbHH.DataSource = Model.CTDHMod.getCTHDHangHoa123().Tables[0];
            cbHH.DisplayMember = "TenHH";
            cbHH.ValueMember = "TenHH";
            cbHinhThucKhuyenMai.Items.Clear();
            cbHinhThucKhuyenMai.Items.Add("Giảm giá phần trăm");
            cbHinhThucKhuyenMai.Items.Add("Tặng kèm sản phẩm");
        }
        void clearData()
        {
            txtMa.Text = Model.ConnectionToSQL.ExcuteScalar(string.Format(" select MaHD=dbo.fcgetMaHD()"));
            dtpNgayLap.Text = "";
            loadcontrol();//Gọi vào để load
            cbNhanVien.Text = "";
            cbKhachHang.Text = "";
            cbHH.Text = "";
            txtDonGia.Text = "";
            txtIMEI.Text = "";
            cbIDKhuyenMai.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            clearData();
            dis_end(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //load lại 
            uctHoaDon_Load(sender, e);
            dis_end(false);
            lbThanhTien.Text = "0";
            lbTongHoaDon.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // khai báo các biến
            string _MaHD = "";
            try
            {
                _MaHD = txtMa.Text;
            }
            catch { }
            string _MaNhanVien = "";
            try
            {
                _MaNhanVien = cbNhanVien.Text;
            }
            catch { }
            DateTime _NgayLapHD = dtpNgayLap.Value;
            try
            {

            }
            catch { }
            string _MaKhachHang = "";
            try
            {
                _MaKhachHang = cbKhachHang.Text;
            }
            catch { }
            string _TenHH = "";
            try
            {
                _TenHH = cbHH.Text;
            }
            catch { }
            string _DonGia = "";
            try
            {
                _DonGia = txtDonGia.Text;
            }
            catch { }
            string _SoLuong = "";
            try
            {
                _SoLuong = txtSL.Text;
            }
            catch { }
            string _ThanhTien = "";
            try
            {
                _ThanhTien = lbTongHoaDon.Text;
            }
            catch { }
            DateTime _ThoiGianBaoHanh = dtpThoiGianBaoHanh.Value;
            try
            {

            }
            catch { }
            string _IMEI = "";
            try
            {
                _IMEI = txtIMEI.Text;
            }
            catch { }
            if (flag == 0)
            {
                //Thêm mới
                if (_MaHD == "" || _MaKhachHang == "" || _TenHH == "" || _ThanhTien == "0")
                    MessageBox.Show("Hãy nhập đầy đủ thông tin ");
                else
                {
                    int i = 0, j = 0;
                    i = Controller.HoaDonCtrl.InsertHoaDon(_MaHD, _NgayLapHD, _MaNhanVien, _MaKhachHang, _ThanhTien);
                    if (i > 0)
                    {
                        MessageBox.Show("Thêm mới thành công !");
                        HienThiDanhSachHoaDon();
                        lbThanhTien.Text = "0";
                        lbTongHoaDon.Text = "0";
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại !");
                    }
                }
            }
            uctHoaDon_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string _MaHD = "";
            try
            {
                _MaHD = txtMa.Text;
            }
            catch
            { }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controller.HoaDonCtrl.DeleteHoaDon(_MaHD);
                i = Controller.CTHDCtrl.DeleteCTHD(_MaHD);
                if (i > 0)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDanhSachHoaDon();
                    uctHoaDon_Load(sender, e);
                }
                else
                    MessageBox.Show("Xóa thông tin thành công !");
            }
            else
                return;
        
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Controller.CTHDCtrl.FillDataSet_FilldatasetCTHDbyIDHD(txtMa.Text);//Note
        }

        //private void txtDonGia_TextChanged(object sender, EventArgs e)
        //{
        //    txtDonGia.Text = cbHH.SelectedValue.ToString();//Note
        //}

        //private void txtDonGia_TabIndexChanged(object sender, EventArgs e)
        //{
        //    txtDonGia.Text = cbHH.SelectedValue.ToString();//Note
        //}

        private void btnADD_Click(object sender, EventArgs e)
        {
            float m = float.Parse(lbThanhTien.Text.ToString());
            float n = float.Parse(txtPhanTramGiamGia.Text.ToString());
            float s = m - m * n / (100.0f);
            lbThanhTien.Text = s.ToString();
            // khai báo các biến
            string _MaHD = "";
            try
            {
                _MaHD = txtMa.Text;
            }
            catch { }
            string _TenHH = "";
            try
            {
                _TenHH = cbHH.Text;
            }
            catch { }
            string _SoLuong = "";
            try
            {
                _SoLuong = txtSL.Text;
            }
            catch { }
            string _DonGia = "";
            try
            {
                _DonGia = txtDonGia.Text;
            }
            catch { }
            string _ThanhTien = "";
            try
            {
                _ThanhTien = lbThanhTien.Text;
            }
            catch { }
            DateTime _ThoiGianBaoHanh = dtpThoiGianBaoHanh.Value;
            try
            {

            }
            catch { }
            string _IMEI = "";
            try
            {
                _IMEI = txtIMEI.Text;
            }
            catch { }
            string _TinhTrangBaoHanh = "";
            try
            {
                
            }
            catch { }
            string _IDKhuyenMai = "";
            try
            {
                _IDKhuyenMai = cbIDKhuyenMai.Text;
            }
            catch { }
            if (flag == 0)
            {
                //Thêm mới
                if (_MaHD == "" || _TenHH == "" || _SoLuong == "" || _IMEI == "" )
                    MessageBox.Show("Hãy nhập đầy đủ thông tin ");
                else
                {
                    int i = 0;
                    i = Controller.CTHDCtrl.InsertCTHD(_MaHD, _TenHH, _SoLuong, _DonGia, _ThanhTien, _ThoiGianBaoHanh, _IMEI, _TinhTrangBaoHanh, _IDKhuyenMai);
                    if (i > 0) i = Controller.CTHDCtrl.UpdateSoLuong(_TenHH, _SoLuong);
                    if (i > 0)
                    {
                        MessageBox.Show("Thêm mới thành công !");
                        HienThiDanhSachHoaDon();
                        m = float.Parse(lbThanhTien.Text.ToString());
                        n = float.Parse(lbTongHoaDon.Text.ToString());
                        s = n + m;
                        lbTongHoaDon.Text = s.ToString();
                        if (GiamGia != 0)
                        {
                            GiamGia = GiamGia - 1;
                        }
                        txtPhanTramGiamGia.Text = "0";
                        txtPhanTramGiamGia.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại !");
                    }
                }
                HienThiDanhSachHoaDon();
            }
        }

        private void btnLess_Click(object sender, EventArgs e)
        {
            string _MaHD = "";
            try
            {
                _MaHD = txtMa.Text;
            }
            catch { }
            string _TenHH = "";
            try
            {
                _TenHH = cbHH.Text;
            }
            catch { }
            string _SoLuong = "";
            try
            {
                _SoLuong = "-" + txtSL.Text;
            }
            catch { }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn bỏ ra khỏi giỏ hàng ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controller.CTHDCtrl.DeleteCTHDTheoCTHD(_MaHD, _TenHH);
                if (i > 0) i = Controller.CTHDCtrl.UpdateSoLuong(_TenHH, _SoLuong);
                if (i > 0)
                {
                    MessageBox.Show("Xóa mặt hàng thành công !");
                    HienThiDanhSachHoaDon();
                    float m = float.Parse(lbThanhTien.Text.ToString());
                    float n = float.Parse(lbTongHoaDon.Text.ToString());
                    float s = n - m;
                    lbTongHoaDon.Text = s.ToString();
                }
                else
                    MessageBox.Show("Xóa thông tin thành công !");
            }
            else
                return;
        }

        

        private void cbHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnChiTietKhuyenMai.Enabled = false;
            btnHangKhuyenMai.Enabled = false;
            dtpKhuyenMai.Text = "01/01/2000";
            string _TenHH = cbHH.Text;
            dgvPhuQuanLyHoaDon.DataSource = Controller.CTHDCtrl.FillDataset_getspCTHD(_TenHH).Tables[0];
            dgvKhuyenMai.DataSource = Controller.CTHDCtrl.FillDataset_getKhuyenMaiCTHD(_TenHH).Tables[0]; txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dgvPhuQuanLyHoaDon.DataSource, "GiaBan");
            txtThoiLuongBaoHanh.DataBindings.Clear();
            txtThoiLuongBaoHanh.DataBindings.Add("Text", dgvPhuQuanLyHoaDon.DataSource, "ThoiGianBaoHanh");
            cbIDKhuyenMai.DataBindings.Clear();
            cbIDKhuyenMai.DataBindings.Add("Text", dgvKhuyenMai.DataSource, "IDKhuyenMai");
            dtpKhuyenMai.DataBindings.Clear();
            dtpKhuyenMai.DataBindings.Add("Text", dgvKhuyenMai.DataSource, "ThoiGianApDung");
            if (GiamGia == 0 && dgvKhuyenMai.Text != "01/01/2000")
            {
                _IDKhuyenMai = cbIDKhuyenMai.Text;
                if (cbIDKhuyenMai.Text != "" && dtpKhuyenMai.Value >= dtpNgayLap.Value)
                {
                    btnHangKhuyenMai.Enabled = true;
                    btnChiTietKhuyenMai.Enabled = true;
                    txtChiTietKhuyenMai.DataBindings.Clear();
                    txtChiTietKhuyenMai.DataBindings.Add("Text", dgvKhuyenMai.DataSource, "ChiTiet");
                    _ChiTietKhuyenMai = txtChiTietKhuyenMai.Text;
                }
                else
                {
                    btnHangKhuyenMai.Enabled = false;
                    btnChiTietKhuyenMai.Enabled = false;
                    cbHinhThucKhuyenMai.Enabled = false;
                }
            }
            else
            {
                txtDonGia.Text = "0";
            }
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            float i = float.Parse(txtDonGia.Text.ToString());
            float j = float.Parse(txtSL.Text.ToString());
            float s = i * j;
            lbThanhTien.Text = s.ToString();
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (txtDonGia.Text != "System.Data.DataRowView" && txtDonGia.Text != "")
            {
                float i = float.Parse(txtDonGia.Text.ToString());
                float j = float.Parse(txtSL.Text.ToString());
                float s = i * j;
                lbThanhTien.Text = s.ToString();
            }
        }

        private void btnChiTietKhuyenMai_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_ChiTietKhuyenMai, _IDKhuyenMai);
        }

        private void btnHangKhuyenMai_Click(object sender, EventArgs e)
        {
            cbHinhThucKhuyenMai.Enabled = true;
        }

        private void txtPhanTramGiamGia_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbHinhThucKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbHinhThucKhuyenMai.Text == "Giảm giá phần trăm")
            {
                lbPhanTramGiamGia.Visible = true;
                txtPhanTramGiamGia.Visible = true;
                GiamGia = 0;
            }
            if (cbHinhThucKhuyenMai.Text == "Tặng kèm sản phẩm")
            {
                txtPhanTramGiamGia.Text = "0";
                lbPhanTramGiamGia.Visible = false;
                txtPhanTramGiamGia.Visible = false;
                GiamGia = 2;
            }
        }

        private void txtIMEI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhanTramGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
