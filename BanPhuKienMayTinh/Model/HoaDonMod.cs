using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Model
{
    class HoaDonMod
    {
        protected string MaHD { get; set; }
        protected DateTime NgayLap { get; set; }
        protected string TenNhanVien { get; set; }
        protected string TenKhachHang { get; set; }
        protected string Tong { get; set; }
        public HoaDonMod(string _MaHD)
        {
            MaHD = _MaHD;
        }
        public HoaDonMod() { } //Hàm này không có đối số

        public HoaDonMod(string _MaHD, DateTime _NgayLap, string _TenNhanVien, string _TenKhachHang, string _Tong)
        {
            MaHD = _MaHD;
            NgayLap = _NgayLap;
            TenNhanVien = _TenNhanVien;
            TenKhachHang = _TenKhachHang;
            Tong = _Tong;
        }

        //Khai báo các hàm thêm - sửa - xóa
        public int InsertHoaDon()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[5] { "@MaHD", "@NgayLap", "@TenNhanVien", "@TenKhachHang", "@Tong" };
            object[] values = new object[5] { MaHD, NgayLap, TenNhanVien, TenKhachHang, Tong };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spInsertBanHang", CommandType.StoredProcedure, paras, values);
            return i;
        }

        //Delete
        public int DeleteHoaDon()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[1] { "@MaHD" };
            object[] values = new object[1] { MaHD };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spDeleteBanHang", CommandType.StoredProcedure, paras, values);
            return i;
        }
        //Khởi tạo hàm dataset để Load "Bán Hàng"
        public static DataSet FilldatasetHoaDon()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetBanHang", CommandType.StoredProcedure);
        }
        public static DataSet getTenKhachHang()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetTenKhachHangByHoaDonBan", CommandType.StoredProcedure);
        }
        public static DataSet getTenNhanVien()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetTenNhanVienByHoaDonBan", CommandType.StoredProcedure);
        }
        //Get Nhan Vien by IDKhachHang
        public DataSet Filldataset_getHoaDonbyIDMaHD()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaHD" };
            object[] values = new object[1] { MaHD };
            ds = Model.ConnectionToSQL.FillDataSet("spgetHoaDonByIDHoaDon", CommandType.StoredProcedure, paras, values);
            return ds;
        }
    }
}
