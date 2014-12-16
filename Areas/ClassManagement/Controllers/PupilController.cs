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
        public void convertPupilModelToPupil(PupilModel pupil, Pupil p)
        {
            p.Id = pupil.Id;
            p.LastName = pupil.LastName;
            p.FirstName = pupil.FirstName;
            p.Classroom_Id = pupil.Classroom_Id;
            p.Sex = pupil.Sex;
            p.State = 1;
            p.BirthdayDate = pupil.BirthdayDate;
            p.Tutor_Id = pupil.Tutor_Id;
            p.Level_Id = pupil.Level_Id;
            p.Classroom_Id = pupil.Classroom_Id;
        }

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
                    Level_Id = p.Level_Id,
                    TutorName = p.Tutor.FirstName + " " + p.Tutor.LastName,
                    LevelTitle = p.Level.Title,
                    ClassroomTitle = p.Classroom.Title
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

        [HttpPost]
        public ActionResult Create(PupilModel pupil)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities())
                {
                    PupilRepository repo = new PupilRepository(entity);
                    pupil.Id = Guid.NewGuid();
                    Pupil p = new Pupil();
                    convertPupilModelToPupil(pupil, p);
                    repo.Add(p);
                    repo.Save();
                    return View("~/Areas/ClassManagement/Views/Pupil/Read.cshtml", pupil);
                }

            }
            else
            {
                return View("~/Areas/ClassManagement/Views/Pupil/Create.cshtml", pupil);
            }
        }


    }
}
