using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class ResultRepository
    {
        public Entities context;

        public ResultRepository(Entities ent)
        {
            context = ent;
        }

        public IQueryable<Result> All() {
            return context.Results;
        }

        public IQueryable<Result> getById(Guid id)
        {
            return context.Results.Where(r => r.Id == id);
        }

        public IQueryable<Result> getByEvaluation(Guid id)
        {
            return context.Results.Where(r => r.Evaluation_Id == id);
        }

        public IQueryable<Result> getByPupil(Guid id)
        {
            return context.Results.Where(r => r.Pupil_Id == id);
        }
    }
}