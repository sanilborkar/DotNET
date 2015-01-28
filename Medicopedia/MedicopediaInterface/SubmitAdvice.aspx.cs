using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    public partial class WebForm10 : System.Web.UI.Page
    {
        string userId = string.Empty;
        string connString = ConfigurationManager.AppSettings.Get("connString");

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["username"] = "Guest";
            Session["role"] = "Guest";
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtAdvice.Enabled = true;
            gvSpecialists.Visible = false;

            if (Session["username"] != null)
                lblUserName.Text = Session["username"].ToString();

            if (Session["queryId"] != null)
                lblQueryId.Text = Session["queryId"].ToString();

            if (Session["username"] != null)
                lblAdviceBy.Text = Session["username"].ToString();

            if (Session["userId"] != null)
                userId = Session["userId"].ToString();

            if (Session["username"] != null && Session["role"].ToString().Equals("Guest"))
            {
                LinkButton1.Visible = false;
                Response.Redirect("Home.aspx");
            }
 
        }

        public void InsertAdvice(string status)
        {
            try
            {
                ArrayList queryDetails = new ArrayList();
                queryDetails.Add(int.Parse(lblQueryId.Text));
                queryDetails.Add(Session["userId"].ToString());
                queryDetails.Add(txtAdvice.Text);
                queryDetails.Add(status);

                BusinessLayer businessObj = new BusinessLayer();
                businessObj.InsertAdvice(queryDetails, connString);
 

            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx"); 
            }
                
        }

                        
         
        

        public void LoadSpecialists()
        {

            try
            {
                BusinessLayer businessObj = new BusinessLayer();
                gvSpecialists.DataSource = businessObj.LoadSpecialists(connString);
                gvSpecialists.DataBind();
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx"); 
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string status = "Resolved";
                if (chkStatus.Checked.ToString().Equals("Need more info"))
                {
                    status = chkStatus.Text;
                }

                InsertAdvice(status);
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }
            finally
            {
                Cleartext();
            }
        }
        public void Cleartext()
        {
            lblQueryId.Text = "";
            txtAdvice.Text = "";
            lblAdviceBy.Text = "";
            chkStatus.Checked = false;
        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            try
            {
                txtAdvice.Enabled = false;

                LoadSpecialists();

                gvSpecialists.Visible = true;
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }
        }


    

        protected void gvSpecialists_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvSpecialists.SelectedRow;
                int docId = int.Parse(row.Cells[0].Text);
                int userid = int.Parse(Session["userId"].ToString());

                BusinessLayer busObj = new BusinessLayer();
                busObj.AddToWorklist(userid, int.Parse(lblQueryId.Text), docId, connString);
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }
        }
        


       
        
    }
}
