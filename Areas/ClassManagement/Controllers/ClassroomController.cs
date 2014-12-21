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
                List<ClassroomModel> classrooms = repo.All().Select(c => new ClassroomModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    User_Id = c.User_Id,
                    Year_Id = c.Year_Id,
                    Establishment_Id = c.Establishment_Id,
                    Establishment_Name = c.Establishment.Name,
                    Year1 = c.Year.Year1,
                    User_Name = c.User.FirstName + " " + c.User.LastName,
                }).ToList();
                return View(classrooms);
            };
        }

        [HttpGet]
        public ActionResult Create(Guid? Year_Id, Guid? Establishment_Id)
        {
            using (var entity = new Entities())
            {
                ClassroomModel classroom = new ClassroomModel();
                if (Year_Id.HasValue)
                {
                    classroom.Year_Id = (Guid) Year_Id;
                }
                if (Establishment_Id.HasValue)
                {
                    classroom.Establishment_Id = (Guid)Establishment_Id;
                }
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
                    UserRepository userRepo = new UserRepository(entity);
                    classroom.User_Id = establishmentRepo.getById(classroom.Establishment_Id).First().User_Id;
                    classroom.Establishment_Name = establishmentRepo.getById(classroom.Establishment_Id).First().Name;
                    classroom.pupils = new List<PupilModel>();
                    classroom.evaluations = new List<EvaluationModel>();
                    classroom.User_Name = userRepo.getById(classroom.User_Id).First().FirstName + " " + userRepo.getById(classroom.User_Id).First().LastName;
                    classroom.Id = Guid.NewGuid();
                    Classroom c = new Classroom();
                    convertClassroomModelToClassroom(classroom, c);
                    repo.Add(c);
                    repo.Save();
                    return View("~/Areas/ClassManagement/Views/Classroom/Read.cshtml", classroom);
                }

            }
            else
            {
                return View("~/Areas/ClassManagement/Views/Classroom/Create.cshtml", classroom);
            }
        }

        [HttpGet]
        public ActionResult Read(Guid id)
        {
            using (var entity = new Entities())
            {
                ClassroomRepository repo = new ClassroomRepository(entity);
                PupilRepository pupilRepo = new PupilRepository(entity);
                EvaluationRepository evaluationRepo = new EvaluationRepository(entity);
                ClassroomModel classroom = repo.getById(id).Select(c => new ClassroomModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    User_Id = c.User_Id,
                    Year_Id = c.Year_Id,
                    Establishment_Id = c.Establishment_Id,
                    Establishment_Name = c.Establishment.Name,
                    Year1 = c.Year.Year1,
                    User_Name = c.User.FirstName + " " + c.User.LastName,
                }).First();
                classroom.pupils = pupilRepo.getByClassroom(id).Select(p => new PupilModel{
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Sex = p.Sex,
                    BirthdayDate = p.BirthdayDate,
                    State = p.State,
                    Tutor_Id = p.Tutor_Id,
                    TutorName = p.Tutor.FirstName + " " + p.Tutor.LastName,
                    Classroom_Id = p.Classroom_Id,
                    ClassroomTitle = p.Classroom.Title,
                    Level_Id = p.Level_Id,
                    LevelTitle = p.Level.Title
                }).ToList();
                classroom.evaluations = evaluationRepo.getByClassroom(id).Select(e => new EvaluationModel
                {
                    Id = e.Id,
                    Classroom_Id = e.Classroom_Id,
                    User_Id = e.User_Id,
                    Period_Id = e.Period_Id,
                    Date = e.Date,
                    TotalPoint = e.TotalPoint
                }).ToList();
                return View(classroom);
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            using (var entity = new Entities())
            {
                ClassroomRepository repo = new ClassroomRepository(entity);
                ClassroomModel classroom = repo.getById(id).Select(c => new ClassroomModel
                {
                    Id = c.Id,
                    Establishment_Id = c.Establishment_Id,
                    Title = c.Title,
                    Year_Id = c.Year_Id,
                    User_Id = c.User_Id
                }).First();
                EstablishmentRepository establishmentRepo = new EstablishmentRepository(entity);
                UserRepository userRepo = new UserRepository(entity);
                YearRepository yearRepo = new YearRepository(entity);
                Dictionary<EstablishmentModel, UserModel> establishmentManager = new Dictionary<EstablishmentModel, UserModel>();
                
                var establishments = establishmentRepo.All().Select(u => new EstablishmentModel
                {
                    id = u.Id,
                    Name = u.Name,
                    User_Id = u.User_Id
                }).ToList();
                foreach (EstablishmentModel establishment in establishments)
                {
                    UserModel user = userRepo.getById(establishment.User_Id).Select(u => new UserModel
                    {
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
                return View("~/Areas/ClassManagement/Views/Classroom/Edit.cshtml", classroom);
            }
        }

        [HttpPost]
        public ActionResult Edit(ClassroomModel classroom)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities())
                {
                    ClassroomRepository repo = new ClassroomRepository(entity);
                    EstablishmentRepository establishmentRepo = new EstablishmentRepository(entity);
                    classroom.User_Id = establishmentRepo.getById(classroom.Establishment_Id).First().User_Id;
                    Classroom c = repo.getById(classroom.Id).First();
                    convertClassroomModelToClassroom(classroom, c);
                    repo.Save();
                }

            }
            return RedirectToAction("Index"); ;
        }
    }
}
