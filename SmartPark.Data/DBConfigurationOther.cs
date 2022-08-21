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
    public class DBConfigurationOther : DBUser
    {
        public OtherConfig GetServiceProviderOthersConfiguration(string page, string sortdir, string sortColumn,
            int serviceProviderId)
        {
            var objOtherCng = new OtherConfig();
            List<OtherConfig> ListOtherConfig = null;
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "Name_ASC";
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetServiceProviderOthersConfiguration", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PageNbr", page);
                objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceProviderId);

                using (objReader = objCommand.ExecuteReader())
                {
                    if (objReader.HasRows)
                    {
                        ListOtherConfig = new List<OtherConfig>();
                        while (objReader.Read())
                        {
                            var ObjOtherConfig = new OtherConfig();
                            ObjOtherConfig.ListType = objReader["ListType"].ToString();
                            ObjOtherConfig.Label = objReader["Label"].ToString();
                            ObjOtherConfig.Value = objReader["Value"].ToString();
                            ObjOtherConfig.DisplayOrder = (Int32)objReader["DisplayOrder"];
                            ObjOtherConfig.IsEnabled = (bool)objReader["IsEnabled"];
                            ObjOtherConfig.TotalCount = (Int32)objReader["TotalCount"];
                            ObjOtherConfig.OtherConfigID = (Int32)objReader["ConfigurationOthersID"];
                            ListOtherConfig.Add(ObjOtherConfig);
                        }
                        objOtherCng.lstOtherConfig = ListOtherConfig;
                    }
                }


                //Call SP which will fetch others Configuration fields.
                objCommand = new SqlCommand("usp_GetModuleDisplayed", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceProviderId);
                using (objReader = objCommand.ExecuteReader())
                {
                    if (objReader.HasRows)
                    {
                        if (objReader.Read())
                        {
                            objOtherCng.bIsAgentKiosk = (bool)objReader["AllowAgentKiosk"];
                            objOtherCng.bIsBackOffice = (bool)objReader["AllowBackOffice"];
                        }
                    }
                }

                return objOtherCng;
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
            return objOtherCng;
        }



        public List<SelectListItem> GetAllPortalThemes()
        {
            var portalThemesList = new List<SelectListItem>();
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetAllPortalThemes", objConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (objReader = objCommand.ExecuteReader())
                {
                    if (objReader.HasRows)
                    {
                        while (objReader.Read())
                        {
                            portalThemesList.Add(new SelectListItem
                            {
                                Text = objReader["PortalThemeName"].ToString(),
                                Value = Convert.ToInt32(objReader["PortalThemeID"]).ToString(),
                                Selected = false
                            });
                        }
                        return portalThemesList;
                    }
                }
                return portalThemesList;
            }
            catch (Exception e)
            {
                //call a logger service.
            }
            return portalThemesList;
        }

        public int InsertOtherConfiguration(OtherConfig otherconfig, int CreatedBy, int serviceProvider)
        {
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_InsertOtherConfig", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ListType", otherconfig.ListType);
                objCommand.Parameters.AddWithValue("@Label", otherconfig.Label);
                objCommand.Parameters.AddWithValue("@Value", otherconfig.Value);
                objCommand.Parameters.AddWithValue("@DisplayOrder", otherconfig.DisplayOrder == null || otherconfig.DisplayOrder.ToString() == "" ? 0 : otherconfig.DisplayOrder);
                objCommand.Parameters.AddWithValue("@IsEnabled", otherconfig.IsEnabled);
                objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCommand.Parameters.AddWithValue("@UpdatedBy", CreatedBy);
                objCommand.Parameters.AddWithValue("@ServiceProvideID", serviceProvider);
                objCommand.Parameters.AddWithValue("@ActionType", "add");
                objCommand.Parameters.AddWithValue("@ConfigurationOthersID", 0);

                objReader = objCommand.ExecuteReader();
                int ConfigurationOthersID = 0;
                if (objReader.Read())
                {
                    ConfigurationOthersID = Convert.ToInt32(objReader["ConfigurationOthersID"].ToString());
                }

                if (objReader != null)
                {
                    objReader.Close();
                }

                return ConfigurationOthersID;
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
            
        }

        public int UpdateOtherConfiguration(OtherConfig otherconfig, int CreatedBy, int serviceProvider)
        {
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_InsertOtherConfig", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ListType", otherconfig.ListType);
                objCommand.Parameters.AddWithValue("@Label", otherconfig.Label);
                objCommand.Parameters.AddWithValue("@Value", otherconfig.Value);
                objCommand.Parameters.AddWithValue("@DisplayOrder", otherconfig.DisplayOrder);
                objCommand.Parameters.AddWithValue("@IsEnabled", otherconfig.IsEnabled);
                objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCommand.Parameters.AddWithValue("@UpdatedBy", CreatedBy);
                objCommand.Parameters.AddWithValue("@ServiceProvideID", serviceProvider);
                objCommand.Parameters.AddWithValue("@ActionType", "edit");
                objCommand.Parameters.AddWithValue("@ConfigurationOthersID", otherconfig.OtherConfigID);

                objReader = objCommand.ExecuteReader();
                int ConfigurationOthersID = 0;
                if (objReader.Read())
                {
                    ConfigurationOthersID = Convert.ToInt32(objReader["ConfigurationOthersID"].ToString());
                }

                if (objReader != null)
                {
                    objReader.Close();
                }

                return ConfigurationOthersID;
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
          
        }



        public int UpdateAgentKioskModule(bool bAgentKiosk, int CreatedBy, int serviceProvider)
        {
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_UpdateAgentKioskModule", objConnection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@AgentKiosk", bAgentKiosk);
                    objCommand.Parameters.AddWithValue("@ServicePrvdrId", serviceProvider);
                    objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    objCommand.Parameters.AddWithValue("@UpdatedBy", CreatedBy);

                    int Result = objCommand.ExecuteNonQuery();
                    return Result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public int UpdateBackOfficeModule(bool bBackOffice, int CreatedBy, int serviceProvider)
        {
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_UpdateBackOfficeModule", objConnection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@BackOffice", bBackOffice);
                    objCommand.Parameters.AddWithValue("@ServicePrvdrId", serviceProvider);
                    objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    objCommand.Parameters.AddWithValue("@UpdatedBy", CreatedBy);

                    int Result = objCommand.ExecuteNonQuery();
                    return Result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public OtherConfig GetOtherConfigByOtherConfigId(int OtherConfigId)
        {
            OtherConfig ObjOtherConfig = null;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_InsertOtherConfig", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ActionType", "select");
                objCommand.Parameters.AddWithValue("@ConfigurationOthersID", OtherConfigId);

                using (objReader = objCommand.ExecuteReader())
                {
                    if (objReader.HasRows)
                    {
                        while (objReader.Read())
                        {
                            ObjOtherConfig = new OtherConfig();
                            ObjOtherConfig.ListType = objReader["ListType"].ToString();
                            ObjOtherConfig.Label = objReader["Label"].ToString();
                            ObjOtherConfig.Value = objReader["Value"].ToString();
                            ObjOtherConfig.DisplayOrder = (Int32)objReader["DisplayOrder"];
                            ObjOtherConfig.IsEnabled = (bool)objReader["IsEnabled"];
                            ObjOtherConfig.OtherConfigID = (Int32)objReader["ConfigurationOthersID"];
                        }
                    }
                }
                return ObjOtherConfig;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}