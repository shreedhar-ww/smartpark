using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SmartPark.Entity;
using SmartPark.Helper;

namespace SmartPark.Data
{
    public class DBHiddenToolTip : DBHelper
    {
        public List<int> GetHiddenToolTip(int UserId, string ControllerName)
        {
            //string hiddenToolTip = "";
            List<int> listToolTip = new List<int>();

            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {

                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetHiddenToolTip", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@UserId", UserId);
                    objCommand.Parameters.AddWithValue("@ControllerName", ControllerName);
                    objReader = objCommand.ExecuteReader();
                    using (objReader)
                    {
                        while (objReader.Read())
                        {
                            listToolTip.Add(Convert.ToInt32(objReader["ToolTipId"]));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }
            return listToolTip;
        }


        public int InsertHiddenToolTip(int UserId, int ToolTipId)
        {
            int success = 0;

            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {

                    objConnection.Open();
                    objCommand = new SqlCommand("usp_InsertHiddenToolTipID", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@UserId", UserId);
                    objCommand.Parameters.AddWithValue("@ToolTipId", ToolTipId);
                    objCommand.ExecuteNonQuery();
                    success = 1;
                }

            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }
            return success;
        }

    }
}
