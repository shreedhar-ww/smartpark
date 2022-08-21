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
    public class DBPaymentGatewayOfServiceProvider : DBHelper
    {
        public VMPaymentGatewayOfServiceProvider GetServiceProviderPaymentGatewayDetails(int ServiceProviderId, int CarParkID)
        {
            VMPaymentGatewayOfServiceProvider objVMSPPaymentGateway = new VMPaymentGatewayOfServiceProvider();
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetPaymentGatewayDetails", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderId);
                    objCommand.Parameters.AddWithValue("@CarParkID", CarParkID);
                    objReader = objCommand.ExecuteReader();
                    using (objReader)
                    {
                        if (objReader.HasRows)
                        {
                            while (objReader.Read())
                            {

                                //GatewayID 
                                objVMSPPaymentGateway.GatewayID = Convert.ToInt32(objReader["PaymentGatewayID"]);
                                //EWAY
                                objVMSPPaymentGateway.EwayCustomerID = objReader["EwayCustomerID"].ToString();
                                objVMSPPaymentGateway.EwayUsername = objReader["EwayUsername"].ToString();
                                objVMSPPaymentGateway.EwayPassword = objReader["EwayPassword"].ToString();

                                objVMSPPaymentGateway.APIkey = objReader["APIKey"].ToString();
                            
                                objVMSPPaymentGateway.EwayRFIDCharges = objReader["RFIDCharges"] == DBNull.Value ? 0 : Convert.ToDecimal(objReader["RFIDCharges"]);
                                //PAYPAL
                                objVMSPPaymentGateway.AccountNo = objReader["AccountNo"].ToString();
                                objVMSPPaymentGateway.Credentials = objReader["Credentials"].ToString();
                                objVMSPPaymentGateway.ElectronicBusinessNo = objReader["ElectronicBusinessNo"].ToString();
                                objVMSPPaymentGateway.TerminalIdentifier = objReader["TerminalIdentifier"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return objVMSPPaymentGateway;
        }

        public VMPaymentGatewayOfServiceProvider GetServiceProviderPaymentGatewayDetailsFromSubscriberID(int ServiceProviderId, int SubscriberID)
        {
            VMPaymentGatewayOfServiceProvider objVMSPPaymentGateway = new VMPaymentGatewayOfServiceProvider();
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_PaymentDetailFromSubscriberID", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderId);
                    objCommand.Parameters.AddWithValue("@SubscriberID", SubscriberID);
                    objReader = objCommand.ExecuteReader();
                    using (objReader)
                    {
                        if (objReader.HasRows)
                        {
                            while (objReader.Read())
                            {
                                //EWAY
                                objVMSPPaymentGateway.EwayCustomerID = objReader["EwayCustomerID"].ToString();
                                objVMSPPaymentGateway.EwayUsername = objReader["EwayUsername"].ToString();
                                objVMSPPaymentGateway.EwayPassword = objReader["EwayPassword"].ToString();
                                //PAYPAL
                                objVMSPPaymentGateway.AccountNo = objReader["AccountNo"].ToString();
                                objVMSPPaymentGateway.Credentials = objReader["Credentials"].ToString();
                                objVMSPPaymentGateway.ElectronicBusinessNo = objReader["ElectronicBusinessNo"].ToString();
                                objVMSPPaymentGateway.TerminalIdentifier = objReader["TerminalIdentifier"].ToString();

                                objVMSPPaymentGateway.GatewayId = Convert.ToInt32(objReader["PaymentGatewayID"]);
                                objVMSPPaymentGateway.RFIDCharges = Convert.ToDecimal(objReader["RFIDCharges"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return objVMSPPaymentGateway;
        }

        public string GetTokenIDforBySubscriber(int SubscriberID)
        {
            string TokenID = "0";
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetTokenIDFromSubscriberID", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@SubscriberID",SubscriberID);
                    objReader = objCommand.ExecuteReader();
                    using (objReader)
                    {
                        if (objReader.HasRows)
                        {
                            if (objReader.Read())
                            {
                                //EWAY
                                TokenID = objReader["CustomerID"].ToString();
                              
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return TokenID;
        }
    }
}
