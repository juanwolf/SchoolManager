using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class CycleRepository
    {

        public Entities context;

        public CycleRepository(Entities ent)
        {
            context = ent;
        }

        public IQueryable<Cycle> All() {
            return context.Cycles;
        }

        public IQueryable<Cycle> getById(Guid id)
        {
            return context.Cycles.Where(s => s.Id == id);
        }
    }
}