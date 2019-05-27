using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for clsDataLayer
/// Holds Connection strings to MYSQL
/// </summary>
public class clsDataLayer
{
    string connectionString;
    MySqlConnection conn;

    public clsDataLayer()
    {
        connectionString = @"Server=localhost;Database=CIS470_seniorproject;Uid=SeniorProject;Pwd=password";
        conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
    }

    public void UserLogin(string username, string password)
    {
        if (username != "" && password != "")
        {
            try
            {
                conn.Open();
                // todo: handle login
                // once logged in use a response.redirect


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex);
            }
        }
    }

    public bool ValidateUser(string username, string password)
    {
        bool isUserVerified = false;
        conn.Open();

        string sqlStatement = "SELECT * FROM cis470_seniorproject.users WHERE UserID = '" + username +"' AND  UserPW = '" +password + "';";

        MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
        MySqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            if(reader.HasRows)
            {
                // if both credentials provided exist, set bool value to true
                isUserVerified = true;
            }
            else
            {
                // if credentials are not accurate, set to false
                isUserVerified = false;
            }
        }
        // return bool  value
        conn.Close();
        return isUserVerified;

    }
}