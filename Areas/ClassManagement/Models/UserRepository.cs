using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Areas.ClassManagement.Models
{
    public class UserRepository
    {

         public Entities context;

        public UserRepository(Entities ent)
        {
            context = ent;
        }

        public IQueryable<User> All() {
            return context.Users;
        }

        public IQueryable<User> getById(Guid id)
        {
            return context.Users.Where(u => u.Id == id);
        }
    }
}