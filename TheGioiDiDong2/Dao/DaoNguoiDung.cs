 using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TheGioiDiDong2.Entity;

namespace TheGioiDiDong2.Dao
{
    public class DaoNguoiDung
    {
        public static List<NguoiDung> getAll()
        {
            List<NguoiDung> lstND = new List<NguoiDung>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT UserID, TaiKhoan, MatKhau, FullName FROM NguoiDung ";
            //Định nghĩa đối tượng Connection
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                //Khởi tạo đối tượng Command
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();
                //Sử dụng đối tượng DataReader để đọc dữ liệu
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                NguoiDung objSV = null;
                while (sqlDataReader.Read())
                {
                    objSV = new NguoiDung();
                    objSV.UserID = Convert.ToInt32(sqlDataReader["UserID"]);
                    objSV.TaiKhoan = Convert.ToString(sqlDataReader["TaiKhoan"]);
                    objSV.MatKhau = Convert.ToString(sqlDataReader["MatKhau"]);
                    objSV.FullName = Convert.ToString(sqlDataReader["FullName"]);
                    lstND.Add(objSV);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
            return lstND;
                
            }
        }
        
        public static NguoiDung getOne(string _taikhoan, string _matkhau)
        {
            NguoiDung objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "select UserID, TaiKhoan, MatKhau, FullName from [NguoiDung] where TaiKhoan = '" + _taikhoan + "' and MatKhau = '" + _matkhau + "'";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new NguoiDung();
                    objND.UserID = Convert.ToInt32(reader["UserID"]);
                    objND.TaiKhoan = Convert.ToString(reader["TaiKhoan"]);
                    objND.MatKhau = Convert.ToString(reader["MatKhau"]);
                    objND.FullName = Convert.ToString(reader["FullName"]);
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
    }
}
