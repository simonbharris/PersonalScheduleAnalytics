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
        string username = txtUserID.Text;
        string password = txtUserPassword.Text;

        if (username != "" && password != "")
        {
            try
            {
                MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                conn.Open();


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex);
            }
        }
        string script = "alert(\"Hello!\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);

    }

    protected void LnkBtnUserCreate_Click(object sender, EventArgs e)
    {
  
    }

}