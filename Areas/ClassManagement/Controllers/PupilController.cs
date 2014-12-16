using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.Areas.ClassManagement.Controllers
{
    public class PupilController : Controller
    {
        //
        // GET: /Pupil/

        public ActionResult Index()
        {
            using ( var entity = new Entities() )
            {
                var pupilRepo = new PupilRepository(entity);
                List<PupilModel> pupils = pupilRepo.All().Select(p => new PupilModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Sex = p.Sex,
                    BirthdayDate = p.BirthdayDate,
                    State = p.State,
                    Tutor_Id = p.Tutor_Id,
                    Classroom_Id = p.Classroom_Id,
                    Level_Id = p.Level_Id
                }).ToList();
                return View(pupils);
            }
        }

        public ActionResult Read(Guid id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (var entity = new Entities())
            {
                PupilModel pupil = new PupilModel();
                LevelRepository levelRepo = new LevelRepository(entity);
                TutorRepository tutorRepo = new TutorRepository(entity);
                ClassroomRepository classroomRepo = new ClassroomRepository(entity);
                var levels = levelRepo.All().Select(u => new LevelModel
                {
                    Id = u.Id,
                    Title = u.Title,
                    CycleName = u.Cycle.Title
                }).ToList();
                ViewData["levels"] = levels;
                var classrooms = classroomRepo.All().Select(c => new ClassroomModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    User_Name = c.User.FirstName + " " + c.User.LastName,
                    Year1 = c.Year.Year1,
                    Establishment_Name = c.Establishment.Name
                }).ToList();
                ViewData["classrooms"] = classrooms;
                var tutors = tutorRepo.All().Select(t => new TutorModel
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName
                }).ToList();
                ViewData["tutors"] = tutors;
                return View(pupil);
            }
        }

        /*[HttpPost]
        public ActionResult Create(PupilModel classroom)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities())
                {
                    PupilRepository repo = new PupilRepository(entity);
                    EstablishmentRepository establishmentRepo = new EstablishmentRepository(entity);
                    UserRepository userRepo = new UserRepository(entity);
                    classroom.User_Id = establishmentRepo.getById(classroom.Establishment_Id).First().User_Id;
                    classroom.Establishment_Name = establishmentRepo.getById(classroom.Establishment_Id).First().Name;
                    classroom.pupils = new List<PupilModel>();
                    classroom.evaluations = new List<EvaluationModel>();
                    classroom.User_Name = userRepo.getById(classroom.User_Id).First().FirstName + " " + userRepo.getById(classroom.User_Id).First().LastName;
                    classroom.Id = Guid.NewGuid();
                    Pupil c = new Pupil();
                    convertPupilModelToPupil(classroom, c);
                    repo.Add(c);
                    repo.Save();
                    return View("~/Areas/ClassManagement/Views/Pupil/Read.cshtml", classroom);
                }

            }
            else
            {
                return View("~/Areas/ClassManagement/Views/Pupil/Create.cshtml", classroom);
            }
        }*/


    }
}
