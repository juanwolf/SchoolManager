using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class YearModel
    {
        public Guid Id {
            get; set;
        }
        public int Year1 {
            get; set;
        }

        public Guid ClassroomId
        {
            get;
            set;
        }

        public Guid PeriodsId
        {
            get;
            set;
        }

        public List<ClassroomModel> classrooms
        {
            get;
            set;
        }

        public List<PeriodModel> periods
        {
            get;
            set;
        }

    }
}