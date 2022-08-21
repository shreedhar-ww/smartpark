using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{
    public class WorkFlow
    {

        [Display(Name = "Payments")]
        public bool Payments { get; set; }

        [Display(Name = "Alert")]
        public bool SMSAlert { get; set; }

        [Display(Name = "Offer")]
        public bool SMSOffer { get; set; }

        [Display(Name = "Electronic Statement")]
        public bool ElectronicStatement { get; set; }


 

        [Display(Name = "Term & Conditions")]
        public bool TermAndConditions { get; set; }

        [Display(Name = "Social Media Integration")]
        public bool FacebookIntegration { get; set; }



    }
}
