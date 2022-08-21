using SmartPark.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartPark.Data
{
    
    public class DBRegisterPage : DBHelper
    {
        public PageLabelsandValidation GetIndexPageFields(int ServiceProviderId)
        {
            PageLabelsandValidation objVMSubscriberDetail = null;

            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetFormConfiguration", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@intServiceProviderID", ServiceProviderId);
                    objReader = objCommand.ExecuteReader();
                    using (objReader)
                    {
                        while (objReader.Read())
                        {
                            //objVMSubscriberDetail.                    = objReader["CountryName"].ToString();
                            //objVMSubscriberDetail.                    = objReader["CountryName"].ToString();
                            //objVMSubscriberDetail.                    = objReader["CountryName"].ToString();
                            //objVMSubscriberDetail.                    = objReader["CountryName"].ToString();
                            //objVMSubscriberDetail.                    = objReader["CountryName"].ToString();

                            objVMSubscriberDetail = new PageLabelsandValidation();
                            objVMSubscriberDetail.lblTitleID = objReader["Title"].ToString();
                            objVMSubscriberDetail.IsTitleIDReq = (bool)objReader["IsReqTitle"];

                            objVMSubscriberDetail.lblFname = objReader["FirstName"].ToString();
                            objVMSubscriberDetail.IsFirstNameReq = (bool)objReader["IsReqFirstName"];

                            objVMSubscriberDetail.lblLname = objReader["LastName"].ToString();
                            objVMSubscriberDetail.IsLastNameReq = (bool)objReader["IsReqLastName"];

                            objVMSubscriberDetail.lblStreet = objReader["Street"].ToString();
                            objVMSubscriberDetail.IsStreetLineReq = (bool)objReader["IsReqStreet"];

                            objVMSubscriberDetail.lblStreet2 = objReader["StreetLine"].ToString();
                            objVMSubscriberDetail.IsStreetLine2Req = (bool)objReader["IsReqStreetLine"];

                            objVMSubscriberDetail.lblEmailAddres = objReader["Email"].ToString();
                            objVMSubscriberDetail.IsEmailAddressReq = (bool)objReader["IsReqEmail"];

                            objVMSubscriberDetail.lblDrivinglic = objReader["DriverLicence"].ToString();
                            objVMSubscriberDetail.IsDriverLiscenceReq = (bool)objReader["IsReqDriverLicence"];

                            objVMSubscriberDetail.lblCountry = objReader["Country"].ToString();
                            objVMSubscriberDetail.lblState = objReader["State"].ToString();

                            objVMSubscriberDetail.lblSuburb = objReader["Suburb"].ToString();
                            objVMSubscriberDetail.IsSuburbReq = (bool)objReader["IsReqSuburb"];


                            objVMSubscriberDetail.lblPostCode = objReader["Postcode"].ToString();
                            objVMSubscriberDetail.IsPostCodeReq = (bool)objReader["IsReqPostcode"];

                            objVMSubscriberDetail.lblMobileNo = objReader["MobileNo"].ToString();
                            objVMSubscriberDetail.IsMobileContactNoReq = (bool)objReader["IsReqMobileNo"];

                            objVMSubscriberDetail.lblHomeNo = objReader["HomeNo"].ToString();
                            objVMSubscriberDetail.IsHomeContactNoReq = (bool)objReader["IsReqHomeNo"];

                            objVMSubscriberDetail.IsReqState = (bool)objReader["IsReqState"];

                            objVMSubscriberDetail.lblcarparkName = objReader["CarParkName"].ToString();

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return objVMSubscriberDetail;
        }
    }
}
