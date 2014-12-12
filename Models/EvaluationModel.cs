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

        public Guid User_Id
        {
            get;
            set;
        }

        public Guid Period_Id
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
    }
}