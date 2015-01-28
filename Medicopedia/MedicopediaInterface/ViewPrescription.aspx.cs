using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient ;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using BusinessClassLayer;


namespace MedicopediaInterface
{
    public partial class ViewPrescription : System.Web.UI.Page
    {
        private string connString = ConfigurationManager.AppSettings.Get("connString");

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["username"] = "Guest";
            Session["role"] = "Guest";
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] != null)
                    lblUserName.Text = Session["username"].ToString();

                if (Session["username"] != null && Session["username"].ToString().Equals("Guest"))
                    LinkButton1.Visible = false;

                if (Session["username"] != null && Session["role"].ToString().Equals("Guest"))
                {
                    LinkButton1.Visible = false;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    BusinessLayer businessObj = new BusinessLayer();
                    GridView1.DataSource = businessObj.ViewPrescriptions(connString);
                    GridView1.DataBind();
                }
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }
            

        }
    }
}
