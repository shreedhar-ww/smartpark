using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string IsSelected { get; set; }
    }
}
