﻿using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManager.Areas.Administration.Controllers
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
                var pupilsRepo = new PupilRepository(entity);
                var levelRepo = new LevelRepository(entity);
                LevelModel level = levelRepo.getById(id).Select(lvl => new LevelModel { 
                    Id = lvl.Id,
                    Title = lvl.Title,
                    Cycle_Id = lvl.Cycle_Id
                }).First();
                List<PupilModel> pupils = pupilsRepo.getByLevel(id).Select(p => new PupilModel {
                    Id = p.Id,
                    BirthdayDate = p.BirthdayDate,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Sex = p.Sex,
                    State = p.State,
                    Level_Id = level.Id,
                    LevelTitle = level.Title,
                    TutorName = p.Tutor.FirstName + " " + p.Tutor.LastName,
                    Tutor_Id = p.Tutor.Id,
                    ClassroomTitle = p.Classroom.Title,
                    Classroom_Id = p.Classroom_Id
                }).ToList();
                level.pupils = pupils;
                return View(level);
            }
        }

    }
}
