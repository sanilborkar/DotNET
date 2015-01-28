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
    public partial class HomeUser : System.Web.UI.Page
    {
        public string buttonClicked = string.Empty;
        private string itemDescription = string.Empty;
        private string connString = ConfigurationManager.AppSettings.Get("connString");

        public string ItemDescription
        {
            get { return itemDescription; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"] != null)
                lblUserName.Text = Session["username"].ToString();

            LoadTop10Grid();

        }



        private void LoadTop10Grid()
        {
            BusinessLayer busObj = new BusinessLayer();
            gvTop10.DataSource = busObj.LoadTop10Grid(connString);
            gvTop10.DataBind();
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
            try
            {
                GridViewRow row = gvTop10.SelectedRow;
                Session["itemId"] = row.Cells[0].Text;


                if (buttonClicked.Equals("Vote"))
                {
                    Response.Redirect("Vote.aspx");
                }
                else if (buttonClicked.Equals("Comment"))
                {
                    Session["adviceCommentTitle"] = row.Cells[1].Text;
                    Response.Redirect("Comment.aspx");

                }
                else if (buttonClicked.Equals("Info"))
                {
                    Response.Redirect("VoteAndCommentInfo.aspx");
                }
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }

        }



        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            buttonClicked = "Vote";

        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            buttonClicked = "Comment";
        }

        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            buttonClicked = "Info";
        }



    }

        



  

    }

