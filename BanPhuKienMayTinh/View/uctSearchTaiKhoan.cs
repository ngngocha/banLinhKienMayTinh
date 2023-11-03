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
    public partial class uctSearchTaiKhoan : UserControl
    {
        public uctSearchTaiKhoan()
        {
            InitializeComponent();
        }

        public static uctSearchTaiKhoan uctQLTK = new uctSearchTaiKhoan();
        private void uctSearchTaiKhoan_Load(object sender, EventArgs e)
        {
            cmbFind.Items.Add("IDTK");
            loadcontrol();
        }
        void loadcontrol()
        {
            cmbFind.Items.Clear();
            cmbFind.Items.Add("IDTK");
            cmbFind.Items.Add("Loại TK");
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFind.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (cmbFind.Text == "IDTK")
                {
                    string _IDTK = txtFind.Text;
                    DataTable dt = new DataTable();
                    dt = Controller.QuanLyTaiKhoanCtrl.SearchTaiKhoan(_IDTK).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        dgvTaiKhoan.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("ID" + txtFind + "Không có trong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    string _LoaiTK = txtFind.Text;
                    DataTable dt = new DataTable();
                    dt = Controller.QuanLyTaiKhoanCtrl.SearchTaiKhoanbyLoaiTK(_LoaiTK).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        dgvTaiKhoan.DataSource = dt;
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
            dgvTaiKhoan.Columns[0].HeaderText = "IDTK";
            dgvTaiKhoan.Columns[1].HeaderText = "Loại Tài Khoản";
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (cmbFind.Text == "IDTK")
            {
                string _IDTK = txtFind.Text.ToString();
                DataTable dt = new DataTable();
                dt = Controller.QuanLyTaiKhoanCtrl.SearchTaiKhoan(_IDTK).Tables[0];
                dgvTaiKhoan.DataSource = dt;
                Doiten();
            }
            else
            {
                string _LoaiTK = txtFind.Text.ToString();
                DataTable dt = new DataTable();
                dt = Controller.QuanLyTaiKhoanCtrl.SearchTaiKhoanbyLoaiTK(_LoaiTK).Tables[0];
                dgvTaiKhoan.DataSource = dt;
                Doiten();
            }
        }
    }
}
