using SchoolManager.Areas.ClassManagement.Models;
using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.Areas.ClassManagement.Controllers
{
    public class ClassroomController : Controller
    {
        //
        // GET: /ClassManagement/Classroom/

        public ActionResult Index()
        {
            using (var entity = new Entities())
            {
                var repo = new ClassroomRepository(entity);
                var establishmentRepo = new EstablishmentRepository(entity);
                var yearRepo = new YearRepository(entity);
                var userRepo = new UserRepository(entity);
                var query_classrooms =
                    from classroom in entity.Classrooms
                    join establishment in entity.Establishments
                        on classroom.Establishment_Id equals establishment.Id
                    join year in entity.Years
                        on classroom.Year_Id equals year.Id
                    join user in entity.Users
                        on classroom.User_Id equals user.Id
                    select new ClassroomModel {
                        Id = classroom.Id,
                        Title = classroom.Title,
                        User_Id = classroom.User_Id,
                        Year_Id = classroom.Year_Id,
                        Establishment_Id = classroom.Establishment_Id,
                        Establishment_Name = establishment.Name,
                        Year1 = year.Year1,
                        User_Name = user.FirstName + " " + user.LastName,
                    };
                List<ClassroomModel> classrooms = query_classrooms.ToList();
                /*List<ClassroomModel> classrooms = repo.All().Join(entity.Establishments,
                    c => c.Establishment_Id,
                    e => e.Id,
                    (c, e) => new ClassroomModel
                    {
                        Id = c.Id,
                        Title = c.Title,
                        User_Id = c.User_Id,
                        Year_Id = c.Year_Id,
                        Establishment_Id = c.Establishment_Id,
                        Establishment_Name = establishmentRepo.getById(c.Establishment_Id).First().Name
                    }).Join(entity.Years,
                    c => c.Establishment_Id,
                    e => e.Id,
                    (c, e) => new ClassroomModel).ToList();
                User_Name =
                            userRepo.getById(c.User_Id).First().FirstName 
                            + " "
                            + userRepo.getById(c.User_Id).First().LastName,
                        Year1 = yearRepo.getById(c.Year_Id).First().Year1,
                        */
                return View(classrooms);
            };
        }

    }
}
