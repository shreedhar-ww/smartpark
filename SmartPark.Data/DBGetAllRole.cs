using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;
using SmartPark.Entity;
using SmartPark.Helper;
namespace SmartPark.Data
{
    public class DBGetAllRole :DBHelper
    {
        public List<UserRole> GetAllRole(string CurrentRole)
        {
            List<UserRole> listUserRole = new List<UserRole>();
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("[usp_GetAllRole]", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@CurrentRole", CurrentRole);

                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        UserRole objUserRole = new UserRole();
                        //items.Add(new SelectListItem() { Text = objReader["Name"].ToString(), Value = Convert.ToInt32(objReader["CarParkBayTypeID"]).ToString(), Selected = false });
                        objUserRole.Role = objReader["Role"].ToString();
                        objUserRole.RoleID = (int)objReader["RoleID"];
                        listUserRole.Add(objUserRole);
                    }
                    return listUserRole;
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
            return listUserRole;


        }
    }
}
