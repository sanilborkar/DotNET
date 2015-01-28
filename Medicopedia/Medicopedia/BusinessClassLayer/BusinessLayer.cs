using System;
using System.Web;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

// ADD FOR SQL FUNCTIONALITIES
using System.Data;
using System.Data.SqlClient;

// ADD NAMESPACES
using DataClassLayer;
using DomainClassLayer;
using BusinessClassLayer;


namespace BusinessClassLayer
{
    public class BusinessLayer
    {

        public DataSet GetCategories(string searchStr, string category, string connString)
        {
            try
            {
                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = System.Data.CommandType.StoredProcedure;


                DataSet dsCategories = new DataSet();

                DataLayer datalayerObj = new DataLayer();

                if (searchStr.Equals("Disease"))
                {
                    cmdSql.CommandText = "usp_GetDiseaseCategory";
                    dsCategories = datalayerObj.GetDiseaseCategories(cmdSql, connString);

                }
                else if (searchStr.Equals("Medicines"))
                {
                    cmdSql.CommandText = "usp_GetMedicineCategory";
                    dsCategories = datalayerObj.GetMedicineCategories(cmdSql, connString);
                }
                else if (searchStr.Equals("Doctor"))
                {
                    cmdSql.CommandText = "usp_GetDoctorCategory";
                    dsCategories = datalayerObj.GetDoctorCategories(cmdSql, connString);
                }

                return dsCategories;
            }
            catch
            {
                throw;
            }
        }



        public DataSet GetTypes(string searchStr, string category, string connString)
        {
            try
            {
                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter pCategory = new SqlParameter("@category", SqlDbType.NVarChar, 20);
                pCategory.Value = category;
                cmdSql.Parameters.Add(pCategory);

                DataSet dsCategories = new DataSet();

                DataLayer datalayerObj = new DataLayer();

                if (searchStr.Equals("Disease"))
                {
                    cmdSql.CommandText = "usp_GetDiseaseType";
                    dsCategories = datalayerObj.GetDiseaseCategories(cmdSql, connString);

                }
                else if (searchStr.Equals("Medicines"))
                {
                    cmdSql.CommandText = "usp_GetMedicineType";
                    dsCategories = datalayerObj.GetMedicineCategories(cmdSql, connString);
                }
                else if (searchStr.Equals("Doctor"))
                {
                    cmdSql.CommandText = "usp_GetDoctorType";
                    dsCategories = datalayerObj.GetDoctorCategories(cmdSql, connString);
                }

                return dsCategories;
            }
            catch
            {
                throw;
            }
        }




        public Users ValidateUserPass(string userEmail, string password, string role, string connString)
        {
            try
            {
                SqlConnection connsql = new SqlConnection(connString);
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.CommandText = "usp_ValidateUserPassword";
                cmdsql.CommandType = CommandType.StoredProcedure;
                cmdsql.Connection = connsql;

                SqlParameter puserEmail = new SqlParameter("@userEmail", SqlDbType.NVarChar, 50);
                SqlParameter ppassword = new SqlParameter("@password", SqlDbType.VarChar, 50);
                SqlParameter prole = new SqlParameter("@role", SqlDbType.NChar, 10);


                puserEmail.Value = userEmail;
                ppassword.Value = password;
                prole.Value = role;


                cmdsql.Parameters.Add(puserEmail);
                cmdsql.Parameters.Add(ppassword);
                cmdsql.Parameters.Add(prole);



                DataLayer dlObj = new DataLayer();
                DataSet dsUser = new DataSet();
                dsUser = dlObj.GetUserDetails(cmdsql, connString);
                Users loggedUser = new Users();

                if (dsUser != null)
                {
                    loggedUser.UserId = int.Parse(dsUser.Tables["Users"].Rows[0]["UserId"].ToString());
                    loggedUser.Name = dsUser.Tables["Users"].Rows[0]["UserName"].ToString();
                    loggedUser.Password = dsUser.Tables["Users"].Rows[0]["Password"].ToString();
                    loggedUser.Role = dsUser.Tables["Users"].Rows[0]["UserRole"].ToString();
                    loggedUser.EmailID = dsUser.Tables["Users"].Rows[0]["Email"].ToString();                    
                    loggedUser.LicenseNumber = dsUser.Tables["Users"].Rows[0]["LicenceNumber"].ToString(); ;
                    loggedUser.Specialization = dsUser.Tables["Users"].Rows[0]["Specialization"].ToString();
                    loggedUser.DateOfBirth = DateTime.Parse(dsUser.Tables["Users"].Rows[0]["DateOfBirth"].ToString());
                    loggedUser.AreaOfInterest = dsUser.Tables["Users"].Rows[0]["AreaOfInterest"].ToString();
                    loggedUser.Vote = int.Parse(dsUser.Tables["Users"].Rows[0]["Vote"].ToString());
                }
                else
                    loggedUser = null;

                connsql.Close();
                return loggedUser;
            }
            catch
            {
                throw;
            }

        }




