using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Areas.ClassManagement.Models
{
    public class AcademyModel
    {
        public Guid Id
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }

        public List<EstablishmentModel> establishments
        {
            get;
            set;
        }
    }
}