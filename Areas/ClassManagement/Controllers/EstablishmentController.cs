using SchoolManager.Areas.ClassManagement.Models;
using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.Areas.ClassManagement.Controllers
{
    public class EstablishmentController : Controller
    {

        private void setViewData()
        {
            using (var entity = new Entities())
            {
                AcademyRepository academy = new AcademyRepository(entity);
                UserRepository userRepo = new UserRepository(entity);
                ViewData["academies"] = academy.All().Select(u => new AcademyModel
                {
                    Id = u.Id,
                    Name = u.Name
                }).ToList();
                ViewData["users"] = userRepo.All().Select(u => new UserModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                }).ToList();
            }
        }

        public void convertEstablishmentModelToEstablishment(EstablishmentModel establishment, Establishment e)
        {
            e.Id = establishment.id;
            e.Name = establishment.Name;
            e.Address = establishment.Address;
            e.PostCode = establishment.PostCode;
            e.Town = establishment.Town;
            e.User_Id = establishment.User_Id;
            e.Academie_Id = establishment.Academie_Id;
        }

        public ActionResult Index()
        {
            using (var entity = new Entities())
            {
                var repo = new EstablishmentRepository(entity);
                var repoAcademy = new AcademyRepository(entity);
                List<EstablishmentModel> establishments = repo.All().Join(entity.Academies,
                    (e => e.Academie_Id), (ac => ac.Id), (e, ac) => new EstablishmentModel
                    {
                    id = e.Id,
                    Name = e.Name,
                    Address = e.Address,
                    PostCode = e.PostCode,
                    Town = e.Town,                
                    Academie_Id = e.Academie_Id,
                    AcademyName = ac.Name
                    }).ToList();

                return View(establishments);
            };
        }
        public ActionResult Read(Guid id)
        {
            using (var entity = new Entities())
            {
                var establishmentRepo = new EstablishmentRepository(entity);
                var classroomRepo = new ClassroomRepository(entity);
                var academyRepo = new AcademyRepository(entity);
                var UserRepo = new UserRepository(entity);
                EstablishmentModel establishment = establishmentRepo.getById(id).Select(p => new EstablishmentModel
                {
                    id = p.Id,
                    Name = p.Name,
                    Address = p.Address,
                    PostCode = p.PostCode,
                    Town = p.Town,
                    Academie_Id = p.Academie_Id,
                    AcademyName = p.Academy.Name,
                    UserName = p.User.FirstName + " " + p.User.LastName,
                    User_Id = p.User_Id
                }).First();
                establishment.Classrooms = classroomRepo.getByEstablishment(id).Select(c => new ClassroomModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    User_Id = c.User_Id,
                    Year_Id = c.Year_Id,
                    Establishment_Id = c.Establishment_Id,
                    Establishment_Name = c.Establishment.Name,
                    Year1 = c.Year.Year1,
                    User_Name = c.User.FirstName + " " + c.User.LastName
                }).ToList();
                return View(establishment);
            }
        }

        [HttpGet]
        public ActionResult Create(Guid? Academy_Id)
        {
            using (var entity = new Entities()) {
                EstablishmentModel establishment = new EstablishmentModel();
                if (Academy_Id.HasValue)
                {
                    establishment.Academie_Id = (Guid)Academy_Id;
                }
                setViewData();
                return View(establishment);
            }
        }

        [HttpPost]
        public ActionResult Create(EstablishmentModel establishment)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities())
                {
                    EstablishmentRepository repo = new EstablishmentRepository(entity);

                    establishment.id = Guid.NewGuid();
                    Establishment e = new Establishment();
                    convertEstablishmentModelToEstablishment(establishment, e);
                    repo.Add(e);
                    repo.Save();
                }
                return RedirectToAction("Read", new { id = establishment.id });
            }
            setViewData();
            return View(establishment);
            
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            using (var entity = new Entities())
            {
                EstablishmentRepository repo = new EstablishmentRepository(entity);
                EstablishmentModel establishment = repo.getById(id).Select(a => new EstablishmentModel
                {
                    id = a.Id,
                    Name = a.Name,
                    Address = a.Address,
                    PostCode = a.PostCode,
                    Town = a.Town,
                    Academie_Id = a.Academie_Id,
                    User_Id = a.User_Id
                }).First();
                AcademyRepository academy = new AcademyRepository(entity);
                UserRepository userRepo = new UserRepository(entity);
                ViewData["academies"] = academy.All().Select(u => new AcademyModel
                {
                    Id = u.Id,
                    Name = u.Name
                }).ToList();
                ViewData["users"] = userRepo.All().Select(u => new UserModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                }).ToList();
                return View("~/Areas/ClassManagement/Views/Establishment/Edit.cshtml", establishment);
            }
        }

        [HttpPost]
        public ActionResult Edit(EstablishmentModel establishment)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities())
                {
                    EstablishmentRepository repo = new EstablishmentRepository(entity);
                    Establishment e = repo.getById(establishment.id).First();
                    convertEstablishmentModelToEstablishment(establishment, e);
                    repo.Save();
                }
                return RedirectToAction("Read", new { id = establishment.id });
            }
            setViewData();
            return View(establishment);

            
        }

        [HttpPost]
        public ActionResult Search(string query)
        {
            using (var entity = new Entities())
            {
                String[] results = query.Split(new Char[] { ' ', ',' });
                var repo = new EstablishmentRepository(entity);
                var establishments = repo.Search(results).Select(p => new EstablishmentModel
                {
                    id = p.Id,
                    Name = p.Name,
                    Address = p.Address,
                    PostCode = p.PostCode,
                    Town = p.Town,
                    Academie_Id = p.Academie_Id,
                    AcademyName = p.Academy.Name,
                    UserName = p.User.FirstName + " " + p.User.LastName,
                    User_Id = p.User_Id
                }).ToList();

                return PartialView("~/Areas/ClassManagement/Views/Shared/_EstablishmentResults.cshtml", establishments);
            }
        }
    }
}
