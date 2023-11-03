using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanPhuKienMayTinh.Formm
{
    public partial class ManHinhChinh : Form
    {
        static int count = 0;
        public ManHinhChinh()
        {
            InitializeComponent();
        }

        internal static List<byte> typePages = new List<byte>();
        public void ThemtabPages(UserControl uct, byte typeControl, string tenTab)
        {
            //Kiếm tra xem tồn tại trang này chưa
            for (int i = 0; i < TabHienThi.TabPages.Count; i++)
            {
                if (TabHienThi.TabPages[i].Contains(uct) == true)
                {
                    TabHienThi.SelectedTab = TabHienThi.TabPages[i];
                    return;
                }
            }
            TabPage tab = new TabPage();
            typePages.Add(typeControl);
            tab.Name = uct.Name;
            tab.Size = TabHienThi.Size;
            tab.Text = tenTab;
            TabHienThi.TabPages.Add(tab);
            TabHienThi.SelectedTab = tab;
            uct.Dock = DockStyle.Fill;
            tab.Controls.Add(uct);
            uct.Focus();
        }
        // Đóng tab hiện tại
        public void DongtabHienTai()
        {
            count--;
            TabHienThi.TabPages.Remove(TabHienThi.SelectedTab);
            if (count == 0)
                TabHienThi.Visible = false;
        }

        //Đóng all tab
        public void DongAllTab()
        {
            while (TabHienThi.TabPages.Count > 0)
            {
                DongtabHienTai();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap.QuyenTaiKhoan = 0;
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo)
                == DialogResult.Yes) Close();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabHienThi.Visible = true;
            ThemtabPages(View.uctNhanVien.uctNV, 4, "Quản Lý Nhân Viên");
            count++;
        }

        private void đóngTrangHiệnTạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DongtabHienTai();
        }

        private void đóngTấtCảTrangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabHienThi.Visible = false;
            DongAllTab();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabHienThi.Visible = true;
            ThemtabPages(View.uctKhachHang.uctKH, 4, "Quản Lý Khách Hàng");
            count++;
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabHienThi.Visible = true;
            ThemtabPages(View.uctHoaDon.uctHD, 4, "Quản Lý Hóa Đơn");
            count++;
        }

        private void TabHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabHienThi.Visible = true;
            ThemtabPages(View.uctPhieuNhap.uctPN, 4, "Quản Lý Phiếu Nhập");
            count++;
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabHienThi.Visible = true;
            ThemtabPages(View.uctQuanLyTaiKhoan.uctQLTK, 4, "Quản Lý Tài Khoản");
            count++;
        }

        private void hàngHóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabHienThi.Visible = true;
            ThemtabPages(View.uctHangHoa.uctHH, 4, "Quản Lý Hàng Hóa");
            count++;
        }

        private void bảoHànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabHienThi.Visible = true;
            ThemtabPages(View.uctBaoHanh.uctBH, 4, "Bảo Hành");
            count++;
        }

        private void quToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabHienThi.Visible = true;
            ThemtabPages(View.uctQuanLyTaiKhoan.uctQLTK, 4, "Quản Lý Tài Khoản");
            count++;
        }

        private void phiếuNhậpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TabHienThi.Visible = true;
            ThemtabPages(View.uctPhieuNhap.uctPN, 4, "Quản Lý Phiếu Nhập");
            count++;
        }

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {
            //DangNhap.QuyenTaiKhoan = 1;
            if(DangNhap.QuyenTaiKhoan == 0)
            {
                quToolStripMenuItem.Enabled = false;
                nhânViênToolStripMenuItem.Enabled = false;
                nhàCungCấpToolStripMenuItem.Enabled = false;
            }
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabHienThi.Visible = true;
            ThemtabPages(View.uctNhaCungCap.uctNCC, 4, "Quản Lý Nhà Cung Cấp");
            count++;
        }
    }
}
