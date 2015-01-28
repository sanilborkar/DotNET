﻿using System;
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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null && Session["role"].ToString().Equals("Guest"))
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
    }
}
