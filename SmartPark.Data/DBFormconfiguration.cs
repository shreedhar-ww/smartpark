using SmartPark.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartPark.Data
{
    public class DBFormconfiguration : DBHelper
    {

        /// <summary>
        /// Insert DocumentationConfig
        /// </summary>
        /// <param name="objPricing">model object containing the details of the view</param>
        /// <param name="CreatedBy">System UserId</param>
        /// <param name="ServiceProvideID"> ServiceProvideID </param>
        /// <returns> 1 if data saved successfully</returns>
        public int InsertConfigDocumentation(FormConfiguration objFormConfiguration, int createdBy, int serviceproviderID)
        {
            int success = 0;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_InsertRegisterUIDetail", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objCommand.Parameters.AddWithValue("@Title", objFormConfiguration.Title);
                objCommand.Parameters.AddWithValue("@IsReqTitle", objFormConfiguration.IsReqTitle);

                objCommand.Parameters.AddWithValue("@FirstName", objFormConfiguration.FirstName);
                objCommand.Parameters.AddWithValue("@IsReqFirstName", objFormConfiguration.IsReqFirstName);

                objCommand.Parameters.AddWithValue("@LastName", objFormConfiguration.LastName);
                objCommand.Parameters.AddWithValue("@IsReqLastName", objFormConfiguration.IsReqLastName);

                objCommand.Parameters.AddWithValue("@Street", objFormConfiguration.Street);
                objCommand.Parameters.AddWithValue("@IsReqStreet", objFormConfiguration.IsReqStreetLine);

                objCommand.Parameters.AddWithValue("@StreetLine", objFormConfiguration.StreetLine);
                objCommand.Parameters.AddWithValue("@IsReqStreetLine", objFormConfiguration.IsReqStreetLine);


                objCommand.Parameters.AddWithValue("@Email", objFormConfiguration.Email);
                objCommand.Parameters.AddWithValue("@IsReqEmail", objFormConfiguration.IsReqEmail);

                objCommand.Parameters.AddWithValue("@DriverLicence", objFormConfiguration.DriverLicence);
                objCommand.Parameters.AddWithValue("@IsReqDriverLicence", objFormConfiguration.IsReqDriverLicence);

                objCommand.Parameters.AddWithValue("@Country", objFormConfiguration.Country);
                objCommand.Parameters.AddWithValue("@IsReqCountry", objFormConfiguration.IsReqCountry);


                objCommand.Parameters.AddWithValue("@State", objFormConfiguration.State);
                objCommand.Parameters.AddWithValue("@IsReqState", objFormConfiguration.IsReqState);

                objCommand.Parameters.AddWithValue("@Suburb", objFormConfiguration.Suburb);
                objCommand.Parameters.AddWithValue("@IsReqSuburb", objFormConfiguration.IsReqSuburb);

                objCommand.Parameters.AddWithValue("@Postcode", objFormConfiguration.Postcode);
                objCommand.Parameters.AddWithValue("@IsReqPostcode", objFormConfiguration.IsReqPostcode);

                objCommand.Parameters.AddWithValue("@MobileNo", objFormConfiguration.MobileNo);
                objCommand.Parameters.AddWithValue("@IsReqMobileNo", objFormConfiguration.IsReqMobileNo);

                objCommand.Parameters.AddWithValue("@HomeNo", objFormConfiguration.HomeNo);
                objCommand.Parameters.AddWithValue("@IsReqHomeNo ", objFormConfiguration.IsReqHomeNo);

                objCommand.Parameters.AddWithValue("@serviceproviderID", serviceproviderID);

                objCommand.Parameters.AddWithValue("@CreatedBy", createdBy);


                objCommand.Parameters.AddWithValue("@CarParkName", objFormConfiguration.CarParkName);
                objCommand.Parameters.AddWithValue("@IsReqCarParkName ", objFormConfiguration.IsCarParkName);


                success = Convert.ToInt32(objCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
            return success;

        }


        public FormConfiguration GetFormConfiguration(int ServiceProviderId)
        {
            FormConfiguration objFormConfiguration = new FormConfiguration();

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetFormConfiguration", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@intServiceProviderID", ServiceProviderId);
                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {

                        objFormConfiguration.hdnFormID = Convert.ToInt32(objReader["ID"]);
                        objFormConfiguration.Title = objReader["Title"].ToString();
                        objFormConfiguration.IsReqTitle =(bool) objReader["IsReqTitle"];

                        objFormConfiguration.FirstName = objReader["FirstName"].ToString();
                        objFormConfiguration.IsReqFirstName =(bool) objReader["IsReqFirstName"];

                        objFormConfiguration.LastName = objReader["LastName"].ToString();
                        objFormConfiguration.IsReqLastName = (bool)objReader["IsReqLastName"];


                        objFormConfiguration.Street = objReader["Street"].ToString();
                        objFormConfiguration.IsReqStreet =(bool) objReader["IsReqStreet"];

                        objFormConfiguration.LastName = objReader["LastName"].ToString();
                        objFormConfiguration.IsReqLastName = (bool)objReader["IsReqLastName"];

                        objFormConfiguration.StreetLine = objReader["StreetLine"].ToString();
                        objFormConfiguration.IsReqStreetLine = (bool)objReader["IsReqStreetLine"];

                        objFormConfiguration.Email = objReader["Email"].ToString();
                        objFormConfiguration.IsReqEmail =(bool) objReader["IsReqEmail"];
                         
                        objFormConfiguration.Email = objReader["Email"].ToString();
                        objFormConfiguration.IsReqEmail =(bool) objReader["IsReqEmail"];

                        objFormConfiguration.DriverLicence = objReader["DriverLicence"].ToString();
                        objFormConfiguration.IsReqDriverLicence = (bool)objReader["IsReqDriverLicence"];


                        objFormConfiguration.Country = objReader["Country"].ToString();
                        objFormConfiguration.IsReqCountry = (bool)objReader["IsReqCountry"];


                        objFormConfiguration.State = objReader["State"].ToString();
                        objFormConfiguration.IsReqState = (bool)objReader["IsReqState"];



                        objFormConfiguration.Suburb = objReader["Suburb"].ToString();
                        objFormConfiguration.IsReqSuburb = (bool)objReader["IsReqSuburb"];



                        objFormConfiguration.Postcode = objReader["Postcode"].ToString();
                        objFormConfiguration.IsReqPostcode = (bool)objReader["IsReqPostcode"];




                        objFormConfiguration.MobileNo = objReader["MobileNo"].ToString();
                        objFormConfiguration.IsReqMobileNo = (bool)objReader["IsReqMobileNo"];


                        objFormConfiguration.HomeNo = objReader["HomeNo"].ToString();
                        objFormConfiguration.IsReqHomeNo = (bool)objReader["IsReqHomeNo"];

                        objFormConfiguration.CarParkName = objReader["CarParkName"].ToString();
                        objFormConfiguration.IsCarParkName = (bool)objReader["IsReqCarParkName"];


                        objFormConfiguration.CarParkName = objReader["CarParkName"].ToString();
                        objFormConfiguration.IsCarParkName = (bool)objReader["IsReqCarParkName"];



                    }
                    return objFormConfiguration;

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
            return objFormConfiguration;


        }


        public int UpdateConfigDocumentation(FormConfiguration objFormConfiguration, int createdBy, int serviceproviderID)
        {
            int success = 0;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_UpdateFormConfiguration", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objCommand.Parameters.AddWithValue("@Title", objFormConfiguration.Title);
                objCommand.Parameters.AddWithValue("@IsReqTitle", objFormConfiguration.IsReqTitle);

                objCommand.Parameters.AddWithValue("@FirstName", objFormConfiguration.FirstName);
                objCommand.Parameters.AddWithValue("@IsReqFirstName", objFormConfiguration.IsReqFirstName);

                objCommand.Parameters.AddWithValue("@LastName", objFormConfiguration.LastName);
                objCommand.Parameters.AddWithValue("@IsReqLastName", objFormConfiguration.IsReqLastName);

                objCommand.Parameters.AddWithValue("@Street", objFormConfiguration.Street);
                objCommand.Parameters.AddWithValue("@IsReqStreet", objFormConfiguration.IsReqStreet);

                objCommand.Parameters.AddWithValue("@StreetLine", objFormConfiguration.StreetLine);
                objCommand.Parameters.AddWithValue("@IsReqStreetLine", objFormConfiguration.IsReqStreetLine);


                objCommand.Parameters.AddWithValue("@Email", objFormConfiguration.Email);
                objCommand.Parameters.AddWithValue("@IsReqEmail", objFormConfiguration.IsReqEmail);

                objCommand.Parameters.AddWithValue("@DriverLicence", objFormConfiguration.DriverLicence);
                objCommand.Parameters.AddWithValue("@IsReqDriverLicence", objFormConfiguration.IsReqDriverLicence);

                objCommand.Parameters.AddWithValue("@Country", objFormConfiguration.Country);
                objCommand.Parameters.AddWithValue("@IsReqCountry", objFormConfiguration.IsReqCountry);


                objCommand.Parameters.AddWithValue("@State", objFormConfiguration.State);
                objCommand.Parameters.AddWithValue("@IsReqState", objFormConfiguration.IsReqState);

                objCommand.Parameters.AddWithValue("@Suburb", objFormConfiguration.Suburb);
                objCommand.Parameters.AddWithValue("@IsReqSuburb", objFormConfiguration.IsReqSuburb);

                objCommand.Parameters.AddWithValue("@Postcode", objFormConfiguration.Postcode);
                objCommand.Parameters.AddWithValue("@IsReqPostcode", objFormConfiguration.IsReqPostcode);

                objCommand.Parameters.AddWithValue("@MobileNo", objFormConfiguration.MobileNo);
                objCommand.Parameters.AddWithValue("@IsReqMobileNo", objFormConfiguration.IsReqMobileNo);

                objCommand.Parameters.AddWithValue("@HomeNo", objFormConfiguration.HomeNo);
                objCommand.Parameters.AddWithValue("@IsReqHomeNo ", objFormConfiguration.IsReqHomeNo);

                objCommand.Parameters.AddWithValue("@ID", objFormConfiguration.hdnFormID);

                objCommand.Parameters.AddWithValue("@updateby", createdBy);


                objCommand.Parameters.AddWithValue("@CarParkName", objFormConfiguration.CarParkName);
                objCommand.Parameters.AddWithValue("@IsReqCarParkName ", objFormConfiguration.IsCarParkName);

                success = Convert.ToInt32(objCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
            return success;

        }

    }
}
