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
	public partial class LoginPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            UpdateTable();
		}

        protected void btnCreateProfile_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AddToDatabase(txtEmail.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim());
                UpdateTable();
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void AddToDatabase(String email, String username, String password)
        {
            string imagePath = "beegyosh.jpg";
            if (fuProfileImage.HasFile)
            {
                imagePath = fuProfileImage.FileName;
            }
                fuProfileImage.SaveAs(Server.MapPath(Request.ApplicationPath) + "/Content/" + imagePath);
                SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyShelfDB"].ConnectionString;

            SqlCommand addUser = new SqlCommand();
            addUser.Connection = conn;

#pragma warning disable CS0618 // Type or member is obsolete
            string passwordHash = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
#pragma warning restore CS0618 // Type or member is obsolete

            addUser.CommandText = "INSERT INTO UserInfo (Email, Password) VALUES ('" + email + "', '" + passwordHash + "'); " +
                "INSERT INTO ProfileInfo VALUES ('" + username + "', '" + imagePath +"');";

            conn.Open();
            addUser.ExecuteNonQuery();
            conn.Close();
        }

        protected void UpdateTable()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyShelfDB"].ConnectionString;
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand updateTable = new SqlCommand();
            updateTable.Connection = conn;

            updateTable.CommandText = "SELECT * FROM UserInfo;";
            sda.SelectCommand = updateTable;

            conn.Open();
            sda.Fill(dt);
            gvDebugTable.DataSource = dt;
            gvDebugTable.DataBind();
            conn.Close();
        }

        protected void btnDebugTable_Click(object sender, EventArgs e)
        {
            gvDebugTable.Visible = !gvDebugTable.Visible;
            UpdateTable();
        }
        protected void btnLogin_Click(object sender, EventArgs e) 
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}