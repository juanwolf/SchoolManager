using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class EvaluationRepository
    {
         public Entities context;

        public EvaluationRepository(Entities ent)
        {
            context = ent;
        }

        public IQueryable<Evaluation> All() {
            return context.Evaluations;
        }

        public IQueryable<Evaluation> getById(Guid id)
        {
            return context.Evaluations.Where(e => e.Id == id);
        }

        public IQueryable<Evaluation> getByPeriod(Guid id)
        {
            return context.Evaluations.Where(e => e.Period_Id == id);
        }

        public IQueryable<Evaluation> getByUser(Guid id)
        {
            return context.Evaluations.Where(e => e.User_Id == id);
        }

        public IQueryable<Evaluation> getByClassroom(Guid id)
        {
            return context.Evaluations.Where(e => e.Classroom_Id == id);
        }
    }
}