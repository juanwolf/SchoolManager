using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.Controllers
{
    public class LevelController : Controller
    {
        //
        // GET: /Level/

        public ActionResult Index()
        {
            using (var entity = new Entities())
            {
                var cycleRepo = new CycleRepository(entity);

                var repo = new LevelRepository(entity);
                List<LevelModel> levels = repo.All().Join(entity.Cycles,
                    (lvl => lvl.Cycle_Id), (cycle => cycle.Id), (lvl, cycle) => new LevelModel
                    {
                        Cycle_Id = lvl.Cycle_Id,
                        CycleName = cycle.Title,
                        Id = lvl.Id,
                        Title = lvl.Title
                    }).OrderBy(lvl => lvl.Cycle_Id).ToList();

                return View(levels);
            };
        }

        public ActionResult Read(Guid id)
        {
            using (var entity = new Entities())
            {
                var levelrepo = new LevelRepository(entity);
                LevelModel level = levelrepo.getById(id).Join(entity.Cycles, 
                    (lvl => lvl.Cycle_Id), (cycle => cycle.Id), (lvl, cycle) => new LevelModel
                {
                    Cycle_Id = lvl.Cycle_Id,
                    CycleName = cycle.Title,
                    Id = lvl.Id,
                    Title = lvl.Title
                }).First();
                
                return View(level);
            }
        }

    }
}
