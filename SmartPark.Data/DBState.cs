using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web.Mvc;
using SmartPark.Entity;
using SmartPark.Helper;

namespace SmartPark.Data
{
    public class DBState : DBHelper
    {
        public List<State> GetStateList(int CountryID)
        {
            List<State> listState = new List<State>();

            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetStateList", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@CountryId", CountryID);
                    objReader = objCommand.ExecuteReader();

                    using (objReader)
                    {
                        while (objReader.Read())
                        {
                            State objState = new State();
                            objState.StateName = objReader["StateName"].ToString();
                            objState.StateId = objReader["StateId"].ToString();
                            listState.Add(objState);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }
            return listState;
        }
    }
}
