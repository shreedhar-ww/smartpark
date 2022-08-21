using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{
    [Serializable]
    public class PageLabelsandValidation
    {
        #region page Label and isrequired fields

        public string lblTitleID { get; set; }
        public bool IsTitleIDReq { get; set; }

        public string lblFname { get; set; }
        public bool IsFirstNameReq { get; set; }

        public string lblLname { get; set; }
        public bool IsLastNameReq { get; set; }

        public string lblStreet { get; set; }
        public bool IsStreetLineReq { get; set; }

        public string lblStreet2 { get; set; }
        public bool IsStreetLine2Req { get; set; }

        public string lblEmailAddres { get; set; }
        public bool IsEmailAddressReq { get; set; }

        public string lblDrivinglic { get; set; }
        public bool IsDriverLiscenceReq { get; set; }

        public string lblCountry { get; set; }
        public string lblState { get; set; }
        public bool IsReqState { get; set; }

        public string lblSuburb { get; set; }
        public bool IsSuburbReq { get; set; }

        public string lblPostCode { get; set; }
        public bool IsPostCodeReq { get; set; }

        public string lblMobileNo { get; set; }
        public bool IsMobileContactNoReq { get; set; }

        public string lblHomeNo { get; set; }
        public bool IsHomeContactNoReq { get; set; }

        public string lblcarparkName { get; set; }


        #endregion
    }
}
