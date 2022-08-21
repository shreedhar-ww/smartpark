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
    public class DBCMSFeatureTiles : DBHelper
    {
        public int InsertCMSFeature(VMCMSFeatureTiles objVMCMSFeature, int ServiceProviderID, int CreatedBy)
        {
            int success = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_InsertCMSFeatureTiles", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@FeatureTilesID", objVMCMSFeature.CMSFeatureTilesID);
                    objCommand.Parameters.AddWithValue("@FeatureImage1", objVMCMSFeature.FeatureImg1 == null ? "" : objVMCMSFeature.FeatureImg1);
                    objCommand.Parameters.AddWithValue("@FeatureText1", objVMCMSFeature.FeatureTxt1 == null ? "" : objVMCMSFeature.FeatureTxt1);
                    objCommand.Parameters.AddWithValue("@YoutubeURL1", objVMCMSFeature.YoutubeURL1 == null ? "" : objVMCMSFeature.YoutubeURL1);
                    objCommand.Parameters.AddWithValue("@FeatureImage2", objVMCMSFeature.FeatureImg2 == null ? "" : objVMCMSFeature.FeatureImg2);
                    objCommand.Parameters.AddWithValue("@FeatureText2", objVMCMSFeature.FeatureTxt2 == null ? "" : objVMCMSFeature.FeatureTxt2);
                    objCommand.Parameters.AddWithValue("@YoutubeURL2", objVMCMSFeature.YoutubeURL2 == null ? "" : objVMCMSFeature.YoutubeURL2);
                    objCommand.Parameters.AddWithValue("@FeatureImage3", objVMCMSFeature.FeatureImg3 == null ? "" : objVMCMSFeature.FeatureImg3);
                    objCommand.Parameters.AddWithValue("@FeatureText3", objVMCMSFeature.FeatureTxt3 == null ? "" : objVMCMSFeature.FeatureTxt3);
                    objCommand.Parameters.AddWithValue("@YoutubeURL3", objVMCMSFeature.YoutubeURL3 == null ? "" : objVMCMSFeature.YoutubeURL3);
                    objCommand.Parameters.AddWithValue("@FeatureImage4", objVMCMSFeature.FeatureImg4 == null ? "" : objVMCMSFeature.FeatureImg4);
                    objCommand.Parameters.AddWithValue("@FeatureText4", objVMCMSFeature.FeatureTxt4 == null ? "" : objVMCMSFeature.FeatureTxt4);
                    objCommand.Parameters.AddWithValue("@YoutubeURL4", objVMCMSFeature.YoutubeURL4 == null ? "" : objVMCMSFeature.YoutubeURL4);
                    objCommand.Parameters.AddWithValue("@ServiceProviderId", ServiceProviderID);
                    objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    objCommand.ExecuteNonQuery();
                }
                success = 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
                success = 0;
            }
            return success;
        }

        public VMCMSFeatureTiles GetCMSFeature(int ServiceProviderID)
        {
            VMCMSFeatureTiles objVMCMSFeature = new VMCMSFeatureTiles();
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetCMSFeatureTiles", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ServiceProviderId", ServiceProviderID);

                    objReader = objCommand.ExecuteReader();
                    if (objReader.Read())
                    {
                        using (objReader)
                        {
                            objVMCMSFeature.CMSFeatureTilesID = Convert.ToInt32(objReader["FeatureTilesID"]);
                            objVMCMSFeature.FeatureImg1 = objReader["FeatureImage1"].ToString() == "" ? null : objReader["FeatureImage1"].ToString();
                            objVMCMSFeature.YoutubeURL1 = objReader["YoutubeURL1"].ToString() == "" ? null : objReader["YoutubeURL1"].ToString();
                            objVMCMSFeature.FeatureImg2 = objReader["FeatureImage2"].ToString() == "" ? null : objReader["FeatureImage2"].ToString();                        
                            objVMCMSFeature.YoutubeURL2 = objReader["YoutubeURL2"].ToString() == "" ? null : objReader["YoutubeURL2"].ToString();
                            objVMCMSFeature.FeatureImg3 = objReader["FeatureImage3"].ToString() == "" ? null : objReader["FeatureImage3"].ToString();                         
                            objVMCMSFeature.YoutubeURL3 = objReader["YoutubeURL3"].ToString() == "" ? null : objReader["YoutubeURL3"].ToString();
                            objVMCMSFeature.FeatureImg4 = objReader["FeatureImage4"].ToString() == "" ? null : objReader["FeatureImage4"].ToString();                        
                            objVMCMSFeature.YoutubeURL4 = objReader["YoutubeURL4"].ToString() == "" ? null : objReader["YoutubeURL4"].ToString();
                            objVMCMSFeature.FeatureTxt1 = objReader["FeatureText1"].ToString() == "" ? null : objReader["FeatureText1"].ToString();
                            objVMCMSFeature.FeatureTxt2 = objReader["FeatureText2"].ToString() == "" ? null : objReader["FeatureText2"].ToString();
                            objVMCMSFeature.FeatureTxt3 = objReader["FeatureText3"].ToString() == "" ? null : objReader["FeatureText3"].ToString();
                            objVMCMSFeature.FeatureTxt4 = objReader["FeatureText4"].ToString() == "" ? null : objReader["FeatureText4"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            
           

            return objVMCMSFeature;
        }
    }
}

