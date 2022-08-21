using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SmartPark.Entity;

namespace SmartPark.Data
{
    public class DBCarParkNumber : DBHelper
    {
        public List<CarParkNumber> GetCarParkNumber(int ServiceProviderId)
        {
            List<CarParkNumber> listCarParkNumber = new List<CarParkNumber>();
             
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();                
                objCommand = new SqlCommand("usp_GetCarParkNumber", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@intServiceProviderID", ServiceProviderId);

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                     //   items.Add(new SelectListItem() { Text = objReader["SmartRepCarParkCode"].ToString(), Value = Convert.ToInt32(objReader["CarParkID"]).ToString(), Selected = false });
                        CarParkNumber objCarpark = new CarParkNumber();
                        objCarpark.SmartRepCarParkCode = objReader["CarParkName"].ToString();
                        objCarpark.CarParkID = (Int64)objReader["CarParkID"];
                        listCarParkNumber.Add(objCarpark);

                    }
                    return listCarParkNumber;

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
            return listCarParkNumber;


        }

        public List<CarParkingDocumentaion> GetCarParkNumberBasedOnUserDocument(int ServiceProviderID, int CarPark)
        {
            List<CarParkingDocumentaion> listCarParkNumber = new List<CarParkingDocumentaion>();

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetCarpkBasedOnDoc", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@intServiceProviderID", ServiceProviderID);
                objCommand.Parameters.AddWithValue("@carparkid", CarPark);

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        //   items.Add(new SelectListItem() { Text = objReader["SmartRepCarParkCode"].ToString(), Value = Convert.ToInt32(objReader["CarParkID"]).ToString(), Selected = false });
                        CarParkingDocumentaion objCarpark = new CarParkingDocumentaion();
                        objCarpark.CarParkID = (Int64)objReader["carparkid"];
                        objCarpark.carparkingdocumentationID = Convert.ToInt32(objReader["carparkingdocumentaionID"]);
                        objCarpark.CarParkBayTypeID = Convert.ToInt32(objReader["carparkbaytypeid"]);
                        objCarpark.RequiredDocumentID = Convert.ToInt32(objReader["Requireddocumentid"]);
                        objCarpark.CarParkName = objReader["CarParkName"].ToString();
                        objCarpark.CarParkBayTypeName = objReader["Name"].ToString();
                        // objCarpark.CarParkBayTypeID = (Int64)objReader["CarParkID"];
                        listCarParkNumber.Add(objCarpark);

                    }
                    return listCarParkNumber;

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
            return listCarParkNumber;
        }
    }
}
