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
    }
}