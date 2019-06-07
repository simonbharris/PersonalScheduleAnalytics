using System;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;


public partial class frmUpdateTimeSheets : System.Web.UI.Page
{
    string connectionString = @"Server=localhost;Database=CIS470_seniorproject;Uid=SeniorProject;Pwd=password";
    string userID = null;
    string userName = null;
    string sheetStartDt = null;
    string sheetEndDt = null;
    string sheetMisc = null;
    string sheetNote = null;
    string sheetID = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Session["sessionUserID"] as string))
        {
            if (!this.IsPostBack)
            {
             userID = (Session["sessionUserID"] as string);

                //Name Data
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT DISTINCT CONCAT(USR.UserLastName, ', ', USR.UserFirstName) AS UserName, " +
                                        "DATE_ADD(CURDATE(), INTERVAL - WEEKDAY(CURDATE()) DAY) AS SheetStartDt, " +
                                        "CURDATE() + INTERVAL 7 - weekday(CURDATE()) DAY AS SheetEndDt, " +
                                        "TS.SheetMisc, TS.SheetNote, TS.SheetID " +
                                        "FROM users AS USR " +
                                        "INNER JOIN categorytypes AS CAT " +
                                        "ON USR.UserID = CAT.UserID " +
                                        "INNER JOIN timesheets AS TS " +
                                        "ON USR.UserID = TS.UserID " +
                                        "WHERE LOWER(USR.UserID) = LOWER('" + userID + "') AND USR.UserEndDt IS NULL AND CAT.Displayable IS NULL " +
                                        "AND TS.SheetStartDt BETWEEN DATE_ADD(CURDATE(), INTERVAL - WEEKDAY(CURDATE()) DAY) AND CURDATE() + INTERVAL 7 - weekday(CURDATE()) DAY " +
                                        "AND TS.SheetEndDt BETWEEN DATE_ADD(CURDATE(), INTERVAL - WEEKDAY(CURDATE()) DAY) AND CURDATE() + INTERVAL 7 - weekday(CURDATE()) DAY " +
                                        "ORDER BY TS.SheetStartDt " +
                                        "LIMIT 1;";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userName = Convert.ToString(reader["UserName"]);
                    sheetStartDt = Convert.ToString(reader["SheetStartDt"]);
                    sheetEndDt = Convert.ToString(reader["SheetEndDt"]);
                    sheetMisc = Convert.ToString(reader["SheetMisc"]);
                    sheetNote = Convert.ToString(reader["SheetNote"]);
                    sheetID = Convert.ToString(reader["SheetID"]);

                }
                reader.Close();
                txtUserName.Text = userName;
                txtSheetStartDt.Text = sheetStartDt;
                txtSheetEndDt.Text = sheetEndDt;
                txtSheetMisc.Text = sheetMisc;
                txtSheetNote.Text = sheetNote;
                connection.Close();

                if (sheetID == "")
                {
                    try
                    {
                        MySqlCommand cmd;
                        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                        conn.Open();
                        string sqlStmt = "INSERT INTO CIS470_seniorproject.timesheets "+ 
                                         "SELECT MAX(SheetID)+1 AS SheetID,'" + txtSheetMisc.Text + "' AS SheetMisc, '" + txtSheetNote.Text + "' AS SheetNote, DATE_ADD(CURDATE(), INTERVAL - WEEKDAY(CURDATE()) DAY) AS SheetStartDt, CURDATE() +INTERVAL 6 - weekday(CURDATE()) DAY AS SheetEndDt, '" + userID + "' AS UserID "+
                                         "FROM CIS470_seniorproject.timesheets; ";
                        cmd = new MySqlCommand(sqlStmt, conn);
                        cmd.ExecuteReader();
                        conn.Close();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.Write(ex);
                    }
                }

                //Fill Drop Down List
                    using (MySqlConnection con2 = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT CONCAT(USR.UserLastName, ', ', USR.UserFirstName) AS TeamLead FROM users AS USR WHERE LOWER(USR.UserID) != LOWER('" + userID + "') AND USR.UserEndDt IS NULL;"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con2;
                        con2.Open();
                        ddlTeamLead.DataSource = cmd.ExecuteReader();
                        ddlTeamLead.DataTextField = "TeamLead";
                        ddlTeamLead.DataValueField = "TeamLead";
                        ddlTeamLead.DataBind();
                        con2.Close();
                    }
                }
                ddlTeamLead.Items.Insert(0, new ListItem("--Select Customer--", "0"));

                //Work Description Data
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT CAT.CatName AS Category, CAT.CatDesc AS Description, DAYNAME(INS.CatStartTm) AS Day, SUM(INS.CatDuration) AS Hours " +
                                                                "FROM users AS USR INNER JOIN categorytypes AS CAT ON USR.UserID = CAT.UserID INNER JOIN timesheets AS TS ON USR.UserID = TS.UserID INNER JOIN category_instance AS INS ON CAT.CategoryID = INS.CatID " +
                                                                "WHERE LOWER(USR.UserID) = LOWER('" + userID + "') " +
                                                                "AND TS.SheetStartDt BETWEEN CAST(STR_TO_DATE('" + sheetStartDt + "', '%m/%d/%Y') AS DATE) AND CAST(STR_TO_DATE('" + sheetEndDt + "', '%m/%d/%Y') AS DATE) " +
                                                                "AND TS.SheetEndDt BETWEEN CAST(STR_TO_DATE('" + sheetStartDt + "', '%m/%d/%Y') AS DATE) AND CAST(STR_TO_DATE('" + sheetEndDt + "', '%m/%d/%Y') AS DATE) " +
                                                                "AND INS.CatStartTm BETWEEN CAST(STR_TO_DATE('" + sheetStartDt + "', '%m/%d/%Y') AS DATE) AND CAST(STR_TO_DATE('" + sheetEndDt + "', '%m/%d/%Y') AS DATE) " +
                                                                "AND INS.CatEndTm BETWEEN CAST(STR_TO_DATE('" + sheetStartDt + "', '%m/%d/%Y') AS DATE) AND CAST(STR_TO_DATE('" + sheetEndDt + "', '%m/%d/%Y') AS DATE) " +
                                                                "AND USR.UserEndDt IS NULL AND CAT.Displayable IS NULL AND INS.CatShowHide IS NULL GROUP BY CAT.CatName, CAT.CatDesc,DAYNAME(INS.CatStartTm) ORDER BY INS.CatStartTm;"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                gridWorkDescription.DataSource = dt;
                                gridWorkDescription.DataBind();
                            }
                        }
                    }
                }
            }

        }
        else
        {
            Response.Redirect("~/frmLoginPage.aspx?");
        }
    }

    protected void LnkBtnUpdate_Click(object sender, EventArgs e)
    {
        userID = (Session["sessionUserID"] as string);

        //Name Data
        MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT DISTINCT CONCAT(USR.UserLastName, ', ', USR.UserFirstName) AS UserName, " +
                                "DATE_ADD(CURDATE(), INTERVAL - WEEKDAY(CURDATE()) DAY) AS SheetStartDt, " +
                                "CURDATE() + INTERVAL 6 - weekday(CURDATE()) DAY AS SheetEndDt, " +
                                "TS.SheetMisc, TS.SheetNote, TS.SheetID " +
                                "FROM users AS USR " +
                                "INNER JOIN categorytypes AS CAT " +
                                "ON USR.UserID = CAT.UserID " +
                                "INNER JOIN timesheets AS TS " +
                                "ON USR.UserID = TS.UserID " +
                                "WHERE LOWER(USR.UserID) = LOWER('" + userID + "') AND USR.UserEndDt IS NULL AND CAT.Displayable IS NULL " +
                                "AND TS.SheetStartDt BETWEEN DATE_ADD(CURDATE(), INTERVAL - WEEKDAY(CURDATE()) DAY) AND CURDATE() + INTERVAL 7 - weekday(CURDATE()) DAY " +
                                "AND TS.SheetEndDt BETWEEN DATE_ADD(CURDATE(), INTERVAL - WEEKDAY(CURDATE()) DAY) AND CURDATE() + INTERVAL 7 - weekday(CURDATE()) DAY " +
                                "ORDER BY TS.SheetStartDt " +
                                "LIMIT 1;";
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            userName = Convert.ToString(reader["UserName"]);
            sheetStartDt = Convert.ToString(reader["SheetStartDt"]);
            sheetEndDt = Convert.ToString(reader["SheetEndDt"]);
            sheetMisc = Convert.ToString(reader["SheetMisc"]);
            sheetNote = Convert.ToString(reader["SheetNote"]);
            sheetID = Convert.ToString(reader["SheetID"]);

        }
        reader.Close();
        txtUserName.Text = userName;
        txtSheetStartDt.Text = sheetStartDt;
        txtSheetEndDt.Text = sheetEndDt;
        connection.Close();

        try
        {
            MySqlCommand cmd;
            MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();
            string sqlStmt = "UPDATE CIS470_seniorproject.timesheets SET SheetMisc = '" + txtSheetMisc.Text + "',SheetNote = '" + txtSheetNote.Text + "' " +
                             "WHERE LOWER(UserID) = LOWER('" + userID + "') " +
                             "AND SheetID = '" + sheetID + "';";
            cmd = new MySqlCommand(sqlStmt, conn);
            cmd.ExecuteReader();
            conn.Close();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Console.Write(ex);
        }
    }

    protected void LnkBtnPrint_Click(object sender, EventArgs e)
    {
        
    }

    protected void LnkBtnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void ddlTeamLead_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Populate Approved by based on Team Lead Selected
        txtApprovedBy.Text = ddlTeamLead.SelectedValue;
    }
    protected void txtSheetStartDt_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void txtSheetEndDt_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}