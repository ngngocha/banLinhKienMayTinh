using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanPhuKienMayTinh.Model
{
    class ChiTietPhieuNhapMod
    {
        protected string MaPN { get; set; }
        protected string MaHH { get; set; }
        protected string SoLuong { get; set; }
        protected string DonGia { get; set; }
        protected string ThanhTien { get; set; }
        public ChiTietPhieuNhapMod(string _MaPN, string _MaHH)
        {
            MaPN = _MaPN;
            MaHH = _MaHH;
        }
        public ChiTietPhieuNhapMod(string _MaPN)
        {
            MaPN = _MaPN;
        }

        public ChiTietPhieuNhapMod() { } //Hàm này không có đối số

        public ChiTietPhieuNhapMod(string _MaPN, string _MaHH, string _SoLuong, string _DonGia, string _ThanhTien)
        {
            MaPN = _MaPN;
            MaHH = _MaHH;
            SoLuong = _SoLuong;
            DonGia = _DonGia;
            ThanhTien = _ThanhTien;
        }

        public int InsertChiTietPhieuNhap()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[5] { "@MaPN", "@TenHH", "@SoLuong", "@DonGia", "ThanhTien" };
            object[] values = new object[5] { MaPN, MaHH, SoLuong, DonGia, ThanhTien };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spInsertCTPN", CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int DeleteCTPN()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[1] { "@MaPN" };
            object[] values = new object[1] { MaPN };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spDeleteCTPN", CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int DeleteCTPNTheoCTPN()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta khai báo trong SQL
            string[] paras = new string[2] { "@MaPN", "@TenHH" };
            object[] values = new object[2] { MaPN, MaHH };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spDeleteCTPNTheoCTPN", CommandType.StoredProcedure, paras, values);
            return i;
        }

        public DataSet Filldataset_getCTPNHangHoa()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@MaPN" };
            object[] values = new object[1] { MaPN };
            ds = Model.ConnectionToSQL.FillDataSet("spgetGiaNhapByTenHH", CommandType.StoredProcedure, paras, values);
            return ds;
        }

        public static DataSet getCTPNHangHoa()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetCTPN", CommandType.StoredProcedure);
        }
        public static DataSet getCTPNHangHoa123()
        {
            return Model.ConnectionToSQL.FillDataSet("spgetHangHoainPhieuNhap", CommandType.StoredProcedure);
        }
    }
}
