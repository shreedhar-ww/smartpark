using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace SmartPark.Entity
{
    public class UserModel
    {

        [Required(ErrorMessage = "Please enter First Name")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please enter valid First Name")]
        [Display(Name = "First Name *")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please enter valid Last Name")]
        [Display(Name = "Last Name *")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Email Address")]
        [RegularExpression(@"^([\w-\.$#^&*]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid Email Address")]
       // [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid Email Address")]
        [Display(Name = "Email *")]
        public string Email { get; set; }
        public Boolean IsActive { get; set; }


        [Required(ErrorMessage = "Please select one of the valid roles")]
        [Display(Name = "Role *")]
        public string Role { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }


        [Required(ErrorMessage = "Please enter User Name")]
        [Display(Name = "Username *")]
        //[RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Please enter valid User Name")]
        public string Username { get; set; }

      
        [Display(Name = "Password *")]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at most 15 characters long.", MinimumLength = 8)]
        //[RegularExpression(@"(?=.*\d)(?=.*[a-zA-Z])(?=.*[!@#$%^&+=*/;':,.<>?-_]).*$", ErrorMessage = "Password must contain letters,numbers and 1 special character.No space allowed.")]
        [Required(ErrorMessage = "Please enter the Password")]      
        public string Password { get; set; }


        public int SystemUserRoleID { get; set; }
        public string Name { get; set; }
        public string ServiceProviderName { get; set; }
        public string SystemUserID { get; set; }
        public int TotalCount { get; set; }
        public Int32 ServiceProviderID { get; set; }
        

        [Display(Name = "Enforce Password Change")]
        public bool IsPasswordReset { get; set; }


    }
}
