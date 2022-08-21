using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace SmartPark.Entity
{
    [Serializable]
    public class VMAgentKiosk
    {
        public string RFIDNumber { get; set; }
        public string SubscriberName { get; set; }
        public string Address { get; set; }
        public string PermitState { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalCount { get; set; }
        public int SubscriberId { get; set; }
        public int BackOfficeID { get; set; }
        
    }
}
