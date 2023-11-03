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
    public partial class uctSearchKhachHang : UserControl
    {
        public uctSearchKhachHang()
        {
            InitializeComponent();
        }
        void loadcontrol()
        {
            cmbFind.Items.Clear();
            cmbFind.Items.Add("Mã Khách Hàng");
            cmbFind.Items.Add("Tên Khách Hàng");
        }
        private void uctSearchKhahcHang_Load(object sender, EventArgs e)
        {
            cmbFind.Items.Add("Mã Khách Hàng");
            loadcontrol();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFind.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
            {
                if (cmbFind.Text == "Mã Khách Hàng")
                {
                    string _MaKhachHang = txtFind.Text;
                    DataTable dt = new DataTable();
                    dt = Controller.KhachHangCtrl.FillDataSet_SearchKhachHangByIDKhachHang(_MaKhachHang).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        dgvKhachHang.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Mã" + txtFind + "Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    string _Ten = txtFind.Text;
                    DataTable dt = new DataTable();
                    dt = Controller.KhachHangCtrl.FillDataSet_SearchKhachHangByTenKhachHang(_Ten).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        dgvKhachHang.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Tên" + txtFind + "Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            Doiten();
        }
        private void Doiten()
        {
            dgvKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns[2].HeaderText = "Ngày Sinh";
            dgvKhachHang.Columns[3].HeaderText = "Điện Thoại";
            dgvKhachHang.Columns[4].HeaderText = "Email";
            dgvKhachHang.Columns[5].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns[6].HeaderText = "Giới Tính";
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (cmbFind.Text == "Mã Khách Hàng")
            {
                string _MaKhachHang = txtFind.Text.ToString();
                DataTable dt = new DataTable();
                dt = Controller.KhachHangCtrl.FillDataSet_SearchKhachHangByIDKhachHang(_MaKhachHang).Tables[0];
                dgvKhachHang.DataSource = dt;
                Doiten();
            }
            else
            {
                string _Ten = txtFind.Text.ToString();
                DataTable dt = new DataTable();
                dt = Controller.KhachHangCtrl.FillDataSet_SearchKhachHangByTenKhachHang(_Ten).Tables[0];
                dgvKhachHang.DataSource = dt;
                Doiten();
            }
        }
    }
}
