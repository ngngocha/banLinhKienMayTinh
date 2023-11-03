using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanPhuKienMayTinh.Model
{
    class QuanLyTaiKhoanMod
    {
        //Khai báo biến
        protected string IDTK { get; set; }
        protected string Password { get; set; }
        protected string LoaiTK { get; set; }
        
        public QuanLyTaiKhoanMod(string _IDTK)
        {
            IDTK = _IDTK;
        }
        public QuanLyTaiKhoanMod(string _IDTK, string _Password)
        {
            IDTK = _IDTK;
            Password = _Password;
        }
        public QuanLyTaiKhoanMod(string _IDTK, string _Password, string _LoaiTK)
        {
            IDTK = _IDTK;
            Password = _Password;
            LoaiTK = _LoaiTK;
        }
        //Khai báo thêm - xóa
        public int InsertTaiKhoan()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta HHai báo trong SQL
            string[] paras = new string[2] { "@IDTK", "@Password" };
            object[] values = new object[2] { IDTK, Password };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spInsertTaiKhoan", CommandType.StoredProcedure, paras, values);
            // lưu ý : các biến truyền vào phải giống các biến ta HHai báo trong SQL
            paras = new string[2] { "@IDTK", "@LoaiTK" };
            values = new object[2] { IDTK, LoaiTK };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spInsertQuyenTaiKhoan", CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int UpdateTaiKhoan()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta HHai báo trong SQL
            string[] paras = new string[2] { "@IDTK", "@Password" };
            object[] values = new object[2] { IDTK, Password };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spUpdateTaiKhoan", CommandType.StoredProcedure, paras, values);
            // lưu ý : các biến truyền vào phải giống các biến ta HHai báo trong SQL
            paras = new string[2] { "@IDTK", "@LoaiTK" };
            values = new object[2] { IDTK, LoaiTK };
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("spUpdateQuyenTaiKhoan", CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int DeleteTaiKhoan()
        {
            int i = 0;
            // lưu ý : các biến truyền vào phải giống các biến ta HHai báo trong SQL
            string[] paras = new string[1] { "@IDTK"};
            object[] values = new object[1] { IDTK};
            // Gọi đúng tên thủ tục vừa nãy ta đặt
            i = Model.ConnectionToSQL.Excute_Sql("sqDeleteTaiKhoan", CommandType.StoredProcedure, paras, values);
            return i;
        }
        public static DataSet FilldatasetTaiKhoan()
        {
            // Ta gọi thủ tục getHangHoa nãy đã tạo ra
            return Model.ConnectionToSQL.FillDataSet("spGetTaiKhoan", CommandType.StoredProcedure);
        }
        public DataSet SearchTaiKhoan()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@IDTK" };
            object[] values = new object[1] { IDTK };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchTimKiemTaiKhoan", CommandType.StoredProcedure, paras, values);
            return ds;
        }

        public DataSet SearchTaiKhoanbyLoaiTK()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@LoaiTK" };
            object[] values = new object[1] { IDTK };
            ds = Model.ConnectionToSQL.FillDataSet("spSearchTimKiemTaiKhoanbyLoaiTK", CommandType.StoredProcedure, paras, values);
            return ds;
        }

        public DataSet CheckTaiKhoan()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[2] { "@IDTK", "Password" };
            object[] values = new object[2] { IDTK, Password };
            ds = Model.ConnectionToSQL.FillDataSet("spLogIn", CommandType.StoredProcedure, paras, values);
            return ds;
        }
        public DataSet CheckQuyenTaiKhoan()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@IDTK" };
            object[] values = new object[1] { IDTK };
            ds = Model.ConnectionToSQL.FillDataSet("spCheckID", CommandType.StoredProcedure, paras, values);
            return ds;
        }
    } 
}
