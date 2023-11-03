using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Controller
{
    class HangHoaCtrl
    {
        public static DataSet FillDataSet_getHangHoaByIDHangHoa(string _MaHH)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.HangHoaMod hanghoa = new Model.HangHoaMod(_MaHH);
                return hanghoa.Filldataset_getHangHoabyIDHangHoa();
            }
            catch
            {
                return null;
            }
        }
        public static DataSet FillDataSet_SearchHangHoaByIDHangHoa(string _MaHH)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.HangHoaMod hanghoa = new Model.HangHoaMod(_MaHH);
                return hanghoa.Filldataset_SearchHangHoabyIDHangHoa();
            }
            catch
            {
                return null;
            }
        }
        public static DataSet FillDataSet_SearchHangHoaByTenHangHoa(string _TenHH)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.HangHoaMod hanghoa = new Model.HangHoaMod(_TenHH);
                return hanghoa.Filldataset_SearchHangHoabyTenHangHoa();
            }
            catch
            {
                return null;
            }
        }
        // Method ADD
        public static int InsertHangHoa(string _MaHH, string _TenHH, string _MaNhomLoai, string _GiaBan, string _DVTinh, string _MoTa)
        // Copy bên HangHoaMod - try - catch
        {
            try
            {
                Model.HangHoaMod _HangHoa = new Model.HangHoaMod( _MaHH,  _TenHH, _MaNhomLoai,  _GiaBan,  _DVTinh,  _MoTa);
                return _HangHoa.InsertHangHoa();
            }
            catch
            {
                return 0;
            }
        }

        // Method UPDATE
        public static int UpdateHangHoa(string _MaHH, string _TenHH, string _MaNhomLoai, string _GiaBan, string _DVTinh, string _MoTa)
        // Copy bên HangHoaMod - try - catch
        {
            try
            {
                Model.HangHoaMod _HangHoa = new Model.HangHoaMod(_MaHH, _TenHH, _MaNhomLoai, _GiaBan, _DVTinh, _MoTa);
                return _HangHoa.UpdateHangHoa();
            }
            catch
            {
                return 0;
            }
        }

        // Method Delete
        public static int DeleteHangHoa(string _MaHH)
        {
            try
            {
                Model.HangHoaMod _HangHoa = new Model.HangHoaMod(_MaHH);
                return _HangHoa.DeleteHangHoa();
            }
            catch
            {
                return 0;
            }
        }

    }
}
