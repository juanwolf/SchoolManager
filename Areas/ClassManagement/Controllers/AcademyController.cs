using SchoolManager.Areas.ClassManagement.Models;
using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.Areas.ClassManagement.Controllers
{
    public class AcademyController : Controller
    {
        //
        // GET: /ClassManagement/Academy/

        public void convertAcademyModelToAcademy(AcademyModel academy, Academy a)
        {
            a.Id = academy.Id;
            a.Name = academy.Name; 
        }

        public ActionResult Index()
        {
            using (var entity = new Entities())
            {
                var repo = new AcademyRepository(entity);
                List<AcademyModel> academies = repo.All().Select(s => new AcademyModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();

                return View(academies);
            };
        }
        public ActionResult Read(Guid id)
        {
            using (var entity = new Entities())
            {
                var establishmentRepo = new EstablishmentRepository(entity);
                var academyRepo = new AcademyRepository(entity);
                AcademyModel academy = academyRepo.getById(id).Select(a => new AcademyModel
                {
                    Id = a.Id,
                    Name = a.Name
                }).First();
                List<EstablishmentModel> establishments = establishmentRepo.getByAcademy(id).Select(p => new EstablishmentModel
                {
                    id = p.Id,
                    Name = p.Name,
                    PostCode = p.PostCode,
                    Address = p.Address,
                    Town = p.Town,
                    User_Id = p.User_Id,
                    Academie_Id = p.Academie_Id
                }).ToList();
                academy.establishments = establishments;
                return View(academy);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            AcademyModel academy = new AcademyModel();
            return View(academy);
        }

        [HttpPost]
        public ActionResult Create(AcademyModel academy)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities())
                {
                    AcademyRepository repo = new AcademyRepository(entity);
                    academy.Id = Guid.NewGuid();
                    Academy a = new Academy();
                    convertAcademyModelToAcademy(academy, a);
                    repo.Add(a);
                    repo.Save();
                }

            }
            return View("~/Areas/ClassManagement/Views/Academy/Read.cshtml", academy.Id);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            using (var entity = new Entities())
            {
                AcademyRepository repo = new AcademyRepository(entity);
                AcademyModel academy = repo.getById(id).Select(a => new AcademyModel
                {
                    Id = a.Id,
                    Name = a.Name
                }).First();
                return View("~/Areas/ClassManagement/Views/Academy/Edit.cshtml", academy);
            }
        }

        [HttpPost]
        public ActionResult Edit(AcademyModel academy)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities())
                {
                    AcademyRepository repo = new AcademyRepository(entity);
                    Academy a = repo.getById(academy.Id).First();
                    convertAcademyModelToAcademy(academy, a);
                    repo.Save();
                }

            }
            return View("~/Areas/ClassManagement/Views/Academy/Read.cshtml", academy);
        }
    }
}
