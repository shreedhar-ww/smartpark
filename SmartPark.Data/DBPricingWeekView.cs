using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartPark.Data
{
    public class WeekView
    {
        public string Mon { get; set; }
        public string Tues { get; set; }
        public string Wed { get; set; }
        public string Thurs { get; set; }
        public string Fri { get; set; }
        public string Sat { get; set; }
        public string Sun { get; set; }
        public string PricingID { get; set; }
        public string DayPartFrom { get; set; }
        public string DayPartTo { get; set; }
    }

    public class DBPricingWeekView : DBHelper
    {
        public Tuple<List<WeekView>, string> GetWeekViewDetail(int CarParkId, int ParkTypeId, string validFromDate, int serviceProviderId)
        {
            List<WeekView> listweekview = new List<WeekView>();
            string strcurrencysybol = "$";
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetPricingWeekList", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceProviderId);
                objCommand.Parameters.AddWithValue("@CarParkId", CarParkId);
                objCommand.Parameters.AddWithValue("@CarParkBayTypeID", ParkTypeId);
                objCommand.Parameters.AddWithValue("@FromDate", validFromDate);
                /// objCommand.Parameters.AddWithValue("@ToDate", validToDate);

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    // will display default currecy symbol
                    while (objReader.Read())
                    {
                       
                        WeekView objweekview = new WeekView();
                        objweekview.Mon = objReader["Monday"].ToString();
                        objweekview.Tues = objReader["Tuesday"].ToString();
                        objweekview.Wed = objReader["Wednesday"].ToString();
                        objweekview.Thurs = objReader["Thursday"].ToString();
                        objweekview.Fri = objReader["Friday"].ToString();
                        objweekview.Sat = objReader["Saturday"].ToString();
                        objweekview.Sun = objReader["Sunday"].ToString();
                        objweekview.PricingID = objReader["PricingID"].ToString();
                        objweekview.DayPartFrom = objReader["DayPartFrom"].ToString();
                        objweekview.DayPartTo = objReader["DayPartTo"].ToString();
                        listweekview.Add(objweekview);
                    }

                    if (objReader.NextResult())
                    {
                        while (objReader.Read())
                        {
                            strcurrencysybol = objReader["CurrencySymbol"].ToString();
                            //items.Add(new SelectListItem() { Text = objReader["RequiredDocument"].ToString(), Value = Convert.ToInt32(objReader["ConfigurationOthersID"]).ToString(), Selected = false });
                            //Document objDocument = new Document();
                            //objDocument.ReqDocument = objReader["RequiredDocument"].ToString();
                            //objDocument.DocumentId = (int)objReader["ConfigurationOthersID"];
                            //listRequiredDocument.Add(objDocument);
                            
                        }
                    }
                    //return listRequiredDocument;
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

            Tuple<List<WeekView>, string > _tuplePricingcurrencysymbol =
                Tuple.Create(listweekview, strcurrencysybol);

            return _tuplePricingcurrencysymbol;

        }


        public int InsertPricingWeekDetails(int CarParkId, int ParkTypeId, string PrevFromDate, string FromDate, string PricingId, int CreatedBy)
        {
            int success = 0;

            using (objConnection = new SqlConnection(connectionString))
            {
                try
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_InsertPricingWeekView", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    objCommand.Parameters.AddWithValue("@CarParkId", CarParkId);
                    objCommand.Parameters.AddWithValue("@ParkTypeId", ParkTypeId);
                    objCommand.Parameters.AddWithValue("@FromDate", FromDate);
                    objCommand.Parameters.AddWithValue("@PrevFromDate", PrevFromDate);
                    objCommand.Parameters.AddWithValue("@PricingId", PricingId);
                    objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    /// objCommand.Parameters.AddWithValue("@ToDate", validToDate);

                    success = Convert.ToInt16(objCommand.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return success;
            }

        }
    }
}
