using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanPhuKienMayTinh.Controller
{
    class CTHDCtrl
    {
        public static int UpdateSoLuong(string _MaHH, string _SoLuong)
        {
            try
            {
                Model.CTDHMod _CTDH = new Model.CTDHMod(_MaHH, _SoLuong);
                return _CTDH.UpdateSoLuongHang();
            }
            catch
            {
                return 0;
            }
        }
        public static int InsertCTHD(string _MaHD, string _TenHH, string _SoLuong, string _DonGia, string _ThanhTien, DateTime _ThoiGianBaoHanh, string _IMEI, string _TinhTrangBaoHanh, string _IDKhuyenMai)
        // Copy bên CTHDMod - try - catch
        {
            try
            {
                Model.CTDHMod _CTHD = new Model.CTDHMod(_MaHD, _TenHH, _SoLuong, _DonGia, _ThanhTien, _ThoiGianBaoHanh, _IMEI, _TinhTrangBaoHanh, _IDKhuyenMai);
                return _CTHD.InsertCTHD();
            }
            catch
            {
                return 0;
            }
        }
        public static int DeleteCTHD(string _MaHD)
        {
            try
            {
                Model.CTDHMod _CTHD = new Model.CTDHMod(_MaHD);
                return _CTHD.DeleteCTHD();
            }
            catch
            {
                return 0;
            }
        }

        // Method Delete
        public static int DeleteCTHDTheoCTHD(string _MaHD, string _TenHH)
        {
            try
            {
                Model.CTDHMod _CTHD = new Model.CTDHMod(_MaHD,_TenHH);
                return _CTHD.DeleteCTHDTheoCTHD();
            }
            catch
            {
                return 0;
            }
        }
        public static DataSet FillDataSet_FilldatasetCTHDbyIDHD(string _MaHD)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.CTDHMod HoaDon = new Model.CTDHMod(_MaHD);
                return HoaDon.Filldataset_getCTHDHangHoa();//note
            }
            catch
            {
                return null;
            }
        }
        public static DataSet Filldataset_getCTHDHangHoa(string TenHH)
        {
            //ta dùng try - cactch để bắt lỗi
            try
            {
                Model.CTDHMod HoaDon = new Model.CTDHMod(TenHH);
                return HoaDon.Filldataset_getCTHDHangHoa();//note
            }
            catch
            {
                return null;
            }
        }

        public static DataSet FillDataset_getspCTHD(string _TenHH)
        {
            try
            {
                Model.CTDHMod HoaDon = new Model.CTDHMod(_TenHH);
                return HoaDon.GetspCTHD();
            }
            catch
            {
                return null;
            }
        }
        public static DataSet FillDataset_getKhuyenMaiCTHD(string _TenHH)
        {
            try
            {
                Model.CTDHMod HoaDon = new Model.CTDHMod(_TenHH);
                return HoaDon.GetKhuyenMaiCTHD();
            }
            catch
            {
                return null;
            }
        }
    }
}
