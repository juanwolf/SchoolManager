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
        [RegularExpression("^[a-zàâçéèêëîïôûùüÿñæœ .-]+$/i", ErrorMessage = "Invalid Name (forbiddent character <>@^¨£$µ%!§/")]
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