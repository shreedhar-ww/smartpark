using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPark.Entity;
using SmartPark.Helper;
using System.Web.Mvc;

namespace SmartPark.Data
{
    public class DBServiceProviderDetail : DBHelper
    {
        public List<VMServiceProvider> GetAllServiceProviderDetail(string page, string sortdir, string sortColumn, string ServiceProviderName)
        {

            List<VMServiceProvider> ListServiceProviderDetail = new List<VMServiceProvider>();
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "Name_ASC";
            string ProviderName = !string.IsNullOrEmpty(ServiceProviderName) ? ServiceProviderName : "";
            try
            {
                
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();  
                objCommand = new SqlCommand("usp_GetAllServiceProviderDetail", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PageNbr", page);
                objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                objCommand.Parameters.AddWithValue("@ServiceProviderName", ProviderName);
                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        VMServiceProvider ObjServiceProvider = new VMServiceProvider();
                        ObjServiceProvider.strServiceProviderName = objReader["ServiceProviderName"].ToString();
                        ObjServiceProvider.strServiceURL = objReader["PortalURL"].ToString();
                        ObjServiceProvider.PaymentMode = objReader["PaymentMode"].ToString();
                        ObjServiceProvider.bIsActive = (bool)objReader["ISActive"];
                        ObjServiceProvider.PortalServiceProviderID = AESEncryption.Encrypt(objReader["PortalServiceProviderID"].ToString());
                        ObjServiceProvider.TotalCount = Convert.ToInt16(objReader["TotalCount"]); ; ;
                        ListServiceProviderDetail.Add(ObjServiceProvider);
                    }
                    return ListServiceProviderDetail;
                }
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
            return ListServiceProviderDetail;


        }


        public List<ServiceProvider> GetAllDisabledServiceProvider()
        {
            List<ServiceProvider> listserviceProvider = new List<ServiceProvider>();
            //List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetAllDisabledServiceProvider", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        ServiceProvider objServiceProvider = new ServiceProvider();
                        objServiceProvider.ServiceProviderName = objReader["ServiceProviderName"].ToString();
                        objServiceProvider.ServiceProviderID = Convert.ToInt32(objReader["ServiceProviderID"]);
                        listserviceProvider.Add(objServiceProvider);
                    }
                    return listserviceProvider;


                }
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
            return listserviceProvider;


        }


        public List<ServiceProvider> GetAllServiceProvider()
        {
            List<ServiceProvider> listserviceProvider = new List<ServiceProvider>();
            //List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetAllServiceProvider", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        ServiceProvider objServiceProvider = new ServiceProvider();
                        objServiceProvider.ServiceProviderName = objReader["ServiceProviderName"].ToString();
                        objServiceProvider.ServiceProviderID = Convert.ToInt32(objReader["ServiceProviderID"]);
                        listserviceProvider.Add(objServiceProvider);
                    }
                    return listserviceProvider;


                }
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
            return listserviceProvider;


        }

        public VMServiceProvider GetServiceProviderDetailByID(string PortalServiceProviderID)
        {
            VMServiceProvider ObjServiceProvider = new VMServiceProvider();
            try
            {

                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetServiceProviderDetailByID", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PortalServiceProviderID", AESEncryption.Decrypt(PortalServiceProviderID));
                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        ObjServiceProvider.PortalServiceProviderID = AESEncryption.Encrypt((objReader["PortalServiceProviderID"]).ToString());
                        ObjServiceProvider.PaymewntModeId = (int)objReader["PaymentModeID"];
                        ObjServiceProvider.hdnPreviousPayType = ObjServiceProvider.PaymewntModeId;
                        ObjServiceProvider.strServiceURL = objReader["PortalURL"].ToString();
                        ObjServiceProvider.bIsActive = (Boolean)objReader["IsActive"];
                        ObjServiceProvider.ServiceProviderID =  Convert.ToInt64(objReader["ServiceProviderID"].ToString());
                        string commaseparatedstring = objReader["Carparkdetails"].ToString();
                        ObjServiceProvider.SelectedCarParkValues = ToIntArray(commaseparatedstring, ',');
                        //ObjServiceProvider.SelectedCarParkValues = 

                    }


                }
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

            return ObjServiceProvider;
        }

        public int InsertServiceProviderDetail(VMServiceProvider serviceProvider, int createdby)
        {

            int success = 0;
            string carparkcommaseparedvalue = "";
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_InsertPortalServiceProviderDetail", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceProvider.ServiceProviderID);
                // objCommand.Parameters.AddWithValue("@PortalURL", serviceProvider.strServiceURL);
                objCommand.Parameters.AddWithValue("@PaymentModeID", serviceProvider.PaymewntModeId);
                objCommand.Parameters.AddWithValue("@IsActive", serviceProvider.bIsActive);
                //theme is set by default
                objCommand.Parameters.AddWithValue("@PortalThemeID", 1);
                objCommand.Parameters.AddWithValue("@CreatedBy", createdby);
                objCommand.Parameters.AddWithValue("@UpdatedBy", createdby);
                //Hard code value for Car park detail
                if (serviceProvider.SelectedCarParkValues != null)
                {
                    carparkcommaseparedvalue = getCommaseparatedValue(serviceProvider.SelectedCarParkValues);
                }
                objCommand.Parameters.AddWithValue("@CarParkDetails", carparkcommaseparedvalue);

                success = (Int32)objCommand.ExecuteScalar();

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

        public string getCommaseparatedValue(int[] carparklist)
        {
            string concatedstring = "";
            for (int i = 1; i <= carparklist.Length; i++)
            {
                concatedstring += carparklist[i - 1].ToString();
                if (i != carparklist.Length)
                {
                    concatedstring += ",";
                }
            }
            return concatedstring;

        }

        public int UpdateServiceProviderDetail(VMServiceProvider ObjServiceProvider, int UpdatedBy)
        {
            int Success = 0;

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_UpdatedPortalServiceProviderDetail", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PaymentModeID", ObjServiceProvider.PaymewntModeId);
                objCommand.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCommand.Parameters.AddWithValue("@IsActive", ObjServiceProvider.bIsActive);
                //Hard code value
                if (ObjServiceProvider.SelectedCarParkValues != null)
                {
                    objCommand.Parameters.AddWithValue("@CarparkDetail",getCommaseparatedValue(ObjServiceProvider.SelectedCarParkValues));
                }
                else{
                objCommand.Parameters.AddWithValue("@CarparkDetail","");
                }       
                objCommand.Parameters.AddWithValue("@PortalServiceProviderID", AESEncryption.Decrypt(ObjServiceProvider.PortalServiceProviderID));
                Success = objCommand.ExecuteNonQuery();
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
            return Success;
        }

        public string getServiceURL(int serviceProviderID)
        {

            string serviceProviderURL = null;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetPortalURL", objConnection);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceProviderID);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                serviceProviderURL = objCommand.ExecuteScalar().ToString();


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
            return serviceProviderURL;
        }

        public int[] ToIntArray(string value, char separator)
        {
            return Array.ConvertAll(value.Split(separator), s => int.Parse(s));
        }

        public List<string> GetSubscriberEmailWithPaymentTypeSalary(int serviceProviderID)
        {
            List<string> listemailaddress = new List<string>();
            //List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetSubscriberEmailWithPaymentTypeSalary", objConnection);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceProviderID);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                      listemailaddress.Add(objReader["EmailAddress"].ToString());
                    }
                    return listemailaddress;


                }
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
            return listemailaddress;
           
        }
    }
}
