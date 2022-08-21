using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SmartPark.Entity;

namespace SmartPark.Data
{
    public class DBServiceProvider : DBHelper
    {
        public List<SelectListItem> GetAllServiceProvider()
        {
            List<ServiceProvider> listserviceProvider = new List<ServiceProvider>();
            List<SelectListItem> items = new List<SelectListItem>();
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
                        items.Add(new SelectListItem() { Text = objReader["ServiceProviderName"].ToString(), Value = Convert.ToInt32(objReader["ServiceProviderID"]).ToString(), Selected = false });
                    }                  

                }
                else
                {
                    items.Add(new SelectListItem() { Text = "Pseudo Service Provider", Value = "-1", Selected = false });
                }
                return items;
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
            return items;


        }
        
        public ServiceProviderInfo GetServiceProviderNamdandIDByUserID(int systemUserID)
        {
            
            ServiceProviderInfo objserviceProviderInfo = null;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetServiceProviderIDByUserID", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@SystemUserID", systemUserID);

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    objserviceProviderInfo = new ServiceProviderInfo();
                    while (objReader.Read())
                    {
                        objserviceProviderInfo.ServiceProviderID = Convert.ToInt32(objReader["ServiceProviderID"].ToString());
                        objserviceProviderInfo.ServiceProviderName =  objReader["ServiceProviderName"].ToString();  
                    }
                    return objserviceProviderInfo;

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
            return objserviceProviderInfo;
        
        }



        public string GetServiceProviderLogoByID(int ID)
        {
            string path = null;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetServiceProviderLogoByID", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ServiceProviderID",ID);

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                   
                    if (objReader.Read())
                    {

                        path = objReader["ClientLogo"].ToString();
                    }
                    return path;

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

            return path;
           
        }

        //--------------Preset Changes-----------//
        public string GetServiceProviderPaymentMethodByID(int ID)
        {
            string PaymentTypeID = null;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetServiceProviderPaymentTypeByID", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ServiceProviderID", ID);

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {

                    if (objReader.Read())
                    {

                        PaymentTypeID = objReader["PaymentModeID"].ToString();
                    }
                    return PaymentTypeID;

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

            return PaymentTypeID;

        }
        //---------------------------------------//
    }
}
