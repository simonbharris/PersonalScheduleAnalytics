using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Session["sessionUserID"] as string))
        {
            TextBox1.Text = (Session["sessionUserID"] as string);
        }
        else
        {
            Response.Redirect("~/frmLoginPage.aspx?");
        }
    }

    protected void LnkBtnUpdateUsers_Click(object sender, EventArgs e)
    {

    }

    protected void LnkBtnUpdateCategories_Click(object sender, EventArgs e)
    {

    }

    protected void LnkBtnUpdateTimeSheets_Click(object sender, EventArgs e)
    {

    }

    protected void LnkBtnExitApp_Click(object sender, EventArgs e)
    {
        Session.Remove("sessionUserID");
        Session.Clear();
        Session.Abandon();
        Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
        Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
        Response.Redirect("~/frmLoginPage.aspx?");
    }
}