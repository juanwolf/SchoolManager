using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Areas.ClassManagement.Models
{
    public class EstablishmentModel
    {
        public Guid id
        {
            get;
            set;
        }

        public String Name
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

        public String UserName
        {
            get;
            set;
        }

        public Guid User_Id
        {
            get;
            set;
        }

        public Guid Academie_Id
        {
            get;
            set;
        }

        public String AcademyName
        {
            get;
            set;
        }

    }
}