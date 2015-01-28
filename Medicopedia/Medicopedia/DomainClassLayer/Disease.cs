using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainClassLayer
{
    public class Disease
    {
        string name;
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }
        string description;
        public string Description
        {
            get { return description; }
            set { this.description = value; }
        }
        string symptoms;
        public string Symptoms
        {
            get { return symptoms; }
            set { this.symptoms = value; }
        }
        string category;
        public string Category
        {
            get { return category; }
            set { this.category = value; }
        }

        //default constructor
        public Disease()
        { }
        //parametrized constructor
        public Disease(string name, string description, string symptoms, string category)
        {
            Name = name;
            Description = description;
            Symptoms = symptoms;
            Category = category;
        }
    }
}
