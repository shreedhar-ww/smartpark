using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{
   public class CarParkingDocumentaion
    {

        public int carparkingdocumentationID { get; set; }
        public Int64 CarParkID { get; set; }

        public Int32 CarParkBayTypeID { get; set; }

        public Int64 RequiredDocumentID { get; set; }

        public string CarParkName { get; set; }

        public string CarParkBayTypeName { get; set; }
    }
}
