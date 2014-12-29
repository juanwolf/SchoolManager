using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SchoolManager.Models
{
    public class ClassroomModel
    {
        public Guid Id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Title is required")]
        [RegularExpression("^[0-9A-Za-zÀÈÌÒÙÉÊàâçéèêëîïôûùüÿñæœ .-]+$", ErrorMessage = "Invalid Title (forbidden character <>@^¨£$µ%!§/")]
        public String Title
        {
            get;
            set;
        }

        [Required]
        public Guid User_Id
        {
            get;
            set;
        }

        [Required]
        public Guid Year_Id
        {
            get;
            set;
        }

        [Required]
        public Guid Establishment_Id
        {
            get;
            set;
        }

        public String Establishment_Name
        {
            get;
            set;
        }

        public string User_Name
        {
            get;
            set;
        }

        public int Year1 
        { 
            get;
            set;
        }

        public List<PupilModel> pupils 
        { 
            get;
            set;
        }

        public List<EvaluationModel> evaluations
        {
            get;
            set;
        }
    }
}