using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using MedicopediaInterface;
using BusinessClassLayer;


namespace MedicopediaInterface
{
    public partial class Prescribe : System.Web.UI.Page
    {
        
        string connectionString = ConfigurationManager.AppSettings.Get("connString");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                lblUserName.Text = Session["username"].ToString();

            if (Session["username"] != null && Session["role"].ToString().Equals("Guest"))
                LinkButton1.Text = string.Empty;

            if(Session["queryTitle"] != null)
                txtQuery.Text = Session["queryTitle"].ToString();

            if (Session["username"] != null && Session["role"].ToString().Equals("Guest"))
            {
                LinkButton1.Visible = false;
                Response.Redirect("Home.aspx");
            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["username"] = "Guest";
            Session["role"] = "Guest";
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        public void ClearData()
        {
            txtQuery.Text = string.Empty;
            txtPrescribe.Text = string.Empty;
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                Session["querytitle"] = txtQuery.Text;
                Session["prescription"] = txtPrescribe.Text;

                int presId = int.Parse(Session["userId"].ToString());
                string presDescription = txtPrescribe.Text;
                int queryId = int.Parse(Session["queryId"].ToString());

                BusinessLayer busObj = new BusinessLayer();
                busObj.InsertPrescription(presId, presDescription, queryId, connectionString);


            }
            catch
            {
                throw;
            }
            finally
            {
                ClearData();
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            Response.Redirect("Queries.aspx");
        }

    }  

}
