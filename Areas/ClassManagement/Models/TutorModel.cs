using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class TutorModel
    {
        public Guid Id
        {
            get;
            set;
        }

        [Required]
        [RegularExpression("^[A-Za-zÀÈÌÒÙÉÊàâçéèêëîïôûùüÿñæœ .-]+$", ErrorMessage = "Invalid Last Name(forbidden character <>@^¨£$µ%!§/")]
        public String LastName
        {
            get;
            set;
        }

        [RegularExpression("^[A-Za-zÀÈÌÒÙÉÊàâçéèêëîïôûùüÿñæœ .-]+$", ErrorMessage = "Invalid First Name (forbidden character <>@^¨£$µ%!§/")]
        public String FirstName
        {
            get;
            set;
        }

        [RegularExpression("^[0-9A-Za-zÀÈÌÒÙÉÊàâçéèêëîïôûùüÿñæœ .-]+$", ErrorMessage = "Invalid Address (forbidden character <>@^¨£$µ%!§/")]
        public String Address
        {
            get;
            set;
        }

        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Invalid Title (forbidden character <>@^¨£$µ%!§/")]
        public String PostCode
        {
            get;
            set;
        }

        [Required]
        [RegularExpression("^[0-9A-Za-zÀÈÌÒÙÉÊàâçéèêëîïôûùüÿñæœ .-]+$", ErrorMessage = "Invalid Town Name (forbidden character <>@^¨£$µ%!§/")]
        public String Town
        {
            get;
            set;
        }
        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Invalid Title (forbidden character <>@^¨£$µ%!§/")]
        public String Tel
        {
            get;
            set;
        }

        [Required]
        [RegularExpression("^[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]{2,}\\.[a-z]{2,4}$", ErrorMessage = "Invalid Mail(forbidden character <>^¨£$µ%!§/")]
        public String Mail
        {
            get;
            set;
        }

        [Required]
        [RegularExpression("^[0-9A-Za-zÀÈÌÒÙÉÊàâçéèêëîïôûùüÿñæœ .-]+$", ErrorMessage = "Invalid Comment (forbidden character <>@^¨£$µ%!§/")]
        public String Comment
        {
            get;
            set;
        }

        public List<PupilModel> pupils
        {
            get;
            set;
        }

        public TutorModel() { }

        public TutorModel(Guid id, String lastName, String firstName, String address, String postcode, String town, String tel, String mail, String comment)
        {
            this.Id = id;
            this.LastName = lastName;
            this.Address = address;
            this.PostCode = postcode;
            this.Town = town;
            this.Tel = tel;
            this.Mail = mail;
            this.Comment = comment;
        }
    }
}