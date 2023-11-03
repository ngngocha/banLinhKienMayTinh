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

namespace BanPhuKienMayTinh.Formm
{
    public partial class DangNhap : Form
    {
        public static int QuyenTaiKhoan = 0;

        public DangNhap()
        {
            InitializeComponent();
        }


        public static string sqlcon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanPhuKienMayTinh;Integrated Security=True";
        public static SqlConnection Getconnection()
        {
            SqlConnection con = new SqlConnection(sqlcon);
            return con;
        }

        private void btnQuenmatkhau_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Call: 0354905379", "Contact me");
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            /*if (txtUserName.Text == "admin" && txtPassword.Text == "123")
            {
                QuyenTaiKhoan = 1;
                MessageBox.Show("Bạn đã đăng nhập thành công !");
                ManHinhChinh f2 = new ManHinhChinh();
                this.Hide();
                f2.ShowDialog();
                this.Show();
                txtPassword.Clear();
            }
            else
            {
                //MessageBox.Show("Sai mật khẩu !", "Lỗi !");
                QuyenTaiKhoan = 0;
                ManHinhChinh f2 = new ManHinhChinh();
                this.Hide();
                f2.ShowDialog();
                this.Show();
                txtPassword.Clear();
            }*/
            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                DataSet ds = new DataSet();
                ds = Controller.QuanLyTaiKhoanCtrl.CheckTaiKhoan(txtUserName.Text, txtPassword.Text);
                dgvTaiKhoancheck.DataSource = Controller.QuanLyTaiKhoanCtrl.CheckTaiKhoan(txtUserName.Text, txtPassword.Text).Tables[0];
                txtCheck.DataBindings.Clear();
                txtCheck.DataBindings.Add("Text", dgvTaiKhoancheck.DataSource, "IDTK");
                if (txtCheck.Text == "" )
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu !", "Lỗi !");
                }
                else
                {
                    dgvTaiKhoancheck.DataSource = Controller.QuanLyTaiKhoanCtrl.CheckQuyenTaiKhoan(txtUserName.Text).Tables[0];
                    txtCheck.DataBindings.Clear();
                    txtCheck.DataBindings.Add("Text", dgvTaiKhoancheck.DataSource, "LoaiTK");
                    if (txtCheck.Text == "Quản Lý")
                        QuyenTaiKhoan += 1;
                    MessageBox.Show("Bạn đã đăng nhập thành công !");
                    ManHinhChinh f2 = new ManHinhChinh();
                    this.Hide();
                    f2.ShowDialog();
                    this.Show();
                    txtPassword.Clear();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo)
                == DialogResult.Yes) Close();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