        public int InsertUser(Users newUser, string connString)
        {
            try
            {
                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = CommandType.StoredProcedure;
                cmdSql.CommandText = "usp_InsertUser";


                // WRITE SQL PARAMETERS
                SqlParameter pRole = new SqlParameter("@role", SqlDbType.NChar, 10);
                SqlParameter pName = new SqlParameter("@name", SqlDbType.NVarChar, 50);
                SqlParameter pPassword = new SqlParameter("@password", SqlDbType.NVarChar, 50);
                SqlParameter pEmailID = new SqlParameter("@emailID", SqlDbType.NVarChar, 50);
                SqlParameter pGender = new SqlParameter("@gender", SqlDbType.VarChar, 10);
                SqlParameter pDob = new SqlParameter("@dob", SqlDbType.SmallDateTime, 0);
                SqlParameter pAreaofInterest = new SqlParameter("@areaofinterest", SqlDbType.NVarChar, 50);
                SqlParameter pLicenceNo = new SqlParameter("@licenceNo", SqlDbType.NChar, 10);
                SqlParameter pSpecialization = new SqlParameter("@specialization", SqlDbType.NVarChar, 50);
                SqlParameter pVote = new SqlParameter("@vote", SqlDbType.Int, 0);
                SqlParameter pStatus = new SqlParameter("@status", SqlDbType.NVarChar, 50);
                SqlParameter pUserId = new SqlParameter("@userId", SqlDbType.NVarChar, 50);


                pRole.Value = newUser.Role;
                pName.Value = newUser.Name;
                pPassword.Value = newUser.Password;
                pEmailID.Value = newUser.EmailID;
                pGender.Value = newUser.Gender;
                pDob.Value = newUser.DateOfBirth;
                pAreaofInterest.Value = newUser.AreaOfInterest;
                pVote.Value = newUser.Vote;
                pStatus.Value = newUser.RegistrationStatus;
                pLicenceNo.Value = newUser.LicenseNumber;
                pSpecialization.Value = newUser.Specialization;
                pUserId.Direction = ParameterDirection.Output;


                cmdSql.Parameters.Add(pRole);
                cmdSql.Parameters.Add(pName);
                cmdSql.Parameters.Add(pPassword);
                cmdSql.Parameters.Add(pEmailID);
                cmdSql.Parameters.Add(pGender);
                cmdSql.Parameters.Add(pDob);
                cmdSql.Parameters.Add(pAreaofInterest);
                cmdSql.Parameters.Add(pLicenceNo);
                cmdSql.Parameters.Add(pSpecialization);
                cmdSql.Parameters.Add(pVote);
                cmdSql.Parameters.Add(pStatus);
                cmdSql.Parameters.Add(pUserId);


                DataLayer dataObj = new DataLayer();
                cmdSql = dataObj.InsertUser(cmdSql, connString);

                int userId = int.Parse(cmdSql.Parameters["@userId"].Value.ToString());
                return userId;
            }
            catch
            {
                throw;
            }


        }




