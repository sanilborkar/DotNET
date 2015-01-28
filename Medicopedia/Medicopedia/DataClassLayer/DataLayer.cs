using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using System.Data;
using System.Data.SqlClient;

using DomainClassLayer;


namespace DataClassLayer
{
    public class DataLayer
    {
        public DataSet GetDiseaseCategories(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null ;

            try
            {
                // CREATE A SQL CONNECTION: connString IS PASSED FROM THE 
                // BUSINESS LAYER
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;

                // OPEN THE SQL CONNECTION
                connSql.Open();

                DataSet dsCategory = new DataSet();
                SqlDataAdapter adpater = new SqlDataAdapter(cmdSql);             
                
         
                adpater.Fill(dsCategory, "Disease");

                               
                return dsCategory;
            }
            catch
            {
                throw;
            }
            finally
            {
                // CLOSE THE SQL CONNECTION
                connSql.Close();

                // DISPOSE THE SQL CONNECTION
                connSql.Dispose();
            }


        }



        public DataSet GetMedicineCategories(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                // CREATE A SQL CONNECTION: connString IS PASSED FROM THE 
                // BUSINESS LAYER
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;

                // OPEN THE SQL CONNECTION
                connSql.Open();

                DataSet dsCategory = new DataSet();
                SqlDataAdapter adpater = new SqlDataAdapter(cmdSql);
                adpater.Fill(dsCategory, "Medicines");


                return dsCategory;
            }
            catch
            {
                throw;
            }
            finally
            {
                // CLOSE THE SQL CONNECTION
                connSql.Close();

                // DISPOSE THE SQL CONNECTION
                connSql.Dispose();
            }


        }



        public DataSet GetDoctorCategories(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                // CREATE A SQL CONNECTION: connString IS PASSED FROM THE 
                // BUSINESS LAYER
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;

                // OPEN THE SQL CONNECTION
                connSql.Open();

                DataSet dsCategory = new DataSet();
                SqlDataAdapter adpater = new SqlDataAdapter(cmdSql);
                adpater.Fill(dsCategory, "Users");


                return dsCategory;
            }
            catch
            {
                throw;
            }
            finally
            {
                // CLOSE THE SQL CONNECTION
                connSql.Close();

                // DISPOSE THE SQL CONNECTION
                connSql.Dispose();
            }


        }



        public DataSet GetUserDetails(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {

                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();

                DataSet dsUser = new DataSet();
                SqlDataAdapter adpater = new SqlDataAdapter(cmdSql);
                adpater.Fill(dsUser, "Users");

                if (dsUser.Tables[0].Rows.Count == 0)
                    dsUser = null;

                return dsUser;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }
        }



        public SqlCommand InsertUser(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();
                cmdSql.ExecuteNonQuery();
                return cmdSql;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }

        }




        public DataSet PerformSearch(SqlCommand cmdSql, string connString, string dbName)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();

                DataSet dsSearch = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdSql);
                adapter.Fill(dsSearch, dbName);

                return dsSearch;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }
        }




        public DataSet LoadTop10(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();

                DataSet dstop10 = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdSql);
                adapter.Fill(dstop10);
                

                //if (reader.HasRows)
                    return dstop10;
                //else
                  //  return null;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }
        }




        public ArrayList LoadVoteData(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();

                DataSet dsSearch = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdSql);
                adapter.Fill(dsSearch, "Items");

                SqlDataReader reader = cmdSql.ExecuteReader();

                Items item = new Items();
                string comment = string.Empty;
                ArrayList comments = new ArrayList();
                ArrayList itemList = new ArrayList();

                if (reader.HasRows)
                {
                    reader.Read();
                    item.ItemName = reader["AdviceName"].ToString();
                    item.PositiveVotes = int.Parse(reader["PositiveVotes"].ToString());
                    item.NegativeVotes = int.Parse(reader["NegativeVotes"].ToString());
                }

                while (reader.Read())
                {
                    comment = reader["Comment"].ToString();
                    comments.Add(comment);
                }

                itemList.Add(item);
                itemList.Add(comments);

                return itemList;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }
        }



        public DataSet LoadXMLVoteData(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();

                DataSet dsXML = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdSql);
                adapter.Fill(dsXML);
                
                if (dsXML != null)
                    return dsXML;
                else
                    return null;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }
        }




        public int VoteItem(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();
                int rowsAffected = cmdSql.ExecuteNonQuery();
                return rowsAffected;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }

        
        }



        public string LoadCommentData(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();

                SqlDataReader dataReader = cmdSql.ExecuteReader();

                string itemDescription = string.Empty;

                while (dataReader.Read())
                {
                    itemDescription = dataReader["ItemDescription"].ToString();
                }

                return itemDescription;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }
        }




        public SqlCommand AddComment(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();
                cmdSql.ExecuteNonQuery();
                return cmdSql;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }


        }



        public int InsertAdvice(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();
                int rowsAffected = cmdSql.ExecuteNonQuery();
                return rowsAffected;

            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }

        }



        public void InsertPrescription(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();
                cmdSql.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }


        }



        public DataSet LoadSpecialists(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();

                DataSet dsSpecialists = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdSql);
                adapter.Fill(dsSpecialists, "Users");

                return dsSpecialists;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }
        }



        public void AddToWorklist(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();
                cmdSql.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }

        }


        public DataSet LoadAdminData(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;
            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();
                
                DataSet dsAdmin = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdSql);
                adapter.Fill(dsAdmin, "Users");

                return dsAdmin;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }
            
        }



        // USED FOR BOTH: Adding a doctor (Registration Status = Registration)
        // AND For Deleting a doctor
        public void UpdateDoctor(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;
            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();
                cmdSql.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }
        }



        public void InsertQuery(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;
            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();
                cmdSql.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }
        }


        public DataSet ViewPrescriptions(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;

            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql; 
                connSql.Open();

                DataSet dsPrescriptions = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdSql);
                adapter.Fill(dsPrescriptions, "Query");


                return dsPrescriptions;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }

        }


        public DataSet GetDoctorWorklist(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;
            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();

                DataSet dsWorklist = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdSql);
                adapter.Fill(dsWorklist, "Query");


                return dsWorklist;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }
        }


        public DataSet GetPersonalizationDetails(SqlCommand cmdSql, string connString)
        {
            SqlConnection connSql = null;
            try
            {
                connSql = new SqlConnection(connString);
                cmdSql.Connection = connSql;
                connSql.Open();

                DataSet dsPersonalize = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdSql);
                adapter.Fill(dsPersonalize, "Personalization");


                return dsPersonalize;
            }
            catch
            {
                throw;
            }
            finally
            {
                connSql.Close();
                connSql.Dispose();
            }
 
        }


    }
    }

