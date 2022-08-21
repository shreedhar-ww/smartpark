using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SmartPark.Entity
{
    public class VMCMSBanner
    {
 

        public HttpPostedFileBase BannerLogoFile1 { get; set; }
        public HttpPostedFileBase BannerLogoFile2 { get; set; }
        public HttpPostedFileBase BannerLogoFile3 { get; set; }

        public string hdnBannerImg1 { get; set; }
        public string hdnBannerImg2 { get; set; }
        public string hdnBannerImg3 { get; set; }

        public int CMSBannerID { get; set; }
        public bool IsSuccess { get; set; }

        [Display(Name = "Banner Image 1 *")]
        public string BannerImg1 { get; set; }

        [Display(Name = "Banner Text 1")]
        public string BannerTxt1 { get; set; }

        [Display(Name = "Banner Image 2")]
        public string BannerImg2 { get; set; }

        [Display(Name = "Banner Text 2")]
        public string BannerTxt2 { get; set; }

        [Display(Name = "Banner Image 3")]
        public string BannerImg3 { get; set; }

        [Display(Name = "Banner Text 3")]
        public string BannerTxt3 { get; set; }
    }
}
