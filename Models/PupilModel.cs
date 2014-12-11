using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class PupilModel
    {
        public Guid Id
        {
            get;
            set;
        }

        public Guid Tutor_Id
        {
            get;
            set;
        }

        public Guid Classroom_Id
        {
            get;
            set;
        }

        public Guid Level_Id
        {
            get;
            set;
        }

        public String FirstName
        {
            get;
            set;
        }

        public String LastName {
            get; set;
        }

        public int Sex
        {
            get;
            set;
        }

        public DateTime BirthdayDate
        {
            get;
            set;
        }

        public int State
        {
            get;
            set;
        }

        public String LevelTitle
        {
            get;
            set;
        }

        public String TutorName
        {
            get;
            set;
        }

        public String ClassroomTitle
        {
            get;
            set;
        }
    }
}