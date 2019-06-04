using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class frmLoginPage : System.Web.UI.Page
{
    string connectionString = @"Server=localhost;Database=CIS470_seniorproject;Uid=SeniorProject;Pwd=password";

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void LnkBtnUserLogin_Click(object sender, EventArgs e)
    {
        string username = txtUserID.Text.Trim();
        string password = txtUserPassword.Text.Trim();

        if (username != "" && password != "")
        {
            try
            {
                MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                conn.Open();

                Session["sessionUserID"] = txtUserID.Text.Trim();
                Response.Redirect("~/frmDashboard.aspx?userID=" + username);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex);
            }
        }
    }
     

    protected void LnkBtnUserCreate_Click(object sender, EventArgs e)
    {
  
    }

}