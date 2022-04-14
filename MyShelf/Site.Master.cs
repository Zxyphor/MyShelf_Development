using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace MyShelf
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UpdateTable();
            }
        }

        protected void btnCreateProfile_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AddToDatabase(txtEmail.Text, txtUsername.Text, txtPassword.Text);
                UpdateTable();
            }
        }

        protected void AddToDatabase(String email, String username, String password)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyShelfDB"].ConnectionString;

            SqlCommand addUser = new SqlCommand();
            addUser.Connection = conn;

            addUser.CommandText = "INSERT INTO UserInfo (Email, Password) VALUES ('" + email + "', '" + password + "'); " +
                "INSERT INTO ProfileInfo (Username) VALUES ('" + username + "')";

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
            if (gvDebugTable.Visible)
            {
                gvDebugTable.Visible = false;
            } else
            {
                gvDebugTable.Visible = true;
            }
        }
    }
}