using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using DomainClassLayer;
using BusinessClassLayer;

namespace MedicopediaInterface
{
    public partial class Login : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connString");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            { 
                if(!Session["username"].ToString().Equals("Guest"))
                    Response.Redirect("Home.aspx");
                else
                    lblUserName1.Text = Session["username"].ToString();
            }

            if (Session["MaxAttempts"].ToString().Equals(Session["Attempts"].ToString()))
            {
                lblmsg.Text = "Your login attempts have crossed the accepted limits. Try logging in again.";
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            string userEmail = txtUserName.Text;
            string password = txtPassword.Text;
            string role = string.Empty;

            if (ddlRole.SelectedValue.ToString().Equals("User"))
            {
                role = "Users";
            }
            else
            {
                role = ddlRole.SelectedValue.ToString();
            }

            try
            {
                BusinessLayer businessObj = new BusinessLayer();
                Users authenticatedUser = businessObj.ValidateUserPass(userEmail, password, role, connectionString);
                if (authenticatedUser != null)
                {
                    Session["username"] = authenticatedUser.Name.Trim();
                    Session["role"] = authenticatedUser.Role.Trim();
                    Session["userId"] = authenticatedUser.UserId;
                    FormsAuthentication.RedirectFromLoginPage(userEmail, false);
                }
                else
                {
                    lblmsg.Text = "Login failed. Try again.";
                }
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }
       
    }
    


}

        }

