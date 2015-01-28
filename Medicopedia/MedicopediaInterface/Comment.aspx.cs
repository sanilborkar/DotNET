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
using DomainClassLayer;


namespace MedicopediaInterface
{
    public partial class Comment : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connString");


        protected void Page_Load(object sender, EventArgs e)
        {
            ClearData();

            if(Session["adviceCommentTitle"] != null)
                txtDescription.Text = Session["adviceCommentTitle"].ToString();

            if (Session["username"] != null && Session["username"].ToString().Equals("Guest"))
                LinkButton1.Visible = false;

            if (Session["username"] != null)
                lblUserName.Text = Session["username"].ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["username"] = "Guest";
            Session["role"] = "Guest";
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }
         

     private void ClearData()
    {
        txtComment.Text = string.Empty;
        txtDescription.Text = string.Empty;
    }



       

        protected void btnComment_Click(object sender, EventArgs e)
        {
            try
            {
                string comments = txtComment.Text;
                int adviceId = int.Parse(Session["itemId"].ToString());
                int userId = int.Parse(Session["userId"].ToString());

                BusinessLayer busObj = new BusinessLayer();
                busObj.AddComment(adviceId, comments, userId, connectionString);

                ClearData();
                //Response.Redirect("Home.aspx");
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            Response.Redirect("Home.aspx");
        }

    }
}
