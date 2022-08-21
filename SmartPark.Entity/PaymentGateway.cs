using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SmartPark.Entity
{
   public class PaymentGateway
    {

       [Display(Name = "Payment Gateway")]
       public int PaymentGatewayID { get; set; }

       public string PaymentGatewayName { get; set; }
       public IEnumerable<SelectListItem> PaymentGatewayList { get; set; }

       [Display(Name = "CarPark Name")]
       [Required]
       public int CarParkID { get; set; }
       public IEnumerable<SelectListItem> carParkList { get; set; }
    }
}
