using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;



namespace SmartPark.Entity
{
    public class VMBrandingModel
    {
        // [ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]
        public HttpPostedFileBase AgentLogoFile { get; set; }

        //[ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]
        public HttpPostedFileBase BannerFile { get; set; }

        //[ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]
        public HttpPostedFileBase FavIconFile { get; set; }


        [Display(Name = "Agent Logo *")]
        public string lblAgentLogo { get; set; }
        [Display(Name = "Header Banner *")]
        public string lblBannerLogo { get; set; }

        [Display(Name = "Fav Icon")]
        public string lblFavIcon { get; set; }

        public string hdnAgentLogo { get; set; }
        public string hdnBannerLogo { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string hdnFavIcon { get; set; }

        public string WebRootPath { get; set; }
        public int Branding_PortalID { get; set; }
        public int ServiceProviderID { get; set; }

        public bool IsSuccess { get; set; }

        [Required(ErrorMessage = "Landing Page URL cannot be empty")]
        [Display(Name = "Landing Page URL *")]
        public string LandingPageURL { get; set; }
        public string ClientLogo { get; set; }
        public string HeaderBanner { get; set; }
        public string ClientLogoUrl { get; set; }
        public string HeaderBannerUrl { get; set; }
        //[Required(ErrorMessage = "Select one of the branding options")]
        [Display(Name = "Portal Theme")]
        public int? PortalThemeID { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int SystemUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool Common { get; set; }
        public bool Personalised { get; set; }
        public bool Customised { get; set; }

        public string hdnCommonURL { get; set; }

        [Display(Name = "Contact Info")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ContactInfo { get; set; }

        [Display(Name = "Portal Theme")]
        public List<SelectListItem> PortalThemesList { get; set; }

        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "URL format is wrong")]
        public string Facebook { get; set; }
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "URL format is wrong")]
        public string Twitter { get; set; }
        [Display(Name = "Google +")]
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "URL format is wrong")]
        public string Google { get; set; }


        [Required(ErrorMessage = "Please select currency")]
        [Display(Name = "Currency Symbol *")]
        public string CurrencySymbol { get; set; }

        [Required(ErrorMessage = "Please enter RFID charges")]
        [Display(Name = "RFID charges *")]
        public decimal RFIDcharges { get; set; }


        [Required(ErrorMessage = "Please enter provider name")]
        [Display(Name = "Name *")]
        public string serviceProviderName { get; set; }

        [Required(ErrorMessage = "Please enter link")]
        [Display(Name = "Link *")]
        public string websiteLink { get; set; }

        [Required(ErrorMessage = "Please enter Disclaimer")]
        [Display(Name = "Disclaimer *")]
        public string Disclaimer { get; set; }



        [Remote("checkEmailAddressAvailability","Configuration",ErrorMessage="Email Already Exists")]
        [Required(ErrorMessage = "Please enter Contact Email")]
        [RegularExpression(@"^([\w-\.$#^&*]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid Email Address")]
        [Display(Name = "Email address for sending document *")]
        public string ContactEmail { get; set; }


    }
}