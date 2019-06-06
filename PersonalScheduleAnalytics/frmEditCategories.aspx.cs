using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmEditCategories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsDataLayer cdl;
        if (!IsPostBack)
        {
            cdl = new clsDataLayer();
            lstCategoryNames.DataSource = cdl.GetCategoryTypes((string)Session["UserName"]);
            lstCategoryNames.DataTextField = "CatName";
            lstCategoryNames.DataValueField = "CatID";
            lstCategoryNames.DataBind();
        }
    }

    protected void LnkBtnAdd_Click(object sender, EventArgs e)
    {

    }

    protected void LnkBtnUpdate_Click(object sender, EventArgs e)
    {
        if (lstCategoryNames.SelectedIndex > -1)
        {
            Session["UpdateCatID"] = lstCategoryNames.SelectedValue;
            Response.Redirect("frmUpdateCategory.aspx");
        }
    }

    protected void LnkBtnCancel_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void lnkBtnDelete_Click(object sender, EventArgs e)
    {
        if (lstCategoryNames.SelectedIndex >= 0)
        {
            clsDataLayer cls = new clsDataLayer();
            cls.DeleteCategory(Int32.Parse(lstCategoryNames.SelectedValue));
            Response.Redirect("frmEditCategories.aspx");
        }
    }
}