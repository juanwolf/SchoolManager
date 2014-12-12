using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class CycleModel
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

        public List<LevelModel> levels {
            get;
            set;
        }
    }
}