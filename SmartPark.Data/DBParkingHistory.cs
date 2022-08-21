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
    public class DBParkingHistory : DBHelper
    {
        public List<VMParkingPaymentHistory> GetParkingHistory(string page, string sortdir, string sortColumn, int SubscriberID,
            string BarcodeNumber, DateTime FromDate, DateTime ToDate
            , string symbol)
        {
            List<VMParkingPaymentHistory> ListParkingHistoryModel = new List<VMParkingPaymentHistory>();
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "ParkingHistoryID_Desc";
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
                objCommand = new SqlCommand("usp_GetParkingHistory", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PageNbr", page);
                objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                objCommand.Parameters.AddWithValue("@SubscriberID", SubscriberID);
                objCommand.Parameters.AddWithValue("@RFIDNumber", BarcodeNumber);
                objCommand.Parameters.AddWithValue("@FromDate", FromDateTime);
                objCommand.Parameters.AddWithValue("@Todate", TodateTime);
                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        VMParkingPaymentHistory ObjPaymentHistory = new VMParkingPaymentHistory();
                        ObjPaymentHistory.RFIDNo = objReader["RFIDNumber"].ToString();
                        ObjPaymentHistory.PaymentDate = Convert.ToDateTime(objReader["Date"]).ToString("dd-MMM-yyyy");//Convert.ToDateTime(objReader["Date"]);
                        ObjPaymentHistory.TimeIn = objReader["TIME_IN"].ToString();
                        ObjPaymentHistory.TimeOut = objReader["TIME_OUT"].ToString();
                        ObjPaymentHistory.Amount = symbol + " " + (objReader["AmountDeducted"]);
                        ObjPaymentHistory.Balance = symbol + " " + (objReader["Balance"].ToString());
                        ObjPaymentHistory.TOTALCOUNT = Convert.ToInt32(objReader["TOTALCOUNT"].ToString());
                        ObjPaymentHistory.ParkingLocation = objReader["ParkingLocation"].ToString();
                        ListParkingHistoryModel.Add(ObjPaymentHistory);

                    }
                    return ListParkingHistoryModel;

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
            return ListParkingHistoryModel;

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
        public List<VMParkingPaymentHistory> GetParkingHistoryPDF(int SubscriberID, string RFIDNumber, DateTime FromDate, DateTime ToDate, string symbol)
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
              //  FromDateTime = FromDate.ToString("MMM-dd-yyyy h:mm tt");
            }

            // string TodateTime = null;
            if (ToDate.Year == 1)
            {
                TodateTime = "1-1-2099";
            }
            else
            {
               // TodateTime = ToDate.ToString("MMM-dd-yyyy h:mm tt");
            }
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetParkingHistory_ExportToPDF", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@SubscriberID", SubscriberID);
                objCommand.Parameters.AddWithValue("@RFIDNumber", RFIDNumber);
                objCommand.Parameters.AddWithValue("@FromDate", FromDate);
                objCommand.Parameters.AddWithValue("@Todate", ToDate);
                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        VMParkingPaymentHistory ObjPaymentHistory = new VMParkingPaymentHistory();
                        ObjPaymentHistory.RFIDNo = objReader["RFIDNumber"].ToString();
                        ObjPaymentHistory.PaymentDate = Convert.ToDateTime(objReader["Date"]).ToString("dd-MMM-yyyy"); //Convert.ToDateTime(objReader[""]);
                        ObjPaymentHistory.TimeIn = objReader["TIME_IN"].ToString();
                        ObjPaymentHistory.TimeOut = objReader["TIME_OUT"].ToString();
                        ObjPaymentHistory.Amount = symbol + " " + (objReader["AmountDeducted"]);
                        ObjPaymentHistory.Balance = symbol + " " + (objReader["Balance"].ToString());
                        ObjPaymentHistory.ParkingLocation = objReader["ParkingLocation"].ToString().Replace("<br>","\n");
                        //  ObjPaymentHistory.TOTALCOUNT = Convert.ToInt32(objReader["TOTALCOUNT"].ToString());
                        ListPaymentHistoryModel.Add(ObjPaymentHistory);

                    }
                    return ListPaymentHistoryModel;

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
            return ListPaymentHistoryModel;

        }


        ////------------------------Preset changes------------------------//////////////////////////////////

        public List<VMParkingPaymentHistory> GetParkingHistoryPreset(string page, string sortdir, string sortColumn, int SubscriberID,
         string  RFID, DateTime FromDate, DateTime ToDate
         , string symbol)
        {
            List<VMParkingPaymentHistory> ListParkingHistoryModel = new List<VMParkingPaymentHistory>();
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "ParkingHistoryID_Desc";
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
                objCommand = new SqlCommand("usp_Portal_GetParkingHistory", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PageNbr", page);
                objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                objCommand.Parameters.AddWithValue("@SubscriberID", SubscriberID);
                objCommand.Parameters.AddWithValue("@FromDate", FromDateTime);
                objCommand.Parameters.AddWithValue("@Todate", TodateTime);
                objCommand.Parameters.AddWithValue("@Rfid", RFID);
                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        VMParkingPaymentHistory ObjPaymentHistory = new VMParkingPaymentHistory();
                        ObjPaymentHistory.RFIDNo = objReader["RFIDNumber"].ToString();
                        ObjPaymentHistory.PaymentDate = Convert.ToDateTime(objReader["Date"]).ToString("dd-MMM-yyyy");//Convert.ToDateTime(objReader["Date"]);
                        ObjPaymentHistory.TimeIn = objReader["TIME_IN"].ToString();
                        ObjPaymentHistory.TimeOut = objReader["TIME_OUT"].ToString();
                        ObjPaymentHistory.Amount = symbol + " " + (objReader["AmountDeducted"]);
                        ObjPaymentHistory.Balance = symbol + " " + (objReader["Balance"].ToString());
                        ObjPaymentHistory.TOTALCOUNT = Convert.ToInt32(objReader["TOTALCOUNT"].ToString());
                        ObjPaymentHistory.ParkingLocation = objReader["ParkingLocation"].ToString();
                        ListParkingHistoryModel.Add(ObjPaymentHistory);

                    }
                    return ListParkingHistoryModel;

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
            return ListParkingHistoryModel;

        }


        ////---------------------------Preset changes---------------------//////////////////////////////////

        public List<SelectListItem> GetRFIDList(int SubscriberID)
        {
            List<SelectListItem> listRFID = new List<SelectListItem>();

            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetRFID", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@SubscriberID", SubscriberID);
                    objReader = objCommand.ExecuteReader();

                    using (objReader)
                    {
                        while (objReader.Read())
                        {
                            listRFID.Add(new SelectListItem { Text = objReader["RFIDNumber"].ToString(), Value = objReader["RFIDNumber"].ToString() });
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            return listRFID;
        }
    }
}
