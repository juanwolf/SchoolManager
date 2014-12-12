using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.Areas.Administration.Controllers
{
    public class PeriodController : Controller
    {
        //
        // GET: /Period/

        public ActionResult Index()
        {
            using (var entity = new Entities())
            {
                var repo = new PeriodRepository(entity);
                List<PeriodModel> periods = repo.All().Join(entity.Years, (p => p.Year_Id), (y => y.Id), (p, y) => new PeriodModel
                {
                    Id = p.Id,
                    Begin = p.Begin,
                    End = p.End,
                    Year_Id = p.Year_Id,
                    Year1 = y.Year1
                }).OrderBy(p => p.Year1).ToList();

                return View(periods);
            }
        }

        public ActionResult Read(Guid id)
        {
            using (var entity = new Entities())
            {
                var periodRepo = new PeriodRepository(entity);
                var yearRepo = new YearRepository(entity);
                var evaluationRepo = new EvaluationRepository(entity);
                PeriodModel period = periodRepo.getById(id).Join(entity.Years, (p => p.Year_Id), (y => y.Id), (p, y) => new PeriodModel
                {
                    Id = p.Id,
                    Begin = p.Begin,
                    End = p.End,
                    Year_Id = p.Year_Id,
                    Year1 = y.Year1
                }).First();

                List<EvaluationModel> evals = evaluationRepo.getByPeriod(id).Select(e => new EvaluationModel
                {
                    Date = e.Date,
                    TotalPoint = e.TotalPoint,
                }).ToList();

                period.Evaluations = evals;
                

                return View(period);
            }
        }

    }
}
