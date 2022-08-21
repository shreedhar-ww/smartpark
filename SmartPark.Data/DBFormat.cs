using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web.Mvc;
using SmartPark.Entity;

namespace SmartPark.Data
{
    public class DBFormat:DBHelper 
    {
        public List<Format> GetFormat(int serviceProviderId)
        {
            List<Format> listFormat = new List<Format>();           
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetFormatList", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceProviderId);

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        //items.Add(new SelectListItem() { Text = objReader["RequiredDocument"].ToString(), Value = Convert.ToInt32(objReader["ConfigurationOthersID"]).ToString(), Selected = false });
                        Format objFormat = new Format();
                        objFormat.FormatName = objReader["Format"].ToString();
                        objFormat.FormatID = (int)objReader["ConfigurationOthersID"];
                        listFormat.Add(objFormat);
                    }
                    return listFormat;
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
            return listFormat;
        }    
    }
}
