using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartPark.Data
{
    public class DBCMS : DBHelper
    {
        public Hashtable getFilesByServiceProviderId(int ServPrvdId)
        {
            //List<string> lstFiles = null;
            Hashtable hashfiles = null;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetUploadImages", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServPrvdId);

                    using (objReader = objCommand.ExecuteReader())
                    {
                        // lstFiles = new List<string>();
                        hashfiles = new Hashtable();
                        while (objReader.Read())
                        {
                            //lstFiles.Add(Convert.ToString(objReader["FileName"]));
                            hashfiles.Add(Convert.ToString(objReader["ID"]), Convert.ToString(objReader["FileName"]));
                        }
                        return hashfiles;
                    }
                }
            }
            catch (Exception ex)
            {
                return hashfiles;
            }
        }

        public int InsertFileName(int CreatedBy, int ServiceProvideID, string strFileName)
        {
            int success = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_InsertUploadImage", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ServiceProviderId", ServiceProvideID);
                    objCommand.Parameters.AddWithValue("@FileName", strFileName);
                    objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    success = (Int32)objCommand.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return success;
        }

        public bool DeleteRecord(int id)
        {
            int success = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_DeleteUploadImage", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@Id", id);
                    success = (Int32)objCommand.ExecuteNonQuery();
                    if (success > 0)
                        return true;
                    else
                        return false;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public int InsertContent(int SectionID, int ServiceProvideID, string CMSContent, int CreatedBy)
        {
            int success = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_InsertCMSContent", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ServiceProviderId", ServiceProvideID);
                    objCommand.Parameters.AddWithValue("@CMSContent", CMSContent);
                    objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    objCommand.Parameters.AddWithValue("@SectionID", SectionID);
                    objCommand.Parameters.AddWithValue("@Action", "INSERT");
                    success = (Int32)objCommand.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return success;
        }

        public int EditContent(int contentID, int SectionID, int ServiceProvideID, string CMSContent, int CreatedBy)
        {
            int success = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_InsertCMSContent", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ServiceProviderId", ServiceProvideID);
                    objCommand.Parameters.AddWithValue("@CMSContent", CMSContent);
                    objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    objCommand.Parameters.AddWithValue("@SectionID", SectionID);
                    objCommand.Parameters.AddWithValue("@ContentID", contentID);
                    objCommand.Parameters.AddWithValue("@Action", "EDIT");
                    success = (Int32)objCommand.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return success;
        }

        public ArrayList getCMSContent(int SectionID, int ServiceProvideID)
        {
            ArrayList arrLst = null;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetCMSContent", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ServiceProviderId", ServiceProvideID);
                    objCommand.Parameters.AddWithValue("@SectionID", SectionID);

                    using (objReader = objCommand.ExecuteReader())
                    {
                        if (objReader.Read())
                        {
                            arrLst = new ArrayList();
                            arrLst.Add(Convert.ToString(objReader["HTMLContent"]));
                            arrLst.Add(Convert.ToInt32(objReader["CMSId"]));
                        }
                        return arrLst;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

    }
}
