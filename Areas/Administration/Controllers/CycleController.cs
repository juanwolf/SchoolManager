using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.Areas.Administration.Controllers
{
    public class CycleController : Controller
    {
        public ActionResult Index()
        {
            using (var entity = new Entities()) {
                var repo = new CycleRepository(entity);
                List<CycleModel> cycles = repo.All().Select(s => new CycleModel
                {
                    Id = s.Id,
                    Title = s.Title
                }).ToList();

                return View(cycles);
            };
        }

        public ActionResult Read(Guid id)
        {
            using (var entity = new Entities())
            {
                var repo = new CycleRepository(entity);
                CycleModel cycle = repo.getById(id).Select(c => new CycleModel {
                    Id = c.Id,
                    Title = c.Title
                }).First();
                var levelrepo = new LevelRepository(entity);
                List<LevelModel> levels = levelrepo.getByCycleId(cycle.Id).Select(s => new LevelModel {
                    Cycle_Id = s.Cycle_Id,
                    CycleName = cycle.Title,
                    Id = s.Id,
                    Title = s.Title
                }).ToList();
                cycle.levels = levels;
                return View(cycle);
            }
        }


    }
}