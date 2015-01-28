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
    public partial class WebForm11 : System.Web.UI.Page
    {
        string connString = ConfigurationManager.AppSettings.Get("connString");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                lblUserName.Text = Session["username"].ToString();

            if (!IsPostBack)
            {
                LoadData();
            }

        }
        public void LoadData()
        {
            try
            {
                BusinessLayer busObj = new BusinessLayer();
                gvDoctors.DataSource = busObj.LoadAdminData(connString);
                gvDoctors.DataBind();
            }
            catch
            {
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

        protected void gvDoctors_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int userId = int.Parse(gvDoctors.Rows[e.NewSelectedIndex].Cells[0].Text);

                BusinessLayer busObj = new BusinessLayer();
                busObj.UpdateDoctor(userId, connString);
                LoadData();
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void gvDoctors_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int puserid = int.Parse(gvDoctors.DataKeys[0].Value.ToString());

                BusinessLayer busObj = new BusinessLayer();
                busObj.DeleteDoctor(puserid, connString);
                LoadData();
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }
        }


            
        



        
    }
}
