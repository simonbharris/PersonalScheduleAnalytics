using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class frmLoginPage : System.Web.UI.Page
{
    clsDataLayer DataLayer;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer = new clsDataLayer();
    }

    protected void LnkBtnUserLogin_Click(object sender, EventArgs e)
    {
        string username = txtUserID.Text;
        string password = txtUserPassword.Text;

        //todo: check if txtUserID and txtUserPassword is blank/null


        // validate the provided credentials 
        bool isUserVerified = DataLayer.ValidateUser(username, password);

        if (isUserVerified)
        {
            // log user in if user is verified
            DataLayer.UserLogin(username, password);
        }
        else
        {
            //todo: handle the case where the login credentials do not match what's in database
        }
        
        

    }

    protected void LnkBtnUserCreate_Click(object sender, EventArgs e)
    {
  
    }

}