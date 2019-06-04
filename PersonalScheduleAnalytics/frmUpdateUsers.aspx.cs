using System;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class frmUpdateUsers : System.Web.UI.Page
{
    string connectionString = @"Server=localhost;Database=CIS470_seniorproject;Uid=SeniorProject;Pwd=password";
    string userID = null; 
    string firstName = null;
    string lastName = null;
    string email = null;
    string password = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Session["sessionUserID"] as string))
        {
            txtUserID.Text = (Session["sessionUserID"] as string);
            userID = txtUserID.Text;
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT UserFirstName, UserLastName, UserEmail, UserPW FROM cis470_seniorproject.users WHERE LOWER(UserID) = LOWER('" + userID + "')AND UserEndDt IS NULL;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                firstName = Convert.ToString(reader["UserFirstName"]);
                lastName = Convert.ToString(reader["UserLastName"]);
                email = Convert.ToString(reader["UserEmail"]);
                password = Convert.ToString(reader["UserPW"]);
            }
            reader.Close();
            }
        else
        {
            Response.Redirect("~/frmLoginPage.aspx?");
        }
    }
    protected void BtnUserUpdate_Click(object sender, EventArgs e)
    {
        string changePassword = txtUserChangePassword.Text.Trim();
        string verifyPassword = txtUserVerifyPassword.Text.Trim();
        string changeFirstName = txtUserFirstName.Text.Trim();
        string changeLastName = txtUserLastName.Text.Trim();
        string changeEmail = txtUserEmail.Text.Trim();

        //Start Password Change
        if (changePassword != "")
        {
            if (changePassword != password)
            {
                if (verifyPassword == "")
                {
                    txtUserChangePassword.BackColor = System.Drawing.Color.White;
                    txtUserVerifyPassword.BackColor = System.Drawing.Color.Yellow;
                    lblError.Text = "Please verify your Password.";
                    lblError.BackColor = System.Drawing.Color.Red;
                }
                else if (changePassword != verifyPassword)
                {
                    txtUserChangePassword.BackColor = System.Drawing.Color.Yellow;
                    txtUserVerifyPassword.BackColor = System.Drawing.Color.Yellow;
                    lblError.Text = "Password and Password Verification must be the same.";
                    lblError.BackColor = System.Drawing.Color.Red;
                }
                else if (changePassword != "" && verifyPassword != "")
                {
                    txtUserChangePassword.BackColor = System.Drawing.Color.White;
                    txtUserVerifyPassword.BackColor = System.Drawing.Color.White;
                    lblError.Text = "";
                    lblError.BackColor = System.Drawing.Color.White;
                    try
                    {
                        MySqlCommand cmd;
                        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                        conn.Open();
                        string sqlStmt = "UPDATE CIS470_seniorproject.users SET UserPW = '" + changePassword + "' WHERE LOWER(UserID) = LOWER('" + userID + "')AND UserEndDt IS NULL;";
                        cmd = new MySqlCommand(sqlStmt, conn);
                        cmd.ExecuteReader();
                        conn.Close();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.Write(ex);
                    }
                    Response.Redirect("~/frmUpdateUsers.aspx?userID=" + userID);
                }
            }
        }
        else if (changePassword == "" && verifyPassword != "")
        {
            txtUserChangePassword.BackColor = System.Drawing.Color.Yellow;
            txtUserVerifyPassword.BackColor = System.Drawing.Color.White;
            lblError.Text = "Please enter your new Password.";
            lblError.BackColor = System.Drawing.Color.Red;
        }
     //start name and email changes
        else if (changePassword == "" && verifyPassword == "" && changeFirstName != "" || changeLastName != "" || changeEmail != "")
        {
            try
            {
                MySqlCommand cmd;
                MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                conn.Open();
                string sqlStmt = "UPDATE cis470_seniorproject.users SET UserFirstName = IF('" + changeFirstName + "' ='' ,UserFirstName,'" + changeFirstName + "'),UserLastName = IF('" + changeLastName + "' ='' ,UserLastName,'" + changeLastName + "'),UserEmail = IF('" + changeEmail + "' ='' ,UserEmail,'" + changeEmail + "')WHERE LOWER(UserID) = LOWER('" + userID + "')AND UserEndDt IS NULL;";
                cmd = new MySqlCommand(sqlStmt, conn);
                cmd.ExecuteReader();
                conn.Close();
            }
                catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex);
            }
            Response.Redirect("~/frmUpdateUsers.aspx?userID=" + userID);
        }
     //start UserPic Change
        else if (changePassword == "" && verifyPassword == "" && changeFirstName == "" && changeLastName == "" && changeEmail == "" && changeEmail == "")
        {
            Response.Redirect("~/frmUpdateUsers.aspx?userID=" + userID);
        }
    }

    protected void BtnUserPicUpdate_Click(object sender, EventArgs e)
    {
        FileUpload changePic = (FileUpload)imgUserPic;

        try
        {
            MySqlCommand cmd;
            MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();
            string sqlStmt = "UPDATE cis470_seniorproject.users SET UserPic = '" + changePic + "' WHERE LOWER(UserID) = LOWER('" + userID + "')AND UserEndDt IS NULL;";
            cmd = new MySqlCommand(sqlStmt, conn);
            cmd.ExecuteReader();
            conn.Close();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Console.Write(ex);
        }
        Response.Redirect("~/frmUpdateUsers.aspx?userID=" + userID);
    }

        protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/frmDashboard.aspx?userID=" + userID);
    }
}