using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BanPhuKienMayTinh.Model
{
    class NhaCungCapMod
    {
        //Khai báo các biến và hàm thuộc tính
        public string MaNhaCC { get; set; }
        public string TenNhaCC { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        //Hàm khởi tạo (constructor)
        public NhaCungCapMod(string _MaNhaCC)
        {
            MaNhaCC = _MaNhaCC;
        }

        public NhaCungCapMod(string _MaNhaCC, string _TenNhaCC, string _DiaChi, string _SoDienThoai)
        {
            MaNhaCC = _MaNhaCC;
            TenNhaCC = _TenNhaCC;
            DiaChi = _DiaChi;
            SoDienThoai = _SoDienThoai;
        }

        public NhaCungCapMod() { }

        //Khai báo các hàm thêm - sửa - xóa
        public int InsertNhaCungCap()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[4] { "@MaNhaCungCap", "@TenNhaCungCap", "@DiaChi", "@SoDienThoai"};
            object[] values = new object[4] { MaNhaCC, TenNhaCC, DiaChi, SoDienThoai};
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spInsertNhaCungCap", CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int UpdateNhaCungCap()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[4] { "@MaNhaCungCap", "@TenNhaCungCap", "@DiaChi", "@SoDienThoai" };
            object[] values = new object[4] { MaNhaCC, TenNhaCC, DiaChi, SoDienThoai };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spUpdateNhaCungCap", CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int DeleteNhaCungCap()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[1] { "@MaNhaCungCap" };
            object[] values = new object[1] { MaNhaCC };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spDeleteNhaCungCap", CommandType.StoredProcedure, paras, values);
            return i;
        }

        //Khởi tạo hàm dataset để Load "nhân viên"
        public static DataSet FilldatasetNhaCungCap()
        {
            // Ta gọi thủ tục getNhanVien nãy đã tạo ra
            return Model.ConnectionToSQL.FillDataSet("spgetNhaCungCap", CommandType.StoredProcedure);
        }

        //Get Nhan Vien by IDNHANVIEN
        public DataSet Filldataset_getNhaCungCapbyIDNhaCungCap()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaNhaCungCap" };
            object[] values = new object[1] { MaNhaCC };
            ds = Model.ConnectionToSQL.FillDataSet("spgetNhaCungCapByIDNhaCungCap", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        //Tìm kiếm theo Mã Nhân Viên
        public DataSet Filldataset_SearchNhaCungCapbyIDNhaCungCap()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaNhaCungCap" };
            object[] values = new object[1] { MaNhaCC };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchNhaCungCapByMaNhaCungCap", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        //Tìm kiếm theo tên Nhân viên
        public DataSet Filldataset_SearchNhaCungCapbyTenNhaCungCap()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@TenNhaCungCap" };
            object[] values = new object[1] { MaNhaCC };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchNhaCungCapByTenNhaCungCap", CommandType.StoredProcedure, paras, values);
            return ds;
        }
    }
}
