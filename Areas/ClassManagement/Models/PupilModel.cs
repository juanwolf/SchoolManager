using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [RegularExpression("^[A-Za-zÀÈÌÒÙÉÊàâçéèêëîïôûùüÿñæœ .-]+$", ErrorMessage = "Invalid First Name (forbidden character <>@^¨£$µ%!§/")]
        public String FirstName
        {
            get;
            set;
        }

        [Required]
        [RegularExpression("^[A-Za-zÀÈÌÒÙÉÊàâçéèêëîïôûùüÿñæœ .-]+$", ErrorMessage = "Invalid Last Name (forbidden character <>@^¨£$µ%!§/")]
        public String LastName {
            get; set;
        }

        public short Sex
        {
            get;
            set;
        }

        public enum Sexes {
            Male=1, Female
        }

        [Required]
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
        
        public PupilModel(Guid id, String FirstName, String LastName, short Sex, DateTime date, int State, Guid Tutor_Id, Guid Classroom_Id, Guid Level_id ) {
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