using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanPhuKienMayTinh.Model
{
    class NhomLoaiHangHoaMod
    {
        protected string MaNhomLoai { get; set; }
        protected string TenNhomLoai { get; set; }
        protected string MoTa { get; set; }
        public NhomLoaiHangHoaMod() { }
        public NhomLoaiHangHoaMod(string _MaNhomLoai, string _TenNhomLoai, string _MoTa)
        {
            MaNhomLoai = _MaNhomLoai;
            TenNhomLoai = _TenNhomLoai;
            MoTa = _MoTa;
        }
        public NhomLoaiHangHoaMod(string _MaNhomLoai)
        {
            MaNhomLoai = _MaNhomLoai;
        }
        public int InsertNhomLoai()
        {
            int i = 0;
            string[] paras = new string[3] { "@MaNhomLoai", "@TenNhomLoai", "@MoTa" };
            object[] values = new object[3] { MaNhomLoai, TenNhomLoai, MoTa };
            i = Model.ConnectionToSQL.Excute_Sql("spInsertNhomLoaiHangHoa", CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int UpdateNhomLoai()
        {
            int i = 0;
            string[] paras = new string[3] { "@MaNhomLoai", "@TenNhomLoai", "@MoTa" };
            object[] values = new object[3] { MaNhomLoai, TenNhomLoai, MoTa };
            i = Model.ConnectionToSQL.Excute_Sql("spUpdateLoaiHangHoa", CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int DeleteNhomLoai()
        {
            int i = 0;
            string[] paras = new string[1] { "@MaNhomLoai" };
            object[] values = new object[1] { MaNhomLoai };
            i = Model.ConnectionToSQL.Excute_Sql("spDeleteNhomLoaiHangHoa", CommandType.StoredProcedure, paras, values);
            return i;
        }
        public static DataSet Filldataset_NhomLoaiHangHoa()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetNhomLoaiHangHoa", CommandType.StoredProcedure);
        }
        public DataSet SearchNhomLoaiHangHoabyIDNhomLoaiHangHoa()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaNhomLoai" };
            object[] values = new object[1] { MaNhomLoai };
            ds = Model.ConnectionToSQL.FillDataSet("spgetNhomLoaiHangHoaByIDNhomLoaiHangHoa", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        public DataSet SearchNhomLoaiHangHoabyTenNhomLoaiHangHoa()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@TenNhomLoai" };
            object[] values = new object[1] { MaNhomLoai };
            ds = Model.ConnectionToSQL.FillDataSet("spgetNhomLoaiHangHoaByTenNhomLoaiHangHoa", CommandType.StoredProcedure, paras, values);
            return ds;
        }
    }
}
