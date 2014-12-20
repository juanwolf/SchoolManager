using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class EvaluationModel
    {
        public Guid Id
        {
            get;
            set;
        }

        public Guid Classroom_Id
        {
            get;
            set;
        }

        public String Classroom_Title
        {
            get;
            set;
        }

        public Guid User_Id
        {
            get;
            set;
        }

        public String User_Name
        {
            get;
            set;
        }

        public Guid Period_Id
        {
            get;
            set;
        }

        public DateTime Period_Begin
        {
            get;
            set;
        }

        public DateTime Period_End
        {
            get;
            set;
        }

        public int Year1
        {
            get;
            set;
        }

        public Guid Year_Id
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public int TotalPoint
        {
            get;
            set;
        }

        public List<ResultModel> Results
        {
            get;
            set;
        }

        public int Results_Number
        {
            get;
            set;
        }

        public Boolean HasResults
        {
            get { return Results_Number != 0; }
        }


    }
}