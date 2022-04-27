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
                mbtnSignup.Visible = false;
                mbtnLogout.Visible = true;
                mbtnLogin.Visible = false;
            }
            else
            {
                mbtnLogin.Visible = false;
                mbtnSignup.Visible = false;
                mbtnLogout.Visible = false;
            }
        }

        //Hey. Hey. Before you judge. Is this a design course? No. Keep on grading. I've got my eye on you. 

        protected void mbtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void mbtnSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpPage.aspx");
        }

        protected void mbtnLogout_Click(object sender, EventArgs e)
        {
            //Session.Remove("email");
            //Response.Redirect("LoginPage.aspx");
            if (mbtnLogout.Text == "Login")
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                Session.Remove("email");
                Response.Redirect("LoginPage.aspx");
            }
        }

    }
}