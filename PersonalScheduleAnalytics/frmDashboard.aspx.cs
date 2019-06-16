using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;


public partial class frmDashboard : System.Web.UI.Page
{
    clsDataLayer DataLayer;
    string username;

    const string SERVER = "localhost";
    const string DATABASE = "CIS470_seniorproject";
    const string UID = "SeniorProject";
    const string PWD = "password";
    int categoryID;
    string startDate;


    string connectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        startDate = DateTime.Today.ToString("yyyy/MM/dd");
        connectionString = @"Server=" + SERVER + @";Database=" + DATABASE + @";Uid=" + UID + @";Pwd=" + PWD;
        DataLayer = new clsDataLayer();
        username = Session["sessionUserID"].ToString();
        usernameLabel.InnerText = username;

        // TODO: move code in to this method
        //GetCategoryTypes();


        //loads categories
        clsDataLayer cls;

        if (!IsPostBack)
        {

            cls = new clsDataLayer();
            dropdownCategoryTypes.DataSource = cls.GetCategoryTypes((string)Session["sessionUserID"]);
            dropdownCategoryTypes.DataTextField = "CatName";
            dropdownCategoryTypes.DataValueField = "CatID";
            dropdownCategoryTypes.DataBind();
            dropdownCategoryTypes.Items.Insert(0, new ListItem("--Select Category--", "0"));
            getChartData(username);
        }
        else
        {

        }

    }


    protected void getChartData(string userID)
    {
        string startDate = (DateTime.Today.ToString("yyyy/MM/dd"));
        string endDate = (DateTime.Today.AddDays(1).ToString("yyyy/MM/dd"));

        string sqlStatement = "SELECT CAT.CatName AS Category, SUM(INS.CatDuration) " +
                              "AS Duration FROM users AS USR " +
                              "INNER JOIN categorytypes AS CAT ON USR.UserID = CAT.UserID " +
                              "INNER JOIN category_instance AS INS ON CAT.CategoryID = INS.CatID " +
                              "WHERE LOWER(USR.UserID) = LOWER(" + "'" + userID + "'" + ") " +
                              "AND CatShowHide IS NULL " +
                              "AND Displayable IS NULL " +
                              "AND INS.CatStartTm BETWEEN CAST(DATE_FORMAT('" + startDate + "', '%Y/%m/%d') AS DATE) AND  CAST(DATE_FORMAT('" + endDate + "', '%Y/%m/%d') AS DATE) " +
                              "AND INS.CatEndTm BETWEEN CAST(DATE_FORMAT('" + startDate + "', '%Y/%m/%d') AS DATE) AND CAST(DATE_FORMAT('" + endDate + "', '%Y/%m/%d') AS DATE) " +
                              "GROUP BY CAT.CatName; ";


        MySqlConnection conn = new MySqlConnection(connectionString);

        conn.Open();
        MySqlCommand command = conn.CreateCommand();
        command.CommandText = sqlStatement;
        MySqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows == true)
        {
            while (reader.Read())
            {
                Series series = Chart1.Series["Series1"];
                Chart1.ChartAreas[0].AxisY.Title = "Time Spent (in hours)";
                Chart1.ChartAreas[0].AxisX.Title = "Task Name";
                series.Points.Clear();
                series.Points.AddXY(reader["Category"].ToString(), Convert.ToDouble(reader["Duration"]));

                Console.WriteLine(reader);

            }

        }
        else
        {
            Chart1.Visible = false;
            statsLabel.InnerHtml = "No Stats to Display for " + DateTime.Now.ToString("MMMM dd, yyyy");
        }

    }


    protected void GetDayChartData(object sender, EventArgs e)
    {

        string thisStartDate;
        string newFormat;

        if (chartDateTextBox.Text == "")
        {
            thisStartDate = DateTime.Today.ToString("yyyy/MM/dd");
            newFormat = DateTime.ParseExact(thisStartDate, "yyyy/MM/dd", CultureInfo.InvariantCulture).ToString("MMMM dd, yyyy");
        }
        else
        {
            thisStartDate = chartDateTextBox.Text;
            newFormat = DateTime.ParseExact(thisStartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("MMMM dd, yyyy");
        }


        var tryEndDate = Convert.ToDateTime(startDate);

        string endDate = (tryEndDate.AddDays(1).ToString("yyyy/MM/dd"));

        


        string sqlStatement = "SELECT CAT.CatName AS Category, SUM(INS.CatDuration) " +
                              "AS Duration FROM users AS USR " +
                              "INNER JOIN categorytypes AS CAT ON USR.UserID = CAT.UserID " +
                              "INNER JOIN category_instance AS INS ON CAT.CategoryID = INS.CatID " +
                              "WHERE LOWER(USR.UserID) = LOWER(" + "'" + username + "'" + ") " +
                              "AND CatShowHide IS NULL " +
                              "AND Displayable IS NULL " +
                              "AND INS.CatStartTm BETWEEN CAST(DATE_FORMAT('" + thisStartDate + "', '%Y/%m/%d') AS DATE) AND  CAST(DATE_FORMAT('" + endDate + "', '%Y/%m/%d') AS DATE) " +
                              "AND INS.CatEndTm BETWEEN CAST(DATE_FORMAT('" + thisStartDate + "', '%Y/%m/%d') AS DATE) AND CAST(DATE_FORMAT('" + endDate + "', '%Y/%m/%d') AS DATE) " +
                              "GROUP BY CAT.CatName; ";


        MySqlConnection conn = new MySqlConnection(connectionString);
        Series series = Chart1.Series["Series1"];
        Chart1.ChartAreas[0].AxisY.Title = "Time Spent (in hours)";
        Chart1.ChartAreas[0].AxisX.Title = "Task Name";
        series.Points.Clear();
        conn.Open();
        MySqlCommand command = conn.CreateCommand();
        command.CommandText = sqlStatement;
        MySqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows == true)
        {
            statsLabel.InnerHtml = "Analytics for the day of " + newFormat;
            chartButtonGroup.Visible = true;
        }

        else
        {
            Chart1.Visible = false;
            statsLabel.InnerHtml = "No Stats to Display for " + newFormat;
        }

        while (reader.Read())
        {

            series.Points.AddXY(reader["Category"].ToString(), Convert.ToDouble(reader["Duration"]));


        }

    }

    protected void GetWeekChartData(object sender, EventArgs e)
    {
        string thisStartDate;

        if (chartDateTextBox.Text == "")
        {
            thisStartDate = DateTime.Today.ToString("yyyy-MM-dd");
        }
        else
        {
            thisStartDate = chartDateTextBox.Text;
        }

        var startDateAsDate = Convert.ToDateTime(thisStartDate);
        DateTime endDateAsDate;

        string newFormat = DateTime.ParseExact(thisStartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("MMMM dd, yyyy");

        //get day of week
        string dayOfTheWeek = startDateAsDate.DayOfWeek.ToString();

        switch (dayOfTheWeek)
        {
            case "Sunday":
                break;
            case "Monday":
                startDateAsDate = startDateAsDate.AddDays(-1);
                break;
            case "Tuesday":
                startDateAsDate = startDateAsDate.AddDays(-2);
                break;
            case "Wednesday":
                startDateAsDate = startDateAsDate.AddDays(-3);
                break;
            case "Thursday":
                startDateAsDate = startDateAsDate.AddDays(-4);
                break;
            case "Friday":
                startDateAsDate = startDateAsDate.AddDays(-5);
                break;
            case "Saturday":
                startDateAsDate = startDateAsDate.AddDays(-6);
                break;
            default:
                Console.WriteLine("WOOPS");
                break;
        }

        endDateAsDate = startDateAsDate.AddDays(7);

        string startDate = startDateAsDate.ToString("yyyy/MM/dd");
        string endDate = endDateAsDate.ToString("yyyy/MM/dd");


        string sqlStatement = "SELECT CAT.CatName AS Category, SUM(INS.CatDuration) " +
                              "AS Duration FROM users AS USR " +
                              "INNER JOIN categorytypes AS CAT ON USR.UserID = CAT.UserID " +
                              "INNER JOIN category_instance AS INS ON CAT.CategoryID = INS.CatID " +
                              "WHERE LOWER(USR.UserID) = LOWER(" + "'" + username + "'" + ") " +
                              "AND CatShowHide IS NULL " +
                              "AND Displayable IS NULL " +
                              "AND INS.CatStartTm BETWEEN CAST(DATE_FORMAT('" + startDate + "', '%Y/%m/%d') AS DATE) AND  CAST(DATE_FORMAT('" + endDate + "', '%Y/%m/%d') AS DATE) " +
                              "AND INS.CatEndTm BETWEEN CAST(DATE_FORMAT('" + startDate + "', '%Y/%m/%d') AS DATE) AND CAST(DATE_FORMAT('" + endDate + "', '%Y/%m/%d') AS DATE) " +
                              "GROUP BY CAT.CatName; ";


        MySqlConnection conn = new MySqlConnection(connectionString);

        conn.Open();
        MySqlCommand command = conn.CreateCommand();
        command.CommandText = sqlStatement;
        MySqlDataReader reader = command.ExecuteReader();
        Series series = Chart1.Series["Series1"];
        series.ChartType = SeriesChartType.Pie;
        Chart1.ChartAreas[0].AxisY.Title = "Time Spent (in hours)";
        Chart1.ChartAreas[0].AxisX.Title = "Task Name";
        series.Points.Clear();

        if (reader.HasRows == true)
        {
            statsLabel.InnerHtml = "Analytics for the Week of " + newFormat;
            chartButtonGroup.Visible = true;
        }
        else
        {
            Chart1.Visible = false;
            statsLabel.InnerHtml = "No Stats to Display for the week of " + newFormat;
        }
        while (reader.Read())
        {

            series.Points.AddXY(reader["Category"].ToString(), Convert.ToDouble(reader["Duration"]));

        }

    }

    protected void GetMonthChartData(object sender, EventArgs e)
    {

        string thisStartDate;

        if (chartDateTextBox.Text == "")
        {
            thisStartDate = DateTime.Today.ToString("yyyy/MM/dd");
        }
        else
        {
            thisStartDate = chartDateTextBox.Text;
        }

        var startDateAsDate = Convert.ToDateTime(thisStartDate);


        var firstDayOfMonth = new DateTime(startDateAsDate.Year, startDateAsDate.Month, 1);
        var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

        string firstDayOfMonthAsString = firstDayOfMonth.ToString("yyyy/MM/dd");
        string lastDayOfMonthAsString = lastDayOfMonth.ToString("yyyy/MM/dd");

        string statsMonth = firstDayOfMonth.ToString("y");

        string sqlStatement = "SELECT CAT.CatName AS Category, SUM(INS.CatDuration) " +
                              "AS Duration FROM users AS USR " +
                              "INNER JOIN categorytypes AS CAT ON USR.UserID = CAT.UserID " +
                              "INNER JOIN category_instance AS INS ON CAT.CategoryID = INS.CatID " +
                              "WHERE LOWER(USR.UserID) = LOWER(" + "'" + username + "'" + ") " +
                              "AND CatShowHide IS NULL " +
                              "AND Displayable IS NULL " +
                              "AND INS.CatStartTm BETWEEN CAST(DATE_FORMAT('" + firstDayOfMonthAsString + "', '%Y/%m/%d') AS DATE) AND  CAST(DATE_FORMAT('" + lastDayOfMonthAsString + "', '%Y/%m/%d') AS DATE) " +
                              "AND INS.CatEndTm BETWEEN CAST(DATE_FORMAT('" + firstDayOfMonthAsString + "', '%Y/%m/%d') AS DATE) AND CAST(DATE_FORMAT('" + lastDayOfMonthAsString + "', '%Y/%m/%d') AS DATE) " +
                              "GROUP BY CAT.CatName; ";


        MySqlConnection conn = new MySqlConnection(connectionString);
        Series series = Chart1.Series["Series1"];
        series.ChartType = SeriesChartType.Doughnut;
        Chart1.ChartAreas[0].AxisY.Title = "Time Spent (in hours)";
        Chart1.ChartAreas[0].AxisX.Title = "Task Name";
        series.Points.Clear();
        conn.Open();
        MySqlCommand command = conn.CreateCommand();
        command.CommandText = sqlStatement;
        MySqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows == true)
        {
            statsLabel.InnerHtml = "Analytics for the month of " + statsMonth;
            chartButtonGroup.Visible = true;
        }

        else
        {
            Chart1.Visible = false;
            statsLabel.InnerHtml = "No Stats to Display for month of " + statsMonth;
        }

        while (reader.Read())
        {

            series.Points.AddXY(reader["Category"].ToString(), Convert.ToDouble(reader["Duration"]));


        }
    }

    protected void GetCategoryTypes()
    {
        if (!IsPostBack)
        {
            clsDataLayer cls = new clsDataLayer();
            //DatacatInfo = cls.GetCategoryDetails( username);

            DataTable dt = cls.GetCategoryTypes(username);
            //dropdownCategoryTypes.Text =


            //ddlTeamLead.DataSource = cmd.ExecuteReader();
            dropdownCategoryTypes.DataSource = dt;
            dropdownCategoryTypes.DataTextField = "TeamLead";
            dropdownCategoryTypes.DataValueField = "TeamLead";
            //dropdownCategoryTypes.DataBind();
            //ddlTeamLead.DataBind();
        }
    }


    protected void submitNewCategoryTime(object sender, EventArgs e)
    {
        int catID;
        DateTime startDateTimeObject;
        DateTime endDateTimeObject;

        if (dropdownCategoryTypes.SelectedIndex == 0)
        {
            catMessageText.InnerHtml = "Please select a category";

        }
        else if (catStartTime.Text == "")
        {
            catMessageText.InnerHtml = "Please enter a start time";
        }
        else if (catEndTime.Text == "")
        {
            catMessageText.InnerHtml = "Please enter an end time";
        }
        if ((catID = dropdownCategoryTypes.SelectedIndex) != -1)
        {
            catID = dropdownCategoryTypes.SelectedIndex;

            string startDate = catStartDate.Text + ' ' + catStartTime.Text;
            startDateTimeObject = Convert.ToDateTime(startDate);

            string endDate = catEndDate.Text + ' ' + catEndTime.Text;
            endDateTimeObject = Convert.ToDateTime(endDate);

            clsDataLayer dataLayer = new clsDataLayer();

            dataLayer.InsertCategoryInstance(username, catID, startDateTimeObject, endDateTimeObject);
        }

        Response.Redirect("frmDashBoard.aspx");

    }

    //protected void ViewTimeAnalytics(object sender, EventArgs e)
    //{
    //    string viewAnalyticsBy = ddlTimeAnalytics.SelectedItem.Value;

    //    if(viewAnalyticsBy == "Day")
    //    {
    //        GetDayChartData();
    //        return;
    //    }
    //    if(viewAnalyticsBy == "Month")
    //    {
    //        GetMonthChartData();
    //        return;
    //    }
    //    if(viewAnalyticsBy == "Year")
    //    {
    //        GetYearChartData();
    //        return;
    //    }
    //}

    protected void LnkBtnUpdateUsers_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmUpdateUsers.aspx");
    }

    protected void LnkBtnUpdateCategories_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmEditCategory.aspx");
    }

    protected void LnkBtnUpdateTimeSheets_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmUpdateTimeSheets.aspx");
    }

    protected void LnkBtnExitApp_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmLoginPage.aspx");
    }

}

