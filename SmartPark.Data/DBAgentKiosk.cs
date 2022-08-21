using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPark.Entity;
using SmartPark.Helper;


namespace SmartPark.Data
{
    public class DBAgentKiosk : DBHelper
    {
        public List<VMAgentKiosk> GetAllSubscribers(string page, string sortdir, string sortColumn, int ServiceProvider, VMAgentKiosk objAgentKiosk)
        {
            List<VMAgentKiosk> ListAgentKiosk = new List<VMAgentKiosk>();
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "BackOfficeID_DESC";
            string RFIDNumber = !string.IsNullOrEmpty(objAgentKiosk.RFIDNumber) ? objAgentKiosk.RFIDNumber : "";
            string FirstName = !string.IsNullOrEmpty(objAgentKiosk.FirstName) ? objAgentKiosk.FirstName.Trim() : "";
            string LastName = !string.IsNullOrEmpty(objAgentKiosk.LastName) ? objAgentKiosk.LastName.Trim() : "";

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetSubscriberDetail", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PageNbr", page);
                objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProvider);
                objCommand.Parameters.AddWithValue("@RFIDNumber", RFIDNumber);
                objCommand.Parameters.AddWithValue("@LastName", LastName);
                objCommand.Parameters.AddWithValue("@FirstName", FirstName);


                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    using (objReader)
                    {
                        while (objReader.Read())
                        {
                            VMAgentKiosk modelAgentKiosk = new VMAgentKiosk();
                            modelAgentKiosk.RFIDNumber = objReader["RFIDNumber"].ToString();
                            modelAgentKiosk.SubscriberId = Convert.ToInt32(objReader["SubscriberID"]);
                            modelAgentKiosk.SubscriberName = objReader["Subscriber"].ToString();
                            modelAgentKiosk.Address = objReader["Address"].ToString();
                            modelAgentKiosk.PermitState = objReader["PermitState"].ToString();
                            modelAgentKiosk.TotalCount = Convert.ToInt32(objReader["TotalCount"]);
                            modelAgentKiosk.BackOfficeID = Convert.ToInt32(objReader["BackOfficeID"]);
                            ListAgentKiosk.Add(modelAgentKiosk);
                        }
                        return ListAgentKiosk;

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
            return ListAgentKiosk;
        }



        public string GetCurrencySymbol(int ServiceProviderID)
        {
            string symbol = "$";

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetCurrencySymbol", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderID);
                symbol = objCommand.ExecuteScalar().ToString();

                symbol = symbol.Replace(' ', '@');

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

            return symbol;
        }


        public string GetCurrencySymbolandRFIDCharges(int ServiceProviderID)
        {
            string symbol = "$";

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetCurrencySymbol", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderID);
                symbol = objCommand.ExecuteScalar().ToString();

                symbol = symbol.Replace(' ', '@');

               
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

            return symbol;
        }


        ///////////////----------------------------Preset DB Changes------------------------//////////////////////////////////


        public List<VMAgentKiosk> GetAllSubscribersPreset(string page, string sortdir, string sortColumn, int ServiceProvider, VMAgentKiosk objAgentKiosk)
        {
            List<VMAgentKiosk> ListAgentKiosk = new List<VMAgentKiosk>();
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "BackOfficeID_DESC";
            string PermitState = !string.IsNullOrEmpty(objAgentKiosk.PermitState) ? objAgentKiosk.PermitState : "";
            string FirstName = !string.IsNullOrEmpty(objAgentKiosk.FirstName) ? objAgentKiosk.FirstName.Trim() : "";
            string LastName = !string.IsNullOrEmpty(objAgentKiosk.LastName) ? objAgentKiosk.LastName.Trim() : "";
            string RFIDNumber = !string.IsNullOrEmpty(objAgentKiosk.RFIDNumber) ? objAgentKiosk.RFIDNumber : "";

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetPresetSubscriberDetail", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PageNbr", page);
                objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProvider);
                objCommand.Parameters.AddWithValue("@PermitState", PermitState);
                objCommand.Parameters.AddWithValue("@LastName", LastName);
                objCommand.Parameters.AddWithValue("@FirstName", FirstName);
                objCommand.Parameters.AddWithValue("@RFIDNumber", RFIDNumber);
                


                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    using (objReader)
                    {
                        while (objReader.Read())
                        {
                            VMAgentKiosk modelAgentKiosk = new VMAgentKiosk();
                            //modelAgentKiosk.RFIDNumber = objReader["RFIDNumber"].ToString();
                            modelAgentKiosk.SubscriberId = Convert.ToInt32(objReader["SubscriberID"]);
                            modelAgentKiosk.SubscriberName = objReader["Subscriber"].ToString();
                            modelAgentKiosk.Address = objReader["Address"].ToString();
                            modelAgentKiosk.PermitState = objReader["State"].ToString();
                            modelAgentKiosk.TotalCount = Convert.ToInt32(objReader["TotalCount"]);
                            modelAgentKiosk.BackOfficeID = Convert.ToInt32(objReader["BackOfficeID"]);
                            modelAgentKiosk.RFIDNumber = objReader["RFIDNumber"].ToString();
                            ListAgentKiosk.Add(modelAgentKiosk);
                        }
                        return ListAgentKiosk;

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
            return ListAgentKiosk;
        }






        //////////////-----------------------------Preset DB Chnages-----------------------///////////////////////////////////

    }
}
