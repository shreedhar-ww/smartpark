using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SmartPark.Entity;

namespace SmartPark.Data
{
    public class DBCustMembership : DBHelper
    {

        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;

        public List<User> getUserList()
        {
            List<User> userList = null;
            User user = null;

            try
            {

                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("select [UserName],[Password] from [CPT_PERMITS_DEV].[dbo].[SystemUser]", objConnection);
                objReader = objCommand.ExecuteReader();
                userList = new List<User>();
                while (objReader.Read())
                {
                    user = new User();
                    user.UserName = objReader["UserName"].ToString();
                    user.Password = objReader["Password"].ToString();
                    userList.Add(user);
                }

                if (objReader != null)
                {
                    objReader.Close();
                }

                return userList;

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

            return null;
        }

        public User getUserIdbyNameAndPassword(string strUName, string strPassword)
        {
            User Objuser = null;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_ValidateSystemUser", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@username", strUName);
                objCommand.Parameters.AddWithValue("@password", strPassword);
                objReader = objCommand.ExecuteReader();

                if (objReader.Read())
                {
                    Objuser = new User();
                    Objuser.UserID = Convert.ToInt32(objReader["SystemUserID"].ToString());
                    Objuser.IsPasswordReset = (bool)objReader["IsPasswordReset"];

                    Objuser.FisrtName = objReader["FirstName"].ToString();

                    if (objReader["AllowAgentKiosk"] != DBNull.Value)
                        Objuser.bIsAgentKiosk = (bool)objReader["AllowAgentKiosk"];
                    else
                        Objuser.bIsAgentKiosk = false;

                    if (objReader["AllowBackOffice"] != DBNull.Value)
                        Objuser.bIsBackOffice = (bool)objReader["AllowBackOffice"];
                    else
                        Objuser.bIsBackOffice = false;

                }

                if (objReader != null)
                {
                    objReader.Close();
                }

                return Objuser;

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
            return Objuser;
        }

        public bool ResetPassword(string username, string oldpassword, string newpassword)
        {
            int success = 0;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_ResetSystemUserPassword", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@username", username);
                objCommand.Parameters.AddWithValue("@password", oldpassword);
                objCommand.Parameters.AddWithValue("@newpassword", newpassword);
                success = (int)objCommand.ExecuteScalar();
                if (success > 0)
                    return true;
                else
                    return false;
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
            return false;

        }

        

    }
}