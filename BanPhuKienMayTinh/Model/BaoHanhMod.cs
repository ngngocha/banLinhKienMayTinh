using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanPhuKienMayTinh.Model
{
    class BaoHanhMod
    {
        //Khai báo các biến và thuộc tính
        protected string MaNhomLoai { get; set; }
        protected string ThoiGianBaoHanh { get; set; }
        protected string IMEI { get; set; }
        protected string TinhTrangBaoHanh { get; set; }

        //Hàm khởi tạo (constructor)
        public BaoHanhMod() { }

        public BaoHanhMod(string _MaNhomLoai)
        {
            MaNhomLoai = _MaNhomLoai;
        }

        public BaoHanhMod(string _MaNhomLoai, string _ThoiGianBaoHanh)
        {
            MaNhomLoai = _MaNhomLoai;
            ThoiGianBaoHanh = _ThoiGianBaoHanh;
        }

        public int InsertBaoHanh()
        {
            int i = 0;
            string[] paras = new string[2] { "@MaNhomLoai", "@ThoiGianBaoHanh"};
            object[] values = new object[2] { MaNhomLoai, ThoiGianBaoHanh};
            i = Model.ConnectionToSQL.Excute_Sql("spInsertBaoHanh", CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int UpdateTinhTrangBaoHanh()
        {
            int i = 0;
            string[] paras = new string[2] { "@IMEI", "@TinhTrangBaoHanh" };
            object[] values = new object[2] { MaNhomLoai, ThoiGianBaoHanh };
            i = Model.ConnectionToSQL.Excute_Sql("spUpdateTinhTrangBaoHanh", CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int UpdateBaoHanh()
        {
            int i = 0;
            string[] paras = new string[2] { "@MaNhomLoai", "@ThoiGianBaoHanh"};
            object[] values = new object[2] { MaNhomLoai, ThoiGianBaoHanh};
            i = Model.ConnectionToSQL.Excute_Sql("spUpdateBaoHanh", CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int DeleteBaoHanh()
        {
            int i = 0;
            string[] paras = new string[1] { "@MaNhomLoai" };
            object[] values = new object[1] { MaNhomLoai };
            i = Model.ConnectionToSQL.Excute_Sql("spDeleteBaoHanh", CommandType.StoredProcedure, paras, values);
            return i;
        }

        public DataSet SearchBaoHanh()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@TinhTrangBaoHanh" };
            object[] values = new object[1] { MaNhomLoai };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchBaoHanh", CommandType.StoredProcedure, paras, values);
            return ds;
        }

        public DataSet SearchBaoHanhTheoIMEI()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@IMEI" };
            object[] values = new object[1] { MaNhomLoai };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchBaoHanhTheoIMEI", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        public DataSet SearchBaoHanhTheoMaNhomLoai()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaNhomLoai" };
            object[] values = new object[1] { MaNhomLoai };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchBaoHanhTheoMaNhomLoai", CommandType.StoredProcedure, paras, values);
            return ds;
        }

        public static DataSet FillDataset_getBaoHanh()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetBaoHanh");
        }

        public static DataSet GetMaNhomLoaiHangHoa()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetMaNhomLoaiHangHoa", CommandType.StoredProcedure);
        }
    }
}
