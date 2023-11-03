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
    public partial class uctSearchNhanVien : UserControl
    {
        public uctSearchNhanVien()
        {
            InitializeComponent();
        }
        void loadcontrol()
        {
            cmbFind.Items.Clear();
            cmbFind.Items.Add("Mã Nhân Viên");
            cmbFind.Items.Add("Tên Nhân Viên");
        }
        private void uctSearchNhanVien_Load(object sender, EventArgs e)
        {
            cmbFind.Items.Add("Mã Nhân Viên");
            loadcontrol();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(txtFind.Text =="")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tìm kiếm", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Stop);

            }
            else
            {
                if(cmbFind.Text=="Mã Nhân Viên")
                {
                    string _MaNhanVien = txtFind.Text;
                    DataTable dt = new DataTable();
                    dt = Controller.NhanVienCtrl.FillDataSet_SearchNhanVienByIDNhanVien(_MaNhanVien).Tables[0];
                    if(dt.Rows.Count>0)
                    {
                        dgvNhanVien.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Mã" + txtFind + "Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    string _HoTenNhanVien = txtFind.Text;
                    DataTable dt = new DataTable();
                    dt = Controller.NhanVienCtrl.FillDataSet_SearchNhanVienByTenNhanVien(_HoTenNhanVien).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        dgvNhanVien.DataSource = dt;
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
            dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvNhanVien.Columns[1].HeaderText = "Họ và tên";
            dgvNhanVien.Columns[2].HeaderText = "Ngày Sinh";
            dgvNhanVien.Columns[3].HeaderText = "Điện Thoại";
            dgvNhanVien.Columns[4].HeaderText = "Email";
            dgvNhanVien.Columns[5].HeaderText = "Địa Chỉ";
            dgvNhanVien.Columns[6].HeaderText = "Giới Tính";
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (cmbFind.Text == "Mã Nhân Viên")
            {
                string _MaNhanVien = txtFind.Text.ToString();
                DataTable dt = new DataTable();
                dt = Controller.NhanVienCtrl.FillDataSet_SearchNhanVienByIDNhanVien(_MaNhanVien).Tables[0];
                dgvNhanVien.DataSource = dt;
                Doiten();
            }
            else
            {
                string _HoTenNhanVien = txtFind.Text.ToString();
                DataTable dt = new DataTable();
                dt = Controller.NhanVienCtrl.FillDataSet_SearchNhanVienByTenNhanVien(_HoTenNhanVien).Tables[0];
                dgvNhanVien.DataSource = dt;
                Doiten();
            }
        }
    }
}
