using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Areas.ClassManagement.Models
{
    public class UserModel
    {
        public Guid Id
        {
            get;
            set;
        }

        public String UserName
        {
            get;
            set;
        }

        public String Password
        {
            get;
            set;
        }

        public String FirstName
        {
            get;
            set;
        }

        public String LastName
        {
            get;
            set;
        }

        public String Mail
        {
            get;
            set;
        }

        List<ClassroomModel> classrooms;

        List<EstablishmentModel> establishments;

        List<EvaluationModel> evaluations;
    }
}