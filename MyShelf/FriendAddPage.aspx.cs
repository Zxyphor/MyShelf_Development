using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

namespace MyShelf
{
	public partial class FriendAddPage : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["email"] == null)
                {
                    Response.Redirect("LoginPage.aspx");
                }
                UpdateTable();
            }
        }
        protected void gvFriendList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button deleteEntry = e.Row.FindControl("btnDeleteEntry") as Button;

                deleteEntry.CommandArgument = e.Row.Cells[0].Text;

            }
        }

        protected void gvFriendList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteEntry")
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyShelfDB"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "WITH friends as (SELECT UserID FROM ProfileInfo WHERE Username = '" + e.CommandArgument.ToString() + "') DELETE FROM FriendInfo WHERE FriendID = (SELECT DISTINCT FriendID FROM FriendInfo JOIN friends ON FriendInfo.FriendID = friends.UserID);";
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    UpdateTable();
                }
            }
        }

        protected void UpdateTable()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyShelfDB"].ConnectionString;
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand updateTable = new SqlCommand();
            updateTable.Connection = conn;

            updateTable.CommandText = "WITH friends as (SELECT FriendID FROM FriendInfo WHERE UserID = '" + int.Parse(Session["email"].ToString()) + "') SELECT Username FROM ProfileInfo JOIN friends ON ProfileInfo.UserID = friends.FriendID;";
            sda.SelectCommand = updateTable;

            conn.Open();
            sda.Fill(dt);
            gvFriendList.DataSource = dt;
            gvFriendList.DataBind();
            conn.Close();
        }

        protected void AddEntry()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyShelfDB"].ConnectionString;

            SqlCommand addEntry = new SqlCommand();
            addEntry.Connection = conn;


            addEntry.CommandText = "INSERT INTO FriendInfo (FriendID, UserID) VALUES ('" + txtFriendInput.Text.Trim() + "', '" + int.Parse(Session["email"].ToString()) + "'); ";

            conn.Open();
            addEntry.ExecuteNonQuery();
            conn.Close();
            txtFriendInput.Text = "";
        }

        protected void btnAddEntry_Click(object sender, EventArgs e)
        {
            AddEntry();
            UpdateTable();
        }
    }
}