using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class TutorModel
    {
        public Guid Id
        {
            get;
            set;
        }

        public String LastName
        {
            get;
            set;
        }

        public String FirstName
        {
            get;
            set;
        }

        public String Address
        {
            get;
            set;
        }

        public String PostCode
        {
            get;
            set;
        }

        public String Town
        {
            get;
            set;
        }

        public String Tel
        {
            get;
            set;
        }

        public String Mail
        {
            get;
            set;
        }

        public String Comment
        {
            get;
            set;
        }

        public List<PupilModel> pupils
        {
            get;
            set;
        }

        public TutorModel() { }

        public TutorModel(Guid id, String lastName, String firstName, String address, String postcode, String town, String tel, String mail, String comment)
        {
            this.Id = id;
            this.LastName = lastName;
            this.Address = address;
            this.PostCode = postcode;
            this.Town = town;
            this.Tel = tel;
            this.Mail = mail;
            this.Comment = comment;
        }
    }
}