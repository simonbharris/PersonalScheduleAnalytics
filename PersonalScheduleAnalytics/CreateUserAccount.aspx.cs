using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class CreateUserAccount : System.Web.UI.Page
{

    string connectionString = @"Server=localhost;Database=CIS470_seniorproject;Uid=root;Pwd=Qazwsx1$";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUserAccountCreate_Click(object sender, EventArgs e)
    {

        string username = txtNewUserID.Text;
        string password = txtNewUserPassword.Text;

        if (username != "" && password != "")
        {
            try
            {
                MySqlCommand cmd;

                MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                conn.Open();

                string sqlStmt = "INSERT INTO testtable.users (UserID, UserPW) " + "Values('" + username + "',' " + password + "' )";

                cmd = new MySqlCommand(sqlStmt, conn);
                cmd.ExecuteReader();
                conn.Close();


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex);
            }
        }
    }
}