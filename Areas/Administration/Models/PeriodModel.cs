using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class PeriodModel
    {
        public Guid Id
        {
            get;
            set;
        }

        public DateTime Begin
        {
            get;
            set;
        }

        public DateTime End
        {
            get;
            set;
        }

        public Guid Year_Id
        {
            get;
            set;
        }

        public int Year1
        {
            get;
            set;
        }

        public List<EvaluationModel> Evaluations
        {
            get;
            set;
        }

    }
}