using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Model
{
    class PhieuNhapMod
    {
        protected string MaPN { get; set; }
        protected DateTime NgayLapPhieuNhap { get; set; }
        protected string MaNhanVien { get; set; }
        protected string MaNhaCungCap { get; set; }
        protected string Tong { get; set; }

        //Hàm khởi tạo (constructor)
        public PhieuNhapMod(string _MaPN)
        {
            MaPN = _MaPN;
        }

        public PhieuNhapMod() { } //Hàm này không có đối số

        public PhieuNhapMod(string _MaPN, DateTime _NgayLapPhieuNhap, string _MaNhanVien, string _MaNhaCungCap, string _Tong)
        {
            MaPN = _MaPN;
            NgayLapPhieuNhap = _NgayLapPhieuNhap;
            MaNhanVien = _MaNhanVien;
            MaNhaCungCap = _MaNhaCungCap;
            Tong = _Tong;
        }

        //Khai báo các hàm thêm - sửa - xóa
        public int InsertPhieuNhap()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[5] { "@MaPN", "@NgayLapPhieuNhap", "@TenNhanVien", "@TenNhaCungCap", "@Tong" };
            object[] values = new object[5] { MaPN, NgayLapPhieuNhap, MaNhanVien, MaNhaCungCap, Tong };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spInsertPhieuNhap", CommandType.StoredProcedure, paras, values);
            return i;
        }

        //Delete
        public int DeletePhieuNhap()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[1] { "@MaPN" };
            object[] values = new object[1] { MaPN };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spDeletePhieuNhap", CommandType.StoredProcedure, paras, values);
            return i;
        }

        //Khởi tạo hàm dataset để Load "Bán Hàng"
        public static DataSet FilldatasetPhieuNhap()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetPhieuNhap", CommandType.StoredProcedure);
        }
        public static DataSet getTenNhaCungCap()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetTenNhaCungCapByPN", CommandType.StoredProcedure);
        }
        public static DataSet getTenNhanVien()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetTenNhanVienByPN", CommandType.StoredProcedure);
        }

        //Get Nhan Vien by IDKhachHang
        public DataSet Filldataset_getPhieuNhapnbyIDMaPhieuNhap()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaPN" };
            object[] values = new object[1] { MaPN };
            ds = Model.ConnectionToSQL.FillDataSet("spgetPhieuNhapByIDPhieuNhap", CommandType.StoredProcedure, paras, values);
            return ds;
        }
    }
}
