using System;
using System.Collections;
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

// ADD NAMESPACES
using BusinessClassLayer;
using DomainClassLayer;

namespace MedicopediaInterface
{
    public partial class MedicopediaMasterPage : System.Web.UI.MasterPage
    {
        string ddlSearchSelected = string.Empty;
        string connectionString = ConfigurationManager.AppSettings.Get("connString");

        protected void Page_Load(object sender, EventArgs e)
        {

            /*
             * IF BACK BUTTON IS PRESSED AFTER LOGOUT, IT SHOWS THE PREV PAGE,
             * WHICH SHUD NOT HAPPEN. THIS HAPPENS AS THE PAGES ARE CACHED AS
             * AND WHEN THEY ARE ACCESSED. THEREFORE, CLEAR THE CACHE.
             * */

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));


            
            if (Session["role"] != null && Session["role"].ToString().Equals("Guest"))
                lnkPersonalize.Visible = false;
            else
                lnkPersonalize.Visible = true;


            // PERSONALIZE
            //if (Session["userId"] != null && int.Parse(Session["userId"].ToString()) == 0)
            //{
            //    HttpCookie cookie = Request.Cookies["UserPreference"];
            //    if (cookie != null && cookie["UserId"].ToString().Equals(Session["userId"].ToString()))
            //    {
            //        PageBody.Attributes.Add("bgcolor", cookie["BackColor"].ToString());
            //        LeftPane.Attributes.Add("bgcolor", cookie["LeftPaneColor"].ToString());
            //    }
            //}
               

            txtSymptoms.Width = Unit.Pixel(100);
            btnGo.Width = Unit.Pixel(40);

            // GET THE DATE
            lblDate.Text = DateTime.Now.ToLongDateString();

            //ddlSearch.Items.Clear();
            //ddlCategory.Items.Clear();
            //ddlType.Items.Clear();

            lblMsg.Text = string.Empty;

