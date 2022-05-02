using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;

namespace MyShelf
{
    public partial class LoginPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            string HashedPW = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "SHA1");
#pragma warning restore CS0618 // Type or member is obsolete
            string email = txtEmail.Text.Trim();
            
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyShelfDB"].ConnectionString;
                SqlCommand checkUser = new SqlCommand();
                checkUser.Connection = conn;
                checkUser.CommandText = "SELECT UserID FROM UserInfo WHERE Email ='" + email + "' AND Password = '" + HashedPW + "';";
                conn.Open();
                SqlDataReader sdr = checkUser.ExecuteReader();
                if (sdr.Read())
                {
                    Session["email"] = sdr["UserID"].ToString();
                    Response.Redirect("MyShelfProfile.aspx");
                } else
                {
                    lblLoginFail.Visible = true;
                }
                
            }
        }
    }
}