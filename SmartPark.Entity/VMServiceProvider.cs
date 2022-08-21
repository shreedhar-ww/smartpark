using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SmartPark.Entity
{
    public class VMServiceProvider
    {
        //public string ServiceProviderName { get; set; }

        [Required(ErrorMessage = "Please select the ServiceProvider")]
        [Display(Name = "Service Provider *")]
        public Int64 ServiceProviderID { get; set; }
        public IEnumerable<SelectListItem> ProviderList { get; set; }



        [Required(ErrorMessage = "Please select the Payment Method")]
        [Display(Name = "Payment Method *")]
        public int PaymewntModeId { get; set; }
        public IEnumerable<SelectListItem> PaymentList { get; set; }
        //public IList<System.Web.Mvc.SelectListItem> PaymentList { get; set; }


        [Display(Name = "Car Park Name ")]
        public int[] SelectedCarParkValues { get; set; }
        public IEnumerable<SelectListItem> CarParkList { get; set; }


        [Required(ErrorMessage = "Please generate the Service URL")]
        [Display(Name = "Service URL ")]
        public string strServiceURL { get; set; }

        [Display(Name = "Active")]
        public bool bIsActive { get; set; }

        public string strServiceProviderName { get; set; }
        public string PaymentMode { get; set; }
        public int TotalCount { get; set; }
        public int hdnPreviousPayType { get; set; }

        public string PortalServiceProviderID { get; set; }

    }
}
