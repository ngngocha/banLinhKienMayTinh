using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Controller
{
    class NhaCungCapCtrl
    {
        public static DataSet FillDataSet_getNhaCungCapByIDNhaCungCap(string _MaNhaCC)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.NhaCungCapMod ncc = new Model.NhaCungCapMod(_MaNhaCC);
                return ncc.Filldataset_getNhaCungCapbyIDNhaCungCap();
            }
            catch
            {
                return null;
            }
        }

        public static DataSet FillDataSet_SearchNhaCungCapnByIDNhaCungCap(string _MaNhaCC)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.NhaCungCapMod ncc = new Model.NhaCungCapMod(_MaNhaCC);
                return ncc.Filldataset_SearchNhaCungCapbyIDNhaCungCap();
            }
            catch
            {
                return null;
            }
        }

        public static DataSet FillDataSet_SearchNhaCungCapnByTenNhaCungCap(string _TenNhaCC)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.NhaCungCapMod ncc = new Model.NhaCungCapMod(_TenNhaCC);
                return ncc.Filldataset_SearchNhaCungCapbyTenNhaCungCap();
            }
            catch
            {
                return null;
            }
        }

        public static int InsertNhaCungCap(string _MaNhaCC, string _TenNhaCC, string _DiaChi, string _SoDienThoai)
        // Copy bên NhanVienMod - try - catch
        {
            try
            {
                Model.NhaCungCapMod ncc = new Model.NhaCungCapMod(_MaNhaCC, _TenNhaCC, _DiaChi, _SoDienThoai);
                return ncc.InsertNhaCungCap();
            }
            catch
            {
                return 0;
            }
        }

        // Method UPDATE
        public static int UpdateNhaCungCap(string _MaNhaCC, string _TenNhaCC, string _DiaChi, string _SoDienThoai)
        // Copy bên NhanVienMod - try - catch
        {
            try
            {
                Model.NhaCungCapMod ncc = new Model.NhaCungCapMod(_MaNhaCC, _TenNhaCC, _DiaChi, _SoDienThoai);
                return ncc.UpdateNhaCungCap();
            }
            catch
            {
                return 0;
            }
        }

        // Method Delete
        public static int DeleteNhaCungCap(string _MaNhaCC)
        {
            try
            {
                Model.NhaCungCapMod ncc = new Model.NhaCungCapMod(_MaNhaCC);
                return ncc.DeleteNhaCungCap();
            }
            catch
            {
                return 0;
            }
        }
    }
}
