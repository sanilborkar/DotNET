using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainClassLayer
{
    public  class Query
    {
        int queryId;
        public int QueryId
        {
            get { return queryId; }
            set { this.queryId = value; }
        }
        string queryTitle;
        public string QueryTitle
        {
            get { return queryTitle; }
            set { queryTitle = value; }
        }
        int userDetails;
        public int UserDetails
        {
            get { return userDetails; }
            set { userDetails = value; }
        }
        string disease;
        public string Disease
        {
            get { return disease; }
            set { this.disease = value; }
        }
        string symptoms;
        public string Symptoms
        {
            get { return symptoms; }
            set { this.symptoms = value; }
        }
        string history;
        public string History
        {
            get { return history; }
            set { this.history = value; }
        }
        string status;
        public string Status
        {
            get { return status; }
            set { this.status = value; }
        }
        //default constructor
        public Query()
        { }
        //parametrized constructor
        public Query(int queryId,string disease, string symptoms, string history,string status)
        {
            QueryId = queryId;
            Disease = disease;
            Symptoms = symptoms;
            History = history;
            Status = status;
        }

    }
}
