using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Controller
{
    class ChiTietPhieuNhapCtrl
    {
        public static int InsertCTPN(string _MaPN, string _MaHH, string _SoLuong, string _DonGia, string _ThanhTien)
        // Copy bên CTHDMod - try - catch
        {
            try
            {
                Model.ChiTietPhieuNhapMod _CTPN = new Model.ChiTietPhieuNhapMod(_MaPN, _MaHH, _SoLuong, _DonGia, _ThanhTien);
                return _CTPN.InsertChiTietPhieuNhap();
            }
            catch
            {
                return 0;
            }
        }

        // Method Delete
        public static int DeleteCTPN(string _MaPN)
        {
            try
            {
                Model.ChiTietPhieuNhapMod _CTPN = new Model.ChiTietPhieuNhapMod(_MaPN);
                return _CTPN.DeleteCTPN();
            }
            catch
            {
                return 0;
            }
        }
        public static int DeleteCTPNTheoCTPN(string _MaPN, string _TenHH)
        {
            try
            {
                Model.ChiTietPhieuNhapMod _CTPN = new Model.ChiTietPhieuNhapMod(_MaPN, _TenHH);
                return _CTPN.DeleteCTPNTheoCTPN();
            }
            catch
            {
                return 0;
            }
        }

        public static DataSet FillDataSet_FilldatasetCTPNbyIDPN(string _MaPN)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.ChiTietPhieuNhapMod PhieuNhap = new Model.ChiTietPhieuNhapMod(_MaPN);
                return PhieuNhap.Filldataset_getCTPNHangHoa();//note
            }
            catch
            {
                return null;
            }
        }

        public static DataSet Filldataset_getCTHDHangHoa(string _TenHH)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.ChiTietPhieuNhapMod PhieuNhap = new Model.ChiTietPhieuNhapMod(_TenHH);
                return PhieuNhap.Filldataset_getCTPNHangHoa();//note
            }
            catch
            {
                return null;
            }
        }
    }
}
