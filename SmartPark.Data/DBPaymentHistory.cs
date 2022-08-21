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

    public class DBPaymentHistory : DBHelper
    {

        public List<VMParkingPaymentHistory> GetPaymentHistory(string page, string sortdir, string sortColumn, int SubscriberID, string RFIDNumber,
            DateTime FromDate, DateTime ToDate, string symbol)
        {
            List<VMParkingPaymentHistory> ListPaymentHistoryModel = new List<VMParkingPaymentHistory>();
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "Name_ASC";
            string FromDateTime = FromDate.ToString("yyyy-MM-dd h:mm tt"); //Filter.FromDate.ToString("yyyy-MM-dd h:mm tt");
            string TodateTime = ToDate.ToString("yyyy-MM-dd h:mm tt");// Filter.ToDate.ToString("yyyy-MM-dd h:mm tt");
            if (FromDate.Year == 1)
            {
                FromDateTime = "1-1-2000";
            }
            else
            {
                FromDateTime = FromDate.ToString("MM-dd-yyyy h:mm tt");
            }

            // string TodateTime = null;
            if (ToDate.Year == 1)
            {
                TodateTime = "1-1-2099";
            }
            else
            {
                TodateTime = ToDate.ToString("MM-dd-yyyy h:mm tt");
            }
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetPaymentHistory", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PageNbr", page);
                objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                objCommand.Parameters.AddWithValue("@SubscriberID", SubscriberID);
                objCommand.Parameters.AddWithValue("@RFIDNumber", RFIDNumber);
                objCommand.Parameters.AddWithValue("@FromDate", FromDateTime);
                objCommand.Parameters.AddWithValue("@Todate", TodateTime);

                //objCommand.Parameters.AddWithValue("@FromDate", "2013-4-1");
                //objCommand.Parameters.AddWithValue("@Todate", "2015-4-30");

                //2013/4/1 //2014/4/19


                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        VMParkingPaymentHistory ObjPaymentHistory = new VMParkingPaymentHistory();
                        ObjPaymentHistory.RFIDNo = objReader["RFIDNumber"].ToString();
                        ObjPaymentHistory.PaymentDate = Convert.ToDateTime(objReader["PaymentDate"]).ToString("dd-MMM-yyyy");//Convert.ToDateTime(objReader[""]);
                        ObjPaymentHistory.Amount = symbol + " " + (objReader["Amount"]);
                        ObjPaymentHistory.Balance = symbol + " " + (objReader["Balance"].ToString());
                        ObjPaymentHistory.TOTALCOUNT = Convert.ToInt32(objReader["TOTALCOUNT"].ToString());
                        ListPaymentHistoryModel.Add(ObjPaymentHistory);

                    }
                    return ListPaymentHistoryModel;

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
            return ListPaymentHistoryModel;

        }

        /// <summary>
        /// Get Payment history in PDF
        /// </summary>
        /// <param name="page"></param>
        /// <param name="sortdir"></param>
        /// <param name="sortColumn"></param>
        /// <param name="SubscriberID"></param>
        /// <param name="GlobalRFIDTagID"></param>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public List<VMParkingPaymentHistory> GetPaymentHistoryPDF(int SubscriberID, string RFIDNumber, DateTime FromDate, DateTime ToDate,string symbol)
        {
            List<VMParkingPaymentHistory> ListPaymentHistoryModel = new List<VMParkingPaymentHistory>();
            string FromDateTime = FromDate.ToString("yyyy-MMM-dd h:mm tt"); //Filter.FromDate.ToString("yyyy-MM-dd h:mm tt");
            string TodateTime = ToDate.ToString("yyyy-MMM-dd h:mm tt");// Filter.ToDate.ToString("yyyy-MM-dd h:mm tt");
            if (FromDate.Year == 1)
            {
                FromDateTime = "1-1-2000";
            }
            else
            {
                FromDateTime = FromDate.ToString("MMM-dd-yyyy h:mm tt");
            }

            // string TodateTime = null;
            if (ToDate.Year == 1)
            {
                TodateTime = "1-1-2099";
            }
            else
            {
                TodateTime = ToDate.ToString("MMM-dd-yyyy h:mm tt");
            }

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetPaymentHistory_ExportToPDF", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@SubscriberID", SubscriberID);
                objCommand.Parameters.AddWithValue("@RFIDNumber", RFIDNumber);
                objCommand.Parameters.AddWithValue("@FromDate", FromDate);
                objCommand.Parameters.AddWithValue("@Todate", ToDate);

                //objCommand.Parameters.AddWithValue("@FromDate", "2013/4/1");
                //objCommand.Parameters.AddWithValue("@Todate", "2014/4/19");

                //2013/4/1 //2014/4/19


                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        VMParkingPaymentHistory ObjPaymentHistory = new VMParkingPaymentHistory();
                        ObjPaymentHistory.RFIDNo = objReader["RFIDNumber"].ToString();
                        ObjPaymentHistory.PaymentDate = Convert.ToDateTime(objReader["PaymentDate"]).ToString("dd-MMM-yyyy");//Convert.ToDateTime(objReader["PaymentDate"]);
                        ObjPaymentHistory.Amount = symbol + " " +(objReader["Amount"]);
                        ObjPaymentHistory.Balance = symbol + " " + (objReader["Balance"].ToString());
                        ListPaymentHistoryModel.Add(ObjPaymentHistory);

                    }
                    return ListPaymentHistoryModel;

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
            return ListPaymentHistoryModel;

        }
    }
}
