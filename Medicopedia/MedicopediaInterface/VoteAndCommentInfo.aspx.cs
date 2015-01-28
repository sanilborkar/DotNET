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
    public partial class  VoteAndCommentInfo: System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connString");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                lblUserName.Text = Session["username"].ToString();

            if (Session["username"] != null && Session["username"].ToString().Equals("Guest"))
                LinkButton1.Visible = false;

            lblXMLSuccess.Text = string.Empty;

            if (!IsPostBack)
            {
                try
                {
                    LoadData();
                }
                catch
                {
                    //Response.Redirect("ErrorPage.aspx");
                }
            }
        }


        public void LoadData()
        {
            try
            {
                int itemId = 0;
                if (Session["itemId"] != null)
                    itemId = int.Parse(Session["itemId"].ToString());

                lblAdviceId.Text = itemId.ToString();

                BusinessLayer businessObj = new BusinessLayer();
                ArrayList itemList = businessObj.LoadVoteData(itemId, connectionString);

                Items reqdItem = (Items)itemList[0];
                ArrayList comments = (ArrayList)itemList[1];

                lblAdviceName.Text = reqdItem.ItemName;
                lblPosVotes.Text = reqdItem.PositiveVotes.ToString();
                lblNegVotes.Text = reqdItem.NegativeVotes.ToString();


                RepComments.DataSource = comments;
                RepComments.DataBind();
                //this.DataBind();               
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }

        }


        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void lnkXML_Click(object sender, EventArgs e)
        {
            try
            {
                int itemId = int.Parse(Session["itemId"].ToString());

                BusinessLayer businessObj = new BusinessLayer();
                DataSet dsXML = businessObj.LoadXMLVoteData(itemId, connectionString);
                dsXML.WriteXml(@"D:\VoteAndCommentInfo.xml", XmlWriteMode.WriteSchema);
                lblXMLSuccess.Text = "File Successfully Downloaded (in your D: drive)";
            }
            catch
            {
                lblXMLSuccess.Text = "Error in file download. Please try again later.";
                //Response.Redirect("ErrorPage.aspx");
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["username"] = "Guest";
            Session["role"] = "Guest";
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }


    }
}
