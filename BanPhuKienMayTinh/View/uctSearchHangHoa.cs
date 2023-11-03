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
    public partial class uctSearchHangHoa : UserControl
    {
        public uctSearchHangHoa()
        {
            InitializeComponent();
        }
        void loadcontrol()
        {
            cmbFind.Items.Clear();
            cmbFind.Items.Add("Mã Hàng Hóa");
            cmbFind.Items.Add("Tên Hàng Hóa");
            cmbFind.Items.Add("Mã Loại Hàng");
            cmbFind.Items.Add("Tên Loại Hàng");
        }

        //Khai báo biến để phân biệt lúc THÊM và SỬA
        int flag = 0;

        public static uctHangHoa uctHH = new uctHangHoa();

        //Khai báo hàm hiển thị DSHH - để đổ dữ liệu vào dataGridView
        public void HienThiDanhSachNhomLoaiHangHoa()
        {
            //trỏ tới data Hàng Hóa
            dgvHangHoa.DataSource = Model.NhomLoaiHangHoaMod.Filldataset_NhomLoaiHangHoa().Tables[0];
            DoiTenNhomLoai();
            //dgvHangHoa.Dock = DockStyle.Fill;
            //dgvHangHoa.BorderStyle = BorderStyle.Fixed3D;
            //dgvHangHoa.RowHeadersVisible = false;
        }
        void DoiTenNhomLoai()
        {
            dgvHangHoa.Columns[0].HeaderText = "Mã Loại Hàng";
            dgvHangHoa.Columns[1].HeaderText = "Tên Loại Hàng";
            dgvHangHoa.Columns[2].HeaderText = "Mô Tả";
        }
        void bingding()
        {
            //lưu ý cần trỏ đến tham số mà chúng ta khai báo
           
        }

        // Hàm dis-end các button khi load lên
        void dis_end(bool e)
        {
            txtMaHang.Enabled = e;
            txtTenHang.Enabled = e;
            txtMoTa.Enabled = e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }
        //Hàm xóa dữ liệu ở textbox lúc ta nhấn vào button
        void clearData()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtMoTa.Text = "";
            loadcontrol();//Gọi vào để load giới tính
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //load lại 
            uctSearchHangHoa_Load(sender, e);
            dis_end(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // lúc click sửa sẽ mặc định cho flag = 1;
            flag = 1;
            dis_end(true); //lúc này các nút thêm sửa xóa sẽ ẩn đi, chỉ còn nút lưu và hủy
            txtMaHang.Enabled = false;
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
            string _MaNhomLoai = "";
            try
            {
                _MaNhomLoai = txtMaHang.Text;
            }
            catch { }
            string _TenNhomLoai = "";
            try
            {
                _TenNhomLoai = txtTenHang.Text;
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
                if (_MaNhomLoai == "" || _TenNhomLoai == "")
                    MessageBox.Show("Hãy nhập đầy đủ thông tin ");
                else
                {
                    int i = 0;
                    i = Controller.NhomLoaiHangHoaCtrl.InsertNhomLoai(_MaNhomLoai, _TenNhomLoai, _MoTa);
                    if( i > 0)
                    {
                        MessageBox.Show("Thêm mới thành công !");
                        HienThiDanhSachNhomLoaiHangHoa();
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
                i = Controller.NhomLoaiHangHoaCtrl.UpdateNhomLoai(_MaNhomLoai, _TenNhomLoai, _MoTa);
                if (i > 0)
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDanhSachNhomLoaiHangHoa();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại !");
                }
            }
            uctSearchHangHoa_Load(sender, e);
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
                    HienThiDanhSachNhomLoaiHangHoa();
                    uctSearchHangHoa_Load(sender, e);
                }
                else
                    MessageBox.Show("Xóa thông tin thành công !");
            }
            else
                return;
        }

        private void uctSearchHangHoa_Load(object sender, EventArgs e)
        {
            cmbFind.Items.Add("Mã Hàng Hóa");
            loadcontrol();
            dis_end(false);
            bingding();
            if (uctHangHoa.countThemLoaiHangHoa % 2 == 1)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFind.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (cmbFind.Text == "Mã Hàng Hóa" || cmbFind.Text == "Tên Hàng Hóa")
                {
                    if (cmbFind.Text == "Mã Hàng Hóa")
                    {
                        string _MaHH = txtFind.Text;
                        DataTable dt = new DataTable();
                        dt = Controller.HangHoaCtrl.FillDataSet_SearchHangHoaByIDHangHoa(_MaHH).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            dgvHangHoa.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Mã" + txtFind + "Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        string _TenHH = txtFind.Text;
                        DataTable dt = new DataTable();
                        dt = Controller.HangHoaCtrl.FillDataSet_SearchHangHoaByTenHangHoa(_TenHH).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            dgvHangHoa.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Tên" + txtFind + "Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    Doiten();
                }
                else if (cmbFind.Text == "Mã Loại Hàng" || cmbFind.Text == "Tên Loại Hàng")
                {
                    if (cmbFind.Text == "Mã Loại Hàng")
                    {
                        string _MaHH = txtFind.Text;
                        DataTable dt = new DataTable();
                        dt = Controller.NhomLoaiHangHoaCtrl.SearchNhomLoaiHangHoabyIDNhomLoaiHangHoa(_MaHH).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            dgvHangHoa.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Mã" + txtFind + "Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        string _TenHH = txtFind.Text;
                        DataTable dt = new DataTable();
                        dt = Controller.NhomLoaiHangHoaCtrl.SearchNhomLoaiHangHoabyTenNhomLoaiHangHoa(_TenHH).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            dgvHangHoa.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Tên" + txtFind + "Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    DoiTenNhomLoai();
                }
            }
        }
        private void Doiten()
        {
            dgvHangHoa.Columns[0].HeaderText = "Mã Hàng Hóa";
            dgvHangHoa.Columns[1].HeaderText = "Tên Hàng Hóa";
            dgvHangHoa.Columns[2].HeaderText = "Giá Nhập";
            dgvHangHoa.Columns[3].HeaderText = "Giá Bán";
            dgvHangHoa.Columns[4].HeaderText = "DV Tính";
            dgvHangHoa.Columns[5].HeaderText = "Mô Tả";
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (cmbFind.Text == "Mã Hàng Hóa" || cmbFind.Text == "Tên Hàng Hóa")
            {
                if (cmbFind.Text == "Mã Hàng Hóa")
                {
                    string _MaHH = txtFind.Text.ToString();
                    DataTable dt = new DataTable();
                    dt = Controller.HangHoaCtrl.FillDataSet_SearchHangHoaByIDHangHoa(_MaHH).Tables[0];
                    dgvHangHoa.DataSource = dt;
                }
                else
                {
                    string _TenHH = txtFind.Text.ToString();
                    DataTable dt = new DataTable();
                    dt = Controller.HangHoaCtrl.FillDataSet_SearchHangHoaByTenHangHoa(_TenHH).Tables[0];
                    dgvHangHoa.DataSource = dt;
                }
                Doiten();
            }
            else if (cmbFind.Text == "Mã Loại Hàng" || cmbFind.Text == "Tên Loại Hàng")
            {
                if (cmbFind.Text == "Mã Loại Hàng")
                {
                    string _MaNhomLoaiHang = txtFind.Text.ToString();
                    DataTable dt = new DataTable();
                    dt = Controller.NhomLoaiHangHoaCtrl.SearchNhomLoaiHangHoabyIDNhomLoaiHangHoa(_MaNhomLoaiHang).Tables[0];
                    dgvHangHoa.DataSource = dt;
                }
                else
                {
                    string _TenNhomHangHoa = txtFind.Text.ToString();
                    DataTable dt = new DataTable();
                    dt = Controller.NhomLoaiHangHoaCtrl.SearchNhomLoaiHangHoabyTenNhomLoaiHangHoa(_TenNhomHangHoa).Tables[0];
                    dgvHangHoa.DataSource = dt;
                }
                DoiTenNhomLoai();
            }
        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbFind.Text == "Mã Loại Hàng" || cmbFind.Text == "Tên Loại Hàng")
            {
                if (uctHangHoa.countThemLoaiHangHoa % 2 == 1)
                {
                    txtMaHang.DataBindings.Clear();
                    txtMaHang.DataBindings.Add("Text", dgvHangHoa.DataSource, "MaNhomLoai");
                    txtTenHang.DataBindings.Clear();
                    txtTenHang.DataBindings.Add("Text", dgvHangHoa.DataSource, "TenNhomLoai");
                    txtMoTa.DataBindings.Clear();
                    txtMoTa.DataBindings.Add("Text", dgvHangHoa.DataSource, "MoTa");
                }
            }
        }
    }
}