            if (!IsPostBack)
            {

                ddlSearch.Items.Add("Select a search criteria");
                ddlSearch.Items.Add("By Disease");
                ddlSearch.Items.Add("By Medicine");
                ddlSearch.Items.Add("By Medical Experts");
                ddlSearch.Items.Add("By Symptoms");

                //Medicopedia.FillSearchCriteria();
                //ddlSearch.DataSource = Medicopedia.SearchCriteria;
                ddlCategory.Items.Add("Select a search criteria");
                ddlType.Items.Add("Select a search criteria");

                ddlCategory.Enabled = false;
                ddlType.Enabled = false;

                DataBind();
            }
          
            
        }

        protected void gvTop10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string searchCriteria = string.Empty;
            string category = string.Empty;
            string type = string.Empty;

            try
            {
                // IF symptoms OPTION IS SELECTED
                if (ddlSearch.SelectedItem.ToString().Equals("By Symptoms"))
                {
                    searchCriteria = "By Symptoms";
                    type = txtSymptoms.Text;
                }
                else
                {
                    searchCriteria = ddlSearch.SelectedValue.ToString();
                    category = ddlCategory.SelectedValue.ToString();
                    type = ddlType.SelectedValue.ToString();
                }

                if (!ddlSearch.SelectedItem.ToString().Equals("Select a search criteria"))
                {
                    BusinessLayer busObj = new BusinessLayer();
                    gvDiseases.DataSource = busObj.Search(searchCriteria, category, type, connectionString);
                    gvDiseases.DataBind();
                }
                else
                {
                    lblMsg.Text = "Specify a search criteria";
                }
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }

            
        }

        protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCategory.Enabled = true;
            //ddlType.Items.Insert(0, "-- Select a search criteria --");
            ddlType.Enabled = false;

            string searchStr = string.Empty;
            string categoryStr = string.Empty;

            try
            {
                BusinessLayer businessLayerObj = new BusinessLayer();
                DataSet dsTypes = new DataSet();

                if (ddlSearch.SelectedItem.ToString().Equals("By Disease"))
                {
                    searchStr = "Disease";

                    dsTypes = businessLayerObj.GetCategories(searchStr, categoryStr, connectionString);

                    ddlType.Enabled = true;
                    ddlCategory.DataSource = dsTypes.Tables["Disease"];
                    ddlCategory.DataTextField = dsTypes.Tables["Disease"].Columns["CategoryOfDisease"].ToString();


                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, "Select a search criteria");
                    ddlCategory.DataBind();
                }
                else if (ddlSearch.SelectedItem.ToString().Equals("By Medicine"))
                {
                    searchStr = "Medicines";
                    categoryStr = ddlCategory.SelectedItem.ToString();

                    dsTypes = businessLayerObj.GetCategories(searchStr, categoryStr, connectionString);

                    ddlType.Enabled = true;
                    ddlCategory.DataSource = dsTypes.Tables["Medicines"];
                    ddlCategory.DataTextField = dsTypes.Tables["Medicines"].Columns["Category"].ToString();
                    ddlCategory.DataBind();


                }
                else if (ddlSearch.SelectedItem.ToString().Equals("By Medical Experts"))
                {

                    searchStr = "Doctor";
                    categoryStr = ddlCategory.SelectedItem.ToString();
                    ddlType.Enabled = false;

                    dsTypes = businessLayerObj.GetCategories(searchStr, categoryStr, connectionString);

                    ddlType.Enabled = true;
                    ddlCategory.DataSource = dsTypes.Tables["Users"];
                    ddlCategory.DataTextField = dsTypes.Tables["Users"].Columns["Specialization"].ToString();
                    ddlCategory.DataBind();

                }
                else if (ddlSearch.SelectedItem.ToString().Equals("By Symptoms"))
                {
                    ddlCategory.Visible = false;
                    ddlType.Visible = false;
                    txtSymptoms.Visible = true;
                }
                else
                {
                    ddlCategory.Visible = true;
                    ddlCategory.Enabled = false;
                    ddlCategory.Items.Add("Select a search criteria");

                    ddlType.Items.Add("Select a search criteria");
                    ddlType.Visible = true;
                    ddlType.Enabled = false;

                    txtSymptoms.Visible = false;

                }


                string newCategory = string.Empty;
                LoadData(newCategory);


            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }



        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCategory.Enabled = true;

            string searchStr = string.Empty;
            string categoryStr = string.Empty;


            try
            {
                BusinessLayer businessLayerObj = new BusinessLayer();
                DataSet dsTypes = new DataSet();

                if (ddlSearch.SelectedItem.ToString().Equals("By Disease"))
                {
                    searchStr = "Disease";
                    categoryStr = ddlCategory.SelectedItem.ToString();

                    dsTypes = businessLayerObj.GetTypes(searchStr, categoryStr, connectionString);

                    ddlType.Enabled = true;
                    ddlType.DataSource = dsTypes.Tables["Disease"];
                    ddlType.DataTextField = dsTypes.Tables["Disease"].Columns[0].ToString();
                    ddlType.DataBind();
                }
                else if (ddlSearch.SelectedItem.ToString().Equals("By Medicine"))
                {
                    searchStr = "Medicines";
                    categoryStr = ddlCategory.SelectedItem.ToString();

                    dsTypes = businessLayerObj.GetTypes(searchStr, categoryStr, connectionString);

                    ddlType.Enabled = true;
                    ddlType.DataSource = dsTypes.Tables["Medicines"];
                    ddlType.DataTextField = dsTypes.Tables["Medicines"].Columns[0].ToString();
                    ddlType.DataBind();


                }
                else if (ddlSearch.SelectedItem.ToString().Equals("By Medical Experts"))
                {

                    searchStr = "Doctor";
                    categoryStr = ddlCategory.SelectedItem.ToString();
                    ddlType.Enabled = false;
                }
                else if (ddlSearch.SelectedItem.ToString().Equals("By Symptoms"))
                {
                    ddlCategory.Visible = false;
                    ddlType.Visible = false;
                    txtSymptoms.Visible = true;
                }
                else
                {
                    ddlCategory.Enabled = false;
                    ddlCategory.Items.Add("Select a search criteria");
                    ddlType.Items.Add("Select a search criteria");

                    ddlType.Enabled = false;
                    ddlCategory.Enabled = false;
                }
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }


        }





        public void LoadData(string newCategory)
        {
            ddlCategory.Enabled = true;
            string searchStr = string.Empty;
            string categoryStr = string.Empty;

            try
            {
                BusinessLayer businessLayerObj = new BusinessLayer();
                DataSet dsTypes = new DataSet();

                if (ddlSearch.SelectedItem.ToString().Equals("By Disease"))
                {
                    searchStr = "Disease";
                    categoryStr = ddlCategory.SelectedItem.ToString();

                    dsTypes = businessLayerObj.GetTypes(searchStr, categoryStr, connectionString);

                    ddlType.Enabled = true;
                    ddlType.DataSource = dsTypes.Tables["Disease"];
                    ddlType.DataTextField = dsTypes.Tables["Disease"].Columns[0].ToString();
                    ddlType.DataBind();
                }
                else if (ddlSearch.SelectedItem.ToString().Equals("By Medicine"))
                {
                    searchStr = "Medicines";
                    categoryStr = ddlCategory.SelectedItem.ToString();

                    dsTypes = businessLayerObj.GetTypes(searchStr, categoryStr, connectionString);

                    ddlType.Enabled = true;
                    ddlType.DataSource = dsTypes.Tables["Medicines"];
                    ddlType.DataTextField = dsTypes.Tables["Medicines"].Columns[0].ToString();
                    ddlType.DataBind();


                }
                else if (ddlSearch.SelectedItem.ToString().Equals("By Medical Experts"))
                {

                    searchStr = "Doctor";
                    categoryStr = ddlCategory.SelectedItem.ToString();
                    ddlType.Enabled = false;
                }
                else if (ddlSearch.SelectedItem.ToString().Equals("By Symptoms"))
                {
                    ddlCategory.Visible = false;
                    ddlType.Visible = false;
                    txtSymptoms.Visible = true;
                }
                else
                {
                    ddlCategory.Enabled = false;
                    ddlCategory.Items.Add("Select a search criteria");
                    ddlType.Items.Add("Select a search criteria");

                    ddlType.Enabled = false;
                    ddlCategory.Enabled = false;
                }
            }
            catch
            {
                //Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void lnkPersonalize_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personalize.aspx");
        }



    }

}