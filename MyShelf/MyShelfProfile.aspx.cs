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
            if (Session["email"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            getUserName();
            UpdateFriendTable();
            UpdateGameTable();
        }

        protected void getUserName()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyShelfDB"].ConnectionString;

            SqlCommand getUsername = new SqlCommand();
            getUsername.Connection = conn;
            getUsername.CommandText = "SELECT Username, ProfilePicture FROM ProfileInfo WHERE UserID= '" + Session["email"] + "'";
            conn.Open();

            SqlDataReader sdr = getUsername.ExecuteReader();

            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    lblUsername.Text = sdr["Username"].ToString();
                    imgProfile.ImageUrl = "~/Content/" + sdr["ProfilePicture"];
                }
            }


        }
        protected void UpdateGameTable()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyShelfDB"].ConnectionString;
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand updateTable = new SqlCommand();
            updateTable.Connection = conn;

            updateTable.CommandText = "SELECT GameName FROM ShelfInfo WHERE UserID = '" + int.Parse(Session["email"].ToString()) + "';";
            sda.SelectCommand = updateTable;

            conn.Open();
            sda.Fill(dt);
            gvGameList.DataSource = dt;
            gvGameList.DataBind();
            conn.Close();
        }
        protected void UpdateFriendTable()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyShelfDB"].ConnectionString;
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand updateTable = new SqlCommand();
            updateTable.Connection = conn;

            updateTable.CommandText = "WITH Friends as (SELECT GameID FROM FriendInfo WHERE UserID = '" + int.Parse(Session["email"].ToString()) + "') SELECT Username FROM ProfileInfo JOIN friends ON ProfileInfo.UserID = friends.GameID;";
            sda.SelectCommand = updateTable;

            conn.Open();
            sda.Fill(dt);
            gvFriendList.DataSource = dt;
            gvFriendList.DataBind();
            conn.Close();
        }
    }
}