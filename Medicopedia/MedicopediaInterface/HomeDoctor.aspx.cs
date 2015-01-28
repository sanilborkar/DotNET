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
using BusinessClassLayer;

namespace MedicopediaInterface
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        string connString = ConfigurationManager.AppSettings.Get("connString");
        string buttonClicked = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] != null)
                    lblUserName.Text = Session["username"].ToString();

                LoadWorklist();
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }

        }


        private void LoadWorklist()
        {
            int userId;
            if (Session["userId"] != null)
            {
                userId = int.Parse(Session["userId"].ToString());

                BusinessLayer busObj = new BusinessLayer();
                gvWorklist.DataSource = busObj.LoadWorklist(userId, connString);
                gvWorklist.DataBind();
            }
 


        }


        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session["username"] = "Guest";
            Session["role"] = "Guest";
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        protected void gvTop10_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvTop10.SelectedRow;
            Session["queryId"] = row.Cells[0].Text;

            if (buttonClicked.Equals("Vote"))
            {
                Response.Redirect("Vote.aspx");
            }
            else if (buttonClicked.Equals("Comment"))
            {
                Response.Redirect("Comment.aspx");
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            buttonClicked = "Vote";
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            buttonClicked = "Comment";
        }

        protected void gvWorklist_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int queryId = int.Parse(gvWorklist.Rows[e.NewSelectedIndex].Cells[0].Text);

            Session["queryId"] = queryId;
            Response.Redirect("SubmitAdvice.aspx");

        }


    }
}

