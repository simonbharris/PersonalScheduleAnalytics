using System;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class frmUpdateUsers : System.Web.UI.Page
{
    string connectionString = @"Server=localhost;Database=CIS470_seniorproject;Uid=SeniorProject;Pwd=password";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnUserUpdate_Click(object sender, EventArgs e)
    {
        string userID = txtUserID.Text.Trim();
        string changePassword = txtUserChangePassword.Text.Trim();
        string verifyPassword = txtUserVerifyPassword.Text.Trim();
        string email = txtUserEmail.Text.Trim();
        string firstName = txtUserFirstName.Text.Trim();
        string lastName = txtUserLastName.Text.Trim();
        FileUpload pic = (FileUpload)imgUserPic;
        int userIDExists = 0;

        MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();

        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) AS COUNT FROM cis470_seniorproject.users WHERE (UPPER(UserID) = UPPER('" + userID + "'))";
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            userIDExists = Convert.ToInt32(reader["COUNT"]);
        }
        reader.Close();

        if (userID == "")
        {//standard validation of empty field
            txtUserID.BackColor = System.Drawing.Color.Yellow;
            txtUserChangePassword.BackColor = System.Drawing.Color.White;
            txtUserVerifyPassword.BackColor = System.Drawing.Color.White;
            txtUserEmail.BackColor = System.Drawing.Color.White;
            txtUserFirstName.BackColor = System.Drawing.Color.White;
            txtUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "Please enter a User ID.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (userID != "" && userIDExists != 0)
        {//standard validation of empty field
            txtUserID.BackColor = System.Drawing.Color.Yellow;
            txtUserChangePassword.BackColor = System.Drawing.Color.White;
            txtUserVerifyPassword.BackColor = System.Drawing.Color.White;
            txtUserEmail.BackColor = System.Drawing.Color.White;
            txtUserFirstName.BackColor = System.Drawing.Color.White;
            txtUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "User ID is already taken, please select a different User ID.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (changePassword == "")
        {//standard validation of empty field
            txtUserID.BackColor = System.Drawing.Color.White;
            txtUserChangePassword.BackColor = System.Drawing.Color.Yellow;
            txtUserVerifyPassword.BackColor = System.Drawing.Color.White;
            txtUserEmail.BackColor = System.Drawing.Color.White;
            txtUserFirstName.BackColor = System.Drawing.Color.White;
            txtUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "Please enter a Pasword.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (verifyPassword == "")
        {//standard validation of empty field
            txtUserID.BackColor = System.Drawing.Color.White;
            txtUserChangePassword.BackColor = System.Drawing.Color.White;
            txtUserVerifyPassword.BackColor = System.Drawing.Color.Yellow;
            txtUserEmail.BackColor = System.Drawing.Color.White;
            txtUserFirstName.BackColor = System.Drawing.Color.White;
            txtUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "Please verify your Password.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (changePassword != verifyPassword)
        {//validates matching password and password verification fields
            txtUserID.BackColor = System.Drawing.Color.White;
            txtUserChangePassword.BackColor = System.Drawing.Color.Yellow;
            txtUserVerifyPassword.BackColor = System.Drawing.Color.Yellow;
            txtUserEmail.BackColor = System.Drawing.Color.White;
            txtUserFirstName.BackColor = System.Drawing.Color.White;
            txtUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "Password and Password Verification must be the same.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (email == "")
        {//standard validation of empty field
            txtUserID.BackColor = System.Drawing.Color.White;
            txtUserChangePassword.BackColor = System.Drawing.Color.White;
            txtUserVerifyPassword.BackColor = System.Drawing.Color.White;
            txtUserEmail.BackColor = System.Drawing.Color.Yellow;
            txtUserFirstName.BackColor = System.Drawing.Color.White;
            txtUserLastName.BackColor = System.Drawing.Color.White; ;
            lblError.Text = "Please enter an Email address.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (firstName == "")
        {//standard validation of empty field
            txtUserID.BackColor = System.Drawing.Color.White;
            txtUserChangePassword.BackColor = System.Drawing.Color.White;
            txtUserVerifyPassword.BackColor = System.Drawing.Color.White;
            txtUserEmail.BackColor = System.Drawing.Color.White;
            txtUserFirstName.BackColor = System.Drawing.Color.Yellow;
            txtUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "Please enter your First Name.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (lastName == "")
        {//standard validation of empty field
            txtUserID.BackColor = System.Drawing.Color.White;
            txtUserChangePassword.BackColor = System.Drawing.Color.White;
            txtUserVerifyPassword.BackColor = System.Drawing.Color.White;
            txtUserEmail.BackColor = System.Drawing.Color.White;
            txtUserFirstName.BackColor = System.Drawing.Color.White;
            txtUserLastName.BackColor = System.Drawing.Color.Yellow;
            lblError.Text = "Please enter your Last Name.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else if (userID != "" && changePassword != "" && verifyPassword != "" && email != "" && firstName != "" && lastName != "")
        {//resets validation fields
            txtUserID.BackColor = System.Drawing.Color.White;
            txtUserChangePassword.BackColor = System.Drawing.Color.White;
            txtUserVerifyPassword.BackColor = System.Drawing.Color.White;
            txtUserEmail.BackColor = System.Drawing.Color.White;
            txtUserFirstName.BackColor = System.Drawing.Color.White;
            txtUserLastName.BackColor = System.Drawing.Color.White;
            lblError.Text = "";
            lblError.BackColor = System.Drawing.Color.White;

            try
            {
                MySqlCommand cmd;

                MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                conn.Open();

                string sqlStmt = "INSERT INTO CIS470_seniorproject.users (UserID, UserPW, UserEmail, UserFirstName, UserLastName, UserStartDt, UserPic) Values('" + userID + "','" + changePassword + "','" + email + "','" + firstName + "','" + lastName + "',NOW(),'" + pic + "');";

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

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        string userID = txtUserID.Text.Trim();

        Response.Redirect("~/frmDashboard.aspx?userID=" + userID);
    }
}