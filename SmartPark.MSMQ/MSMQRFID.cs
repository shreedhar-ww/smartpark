using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.MSMQ
{
     
    [Serializable]
    public class MSMQRFID
    {
        

        public Int32 BackOFficeID { get; set; }
        public int GatewayID { get; set; } // 1 for Eway , 2 for Paypal
        public Int32 SubscriberID { get; set; }

        //Eway detail
        public string eWAYCustomerID { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string CustomerID { get; set; }
        public decimal RFIDCharges { get; set; }
        public decimal TopupValue { get; set; }


        //PayPal
        public string ElectronicBusinessNo { get; set; }
        public string TerminalIdentifier { get; set; }
        public string Credentials { get; set; }
        public string AccountNo { get; set; }


        // RFID payment gateway failed then used this detail for sending mail.
        public string To { get; set; }
        public string URL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // carparkid and carparkbaytypeID

        public bool IsApplyForNewCarpark { get; set; }
        public string carparkIDS { get; set; }
        public string CarparkBayTypeIDS { get; set; }


         
    }
}
