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
    public class DBCMSBanner : DBHelper
    {
        public int InsertCMSBanner(VMCMSBanner objVMCMSBanner, int ServiceProviderID, int CreatedBy)
        {
            int success = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_InsertCMSBanner", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@BannerID", objVMCMSBanner.CMSBannerID);
                    objCommand.Parameters.AddWithValue("@BannerImage1", objVMCMSBanner.BannerImg1 == null ? "" : objVMCMSBanner.BannerImg1);
                    objCommand.Parameters.AddWithValue("@BannerText1", objVMCMSBanner.BannerTxt1== null ? "" :objVMCMSBanner.BannerTxt1);
                    objCommand.Parameters.AddWithValue("@BannerImage2", objVMCMSBanner.BannerImg2 == null ? "" : objVMCMSBanner.BannerImg2);
                    objCommand.Parameters.AddWithValue("@BannerText2", objVMCMSBanner.BannerTxt2== null ? "" :objVMCMSBanner.BannerTxt2);
                    objCommand.Parameters.AddWithValue("@BannerImage3", objVMCMSBanner.BannerImg3 == null ? "" : objVMCMSBanner.BannerImg3);
                    objCommand.Parameters.AddWithValue("@BannerText3", objVMCMSBanner.BannerTxt3== null ? "" :objVMCMSBanner.BannerTxt3);
                    objCommand.Parameters.AddWithValue("@ServiceProviderId", ServiceProviderID);
                    objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    objCommand.ExecuteNonQuery();
                }
                success = 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return success;
        }

        public VMCMSBanner GetCMSBanner(int ServiceProviderID)
        {
            VMCMSBanner objVMCMSBanner = new VMCMSBanner();
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetCMSBanner", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ServiceProviderId", ServiceProviderID);

                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        using (objReader)
                        {
                            objVMCMSBanner.CMSBannerID = Convert.ToInt32(objReader["BannerID"]);
                            objVMCMSBanner.BannerImg1 = objReader["BannerImage1"].ToString() == "" ? null : objReader["BannerImage1"].ToString();
                            objVMCMSBanner.BannerTxt1 = objReader["BannerText1"].ToString() == "" ? null : objReader["BannerText1"].ToString();
                            objVMCMSBanner.BannerImg2 = objReader["BannerImage2"].ToString() == "" ? null : objReader["BannerImage2"].ToString();
                            objVMCMSBanner.BannerTxt2 = objReader["BannerText2"].ToString() == "" ? null : objReader["BannerText2"].ToString();
                            objVMCMSBanner.BannerImg3 = objReader["BannerImage3"].ToString() == "" ? null : objReader["BannerImage3"].ToString();
                            objVMCMSBanner.BannerTxt3 = objReader["BannerText3"].ToString() == "" ? null : objReader["BannerText3"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return objVMCMSBanner;
        }
    }
}
