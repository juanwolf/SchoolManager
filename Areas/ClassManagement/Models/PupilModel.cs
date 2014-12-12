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

        public List<ResultModel> resultats;
        
        public PupilModel(Guid id, String FirstName, String LastName, int Sex, DateTime date, int State, Guid Tutor_Id, Guid Classroom_Id, Guid Level_id ) {
            Id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Sex = Sex;
            this.BirthdayDate = date;
            this.State = State;
            this.Tutor_Id = Tutor_Id;
            this.Classroom_Id = Classroom_Id;
            this.Level_Id = Level_id;
        }

        public PupilModel()
        {

        }
    }
}