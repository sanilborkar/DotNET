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


namespace MedicopediaInterface
{
    public partial class MedicopediaMasterPage : System.Web.UI.MasterPage
    {
        string ddlSearchSelected = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            txtSymptoms.Width = Unit.Pixel(100);
            btnGo.Width = Unit.Pixel(40);


            // GET THE TIME
            lblDate.Text = DateTime.Now.ToLongDateString();

            Session["role"] = "Guest";

            

            if (!IsPostBack)
            {
                ddlSearch.Items.Add("Select a search criteria");
                ddlSearch.Items.Add("By Disease");
                ddlSearch.Items.Add("By Medicine");
                ddlSearch.Items.Add("By Medical Experts");
                ddlSearch.Items.Add("By Symptoms");

                ddlCategory.Items.Add("Select a search criteria");
                ddlType.Items.Add("Select a search criteria");

                ddlCategory.Enabled = false;
                ddlType.Enabled = false;


            }
            else
            {
                // IF AN OPTION IS SELECTED FROM THE 1ST DROPDOWN LIST
                if (ddlSearch.SelectedIndex > -1)
                {
                    if (ddlSearch.SelectedItem.ToString().Equals("By Disease")
                        || ddlSearch.SelectedItem.ToString().Equals("By Medicine")
                        || ddlSearch.SelectedItem.ToString().Equals("By Medical Experts"))
                    {
                        ddlCategory.Enabled = true;
                    }

                }

                // IF AN OPTION IS SELECTED FROM THE 2ND DROPDOWN LIST
                if (ddlCategory.SelectedIndex > -1)
                {
                    if (!ddlCategory.SelectedItem.ToString().Equals("Select a search criteria"))
                    {
                        ddlType.Enabled = true;
                    }
                    else
                        ddlType.Enabled = false;
                }


                if (ddlSearch.SelectedItem.ToString().Equals("By Symptoms"))
                {
                    ddlCategory.Visible = false;
                    ddlType.Visible = false;
                    txtSymptoms.Visible = true;
                }
                else
                {
                    ddlCategory.Visible = true;
                    ddlType.Visible = true;
                    txtSymptoms.Visible = false;
                }


                string connectionString = ConfigurationManager.AppSettings.Get("connString");

                if (ddlSearch.SelectedIndex > -1 &&
                    !ddlCategory.SelectedItem.ToString().Equals("Select a search criteria")
                    && !ddlSearch.SelectedItem.ToString().Equals("Select a search criteria"))
                {
                    string searchStr = string.Empty;
                    string categoryStr = string.Empty;

                    // CREATE A BUSINESS CLASS LAYER TO GET THE TYPES
                    BusinessLayer businessLayerObj = new BusinessLayer();
                    DataSet dsTypes = null;




                    if (ddlSearch.SelectedItem.ToString().Equals("By Disease")
                        && !ddlCategory.SelectedItem.ToString().Equals("Select a search criteria"))
                    {
                        //ddlType.Items.Clear();


                        searchStr = "Disease";
                        categoryStr = ddlCategory.SelectedItem.ToString();

                        dsTypes = businessLayerObj.GetTypes(searchStr, categoryStr, connectionString);

                        ddlType.DataSource = dsTypes.Tables["Disease"];
                        ddlType.DataTextField = dsTypes.Tables["Disease"].Columns[0].ToString();
                        ddlType.DataBind();

                    }
                    else if (ddlSearch.SelectedItem.ToString().Equals("By Medicine")
                        && !ddlCategory.SelectedItem.ToString().Equals("Select a search criteria"))
                    {
                        //ddlType.Items.Clear();

                        searchStr = "Medicines";
                        categoryStr = ddlCategory.SelectedItem.ToString();

                        dsTypes = businessLayerObj.GetTypes(searchStr, categoryStr, connectionString);

                        ddlType.DataSource = dsTypes.Tables["Medicines"];
                        ddlType.DataTextField = dsTypes.Tables["Medicines"].Columns[0].ToString();
                        ddlType.DataBind();


                    }
                    else if (ddlSearch.SelectedItem.ToString().Equals("By Medical Experts")
                        && !ddlCategory.SelectedItem.ToString().Equals("Select a search criteria"))
                    {


                        searchStr = "Doctor";
                        categoryStr = ddlCategory.SelectedItem.ToString();

                        dsTypes = businessLayerObj.GetTypes(searchStr, categoryStr, connectionString);

                        ddlType.DataSource = dsTypes.Tables["Users"];
                        ddlType.DataTextField = dsTypes.Tables["Users"].Columns[0].ToString();
                        ddlType.DataBind();

                    }

                }
                else if (ddlSearch.SelectedItem.ToString().Equals("Select a search criteria"))
                {
                    
                    ddlCategory.Items.Add("Select a search criteria");
                    ddlType.Items.Add("Select a search criteria");

                    ddlType.Enabled = false;
                    ddlCategory.Enabled = false;
                }




            }
        }

        protected void gvTop10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }

}