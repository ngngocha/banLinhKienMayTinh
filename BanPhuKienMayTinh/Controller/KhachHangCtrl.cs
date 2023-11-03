using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Controller
{
    class KhachHangCtrl
    {
        public static DataSet FillDataSet_getKhachHangByIDKhachHang(string _MaKhachHang)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.KhachHangMod khachhang = new Model.KhachHangMod(_MaKhachHang);
                return khachhang.Filldataset_getKhachHangbyIDKhachHang();
            }
            catch
            {
                return null;
            }
        }
        public static DataSet FillDataSet_SearchKhachHangByIDKhachHang(string _MaKhachHang)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.KhachHangMod khachhang = new Model.KhachHangMod(_MaKhachHang);
                return khachhang.Filldataset_SearchKhachHangbyIDKhachHang();
            }
            catch
            {
                return null;
            }
        }
        public static DataSet FillDataSet_SearchKhachHangByTenKhachHang(string _TenKH)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.KhachHangMod khachhang = new Model.KhachHangMod(_TenKH);
                return khachhang.Filldataset_SearchKhachHangbyTenKhachHang();
            }
            catch
            {
                return null;
            }
        }
        // Method ADD
        public static int InsertKhachHang(string _MaKhachHang, string _HoLotKhachHang, DateTime _NgaysinhKhachHang, string _GioiTinhKhachHang, string _DienThoaiKhachHang, string _EmailKhachHang, string _DiachiKhachHang)
        // Copy bên KhachHangMod - try - catch
        {
            try
            {
                Model.KhachHangMod _KhachHang = new Model.KhachHangMod(_MaKhachHang, _HoLotKhachHang, _NgaysinhKhachHang, _GioiTinhKhachHang, _DienThoaiKhachHang, _EmailKhachHang, _DiachiKhachHang);
                return _KhachHang.InsertKhachHang();
            }
            catch
            {
                return 0;
            }
        }

        // Method UPDATE
        public static int UpdateKhachHang(string _MaKhachHang, string _HoLotKhachHang, DateTime _NgaysinhKhachHang, string _GioiTinhKhachHang, string _DienThoaiKhachHang, string _EmailKhachHang, string _DiachiKhachHang)
        // Copy bên KhachHangMod - try - catch
        {
            try
            {
                Model.KhachHangMod _KhachHang = new Model.KhachHangMod(_MaKhachHang, _HoLotKhachHang, _NgaysinhKhachHang, _GioiTinhKhachHang, _DienThoaiKhachHang, _EmailKhachHang, _DiachiKhachHang);
                return _KhachHang.UpdateKhachHang();
            }
            catch
            {
                return 0;
            }
        }

        // Method Delete
        public static int DeleteKhachHang(string _MaKhachHang)
        {
            try
            {
                Model.KhachHangMod _KhachHang = new Model.KhachHangMod(_MaKhachHang);
                return _KhachHang.DeleteKhachHang();
            }
            catch
            {
                return 0;
            }
        }
    }
}
