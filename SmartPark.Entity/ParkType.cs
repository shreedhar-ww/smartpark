using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{
    public class ParkType
    {
        public string Name { get; set; }

        public int CarParkBayTypeID { get; set; }

        public IList<System.Web.Mvc.SelectListItem> ParkTypeList { get; set; }
    }
}
