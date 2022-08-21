using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{
   public class VMAgentKioskList
    {
       public List<VMAgentKiosk> VMAgentKiosk { get; set; }
       public string RFIDNumber { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string SortParametrs { get; set; }
       public int PermitState { get; set; }
    }
}
