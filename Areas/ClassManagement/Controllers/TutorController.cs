using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.Areas.ClassManagement.Controllers
{
    public class TutorController : Controller
    {
        //
        // GET: /Tutor/

        public void convertTutorModelToTutor(TutorModel tutor, Tutor t)
        {
            t.Id = tutor.Id;
            t.LastName = tutor.LastName;
            t.Address = tutor.Address;
            t.FirstName = tutor.FirstName;
            t.Mail = tutor.Mail;
            t.PostCode = tutor.PostCode;
            t.Tel = tutor.Tel;
            t.Town = tutor.Town;
            t.Comment = tutor.Comment;
        }

        public ActionResult Index()
        {
            using (var entity = new Entities())
            {
                var repo = new TutorRepository(entity);
                List<TutorModel> tutors = repo.All().Select(s => new TutorModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Address = s.Address,
                    PostCode = s.PostCode,
                    Town = s.Town,
                    Tel = s.Tel,
                    Mail = s.Mail,
                    Comment = s.Comment
                }).ToList();

                return View(tutors);
            };
        }
        public ActionResult Read(Guid id)
        {
            using (var entity = new Entities())
            {
                var pupilsRepo = new PupilRepository(entity);
                var tutorRepo = new TutorRepository(entity);
                TutorModel tutor = tutorRepo.getById(id).Select(t => new TutorModel
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Address = t.Address,
                    PostCode = t.PostCode,
                    Town = t.Town,
                    Tel = t.Tel,
                    Mail = t.Mail,
                    Comment = t.Comment
                }).First();
                List<PupilModel> pupils = pupilsRepo.getByTutor(id).Select(p => new PupilModel
                {
                    BirthdayDate = p.BirthdayDate,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Sex = p.Sex,
                    State = p.State,
                    Level_Id = p.Level_Id,
                    LevelTitle = p.Level.Title,
                    Tutor_Id = tutor.Id,
                    TutorName = tutor.FirstName + " " + tutor.LastName,
                    ClassroomTitle = p.Classroom.Title,
                    Classroom_Id = p.Classroom_Id
                }).ToList();
                tutor.pupils = pupils;
                return View(tutor);
            }
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            TutorModel tutor = new TutorModel();
            
            return View(tutor);
        }

        [HttpPost]
        public ActionResult Create(TutorModel tutor)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities()) {
                    TutorRepository repo = new TutorRepository(entity);
                    tutor.Id = Guid.NewGuid();
                    Tutor t = new Tutor();
                    convertTutorModelToTutor(tutor, t);
                    repo.Add(t);
                    repo.Save();
                }
                
            }
            return View("~/Areas/ClassManagement/Views/Tutor/Index.cshtml", tutor);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            using (var entity = new Entities())
            {
                TutorRepository repo = new TutorRepository(entity);
                TutorModel tutor = repo.getById(id).Select(t => new TutorModel
                {
                    Id = t.Id,
                    Address = t.Address,
                    Comment = t.Comment,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Mail = t.Mail,
                    PostCode = t.PostCode,
                    Tel = t.Tel,
                    Town = t.Town,
                }).First();
                return View("~/Areas/ClassManagement/Views/Tutor/Edit.cshtml", tutor);
            }
        }

        [HttpPost]
        public ActionResult Edit(TutorModel tutor)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities())
                {
                    TutorRepository repo = new TutorRepository(entity);
                    Tutor t = repo.getById(tutor.Id).First();
                    convertTutorModelToTutor(tutor, t);
                    repo.Save();
                }

            }
            return View("~/Areas/ClassManagement/Views/Tutor/Read.cshtml", tutor);
        }

        [HttpPost]
        public ActionResult Search(string query)
        {
            using (var entity = new Entities())
            {
                String[] results = query.Split(new Char[] { ' ', ',' });
                var repo = new TutorRepository(entity);
                var tutors = repo.Search(results).Select(s => new TutorModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Address = s.Address,
                    PostCode = s.PostCode,
                    Town = s.Town,
                    Tel = s.Tel,
                    Mail = s.Mail,
                    Comment = s.Comment
                }).ToList();

                return PartialView("~/Areas/ClassManagement/Views/Shared/_TutorResults.cshtml", tutors);
            }
        }
    }
}
