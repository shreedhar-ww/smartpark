using SmartPark.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartPark.Entity
{
    public class VMBackOfficeList
    {
        public List<VMBackOffice> BackOffice {get;set;}
        public string RFIDNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PermitState { get; set; }
    }
}