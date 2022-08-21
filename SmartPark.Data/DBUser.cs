using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPark.Entity;
using SmartPark.Helper;


namespace SmartPark.Data
{
    public class DBUser : DBHelper
    {

        public List<UserModel> GetAllUser(string page, string sortdir, string sortColumn, string Uname, string Fname, 
            string RoleID, string ServiceProviderName, int serviceProviderID , int UserRoleID)
        {

            List<UserModel> ListUserModel = new List<UserModel>();
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "Name_ASC";
            string Username = !string.IsNullOrEmpty(Uname) ? Uname : "";

            if (RoleID == null || RoleID=="")
            {
                RoleID = "0";
            }
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetSystemUser", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PageNbr", page);
                objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                objCommand.Parameters.AddWithValue("@UserName", Username);
                objCommand.Parameters.AddWithValue("@ServPrvdName", ServiceProviderName);
                objCommand.Parameters.AddWithValue("@ServPrvdId", serviceProviderID);
                objCommand.Parameters.AddWithValue("@Fname", Fname);
                objCommand.Parameters.AddWithValue("@RoleID", Convert.ToInt32(RoleID));
                objCommand.Parameters.AddWithValue("@UserRoleID", UserRoleID );



                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        UserModel ObjUser = new UserModel();
                        ObjUser.Username = objReader["UserName"].ToString();
                        ObjUser.SystemUserID = AESEncryption.Encrypt((objReader["SystemUserID"]).ToString());
                        // ObjUser.Password = objReader["Password"].ToString();
                        ObjUser.Password = "******";
                        ObjUser.Name = objReader["Name"].ToString();
                        ObjUser.Email = objReader["Email"].ToString();
                        ObjUser.Role = objReader["Role"].ToString();
                        ObjUser.ServiceProviderName = objReader["ServiceProviderName"].ToString();
                        ObjUser.IsActive = (bool)objReader["IsActive"];
                        ObjUser.TotalCount = Convert.ToInt32(objReader["TotalCount"]);
                        ListUserModel.Add(ObjUser);

                    }
                    return ListUserModel;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
            return ListUserModel;


        }

        public UserModel GetUserByID(string UserID)
        {
            UserModel ObjUser = new UserModel();
            try
            {

                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetSystemUserByID", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@SystemUserID", AESEncryption.Decrypt(UserID));
                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {

                        ObjUser.Username = objReader["UserName"].ToString();
                        ObjUser.SystemUserID = AESEncryption.Encrypt((objReader["SystemUserID"]).ToString());
                        // ObjUser.Password = objReader["Password"].ToString();
                        ObjUser.Password = "********";
                        ObjUser.FirstName = objReader["FirstName"].ToString();
                        ObjUser.LastName = objReader["LastName"].ToString();
                        ObjUser.Email = objReader["Email"].ToString();
                        ObjUser.SystemUserRoleID = Convert.ToInt32(objReader["RoleId"]);

                        ObjUser.IsActive = (Boolean)objReader["IsActive"];

                    }


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }

            return ObjUser;
        }

        public UserModel GetSubscriberByID(string UserID)
        {
            UserModel ObjUser = new UserModel();
            try
            {

                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetSubscriberByID", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@SystemUserID", AESEncryption.Decrypt(UserID));
                objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {

                        ObjUser.Username = objReader["UserName"].ToString();
                        ObjUser.SystemUserID = AESEncryption.Encrypt((objReader["SubscriberID"]).ToString());
                        // ObjUser.Password = objReader["Password"].ToString();
                        ObjUser.Password = "********";
                        ObjUser.FirstName = objReader["FirstName"].ToString();
                        ObjUser.LastName = objReader["LastName"].ToString();
                        ObjUser.Email = objReader["EmailAddress"].ToString();
                        ObjUser.SystemUserRoleID = Convert.ToInt32(objReader["RoleId"]);

                        ObjUser.IsActive = (bool)objReader["IsActive"];

                    }


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }

            return ObjUser;
        }

        public int InsertSystemUser(UserModel objUser, int CreatedBy, int ServiceProvideID)
        {
            int success = 0;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_InsertSystemUser", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objCommand.Parameters.AddWithValue("@FirstName", objUser.FirstName);
                objCommand.Parameters.AddWithValue("@LastName", objUser.LastName);
                objCommand.Parameters.AddWithValue("@Active", objUser.IsActive);
                objCommand.Parameters.AddWithValue("@Role", objUser.Role);
                objCommand.Parameters.AddWithValue("@Email", objUser.Email);
                objCommand.Parameters.AddWithValue("@UserName", objUser.Username);
                objCommand.Parameters.AddWithValue("@Password", objUser.Password);
                //This parameter are hard code for time being
                objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCommand.Parameters.AddWithValue("@UpdatedBy", CreatedBy);
                objCommand.Parameters.AddWithValue("@ServiceProvideID", ServiceProvideID);
                objCommand.Parameters.AddWithValue("@IsPasswordReset", !objUser.IsPasswordReset);
                success = (Int32)objCommand.ExecuteScalar();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
            return success;
        }

        public int UpdateUser(UserModel ObjUser, int UpdatedBy)
        {
            int Success = 0;

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_UpdateSystemUser", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@FirstName", ObjUser.FirstName);
                objCommand.Parameters.AddWithValue("@LastName", ObjUser.LastName);
                objCommand.Parameters.AddWithValue("@Email", ObjUser.Email);
                objCommand.Parameters.AddWithValue("@UserName", ObjUser.Username);
                objCommand.Parameters.AddWithValue("@Role", ObjUser.SystemUserRoleID);
                objCommand.Parameters.AddWithValue("@IsActive", ObjUser.IsActive);
                objCommand.Parameters.AddWithValue("@UserId", AESEncryption.Decrypt(ObjUser.SystemUserID));
                objCommand.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

                Success = objCommand.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
            return Success;
        }

        public int UpdateSubscriber(bool IsActive, int UpdatedBy, string subscriberID)
        {
            int Success = 0;

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_UpdateSubscriber", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@IsActive", IsActive);
                objCommand.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCommand.Parameters.AddWithValue("@UserId", AESEncryption.Decrypt(subscriberID));
                Success = objCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
            return Success;
        }

        /// <summary>
        /// Create Username based on first name and last name of system USER. 
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public string GetUserName(string firstname, string lastname)
        {
            string UserName = null;

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetSytemUserName", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@FirstName", firstname);
                objCommand.Parameters.AddWithValue("@LastName", lastname);
                UserName = objCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
            return UserName;
        }

        /// <summary>
        /// Get Username on EmailId Validation
        /// </summary>
        /// <param name="EmailID">EmailId of user</param>
        /// <returns>Username</returns>
        public UserModel ForgotUserName(string EmailID)
        {
            UserModel objUser = new UserModel();
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetUserName", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@EmailID", EmailID);
                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        using (objReader)
                        {
                            objUser.FirstName = objReader["FirstName"].ToString();
                            objUser.LastName = objReader["LastName"].ToString();
                            objUser.Username = objReader["UserName"].ToString();
                            objUser.ServiceProviderID = Convert.ToInt32(objReader["ServiceProviderID"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return objUser;
        }

        /// <summary>
        /// Get Password Link on EmailId Validation
        /// </summary>
        /// <param name="EmailID">EmailId of user</param>
        /// <returns>ResetPwdID</returns>
        public UserModel GetResetPasswordLink(string EmailID)
        {
            UserModel objUser = new UserModel();
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetResetPasswordLink", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@EmailID", EmailID);
                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        using (objReader)
                        {
                            int InvalidEmail = Convert.ToInt16(objReader["InvalidEmail"]);
                            if (InvalidEmail == -2)
                            {
                                objUser.FirstName = null;
                                objUser.LastName = null;
                                objUser.Username = null;
                                objUser.Email = null;
                            }
                            else
                            {
                                objUser.FirstName = objReader["FirstName"].ToString();
                                objUser.LastName = objReader["LastName"].ToString();
                                objUser.Username = objReader["UserName"].ToString();

                                objUser.ServiceProviderID = Convert.ToInt32(objReader["ServiceproviderID"]);
                                objUser.Email = objReader["ResetPassWordID"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return objUser;
        }

        /// <summary>
        /// Reset the pwd by accessing the mailed link
        /// </summary>
        /// <param name="ResetPwdId">Pwd in Link</param>
        /// <param name="objUser">Changed Pwd by User</param>
        /// <returns></returns>
        public int AccessResetPasswordLink(string ResetPwdId, string NewPassword)
        {
            int success = -1;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_AccessResetPasswordLink", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ResetPwdId", ResetPwdId);
                    objCommand.Parameters.AddWithValue("@Password", NewPassword);
                    success = Convert.ToInt32(objCommand.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return success;
        }


        /// <summary>
        /// Validate reset the pwd link
        /// </summary>
        /// <param name="ResetPwdId">Pwd in Link</param>
        /// <param name="objUser">Changed Pwd by User</param>
        /// <returns></returns>
        public int ValidateResetPasswordLink(string ResetPwdId)
        {
            int success = -1;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_ValidateResetPasswordLink", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ResetPwdId", ResetPwdId);
                    success = Convert.ToInt32(objCommand.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return success;
        }

        public int ValidateUserEmailId(string EmailId, int UserID)
        {
            int Result = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_ValidateUserEmailId", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@EmailId", EmailId);
                    objCommand.Parameters.AddWithValue("@UserID", UserID);
                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        using (objReader)
                        {
                            Result = Convert.ToInt16(objReader["Result"]);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return Result;
        }
    }
}
