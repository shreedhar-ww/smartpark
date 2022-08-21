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
    public class DBBackOffice : DBHelper
    {
        public List<VMBackOffice> GetAllBackOfficeDtls(string page, string sortdir, string sortColumn, int ServiceProvider, VMBackOffice objVMBackOffice)
        {
            List<VMBackOffice> ListBackOffice = new List<VMBackOffice>();
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "BackOfficeID_DESC";

            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetBackOfficeDetail", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PageNbr", iCurrentPage);
                    objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                    objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProvider);
                    objCommand.Parameters.AddWithValue("@RFIDNumber", objVMBackOffice.RFIDNumber == null ? "" : objVMBackOffice.RFIDNumber);
                    objCommand.Parameters.AddWithValue("@FirstName", objVMBackOffice.FirstName == null ? "" : objVMBackOffice.FirstName);
                    objCommand.Parameters.AddWithValue("@LastName", objVMBackOffice.LastName == null ? "" : objVMBackOffice.LastName);
                    objCommand.Parameters.AddWithValue("@PermitId", objVMBackOffice.PermitState == null || objVMBackOffice.PermitState == "0" ? "" : objVMBackOffice.PermitState.ToString());

                    objReader = objCommand.ExecuteReader();
                    using (objReader)
                    {
                        while (objReader.Read())
                        {
                            VMBackOffice modelBackOffice = new VMBackOffice();
                            modelBackOffice.BackOfficeID = Convert.ToInt32(objReader["BackOfficeID"]);
                            modelBackOffice.RFIDNumber = objReader["RFIDNumber"].ToString();
                            modelBackOffice.Subscriber = objReader["Subscriber"].ToString();
                            modelBackOffice.InitiatedDate = Convert.ToDateTime(objReader["InitiatedDate"]);
                            if (objReader.IsDBNull(5))
                            {
                                modelBackOffice.ActivatedDate = null;
                            }
                            else
                            {
                                modelBackOffice.ActivatedDate = Convert.ToDateTime(objReader["ActivatedDate"]);
                            }

                            if (objReader.IsDBNull(6))
                            {
                                modelBackOffice.PostedDate = null;
                            }
                            else
                            {
                                modelBackOffice.PostedDate = Convert.ToDateTime(objReader["PosteDate"]);
                            }

                            modelBackOffice.PermitState = objReader["PermitState"].ToString();
                            modelBackOffice.GridCarParkName = objReader["CarParkName"].ToString();
                            modelBackOffice.GridParkType = objReader["ParkType"].ToString();
                            modelBackOffice.TotalCount = Convert.ToInt32(objReader["TotalCount"]);
                            ListBackOffice.Add(modelBackOffice);
                        }
                        return ListBackOffice;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return ListBackOffice;
        }

        public VMBackOffice GetBackOfficeByID(int BackOfficeID)
        {
            VMBackOffice objVMBackOffice = new VMBackOffice();
            List<VMBackOffice> listVMBAckOffice = new List<VMBackOffice>();

            try
            {
                objConnection = new SqlConnection(connectionString);
                objConnection.Open();
                objCommand = new SqlCommand("usp_GetBackOfficeDetailsByID", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@BackOfficeId", BackOfficeID);
                objReader = objCommand.ExecuteReader();
                using (objReader)
                {
                    while (objReader.Read())
                    {
                        objVMBackOffice.BackOfficeID = Convert.ToInt32(objReader["BackOfficeID"]);
                        objVMBackOffice.GlobalRFIDTagId = Convert.ToInt32(objReader["GlobalRFIDTagID"]);
                        objVMBackOffice.SubscriberId = Convert.ToInt32(objReader["SubscriberId"]);
                        objVMBackOffice.RFIDNumber = objReader["RFIDNumber"].ToString();
                        objVMBackOffice.Subscriber = objReader["Subscriber"].ToString();
                        objVMBackOffice.AutoTopUpValue = Convert.ToDecimal(objReader["TopUpValue"]);
                        objVMBackOffice.isBalanceUpdated = Convert.ToBoolean(objReader["IsBalanceUpdated"]);
                        objVMBackOffice.Balance = Convert.ToDecimal(objReader["Balance"]);
                        objVMBackOffice.EwayCustomerId = AESEncryption.Encrypt(objReader["CustomerID"].ToString());
                        objVMBackOffice.CarParkID = objReader["CarParkID"].ToString();
                        objVMBackOffice.ParkTypeId = objReader["CarParkBayTypeID"].ToString();
                        objVMBackOffice.EmailAddress = objReader["Email"].ToString();
                        objVMBackOffice.Name = objReader["Name"].ToString();
                        objVMBackOffice.IsNewPermitApply = (bool)objReader["IsNewPermitApply"];
                        objVMBackOffice.AuthKey = objReader["AuthorityKey"].ToString();
                        //objVMBackOffice.ParkTypeId = Convert.ToInt16(objReader["CarParkBayTypeID"]);                      


                        if (Convert.IsDBNull(objReader["InitiatedDate"]))
                        {
                            objVMBackOffice.InitiatedDate = null;
                        }
                        else
                        {
                            objVMBackOffice.InitiatedDate = Convert.ToDateTime(objReader["InitiatedDate"]);
                        }


                        if (objReader["ActivatedDate"] == DBNull.Value)
                        {
                            objVMBackOffice.ActivatedDate = null;
                        }
                        else
                        {
                            objVMBackOffice.ActivatedDate = Convert.ToDateTime(objReader["ActivatedDate"]);
                        }

                        if (objReader["PosteDate"] == DBNull.Value)
                        {
                            objVMBackOffice.PostedDate = null;
                        }
                        else
                        {
                            objVMBackOffice.PostedDate = Convert.ToDateTime(objReader["PosteDate"]);
                        }

                        //objVMBackOffice.PermitState = objReader["PermitStateID"].ToString();
                        objVMBackOffice.PermitStateID = Convert.ToInt32(objReader["PermitStateID"]);

                        if (objReader.NextResult())
                        {
                            List<VMBackOffice.CarPark> listCarPark = new List<VMBackOffice.CarPark>();
                            while (objReader.Read())
                            {
                                VMBackOffice.CarPark objCarPark = new VMBackOffice.CarPark();
                                objCarPark.CarParkName = objReader["CarParkName"].ToString();
                                objCarPark.CarParkType = objReader["Name"].ToString();
                                objVMBackOffice.newCarparkID = Convert.ToInt32(objReader["CarParkID"].ToString());
                                objVMBackOffice.newcarparkbaytypeID = Convert.ToInt32(objReader["CarParkBayTypeID"].ToString());
                                listCarPark.Add(objCarPark);
                            }
                            objVMBackOffice.CarParkList = listCarPark;
                        }
                    }
                    return objVMBackOffice;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return objVMBackOffice;
        }


        public int UpdateBackOffice(VMBackOffice objVMBackOffice, int UpdatedBy)
        {
            int success = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_UpdatePortalBackOffice", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@GlobalRFIDTagID", objVMBackOffice.GlobalRFIDTagId);
                    objCommand.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                    objCommand.Parameters.AddWithValue("@ActivatedDate", objVMBackOffice.ActivatedDate);
                    objCommand.Parameters.AddWithValue("@PosteDate", objVMBackOffice.PostedDate);
                    objCommand.Parameters.AddWithValue("@PermitStateID", objVMBackOffice.PermitStateID);
                    objCommand.Parameters.AddWithValue("@BackOfficeID", objVMBackOffice.BackOfficeID);
                    objCommand.Parameters.AddWithValue("@EWAYAmount", objVMBackOffice.EWAYAmount);
                    objCommand.Parameters.AddWithValue("@AuthKey", objVMBackOffice.AuthKey);
                    success = Convert.ToInt16(objCommand.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return success;
        }

        public int UpdateBackOfficeandSubscriberCarparkandBaytype(VMBackOffice objVMBackOffice, int UpdatedBy,
            string carparkids, string carparkBayIDS)
        {
            int success = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_UpdatePortalBackOfficeCarparkandCarparkBaytypeID", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@GlobalRFIDTagID", objVMBackOffice.GlobalRFIDTagId);
                    objCommand.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                    objCommand.Parameters.AddWithValue("@ActivatedDate", objVMBackOffice.ActivatedDate);
                    objCommand.Parameters.AddWithValue("@PosteDate", objVMBackOffice.PostedDate);
                    objCommand.Parameters.AddWithValue("@PermitStateID", objVMBackOffice.PermitStateID);
                    objCommand.Parameters.AddWithValue("@BackOfficeID", objVMBackOffice.BackOfficeID);
                    objCommand.Parameters.AddWithValue("@EWAYAmount", objVMBackOffice.EWAYAmount);
                    objCommand.Parameters.AddWithValue("@CarparkID", carparkids);
                    objCommand.Parameters.AddWithValue("@CarparkBaytype", carparkBayIDS);
                    success = Convert.ToInt16(objCommand.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return success;
        }


        public List<VMBackOffice> GetBackOfficeRenewalDetail(string page, string sortdir, string sortColumn, int ServiceProvider, VMBackOffice objVMBackOffice)
        {
            List<VMBackOffice> ListBackOffice = new List<VMBackOffice>();
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "RFIDNumber_ASC";

            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetBackOfficeRenewalDetail", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PageNbr", iCurrentPage);
                    objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                    objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProvider);
                    objCommand.Parameters.AddWithValue("@RFIDNumber", objVMBackOffice.RFIDNumber_Search == null ? "" : objVMBackOffice.RFIDNumber_Search);
                    objCommand.Parameters.AddWithValue("@FirstName", objVMBackOffice.FirstName == null ? "" : objVMBackOffice.FirstName);
                    objCommand.Parameters.AddWithValue("@LastName", objVMBackOffice.LastName == null ? "" : objVMBackOffice.LastName);

                    objReader = objCommand.ExecuteReader();
                    using (objReader)
                    {
                        while (objReader.Read())
                        {
                            VMBackOffice modelBackOffice = new VMBackOffice();
                            modelBackOffice.BackOfficeID = Convert.ToInt32(objReader["BackOfficeID"]);
                            modelBackOffice.RFIDNumber = objReader["RFIDNumber"].ToString();
                            modelBackOffice.Subscriber = objReader["Subscriber"].ToString();
                            modelBackOffice.InitiatedDate = Convert.ToDateTime(objReader["InitiatedDate"]);
                            if (objReader.IsDBNull(5))
                            {
                                modelBackOffice.ActivatedDate = null;
                            }
                            else
                            {
                                modelBackOffice.ActivatedDate = Convert.ToDateTime(objReader["ActivatedDate"]);
                            }

                            if (objReader.IsDBNull(6))
                            {
                                modelBackOffice.PostedDate = null;
                            }
                            else
                            {
                                modelBackOffice.PostedDate = Convert.ToDateTime(objReader["PosteDate"]);
                            }

                            modelBackOffice.PermitState = objReader["PermitState"].ToString();
                            modelBackOffice.TotalCount = Convert.ToInt32(objReader["TotalCount"]);
                            ListBackOffice.Add(modelBackOffice);
                        }
                        return ListBackOffice;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return ListBackOffice;
        }

        public int ValidateRFIDNumber(string RFIDNumber)
        {
            int RFIDTagID = -1;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_validateRFIDNumber", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@RFIDNumber", RFIDNumber);

                    objReader = objCommand.ExecuteReader();
                    using (objReader)
                    {
                        while (objReader.Read())
                        {
                            RFIDTagID = Convert.ToInt32(objReader["GlobalRFIDTagID"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return RFIDTagID;
        }


        public int InsertPermitRenewal(VMBackOffice objVMBackOffice, int CreatedBy, int ServiceProviderId, bool isbalanceupdate)
        {
            int success = 0;
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_InsertPermitRenewalEntry", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PrevBackOfficeID", objVMBackOffice.BackOfficeID);
                    objCommand.Parameters.AddWithValue("@GlobalRFIDTagID", objVMBackOffice.GlobalRFIDTagId);
                    objCommand.Parameters.AddWithValue("@SubscriberID", objVMBackOffice.SubscriberId);
                    objCommand.Parameters.AddWithValue("@InitiatedDate", objVMBackOffice.InitiatedDate);
                    objCommand.Parameters.AddWithValue("@PermitStateID", objVMBackOffice.PermitStateID);
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderId);
                    objCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    objCommand.Parameters.AddWithValue("@Isbalanceupdate", isbalanceupdate);
                    success = Convert.ToInt32(objCommand.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return success;
        }


        public string GetReqDocumentListInBackOffice(string CarParkId, string ParkTypeId, int ServiceProviderId)
        {
            string docList = "";
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetReqDocumentListInBackOffice", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    //objCommand.Parameters.AddWithValue("@CarParkID", CarParkId);
                    objCommand.Parameters.AddWithValue("@CarParkBayTypeID", ParkTypeId);
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderId);

                    objReader = objCommand.ExecuteReader();
                    using (objReader)
                    {
                        docList = "";
                        while (objReader.Read())
                        {
                            docList += objReader["Label"].ToString() + " as " + objReader["Format"].ToString() + "\n";
                        }
                        if (docList.Length > 0)
                            docList = docList.Remove(docList.Length - 1, 1);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return docList;
        }

        public List<VMPaymentFailureLogs> GetPaymentFailuerLogs(string page, string sortdir, string sortColumn, int ServiceProviderId, VMPaymentFailureLogs objVMPaymentFailureLogs)
        {

            List<VMPaymentFailureLogs> objVMPaymentFailuerLogsList = new List<VMPaymentFailureLogs>();
            int iCurrentPage = !string.IsNullOrEmpty(page) ? Convert.ToInt32(page) : 1;
            string strSortCol = !string.IsNullOrEmpty(sortColumn) ? sortColumn + "_" + sortdir : "CreatedOn_DESC";
            try
            {
                using (objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();
                    objCommand = new SqlCommand("usp_GetPaymentFailuerLogsByServiceproviderId", objConnection);
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    //objCommand.Parameters.AddWithValue("@CarParkID", CarParkId);
                    objCommand.Parameters.AddWithValue("@ServiceProviderID", ServiceProviderId);
                    objCommand.Parameters.AddWithValue("@PageNbr", iCurrentPage);
                    objCommand.Parameters.AddWithValue("@PageSize", PageSearchSortModel.PageSize);
                    objCommand.Parameters.AddWithValue("@SortCol", strSortCol);
                    objCommand.Parameters.AddWithValue("@FirstName", objVMPaymentFailureLogs.FirstName == null ? string.Empty : objVMPaymentFailureLogs.FirstName);
                    objCommand.Parameters.AddWithValue("@LastName", objVMPaymentFailureLogs.LastName == null ? string.Empty : objVMPaymentFailureLogs.LastName);
                   

                    objReader = objCommand.ExecuteReader();
                   
                    using (objReader)
                    {
                       
                        while (objReader.Read())
                        {
                            VMPaymentFailureLogs ObjVMPaymentFailureLogs = new VMPaymentFailureLogs();

                            ObjVMPaymentFailureLogs.FirstName = objReader["FirstName"].ToString();
                            ObjVMPaymentFailureLogs.LastName = objReader["LastName"].ToString();
                            ObjVMPaymentFailureLogs.CreatedOn = DateTime.Parse(objReader["CreatedOn"].ToString());
                            ObjVMPaymentFailureLogs.TotalCount = int.Parse(objReader["TotalCount"].ToString());
                            ObjVMPaymentFailureLogs.ErrorMessage = objReader["ErrorMessage"].ToString();
                            objVMPaymentFailuerLogsList.Add(ObjVMPaymentFailureLogs);

                            

                          
                        }
                       
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
          
            return objVMPaymentFailuerLogsList;
           
        }
    }
}
