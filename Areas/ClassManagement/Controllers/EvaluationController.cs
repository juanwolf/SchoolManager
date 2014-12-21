using SchoolManager.Areas.ClassManagement.Models;
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

        private void convertResultModelToResult(ResultModel result, Result r)
        {
            r.Id = result.Id;
            r.Evaluation_Id = result.Evaluation_Id;
            r.Note = result.Note;
            r.Pupil_Id = result.Pupil_Id;
        }
        
        public void convertEvaluationModelToEvaluation(EvaluationModel evaluation, Evaluation e)
        {
            e.Id = evaluation.Id;
            e.Classroom_Id = evaluation.Classroom_Id;
            e.Date = evaluation.Date;
            e.TotalPoint = evaluation.TotalPoint;
            e.User_Id = evaluation.User_Id;
            e.Period_Id = evaluation.Period_Id;
        }
        
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
                    TotalPoint = e.TotalPoint,
                    Results_Number = e.Results.Count
                }).ToList();
                return View(evals);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (var entity = new Entities()) {
                EvaluationModel eval = new EvaluationModel();
                ClassroomRepository classroomRepo = new ClassroomRepository(entity);
                PeriodRepository periodRepo = new PeriodRepository(entity);
                UserRepository userRepo = new UserRepository(entity);

                ViewData["classrooms"] = classroomRepo.All().Select(c => new ClassroomModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    User_Id = c.User.Id,
                    User_Name = c.User.FirstName + " " + c.User.LastName,
                    Year1 = c.Year.Year1,
                    Establishment_Name = c.Establishment.Name
                }).ToList();
                ViewData["periods"] = periodRepo.All().Select(p => new PeriodModel
                {
                    Id = p.Id,
                    Begin = p.Begin,
                    End = p.End
                }).ToList();
                return View(eval);
            }
        }

        [HttpPost]
        public ActionResult Create(EvaluationModel eval)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities())
                {
                    EvaluationRepository evaluationRepo = new EvaluationRepository(entity);
                    ClassroomRepository classroomRepo = new ClassroomRepository(entity);
                    UserRepository userRepo = new UserRepository(entity);
                    eval.Id = Guid.NewGuid();
                    eval.User_Id = classroomRepo.getById(eval.Classroom_Id).First().User_Id;
                    Evaluation e = new Evaluation();
                    convertEvaluationModelToEvaluation(eval, e);
                    evaluationRepo.Add(e);
                    evaluationRepo.Save();
                    return RedirectToAction("Read", new { @id = eval.Id });
                }
            }
            return View(eval);
        }

        [HttpGet]
        public ActionResult AddResults(Guid id)
        {
            using (var entity = new Entities()) {
                PupilRepository pupilRepo = new PupilRepository(entity);

                EvaluationRepository evalRepo = new EvaluationRepository(entity);
                EvaluationModel eval = evalRepo.getById(id).Select(e => new EvaluationModel
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
                    TotalPoint = e.TotalPoint,
                    Results_Number = e.Results.Count
                    
                }).First();
                List<PupilModel> pupils = pupilRepo.getByClassroom(eval.Classroom_Id).Select(p => new PupilModel {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Sex = p.Sex,
                    BirthdayDate = p.BirthdayDate,
                    State = p.State,
                    Tutor_Id = p.Tutor_Id,
                    TutorName = p.Tutor.FirstName + " " + p.Tutor.LastName,
                    Classroom_Id = p.Classroom_Id,
                    ClassroomTitle = p.Classroom.Title,
                    Level_Id = p.Level_Id,
                    LevelTitle = p.Level.Title
                }).ToList();
                ViewData["pupils"] = pupils;
                ViewData["evaluation"] = eval;
                List<ResultModel> results = new List<ResultModel>();
                foreach (var pupil in pupils)
                {
                    results.Add(new ResultModel());
                }
                return View(results);
            }
        }

        [HttpPost]
        public ActionResult AddResults(List<ResultModel> results)
        {
            using (var entity = new Entities()) {
                var resultRepo = new ResultRepository(entity);
                foreach (var result in results)
                {
                    result.Id = Guid.NewGuid();
                    Result r = new Result();
                    convertResultModelToResult(result, r);
                    resultRepo.Add(r);
                }
                resultRepo.Save();

            }
            return RedirectToAction("Read", results[0].Evaluation_Id);
        }

        [HttpGet]
        public ActionResult Read(Guid id)
        {
            using (var entity = new Entities())
            {
                ResultRepository resultRepo = new ResultRepository(entity);
                EvaluationRepository evalRepo = new EvaluationRepository(entity);
                EvaluationModel eval = evalRepo.getById(id).Select(e => new EvaluationModel
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
                    TotalPoint = e.TotalPoint,
                    Results_Number = e.Results.Count
                }).First();
                ViewData["results"] = resultRepo.getByEvaluation(id).Select(r => new ResultModel
                {
                    Id = r.Id,
                    Note = r.Note,
                    Evaluation_Id = r.Evaluation.Id,
                    EvaluationTotalPoint = r.Evaluation.TotalPoint,
                    EvaluationDate = r.Evaluation.Date,
                    Pupil_Id = r.Pupil_Id,
                    Pupil_Name = r.Pupil.FirstName + " " + r.Pupil.LastName
                }).ToList();
                return View(eval);
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            using(var entity = new Entities()) {
                EvaluationRepository evalRepo = new EvaluationRepository(entity);
                ClassroomRepository classroomRepo = new ClassroomRepository(entity);
                PeriodRepository periodRepo = new PeriodRepository(entity);
                UserRepository userRepo = new UserRepository(entity);
                ResultRepository resultRepo = new ResultRepository(entity);
                EvaluationModel eval = evalRepo.getById(id).Select(e => new EvaluationModel
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
                    TotalPoint = e.TotalPoint,
                    Results_Number = e.Results.Count
                }).First();
                ViewData["classrooms"] = classroomRepo.All().Select(c => new ClassroomModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    User_Id = c.User.Id,
                    User_Name = c.User.FirstName + " " + c.User.LastName,
                    Year1 = c.Year.Year1,
                    Establishment_Name = c.Establishment.Name
                }).ToList();
                ViewData["periods"] = periodRepo.All().Select(p => new PeriodModel
                {
                    Id = p.Id,
                    Begin = p.Begin,
                    End = p.End
                }).ToList();
                eval.Results = resultRepo.getByEvaluation(id).Select(r => new ResultModel {
                    Id = r.Id,
                    Note = r.Note,
                    Evaluation_Id = r.Evaluation.Id,
                    EvaluationTotalPoint = r.Evaluation.TotalPoint,
                    EvaluationDate = r.Evaluation.Date,
                    Pupil_Id = r.Pupil_Id,
                    Pupil_Name = r.Pupil.FirstName + " " + r.Pupil.LastName
                }).ToList();
                return View(eval);
            }
        }

        [HttpPost]
        public ActionResult Edit(EvaluationModel eval) {
            if (ModelState.IsValid)
            {
                using(var entity = new Entities()) {
                EvaluationRepository evaluationRepo = new EvaluationRepository(entity);
                ClassroomRepository classroomRepo = new ClassroomRepository(entity);
                UserRepository userRepo = new UserRepository(entity);

                eval.User_Id = classroomRepo.getById(eval.Classroom_Id).First().User_Id;
                Evaluation e = evaluationRepo.getById(eval.Id).First();
                convertEvaluationModelToEvaluation(eval, e);
                evaluationRepo.Save();
                return RedirectToAction("Read", new { @id = eval.Id });
                }
            }
            return View(eval);
        }

        [HttpPost]
        public ActionResult EditResults(List<ResultModel> results)
        {
            using (var entity = new Entities())
            {
                ResultRepository resultRepo = new ResultRepository(entity);
                foreach (var result in results)
                {
                    Result r = resultRepo.getById(result.Id).First();
                    convertResultModelToResult(result, r);
                    resultRepo.Save();
                }
                return RedirectToAction("Read", new { @id = results[0].Evaluation_Id });
            }
        }

       
    }
}
