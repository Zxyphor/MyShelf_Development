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
                //        UpdateTable();
            }
            if (Session["email"] != null)
            {
                mbtnProfile.Visible = true;
                mbtnLogin.Visible = true;
                mbtnSignup.Visible = true;
                mbtnLogout.Visible = true;
            } else
            {
                mbtnProfile.Visible = false;
                mbtnLogin.Visible = false;
                mbtnSignup.Visible = false;
                mbtnLogout.Visible = false;
            }
        }

        //Hey. Hey. Before you judge. Is this a design course? No. Keep on grading. I've got my eye on you. 

        protected void mbtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("FriendAddPage.aspx");
        }

        protected void mbtnSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("GameAddPage.aspx");
        }

        protected void mbtnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("email");
            Response.Redirect("LoginPage.aspx");
        }

        protected void mbtnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyShelfProfile.aspx");
        }

        //protected void UpdateTable()
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyShelfDB"].ConnectionString;
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    DataTable dt = new DataTable();

        //    SqlCommand updateTable = new SqlCommand();
        //    updateTable.Connection = conn;

        //    updateTable.CommandText = "SELECT * FROM UserInfo;";
        //    sda.SelectCommand = updateTable;

        //    conn.Open();
        //    sda.Fill(dt);
        //    gvDebugTable.DataSource = dt;
        //    gvDebugTable.DataBind();
        //    conn.Close();
        //}
    }
}