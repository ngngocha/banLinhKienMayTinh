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
    public partial class uctSearchNhaCungCap : UserControl
    {
        public uctSearchNhaCungCap()
        {
            InitializeComponent();
        }

        void loadcontrol()
        {
            cmbFind.Items.Clear();
            cmbFind.Items.Add("Mã Nhà Cung Cấp");
            cmbFind.Items.Add("Tên Nhà Cung Cấp");
        }

        private void uctSearchNhaCungCap_Load(object sender, EventArgs e)
        {
            cmbFind.Items.Add("Mã Nhà Cung Cấp");
            loadcontrol();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void Doiten()
        {
            dgvNhaCungCap.Columns[0].HeaderText = "Mã Nhà Cung Cấp";
            dgvNhaCungCap.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
            dgvNhaCungCap.Columns[2].HeaderText = "Địa Chỉ";
            dgvNhaCungCap.Columns[3].HeaderText = "Điện Thoại";
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (cmbFind.Text == "Mã Nhân Viên")
            {
                string _MaNhaCungCap = txtFind.Text.ToString();
                DataTable dt = new DataTable();
                dt = Controller.NhaCungCapCtrl.FillDataSet_SearchNhaCungCapnByIDNhaCungCap(_MaNhaCungCap).Tables[0];
                dgvNhaCungCap.DataSource = dt;
                Doiten();
            }
            else
            {
                string _TenNhaCungCap = txtFind.Text.ToString();
                DataTable dt = new DataTable();
                dt = Controller.NhaCungCapCtrl.FillDataSet_SearchNhaCungCapnByTenNhaCungCap(_TenNhaCungCap).Tables[0];
                dgvNhaCungCap.DataSource = dt;
                Doiten();
            }
        }
    }
}
