using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class LevelRepository
    {
        public Entities context;
        public LevelRepository(Entities e)
        {
            context = e;
        }

        public IQueryable<Level> All()
        {
            return context.Levels;
        }

        public IQueryable<Level> getById(Guid id)
        {
            return context.Levels.Where(s => s.Id == id);
        }

        public IQueryable<Level> getByCycleId(Guid id)
        {
            return context.Levels.Where(s => s.Cycle_Id == id);
        }
    }
}