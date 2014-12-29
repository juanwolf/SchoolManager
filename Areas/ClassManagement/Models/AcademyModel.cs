using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManager.Areas.ClassManagement.Models
{
    public class AcademyModel
    {
        public Guid Id
        {
            get;
            set;
        }

        [Required(ErrorMessage="The Name of the academy is required")]
        [RegularExpression("^[0-9A-Za-zÀÈÌÒÙÉÊàâçéèêëîïôûùüÿñæœ .-]+$", ErrorMessage = "Invalid Name (forbidden character <>@^¨£$µ%!§/")]
        public String Name
        {
            get;
            set;
        }

        public List<EstablishmentModel> establishments
        {
            get;
            set;
        }
    }
}