using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SmartPark.Data
{
    public class DBCustRoleProvider : DBHelper
    {
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;

        public string getUserRolesByUserID(string SystemUserName)
        {
            string UserRole = null;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();

                //objCommand = new SqlCommand("select R.[Role] from [dbo].[Role] R inner join [dbo].[SystemUserRole] SR on SR.[RoleID] = R.[RoleID] inner join [dbo].[SystemUser] su on su.SystemUserID = SR.[SystemUserID] where su.[UserName] = @SysUserName ", objConnection);
                objCommand = new SqlCommand("usp_GetUserRole", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@SysUserName", SystemUserName);
                objReader = objCommand.ExecuteReader();

                while (objReader.Read())
                {
                    UserRole = objReader["Role"].ToString();
                }

                if (objReader != null)
                {
                    objReader.Close();
                }
                

            }
            catch (Exception e)
            {
                //Write a code which will logged an error if any.
            }
            return UserRole;
        }

    }
}