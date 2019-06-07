using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class frmAddCategories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LnkBtnAdd_Click(object sender, EventArgs e)
    {
        clsDataLayer cls = new clsDataLayer();
        cls.AddCategory(Session["sessionUserID"].ToString(), txbxCatName.Text, txbxCatDesc.Text);
        Response.Redirect("frmEditCategories.aspx");

    }

    protected void LnkBtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmEditCategories.aspx");
    }
}