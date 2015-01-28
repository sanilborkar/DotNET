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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string connString = ConfigurationManager.AppSettings.Get("connString");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                lblUserName.Text = Session["username"].ToString();

            if (Session["username"] != null && Session["role"].ToString().Equals("Guest"))
                LinkButton1.Text = string.Empty;

            if (!IsPostBack)
            {
                try
                {
                    LoadData();
                }
                catch
                {

                }
            }

        }



        private void LoadData()
        {
            BusinessLayer busObj = new BusinessLayer();
            DataSet dsPersonalization = new DataSet();
            dsPersonalization = busObj.GetPersonalizationDetails(connString);

            ddlBackColor.DataSource = dsPersonalization.Tables["Personalization"];
            ddlBackColor.DataTextField = dsPersonalization.Tables["Personalization"].Columns["BackColor"].ToString();

            ddlleftColor.DataSource = dsPersonalization.Tables["Personalization"];
            ddlleftColor.DataTextField = dsPersonalization.Tables["Personalization"].Columns["LeftPaneColor"].ToString();

            ddlLogoColor.DataSource = dsPersonalization.Tables["Personalization"];
            ddlLogoColor.DataTextField = dsPersonalization.Tables["Personalization"].Columns["LogoColor"].ToString();
            DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["username"] = "Guest";
            Session["role"] = "Guest";
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlBackColor.SelectedIndex > -1 && ddlleftColor.SelectedIndex > -1 && ddlLogoColor.SelectedIndex > -1)
            {
                HttpCookie cookie = Request.Cookies["UserPreference"];

                if (cookie == null)
                {

                    cookie = new HttpCookie("UserPreference");
                    cookie["UserId"] = Session["userId"].ToString();
                    cookie["BackColor"] = ddlBackColor.SelectedItem.ToString();
                    cookie["LeftPaneColor"] = ddlleftColor.SelectedItem.ToString();
                    cookie["LogoColor"] = ddlLogoColor.SelectedItem.ToString();

                    Response.Cookies.Add(cookie);
                }
            }
        }
    }
}
