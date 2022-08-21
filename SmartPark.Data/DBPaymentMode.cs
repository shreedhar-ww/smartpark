using SmartPark.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SmartPark.Data
{
    public class DBPaymentMode : DBHelper
    {
        public List<PaymentMethod> GetAllPaymentMode()
        {
            List<PaymentMethod> listPaymentMethod = new List<PaymentMethod>();
            //List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetAllPaymentMethods", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                      PaymentMethod objPayment = new PaymentMethod();
                        {
                           // Text = objReader["PaymentModeID"].ToString(),
                            objPayment.PaymentMode = objReader["PaymentMode"].ToString();
                            objPayment.PaymentModeID = (int)(objReader["PaymentModeID"]);
                            listPaymentMethod.Add(objPayment);
                             
                        }
                    }
                    return listPaymentMethod;

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
            return listPaymentMethod;


        }
    }
}
