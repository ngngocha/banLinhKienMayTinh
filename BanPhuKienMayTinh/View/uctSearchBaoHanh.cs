using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanPhuKienMayTinh.Resources
{
    public partial class uctSearchBaoHanh : UserControl
    {
        public uctSearchBaoHanh()
        {
            InitializeComponent();
        }
        
        private void uctSearchBaoHanh_Load(object sender, EventArgs e)
        {
            loadcontrol();
            txtIMEI.Enabled = false;
            dis_end(false);
        }

        void loadcontrol()
        {
            cmbFind.Items.Clear();
            cmbFind.Items.Add("Mã Nhóm Loại");
            cmbFind.Items.Add("IMEI");
            cmbFind.Items.Add("Tình trạng bảo hành");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFind.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (cmbFind.Text == "IMEI")
                {
                    string _IMEI = txtFind.Text;
                    DataTable dt = new DataTable();
                    dt = Controller.BaoHanhCtrl.Filldataset_SearchBaoHanhTheoIMEI(_IMEI).Tables[0];
                    bingding();
                    if (dt.Rows.Count > 0)
                    {
                        dgvBaoHanh.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("IMEI" + txtFind + "Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Doiten();
                }
                if (cmbFind.Text == "Tình trạng bảo hành")
                {
                    string _TinhTrangBaoHanh = txtFind.Text;
                    DataTable dt = new DataTable();
                    dt = Controller.BaoHanhCtrl.Filldataset_SearchBaoHanh(_TinhTrangBaoHanh).Tables[0];
                    bingding();
                    if (dt.Rows.Count > 0)
                    {
                        dgvBaoHanh.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Tình Trạng Bảo Hành" + txtFind + "Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Doiten();
                }
                if (cmbFind.Text == "Mã Nhóm Loại")
                {
                    string _MaNhomLoai = txtFind.Text;
                    DataTable dt = new DataTable();
                    dt = Controller.BaoHanhCtrl.Filldataset_SearchBaoHanhTheoMaNhomLoai(_MaNhomLoai).Tables[0];
                    bingding();
                    if (dt.Rows.Count > 0)
                    {
                        dgvBaoHanh.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Mã Nhóm Loại" + txtFind + "Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Doiten1();
                }
            }
        }
        private void Doiten()
        {
            dgvBaoHanh.Columns[0].HeaderText = "IMEI";
            dgvBaoHanh.Columns[1].HeaderText = "Tình Trạng Bảo Hành";
            dgvBaoHanh.Columns[2].HeaderText = "Thời Gian Bảo Hành";
        }
        private void Doiten1()
        {
            dgvBaoHanh.Columns[0].HeaderText = "Mã Nhóm Loại";
            dgvBaoHanh.Columns[1].HeaderText = "Thời Gian Bảo Hành";
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (cmbFind.Text == "IMEI")
            {
                string _IMEI = txtFind.Text.ToString();
                DataTable dt = new DataTable();
                dt = Controller.BaoHanhCtrl.Filldataset_SearchBaoHanhTheoIMEI(_IMEI).Tables[0];
                dgvBaoHanh.DataSource = dt;
                Doiten();
                bingding();
            }
            if (cmbFind.Text == "Tình trạng bảo hành")
            {
                string _TinhTrangBaoHanh = txtFind.Text.ToString();
                DataTable dt = new DataTable();
                dt = Controller.BaoHanhCtrl.Filldataset_SearchBaoHanh(_TinhTrangBaoHanh).Tables[0];
                dgvBaoHanh.DataSource = dt;
                Doiten();
                bingding();
            }
            if (cmbFind.Text == "Mã Nhóm Loại")
            {
                string _MaNhomLoai = txtFind.Text;
                DataTable dt = new DataTable();
                dt = Controller.BaoHanhCtrl.Filldataset_SearchBaoHanhTheoMaNhomLoai(_MaNhomLoai).Tables[0];
                bingding();
                if (dt.Rows.Count > 0)
                {
                    dgvBaoHanh.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Mã Nhóm Loại" + txtFind + "Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Doiten1();
            }
        }
        void dis_end(bool e)
        {
            txtTinhTrangBaoHanh.Enabled = e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnSua.Enabled = !e;
        }
        void bingding()
        {
            //lưu ý cần trỏ đến tham số mà chúng ta khai báo
            txtIMEI.DataBindings.Clear();
            txtIMEI.DataBindings.Add("Text", dgvBaoHanh.DataSource, "IMEI");
            txtTinhTrangBaoHanh.DataBindings.Clear();
            txtTinhTrangBaoHanh.DataBindings.Add("Text", dgvBaoHanh.DataSource, "TinhTrangBaoHanh");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //load lại 
            uctSearchBaoHanh_Load(sender, e);
            dis_end(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dis_end(true); //lúc này các nút thêm sửa xóa sẽ ẩn đi, chỉ còn nút lưu và hủy
            loadcontrol();
            txtIMEI.Enabled = false;
            bingding();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // khai báo các biến
            string _IMEI = "";
            try
            {
                _IMEI = txtIMEI.Text;
            }
            catch { }
            string _TinhTrangBaoHanh = "";
            try
            {
                _TinhTrangBaoHanh = txtTinhTrangBaoHanh.Text;
            }
            catch { }
            //sửa
            int i = 0;
            i = Controller.BaoHanhCtrl.UpdateTinhTrangBaoHanh(_IMEI, _TinhTrangBaoHanh);
            if (i > 0)
            {
                MessageBox.Show("Sửa thành công !");
            }
            else
            {
                MessageBox.Show("Sửa thất bại !");
            }
            uctSearchBaoHanh_Load(sender, e);
        }
    }
}
