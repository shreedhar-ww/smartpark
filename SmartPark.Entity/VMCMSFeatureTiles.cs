using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SmartPark.Entity
{
    public class VMCMSFeatureTiles
    {
        public int CMSFeatureTilesID { get; set; }
        public bool IsSuccess { get; set; }

        // [ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]

        public HttpPostedFileBase FeatureLogoFile1 { get; set; }
        // [ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]

        public HttpPostedFileBase FeatureLogoFile2 { get; set; }
        // [ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]

        public HttpPostedFileBase FeatureLogoFile3 { get; set; }
        // [ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]

        public HttpPostedFileBase FeatureLogoFile4 { get; set; }

        public string hdnFeatureImg1 { get; set; }
        public string hdnFeatureImg2 { get; set; }
        public string hdnFeatureImg3 { get; set; }
        public string hdnFeatureImg4 { get; set; }

        [Display(Name = "Feature Image 1")]
        public string FeatureImg1 { get; set; }

        [Display(Name = "Feature Text 1")]
        public string FeatureTxt1 { get; set; }

        [Display(Name = "Feature Image 2")]
        public string FeatureImg2 { get; set; }

        [Display(Name = "Feature Text 2")]
        public string FeatureTxt2 { get; set; }

        [Display(Name = "Feature Image 3")]
        public string FeatureImg3 { get; set; }

        [Display(Name = "Feature Text 3")]
        public string FeatureTxt3 { get; set; }

        [Display(Name = "Feature Image 4")]
        public string FeatureImg4 { get; set; }

        [Display(Name = "Feature Text 4")]
        public string FeatureTxt4 { get; set; }

        [Display(Name = "YouTube URL")]
        [RegularExpression(@"^https:\/\/(?:www\.)?youtube.com\/watch\?(?=.*v=\w+)(?:\S+)?$", ErrorMessage = "Please enter valid URL.")]
        public string YoutubeURL1 { get; set; }

        [Display(Name = "YouTube URL")]
        [RegularExpression(@"^https:\/\/(?:www\.)?youtube.com\/watch\?(?=.*v=\w+)(?:\S+)?$", ErrorMessage = "Please enter valid URL.")]
        public string YoutubeURL2 { get; set; }

        [Display(Name = "YouTube URL")]
        [RegularExpression(@"^https:\/\/(?:www\.)?youtube.com\/watch\?(?=.*v=\w+)(?:\S+)?$", ErrorMessage = "Please enter valid URL.")]
        public string YoutubeURL3 { get; set; }

        [Display(Name = "YouTube URL")]
        [RegularExpression(@"^https:\/\/(?:www\.)?youtube.com\/watch\?(?=.*v=\w+)(?:\S+)?$", ErrorMessage = "Please enter valid URL.")]
        public string YoutubeURL4 { get; set; }


        [Display(Name = "Feature Title 1")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FeatureTitleTxt1 { get; set; }

        [Display(Name = "Feature Title 2")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FeatureTitleTxt2 { get; set; }

        [Display(Name = "Feature Title 3")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FeatureTitleTxt3 { get; set; }

        [Display(Name = "Feature Title 4")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FeatureTitleTxt4 { get; set; }
         
    }
}
