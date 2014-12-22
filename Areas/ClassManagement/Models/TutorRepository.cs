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

        public IQueryable<Tutor> Search(String[] items)
        {
            IQueryable<Tutor> tutors = context.Tutors;
            if (items[0] != "")
            {
                tutors = tutors.Where(s => items.Contains(s.FirstName)
                        || items.Contains(s.LastName)
                        || items.Contains(s.PostCode)
                        || items.Contains(s.Town)
                        || items.Contains(s.Mail));
            }
            return tutors;
        }

        public void Add(Tutor t) {
            context.Tutors.Add(t);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}