using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BanPhuKienMayTinh.Model
{
    class NhanVienMod
    {
        //Khai báo các biến và hàm thuộc tính
        protected string MaNhanVien { get; set; }
        protected string HoTen { get; set; }
        protected DateTime NgaysinhNV { get; set; }
        protected string DienThoaiNV { get; set; }
        protected string EmailNV { get; set; }
        protected string GioiTinhNV { get; set; }
        protected string DiaChiNV { get; set; }

        //Hàm Khởi tạo (Hàm contructor)
        public NhanVienMod(string _MaNhanVien)
        {
            MaNhanVien = _MaNhanVien;
        }
        public NhanVienMod() { } //Hàm này không có đối số

        public NhanVienMod(string _MaNhanVien, string _HoTenNhanVien, DateTime _NgaysinhNhanVien, string _GioiTinhNhanVien, string _DienThoaiNhanVien, string _EmailNhanVien, string _DiachiNhanVien)
        {
            MaNhanVien = _MaNhanVien;
            HoTen = _HoTenNhanVien;
            NgaysinhNV = _NgaysinhNhanVien;
            DienThoaiNV = _DienThoaiNhanVien;
            EmailNV = _EmailNhanVien;
            GioiTinhNV = _GioiTinhNhanVien;
            DiaChiNV = _DiachiNhanVien;
        }

        //Khai báo các hàm thêm - sửa - xóa
        public int InsertNhanVien()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[7] { "@MaNhanVien", "@HoTen", "@NgaySinh", "@DienThoai", "@Email", "@GioiTinh", "@DiaChi" };
            object[] values = new object[7] { MaNhanVien, HoTen, NgaysinhNV, DienThoaiNV, EmailNV, GioiTinhNV, DiaChiNV };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spInsertNhanVien", CommandType.StoredProcedure, paras, values);
            return i;
        }


        // Hàm update tương tự
        public int UpdateNhanVien()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[7] { "@MaNhanVien", "@HoTen", "@NgaySinh", "@DienThoai", "@Email", "@GioiTinh", "@DiaChi" };
            object[] values = new object[7] { MaNhanVien, HoTen, NgaysinhNV, DienThoaiNV, EmailNV, GioiTinhNV, DiaChiNV };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spUpdateNhanVien", CommandType.StoredProcedure, paras, values);
            return i;
        }

        //Delete
        public int DeleteNhanVien()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[1] { "@MaNhanVien"};
            object[] values = new object[1] { MaNhanVien};
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spDeleteNhanVien", CommandType.StoredProcedure, paras, values);
            return i;
        }

        //Khởi tạo hàm dataset để Load "nhân viên"
        public static DataSet FilldatasetNhanVien()
        {
            // Ta gọi thủ tục getNhanVien nãy đã tạo ra
            return Model.ConnectionToSQL.FillDataSet("spgetNhanVien",CommandType.StoredProcedure);
        }

        //Get Nhan Vien by IDNHANVIEN
        public DataSet Filldataset_getNhanVienbyIDNhanVien()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaNhanVien" };
            object[] values = new object[1] { MaNhanVien };
            ds = Model.ConnectionToSQL.FillDataSet("spgetNhanVienByIDNhanVien", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        //Tìm kiếm theo Mã Nhân Viên
        public DataSet Filldataset_SearchNhanVienbyIDNhanVien()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaNhanVien" };
            object[] values = new object[1] { MaNhanVien };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchNhanVienByMaNhanVien", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        //Tìm kiếm theo tên Nhân viên
        public DataSet Filldataset_SearchNhanVienbyTenNhanVien()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@TenNhanVien" };
            object[] values = new object[1] { MaNhanVien };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchNhanVienByTenNhanVien", CommandType.StoredProcedure, paras, values);
            return ds;
        }
    }
}
