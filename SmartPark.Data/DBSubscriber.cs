using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SmartPark.Entity;
using SmartPark.Helper;
using System.Data;


namespace SmartPark.Data
{
    public class DBSubscriber : DBHelper
    {



        public int setcutomerIdSubscriberById(string TokenID, int SubscriberID)
        {

            int success = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    //decimal? CCNumber = objSubscriber.CreditCardNumber == null ? 0 :
                    //     Convert.ToDecimal(objSubscriber.CreditCardNumber.Substring(objSubscriber.CreditCardNumber.Length - 2, 2));
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_SetCustomerIDBySubscriberID", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@TokenID", TokenID);
                    objCommand.Parameters.AddWithValue("@SubscriberId", SubscriberID);
                    success = objCommand.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);

            }
            return success;

        }

        public VMSubscriber GetSubscriberByIdForAddCCDetials(Int32 id)
        {
            VMSubscriber objSubscriber = new VMSubscriber();
            try
            {

                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetSubscriberMyaccountDetail", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@SubscriberId", id);


                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        using (objReader)
                        {

                            objSubscriber.SubscriberId = id;
                            objSubscriber.TitleID = objReader["Title"].ToString();
                            //objSubscriber.RFIDNumber = objReader["RFIDNumber"].ToString();
                            //objSubscriber.CustomerID = objReader["CustomerID"].ToString();
                            objSubscriber.FirstName = objReader["FirstName"].ToString();
                            objSubscriber.LastName = objReader["LastName"].ToString();
                            objSubscriber.EmailAddress = objReader["EmailAddress"].ToString();
                            objSubscriber.DriverLiscence = objReader["DriversLicence"].ToString();
                            objSubscriber.HomeContactNo = objReader["HomeContactNumber"].ToString();
                            objSubscriber.MobileContactNo = objReader["MobileContactNumber"].ToString();
                            objSubscriber.StreetLine = objReader["Street"].ToString();
                            objSubscriber.StreetLine2 = objReader["Streetline2"].ToString();
                            objSubscriber.Suburb = objReader["Suburb"].ToString();
                            objSubscriber.StateId = Convert.ToInt16(objReader["StateID"]);
                            objSubscriber.PostCode = objReader["Postcode"].ToString();
                            objSubscriber.CountryId = Convert.ToInt16(objReader["CountryID"]);
                            objSubscriber.hdncarpark = Convert.ToString(objReader["CarParkID"]);
                            //Payment
                            objSubscriber.PaymentDtls = new PaymentDetails();
                            //objSubscriber.PaymentDtls.CreditCardTypeId = Convert.ToInt16(objReader["CreditCardTypeID"]);
                            //objSubscriber.PaymentDtls.CSVCode = objReader["CSVCode"].ToString();
                            //AutoTopup
                            objSubscriber.AutoTopUpId = Convert.ToInt16(objReader["AutoTopUp"]);
                            objSubscriber.TopUpValue = Convert.ToDecimal(objReader["TopUpValue"]);
                            objSubscriber.TopUpThresholdValue = Convert.ToDecimal(objReader["TopUpThresholdValue"]);
                            objSubscriber.hdnISParkingFeesDefaulter = (bool)(objReader["ISParkingFeesDefaulter"]);
                            objSubscriber.IsActive = (bool)(objReader["IsActive"]);
                            objSubscriber.CountryCode = objReader["CountryCode"].ToString();

                            // objSubscriber.SubscriberId = id;
                            // objSubscriber.TitleID = objReader["Title"].ToString();
                            // objSubscriber.CustomerID = objReader["CustomerID"].ToString();
                            // objSubscriber.FirstName = objReader["FirstName"].ToString();
                            // objSubscriber.LastName = objReader["LastName"].ToString();
                            // objSubscriber.EmailAddress = objReader["EmailAddress"].ToString();
                            // objSubscriber.DriverLiscence = objReader["DriversLicence"].ToString();
                            // objSubscriber.HomeContactNo = objReader["HomeContactNumber"].ToString();
                            // objSubscriber.MobileContactNo = objReader["MobileContactNumber"].ToString();
                            // objSubscriber.StreetLine = objReader["Street"].ToString();
                            // objSubscriber.StreetLine2 = objReader["Streetline2"].ToString();
                            // objSubscriber.Suburb = objReader["Suburb"].ToString();
                            // objSubscriber.StateId = Convert.ToInt32(objReader["StateID"].ToString());
                            // objSubscriber.PostCode = objReader["Postcode"].ToString();
                            // objSubscriber.CountryId = Convert.ToInt16(objReader["CountryID"]);

                            // objSubscriber.CountryCode = objReader["CountryCode"].ToString();
                            // objSubscriber.CarParkID = Convert.ToInt16(objReader["CarParkID"]);
                            ///objSubscriber.ParkTypeId = Convert.ToInt16(objReader["CarParkBayTypeID"]);

                            // objSubscriber.UserName = objReader["UserName"].ToString();
                            // objSubscriber.Password = objReader["Password"].ToString();
                            //objSubscriber.ConfirmPassword = objReader["Password"].ToString();

                            //objSubscriber.lblTitleID = objReader["lTitle"].ToString();
                            //objSubscriber.IsTitleIDReq = (bool)objReader["IsReqTitle"];

                            //objSubscriber.lblFname = objReader["lFirstName"].ToString();
                            //objSubscriber.IsFirstNameReq = (bool)objReader["IsReqFirstName"];

                            //objSubscriber.lblLname = objReader["lLastName"].ToString();
                            //objSubscriber.IsLastNameReq = (bool)objReader["IsReqLastName"];

                            //objSubscriber.lblStreet = objReader["lStreet"].ToString();
                            //objSubscriber.IsStreetLineReq = (bool)objReader["IsReqStreet"];

                            //objSubscriber.lblStreet2 = objReader["lStreetLine"].ToString();
                            //objSubscriber.IsStreetLine2Req = (bool)objReader["IsReqStreetLine"];

                            //objSubscriber.lblEmailAddres = objReader["lEmail"].ToString();
                            //objSubscriber.IsEmailAddressReq = (bool)objReader["IsReqEmail"];

                            //objSubscriber.lblDrivinglic = objReader["lDriverLicence"].ToString();
                            //objSubscriber.IsDriverLiscenceReq = (bool)objReader["IsReqDriverLicence"];

                            //objSubscriber.lblCountry = objReader["lCountry"].ToString();
                            //objSubscriber.lblState = objReader["lState"].ToString();

                            //objSubscriber.lblSuburb = objReader["lSuburb"].ToString();
                            //objSubscriber.IsSuburbReq = (bool)objReader["IsReqSuburb"];

                            //objSubscriber.lblPostCode = objReader["lPostcode"].ToString();
                            //objSubscriber.IsPostCodeReq = (bool)objReader["IsReqPostcode"];

                            //objSubscriber.lblMobileNo = objReader["lMobileNo"].ToString();
                            //objSubscriber.IsMobileContactNoReq = (bool)objReader["IsReqMobileNo"];

                            //objSubscriber.lblHomeNo = objReader["lHomeNo"].ToString();
                            //objSubscriber.IsHomeContactNoReq = (bool)objReader["IsReqHomeNo"];

                            //objSubscriber.IsReqState = (bool)objReader["IsReqState"];
                            //objSubscriber.lblcarparkName = objReader["lCarParkName"].ToString();


                            //if (objReader.NextResult())
                            //{
                            //    List<VMSubscriberDetail.CarPark> listCarPark = new List<VMSubscriberDetail.CarPark>();
                            //    while (objReader.Read())
                            //    {
                            //        VMSubscriberDetail.CarPark objCarPark = new VMSubscriberDetail.CarPark();
                            //        objCarPark.CarParkName = objReader["CarParkName"].ToString();
                            //        objCarPark.CarParkType = objReader["Name"].ToString();
                            //        objCarPark.Isdeleted = (bool)objReader["Isdeleted"];
                            //        objCarPark.CarparkID = objReader["CarparkID"].ToString();
                            //        objCarPark.CarparkBayTypeID = objReader["CarparkBayTypeID"].ToString();
                            //        listCarPark.Add(objCarPark);
                            //    }
                            //    objSubscriber.CarParkListMyDetail = listCarPark;
                            //}

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return objSubscriber;
        }

        public VMSubscriber getSubscriberById(int id)
        {
            VMSubscriber objSubscriber = new VMSubscriber();
            try
            {

                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_UpdateSubscriberDetails", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@SubscriberId", id);
                    objCommand.Parameters.AddWithValue("@Action", "SELECT");

                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        using (objReader)
                        {
                            objSubscriber.SubscriberId = id;
                            objSubscriber.TitleID = objReader["Title"].ToString();
                            objSubscriber.RFIDNumber = objReader["RFIDNumber"].ToString();
                            objSubscriber.CustomerID = objReader["CustomerID"].ToString();
                            objSubscriber.FirstName = objReader["FirstName"].ToString();
                            objSubscriber.LastName = objReader["LastName"].ToString();
                            objSubscriber.EmailAddress = objReader["EmailAddress"].ToString();
                            objSubscriber.DriverLiscence = objReader["DriversLicence"].ToString();
                            objSubscriber.HomeContactNo = objReader["HomeContactNumber"].ToString();
                            objSubscriber.MobileContactNo = objReader["MobileContactNumber"].ToString();
                            objSubscriber.StreetLine = objReader["Street"].ToString();
                            objSubscriber.StreetLine2 = objReader["Streetline2"].ToString();
                            objSubscriber.Suburb = objReader["Suburb"].ToString();
                            objSubscriber.StateId = Convert.ToInt16(objReader["StateID"]);
                            objSubscriber.PostCode = objReader["Postcode"].ToString();
                            objSubscriber.CountryId = Convert.ToInt16(objReader["CountryID"]);
                            objSubscriber.hdncarpark = Convert.ToString(objReader["CarParkID"]);
                            //Payment
                            objSubscriber.PaymentDtls = new PaymentDetails();
                            //objSubscriber.PaymentDtls.CreditCardTypeId = Convert.ToInt16(objReader["CreditCardTypeID"]);
                            //objSubscriber.PaymentDtls.CSVCode = objReader["CSVCode"].ToString();
                            //AutoTopup
                            objSubscriber.AutoTopUpId = Convert.ToInt16(objReader["AutoTopUp"]);
                            objSubscriber.TopUpValue = Convert.ToDecimal(objReader["TopUpValue"]);
                            objSubscriber.TopUpThresholdValue = Convert.ToDecimal(objReader["TopUpThresholdValue"]);
                            objSubscriber.hdnISParkingFeesDefaulter = (bool)(objReader["ISParkingFeesDefaulter"]);
                            objSubscriber.IsActive = (bool)(objReader["IsActive"]);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return objSubscriber;
        }

        public VMSubscriber getSubscriberRFIDandId(int id, int BackOfficeID)
        {
            VMSubscriber objSubscriber = new VMSubscriber();
            try
            {

                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetSubscriberByIdandRfId", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@SubscriberId", id);
                    objCommand.Parameters.AddWithValue("@BackOfficeID", BackOfficeID);


                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        using (objReader)
                        {
                            objSubscriber.SubscriberId = id;
                            objSubscriber.TitleID = objReader["Title"].ToString();
                            objSubscriber.RFIDNumber = objReader["RFIDNumber"].ToString();
                            objSubscriber.CustomerID = objReader["CustomerID"].ToString();
                            objSubscriber.FirstName = objReader["FirstName"].ToString();
                            objSubscriber.LastName = objReader["LastName"].ToString();
                            objSubscriber.EmailAddress = objReader["EmailAddress"].ToString();
                            objSubscriber.DriverLiscence = objReader["DriversLicence"].ToString();
                            objSubscriber.HomeContactNo = objReader["HomeContactNumber"].ToString();
                            objSubscriber.MobileContactNo = objReader["MobileContactNumber"].ToString();
                            objSubscriber.StreetLine = objReader["Street"].ToString();
                            objSubscriber.StreetLine2 = objReader["Streetline2"].ToString();
                            objSubscriber.Suburb = objReader["Suburb"].ToString();
                            objSubscriber.StateId = Convert.ToInt16(objReader["StateID"]);
                            objSubscriber.PostCode = objReader["Postcode"].ToString();
                            objSubscriber.CountryId = Convert.ToInt16(objReader["CountryID"]);
                            objSubscriber.hdncarpark = Convert.ToString(objReader["CarParkID"]);
                            //Payment
                            objSubscriber.PaymentDtls = new PaymentDetails();
                            //objSubscriber.PaymentDtls.CreditCardTypeId = Convert.ToInt16(objReader["CreditCardTypeID"]);
                            //objSubscriber.PaymentDtls.CSVCode = objReader["CSVCode"].ToString();
                            //AutoTopup
                            objSubscriber.AutoTopUpId = Convert.ToInt16(objReader["AutoTopUp"]);
                            objSubscriber.TopUpValue = Convert.ToDecimal(objReader["TopUpValue"]);
                            objSubscriber.TopUpThresholdValue = Convert.ToDecimal(objReader["TopUpThresholdValue"]);
                            objSubscriber.hdnISParkingFeesDefaulter = (bool)(objReader["ISParkingFeesDefaulter"]);
                            objSubscriber.IsActive = (bool)(objReader["IsActive"]);

                   

                    if (objReader.NextResult())
                    {
                        List<CarPark> listCarPark = new List<CarPark>();
                        while (objReader.Read())
                        {
                            CarPark objCarPark = new CarPark();

                            objCarPark.ID = int.Parse(objReader["ID"].ToString());
                            objCarPark.CarParkName = objReader["CarParkName"].ToString();
                            objCarPark.CarParkType = objReader["Name"].ToString();
                            objCarPark.Isdeleted = (bool)objReader["Isdeleted"];
                            objCarPark.CarparkID = objReader["CarparkID"].ToString();
                            objCarPark.CarparkBayTypeID = objReader["CarparkBayTypeID"].ToString();
                            objCarPark.BarCode = objReader["Isexpired"].ToString() == "1" ? objReader["Barcode"].ToString() + "(Expired)" : objReader["Barcode"].ToString();
                            listCarPark.Add(objCarPark);
                        }
                        objSubscriber.CarParkListMyDetail = listCarPark;
                    }

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return objSubscriber;
        }

        public int UpdateSubscriberDtls(VMSubscriber objSubscriber, int ServiceProviderID, int UpdatedBy)
        {
            int success = 0;
            decimal? CCNumber = objSubscriber.PaymentDtls == null ? 0 :
                        Convert.ToDecimal(objSubscriber.PaymentDtls.CreditCardNumber_Add.Substring(objSubscriber.PaymentDtls.CreditCardNumber_Add.Length - 2, 2));

            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_UpdateSubscriberDetails", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@SubscriberId", objSubscriber.SubscriberId);
                    objCommand.Parameters.AddWithValue("@Title", objSubscriber.TitleID);
                    objCommand.Parameters.AddWithValue("@FirstName", objSubscriber.FirstName);
                    objCommand.Parameters.AddWithValue("@LastName", objSubscriber.LastName);
                    objCommand.Parameters.AddWithValue("@EmailAddress", objSubscriber.EmailAddress);
                    objCommand.Parameters.AddWithValue("@DriversLicence", objSubscriber.DriverLiscence);
                    objCommand.Parameters.AddWithValue("@HomeContactNumber", objSubscriber.HomeContactNo);
                    objCommand.Parameters.AddWithValue("@MobileContactNumber", objSubscriber.MobileContactNo);
                    objCommand.Parameters.AddWithValue("@Street", objSubscriber.StreetLine);
                    objCommand.Parameters.AddWithValue("@Streetline2", objSubscriber.StreetLine2);
                    objCommand.Parameters.AddWithValue("@Suburb", objSubscriber.Suburb);
                    objCommand.Parameters.AddWithValue("@State", objSubscriber.StateId);
                    objCommand.Parameters.AddWithValue("@Postcode", objSubscriber.PostCode);
                    objCommand.Parameters.AddWithValue("@CountryID", objSubscriber.CountryId);
                    objCommand.Parameters.AddWithValue("@CreatedID", UpdatedBy);

                    objCommand.Parameters.AddWithValue("@CreditCardTypeId", objSubscriber.PaymentDtls == null ? null : objSubscriber.PaymentDtls.CreditCardTypeId);
                    objCommand.Parameters.AddWithValue("@strCustomerID", objSubscriber.CustomerID == null || objSubscriber.CustomerID == "" ? "NULL" : objSubscriber.CustomerID);
                    objCommand.Parameters.AddWithValue("@CSVCode", objSubscriber.PaymentDtls == null ? null : objSubscriber.PaymentDtls.CSVCode);
                    objCommand.Parameters.AddWithValue("@CreditCardNumber", CCNumber);
                    objCommand.Parameters.AddWithValue("@CCExpiryDate", objSubscriber.PaymentDtls == null ? null : objSubscriber.PaymentDtls.ExpiryDate);
                    objCommand.Parameters.AddWithValue("@AutoTopUpId", objSubscriber.AutoTopUpId);
                    objCommand.Parameters.AddWithValue("@TopUpValue", objSubscriber.TopUpValue);
                    objCommand.Parameters.AddWithValue("@TopUpThresholdValue", objSubscriber.TopUpThresholdValue);
                    objCommand.Parameters.AddWithValue("@Balance", objSubscriber.Balance);
                    objCommand.Parameters.AddWithValue("@ISParkingFeesDefaulter", objSubscriber.hdnISParkingFeesDefaulter);
                    objCommand.Parameters.AddWithValue("@ISActive", objSubscriber.IsActive);

                    objCommand.Parameters.AddWithValue("@Action", "EDIT");

                    if (objSubscriber.hdnDeletedPermitId != null && objSubscriber.hdnDeletedPermitId != "")
                    {
                        objSubscriber.hdnDeletedPermitId = objSubscriber.hdnDeletedPermitId.Remove(objSubscriber.hdnDeletedPermitId.Length - 1);
                    }

                    objCommand.Parameters.AddWithValue("@DeletedPermitID", objSubscriber.hdnDeletedPermitId);

                    DataTable ObjUpdatedPermitTable = new DataTable();

                    ObjUpdatedPermitTable.Columns.Add("ID");
                    ObjUpdatedPermitTable.Columns.Add("CarParkID");
                    ObjUpdatedPermitTable.Columns.Add("CarParkBaytypeID");

                    if (objSubscriber.hdnUpdatedPermitId != null)
                    {
                        string[] Arry = objSubscriber.hdnUpdatedPermitId.Split(',');
                        foreach (var m in Arry)
                        {

                            if (m.Trim() != "")
                            {
                                string[] arry = m.Split(':');
                                if (arry.Count() > 2)
                                    ObjUpdatedPermitTable.Rows.Add(arry[0], arry[1], arry[2]);
                            }

                        }

                    }

                    ObjUpdatedPermitTable.AcceptChanges();






                    SqlParameter tvpParam = objCommand.Parameters.AddWithValue("@UpdatedPermitID", ObjUpdatedPermitTable);
                    tvpParam.SqlDbType = SqlDbType.Structured;

                    objCommand.ExecuteNonQuery();
                }
                success = 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return success;
        }

        public Tuple<Int32, Int32> InsertSubscriberDtls(VMSubscriber objSubscriber, string strPaymentGatewayID, int ServiceProviderID, int CreatedBy, string CarParkId, string ParktypeId, bool IsRFIDChargePaid)
        {

            decimal? CCNumber = objSubscriber.PaymentDtls == null || objSubscriber.PaymentDtls.CreditCardNumber_Add.Contains('X') == true ? 0 :
                       Convert.ToDecimal(objSubscriber.PaymentDtls.CreditCardNumber_Add.Substring(objSubscriber.PaymentDtls.CreditCardNumber_Add.Length - 2, 2));
            int BackofficeID = 0, susbcriberID = 0;

            try
            {

                int i = 1;
                string[] Arry = objSubscriber.hdncarpark.Split(',');
                var table = new DataTable();
                table.Columns.Add("PrfID", typeof(int));
                table.Columns.Add("CarparkID", typeof(int));
                table.Columns.Add("CarParkBayTypeID", typeof(int));
         
                foreach (var d in Arry)
                {
                    i++;
                    string[] arry = d.Split(':');
                    DataRow row = table.NewRow();

                    row["PrfID"] = i;
                    row["CarparkID"] = arry[0];
                    row["CarParkBayTypeID"] = arry[1];


                    table.Rows.Add(row);

                }
                table.AcceptChanges();



                string PaymentGatewayID = strPaymentGatewayID == null ? "" : strPaymentGatewayID;

                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_UpdateSubscriberDetails", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@SubscriberId", objSubscriber.SubscriberId);
                    objCommand.Parameters.AddWithValue("@strCustomerID", PaymentGatewayID);
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderID);
                    objCommand.Parameters.AddWithValue("@Title", objSubscriber.TitleID);
                    objCommand.Parameters.AddWithValue("@FirstName", objSubscriber.FirstName);
                    objCommand.Parameters.AddWithValue("@LastName", objSubscriber.LastName);
                    objCommand.Parameters.AddWithValue("@EmailAddress", objSubscriber.EmailAddress);
                    objCommand.Parameters.AddWithValue("@DriversLicence", objSubscriber.DriverLiscence);
                    objCommand.Parameters.AddWithValue("@HomeContactNumber", objSubscriber.HomeContactNo);
                    objCommand.Parameters.AddWithValue("@MobileContactNumber", objSubscriber.MobileContactNo);
                    objCommand.Parameters.AddWithValue("@Street", objSubscriber.StreetLine);
                    objCommand.Parameters.AddWithValue("@Streetline2", objSubscriber.StreetLine2);
                    objCommand.Parameters.AddWithValue("@Suburb", objSubscriber.Suburb);
                    objCommand.Parameters.AddWithValue("@State", objSubscriber.StateId);
                    objCommand.Parameters.AddWithValue("@Postcode", objSubscriber.PostCode);
                    objCommand.Parameters.AddWithValue("@CountryID", objSubscriber.CountryId);
                    objCommand.Parameters.AddWithValue("@CreatedID", CreatedBy);

                    objCommand.Parameters.AddWithValue("@UserName", objSubscriber.UserName);
                    objCommand.Parameters.AddWithValue("@Password", objSubscriber.Password);

                    objCommand.Parameters.AddWithValue("@CarParkID", CarParkId);
                    objCommand.Parameters.AddWithValue("@ParkType", ParktypeId);

                    //objCommand.Parameters.AddWithValue("@CreditCardTypeId", objSubscriber.PaymentDtls == null ? null : objSubscriber.PaymentDtls.CreditCardTypeId);
                    //objCommand.Parameters.AddWithValue("@CSVCode", objSubscriber.PaymentDtls == null ? null : objSubscriber.PaymentDtls.CSVCode);
                    //objCommand.Parameters.AddWithValue("@CreditCardNumber", CCNumber);
                    //objCommand.Parameters.AddWithValue("@CCExpiryDate", objSubscriber.PaymentDtls == null ? null : objSubscriber.PaymentDtls.ExpiryDate);

                    objCommand.Parameters.AddWithValue("@AutoTopUpId", objSubscriber.AutoTopUpId);
                    objCommand.Parameters.AddWithValue("@TopUpValue", objSubscriber.TopUpValue);
                    objCommand.Parameters.AddWithValue("@TopUpThresholdValue", objSubscriber.TopUpThresholdValue);
                    objCommand.Parameters.AddWithValue("@Balance", objSubscriber.Balance);
                    objCommand.Parameters.AddWithValue("@ApplicationId", objSubscriber.ApplicationId);
                    objCommand.Parameters.AddWithValue("@IsRFIDChargePaid", IsRFIDChargePaid);
                    objCommand.Parameters.AddWithValue("@Action", "INSERT");

                    if (objSubscriber.IsAlertEnable)
                    {
                        objCommand.Parameters.AddWithValue("@AlertSMS", objSubscriber.AlertSMS);
                        objCommand.Parameters.AddWithValue("@AlertEmail", objSubscriber.AlertEMail);
                    }
                    else
                    {
                        objCommand.Parameters.AddWithValue("@AlertSMS", null);
                        objCommand.Parameters.AddWithValue("@AlertEmail", null);
                    }

                    if (objSubscriber.IsOfferEnable)
                    {
                        objCommand.Parameters.AddWithValue("@OfferSMS", objSubscriber.OffersSMS);
                        objCommand.Parameters.AddWithValue("@OfferEmail", objSubscriber.OffersEmail);
                    }
                    else
                    {
                        objCommand.Parameters.AddWithValue("@OfferSMS", null);
                        objCommand.Parameters.AddWithValue("@OfferEmail", null);
                    }


                    SqlParameter tvpParam = objCommand.Parameters.AddWithValue("@type_SubscriberParkingPrefernce", table);// Pass 0 for salary account 
                    tvpParam.SqlDbType = SqlDbType.Structured;

                    //objCommand.ExecuteNonQuery();
                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        BackofficeID = (Convert.ToInt32(objReader["BackOfficeID"]));
                        susbcriberID = (Convert.ToInt32(objReader["SubscriberID"]));
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return Tuple.Create(BackofficeID, susbcriberID);
        }

        public string IsPaymentGatewayReq(int ServiceProviderID)
        {
            string IsPaymentGateway = "";
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_IsPaymentDetailRequired", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderID);
                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        using (objReader)
                        {
                            IsPaymentGateway = objReader["PaymentMode"].ToString();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return IsPaymentGateway;
        }

        public ServiceProviderSettings GetServiceProviderSettings(int ServiceProviderID)
        {
            ServiceProviderSettings objServiceProviderSetting = null;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetServiceProviderSettings", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderID);
                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        using (objReader)
                        {
                            objServiceProviderSetting = new ServiceProviderSettings();

                            objServiceProviderSetting.PaymentRequired = Convert.ToBoolean(objReader["PaymentMode"]);
                            objServiceProviderSetting.ISAlertsVisible = Convert.ToBoolean(objReader["SMS_Alert"]);
                            objServiceProviderSetting.ISOffersVisible = Convert.ToBoolean(objReader["SMS_Offer"]);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return objServiceProviderSetting;
        }

        public string GetLandingPageURL(int ServiceProviderId)
        {
            string landingPageURL = "";
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetLandingPageURL", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderId);
                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        landingPageURL = objReader["landingpageURL"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return landingPageURL;
        }

        //Validate Subscriber's EmailId
        public int ValidateSubscriberEmailId(string EmailID, int ServiceProviderID, int SubscriberId)
        {
            int success = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_ValidateSubscriberEmailId", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@EmailId", EmailID);
                    objCommand.Parameters.AddWithValue("@ServiceProviderId", ServiceProviderID);
                    objCommand.Parameters.AddWithValue("@SubscriberId", SubscriberId);
                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        success = Convert.ToInt16(objReader["Result"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return success;
        }

        //Validate Subscriber's UserName
        public int ValidateSubscriberUserName(string Username, int ServiceProviderID, int SubscriberId)
        {
            int success = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_ValidateSubscriberUserName", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@UserName", Username);
                    objCommand.Parameters.AddWithValue("@SubscriberId", SubscriberId);
                    objCommand.Parameters.AddWithValue("@ServiceProviderId", ServiceProviderID);
                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        success = Convert.ToInt16(objReader["Result"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return success;
        }


        public List<string> getCarparkandType(Int32 subscriberID)
        {
            List<string> ParkAndBay = new List<string>();

            try
            {

                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_getCarparkandType", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@subscriberID", subscriberID);
                //   symbol = objCommand.ExecuteScalar().ToString();
                objReader = objCommand.ExecuteReader();
                while (objReader.Read())
                {
                    ParkAndBay.Add(objReader["carparkid"].ToString());
                    ParkAndBay.Add(objReader["CarParkBayID"].ToString());

                }
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }

            return ParkAndBay;
        }

        //--------------------Preset Changes------------------------------//

        public Tuple<Int32, Int32> InsertSubscriberPresetDtls(VMSubscriber objSubscriber, string strPaymentGatewayID, int ServiceProviderID, int CreatedBy, string CarParkId, string ParktypeId, bool IsRFIDChargePaid)
        {
            int i = 1;
            decimal? CCNumber = objSubscriber.PaymentDtls == null || objSubscriber.PaymentDtls.CreditCardNumber_Add.Contains('X') == true ? 0 :
                       Convert.ToDecimal(objSubscriber.PaymentDtls.CreditCardNumber_Add.Substring(objSubscriber.PaymentDtls.CreditCardNumber_Add.Length - 2, 2));
            int BackofficeID = 0, susbcriberID = 0;

            try
            {


                string[] Arry = objSubscriber.hdncarpark.Split(',');
                var table = new DataTable();
                table.Columns.Add("PrfID", typeof(int));
                table.Columns.Add("CarparkID", typeof(int));
                table.Columns.Add("CarParkBayTypeID", typeof(int));

                foreach (var d in Arry)
                {
                    i++;
                    string[] arry = d.Split(':');
                    DataRow row = table.NewRow();

                    row["PrfID"] = i;
                    row["CarparkID"] = arry[0];
                    row["CarParkBayTypeID"] = arry[1];


                    table.Rows.Add(row);

                }
                table.AcceptChanges();






                string PaymentGatewayID = strPaymentGatewayID == null ? "" : strPaymentGatewayID;

                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_updatesubscriberPresetdetails", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@SubscriberId", objSubscriber.SubscriberId);
                    objCommand.Parameters.AddWithValue("@strCustomerID", PaymentGatewayID);
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderID);
                    objCommand.Parameters.AddWithValue("@Title", objSubscriber.TitleID);
                    objCommand.Parameters.AddWithValue("@FirstName", objSubscriber.FirstName);
                    objCommand.Parameters.AddWithValue("@LastName", objSubscriber.LastName);
                    objCommand.Parameters.AddWithValue("@EmailAddress", objSubscriber.EmailAddress);
                    objCommand.Parameters.AddWithValue("@DriversLicence", objSubscriber.DriverLiscence);
                    objCommand.Parameters.AddWithValue("@HomeContactNumber", objSubscriber.HomeContactNo);
                    objCommand.Parameters.AddWithValue("@MobileContactNumber", objSubscriber.MobileContactNo);
                    objCommand.Parameters.AddWithValue("@Street", objSubscriber.StreetLine);
                    objCommand.Parameters.AddWithValue("@Streetline2", objSubscriber.StreetLine2);
                    objCommand.Parameters.AddWithValue("@Suburb", objSubscriber.Suburb);
                    objCommand.Parameters.AddWithValue("@State", objSubscriber.StateId);
                    objCommand.Parameters.AddWithValue("@Postcode", objSubscriber.PostCode);
                    objCommand.Parameters.AddWithValue("@CountryID", objSubscriber.CountryId);
                    objCommand.Parameters.AddWithValue("@CreatedID", CreatedBy);

                    objCommand.Parameters.AddWithValue("@UserName", objSubscriber.UserName);
                    objCommand.Parameters.AddWithValue("@Password", objSubscriber.Password);

                    objCommand.Parameters.AddWithValue("@CarParkID", CarParkId);
                    objCommand.Parameters.AddWithValue("@ParkType", ParktypeId);

                    //objCommand.Parameters.AddWithValue("@CreditCardTypeId", objSubscriber.PaymentDtls == null ? null : objSubscriber.PaymentDtls.CreditCardTypeId);
                    //objCommand.Parameters.AddWithValue("@CSVCode", objSubscriber.PaymentDtls == null ? null : objSubscriber.PaymentDtls.CSVCode);
                    //objCommand.Parameters.AddWithValue("@CreditCardNumber", CCNumber);
                    //objCommand.Parameters.AddWithValue("@CCExpiryDate", objSubscriber.PaymentDtls == null ? null : objSubscriber.PaymentDtls.ExpiryDate);

                    objCommand.Parameters.AddWithValue("@AutoTopUpId", objSubscriber.AutoTopUpId);
                    objCommand.Parameters.AddWithValue("@TopUpValue", objSubscriber.TopUpValue);
                    objCommand.Parameters.AddWithValue("@TopUpThresholdValue", objSubscriber.TopUpThresholdValue);
                    objCommand.Parameters.AddWithValue("@Balance", objSubscriber.Balance);
                    objCommand.Parameters.AddWithValue("@ApplicationId", objSubscriber.ApplicationId);
                    objCommand.Parameters.AddWithValue("@IsRFIDChargePaid", IsRFIDChargePaid);
                    objCommand.Parameters.AddWithValue("@Action", "INSERT");

                    if (objSubscriber.IsAlertEnable)
                    {
                        objCommand.Parameters.AddWithValue("@AlertSMS", objSubscriber.AlertSMS);
                        objCommand.Parameters.AddWithValue("@AlertEmail", objSubscriber.AlertEMail);
                    }
                    else
                    {
                        objCommand.Parameters.AddWithValue("@AlertSMS", null);
                        objCommand.Parameters.AddWithValue("@AlertEmail", null);
                    }

                    if (objSubscriber.IsOfferEnable)
                    {
                        objCommand.Parameters.AddWithValue("@OfferSMS", objSubscriber.OffersSMS);
                        objCommand.Parameters.AddWithValue("@OfferEmail", objSubscriber.OffersEmail);
                    }
                    else
                    {
                        objCommand.Parameters.AddWithValue("@OfferSMS", null);
                        objCommand.Parameters.AddWithValue("@OfferEmail", null);
                    }


                    SqlParameter tvpParam = objCommand.Parameters.AddWithValue("@type_SubscriberParkingPrefernce", table);// Pass 0 for salary account 
                    tvpParam.SqlDbType = SqlDbType.Structured;

                    objCommand.Parameters.AddWithValue("@Barcode", objSubscriber.RFIDNumber);

                    //objCommand.ExecuteNonQuery();
                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        BackofficeID = (Convert.ToInt32(objReader["BackOfficeID"]));
                        susbcriberID = (Convert.ToInt32(objReader["SubscriberID"]));
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return Tuple.Create(BackofficeID, susbcriberID);
        }

        //----------------------------------------------------------------//

    }

}
