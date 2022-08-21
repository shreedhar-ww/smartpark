using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web.Mvc;
using SmartPark.Entity;

namespace SmartPark.Data
{
    public class DBDocument:DBHelper 
    {
        public List<Document> GetRequiredDocument(int serviceProviderId,int CarParkId,int ParkTypeId,int documentationId)
        {
            List<Document> listRequiredDocument = new List<Document>();           
            try
            {   
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetRequiredDocumentList", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceProviderId);
                objCommand.Parameters.AddWithValue("@CarParkId", CarParkId);
                objCommand.Parameters.AddWithValue("@ParkTypeId", ParkTypeId);
                objCommand.Parameters.AddWithValue("@documentationId", documentationId);

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        //items.Add(new SelectListItem() { Text = objReader["RequiredDocument"].ToString(), Value = Convert.ToInt32(objReader["ConfigurationOthersID"]).ToString(), Selected = false });
                        Document objDocument = new Document();
                        objDocument.ReqDocument = objReader["RequiredDocument"].ToString();
                        objDocument.DocumentId = (int)objReader["ConfigurationOthersID"];
                        listRequiredDocument.Add(objDocument);
                    }
                    return listRequiredDocument;
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
            return listRequiredDocument;
        }
    }
}
