using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Controller
{
    class HoaDonCtrl
    {
        public static DataSet FillDataSet_getHoaDonByIDHoaDon(string _MaHD)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.HoaDonMod HoaDon = new Model.HoaDonMod(_MaHD);
                return HoaDon.Filldataset_getHoaDonbyIDMaHD();
            }
            catch
            {
                return null;
            }
        }
        public static int InsertHoaDon(string _MaHD, DateTime _NgayLap, string _MaNhanVien, string _MaKhachHang, string _Tong)
        // Copy bên HoaDonMod - try - catch
        {
            try
            {
                Model.HoaDonMod _HoaDon = new Model.HoaDonMod( _MaHD,  _NgayLap,  _MaNhanVien,  _MaKhachHang, _Tong);
                return _HoaDon.InsertHoaDon();
            }
            catch
            {
                return 0;
            }
        }

        // Method Delete
        public static int DeleteHoaDon(string _MaHD)
        {
            try
            {
                Model.HoaDonMod _HoaDon = new Model.HoaDonMod(_MaHD);
                return _HoaDon.DeleteHoaDon();
            }
            catch
            {
                return 0;
            }
        }
    }
}
