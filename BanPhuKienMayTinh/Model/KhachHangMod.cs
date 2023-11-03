using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BanPhuKienMayTinh.Model
{
    class KhachHangMod
    {
        //Khai báo các biến và hàm thuộc tính
        protected string MaKhachHang { get; set; }
        protected string HoLotKH { get; set; }
        protected DateTime NgaysinhKH { get; set; }
        protected string GioiTinhKH { get; set; }
        protected string DienThoaiKH { get; set; }
        protected string EmailKH { get; set; }
        protected string DiaChiKH { get; set; }
        //Hàm Khởi tạo (Hàm contructor)
        public KhachHangMod(string _MaKhachHang)
        {
            MaKhachHang = _MaKhachHang;
        }
        public KhachHangMod() { } //Hàm này không có đối số

        public KhachHangMod(string _MaKhachHang, string _HoLotKhachHang, DateTime _NgaysinhKhachHang, string _GioiTinhKhachHang, string _DienThoaiKhachHang, string _EmailKhachHang, string _DiachiKhachHang)
        {
            MaKhachHang = _MaKhachHang;
            HoLotKH = _HoLotKhachHang;
            NgaysinhKH = _NgaysinhKhachHang;
            GioiTinhKH = _GioiTinhKhachHang;
            DienThoaiKH = _DienThoaiKhachHang;
            EmailKH = _EmailKhachHang;
            DiaChiKH = _DiachiKhachHang;
        }

        //Khai báo các hàm thêm - sửa - xóa
        public int InsertKhachHang()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[7] { "@MaKhachHang", "@TenKhachHang", "@NgaySinh", "@DienThoai", "@Email", "@GioiTinh", "@DiaChi" };
            object[] values = new object[7] { MaKhachHang, HoLotKH, NgaysinhKH, DienThoaiKH, EmailKH, GioiTinhKH, DiaChiKH };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spInsertKhachHang", CommandType.StoredProcedure, paras, values);
            return i;
        }


        // Hàm update tương tự
        public int UpdateKhachHang()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[7] { "@MaKhachHang", "@TenKhachHang", "@NgaySinh", "@DienThoai", "@Email", "@GioiTinh", "@DiaChi" };
            object[] values = new object[7] { MaKhachHang, HoLotKH, NgaysinhKH, DienThoaiKH, EmailKH, GioiTinhKH, DiaChiKH };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spUpdateKhachHang", CommandType.StoredProcedure, paras, values);
            return i;
        }

        //Delete
        public int DeleteKhachHang()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[1] { "@MaKhachHang" };
            object[] values = new object[1] { MaKhachHang };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spDeleteKhachHang", CommandType.StoredProcedure, paras, values);
            return i;
        }

        //Khởi tạo hàm dataset để Load "Khách Hàng"
        public static DataSet FilldatasetKhachHang()
        {
            // Ta gọi thủ tục getKhachHang nãy đã tạo ra
            return Model.ConnectionToSQL.FillDataSet("spgetKhachHang", CommandType.StoredProcedure);
        }

        //Get Nhan Vien by IDKhachHang
        public DataSet Filldataset_getKhachHangbyIDKhachHang()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaKhachHang" };
            object[] values = new object[1] { MaKhachHang };
            ds = Model.ConnectionToSQL.FillDataSet("spgetKhachHangByIDKhachHang", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        //Tìm kiếm theo Mã Khách Hàng
        public DataSet Filldataset_SearchKhachHangbyIDKhachHang()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaKhachHang" };
            object[] values = new object[1] { MaKhachHang };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchKhachHangByMaKhachHang", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        //Tìm kiếm theo tên Khách Hàng
        public DataSet Filldataset_SearchKhachHangbyTenKhachHang()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@TenKhachHang" };
            object[] values = new object[1] { MaKhachHang };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchKhachHangByTenKhachHang", CommandType.StoredProcedure, paras, values);
            return ds;
        }
    }
}
