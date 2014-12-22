using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Areas.ClassManagement.Models
{
    public class EstablishmentRepository
    {

        public Entities context;

        public EstablishmentRepository(Entities ent)
        {
            context = ent;
        }

        public IQueryable<Establishment> All() {
            return context.Establishments;
        }

        public IQueryable<Establishment> getById(Guid id)
        {
            return context.Establishments.Where(s => s.Id == id);
        }

        public IQueryable<Establishment> getByAcademy(Guid id)
        {
            return context.Establishments.Where(c => c.Academie_Id == id);
        }

        public IQueryable<Establishment> getByUser(Guid id)
        {
            return context.Establishments.Where(c => c.User_Id == id);
        }

        public IQueryable<Establishment> Search(String[] items)
        {
            IQueryable<Establishment> establishments = context.Establishments;
            if (items[0] != "")
            {
                establishments = establishments.Where(s => items.Contains(s.Name)
                        || items.Contains(s.Town)
                        || items.Contains(s.PostCode)
                        || items.Contains(s.User.LastName)
                        || items.Contains(s.Academy.Name));
            }
            return establishments;
        }

        public void Add(Establishment e)
        {
            context.Establishments.Add(e);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}