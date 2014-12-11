using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class LevelModel
    {
        public Guid Id {
            get;
            set;
        }
        public string Title {
            get;
            set;
        }
        public Guid Cycle_Id { 
            get;
            set;
        }

        public String CycleName
        {
            get;
            set;
        }
    }
}