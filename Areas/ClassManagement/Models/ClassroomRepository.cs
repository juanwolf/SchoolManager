using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class ClassroomRepository
    {
         public Entities context;

        public ClassroomRepository(Entities ent)
        {
            context = ent;
        }

        public IQueryable<Classroom> All() {
            return context.Classrooms;
        }

        public IQueryable<Classroom> getById(Guid id)
        {
            return context.Classrooms.Where(s => s.Id == id);
        }

        public IQueryable<Classroom> getByUser(Guid id)
        {
            return context.Classrooms.Where(c => c.User_Id == id);
        }

        public IQueryable<Classroom> getByYear(Guid id)
        {
            return context.Classrooms.Where(c => c.Year_Id == id);
        }
        public IQueryable<Classroom> getByEstablishment(Guid id)
        {
            return context.Classrooms.Where(c => c.Establishment_Id == id);
        }

        public IQueryable<Classroom> Search(String[] items)
        {
            IQueryable<Classroom> classrooms = context.Classrooms;
            if (items[0] != "")
            {
                classrooms = classrooms.Where(s => items.Contains(s.Title)
                        || items.Contains(s.User.LastName)
                        || items.Contains(s.User.FirstName)
                        || items.Contains(s.Establishment.Name));
            }
            return classrooms;
        }
        public void Add(Classroom c)
        {
            context.Classrooms.Add(c);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}