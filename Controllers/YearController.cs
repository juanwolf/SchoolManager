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
                List<YearModel> levels = repo.All().Select(y => new YearModel
                    {
                        Id = y.Id,
                        Year1 = y.Year1

                    }).OrderBy(y => y.Year1).ToList();

                return View(levels);
            }
        }

    }
}
