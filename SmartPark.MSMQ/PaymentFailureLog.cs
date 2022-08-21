using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.MSMQ
{
    [Serializable]
    public class PaymentFailureLog
    {
        public Int32 serviceproviderID { get; set; }
        public Int32 subscriberID { get; set; }
        public string Name { get; set; }
        public decimal ammount { get; set; }
        public string error { get; set; }
        public Int32 SubscriberPermitSessionID { get; set; }
    }
}
