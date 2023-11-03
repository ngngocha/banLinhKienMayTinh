using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Controller
{
    class PhieuNhapCtrl
    {
        public static DataSet FillDataSet_getPhieuNhapByIDPhieuNhap(string _MaPN)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.PhieuNhapMod PhieuNhap = new Model.PhieuNhapMod(_MaPN);
                return PhieuNhap.Filldataset_getPhieuNhapnbyIDMaPhieuNhap();
            }
            catch
            {
                return null;
            }
        }

        public static int InsertPhieuNhap(string _MaPN, DateTime _NgayLapPhieuNhap, string _MaNhanVien, string _MaNhaCungCap, string _Tong)
        // Copy bên HoaDonMod - try - catch
        {
            try
            {
                Model.PhieuNhapMod _PhieuNhap = new Model.PhieuNhapMod(_MaPN, _NgayLapPhieuNhap, _MaNhanVien, _MaNhaCungCap, _Tong);
                return _PhieuNhap.InsertPhieuNhap();
            }
            catch
            {
                return 0;
            }
        }

        // Method Delete
        public static int DeletePhieuNhap(string _MaPN)
        {
            try
            {
                Model.PhieuNhapMod _PhieuNhap = new Model.PhieuNhapMod(_MaPN);
                return _PhieuNhap.DeletePhieuNhap();
            }
            catch
            {
                return 0;
            }
        }
    }
}
