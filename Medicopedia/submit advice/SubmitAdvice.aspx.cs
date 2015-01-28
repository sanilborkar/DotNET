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

namespace MedicopediaInterface
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                try
                {
                    ddlAdviceStatus.Items.Add("Select");
                    ddlAdviceStatus.Items.Add("Resolved");
                    ddlAdviceStatus.Items.Add("Pending");
                    ddlAdviceStatus.Items.Add("Need More Info");
                    ddlAdviceStatus.DataBind();
                }
                catch 
                {
                    throw;
                }
                 LoadData();
            }
        }
        public void InsertAdvice()
        {
            string connectionString = ConfigurationManager.AppSettings.Get("connString");

            using (SqlConnection connsql = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlcmd = new SqlCommand())
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "usp_SubmitAdvice";
                        sqlcmd.Connection = connsql;





                        //write sql parameters
                        SqlParameter pQueryId = new SqlParameter("@QueryID", SqlDbType.Int, 0);
                        SqlParameter pAdviceDescription = new SqlParameter("@AdviceDescription", SqlDbType.NVarChar, 250);
                        SqlParameter pAdvisedBy = new SqlParameter("@AdvisedBy", SqlDbType.Int,0);
                        SqlParameter pAdviceStatus = new SqlParameter("@AdviceStatus", SqlDbType.NVarChar, 50);

                        //put data from textbox into sql parameters

                        pQueryId.Value = txtQueryid.Text;
                        pAdviceDescription.Value = txtAdvice.Text;
                        pAdvisedBy.Value = txtAdviceBy.Text;
                        pAdviceStatus.Value = ddlAdviceStatus.SelectedValue.ToString();

                        sqlcmd.Parameters.Add(pQueryId);
                        sqlcmd.Parameters.Add(pAdviceDescription);
                        sqlcmd.Parameters.Add(pAdvisedBy);
                        sqlcmd.Parameters.Add(pAdviceStatus);
                        connsql.Open();
                        sqlcmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connsql.Close();
                }
            }

                        
         
        }
        public void LoadData()
        {
            string connString = ConfigurationManager.AppSettings.Get("connString");
            SqlConnection connSql = new SqlConnection(connString);
            connSql.Open();
            SqlCommand cmdSql = new SqlCommand();
            cmdSql.CommandType = CommandType.StoredProcedure;
            cmdSql.CommandText = "usp_GetSpecialistDetails";
            cmdSql.Connection = connSql;
            //SqlParameter pAdviceId = new SqlParameter("@queryid", SqlDbType.Int, 0);
            // pQueryId.Value = 3;
            //cmdSql.Parameters.Add(pQueryId);

            DataSet dsSpecialist = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmdSql);
            adapter.Fill(dsSpecialist, "Users");
            GridView1.DataSource = dsSpecialist.Tables["Users"];
            GridView1.DataBind();
            cmdSql.ExecuteNonQuery();
            connSql.Close();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (ddlAdviceStatus.SelectedValue.Equals("Need More Info"))
            //{

            //}
            //else
            //{
            InsertAdvice();
            //}
            Cleartext();
        }
        public void Cleartext()
        {
            txtQueryid.Text = "";
            txtAdvice.Text = "";
            txtAdviceBy.Text = "";
            ddlAdviceStatus.SelectedIndex = -1;
        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
        }

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

       
        
    }
}
