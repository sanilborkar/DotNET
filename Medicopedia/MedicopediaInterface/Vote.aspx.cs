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
using System.Collections.Specialized;
using BusinessClassLayer;
using DomainClassLayer;


namespace MedicopediaInterface
{
    public partial class Vote : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connString");
        string vote = string.Empty;

        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["username"] = "Guest";
            Session["role"] = "Guest";
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;
            btnVoteFor.Enabled = true;
            btnVoteAgainst.Enabled = true;

            string itemId = string.Empty;
            if(Session["itemId"] != null)
                itemId = Session["itemId"].ToString();

            if (Session["username"] != null)
                lblUserName.Text = Session["username"].ToString();

            if (Session["username"] != null && Session["username"].ToString().Equals("Guest"))
                LinkButton1.Visible = false;

            
            if (Request.Cookies["Vote"] == null)
            {
                
                btnVoteFor.Enabled = true;
                btnVoteAgainst.Enabled = true;
            }
            else
            {
                NameValueCollection obj = Request.Cookies["Vote"].Values;

                if (Session["userId"] != null)
                {
                    string cookieString = Session["userId"].ToString() + "Y";
                    if (obj[cookieString] != null && obj[cookieString].ToString().Equals(cookieString))
                    {

                        btnVoteFor.Enabled = false;
                        btnVoteAgainst.Enabled = false;
                        lblMsg.Text = "You have already voted for this item.";
                    }
                }
            }

            if (!IsPostBack)
            {
                try
                {
                    LoadData();
                    //btnVoteAgainst.Enabled = true;
                    //btnVoteFor.Enabled = true;
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
                int itemId = int.Parse(Session["itemId"].ToString());
                lblAdviceId.Text = itemId.ToString();

                BusinessLayer businessObj = new BusinessLayer();
                ArrayList itemList = businessObj.LoadVoteData(itemId, connectionString);

                Items reqdItem = (Items)itemList[0];
                ArrayList comments = (ArrayList)itemList[1];

                txtQueryTitle.Text = reqdItem.ItemName;
                txtNoPositiveVotes.Text = reqdItem.PositiveVotes.ToString();
                txtNoOfNegativeVote.Text = reqdItem.NegativeVotes.ToString();


                RepComments.DataSource = comments;
                RepComments.DataBind();
                //this.DataBind();               
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void btnVoteFor_Click(object sender, EventArgs e)
        {
              vote = "For";
              VoteItem(vote);
              btnVoteFor.Enabled = false;
              btnVoteAgainst.Enabled = false;
        }

        protected void btnVoteAgainst_Click(object sender, EventArgs e)
        {
              vote = "Against";
              VoteItem(vote);
              btnVoteFor.Enabled = false;
              btnVoteAgainst.Enabled = false;
        }


        public void VoteItem(string vote)
        {
           try
           {
               int itemId = 0;
               if (Session["itemId"] != null)
                    itemId = int.Parse(Session["itemId"].ToString());

               
                   if (Session["itemId"] != null)
                   {
                       string cookieString = string.Empty;
                       cookieString = Session["userId"].ToString() + "Y";
                       // SET COOKIE
                       HttpCookie cookie = new HttpCookie("Vote");
                       //cookie.Values.Add("userId", Session["userId"].ToString());
                       cookie.Values.Add(cookieString, cookieString);
                       cookie.Expires = DateTime.Now.AddDays(30);
                       Response.Cookies.Add(cookie);

                       BusinessLayer businessObj = new BusinessLayer();
                       int rowsAffected = businessObj.VoteItem(vote, itemId, connectionString);

                       if (rowsAffected == 1)
                       {
                           lblMsg.Text = "Your vote has been counted. Thank You.";
                       }
                   }
              

           }
           catch
           {
               throw;
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

       

      
    }
}
