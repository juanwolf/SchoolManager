using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class ClassroomModel
    {
        public Guid Id
        {
            get;
            set;
        }

        public String Title
        {
            get;
            set;
        }

        public Guid User_Id
        {
            get;
            set;
        }

        public Guid Year_Id
        {
            get;
            set;
        }

        public Guid Establishment_Id
        {
            get;
            set;
        }
    }
}