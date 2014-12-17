using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class ResultModel
    {
        public Guid Id
        {
            get;
            set;
        }

        public Guid Evaluation_Id
        {
            get;
            set;
        }

        public Guid Pupil_Id
        {
            get;
            set;
        }

        public String Pupil_Name
        {
            get;
            set;
        }

        public double Note
        {
            get;
            set;
        }

        public int EvaluationTotalPoint
        {
            get;
            set;
        }

        public DateTime EvaluationDate
        {
            get;
            set;
        }
    }
}