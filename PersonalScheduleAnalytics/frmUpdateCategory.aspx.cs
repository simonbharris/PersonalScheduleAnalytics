using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class frmUpdateCategories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsDataLayer cls = new clsDataLayer();
           Tuple<int, String, String> catInfo = cls.GetCategoryDetails(Int32.Parse(Session["UpdateCatID"].ToString()));

            DataTable dt = cls.GetCategoryTypes(Session["UserName"].ToString());
            txbxCatName.Text = catInfo.Item2;
            txbxCatDesc.Text = catInfo.Item3;
        }
    }

    protected void LnkBtnUpdate_Click(object sender, EventArgs e)
    {
        clsDataLayer cls = new clsDataLayer();
        cls.UpdateCategory(Int32.Parse(Session["UpdateCatID"].ToString()), txbxCatName.Text, txbxCatDesc.Text, "T");
        Response.Redirect("frmEditCategories.aspx");

    }

    protected void LnkBtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmEditCategories.aspx");
    }
}