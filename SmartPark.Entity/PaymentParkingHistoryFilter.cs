using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{
  public  class PaymentParkingHistoryFilter
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string RFID { get; set; }
    }
}
