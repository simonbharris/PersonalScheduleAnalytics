using System;
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
        string userID = txtNewUserID.Text.Trim();
        string password = txtNewUserPassword.Text.Trim();
        string verifyPassword = txtVerifyNewUserPassword.Text.Trim();
        string email = txtNewUserEmail.Text.Trim();
        string firstName = txtNewUserFirstName.Text.Trim();
        string lastName = txtNewUserLastName.Text.Trim();
        FileUpload pic = (FileUpload)imgNewUserPic;
        int userIDExists = 0;

        MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();

        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) AS COUNT FROM cis470_seniorproject.users WHERE LOWER(UserID) = LOWER('" + userID + "')";
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            userIDExists = Convert.ToInt32(reader["COUNT"]);
        }
        reader.Close();

        if (userID == "")
        {//standard validation of empty field
            txtNewUserID.BackColor = System.Drawing.Color.Yellow;
            txtNewUserPassword.BackColor = System.Drawing.Color.White;
            txtVerifyNewUserPassword.BackColor = System.Drawing.Color.White;
            txtNewUserEmail.BackColor = System.Drawing.Color.White;
            txtNewUserFirstName.BackColor = System.Drawing.Color.White;
            txtNewUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "Please enter a User ID.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (userID != "" && userIDExists != 0)
        {//standard validation of empty field
            txtNewUserID.BackColor = System.Drawing.Color.Yellow;
            txtNewUserPassword.BackColor = System.Drawing.Color.White;
            txtVerifyNewUserPassword.BackColor = System.Drawing.Color.White;
            txtNewUserEmail.BackColor = System.Drawing.Color.White;
            txtNewUserFirstName.BackColor = System.Drawing.Color.White;
            txtNewUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "User ID is already taken, please select a different User ID.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (password == "")
        {//standard validation of empty field
            txtNewUserID.BackColor = System.Drawing.Color.White;
            txtNewUserPassword.BackColor = System.Drawing.Color.Yellow;
            txtVerifyNewUserPassword.BackColor = System.Drawing.Color.White;
            txtNewUserEmail.BackColor = System.Drawing.Color.White;
            txtNewUserFirstName.BackColor = System.Drawing.Color.White;
            txtNewUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "Please enter a Pasword.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (verifyPassword == "")
        {//standard validation of empty field
            txtNewUserID.BackColor = System.Drawing.Color.White;
            txtNewUserPassword.BackColor = System.Drawing.Color.White;
            txtVerifyNewUserPassword.BackColor = System.Drawing.Color.Yellow;
            txtNewUserEmail.BackColor = System.Drawing.Color.White;
            txtNewUserFirstName.BackColor = System.Drawing.Color.White;
            txtNewUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "Please verify your Password.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (password != verifyPassword)
        {//validates matching password and password verification fields
            txtNewUserID.BackColor = System.Drawing.Color.White;
            txtNewUserPassword.BackColor = System.Drawing.Color.Yellow;
            txtVerifyNewUserPassword.BackColor = System.Drawing.Color.Yellow;
            txtNewUserEmail.BackColor = System.Drawing.Color.White;
            txtNewUserFirstName.BackColor = System.Drawing.Color.White;
            txtNewUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "Password and Password Verification must be the same.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (firstName == "")
        {//standard validation of empty field
            txtNewUserID.BackColor = System.Drawing.Color.White;
            txtNewUserPassword.BackColor = System.Drawing.Color.White;
            txtVerifyNewUserPassword.BackColor = System.Drawing.Color.White;
            txtNewUserEmail.BackColor = System.Drawing.Color.White;
            txtNewUserFirstName.BackColor = System.Drawing.Color.Yellow;
            txtNewUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "Please enter your First Name.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (lastName == "")
        {//standard validation of empty field
            txtNewUserID.BackColor = System.Drawing.Color.White;
            txtNewUserPassword.BackColor = System.Drawing.Color.White;
            txtVerifyNewUserPassword.BackColor = System.Drawing.Color.White;
            txtNewUserEmail.BackColor = System.Drawing.Color.White;
            txtNewUserFirstName.BackColor = System.Drawing.Color.White;
            txtNewUserLastName.BackColor = System.Drawing.Color.Yellow;
            lblError.Text = "Please enter your Last Name.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (email == "")
        {//standard validation of empty field
            txtNewUserID.BackColor = System.Drawing.Color.White;
            txtNewUserPassword.BackColor = System.Drawing.Color.White;
            txtVerifyNewUserPassword.BackColor = System.Drawing.Color.White;
            txtNewUserEmail.BackColor = System.Drawing.Color.Yellow;
            txtNewUserFirstName.BackColor = System.Drawing.Color.White;
            txtNewUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "Please enter an Email address.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (userID != "" && password != "" && verifyPassword != "" && email != "" && firstName != "" && lastName != "")
        {//resets validation fields
            txtNewUserID.BackColor = System.Drawing.Color.White;
            txtNewUserPassword.BackColor = System.Drawing.Color.White;
            txtVerifyNewUserPassword.BackColor = System.Drawing.Color.White;
            txtNewUserEmail.BackColor = System.Drawing.Color.White;
            txtNewUserFirstName.BackColor = System.Drawing.Color.White;
            txtNewUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "";
            lblError.BackColor = System.Drawing.Color.White;

            Session["sessionUserID"] = userID;

            try
            {
                MySqlCommand cmd;

                MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                conn.Open();

                string sqlStmt = "INSERT INTO CIS470_seniorproject.users (UserID, UserPW, UserEmail, UserFirstName, UserLastName, UserStartDt, UserPic) Values('" + userID + "','" + password + "','" + email + "','" + firstName + "','" + lastName + "',NOW(),'" + pic + "');";

                cmd = new MySqlCommand(sqlStmt, conn);
                cmd.ExecuteReader();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex);
            }

            Response.Redirect("~/frmDashboard.aspx?userID=" + userID);

        }
    }

}      