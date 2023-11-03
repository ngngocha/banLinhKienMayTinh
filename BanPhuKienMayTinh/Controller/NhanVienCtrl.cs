using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Controller
{
    class NhanVienCtrl
    {
        public static DataSet FillDataSet_getNhanVienByIDNhanVien(string _MaNhanVien)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.NhanVienMod nvien = new Model.NhanVienMod(_MaNhanVien);
                return nvien.Filldataset_getNhanVienbyIDNhanVien();
            }
            catch
            {
                return null;
            }
        }
        public static DataSet FillDataSet_SearchNhanVienByIDNhanVien(string _MaNhanVien)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.NhanVienMod nvien = new Model.NhanVienMod(_MaNhanVien);
                return nvien.Filldataset_SearchNhanVienbyIDNhanVien();
            }
            catch
            {
                return null;
            }
        }
        public static DataSet FillDataSet_SearchNhanVienByTenNhanVien(string _HoTenNV)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.NhanVienMod nvien = new Model.NhanVienMod(_HoTenNV);
                return nvien.Filldataset_SearchNhanVienbyTenNhanVien();
            }
            catch
            {
                return null;
            }
        }
        // Method ADD
        public static int InsertNhanVien(string _MaNhanVien, string _HoTenNhanVien, DateTime _NgaysinhNhanVien, string _GioiTinhNhanVien, string _DienThoaiNhanVien, string _EmailNhanVien, string _DiachiNhanVien)
        // Copy bên NhanVienMod - try - catch
        {
            try
            {
                Model.NhanVienMod _nhanvien = new Model.NhanVienMod(_MaNhanVien, _HoTenNhanVien, _NgaysinhNhanVien, _GioiTinhNhanVien, _DienThoaiNhanVien, _EmailNhanVien, _DiachiNhanVien );
                return _nhanvien.InsertNhanVien();
            }
            catch
            {
                return 0;
            }
        }

        // Method UPDATE
        public static int UpdateNhanVien(string _MaNhanVien, string _HoTenNhanVien, DateTime _NgaysinhNhanVien, string _GioiTinhNhanVien, string _DienThoaiNhanVien, string _EmailNhanVien, string _DiachiNhanVien)
        // Copy bên NhanVienMod - try - catch
        {
            try
            {
                Model.NhanVienMod _nhanvien = new Model.NhanVienMod(_MaNhanVien, _HoTenNhanVien, _NgaysinhNhanVien, _GioiTinhNhanVien, _DienThoaiNhanVien, _EmailNhanVien, _DiachiNhanVien);
                return _nhanvien.UpdateNhanVien();
            }
            catch
            {
                return 0;
            }
        }

        // Method Delete
        public static int DeleteNhanVien(string _MaNhanVien)
        {
            try
            {
                Model.NhanVienMod _nhanvien = new Model.NhanVienMod(_MaNhanVien);
                return _nhanvien.DeleteNhanVien();
            }
            catch
            {
                return 0;
            }
        }
    }
}
