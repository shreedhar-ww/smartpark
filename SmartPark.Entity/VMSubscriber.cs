using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SmartPark.Entity
{
    [Serializable]
    public class VMSubscriber
    {
        public String IsPaymentGatewayReq { get; set; }
        public Int32 SubscriberId { get; set; }

        //[Required(ErrorMessage = "Please select BarCode")]
        [Remote("CheckBarCode", "Subscriber", ErrorMessage = "Invalid Barcode")]
        public string RFIDNumber { get; set; }


        //[Display(Name = "Title")]
        [Required(ErrorMessage = "Please select Title")]
        public string TitleID { get; set; }
        public IEnumerable<SelectListItem> Title { get; set; }

        //[Display(Name = "First Name *")]
        [Required(ErrorMessage = "Please enter your First Name.(Only alphabets and apostrophe(') accepted)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z'-]*$", ErrorMessage = "Please enter your First Name.(Only alphabets and apostrophe(') accepted)")]
        public string FirstName { get; set; }

        //[Display(Name = "Last Name *")]
        [Required(ErrorMessage = "Please enter your Last Name.(Only alphabets and apostrophe(') accepted)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z'-]*$", ErrorMessage = "Please enter your Last Name.(Only alphabets and apostrophe(') accepted)")]
        //[RegularExpression(@"^[a-zA-Z]*['-]+{1}[a-zA-Z]*$", ErrorMessage = "Please Enter your First Name.(Only alphabets and apostrophe(') accepted)")]
        public string LastName { get; set; }

        // [Display(Name = "Email Address *")]
        [Required(ErrorMessage = "Please enter your Email Address")]
        [RegularExpression(@"^([\w-\.$#^&*]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid Email Address")]
        public string EmailAddress { get; set; }

        //  [Display(Name = "Driver's Licence *")]
        //  [Required(ErrorMessage = "Please Enter your Driver's Licence")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string DriverLiscence { get; set; }

        //  [Display(Name = "Home Contact Number")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter valid Home Contact Number.(Only Numbers accpted)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string HomeContactNo { get; set; }

        // [Display(Name = "Mobile Contact Number *")]
        //    [Required(ErrorMessage = "Please Enter your Mobile Contact Number.(Only Numbers accpted)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter valid Mobile Contact Number.(Only Numbers accpted)")]
        public string MobileContactNo { get; set; }

        // [Display(Name = "Street *")]
        //    [Required(ErrorMessage = "Please Enter your StreetLine")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[a-zA-Z0-9- ]*$", ErrorMessage = "Please enter valid StreetLine")]
        public string StreetLine { get; set; }

        //   [Display(Name = "StreetLine 2")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[a-zA-Z0-9- ]*$", ErrorMessage = "Please enter valid StreetLine2")]
        public string StreetLine2 { get; set; }

        //    [Display(Name = "Suburb *")]
        //   [Required(ErrorMessage = "Please Enter your Suburb.(Only alphabets accpted)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z]*$", ErrorMessage = "Please enter alphabets in Suburb.(Only alphabets accpted)")]
        public string Suburb { get; set; }

        //   [Display(Name = "State *")]

        [Required(ErrorMessage = "Please select the State")]
        ///  [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int? StateId { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }

        //    [Display(Name = "Postcode *")]
        //    [Required(ErrorMessage = "Please Enter your Postal Code")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[A-Z0-9]*$", ErrorMessage = "Please enter valid Post code")]
        public string PostCode { get; set; }

        //   [Display(Name = "Country *")]
        [Required(ErrorMessage = "Please select the Country")]
        public int? CountryId { get; set; }
        public string CountryCode { get; set; }
        //public IEnumerable<SelectListItem> CountryList { get; set; }
        public List<Country> CountryList { get; set; }

        public PaymentDetails PaymentDtls { get; set; }

        //AutoTop Up
        [Display(Name = "Auto Top-up")]
        [Required(ErrorMessage = "Please select Auto Top Up")]
        public int AutoTopUpId { get; set; }
        public IEnumerable<SelectListItem> AutoTopUpList { get; set; }

        [Display(Name = "Top-up Value")]
        [Range(0, 99999999, ErrorMessage = "Please enter valid amount")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal TopUpValue { get; set; }

        [Display(Name = "Top-up Threshold Value")]
        [Required(ErrorMessage = "Please enter your TopUp Threshold Value")]
        [Range(0, 99999999, ErrorMessage = "Please enter valid amount")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal TopUpThresholdValue { get; set; }

        // For Add Subscriber
        [Display(Name = "User Name *")]
        [RegularExpression(@"^([\w-\.$#^&*]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid Email Address")]
        // [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid Email Address")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid Email Address")]
        [Required(ErrorMessage = "Please enter User Name")]
        public string UserName { get; set; }

        [Display(Name = "Password *")]
        [Required(ErrorMessage = "Please enter Password")]
        [RegularExpression(@"(?=.*\d)(?=.*[a-zA-Z])(?=.*[!@#$%^&+=*/;':,.<>?-_]).*$", ErrorMessage = "Password must contain letters,numbers and 1 special character. No space allowed.")]
        [StringLength(15, ErrorMessage = "The minimum length for the password is between 8 and 15", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "CarPark Name *")]
        public int CarParkID { get; set; }
        public IEnumerable<SelectListItem> carParkList { get; set; }

        [Display(Name = "Parking Type *")]
        public int ParkTypeId { get; set; }
        public IList<System.Web.Mvc.SelectListItem> ParkTypeList { get; set; }

        public decimal Balance { get; set; }
        public string CustomerID { get; set; }

        public string hdncarpark { get; set; }

        public string hdncarparkinfo { get; set; }

        public int ApplicationId { get; set; }

        public bool ISAlertsVisible { get; set; }
        public bool ISOffersVisible { get; set; }


        [Display(Name = "Email")]
        //[Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^([\w-\.$#^&*]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid Email Address")]
        public string AlertEMail { get; set; }

        [Display(Name = "SMS")]
        //[Required(ErrorMessage = "Please Enter SMS")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter valid Mobile Contact Number")]
        public string AlertSMS { get; set; }

        [Display(Name = "I concent to receive alerts")]
        public bool IsAlertEnable { get; set; }

        [Display(Name = "Email")]
        //[Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^([\w-\.$#^&*]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid Email Address")]
        public string OffersEmail { get; set; }

        [Display(Name = "SMS")]
        //[Required(ErrorMessage = "Please Enter SMS")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter valid Mobile Contact Number")]
        public string OffersSMS { get; set; }

        [Display(Name = "I concent to receive offers")]
        public bool IsOfferEnable { get; set; }

        public List<CarPark> CarParkListMyDetail { get; set; }

        public bool hdnCCnumber { get; set; }
        public string hdnExpirydate { get; set; }
        public string hdnCardholderName { get; set; }
        public bool hdnISParkingFeesDefaulter { get; set; }
        public string RFIDCharges { get; set; }
        public bool IsActive { get; set; }
        public int CurrentPage { get; set; }

        public string hdnUpdatedPermitId { get; set; }
        public string hdnDeletedPermitId { get; set; }

        public PageLabelsandValidation getPageLabelsandValidation { get; set; }

        public bool IsSkipEmail { get; set; }

    }

    [Serializable]
    public class CarPark
    {
        public int ID;
        public string CarParkName;
        public string CarParkType;
        public bool Isdeleted;
        public string CarparkID;
        public string CarparkBayTypeID;
        public string BarCode;

    }

    [Serializable]
    public class PaymentDetails
    {
        //Payment
        [Display(Name = "Credit Card Type *")]
        [Required(ErrorMessage = "Please Select Credit Card Type")]
        public int? CreditCardTypeId { get; set; }
        public IEnumerable<SelectListItem> CreditCardTypeList { get; set; }

        [Display(Name = "Credit Card Number *")]
        [Required(ErrorMessage = "Please enter your Credit Card Number")]
        [RegularExpression(@"^[0-9]*[X]*[0-9]*$", ErrorMessage = "Please enter numbers only")]
        public string CreditCardNumber { get; set; }

        [Display(Name = "Credit Card Number *")]
        [Required(ErrorMessage = "Please enter your Credit Card Number")]
        [StringLength(16, MinimumLength = 14, ErrorMessage = "Credit Card Number must be between 14 and 16 digits")]
        [RegularExpression(@"^[0-9]*[X]*[0-9]*$", ErrorMessage = "Please enter numbers only")]
        public string CreditCardNumber_Add { get; set; }

        [Display(Name = "Cardholder Name *")]
        [Required(ErrorMessage = "Please enter your Card Holder Name")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z]*$", ErrorMessage = "Please enter alphabets only")]
        public string CardHolderName { get; set; }

        [Display(Name = "Expiry Date *")]
        [Required(ErrorMessage = "Please enter Expiry Date")]
        //[RegularExpression("^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.]\\d\\d$", ErrorMessage = "Please enter valid date only")]
        public String ExpiryDate { get; set; }

        [Display(Name = "CSV Code *")]
        [Required(ErrorMessage = "Please enter CSV Code")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter valid CSV Code.(Only Numbers accpted)")]
        public string CSVCode { get; set; }


    }
}
