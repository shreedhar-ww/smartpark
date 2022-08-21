using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;


namespace SmartPark.Entity
{
    public class BrandingModel
    {
        public HttpPostedFileBase AgentLogoFile { get; set; }
        public HttpPostedFileBase BannerFile { get; set; }
        public string WebRootPath { get; set; }
        public int Branding_PortalID { get; set; }
        public int ServiceProviderID { get; set; }
        public string LandingPageURL { get; set; }
        public string ClientLogo { get; set; }
        public string HeaderBanner { get; set; }
        public string ClientLogoUrl { get; set; }
        public string HeaderBannerUrl { get; set; }
        public int PortalThemeID { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int SystemUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Common { get; set; }
        public bool Personalised { get; set; }
        public bool Customised { get; set; }
        public List<SelectListItem> PortalThemesList { get; set; }
    }
}