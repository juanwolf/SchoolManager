using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Areas.ClassManagement.Models
{
    public class AcademyRepository
    {

        public Entities context;

        public AcademyRepository(Entities ent)
        {
            context = ent;
        }

        public IQueryable<Academy> All() {
            return context.Academies;
        }

        public IQueryable<Academy> getById(Guid id)
        {
            return context.Academies.Where(r => r.Id == id);
        }

        public void Add(Academy a)
        {
            context.Academies.Add(a);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}