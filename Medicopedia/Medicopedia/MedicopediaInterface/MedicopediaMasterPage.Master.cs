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

            if(Session["role"] != null)
            {
                lblWelcome.Text = Session["role"].ToString();
            }

            if (!IsPostBack)
            {
                ddlSearch.Items.Add("By Disease");
                ddlSearch.Items.Add("By Medicine");
                ddlSearch.Items.Add("By Medical Experts");
                ddlSearch.Items.Add("By Symptoms");
            }
            else
            {
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

                ddlSearchSelected = ddlSearch.SelectedItem.ToString();
            }
        }
    }
}
