using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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


    string connectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        connectionString = @"Server=" + SERVER + @";Database=" + DATABASE + @";Uid=" + UID + @";Pwd=" + PWD;
        DataLayer = new clsDataLayer();
        username = Session["sessionUserID"].ToString();
        usernameLabel.InnerText = username;
        GetDayChartData();

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
        }
        getChartData(username);
    }


    protected void getChartData(string userID)
    {
        DateTime startDate = DateTime.Today;
        DateTime endDate = DateTime.Today;


        string sqlStatement = "SELECT CAT.CatName AS Category, SUM(INS.CatDuration) AS Duration" +
            " FROM users AS USR" +
            " INNER JOIN categorytypes AS CAT ON USR.UserID = CAT.UserID" +
            " INNER JOIN category_instance AS INS ON CAT.CategoryID = INS.CatID" +
            " WHERE LOWER(USR.UserID) = LOWER('" + userID + "')" +
            " AND INS.CatStartTm BETWEEN" +
            " CAST(DATE_FORMAT('" + startDate + "', '%Y/%m/%d') AS DATE) AND " +
            " CAST(DATE_FORMAT('" + endDate + "', '%Y/%m/%d') AS DATE)" +
            " AND INS.CatEndTm BETWEEN" +
            " CAST(DATE_FORMAT('" + startDate + "', '%Y/%m/%d') AS DATE AND" +
            " CAST(DATE_FORMAT('" + endDate + "', '%Y/%m/%d') AS DATE)" +
            " GROUP BY CAT.CatName; ";


        MySqlConnection conn = new MySqlConnection(connectionString);
        Series series = Chart1.Series["Series1"];
        conn.Open();
        MySqlCommand command = conn.CreateCommand();
        command.CommandText = sqlStatement;
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader);
        }



        series.ChartType = SeriesChartType.Bar;
        series.Points.Clear();
        series.Points.AddXY("lounge", 6);
        series.Points.AddXY("work", 1);
        series.Points.AddXY("rest", 4);
        series.Points.AddXY("swim", 7);
        series.Points.AddXY("tetris", 2);
    }

    protected void LnkBtnUpdateUsers_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmEditCategories.aspx");
    }

    protected void LnkBtnUpdateCategories_Click(object sender, EventArgs e)
    {

    }

    protected void LnkBtnUpdateTimeSheets_Click(object sender, EventArgs e)
    {

    }

    protected void LnkBtnExitApp_Click(object sender, EventArgs e)
    {

    }


    protected void GetWeekChartData(object sender, EventArgs e)
    {
        Series series = Chart1.Series["Series1"];
        series.ChartType = SeriesChartType.Pie;
        series.Points.Clear();
        series.Points.AddXY("Sleep", 12);
        series.Points.AddXY("Eat", 15);
        series.Points.AddXY("Code", 35);
        series.Points.AddXY("Beer", 28);
        series.Points.AddXY("Pet Cat", 10);
    }

    protected void GetDayChartData(object sender, EventArgs e)
    {
        Series series = Chart1.Series["Series1"];
        series.ChartType = SeriesChartType.Bar;
        series.Points.Clear();
        series.Points.AddXY("lounge", 6);
        series.Points.AddXY("work", 1);
        series.Points.AddXY("rest", 4);
        series.Points.AddXY("swim", 7);
        series.Points.AddXY("tetris", 2);

    }

    protected void GetMonthChartData(object sender, EventArgs e)
    {
        Series series = Chart1.Series["Series1"];
        series.ChartType = SeriesChartType.Bar;
        series.Points.Clear();
        series.Points.AddXY("Sleep", 6);
        series.Points.AddXY("Eat", 1);
        series.Points.AddXY("Code", 4);
        series.Points.AddXY("Beer", 7);
        series.Points.AddXY("Pet Cat", 2);
    }

    protected void GetYearChartData()
    {
        Series series = Chart1.Series["Series1"];
        series.ChartType = SeriesChartType.Bar;
        series.Points.Clear();
        series.Points.AddXY("lounge", 6);
        series.Points.AddXY("work", 1);
        series.Points.AddXY("rest", 4);
        series.Points.AddXY("swim", 7);
        series.Points.AddXY("tetris", 2);
    }

    protected void GetMonthChartData()
    {
        Series series = Chart1.Series["Series1"];
        series.ChartType = SeriesChartType.Bar;
        series.Points.Clear();
        series.Points.AddXY("Sleep", 6);
        series.Points.AddXY("Eat", 1);
        series.Points.AddXY("Code", 4);
        series.Points.AddXY("Beer", 7);
        series.Points.AddXY("Pet Cat", 2);
    }

    protected void GetDayChartData()
    {
        Series series = Chart1.Series["Series1"];
        series.ChartType = SeriesChartType.Bar;
        series.Points.Clear();
        series.Points.AddXY("lounge", 6);
        series.Points.AddXY("work", 1);
        series.Points.AddXY("rest", 4);
        series.Points.AddXY("swim", 7);
        series.Points.AddXY("tetris", 2);

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
}

