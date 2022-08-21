using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPark.MSMQ
{
    [Serializable]
    public class MSMQEmail
    {  
       
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string validUntil { get; set; }
        // public string Message { get; set; }
        public string TemplateName { get; set; }
        public string Logo { get; set; }
        public string ContactEmail { get; set; }
        public string Banner { get; set; }
        public string Body { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string URL { get; set; }
        public int ServiceProviderID { get; set; }
        public string ErrorMessage { get; set; }
        public string RFIDNumber { get; set; }
        public long subscriberID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CurrencySymbol { get; set; }
        public string HistoryType { get; set; }

        public string accActivationLink { get; set; }
    }
}
