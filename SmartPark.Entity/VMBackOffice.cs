using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SmartPark.Entity
{
    public class VMBackOffice
    {
        public int BackOfficeID { get; set; }

        [Required]
        [Display(Name = "Barcode No")] //RFID Tag Serial 
        public string RFIDNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string RFIDNumber_Search { get; set; }

        public int GlobalRFIDTagId { get; set; }

        public int SubscriberId { get; set; }
        public string Subscriber { get; set; }

        [Display(Name = "Initiated Date")]
        public DateTime? InitiatedDate { get; set; }

        [Display(Name = "Activated Date")]
        public DateTime? ActivatedDate { get; set; }

        [Display(Name = "Posted Date")]
        public DateTime? PostedDate { get; set; }

        public string PermitState { get; set; }
        public string Permit_State { get; set; }

        public int PermitStateID { get; set; }
        public int _PermitStateID { get; set; }
        public IEnumerable<SelectListItem> PermitStateList { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Authority Key")]
        public string AuthKey { get; set; }


        [Display(Name = "Confirm Authority Key")]
        //[Required(ErrorMessage = "Confirm AuthKey ")]
        [DataType(DataType.Password)]
 
        public string ConfirmAuthKey { get; set; }

        //[Display(Name = "Password *")]
        //[Required(ErrorMessage = "Please Enter Password")]
        //[RegularExpression(@"(?=.*\d)(?=.*[a-zA-Z])(?=.*[!@#$%^&+=*/;':,.<>?-_]).*$", ErrorMessage = "Password must contain letters,numbers and 1 special character. No space allowed.")]
        //[StringLength(15, ErrorMessage = "The minimum length for the password is between 8 and 15", MinimumLength = 8)]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        //[Display(Name = "Confirm Password *")]
        //[Required(ErrorMessage = "Please Enter Password")]
        //[DataType(DataType.Password)]
        //[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

        public int TotalCount { get; set; }

        //[Required]
        //[Display(Name = "Car Park Name")]
        public string CarParkID { get; set; }
        //public IEnumerable<SelectListItem> CarParkNumberList { get; set; }


        //[Required]
        //[Display(Name = "Parking type")]
        public string ParkTypeId { get; set; }
        //public IEnumerable<SelectListItem> ParkTypeList { get; set; }

        public List<CarPark> CarParkList { get; set; }

        //Grid Columns
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GridCarParkName { get; set; }
        public string GridParkType { get; set; }

        public string DocumentList { get; set; }

        public decimal AutoTopUpValue { get; set; }
        public decimal EWAYAmount { get; set; }
        public decimal Balance { get; set; }
        public string EwayCustomerId { get; set; }
        public Boolean isBalanceUpdated { get; set; }
        public Boolean IsNewPermitApply { get; set; }


        public int newCarparkID { get; set; }
        public int newcarparkbaytypeID { get; set; }


        public class CarPark
        {
            public string CarParkName;
            public string CarParkType;
        }
    }
}
