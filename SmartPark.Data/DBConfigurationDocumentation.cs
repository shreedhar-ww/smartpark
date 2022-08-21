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
    public class DBConfigurationDocumentation : DBHelper
    {
        /// <summary>
        /// Get All Documentation Dtls for the grid
        /// </summary>
        /// <param name="page">number of entries in 1 page for paging</param>
        /// <param name="sortdir">asc/desc</param>
        /// <param name="sortColumn">coulmn name on which sorting is done</param>
        /// <param name="objPricingConfig">model used to get the search value</param>
        /// <returns>index view</returns>     
        public List<VMDocumentationConfig> GetAllDocumentation(string page, string sortdir, string sortColumn, string carParkNum, int serviceProviderId)
        {
            //service provide id from cookies
            List<VMDocumentationConfig> DocumentationList = new List<VMDocumentationConfig>();
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "Name_ASC";
            string carParkNumber = !string.IsNullOrEmpty(carParkNum) ? carParkNum : "";
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetDocumentationDetail", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PageNbr", page);
                objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceProviderId);
                objCommand.Parameters.AddWithValue("@CarParkNo", carParkNumber);


                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        VMDocumentationConfig ObjDocumentation = new VMDocumentationConfig();
                        ObjDocumentation.DocumentationId = Convert.ToInt32(objReader["CarParkingDocumentaionID"]);
                        ObjDocumentation.CarParkNumber = objReader["CarParkName"].ToString();
                        ObjDocumentation.ParkType = (objReader["Name"]).ToString();
                        ObjDocumentation.Document = objReader["Documentation"].ToString();
                        ObjDocumentation.Format = objReader["Format"].ToString();
                        ObjDocumentation.ApplicationStat = objReader["ApplicationState"].ToString();
                        ObjDocumentation.IsEnabled = (Boolean)objReader["IsEnabled"];
                        ObjDocumentation.TotalCount = Convert.ToInt32(objReader["TotalCount"]);
                        DocumentationList.Add(ObjDocumentation);
                    }
                    return DocumentationList;

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
            return DocumentationList;


        }

        /// <summary>
        /// Get the pricing detail for edit mode
        /// </summary>
        /// <param name="pricingId">Id of the Row in DB</param>
        /// <returns>model object containing the details of the row </returns>
        public VMDocumentationConfig GetDocumentationByID(int DocumentationId)
        {
            VMDocumentationConfig ObjDocument = new VMDocumentationConfig();
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetDocumentationByID", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@documentationId", DocumentationId);
                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        ObjDocument.DocumentationId = Convert.ToInt32(objReader["CarParkingDocumentaionID"]);
                        ObjDocument.CarParkID = Convert.ToInt32(objReader["CarParkID"]);
                        ObjDocument.ParkTypeId = Convert.ToInt32(objReader["CarParkBayTypeID"]);
                        ObjDocument.RequireDocumentId = Convert.ToInt32(objReader["RequiredDocumentID"]);
                        ObjDocument.FormatId = Convert.ToInt32(objReader["FormatID"]);
                        ObjDocument.ApplicationStatus = Convert.ToBoolean(objReader["ApplicationStateID"]);
                        ObjDocument.IsEnabled = (Boolean)objReader["IsEnabled"];
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
            return ObjDocument;
        }

        ///<summary>
        /// Edit DocumentationConfig
        /// </summary>
        /// <param name="objPricing">model object containing the details of the view</param>
        /// <param name="CreatedBy">System UserId</param>
        /// <param name="ServiceProvideID"> ServiceProvideID </param>
        /// <returns></returns>
        public int EditConfigDocumentation(VMDocumentationConfig objDocumentation, int UpdatedBy, int ServiceProvideID)
        {
            int success = 0;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_UpdateDocumentationDetails", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@DocumentationId", Convert.ToInt16(objDocumentation.DocumentationId));
                objCommand.Parameters.AddWithValue("@CarParkID", Convert.ToInt16(objDocumentation.CarParkID));
                objCommand.Parameters.AddWithValue("@CarParkBayTypeID", Convert.ToInt16(objDocumentation.ParkTypeId));
                objCommand.Parameters.AddWithValue("@RequiredDocumentId", objDocumentation.RequireDocumentId);
                objCommand.Parameters.AddWithValue("@FormatID", objDocumentation.FormatId);
                objCommand.Parameters.AddWithValue("@ApplicationState", objDocumentation.ApplicationStatus);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProvideID);
                objCommand.Parameters.AddWithValue("@IsEnabled", objDocumentation.IsEnabled);
                objCommand.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);                
                objCommand.ExecuteScalar();
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

        /// <summary>
        /// Insert DocumentationConfig
        /// </summary>
        /// <param name="objPricing">model object containing the details of the view</param>
        /// <param name="CreatedBy">System UserId</param>
        /// <param name="ServiceProvideID"> ServiceProvideID </param>
        /// <returns> 1 if data saved successfully</returns>
        public int InsertConfigDocumentation(VMDocumentationConfig objDocumentation, int createdBy, int serviceproviderID)
        {
            int success = 0;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_InsertDocumentationDetails", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@CarParkID", objDocumentation.CarParkID);
                objCommand.Parameters.AddWithValue("@CarParkBayTypeID", objDocumentation.ParkTypeId);
                objCommand.Parameters.AddWithValue("@RequiredDocumentId", objDocumentation.RequireDocumentId);
                objCommand.Parameters.AddWithValue("@FormatID", objDocumentation.FormatId);
                objCommand.Parameters.AddWithValue("@ApplicationState", objDocumentation.ApplicationStatus);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceproviderID);
                objCommand.Parameters.AddWithValue("@IsEnabled ", objDocumentation.IsEnabled);
                objCommand.Parameters.AddWithValue("@CreatedBy", createdBy);
                objCommand.Parameters.AddWithValue("@UpdatedBy", createdBy);
                success = Convert.ToInt32(objCommand.ExecuteScalar());
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