        public DataSet Search(string searchCriteria, string category, string type, string connString)
        {
            try
            {
                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = CommandType.StoredProcedure;
                string dbName = string.Empty;

                if (searchCriteria.Equals("By Disease"))
                {
                    cmdSql.CommandText = "usp_SearchByDisease";
                    dbName = "Disease";

                    SqlParameter pCategory = new SqlParameter("@category", SqlDbType.VarChar, 30);
                    pCategory.Value = category;
                    cmdSql.Parameters.Add(pCategory);

                    SqlParameter pType = new SqlParameter("@type", SqlDbType.VarChar, 50);
                    pType.Value = type;
                    cmdSql.Parameters.Add(pType);
                }
                else if (searchCriteria.Equals("By Medicine"))
                {
                    cmdSql.CommandText = "usp_SearchByMedicine";
                    dbName = "Medicines";

                    SqlParameter pCategory = new SqlParameter("@category", SqlDbType.VarChar, 30);
                    pCategory.Value = category;
                    cmdSql.Parameters.Add(pCategory);

                    SqlParameter pType = new SqlParameter("@type", SqlDbType.VarChar, 50);
                    pType.Value = type;
                    cmdSql.Parameters.Add(pType);
                }
                else if (searchCriteria.Equals("By Medical Experts"))
                {
                    SqlParameter pCategory = new SqlParameter("@category", SqlDbType.VarChar, 30);
                    pCategory.Value = category;
                    cmdSql.Parameters.Add(pCategory);

                    cmdSql.CommandText = "usp_SearchByDoctor";
                    dbName = "Users";

                }
                else if (searchCriteria.Equals("By Symptoms"))
                {
                    cmdSql.CommandText = "usp_SearchBySymptoms";
                    dbName = "Disease";

                    SqlParameter pSymptoms = new SqlParameter("@symptoms", SqlDbType.NVarChar, 500);
                    pSymptoms.Value = type;
                    cmdSql.Parameters.Add(pSymptoms);
                }





                DataLayer dataLayerObj = new DataLayer();
                DataSet dsSearch = new DataSet();
                dsSearch = dataLayerObj.PerformSearch(cmdSql, connString, dbName);

                return dsSearch;
            }
            catch
            {
                throw;
            }


        }




        public DataSet LoadTop10Grid(string connString)
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "usp_GetTop10";

                
                DataLayer dataObj = new DataLayer();
                DataSet dsTop10 = dataObj.LoadTop10(sqlcmd, connString);
                

