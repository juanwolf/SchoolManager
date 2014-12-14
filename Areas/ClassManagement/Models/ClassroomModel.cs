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

        public String Establishment_Name
        {
            get;
            set;
        }

        public string User_Name
        {
            get;
            set;
        }

        public String Year1 
        { 
            get;
            set;
        }

        public List<PupilModel> pupils 
        { 
            get;
            set;
        }

        public List<EvaluationModel> evaluations
        {
            get;
            set;
        }
    }
}