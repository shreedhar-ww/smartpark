using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPark.Entity
{
    public class OtherConfig
    {
        public int OtherConfigID { get; set; }

        [Required(ErrorMessage = "Please enter List Type")]
        [Display(Name = "List Type *")]
        public string ListType { get; set; }

        [Required(ErrorMessage = "Please enter Value")]
        [Display(Name = "Value *")]
        public string Value { get; set; }

        [Required(ErrorMessage = "Please enter Label")]
        [Display(Name = "Label *")]
        public string Label { get; set; }
       // [Required]
        [Display(Name = "Display Order")]
        [RegularExpression(@"^([0-9]|0[0-9]|10)$",ErrorMessage = "Please enter value from 0 to 10.")]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Enabled")]
        public bool IsEnabled { get; set; }
        public int TotalCount { get; set; }

        public List<OtherConfig> lstOtherConfig { get; set; }

        public bool bIsAgentKiosk { get; set; }
        public bool bIsBackOffice { get; set; }
    }
}