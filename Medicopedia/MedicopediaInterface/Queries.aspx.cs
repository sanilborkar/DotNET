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

namespace MedicopediaInterface
{
    public partial class Queries : System.Web.UI.Page
    {
        private TextBox txtQueryTitle;
        private string buttonClicked = string.Empty;

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["username"] = "Guest";
            Session["role"] = "Guest";
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
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
        }  




        protected void btnPrescribe_Click(object sender, EventArgs e)
        {
            buttonClicked = "Prescribe";
        }

        protected void btnAdvise_Click(object sender, EventArgs e)
        {
            buttonClicked = "Advise";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.SelectedRow;
                txtQueryTitle = new TextBox();
                txtQueryTitle.Text = row.Cells[1].Text;
                Session["queryTitle"] = row.Cells[1].Text;
                Session["queryId"] = row.Cells[0].Text;

                if (buttonClicked.Equals("Prescribe"))
                    Response.Redirect("Prescribe.aspx");
                else if (buttonClicked.Equals("Advise"))
                    Response.Redirect("SubmitAdvice.aspx");
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }

        }











        

       

    }
}
