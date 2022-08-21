using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPark.Entity;
using SmartPark.Helper;

namespace SmartPark.Data
{
    public class DBWorkFlow : DBHelper
    {

        public int UpdateFlowValue(WorkFlow model, int ServiceProviderID, int UpdatedBy)
        {
            int Success ;

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_UpdatedWorkFlow", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@FacebookIntergration", model.FacebookIntegration);
               // objCommand.Parameters.AddWithValue("@Payments", model.Payments);
                objCommand.Parameters.AddWithValue("@SMSAlert", model.SMSAlert);
                objCommand.Parameters.AddWithValue("@SMSOffer", model.SMSOffer);
                objCommand.Parameters.AddWithValue("@ElectronicStatement", model.ElectronicStatement);
                objCommand.Parameters.AddWithValue("@TermsConditions", model.TermAndConditions);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderID);
                objCommand.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                Success =Convert.ToInt16(objCommand.ExecuteScalar());

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

        // usp_GetWorkFlowDetail

        public WorkFlow GetFlowValue(int ServiceProviderID)
        {

            WorkFlow objWorkFlow = new WorkFlow();

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetWorkFlowDetail", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderID);


                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        objWorkFlow.FacebookIntegration = (bool)objReader["FacebookIntergration"];
                        objWorkFlow.Payments = (bool)objReader["Payments"];
                        objWorkFlow.SMSAlert = (bool)objReader["SMS_Alert"];
                        objWorkFlow.SMSOffer = (bool)objReader["SMS_Offer"];
                        objWorkFlow.ElectronicStatement = (bool)objReader["ElectronicStatement"];
                        objWorkFlow.TermAndConditions = (bool)objReader["TermsConditions"];
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
            return objWorkFlow;
        }
    }
}
