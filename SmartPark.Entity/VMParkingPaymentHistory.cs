using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{
    public class VMParkingPaymentHistory
    {
        public string RFIDNo { get; set; }

        public string PaymentDate { get; set; }

        public string Amount { get; set; }

        public string Balance { get; set; }

        public string TimeIn { get; set; }

        public string TimeOut { get; set; }

        public int TOTALCOUNT { get; set; }


        public string ParkingLocation { get; set; }
    }
}
