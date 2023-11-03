using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanPhuKienMayTinh.Model
{
    class HangHoaMod
    {
        //Khai báo các biến và hàm thuộc tính
        protected string MaHangHoa { get; set; }
        protected string TenHH { get; set; }
        protected string MaNhomLoai { get; set; }
        protected string GiaBan { get; set; }
        protected string DVTinh { get; set; }
        protected string MoTa { get; set; }
        public HangHoaMod(string _MaHangHoa)
        {
            MaHangHoa = _MaHangHoa;
        }
        public HangHoaMod() { } //Hàm này HHông có đối số

        public HangHoaMod(string _MaHangHoa, string _TenHH, string _MaNhomLoai, string _GiaBan, string _DVTinh, string _MoTa)
        {
            MaHangHoa = _MaHangHoa;
            TenHH = _TenHH;
            MaNhomLoai = _MaNhomLoai;
            GiaBan = _GiaBan;
            DVTinh = _DVTinh;
            MoTa = _MoTa;
        }

        //HHai báo các hàm thêm - sửa - xóa
        public int InsertHangHoa()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta HHai báo trong SQL
            string[] paras = new string[6] { "@MaHangHoa", "@TenHH", "@MaNhomLoai", "@GiaBan", "@DVTinh", "@MoTa"};
            object[] values = new object[6] { MaHangHoa, TenHH, MaNhomLoai, GiaBan, DVTinh, MoTa};
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spInsertHangHoa", CommandType.StoredProcedure, paras, values);
            return i;
        }


        // Hàm update tương tự
        public int UpdateHangHoa()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta HHai báo trong SQL
            string[] paras = new string[6] { "@MaHangHoa", "@TenHH", "@MaNhomLoai", "@GiaBan", "@DVTinh", "@MoTa" };
            object[] values = new object[6] { MaHangHoa, TenHH, MaNhomLoai, GiaBan, DVTinh, MoTa };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spUpdateHangHoa", CommandType.StoredProcedure, paras, values);
            return i;
        }

        //Delete
        public int DeleteHangHoa()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta HHai báo trong SQL
            string[] paras = new string[1] { "@MaHangHoa" };
            object[] values = new object[1] { MaHangHoa };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spDeleteHangHoa", CommandType.StoredProcedure, paras, values);
            return i;
        }

        //HHởi tạo hàm dataset để Load "HHách Hàng"
        public static DataSet FilldatasetHangHoa()
        {
            // Ta gọi thủ tục getHangHoa nãy đã tạo ra
            return Model.ConnectionToSQL.FillDataSet("spgetHangHoa", CommandType.StoredProcedure);
        }

        //Get Nhan Vien by IDHangHoa
        public DataSet Filldataset_getHangHoabyIDHangHoa()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaHangHoa" };
            object[] values = new object[1] { MaHangHoa };
            ds = Model.ConnectionToSQL.FillDataSet("spgetHangHoaByIDHangHoa", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        //Tìm kiếm theo Mã HHách Hàng
        public DataSet Filldataset_SearchHangHoabyIDHangHoa()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaHangHoa" };
            object[] values = new object[1] { MaHangHoa };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchHangHoaByMaHangHoa", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        //Tìm kiếm theo tên HHách Hàng
        public DataSet Filldataset_SearchHangHoabyTenHangHoa()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@TenHH" };
            object[] values = new object[1] { MaHangHoa };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchHangHoaByTenHangHoa", CommandType.StoredProcedure, paras, values);
            return ds;
        }

        public static DataSet dataSet_getMaNhomLoai()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetMaNhomLoaiHangHoa", CommandType.StoredProcedure);
        }
    }
}
