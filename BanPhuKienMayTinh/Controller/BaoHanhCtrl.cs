using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Controller
{
    class BaoHanhCtrl
    {
        public static int UpdateTinhTrangBaoHanh(string _IMEI, string _TinhTrangBaoHanh)
        {
            try
            {
                Model.BaoHanhMod BaoHanh = new Model.BaoHanhMod(_IMEI, _TinhTrangBaoHanh);
                return BaoHanh.UpdateTinhTrangBaoHanh();
            }
            catch
            {
                return 0;
            }
        }

        public static int InsertBaoHanh(string _MaNhomLoai, string _ThoiGianBaoHanh)
        {
            try
            {
                Model.BaoHanhMod BaoHanh = new Model.BaoHanhMod(_MaNhomLoai, _ThoiGianBaoHanh);
                return BaoHanh.InsertBaoHanh();
            }
            catch
            {
                return 0;
            }
        }

        public static int UpdateBaoHanh(string _MaNhomLoai, string _ThoiGianBaoHanh)
        {
            try
            {
                Model.BaoHanhMod BaoHanh = new Model.BaoHanhMod(_MaNhomLoai, _ThoiGianBaoHanh);
                return BaoHanh.UpdateBaoHanh();
            }
            catch
            {
                return 0;
            }
        }

        public static int DeleteBaoHanh(string _MaNhomLoai)
        {
            try
            {
                Model.BaoHanhMod BaoHanh = new Model.BaoHanhMod(_MaNhomLoai);
                return BaoHanh.DeleteBaoHanh();
            }
            catch
            {
                return 0;
            }
        }

        public static DataSet Filldataset_SearchBaoHanh(string _MaNhomLoai)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.BaoHanhMod BaoHanh = new Model.BaoHanhMod(_MaNhomLoai);
                return BaoHanh.SearchBaoHanh();
            }
            catch
            {
                return null;
            }
        }

        public static DataSet Filldataset_SearchBaoHanhTheoIMEI(string _IMEI)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.BaoHanhMod BaoHanh = new Model.BaoHanhMod(_IMEI);
                return BaoHanh.SearchBaoHanhTheoIMEI();
            }
            catch
            {
                return null;
            }
        }
        public static DataSet Filldataset_SearchBaoHanhTheoMaNhomLoai(string _MaNhomLoai)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.BaoHanhMod BaoHanh = new Model.BaoHanhMod(_MaNhomLoai);
                return BaoHanh.SearchBaoHanhTheoMaNhomLoai();
            }
            catch
            {
                return null;
            }
        }
    }
}
