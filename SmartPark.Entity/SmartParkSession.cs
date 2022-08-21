using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace SmartPark.Entity
{
    [Serializable]
    public class SmartParkSession
    {
        public int SystemUserID { get; set; }
        public string FirstName { get; set; }
        public int ServiceProviderID { get; set; }
        public string ServiceProviderName { get; set; }
        public string SmartParkRole { get; set; }

    }
}
