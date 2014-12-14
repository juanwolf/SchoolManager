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

        public void convertClassroomModelToClassroom(ClassroomModel classroom, Classroom c)
        {
            c.Id = classroom.Id;
            c.Establishment_Id = classroom.Establishment_Id;
            c.Title = classroom.Title;
            c.Year_Id = classroom.Year_Id;
            c.User_Id = classroom.User_Id;
        }

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
        [HttpGet]
        public ActionResult Create()
        {
            using (var entity = new Entities())
            {
                ClassroomModel classroom = new ClassroomModel();
                YearRepository yearRepo = new YearRepository(entity);
                EstablishmentRepository establishmentRepo = new EstablishmentRepository(entity);
                UserRepository userRepo = new UserRepository(entity);
                Dictionary<EstablishmentModel, UserModel> establishmentManager = new Dictionary<EstablishmentModel, UserModel>();
                var establishments = establishmentRepo.All().Select(u => new EstablishmentModel
                {
                    id = u.Id,
                    Name = u.Name,
                    User_Id = u.User_Id
                }).ToList();
                foreach(EstablishmentModel establishment in establishments) 
                {
                    UserModel user = userRepo.getById(establishment.User_Id).Select(u => new UserModel {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Id = u.Id
                    }).First();
                    establishmentManager[establishment] = user;
                }
                ViewData["establishmentManager"] = establishmentManager;
                ViewData["years"] = yearRepo.All().Select(y => new YearModel
                {
                    Id = y.Id,
                    Year1 = y.Year1
                }).ToList();
                /*ViewData["users"] = userRepo.All().Select(u => new UserModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                }).ToList();
                ViewData["establishments"] = establishmentRepo.All().Select(u => new EstablishmentModel
                {
                    id = u.Id,
                    Name = u.Name
                }).ToList();*/
                return View(classroom);
            }
        }
        [HttpPost]
        public ActionResult Create(ClassroomModel classroom)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities())
                {
                    ClassroomRepository repo = new ClassroomRepository(entity);
                    EstablishmentRepository establishmentRepo = new EstablishmentRepository(entity);
                    classroom.User_Id = establishmentRepo.getById(classroom.Establishment_Id).First().User_Id;
                    classroom.Id = Guid.NewGuid();
                    Classroom c = new Classroom();
                    convertClassroomModelToClassroom(classroom, c);
                    repo.Add(c);
                    repo.Save();
                }

            }
            return View("~/Areas/ClassManagement/Views/Classroom/Read.cshtml", classroom.Id);
        }
    }
}
