using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class frmDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Session["UserName"].ToString();
        usernameLabel.InnerText = username;
        GetDayChartData();
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

    protected void GetDayChartData()
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
}

