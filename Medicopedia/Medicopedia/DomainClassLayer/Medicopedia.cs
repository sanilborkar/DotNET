using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace DomainClassLayer
{
    public class Medicopedia
    {
        private static ArrayList searchCriteria = new ArrayList();

        public static void FillSearchCriteria()
        {
            searchCriteria.Add("Select a search criteria");
            searchCriteria.Add("By Disease");
            searchCriteria.Add("By Medicine");
            searchCriteria.Add("By Medical Experts");
            searchCriteria.Add("By Symptoms");

        }

        public static ArrayList SearchCriteria
        {
            get { return searchCriteria; }
 
        }
    }
}
