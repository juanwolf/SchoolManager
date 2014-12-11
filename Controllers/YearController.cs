using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.Controllers
{
    public class YearController : Controller
    {
        //
        // GET: /Year/

        public ActionResult Index()
        {
            using (var entity = new Entities())
            {
                var repo = new YearRepository(entity);
                List<YearModel> years = repo.All().Select(y => new YearModel
                    {
                        Id = y.Id,
                        Year1 = y.Year1

                    }).OrderBy(y => y.Year1).ToList();

                return View(years);
            }
        }


        public ActionResult Read(Guid id)
        {
            using (var entity = new Entities())
            {
                var periodsRepo = new PeriodRepository(entity);
                var classroomRepo = new ClassroomRepository(entity);
                var yearRepo = new YearRepository(entity);
                List<PeriodModel> periodsFound = periodsRepo.getByYear(id).Select(p => new PeriodModel{
                    Begin = p.Begin,
                    End = p.End,
                    Id = p.Id,
                    Year_Id = p.Year_Id
                }).ToList();

                List<ClassroomModel> classroomsFound = classroomRepo.getByYear(id).Select(c => new ClassroomModel {
                    Title = c.Title,
                    Id = c.Id,
                    User_Id = c.User_Id,
                    Establishment_Id = c.Establishment_Id
                }).ToList();
                YearModel year = yearRepo.getById(id).Select(y => new YearModel
                {
                    Id = y.Id,
                    Year1 = y.Year1
                }).First();

                year.classrooms = classroomsFound;
                year.periods = periodsFound;

                return View(year);
            }
        }
    }
}
