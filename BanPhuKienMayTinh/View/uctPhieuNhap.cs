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
    public partial class uctPhieuNhap : UserControl
    {
        public uctPhieuNhap()
        {
            InitializeComponent();
        }

        public static uctPhieuNhap uctPN = new uctPhieuNhap();


        //Khai báo biến để phân biệt lúc THÊM và SỬA
        int flag = 0;

        public void HienThiDanhSachPhieuNhap()
        {
            //trỏ tới data nhân viên
            dgvPhieuNhap.DataSource = Model.PhieuNhapMod.FilldatasetPhieuNhap().Tables[0];
            DoiTen();
            dgvPhieuNhap.Dock = DockStyle.Fill;
            dgvPhieuNhap.BorderStyle = BorderStyle.Fixed3D;
            dgvPhieuNhap.RowHeadersVisible = false;
            //Bảng DSHH
            dgvDSHH.DataSource = Model.ChiTietPhieuNhapMod.getCTPNHangHoa().Tables[0];
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
            dgvPhieuNhap.Columns[0].HeaderText = "Mã Phiếu Nhập";
            dgvPhieuNhap.Columns[1].HeaderText = "Ngày Lập";
            dgvPhieuNhap.Columns[2].HeaderText = "Tên Nhân Viên";
            dgvPhieuNhap.Columns[3].HeaderText = "Tên Nhà Cung Cấp";
            dgvPhieuNhap.Columns[4].HeaderText = "Tổng Tiền";
        }
        void DoiTen1()
        {
            dgvDSHH.Columns[0].HeaderText = "Mã Phiếu Nhập";
            dgvDSHH.Columns[1].HeaderText = "Tên Hàng Hóa";
            dgvDSHH.Columns[2].HeaderText = "Số Lượng";
            dgvDSHH.Columns[3].HeaderText = "Đơn Giá";
            dgvDSHH.Columns[4].HeaderText = "Thành Tiền";
        }
        private void uctPhieuNhap_Load(object sender, EventArgs e)
        {
            txtMa.Enabled = false;
            HienThiDanhSachPhieuNhap();
            dis_end(false);
            bingding();
            thanhtien();
        }
        void bingding()
        {
            //lưu ý cần trỏ đến tham số mà chúng ta khai báo
            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", dgvPhieuNhap.DataSource, "MaPN");
            dtpNgayLap.DataBindings.Clear();
            dtpNgayLap.DataBindings.Add("Text", dgvPhieuNhap.DataSource, "NgayLapPhieuNhap");
            cbNhanVien.DataBindings.Clear();
            cbNhanVien.DataBindings.Add("Text", dgvPhieuNhap.DataSource, "TenNhanVien");
            cbNhaCungCap.DataBindings.Clear();
            cbNhaCungCap.DataBindings.Add("Text", dgvPhieuNhap.DataSource, "TenNhaCungCap");
            cbHH.DataBindings.Clear();
            cbHH.DataBindings.Add("Text", dgvDSHH.DataSource, "TenHH");
        }

        // Hàm dis-end các button khi load lên
        void dis_end(bool e)
        {
            txtDonGia.Enabled = e;
            dtpNgayLap.Enabled = e;
            cbNhanVien.Enabled = e;
            cbNhaCungCap.Enabled = e;
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
            cbNhaCungCap.DataSource = Model.PhieuNhapMod.getTenNhaCungCap().Tables[0];
            //Dùng biến MaKH để hiển thị (Lấy giá trị TenKH)
            cbNhaCungCap.DisplayMember = "TenNhaCungCap";
            cbNhaCungCap.ValueMember = "TenNhaCungCap";
            //gọi lại hàm thông qua HD mod
            cbNhanVien.DataSource = Model.HoaDonMod.getTenNhanVien().Tables[0];
            //Dùng biến MaKH để hiển thị (Lấy giá trị TenKH)
            cbNhanVien.DisplayMember = "TenNhanVien";
            cbNhanVien.ValueMember = "TenNhanVien";
            cbHH.DataSource = Model.ChiTietPhieuNhapMod.getCTPNHangHoa123().Tables[0];
            cbHH.DisplayMember = "TenHH";
            cbHH.ValueMember = "TenHH";
        }
        void clearData()
        {
            txtMa.Text = Model.ConnectionToSQL.ExcuteScalar(string.Format(" select MaPN=dbo.fcgetMaPN()"));
            dtpNgayLap.Text = "";
            loadcontrol();//Gọi vào để load
            cbNhanVien.Text = "";
            cbNhaCungCap.Text = "";
            cbHH.Text = "";
            txtDonGia.Text = "";
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
            uctPhieuNhap_Load(sender, e);
            dis_end(false);
            lbThanhTien.Text = "0";
            lbTongHoaDon.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // khai báo các biến
            string _MaPN = "";
            try
            {
                _MaPN = txtMa.Text;
            }
            catch { }
            string _MaNhanVien = "";
            try
            {
                _MaNhanVien = cbNhanVien.Text;
            }
            catch { }
            DateTime _NgayLapPN = dtpNgayLap.Value;
            try
            {

            }
            catch { }
            string _MaNhaCungCap = "";
            try
            {
                _MaNhaCungCap = cbNhaCungCap.Text;
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
            if (flag == 0)
            {
                //Thêm mới
                if (_MaPN == "" || _MaNhaCungCap == "" || _TenHH == "" || _ThanhTien == "0")
                    MessageBox.Show("Hãy nhập đầy đủ thông tin ");
                else
                {
                    int i = 0;
                    i = Controller.PhieuNhapCtrl.InsertPhieuNhap(_MaPN, _NgayLapPN, _MaNhanVien, _MaNhaCungCap, _ThanhTien);
                    if (i > 0)
                    {
                        MessageBox.Show("Thêm mới thành công !");
                        HienThiDanhSachPhieuNhap();
                        lbThanhTien.Text = "0";
                        lbTongHoaDon.Text = "0";
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại !");
                    }
                }
            }
            uctPhieuNhap_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string _MaPN = "";
            try
            {
                _MaPN = txtMa.Text;
            }
            catch
            { }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controller.PhieuNhapCtrl.DeletePhieuNhap(_MaPN);
                i = Controller.ChiTietPhieuNhapCtrl.DeleteCTPN(_MaPN);
                if (i > 0)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDanhSachPhieuNhap();
                    uctPhieuNhap_Load(sender, e);
                }
                else
                    MessageBox.Show("Xóa thông tin không thành công !");
            }
            else
                return;

        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Controller.ChiTietPhieuNhapCtrl.FillDataSet_FilldatasetCTPNbyIDPN(txtMa.Text);//Note
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
            // khai báo các biến
            string _MaPN = "";
            try
            {
                _MaPN = txtMa.Text;
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
            if (flag == 0)
            {
                //Thêm mới
                if (_MaPN == "" || _TenHH == "" || _SoLuong == "" || _ThanhTien == "")
                    MessageBox.Show("Hãy nhập đầy đủ thông tin ");
                else
                {
                    int i = 0;
                    i = Controller.ChiTietPhieuNhapCtrl.InsertCTPN(_MaPN, _TenHH, _SoLuong, _DonGia, _ThanhTien);
                    _SoLuong = "-" + _SoLuong;
                    if (i > 0) i = Controller.CTHDCtrl.UpdateSoLuong(_TenHH, _SoLuong);
                    if (i > 0)
                    {
                        MessageBox.Show("Thêm mới thành công !");
                        HienThiDanhSachPhieuNhap();
                        float m = float.Parse(lbThanhTien.Text.ToString());
                        float n = float.Parse(lbTongHoaDon.Text.ToString());
                        float s = n + m;
                        lbTongHoaDon.Text = s.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại !");
                    }
                }
                HienThiDanhSachPhieuNhap();
            }
        }

        private void btnLess_Click(object sender, EventArgs e)
        {
            string _MaPN = "";
            try
            {
                _MaPN = txtMa.Text;
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
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn bỏ ra khỏi giỏ hàng ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controller.ChiTietPhieuNhapCtrl.DeleteCTPNTheoCTPN(_MaPN, _TenHH);
                if (i > 0) i = Controller.CTHDCtrl.UpdateSoLuong(_TenHH, _SoLuong);
                if (i > 0)
                {
                    MessageBox.Show("Xóa mặt hàng thành công !");
                    HienThiDanhSachPhieuNhap();
                    float m = float.Parse(lbThanhTien.Text.ToString());
                    float n = float.Parse(lbTongHoaDon.Text.ToString());
                    float s = n - m;
                    lbTongHoaDon.Text = s.ToString();
                }
                else
                    MessageBox.Show("Xóa thông tin không thành công !");
            }
            else
                return;
        }

        private void cbHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            float i = float.Parse(txtDonGia.Text.ToString());
            float j = float.Parse(txtSL.Text.ToString());
            float s = i * j;
            lbThanhTien.Text = s.ToString();
        }

        protected string TenHH { get; set; }

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
    }
}
