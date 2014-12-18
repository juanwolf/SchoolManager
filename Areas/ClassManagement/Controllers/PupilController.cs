using OfficeOpenXml;
using OfficeOpenXml.Style;
using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.Areas.ClassManagement.Controllers
{
    public class PupilController : Controller
    {
        //
        // GET: /Pupil/
        public void convertPupilModelToPupil(PupilModel pupil, Pupil p)
        {
            p.Id = pupil.Id;
            p.LastName = pupil.LastName;
            p.FirstName = pupil.FirstName;
            p.Classroom_Id = pupil.Classroom_Id;
            p.Sex = pupil.Sex;
            p.State = 1;
            p.BirthdayDate = pupil.BirthdayDate;
            p.Tutor_Id = pupil.Tutor_Id;
            p.Level_Id = pupil.Level_Id;
            p.Classroom_Id = pupil.Classroom_Id;
        }

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
                    Level_Id = p.Level_Id,
                    TutorName = p.Tutor.FirstName + " " + p.Tutor.LastName,
                    LevelTitle = p.Level.Title,
                    ClassroomTitle = p.Classroom.Title
                }).ToList();
                return View(pupils);
            }
        }

        public ActionResult Read(Guid id)
        {
            using (var entity = new Entities())
            {
                var pupilRepo = new PupilRepository(entity);
                PupilModel pupil = pupilRepo.getById(id).Select(p => new PupilModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Sex = p.Sex,
                    BirthdayDate = p.BirthdayDate,
                    State = p.State,
                    Tutor_Id = p.Tutor_Id,
                    Classroom_Id = p.Classroom_Id,
                    Level_Id = p.Level_Id,
                    TutorName = p.Tutor.FirstName + " " + p.Tutor.LastName,
                    LevelTitle = p.Level.Title,
                    ClassroomTitle = p.Classroom.Title
                }).First();
                var resultRepo = new ResultRepository(entity);
                List<ResultModel> results = resultRepo.getByPupil(id).Select(r => new ResultModel {
                    Id = r.Id,
                    Note = r.Note,
                    Evaluation_Id = r.Evaluation.Id,
                    EvaluationTotalPoint = r.Evaluation.TotalPoint,
                    EvaluationDate = r.Evaluation.Date
                }).ToList();
                pupil.resultats = results;
                return View(pupil);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (var entity = new Entities())
            {
                PupilModel pupil = new PupilModel();
                LevelRepository levelRepo = new LevelRepository(entity);
                TutorRepository tutorRepo = new TutorRepository(entity);
                ClassroomRepository classroomRepo = new ClassroomRepository(entity);
                var levels = levelRepo.All().Select(u => new LevelModel
                {
                    Id = u.Id,
                    Title = u.Title,
                    CycleName = u.Cycle.Title
                }).ToList();
                ViewData["levels"] = levels;
                var classrooms = classroomRepo.All().Select(c => new ClassroomModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    User_Name = c.User.FirstName + " " + c.User.LastName,
                    Year1 = c.Year.Year1,
                    Establishment_Name = c.Establishment.Name
                }).ToList();
                ViewData["classrooms"] = classrooms;
                var tutors = tutorRepo.All().Select(t => new TutorModel
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName
                }).ToList();
                ViewData["tutors"] = tutors;
                return View(pupil);
            }
        }

        [HttpPost]
        public ActionResult Create(PupilModel pupil)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities())
                {
                    PupilRepository repo = new PupilRepository(entity);
                    pupil.Id = Guid.NewGuid();
                    Pupil p = new Pupil();
                    convertPupilModelToPupil(pupil, p);
                    repo.Add(p);
                    repo.Save();
                    return RedirectToAction("Read", new { id = pupil.Id });
                }

            }
            else
            {
                return View(pupil);
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            using (var entity = new Entities())
            {
                PupilRepository pupilRepo = new PupilRepository(entity);
                LevelRepository levelRepo = new LevelRepository(entity);
                TutorRepository tutorRepo = new TutorRepository(entity);
                ClassroomRepository classroomRepo = new ClassroomRepository(entity);
                PupilModel pupil = pupilRepo.getById(id).Select(p => new PupilModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Sex = p.Sex,
                    BirthdayDate = p.BirthdayDate,
                    State = p.State,
                    Tutor_Id = p.Tutor_Id,
                    Classroom_Id = p.Classroom_Id,
                    Level_Id = p.Level_Id,
                    TutorName = p.Tutor.FirstName + " " + p.Tutor.LastName,
                    LevelTitle = p.Level.Title,
                    ClassroomTitle = p.Classroom.Title
                }).First();
                var levels = levelRepo.All().Select(u => new LevelModel
                {
                    Id = u.Id,
                    Title = u.Title,
                    CycleName = u.Cycle.Title
                }).ToList();
                ViewData["levels"] = levels;
                var classrooms = classroomRepo.All().Select(c => new ClassroomModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    User_Name = c.User.FirstName + " " + c.User.LastName,
                    Year1 = c.Year.Year1,
                    Establishment_Name = c.Establishment.Name
                }).ToList();
                ViewData["classrooms"] = classrooms;
                var tutors = tutorRepo.All().Select(t => new TutorModel
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName
                }).ToList();
                ViewData["tutors"] = tutors;
                return View(pupil);
            }
        }

        [HttpPost]
        public ActionResult Edit(PupilModel pupil)
        {
            if (ModelState.IsValid)
            {
                using (var entity = new Entities())
                {
                    PupilRepository repo = new PupilRepository(entity);
                    Pupil p = repo.getById(pupil.Id).First();
                    convertPupilModelToPupil(pupil, p);
                    repo.Save();
                    return RedirectToAction("Read", new { id = pupil.Id });
                }

            }
            else
            {
                return RedirectToAction("Edit", new { id = pupil.Id });
            }
        }

        [HttpGet]
        public void GetPupils()
        {
            using (var entity = new Entities())
            {
                PupilRepository pupilRepo = new PupilRepository(entity);
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
                    Level_Id = p.Level_Id,
                    TutorName = p.Tutor.FirstName + " " + p.Tutor.LastName,
                    LevelTitle = p.Level.Title,
                    ClassroomTitle = p.Classroom.Title
                }).ToList();
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Pupils");

                    //Load the datatable into the sheet, starting from cell A1. 
                    //Print the column names on row 1
                    //Merging cells and create a center heading for out table
                    ws.Cells[1, 1].Value = "Pupils"; // Heading Name
                    ws.Cells[1, 1, 1, 7].Merge = true; //Merge columns start and end range
                    ws.Cells[1, 1, 1, 7].Style.Font.Bold = true; //Font should be bold
                    ws.Cells[1, 1, 1, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, 1, 2, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Dashed;
                    ws.Cells[2, 1, 2, 7].Style.Font.Bold = true;
                    ws.Cells[2, 1].Value = "First Name";
                    ws.Cells[2, 2].Value = "Last Name";
                    ws.Cells[2, 3].Value = "Sex";
                    ws.Cells[2, 4].Value = "Birthday Date";
                    ws.Cells[2, 5].Value = "Level";
                    ws.Cells[2, 6].Value = "Classroom";
                    ws.Cells[2, 7].Value = "Tutor";
                    int i = 3;
                    foreach (var pupil in pupils)
                    {
                        ws.Cells[i, 1].Value = pupil.FirstName;
                        ws.Cells[i, 2].Value = pupil.LastName;
                        ws.Cells[i, 3].Value = (SchoolManager.Models.PupilModel.Sexes) pupil.Sex;
                        ws.Cells[i, 4].Value = pupil.BirthdayDate.ToShortDateString();
                        ws.Cells[i, 5].Value = pupil.LevelTitle;
                        ws.Cells[i, 6].Value = pupil.ClassroomTitle;
                        ws.Cells[i, 7].Value = pupil.TutorName;
                        i++;
                    }
                    ws.Cells[2, 1, i, 7].AutoFitColumns();
                    //Write it back to the client
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;  filename=Pupils.xlsx");
                    Response.BinaryWrite(pck.GetAsByteArray());
                }
            }
        }

    }
}
