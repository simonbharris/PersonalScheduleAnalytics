using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class CreateUserAccount : System.Web.UI.Page
{

    string connectionString = @"Server=localhost;Database=CIS470_seniorproject;Uid=SeniorProject;Pwd=password";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnUserAccountCreate_Click(object sender, EventArgs e)
    {

        string username = txtNewUserID.Text;
        string password = txtNewUserPassword.Text;
        string email = txtNewUserEmail.Text;
        string firstName = txtNewUserFirstName.Text; 
        string lastName = txtNewUserLastName.Text;
        DateTime startDt = DateTime.Now;

        if (username != "" && password != "")
        {
            try
            {
                MySqlCommand cmd;

                MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                conn.Open();

                string sqlStmt = "INSERT INTO CIS470_seniorproject.users (UserID, UserPW, UserEmail, UserFirstName, UserLastName, UserStartDt) " + "Values('" + username + "',' " + password + "',' " + email + "',' " + firstName + "','" + lastName + "','" + startDt + "' )";

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