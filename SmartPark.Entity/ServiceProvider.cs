using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{
    public class ServiceProvider
    {
        public string ServiceProviderName { get; set; }

        public int ServiceProviderID { get; set; }

        public IList<System.Web.Mvc.SelectListItem> ProviderList { get; set; }
    }
}
