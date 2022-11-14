using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheGioiDiDong2.Entity;

namespace TheGioiDiDong2
{
    public partial class GioHangg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ss = (string)Session["FullName"];
            if (Session["UserID"] == null)
            {
                lbSession.Text = "Đăng nhập";
            }
            else
            {
                lbSession.Text = "Xin chào: " + ss + "";
            }
            if (Session["UserID"] == null)
            {
                Response.Redirect("DangNhap.aspx");
            }

            int uID = (int)Session["UserID"];
            List<GioHang> list = Dao.DaoGiohang.getAll(uID);
            dtlDetaiBuy.DataSource = list;
            DataBind();
        }
        protected void bQly_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                Response.Redirect("QuanLy/QlySanPham.aspx");
            }
        }
    }
}