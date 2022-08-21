using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPark.MSMQ
{
    [Serializable]
    public class MSMQPaymentGateway
    {

        // Subscriber detail to make eway call and generate tokenID
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string CountryCode { get; set; }
        public string EmailAddress { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string AlertEmail { get; set; }
        public decimal RFIDCharges { get; set; }
        public decimal TopupValue { get; set; }
        public string TokenID { get; set; }
        //public int intMonth { get; set; }
        //public int intYear { get; set; }
        public string expierydate { get; set; }
        public int SubscriberID { get; set; }

        //Merchant Detail
        public string eWAYCustomerID;
        public string Password;
        public string Username;

        //Gateway ID
        public int GatewayID;
        public int BackOfficeID { get; set; }
        public List<int> ListBackOfficeID { get; set; }
    }
}
