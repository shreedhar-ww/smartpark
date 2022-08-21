using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SmartPark.Entity
{
    public class FormConfiguration
    {
        [Display(Name = "Title *")]
        [Required(ErrorMessage = "This field is required.")]
        public string Title { get; set; }
        public bool IsReqTitle { get; set; }

        [Display(Name = "First Name *")]
        [Required(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }
        public bool IsReqFirstName { get; set; }

        [Display(Name = "Last Name *")]
        [Required(ErrorMessage = "This field is required.")]
        public string LastName { get; set; }
        public bool IsReqLastName { get; set; }

        [Display(Name = "Street *")]
        [Required(ErrorMessage = "This field is required.")]
        public string Street { get; set; }
        public bool IsReqStreet { get; set; }

        [Display(Name = "Street Line *")]
        [Required(ErrorMessage = "This field is required.")]
        public string StreetLine { get; set; }
        public bool IsReqStreetLine { get; set; }

        [Display(Name = "Email Address *")]
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }
        public bool IsReqEmail { get; set; }

        [Display(Name = "Driver's Licence *")]
        [Required(ErrorMessage = "This field is required.")]
        public string DriverLicence { get; set; }
        public bool IsReqDriverLicence { get; set; }

        [Display(Name = "Country *")]
        [Required(ErrorMessage = "This field is required.")]
        public string Country { get; set; }
        public bool IsReqCountry { get; set; }

        [Display(Name = "State *")]
        [Required(ErrorMessage = "This field is required.")]
        public string State { get; set; }
        public bool IsReqState { get; set; }

        [Display(Name = "Suburb *")]
        [Required(ErrorMessage = "This field is required.")]
        public string Suburb { get; set; }
        public bool IsReqSuburb { get; set; }

        [Display(Name = "Postcode *")]
        [Required(ErrorMessage = "This field is required.")]
        public string Postcode { get; set; }
        public bool IsReqPostcode { get; set; }

        [Display(Name = "Mobile Contact Number *")]
        [Required(ErrorMessage = "This field is required.")]
        public string MobileNo { get; set; }
        public bool IsReqMobileNo { get; set; }

        [Display(Name = "Home Contact Number *")]
        [Required(ErrorMessage = "This field is required.")]
        public string HomeNo { get; set; }
        public bool IsReqHomeNo { get; set; }


        [Display(Name = "CarPark Name *")]
        [Required(ErrorMessage = "This field is required.")]
        public string CarParkName { get; set; }
        public bool IsCarParkName { get; set; }

        public int hdnFormID { get; set; }

    }
}