                //if (reader.HasRows)
                  //  return reader;
                //else
                    return dsTop10;
            }
            catch
            {
                throw;
            }
        }




        public ArrayList LoadVoteData(int itemId, string connString)
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "usp_GetAdviceDetails";


                //giving data from text box
                SqlParameter pitemId = new SqlParameter("@adviceid", SqlDbType.Int, 0);
                pitemId.Value = itemId;
                sqlcmd.Parameters.Add(pitemId);

                DataLayer dataLayerObj = new DataLayer();
                ArrayList itemList = dataLayerObj.LoadVoteData(sqlcmd, connString);

                return itemList;
            }
            catch
            {
                throw;
            }
        }



        public DataSet LoadXMLVoteData(int itemId, string connString)
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "usp_GetAdviceDetails";


                //giving data from text box
                SqlParameter pitemId = new SqlParameter("@adviceid", SqlDbType.Int, 0);
                pitemId.Value = itemId;
                sqlcmd.Parameters.Add(pitemId);

                DataLayer dataLayerObj = new DataLayer();
                DataSet dsXML = dataLayerObj.LoadXMLVoteData(sqlcmd, connString);

                return dsXML;
            }
            catch
            {
                throw;
            }
        }



        public int VoteItem(string vote, int itemId, string connString)
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;

                if (vote.Equals("For"))
                    sqlcmd.CommandText = "usp_PositiveVote";
                else if (vote.Equals("Against"))
                    sqlcmd.CommandText = "usp_NegativeVote";


                SqlParameter pItemId = new SqlParameter("@itemId", SqlDbType.Int, 0);
                pItemId.Value = itemId;
                sqlcmd.Parameters.Add(pItemId);

                DataLayer dataObj = new DataLayer();
                int rowsAffected = dataObj.VoteItem(sqlcmd, connString);

                return rowsAffected;
            }
            catch
            {
                throw;
            }
        }



        public string LoadComment(int adviceId, string connString)
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "usp_GetAdviceById";

                SqlParameter pAdviceId = new SqlParameter("@adviceId", SqlDbType.Int, 0);
                pAdviceId.Value = adviceId;
                sqlcmd.Parameters.Add(pAdviceId);

                DataLayer dataObj = new DataLayer();
                string itemDescription = dataObj.LoadCommentData(sqlcmd, connString);

                return itemDescription;
            }
            catch
            {
                throw;
            }
        }



        public void AddComment(int adviceId, string comment, int userId, string connString)
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "usp_AddComment";


                SqlParameter pAdviceId = new SqlParameter("@AdviceId", SqlDbType.Int, 0);
                SqlParameter pUserId = new SqlParameter("@UserId", SqlDbType.Int, 0);
                SqlParameter pComment = new SqlParameter("@Comment", SqlDbType.NVarChar, 100);


                pAdviceId.Value = adviceId;
                pUserId.Value = userId;
                pComment.Value = comment;


                sqlcmd.Parameters.Add(pAdviceId);
                sqlcmd.Parameters.Add(pUserId);
                sqlcmd.Parameters.Add(pComment);

                DataLayer dataObj = new DataLayer();
                sqlcmd = dataObj.AddComment(sqlcmd, connString);
            }
            catch
            {
                throw;
            }

        }



        public void InsertQuery(Query newQuery, string connString)
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "usp_SubmitQuery";


                //write sql parameters

                SqlParameter pUserId = new SqlParameter("@UserId", SqlDbType.Int, 0);
                SqlParameter pQueryTitle = new SqlParameter("@QueryTitle", SqlDbType.NVarChar, 50);
                SqlParameter pDisease = new SqlParameter("@Disease", SqlDbType.NVarChar, 50);
                SqlParameter pSymptomsInQuery = new SqlParameter("@SymptomsInQuery", SqlDbType.NVarChar, 250);
                SqlParameter pDetailsOfEarlierReport = new SqlParameter("@DetailsOfEarlierReport", SqlDbType.NVarChar, 250);
                SqlParameter pStatusOfQuery = new SqlParameter("@StatusOfQuery", SqlDbType.NVarChar, 50);


                //put data from textbox into sql parameters

                pUserId.Value = newQuery.UserDetails;
                pQueryTitle.Value = newQuery.QueryTitle;
                pDisease.Value = newQuery.Disease;
                pSymptomsInQuery.Value = newQuery.Symptoms;
                pDetailsOfEarlierReport.Value = newQuery.History;
                pStatusOfQuery.Value = newQuery.Status;


                sqlcmd.Parameters.Add(pUserId);
                sqlcmd.Parameters.Add(pQueryTitle);
                sqlcmd.Parameters.Add(pDisease);
                sqlcmd.Parameters.Add(pSymptomsInQuery);
                sqlcmd.Parameters.Add(pDetailsOfEarlierReport);
                sqlcmd.Parameters.Add(pStatusOfQuery);

                DataLayer dataObj = new DataLayer();
                dataObj.InsertQuery(sqlcmd, connString);
            }
            catch
            {
                throw;
            }
        }



        public DataSet ViewPrescriptions(string connString)
        {
            try
            {
                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = CommandType.StoredProcedure;
                cmdSql.CommandText = "usp_GetPrescription";

                DataLayer dataObj = new DataLayer();
                DataSet dsPrescriptions = dataObj.ViewPrescriptions(cmdSql, connString);

                return dsPrescriptions;
            }
            catch
            {
                throw;
            }


        }



        public int InsertAdvice(ArrayList queryDetails, string connString)
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "usp_SubmitAdvice";


                //write sql parameters
                SqlParameter pQueryId = new SqlParameter("@QueryID", SqlDbType.Int, 0);
                SqlParameter pAdvisedBy = new SqlParameter("@AdvisedBy", SqlDbType.Int, 0);
                SqlParameter pAdviceDescription = new SqlParameter("@AdviceDescription", SqlDbType.NVarChar, 250);
                SqlParameter pAdviceStatus = new SqlParameter("@AdviceStatus", SqlDbType.NVarChar, 50);

                //put data from textbox into sql parameters



                pQueryId.Value = queryDetails[0];
                pAdvisedBy.Value = queryDetails[1];
                pAdviceDescription.Value = queryDetails[2];
                pAdviceStatus.Value = queryDetails[3];

                sqlcmd.Parameters.Add(pQueryId);
                sqlcmd.Parameters.Add(pAdvisedBy);
                sqlcmd.Parameters.Add(pAdviceDescription);
                sqlcmd.Parameters.Add(pAdviceStatus);

                DataLayer dataObj = new DataLayer();
                int rowsAffected = dataObj.InsertAdvice(sqlcmd, connString);
                return rowsAffected;
            }
            catch
            {
                throw;
            }

        }



        public void InsertPrescription(int presId, string presDescription, int queryId, string connString)
        {
            try
            {
                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = CommandType.StoredProcedure;
                cmdSql.CommandText = "usp_InsertPres";

                SqlParameter pPresId = new SqlParameter("@prescriber", SqlDbType.Int, 0);
                SqlParameter pDesc = new SqlParameter("@desc", SqlDbType.NVarChar, 500);
                SqlParameter pQueryId = new SqlParameter("@queryid", SqlDbType.Int, 0);

                pPresId.Value = presId;
                pDesc.Value = presDescription;
                pQueryId.Value = queryId;

                cmdSql.Parameters.Add(pPresId);
                cmdSql.Parameters.Add(pDesc);
                cmdSql.Parameters.Add(pQueryId);

                DataLayer dataObj = new DataLayer();
                dataObj.InsertPrescription(cmdSql, connString);
            }
            catch
            {
                throw;
            }
 
        }



        public DataSet LoadSpecialists(string connString)
        {
            try
            {
                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = CommandType.StoredProcedure;
                cmdSql.CommandText = "usp_GetSpecialistDetails";

                DataSet dsSpecialists = new DataSet();

                DataLayer dataObj = new DataLayer();
                dsSpecialists = dataObj.LoadSpecialists(cmdSql, connString);

                return dsSpecialists;
            }
            catch
            {
                throw;
            }
        }


        public void AddToWorklist(int userId, int queryId, int forwardId, string connString)
        {
            try
            {
                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = CommandType.StoredProcedure;
                cmdSql.CommandText = "usp_addToWorklist";

                SqlParameter pUserId = new SqlParameter("@userID", SqlDbType.Int, 0);
                SqlParameter pQueryId = new SqlParameter("@queryID", SqlDbType.Int, 0);
                SqlParameter pForwardedBy = new SqlParameter("@forwardedBy", SqlDbType.Int, 0);

                pUserId.Value = userId;
                pQueryId.Value = queryId;
                pForwardedBy.Value = forwardId;

                cmdSql.Parameters.Add(pUserId);
                cmdSql.Parameters.Add(pQueryId);
                cmdSql.Parameters.Add(pForwardedBy);

                DataLayer dataObj = new DataLayer();
                dataObj.AddToWorklist(cmdSql, connString);
            }
            catch
            {
                throw;
            }
        }



        public DataSet LoadAdminData(string connString)
        {
            try
            {

                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = CommandType.StoredProcedure;
                cmdSql.CommandText = "usp_GetDoctorDetails";

                DataLayer dataObj = new DataLayer();
                DataSet dsAdmin = dataObj.LoadAdminData(cmdSql, connString);

                return dsAdmin;
            }
            catch
            {
                throw;
            }
        }
       


        public void UpdateDoctor(int userId, string connString)
        {
            try
            {
                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = CommandType.StoredProcedure;
                cmdSql.CommandText = "usp_UpdateRegistrationStatus";

                SqlParameter puserid = new SqlParameter("@userid", SqlDbType.Int, 0);
                puserid.Value = userId;
                cmdSql.Parameters.Add(puserid);

                DataLayer dataObj = new DataLayer();
                dataObj.UpdateDoctor(cmdSql, connString);
            }
            catch
            {
                throw;
            }
        }



        public void DeleteDoctor(int puserid, string connString)
        {
            try
            {
                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = CommandType.StoredProcedure;
                cmdSql.CommandText = "usp_RemoveUser";

                SqlParameter pUserId = new SqlParameter("@userid", SqlDbType.Int, 0);
                pUserId.Value = puserid;
                cmdSql.Parameters.Add(pUserId);

                DataLayer dataObj = new DataLayer();
                dataObj.UpdateDoctor(cmdSql, connString);
            }
            catch
            {
                throw;
            }

        }


        public DataSet LoadWorklist(int userId, string connString)
        {
            try
            {
                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = CommandType.StoredProcedure;
                cmdSql.CommandText = "usp_GetDoctorWorklist";

                SqlParameter pUserId = new SqlParameter("@userId", SqlDbType.Int, 0);
                pUserId.Value = userId;
                cmdSql.Parameters.Add(pUserId);

                DataSet dsWorklist = new DataSet();
                DataLayer dataObj = new DataLayer();
                dsWorklist = dataObj.GetDoctorWorklist(cmdSql, connString);
                return dsWorklist;
            }
            catch
            {
                throw;
            }
        }


        public DataSet GetPersonalizationDetails(string connString)
        {
            try
            {
                SqlCommand cmdSql = new SqlCommand();
                cmdSql.CommandType = CommandType.StoredProcedure;
                cmdSql.CommandText = "usp_GetPersonalizationDetails";

                DataLayer dataObj = new DataLayer();
                DataSet dsPersonalization = new DataSet();
                dsPersonalization = dataObj.GetPersonalizationDetails(cmdSql, connString);

                return dsPersonalization;
            }
            catch
            {
                throw;
            }
        }



    }

}