using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class YearRepository
    {
         public Entities context;

        public YearRepository(Entities ent)
        {
            context = ent;
        }

        public IQueryable<Year> All() {
            return context.Years;
        }

        public IQueryable<Year> getById(Guid id)
        {
            return context.Years.Where(s => s.Id == id);
        }
    }
}