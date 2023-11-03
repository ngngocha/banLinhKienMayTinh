using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Controller
{
    class NhomLoaiHangHoaCtrl
    {
        public static DataSet SearchNhomLoaiHangHoabyIDNhomLoaiHangHoa(string _MaNhomLoai)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.NhomLoaiHangHoaMod NhomLoaiHangHoa = new Model.NhomLoaiHangHoaMod(_MaNhomLoai);
                return NhomLoaiHangHoa.SearchNhomLoaiHangHoabyIDNhomLoaiHangHoa();
            }
            catch
            {
                return null;
            }
        }
        public static DataSet SearchNhomLoaiHangHoabyTenNhomLoaiHangHoa(string _TenNhomLoai)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.NhomLoaiHangHoaMod NhomLoaiHangHoa = new Model.NhomLoaiHangHoaMod(_TenNhomLoai);
                return NhomLoaiHangHoa.SearchNhomLoaiHangHoabyTenNhomLoaiHangHoa();
            }
            catch
            {
                return null;
            }
        }
        public static int InsertNhomLoai(string _MaNhomLoai, string _TenNhomLoai, string _MoTa)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.NhomLoaiHangHoaMod NhomLoaiHangHoa = new Model.NhomLoaiHangHoaMod(_MaNhomLoai, _TenNhomLoai, _MoTa);
                return NhomLoaiHangHoa.InsertNhomLoai();
            }
            catch
            {
                return 0;
            }
        }
        public static int UpdateNhomLoai(string _MaNhomLoai, string _TenNhomLoai, string _MoTa)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.NhomLoaiHangHoaMod NhomLoaiHangHoa = new Model.NhomLoaiHangHoaMod(_MaNhomLoai, _TenNhomLoai, _MoTa);
                return NhomLoaiHangHoa.UpdateNhomLoai();
            }
            catch
            {
                return 0;
            }
        }
        public static int DeleteNhomLoai(string _MaNhomLoai)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.NhomLoaiHangHoaMod NhomLoaiHangHoa = new Model.NhomLoaiHangHoaMod(_MaNhomLoai);
                return NhomLoaiHangHoa.DeleteNhomLoai();
            }
            catch
            {
                return 0;
            }
        }
    }
}
