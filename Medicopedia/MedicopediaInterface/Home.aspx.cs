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

namespace MedicopediaInterface
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = string.Empty;

            if (Session["username"] != null)
                lblUserName.Text = Session["username"].ToString();


            if(Session["role"] != null)
                role = Session["role"].ToString().Trim();

            if (role.Equals("Users"))
                Response.Redirect("HomeUser.aspx");
            else if (role.Equals("Doctor"))
                Response.Redirect("HomeDoctor.aspx");
            else if (role.Equals("Admin"))
                Response.Redirect("HomeAdmin.aspx");

        }


    }
}
