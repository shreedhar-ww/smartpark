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
    public class DBCountry : DBHelper
    {
        public List<Country> GetCountryList()
        {
            List<Country> listCountry = new List<Country>();

            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetCountryList", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objReader = objCommand.ExecuteReader();

                    using (objReader)
                    {
                            while (objReader.Read())
                            {
                                Country objCountry = new Country();
                                objCountry.CountryName = objReader["CountryName"].ToString();
                                objCountry.CountryCode = objReader["CountryCode"].ToString();
                                objCountry.CountryId = Convert.ToInt16(objReader["CountryID"]);
                                listCountry.Add(objCountry);
                            }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return listCountry;
        }
    }
}
