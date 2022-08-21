using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{
    public class CarParkNumber
    {
        public string SmartRepCarParkCode { get; set; }

        public Int64 CarParkID { get; set; }

        public IList<System.Web.Mvc.SelectListItem> CarParkNumberList { get; set; }
    }
}
