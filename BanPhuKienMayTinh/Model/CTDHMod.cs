using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanPhuKienMayTinh.Model
{
    class CTDHMod
    {
        protected string MaHD { get; set; }
        protected string TenHH { get; set; }
        protected string SoLuong { get; set; }
        protected string DonGia { get; set; }
        protected string ThanhTien { get; set; }
        protected DateTime ThoiGianBaoHanh { get; set; }
        protected string IMEI { get; set; }
        protected string TinhTrangBaoHanh { get; set; }
        protected string IDKhuyenMai { get; set; }
        public CTDHMod(string _MaHD)
        {
            MaHD = _MaHD;
        }
        public CTDHMod() { } //Hàm này không có đối số

        public CTDHMod(string _MaHD, string _TenHH, string _SoLuong, string _DonGia, string _ThanhTien, DateTime _ThoiGianBaoHanh, string _IMEI, string _TinhTrangBaoHanh, string _IDKhuyenMai)
        {
            MaHD = _MaHD;
            TenHH = _TenHH;
            SoLuong = _SoLuong;
            DonGia = _DonGia;
            ThanhTien = _ThanhTien;
            ThoiGianBaoHanh = _ThoiGianBaoHanh;
            IMEI = _IMEI;
            TinhTrangBaoHanh = _TinhTrangBaoHanh;
            IDKhuyenMai = _IDKhuyenMai;
        }

        public CTDHMod(string _IMEI, string _TinhTrangBaoHanh)
        {
            IMEI = _IMEI;
            TinhTrangBaoHanh = _TinhTrangBaoHanh;
        }

        public int InsertCTHD()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[9] { "@MaHD", "@TenHH", "@SoLuong", "@DonGia", "ThanhTien" , "ThoiGianBaoHanh", "IMEI", "TinhTrangBaoHanh", "@IDKhuyenMai" };
            object[] values = new object[9] { MaHD, TenHH, SoLuong, DonGia, ThanhTien, ThoiGianBaoHanh, IMEI, TinhTrangBaoHanh, IDKhuyenMai };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spInsertCTHD", CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int UpdateSoLuongHang()
        {
            int i = 0;
            string[] paras = new string[2] { "@TenHH", "@SoLuong" };
            object[] values = new object[2] { IMEI, TinhTrangBaoHanh };
            i = Model.ConnectionToSQL.Excute_Sql("spCalculationSoLuong", CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int DeleteCTHD()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[1] { "@MaHD"};
            object[] values = new object[1] { MaHD };//note
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spDeleteCTHD", CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int DeleteCTHDTheoCTHD()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[2] {"@MaHD", "@TenHH" };
            object[] values = new object[2] { IMEI, TinhTrangBaoHanh };//note
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spDeleteCTHDTheoCTHD", CommandType.StoredProcedure, paras, values);
            return i;
        }
        public DataSet Filldataset_getCTHDHangHoa()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaHD" };
            object[] values = new object[1] { MaHD };//note
            ds = Model.ConnectionToSQL.FillDataSet("spgetGiaBanByTenHH", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        public static DataSet getCTHDHangHoa()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetCTHD", CommandType.StoredProcedure);
        }
        public static DataSet getCTHDHangHoa123()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetHangHoainBanHang", CommandType.StoredProcedure);
        }

        public DataSet GetspCTHD()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@TenHH" };
            object[] values = new object[1] { MaHD };
            ds = Model.ConnectionToSQL.FillDataSet("spgetHangHoaByIDHangHoainCTHD", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        public DataSet GetKhuyenMaiCTHD()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@TenHH" };
            object[] values = new object[1] { MaHD };
            ds = Model.ConnectionToSQL.FillDataSet("spgetKhuyenMaiByIDHangHoainCTHD", CommandType.StoredProcedure, paras, values);
            return ds;
        }

    }
}
