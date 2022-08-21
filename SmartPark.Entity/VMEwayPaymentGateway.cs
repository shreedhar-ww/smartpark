using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace SmartPark.Entity
{
    public class VMEwayPaymentGateway
    {

        public string PaymentGateWayInfoID { get; set; }

        [Display(Name = "Customer ID *")]
        [Required(ErrorMessage = "Please enter your CustomerID")]
        public string CustomerID { get; set; }


        [Display(Name = "User ID *")]
        [Required(ErrorMessage = "Please enter your UserID")]
        public string UserID { get; set; }

        [Display(Name = "Eway API Key *")]
        [Required(ErrorMessage = "Please enter API Key ")]
        public string APIKey { get; set; }


        [Display(Name = "Password *")]
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }

        [Display(Name = "RFID Charges *")]
        [Required(ErrorMessage = "Please enter RFID Charges")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{:c}")]
        [Range(1, 9999999999, ErrorMessage = "Please enter valid RFID Charges")]

        public decimal RFIDCharges { get; set; }

        public int GateWayID { get; set; }
        public int CarParkId { get; set; }


        [Display(Name = "Currency *")]
        [Required(ErrorMessage = "Please select Currency")]
        public string CurrencySymbol { get; set; }
    }
}
