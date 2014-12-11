using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class PeriodRepository
    {
         public Entities context;

        public PeriodRepository(Entities ent)
        {
            context = ent;
        }

        public IQueryable<Period> All() {
            return context.Periods;
        }

        public IQueryable<Period> getById(Guid id)
        {
            return context.Periods.Where(s => s.Id == id);
        }

        public IQueryable<Period> getByYear(Guid id)
        {
            return context.Periods.Where(p => p.Year_Id == id);
        }

    }
}