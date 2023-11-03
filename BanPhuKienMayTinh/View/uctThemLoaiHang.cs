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
    public partial class uctThemLoaiHang : UserControl
    {
        public uctThemLoaiHang()
        {
            InitializeComponent();
        }

        //Khai báo biến để phân biệt lúc THÊM và SỬA
        int flag = 0;

        // Hàm dis-end các button khi load lên
        void dis_end(bool e)
        {
            txtMaHang.Enabled = e;
            txtTenHang.Enabled = e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        void clearData()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
        }

        private void uctThemLoaiHang_Load(object sender, EventArgs e)
        {
            dis_end(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dis_end(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // lúc click sửa sẽ mặc định cho flag = 1;
            flag = 1;
            dis_end(true); //lúc này các nút thêm sửa xóa sẽ ẩn đi, chỉ còn nút lưu và hủy
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            dis_end(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dis_end(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }


    }
}
