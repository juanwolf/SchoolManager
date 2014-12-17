using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.Areas.ClassManagement.Controllers
{
    public class EvaluationController : Controller
    {
        //
        // GET: /ClassManagement/Evaluation/

        public ActionResult Index()
        {
            using (var entity = new Entities())
            {
                var evalRepo = new EvaluationRepository(entity);
                List<EvaluationModel> evals = evalRepo.All().Select(e => new EvaluationModel
                {
                    Id = e.Id,
                    Classroom_Id = e.Classroom_Id,
                    Classroom_Title = e.Classroom.Title,
                    User_Id = e.User_Id,
                    User_Name = e.User.FirstName + " " + e.User.LastName,
                    Period_Id = e.Period_Id,
                    Period_Begin = e.Period.Begin,
                    Period_End = e.Period.End,
                    Year1 = e.Period.Year.Year1,
                    Year_Id = e.Period.Year_Id,
                    Date = e.Date,
                    TotalPoint = e.TotalPoint
                }).ToList();
                return View(evals);
            }
        }

    }
}
