using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{

    [Serializable]
    public class VMPaymentGatewayOfServiceProvider
    {
       //
        public int GatewayID { get; set; }

        //PayPal
        public string ElectronicBusinessNo { get; set; }
        public string TerminalIdentifier { get; set; }
        public string Credentials { get; set; }
        public string AccountNo { get; set; }

        //EWAY
        public string EwayCustomerID { get; set; }
        public string EwayUsername { get; set; }
        public string EwayPassword { get; set; }
        public string APIkey { get; set; }
        public decimal EwayRFIDCharges { get; set; }


        public int GatewayId { get; set; }

        public decimal RFIDCharges { get; set; }
    }
}
