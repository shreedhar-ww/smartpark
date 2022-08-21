using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using SmartPark.Entity;
using SmartPark.Helper;

namespace SmartPark.Data
{
    public class DBPricingConfig : DBHelper
    {
        /// <summary>
        /// Get All Pricing Dtls for the grid
        /// </summary>
        /// <param name="page">number of entries in 1 page for paging</param>
        /// <param name="sortdir">asc/desc</param>
        /// <param name="sortColumn">coulmn name on which sorting is done</param>
        /// <param name="objPricingConfig">model used to get the search value</param>
        /// <returns>index view</returns>
        public List<VMPricingConfig> GetAllPricingDtl(string page, string sortdir, string sortColumn, string CarParkNo, int serviceProviderId)
        {
            List<VMPricingConfig> ListUserModel = new List<VMPricingConfig>();
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "Name_ASC";
            string CarParkNumber = !string.IsNullOrEmpty(CarParkNo) ? CarParkNo : "";
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetPricingDetail", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PageNbr", page);
                objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceProviderId);
                objCommand.Parameters.AddWithValue("@CarParkNo", CarParkNumber);


                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        VMPricingConfig ObjPrice = new VMPricingConfig();
                        ObjPrice.CarParkNumber = objReader["CarParkName"].ToString();
                        ObjPrice.ParkType = objReader["NAME"].ToString();
                        ObjPrice.PricingID = Convert.ToInt32(objReader["PricingID"]);
                        ObjPrice.FromDate = Convert.ToDateTime(objReader["ValidFrom"]).ToUniversalTime().ToLocalTime();
                        ObjPrice.PriceToDate = Convert.ToDateTime(objReader["ValidtTo"]).ToUniversalTime().ToLocalTime();
                        ObjPrice.FromTime = objReader["DayPartFrom"].ToString();
                        ObjPrice.ToTime = objReader["DayPartTo"].ToString();
                        ObjPrice.MaxStay = Convert.ToDecimal(objReader["MaxStay"]);
                        ObjPrice.Rate = Convert.ToDecimal(objReader["RatePerHour"]);
                        ObjPrice.WeekDay = objReader["WeekDay"].ToString();
                        ObjPrice.IsEnabled = (Boolean)objReader["IsEnabled"];
                        ObjPrice.TotalCount = Convert.ToInt32(objReader["TotalCount"]);
                        ListUserModel.Add(ObjPrice);
                    }
                    return ListUserModel;

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
            return ListUserModel;


        }

        /// <summary>
        /// Get the pricing detail for edit mode
        /// </summary>
        /// <param name="pricingId">Id of the Row in DB</param>
        /// <returns>model object containing the details of the row </returns>
        public VMPricingConfig GetPricingByID(int pricingId)
        {
            VMPricingConfig ObjPrice = new VMPricingConfig();
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetPricingByID", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PricingID", pricingId);
                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        ObjPrice.CarParkID = Convert.ToInt32(objReader["CarParkID"]);
                        ObjPrice.ParkTypeId = Convert.ToInt32(objReader["CarParkBayTypeID"]);
                        ObjPrice.PricingID = Convert.ToInt32(objReader["PricingID"]);
                        ObjPrice.FromDate = Convert.ToDateTime(objReader["ValidFrom"]);
                        ObjPrice.PriceToDate = Convert.ToDateTime(objReader["ValidtTo"]);
                        ObjPrice.FromTime = objReader["DayPartFrom"].ToString();
                        ObjPrice.ToTime = objReader["DayPartTo"].ToString();
                        ObjPrice.MaxStay = Convert.ToDecimal(objReader["MaxStay"]);
                        ObjPrice.Rate = Convert.ToDecimal(objReader["RatePerHour"]);
                        ObjPrice.IsMonday = (Boolean)objReader["Monday"];
                        ObjPrice.IsTuesday = (Boolean)objReader["Tuesday"];
                        ObjPrice.IsWednesday = (Boolean)objReader["Wednesday"];
                        ObjPrice.IsThursday = (Boolean)objReader["Thursday"];
                        ObjPrice.IsFriday = (Boolean)objReader["Friday"];
                        ObjPrice.IsSaturday = (Boolean)objReader["Saturday"];
                        ObjPrice.IsSunday = (Boolean)objReader["Sunday"];
                        ObjPrice.IsEnabled = (Boolean)objReader["IsEnabled"];
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
            return ObjPrice;
        }

        /// <summary>
        /// Insert PricingConfig
        /// </summary>
        /// <param name="objPricing">model object containing the details of the view</param>
        /// <param name="CreatedBy">System UserId</param>
        /// <param name="ServiceProvideID"> ServiceProvideID </param>
        /// <returns> 1 if data saved successfully</returns>
        public int InsertPricingConfig(VMPricingConfig objPricing, int CreatedBy, int ServiceProvideID, DateTime varFromDate, DateTime varToDate,
            Guid gid)
        {
            //Hidden field used when Adding entry from Week View
            if (objPricing.CarParkID == 0)
            {
                objPricing.CarParkID = objPricing.hdnCarParkId;
                objPricing.ParkTypeId = objPricing.hdnParkTypeId;
            }
            int success = 0;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_InsertPricingDetails", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;


                objCommand.Parameters.AddWithValue("@PricingId", 0);
                objCommand.Parameters.AddWithValue("@CarParkID", Convert.ToInt16(objPricing.CarParkID));
                objCommand.Parameters.AddWithValue("@CarParkBayTypeID", Convert.ToInt16(objPricing.ParkTypeId));
                objCommand.Parameters.AddWithValue("@IsEnabled", objPricing.IsEnabled);
                objCommand.Parameters.AddWithValue("@ValidFrom", objPricing.FromDate.Value.ToString("dd-MMM-yyyy"));
                objCommand.Parameters.AddWithValue("@ValidtTo", objPricing.PriceToDate.Value.ToString("dd-MMM-yyyy"));
                objCommand.Parameters.AddWithValue("@RatePerHour", objPricing.Rate);
                objCommand.Parameters.AddWithValue("@DayPartFrom", objPricing.FromTime == "0" || objPricing.FromTime == null ? "00:00" : objPricing.FromTime);
                objCommand.Parameters.AddWithValue("@DayPartTo", objPricing.ToTime == "0" || objPricing.ToTime == null ? "24:00" : objPricing.ToTime);
                objCommand.Parameters.AddWithValue("@MaxStay", objPricing.MaxStay);
                objCommand.Parameters.AddWithValue("@Monday", objPricing.IsMonday);
                objCommand.Parameters.AddWithValue("@Tuesday", objPricing.IsTuesday);
                objCommand.Parameters.AddWithValue("@Wednesday", objPricing.IsWednesday);
                objCommand.Parameters.AddWithValue("@Thursday", objPricing.IsThursday);
                objCommand.Parameters.AddWithValue("@Friday", objPricing.IsFriday);
                objCommand.Parameters.AddWithValue("@Saturday", objPricing.IsSaturday);
                objCommand.Parameters.AddWithValue("@Sunday", objPricing.IsSunday);

                objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProvideID);

                objCommand.Parameters.AddWithValue("@varFromDate", varFromDate.ToString("dd-MMM-yyyy"));
                objCommand.Parameters.AddWithValue("@varToDate", varToDate.ToString("dd-MMM-yyyy"));

                objCommand.Parameters.AddWithValue("@gid", gid);
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


        public int deletePricing(Guid gid)
        {
            int success = 0;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_DeletePricingDetails", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PGUID", gid);
                objCommand.ExecuteNonQuery();
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

        ///<summary>
        /// Edit PricingConfig
        /// </summary>
        /// <param name="objPricing">model object containing the details of the view</param>
        /// <param name="CreatedBy">System UserId</param>
        /// <param name="ServiceProvideID"> ServiceProvideID </param>
        /// <returns></returns>
        public int EditPricingConfig(VMPricingConfig objPricing, int UpdatedBy, int ServiceProvideID, DateTime varFromDate, DateTime varToDate)
        {
            int success = 0;
            try
            {
                Guid gid = new Guid();
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_InsertPricingDetails", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objCommand.Parameters.AddWithValue("@PricingId", Convert.ToInt32(objPricing.PricingID));
                objCommand.Parameters.AddWithValue("@CarParkID", Convert.ToInt16(objPricing.CarParkID));
                objCommand.Parameters.AddWithValue("@CarParkBayTypeID", Convert.ToInt16(objPricing.ParkTypeId));
                objCommand.Parameters.AddWithValue("@IsEnabled", objPricing.IsEnabled);
                objCommand.Parameters.AddWithValue("@ValidFrom", objPricing.FromDate.Value.ToString("dd-MMM-yyyy"));
                objCommand.Parameters.AddWithValue("@ValidtTo", objPricing.PriceToDate.Value.ToString("dd-MMM-yyyy"));
                objCommand.Parameters.AddWithValue("@RatePerHour", objPricing.Rate);
                objCommand.Parameters.AddWithValue("@DayPartFrom", objPricing.FromTime == "0" || objPricing.FromTime == null ? "00:00" : objPricing.FromTime);
                objCommand.Parameters.AddWithValue("@DayPartTo", objPricing.ToTime == "0" || objPricing.ToTime == null ? "24:00" : objPricing.ToTime);
                objCommand.Parameters.AddWithValue("@MaxStay", objPricing.MaxStay);
                objCommand.Parameters.AddWithValue("@Monday", objPricing.IsMonday);
                objCommand.Parameters.AddWithValue("@Tuesday", objPricing.IsTuesday);
                objCommand.Parameters.AddWithValue("@Wednesday", objPricing.IsWednesday);
                objCommand.Parameters.AddWithValue("@Thursday", objPricing.IsThursday);
                objCommand.Parameters.AddWithValue("@Friday", objPricing.IsFriday);
                objCommand.Parameters.AddWithValue("@Saturday", objPricing.IsSaturday);
                objCommand.Parameters.AddWithValue("@Sunday", objPricing.IsSunday);

                objCommand.Parameters.AddWithValue("@CreatedBy", UpdatedBy);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProvideID);
                objCommand.Parameters.AddWithValue("@gid", gid);
                objCommand.Parameters.AddWithValue("@varFromDate", varFromDate.ToString("dd-MMM-yyyy"));
                objCommand.Parameters.AddWithValue("@varToDate", varToDate.ToString("dd-MMM-yyyy"));
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
    }
}
