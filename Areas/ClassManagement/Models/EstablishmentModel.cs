using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManager.Areas.ClassManagement.Models
{
    public class EstablishmentModel
    {
        [Required]
        public Guid id
        {
            get;
            set;
        }

        [Required]
        [RegularExpression("^[0-9A-Za-zÀÈÌÒÙÉÊàâçéèêëîïôûùüÿñæœ .-]+$", 
            ErrorMessage = "Invalid Name (forbidden character <>@^¨£$µ%!§/")]
        public String Name
        {
            get;
            set;
        }

        [RegularExpression("^[0-9A-Za-zÀÈÌÒÙÉÊàâçéèêëîïôûùüÿñæœ '\".-]+$",
            ErrorMessage = "Invalid address (forbidden character <>@^¨£$µ%!§/")]
        public String Address
        {
            get;
            set;
        }

        [Required]
        [RegularExpression("^[0-9]{5}$",
            ErrorMessage = "Invalid Postcode (forbidden character <>@^¨£$µ%!§/")]
        public String PostCode
        {
            get;
            set;
        }

        [Required]
        [RegularExpression("^[0-9A-Za-zÀÈÌÒÙÉÊàâçéèêëîïôûùüÿñæœ .-]+$",
            ErrorMessage = "Invalid Name (forbidden character <>@^¨£$µ%!§/")]
        public String Town
        {
            get;
            set;
        }

        public String UserName
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
        public Guid Academie_Id
        {
            get;
            set;
        }

        public String AcademyName
        {
            get;
            set;
        }

        public List<ClassroomModel> Classrooms
        {
            get;
            set;
        }

    }
}