using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Web.Security;
namespace MyShelf
{
    public partial class MyShelfProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getUserName();

        }

        protected void getUserName() 
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyShelfDB"].ConnectionString;

            SqlCommand getUsername = new SqlCommand();
            getUsername.Connection = conn;
            getUsername.CommandText = "SELECT Username, ProfilePicture FROM ProfileInfo WHERE UserID= '"+Session["email"]+ "'";
            conn.Open();

            SqlDataReader sdr = getUsername.ExecuteReader();

            if (sdr.HasRows) 
            {
                if (sdr.Read())
                {
                    lblUsername.Text = sdr["Username"].ToString();
                    imgProfile.ImageUrl = "/Content/" + sdr["ProfilePicture"].ToString();
                }
            }

            
        }

    }
}