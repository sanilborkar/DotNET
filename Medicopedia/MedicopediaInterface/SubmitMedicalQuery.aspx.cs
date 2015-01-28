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
using BusinessClassLayer;
using DomainClassLayer;


namespace MedicopediaInterface
{
    public partial class SubmitMedicalQuery : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connString");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                lblUserName1.Text = Session["username"].ToString();

            if (Session["username"] != null && Session["role"].ToString().Equals("Guest"))
            {
                LinkButton1.Visible = false;
                Response.Redirect("Home.aspx");
            }

            if (Session["username"] != null)
            {
                txtUserName.Text = Session["username"].ToString();
                txtUserName.Enabled = false;
            }
        }

        public void ClearData()
        {

            txtUserName.Text = string.Empty;
            txtQueryTitle.Text = string.Empty;
            txtDisease.Text = string.Empty;
            txtSymptoms.Text = string.Empty;
            txtEarlierRecords.Text = string.Empty;

        }

        public void InsertQuery()
        {

            string queryStatus = "Pending";

            try
            {
                Query newQuery = new Query();
                newQuery.UserDetails = int.Parse(Session["userId"].ToString());
                newQuery.QueryTitle = txtQueryTitle.Text;
                newQuery.Disease = txtDisease.Text;
                newQuery.Symptoms = txtSymptoms.Text;
                newQuery.History = txtEarlierRecords.Text;
                newQuery.Status = queryStatus;

                BusinessLayer busObj = new BusinessLayer();
                busObj.InsertQuery(newQuery, connectionString);
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                InsertQuery();
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }
            finally
            {
                ClearData();
                Response.Redirect("HomeUser.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["username"] = "Guest";
            Session["role"] = "Guest";
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            Response.Redirect("Home.aspx");
        }
    }
}








