using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SmartPark.Entity;

namespace SmartPark.Data
{
    public class DBParkType : DBHelper
    {
        public List<ParkType> GetParkType(Int64 CarParkId,int pk_ID,string functionality)
        {
            List<ParkType> listParkType = new List<ParkType>();            
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetParkType", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@intCarParkId", CarParkId);
                objCommand.Parameters.AddWithValue("@int_pkid", pk_ID);
                objCommand.Parameters.AddWithValue("@varFunctionality", functionality);

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        ParkType objParkType = new ParkType();
                        //items.Add(new SelectListItem() { Text = objReader["Name"].ToString(), Value = Convert.ToInt32(objReader["CarParkBayTypeID"]).ToString(), Selected = false });
                        objParkType.Name = objReader["Name"].ToString();
                        objParkType.CarParkBayTypeID = (int)objReader["CarParkBayTypeID"];
                        listParkType.Add(objParkType);
                    }
                    return listParkType;
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
            return listParkType;


        }
    }
}
