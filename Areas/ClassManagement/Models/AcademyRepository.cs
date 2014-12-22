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

        public IQueryable<Academy> Search(String[] items)
        {
            IQueryable<Academy> academies = context.Academies;
            if (items[0] != "")
            {
                academies = academies.Where(a => items.Contains(a.Name));
            }
            return academies;
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