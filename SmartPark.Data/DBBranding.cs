using SmartPark.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SmartPark.Data
{
    public class DBBranding : DBUser
    {
        public VMBrandingModel GetBrandingByServiceProviderId(int serviceProviderId)
        {
            VMBrandingModel brandingModel = null;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetBrandingDetails", objConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                objCommand.Parameters.AddWithValue("@ServiceProviderId", serviceProviderId);

                using (objReader = objCommand.ExecuteReader())
                {
                    if (objReader.HasRows)
                    {
                        while (objReader.Read())
                        {
                            brandingModel = new VMBrandingModel();
                             
                              brandingModel.LandingPageURL = objReader["LandingPageURL"].ToString();
                               brandingModel.hdnAgentLogo = objReader["ClientLogo"].ToString();
                               brandingModel.hdnBannerLogo = objReader["HeaderBanner"].ToString();
                               brandingModel.hdnFavIcon = objReader["FavIcon"].ToString();
                             brandingModel.PortalThemeID = (int)objReader["PortalThemeID"];
                            if(!objReader.IsDBNull(objReader.GetOrdinal("Common")))
                            {
                                brandingModel.Common =  (bool)(objReader["Common"]);
                            }

                            if (!objReader.IsDBNull(objReader.GetOrdinal("Customised")))
                            {
                                brandingModel.Customised = (bool)(objReader["Customised"]);
                            }

                            if (!objReader.IsDBNull(objReader.GetOrdinal("Personalised")))
                            {
                                brandingModel.Personalised = (bool)(objReader["Personalised"]);
                            }

                            if (!objReader.IsDBNull(objReader.GetOrdinal("Customised")))
                            {
                                brandingModel.Customised = (bool)(objReader["Customised"]);
                            }
                            if (objReader.IsDBNull(objReader.GetOrdinal("ContactInfo")))
                            {
                                brandingModel.ContactInfo = "";
                            }
                            else
                            {
                                brandingModel.ContactInfo = objReader["ContactInfo"].ToString();
                            }

                            brandingModel.Facebook = objReader["Facebook"].ToString();
                            brandingModel.Twitter = objReader["Twitter"].ToString();
                            brandingModel.Google = objReader["Google"].ToString();


                            if (objReader.IsDBNull(objReader.GetOrdinal("RFIDcharges")))
                            {
                                brandingModel.RFIDcharges = 0;
                            }
                            else
                            {
                                brandingModel.RFIDcharges = Convert.ToDecimal(objReader["RFIDcharges"]);
                            }

                            if (objReader.IsDBNull(objReader.GetOrdinal("CurrencySymbol")))
                            {
                                brandingModel.CurrencySymbol = "$";
                            }
                            else
                            {
                                brandingModel.CurrencySymbol = objReader["CurrencySymbol"].ToString();
                            }


                            if (objReader.IsDBNull(objReader.GetOrdinal("ProviderName")))
                            {
                                brandingModel.serviceProviderName = "";
                            }
                            else
                            {
                                brandingModel.serviceProviderName = (objReader["ProviderName"].ToString());
                            }

                            if (objReader.IsDBNull(objReader.GetOrdinal("Link")))
                            {
                                brandingModel.websiteLink = "";
                            }
                            else
                            {
                                brandingModel.websiteLink = (objReader["Link"].ToString());
                            }

                            if (objReader.IsDBNull(objReader.GetOrdinal("Disclaimer")))
                            {
                                brandingModel.Disclaimer = "";
                            }
                            else
                            {
                                brandingModel.Disclaimer = (objReader["Disclaimer"].ToString());
                            }


                            
                            brandingModel.ContactEmail = objReader["ContactEmail"].ToString();

                            //brandingModel.RFIDcharges = Convert.ToDecimal(string.IsNullOrEmpty((objReader["RFIDcharges"]) ? (object)DBNull.Value :  (objReader["RFIDcharges"])));
                            //brandingModel.CurrencySymbol = objReader["CurrencySymbol"].ToString();
                            
                             
                        }
                        objReader.NextResult();
                        var portalThemesList = new List<SelectListItem>();
                        List<PortalTheme> ListPortalTheme = new List<PortalTheme>();
                        while (objReader.Read())
                        {
                            portalThemesList.Add(new SelectListItem
                            {
                                Text = objReader["PortalThemeName"].ToString(),
                                Value = Convert.ToInt32(objReader["PortalThemeID"]).ToString(),
                                Selected = false
                            });
                        }
                        if (brandingModel != null)
                            brandingModel.PortalThemesList = portalThemesList;
                        //while (objReader.Read())
                        //{
                        //    PortalTheme objPortalTheme = new PortalTheme();
                           
                        //    {
                        //        // Text = objReader["PaymentModeID"].ToString(),
                        //        objPortalTheme.PortalThemeName = objReader["PortalThemeName"].ToString();
                        //        objPortalTheme.PortalThemeID = (int)(objReader["PortalThemeID"]);
                        //        ListPortalTheme.Add(objPortalTheme);

                        //    }
                             
                        //}
                        //if (ListPortalTheme != null)
                        //    brandingModel.PortalThemesList = ListPortalTheme;
                    }
                }

                return brandingModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            return brandingModel;
        }


        public VMBrandingModel SaveBrandingByServiceProviderId(VMBrandingModel brandingModel, int UpdatedBy)
        {
            try
            {
                //Save Agent Logo


                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_UpdateBrandingDetails", objConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                objCommand.Parameters.AddWithValue("@Common", brandingModel.Common);
                objCommand.Parameters.AddWithValue("@Personalised", brandingModel.Personalised);
                objCommand.Parameters.AddWithValue("@Customised", brandingModel.Customised);
                objCommand.Parameters.AddWithValue("@PortalThemeID", brandingModel.PortalThemeID == null ? 1 : brandingModel.PortalThemeID);
                objCommand.Parameters.AddWithValue("@LandingPageURL", brandingModel.LandingPageURL);
                objCommand.Parameters.AddWithValue("@ClientLogo", brandingModel.hdnAgentLogo);
                objCommand.Parameters.AddWithValue("@HeaderBanner", brandingModel.hdnBannerLogo);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", brandingModel.ServiceProviderID);
                objCommand.Parameters.AddWithValue("@ContactInfo", brandingModel.ContactInfo);
                objCommand.Parameters.AddWithValue("@RFIDcharges", brandingModel.RFIDcharges);
                objCommand.Parameters.AddWithValue("@CurrencySymbol",brandingModel.CurrencySymbol);

                objCommand.Parameters.AddWithValue("@Link", brandingModel.websiteLink);
                objCommand.Parameters.AddWithValue("@ProviderName", brandingModel.serviceProviderName);
                objCommand.Parameters.AddWithValue("@Disclaimer", brandingModel.Disclaimer);

                objCommand.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCommand.Parameters.AddWithValue("@FavIcon", brandingModel.hdnFavIcon);
                 

                if(brandingModel.Facebook == null )
                {
                    objCommand.Parameters.AddWithValue("@Facebook",DBNull.Value);
                }
                else{
                 objCommand.Parameters.AddWithValue("@Facebook", brandingModel.Facebook);
                }

                if (brandingModel.Twitter == null)
                {
                    objCommand.Parameters.AddWithValue("@Twitter", DBNull.Value);
                }
                else {
                    objCommand.Parameters.AddWithValue("@Twitter", brandingModel.Twitter);
                }

                if (brandingModel.Google == null)
                {
                    objCommand.Parameters.AddWithValue("@Google", DBNull.Value);
                }
                else
                {
                    objCommand.Parameters.AddWithValue("@Google", brandingModel.Google);
                }


                objCommand.Parameters.AddWithValue("@ContactEmail", brandingModel.ContactEmail);


             //   objCommand.Parameters.AddWithValue("@Twitter", brandingModel.Twitter == null ? brandingModel.Twitter : "");
              //  objCommand.Parameters.AddWithValue("@Google", brandingModel.Google == null ? brandingModel.Google : "");

                int numberOfRowsUpdated = objCommand.ExecuteNonQuery();

                return brandingModel;
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
            return brandingModel;
        }


        public string getServiceURL(int serviceProviderID)
        {

            string serviceProviderURL = null;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetCommonPortalURL", objConnection);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", serviceProviderID);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                serviceProviderURL = objCommand.ExecuteScalar().ToString();


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
            return serviceProviderURL;
        }

        public bool checkEmailAdderessAvailability(int ServiceProviderID, string EmailAddress)
        {
            bool result = false;
            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_CheckEmialAddressAvailability", objConnection);
                objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderID);
                objCommand.Parameters.AddWithValue("@EmailAddress", EmailAddress);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                result = bool.Parse(objCommand.ExecuteScalar().ToString());


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
            return result;
        }
    }
}
