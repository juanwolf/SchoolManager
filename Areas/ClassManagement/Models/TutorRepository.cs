using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class TutorRepository
    {
        public Entities context;

        public TutorRepository(Entities ent)
        {
            context = ent;
        }

        public IQueryable<Tutor> All() {
            return context.Tutors;
        }

        public IQueryable<Tutor> getById(Guid id)
        {
            return context.Tutors.Where(t => t.Id == id);
        }

        public void Add(Tutor t) {
            context.Tutors.Add(t);
        }

        public void Delete(Tutor t)
        {
            
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}