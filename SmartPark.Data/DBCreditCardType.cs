using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SmartPark.Entity;

namespace SmartPark.Data
{
    public class DBCreditCardType : DBHelper 
    {
        public List<CreditCardType> GetCreditCardTypeList()
        {
            List<CreditCardType> listCreditCardType = new List<CreditCardType>();

            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetCreditCardTypeList", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objReader = objCommand.ExecuteReader();

                    using (objReader)
                    {
                        while (objReader.Read())
                        {
                            CreditCardType objCreditCardType = new CreditCardType();
                            objCreditCardType.CreditCardTypeName = objReader["CreditCardType"].ToString();
                            objCreditCardType.CreditCardTypeID = Convert.ToInt16(objReader["CreditCardTypeId"]);
                            listCreditCardType.Add(objCreditCardType);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }
            return listCreditCardType;
        }
    }
}
