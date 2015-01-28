using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainClassLayer
{
    public class Users
    {
        int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        string name;
        public string Name
        { 
            get { return name; }
            set { this.name = value; }
        }
        string emailID;
        public string EmailID
        {
            get { return emailID; }
            set { this.emailID = value; }
        }

        string password;
        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }

        string role;
        public string Role
        {
            get { return role; }
            set { this.role = value; }
        }

        char gender;
        public char Gender
        {
            get { return gender; }
            set { this.gender = value; }
        }
        DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { this.dateOfBirth = value; }
        }
        string areaOfInterest;
        public string AreaOfInterest
        {
            get { return areaOfInterest; }
            set { this.areaOfInterest = value; }
        }

       string licenseNumber;
        public string LicenseNumber
        {
            get { return licenseNumber; }
            set { this.licenseNumber = value; }
        }

        string specialization;
        public string Specialization
        {
            get { return specialization; }
            set { this.specialization = value; }
        }

        int vote;
        public int Vote
        {
            get { return vote; }
            set { this.vote = value; }
        }

        string registrationStatus;
        public string RegistrationStatus
        {
            get { return registrationStatus; }
            set { registrationStatus = value; }
        }

        //default constructor
        public Users()
        { }
        //parametrized constructor
        public Users(string name, string emailID, string password, string role, char gender, DateTime dateOfBirth, string areaOfInterest, string interest, string licenseNumber, string specialization, int vote)
        {
            Name = name;
            EmailID = emailID;
            Password = password;
            Role = role;
            Gender = gender;
            AreaOfInterest = areaOfInterest;
            LicenseNumber = licenseNumber;
            Specialization = specialization;
            Vote = vote;

        }
    }
}
