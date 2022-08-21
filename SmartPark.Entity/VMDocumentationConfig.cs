using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SmartPark.Entity
{
    public class VMDocumentationConfig
    {
        [Required(ErrorMessage ="Please select the Car Park Name")]
        [Display(Name = "Car Park Name *")]
        public int CarParkID { get; set; }
        public IEnumerable<SelectListItem> CarParkNumberList { get; set; }

        [Required(ErrorMessage = "Please select Car Park Type")]
        [Display(Name = "Park type *")]
        public int ParkTypeId { get; set; }
        public IEnumerable<SelectListItem> ParkTypeList { get; set; }

        [Required(ErrorMessage = "Please select Required Documentation")]
        [Display(Name = "Required documentation *")]
        public int RequireDocumentId { get; set; }
        public IEnumerable<SelectListItem> DocumentList { get; set; }

        [Required(ErrorMessage = "Please select Required Format")]
        [Display(Name = "Format *")]
        public int FormatId { get; set; }
        public IEnumerable<SelectListItem> FormatList { get; set; }

        [Required(ErrorMessage = "Please select application status Time")]
        [Display(Name = "Applicable status *")]
        public bool ApplicationStatus { get; set; }

        public bool IsEnabled { get; set; }

        //FOR WEBGRID
        public List<VMDocumentationConfig> listDocumentation { get; set; }
        public string CarParkNumber { get; set; }
        public string ParkType { get; set; }
        public string Document { get; set; }
        public string Format { get; set; }
        public string ApplicationStat { get; set; }

        public int TotalCount { get; set; }
        public int DocumentationId { get; set; }

    }
}
