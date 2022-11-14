using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheGioiDiDong2.Web.DangKy
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void bDangKy_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand
                        ("insert into [NguoiDung] (TaiKhoan, MatKhau, FullName) values (@TaiKhoan, @MatKhau, @FullName)", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@TaiKhoan", tbTaiKhoan.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", tbMatKhau.Text);
                    cmd.Parameters.AddWithValue("@FullName", tbFullName.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("DangNhap.aspx");
                }
            }
        }
        bool Validate()
        {
           
            if(tbMatKhau.Text != reMatKhau.Text)
            {
                Check.Text = "Mật khẩu không trùng khớp";
                return false;
            }
            else if(tbTaiKhoan.Text== "" || tbMatKhau.Text == "" || reMatKhau.Text == "")
            {
                Check.Text = "Vui lòng điền đủ thông tin đã cho!";
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}