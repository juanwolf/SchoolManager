using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class PupilRepository
    {

         public Entities context;

        public PupilRepository(Entities ent)
        {
            context = ent;
        }

        public IQueryable<Pupil> All() {
            return context.Pupils;
        }

        public IQueryable<Pupil> getById(Guid id)
        {
            return context.Pupils.Where(s => s.Id == id);
        }

        public IQueryable<Pupil> getByLevel(Guid id)
        {
            return context.Pupils.Where(s => s.Level_Id == id);
        }

        public IQueryable<Pupil> getByClassroom(Guid id)
        {
            return context.Pupils.Where(p => p.Classroom_Id == id);
        }

        public IQueryable<Pupil> getByTutor(Guid id)
        {
            return context.Pupils.Where(p => p.Tutor_Id == id);
        }

        public IQueryable<Pupil> Search(String[] items)
        {
            IQueryable<Pupil> pupils = context.Pupils;
            pupils = pupils.Where(s => items.Contains(s.FirstName)
                    || items.Contains(s.LastName)
                    || items.Contains(s.Classroom.Title)
                    || items.Contains(s.Tutor.LastName));
            return pupils;
        }

        public void Add(Pupil p)
        {
            context.Pupils.Add(p);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}