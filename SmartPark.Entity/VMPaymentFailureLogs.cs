using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{
   public class VMPaymentFailureLogs
    {

       public string FirstName { get; set; }
       public string LastName { get; set; }
       public DateTime CreatedOn { get; set; }
       public string ErrorMessage { get; set; }
       public int TotalCount { get; set; }

    }
}
