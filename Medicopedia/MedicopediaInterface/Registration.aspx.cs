using System;
using System.Collections;           // FOR ARRAYLIST
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using BusinessClassLayer;
using DomainClassLayer;


namespace MedicopediaInterface
{
    public partial class Registration : System.Web.UI.Page
    {

        string connectionString = ConfigurationManager.AppSettings.Get("connString");

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["username"] = "Guest";
            Session["role"] = "Guest";
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lnkLogin.Visible = false;

            if (Session["username"] != null)
                lblUserName.Text = Session["username"].ToString();

            if (Session["username"] != null && !Session["username"].ToString().Equals("Guest"))
                Response.Redirect("Home.aspx");

            if (Session["username"] != null && Session["username"].ToString().Equals("Guest"))
                LinkButton1.Visible = false;

            lblMsg.Text = string.Empty;

            if (!IsPostBack)
            {
                ClearData();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRegistered.SelectedValue == "Doctor")
            {
                lblLicensenumber.Visible = true;
                lblSpecialization.Visible = true;
                txtLicensenumber.Visible = true;
                txtSpecialization.Visible = true;
            }
            else
            {
                lblLicensenumber.Visible = false;
                lblSpecialization.Visible = false;
                txtLicensenumber.Visible = false;
                txtSpecialization.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Users newUser = new Users();

                if (ddlRegistered.SelectedValue.ToString().Equals("User"))
                {
                    newUser.Role = "Users";
                }
                else
                {
                    newUser.Role = ddlRegistered.SelectedValue.ToString().Trim();
                }
 

                newUser.Name = txtName.Text.Trim();
                newUser.Password = txtPassword.Text.Trim();
                newUser.EmailID = txtEmailid.Text.Trim();

                string newUsergender = rbl_gender.SelectedValue.ToString();
                if(newUsergender.Equals("Male"))
                    newUser.Gender = 'M';
                else if (newUsergender.Equals("Female"))
                    newUser.Gender = 'F';

                newUser.DateOfBirth = DateTime.Parse(txtDOB.Text);
                newUser.AreaOfInterest = txtIinterestedin.Text.Trim();
                newUser.Vote = 0;


                if (ddlRegistered.SelectedValue.ToString().Equals("Doctor"))
                {
                    newUser.RegistrationStatus = "Unregistered";
                    newUser.LicenseNumber = txtLicensenumber.Text.Trim();
                    newUser.Specialization = txtSpecialization.Text.Trim();

                }
                else
                {
                    newUser.RegistrationStatus = "Registered";
                    newUser.LicenseNumber = "NA";
                    newUser.Specialization = "NA";
                }


                BusinessLayer businessObj = new BusinessLayer();
                int userId = businessObj.InsertUser(newUser, connectionString);
                if (userId > 0)
                {
                    lblMsg.Text = "Successfully Registered. Please login to continue";
                    lnkLogin.Visible = true;
                }
                else
                {
                    lblMsg.Text = "Sorry. Registration Unsuccessful. Try again later.";
                }
            }
            catch(Exception ex) 
            {

            }
        }
        
        public void ClearData()
        {
            try
            {
                txtName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtEmailid.Text = string.Empty;
       
                txtIinterestedin.Text = string.Empty;
                txtLicensenumber.Text = string.Empty;
                txtSpecialization.Text = string.Empty;
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }




    }
}
