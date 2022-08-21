using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SmartPark.Entity
{
    public class ResetPassword
    {
        [Required]
        //[StringLength(15, ErrorMessage = "The {0} must be at least {2} and at most 15 characters long.", MinimumLength = 8)]
        //[RegularExpression(@"(?=.*\d)(?=.*[a-zA-Z])(?=.*[!@#$%^&+=*/;':,.<>?-_]).*$", ErrorMessage = "Password must contain letters,numbers and 1 special character. No space allowed.")]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string Password { get; set; }

        [Required]
        //[StringLength(15, ErrorMessage = "The {0} must be at least {2} and at most 15 characters long.", MinimumLength = 8)]
        [RegularExpression(@"(?=.*\d)(?=.*[a-zA-Z])(?=.*[!@#$%^&+=*/;':,.<>?-_]).*$", ErrorMessage = "Password must contain letters,numbers and 1 special character. No space allowed.")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
  
        public string ConfirmPassword { get; set; }

    }
}
