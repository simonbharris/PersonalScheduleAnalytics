using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for clsDataLayer
/// Holds Connection strings to MYSQL
/// </summary>

public class clsDataLayer
{
    // Database connection settings
    const string SERVER =   "localhost";
    const string DATABASE = "CIS470_seniorproject";
    const string UID =      "SeniorProject";
    const string PWD =      "password";

    string connectionString;
    MySqlConnection conn;

    public clsDataLayer()
    {
        connectionString = @"Server=" + SERVER + @";Database=" + DATABASE + @";Uid=" + UID + @";Pwd=" + PWD;
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


    //Input: Username
    //Output: Datatable structure containing PK and CatName values from the CategoryTypes table, where the (UserID == username)
    //Purpose: To populate a ListBox for the user with the categories they have to pick from.
    public DataTable GetCategoryTypes(string username)
    {
        string sqlStatement =
            "SELECT CategoryID, CatName, CatDesc " +
            "FROM " + DATABASE + ".categorytypes " +
            "INNER JOIN users USING (UserID) " +
            "WHERE UserID = '" + username + "';";
        DataTable newTable = null;
        DataColumn column = null;

        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            newTable = new DataTable("CategoryTypes");
            column = new DataColumn("CatID", Type.GetType("System.Int32"));
            newTable.Columns.Add(column);
            column = new DataColumn("CatName", Type.GetType("System.String"));
            newTable.Columns.Add(column);
            column = new DataColumn("CatDesc", Type.GetType("System.String"));
            newTable.Columns.Add(column);

            while (reader.Read())
            {
                DataRow row = newTable.NewRow();
                row["CatID"] = reader.GetInt32(0);
                row["CatName"] = reader.IsDBNull(1) ? "" : reader.GetString(1);
                row["CatDesc"] = reader.IsDBNull(2) ? "" : reader.GetString(2);
                newTable.Rows.Add(row);
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            conn.Close();
        }
        return (newTable);
    }

    public Tuple<int, String, String> GetCategoryDetails(int id)
    {
        string sqlStatement = $"SELECT CategoryID, CatName, CatDesc FROM categoryTypes WHERE CategoryID = {id};";

        Tuple<int, String, String> tuple = null;
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            tuple = new Tuple<int, String, String>(reader.GetInt32(0), reader.GetString(1), 
                reader.IsDBNull(2) ? "" : reader.GetString(2));
        }
        catch (MySqlException ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            conn.Close();
        }
        System.Diagnostics.Debug.WriteLine(tuple);
        return (tuple);
    }

    public void UpdateCategory(int id, string name, string desc, string show)
    {
        string sqlStatement = 
            $"UPDATE CategoryTypes " +
            $"SET CatName = '{name}', CatDesc = '{desc}', displayable = '{show}' " +
            $"WHERE CategoryID = {id};";

        BasicNonQuery(sqlStatement);
    }

    public void AddCategory(string username, string catName, string catDesc)
    {
        string sqlStatement = $"INSERT INTO CategoryTypes(UserID, CatName, CatDesc, displayable) VALUES('{username}', '{catName}', '{catDesc}', 'T');";

        BasicNonQuery(sqlStatement);
    }

    public void BasicNonQuery(string query)
    {
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            conn.Close();
        }
    }

    public void DeleteCategory(int id)
    {
        string sqlStatement = $"DELETE FROM CategoryTypes " +
            $"WHERE CategoryID = {id};";

        BasicNonQuery(sqlStatement);
    }
}