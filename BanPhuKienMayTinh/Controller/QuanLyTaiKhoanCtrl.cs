using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Controller
{
    class QuanLyTaiKhoanCtrl
    {
        public static DataSet CheckTaiKhoan(string _IDTK, string _Password)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.QuanLyTaiKhoanMod quanlytk = new Model.QuanLyTaiKhoanMod(_IDTK, _Password);
                return quanlytk.CheckTaiKhoan();
            }
            catch
            {
                return null;
            }
        }
        public static DataSet CheckQuyenTaiKhoan(string _IDTK)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.QuanLyTaiKhoanMod quanlytk = new Model.QuanLyTaiKhoanMod(_IDTK);
                return quanlytk.CheckQuyenTaiKhoan();
            }
            catch
            {
                return null;
            }
        }
        public static DataSet SearchTaiKhoan(string _IDTK)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.QuanLyTaiKhoanMod quanlytk = new Model.QuanLyTaiKhoanMod(_IDTK);
                return quanlytk.SearchTaiKhoan();
            }
            catch
            {
                return null;
            }
        }

        public static DataSet SearchTaiKhoanbyLoaiTK(string _LoaiTK)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.QuanLyTaiKhoanMod quanlytk = new Model.QuanLyTaiKhoanMod(_LoaiTK);
                return quanlytk.SearchTaiKhoanbyLoaiTK();
            }
            catch
            {
                return null;
            }
        }

        public static int InsertTaiKhoan(string _IDTK, string _Password, string _LoaiTK)
        {
            try
            {
                Model.QuanLyTaiKhoanMod quanlytk = new Model.QuanLyTaiKhoanMod(_IDTK, _Password, _LoaiTK);
                return quanlytk.InsertTaiKhoan();
            }
            catch
            {
                return 0;
            }
        }
        public static int UpdateTaiKhoan(string _IDTK, string _Password, string _LoaiTK)
        {
            try
            {
                Model.QuanLyTaiKhoanMod quanlytk = new Model.QuanLyTaiKhoanMod(_IDTK, _Password, _LoaiTK);
                return quanlytk.UpdateTaiKhoan();
            }
            catch
            {
                return 0;
            }
        }
        public static int DeleteTaiKhoan(string _IDTK)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.QuanLyTaiKhoanMod quanlytk = new Model.QuanLyTaiKhoanMod(_IDTK);
                return quanlytk.DeleteTaiKhoan();
            }
            catch
            {
                return 0;
            }
        }
    }
}
