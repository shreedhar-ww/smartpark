using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SmartPark.Entity;

namespace SmartPark.Data
{
    public class DBCarParkForServiceProvider : DBHelper
    {
        public List<CarParkNumber> GetCarParkNumberForServiceProvider(Int64 ServiceProviderId)
        {
            List<CarParkNumber> listCarParkNumber = new List<CarParkNumber>();
             
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetCarParkNumberForServiceProvider", objConnection);
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
    }
}
