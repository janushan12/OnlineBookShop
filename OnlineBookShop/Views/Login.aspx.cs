using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }

        public static string UName = "";
        public static int User;

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (uname.Value == "" || password.Value == "")
            {
                ErrMsg.Text = "Enter your Username and Password!!!";
            } else if (uname.Value == "admin@gmail.com" && password.Value == "admin")
            {
                Response.Redirect("Admin/Books.aspx");
            }
            else
            {
                string Query = "SELECT * FROM SelTbl WHERE SelEmail = '{0}' AND SelPassword = '{1}'";
                Query = string.Format(Query, uname.Value, password.Value);
                DataTable dt = Con.GetData(Query);
                if (dt.Rows.Count == 0)
                {
                    Response.Redirect("Admin/Books.aspx");
                }
                else
                {
                    UName = uname.Value;
                    User = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("Seller/Selling.aspx");
                }
            }
        }
    }
}