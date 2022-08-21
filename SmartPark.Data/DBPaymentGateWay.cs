using SmartPark.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SmartPark.Helper;

namespace SmartPark.Data
{
    public class DBPaymentGateWay : DBHelper
    {
        //Get all payment gateway type 
        public List<PaymentGateway> GetAllPaymentGateWays()
        {
            List<PaymentGateway> listPaymentGateWays = new List<PaymentGateway>();
            //List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetAllGateway", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        PaymentGateway objPayment = new PaymentGateway();
                        {
                            // Text = objReader["PaymentModeID"].ToString(),
                            objPayment.PaymentGatewayID = Convert.ToInt32(objReader["PaymentGatewayID"]);
                            objPayment.PaymentGatewayName = (objReader["PaymentGatewayName"]).ToString();
                            listPaymentGateWays.Add(objPayment);

                        }
                    }
                    return listPaymentGateWays;

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
            return listPaymentGateWays;


        }

        //Insert Eway PaymentGatewayInfo

        public int InsertEwayCredentials(VMEwayPaymentGateway Ewaycredentials, int ServiceProviderID, int createdby, int updatedby)
        {
            int success = 0;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_InsertServiceProviderPaymentGatewayCredentials", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderID);
                objCommand.Parameters.AddWithValue("@PaymentGatewayID", Ewaycredentials.GateWayID);
                objCommand.Parameters.AddWithValue("@CarParkId", Ewaycredentials.CarParkId);
                objCommand.Parameters.AddWithValue("@CreatedBy", createdby);
                objCommand.Parameters.AddWithValue("@UpdatedBy", createdby);
                objCommand.Parameters.AddWithValue("@EwayCustomerID", Ewaycredentials.CustomerID);
                objCommand.Parameters.AddWithValue("@EwayUsername", Ewaycredentials.UserID);
                objCommand.Parameters.AddWithValue("@EwayPassword", Ewaycredentials.Password);
                objCommand.Parameters.AddWithValue("@APIKey", Ewaycredentials.APIKey);
                //objCommand.Parameters.AddWithValue("@CurrencySymbol", Ewaycredentials.CurrencySymbol);
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


        //Get serviceprovider Payment Gateway credentials
        public VMEwayPaymentGateway GetEwayCredentials(int serviceproviderID, int CarParkId)
        {

            VMEwayPaymentGateway objEwayCredentials = null;

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetServiceProviderPaymentGatewayCredentials", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceproviderID);
                objCommand.Parameters.AddWithValue("@CarParkId", CarParkId);

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    objEwayCredentials = new VMEwayPaymentGateway();

                    while (objReader.Read())
                    {
                        {
                            // Text = objReader["PaymentModeID"].ToString(),
                            //objEwayCredentials.CustomerID = Convert.ToInt32(objReader["EwayCustomerID"]);
                            objEwayCredentials.CustomerID = (objReader["EwayCustomerID"]).ToString();
                            objEwayCredentials.UserID = (objReader["EwayUsername"]).ToString();
                            objEwayCredentials.Password = (objReader["EwayPassword"]).ToString();
                            objEwayCredentials.GateWayID = Convert.ToInt32(objReader["PaymentGatewayID"]);
                            //objEwayCredentials.RFIDCharges = objReader["RFIDCharges"] == DBNull.Value ? 0 : Convert.ToDecimal(objReader["RFIDCharges"]);
                            objEwayCredentials.PaymentGateWayInfoID = AESEncryption.Encrypt((objReader["PortalPaymentGateWayInfoID"]).ToString());
                            objEwayCredentials.APIKey = (objReader["APIkey"]).ToString();
                            //objEwayCredentials.CurrencySymbol = (objReader["CurrencySymbol"]).ToString();

                            return objEwayCredentials;
                        }
                    }
                    return objEwayCredentials;
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
            return objEwayCredentials;
        }


        public int UpdateGatewayCredentials(VMEwayPaymentGateway objewaycredentials, int UpdatedBy)
        {
            int Success = 0;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_UpdatedPaymentGatewayCredentials", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PortalPaymentGateWayInfoID", AESEncryption.Decrypt(objewaycredentials.PaymentGateWayInfoID));
                objCommand.Parameters.AddWithValue("@EwayCustomerID", objewaycredentials.CustomerID);
                //objCommand.Parameters.AddWithValue("@CurrencySymbol", objewaycredentials.CurrencySymbol);
                objCommand.Parameters.AddWithValue("@EwayUsername", objewaycredentials.UserID);
                objCommand.Parameters.AddWithValue("@EwayPassword", objewaycredentials.Password);
                //objCommand.Parameters.AddWithValue("@RFIDCharges", objewaycredentials.RFIDCharges);
                objCommand.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCommand.Parameters.AddWithValue("@APIkey", objewaycredentials.APIKey);
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

        //

    }
}
