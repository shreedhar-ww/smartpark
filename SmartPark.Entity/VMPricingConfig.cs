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
    public class VMPricingConfig
    {

        public Int32 PricingID { get; set; }

        public int hdnCarParkId { get; set; }
        public int hdnParkTypeId { get; set; }

        //public string carParkNo { get; set; }
        public string CarParkNumber { get; set; }
        public string ParkType { get; set; }
        public string WeekDay { get; set; }

        [Display(Name = "CarPark Name *")]
        [Required(ErrorMessage = "Please select the Car Park Name")]
        public Int64 CarParkID { get; set; }
        public IEnumerable<SelectListItem> carParkList { get; set; }

        [Display(Name = "Park Type *")]
        [Required(ErrorMessage="Please select the Car Park Type")]
        public Int64 ParkTypeId { get; set; }
        public IList<System.Web.Mvc.SelectListItem> ParkTypeList { get; set; }

        //[DataType(DataType.Date)]
        [Required(ErrorMessage = "Please select valid Date")]
        [Display(Name = "Valid From *")]
        public DateTime? FromDate { get; set; }

        //[DataType(DataType.Date)]
        [Required(ErrorMessage = "Please select valid Date’, Also check Valid To >= Valid From")]
        [Display(Name = "Valid To *")]
        public DateTime? PriceToDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{:c}")]
        [Display(Name = "Rate/Hour *")]
        [Required(ErrorMessage = "Please enter Rate/hour")]
        public decimal Rate { get; set; }

        //[RegularExpression("^[0-2][0-9]:[0-6][0-9]", ErrorMessage = "Please enter valid From Time")]
        [Display(Name = "From (Time)")]
        //[Required(ErrorMessage = "Please enter From Time")]
        public string FromTime { get; set; }

        //[RegularExpression("^[0-2][0-9]:[0-6][0-9]", ErrorMessage = "Please enter valid To Time")]
        [Display(Name = "To (Time) ")]
        //[Required(ErrorMessage = "Please enter To Time")]
        public string ToTime { get; set; }

        [Required(ErrorMessage = "Please enter Maximun stay")]
        [Display(Name = "Maximum stay (hrs) *")]
        public decimal MaxStay { get; set; }

        [Display(Name = "Mon")]
        public bool IsMonday { get; set; }

        [Display(Name = "Tues")]
        public bool IsTuesday { get; set; }

        [Display(Name = "Wed")]
        public bool IsWednesday { get; set; }

        [Display(Name = "Thurs")]
        public bool IsThursday { get; set; }

        [Display(Name = "Fri")]
        public bool IsFriday { get; set; }

        [Display(Name = "Sat")]
        public bool IsSaturday { get; set; }

        [Display(Name = "Sun")]
        public bool IsSunday { get; set; }

        public bool IsEnabled { get; set; }
        public int TotalCount { get; set; }

        public string[,] WeekViewArray { get; set; }
    }
}
