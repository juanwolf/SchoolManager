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

        public ActionResult Create()
        {
            Guid Id = Guid.NewGuid();
            return View();
        }

    }
}
