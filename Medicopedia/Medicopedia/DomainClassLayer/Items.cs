using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainClassLayer
{
    public class Items
    {
       private int itemID;
        public int ItemID
        {
             get {return itemID;}
        }

        private string itemName;
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }


        private int positiveVotes;
        public int PositiveVotes
        {
            get { return positiveVotes; }
            set { positiveVotes = value; }
        }
         private int negativeVotes;
         public int NegativeVotes
            {
                get { return negativeVotes; }
                set { negativeVotes = value; }
        }
        private string itemDescription;
         private string ItemDescription
            {
                get { return itemDescription; }
                set { itemDescription = value; }
        }

         private string comments;
         public string Comments
         {
             get { return comments; }
             set { comments = value; }
         }

       private DateTime timestamp;
        private DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        public Items()
         { }
        public Items(int itemID, int positiveVotes, int negativeVotes, string itemDescription, string comments, DateTime timestamp)
        {
            this.Comments = comments;
            this.PositiveVotes = positiveVotes;
            this.NegativeVotes = negativeVotes;
            this.ItemDescription = itemDescription;
            this.Timestamp = timestamp;      
        }
    }
}
