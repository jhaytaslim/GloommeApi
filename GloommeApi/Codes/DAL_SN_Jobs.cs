using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GloommeApi.Models;

namespace GloommeApi.Codes
{
    public class DAL_SN_Jobs
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();

        public DAL_SN_Jobs()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }

        //Job procedure for "SN_Jobs_Delete" has not been implemented
        public DataSet SN_Jobs_Delete(int JobID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@JobID", JobID) };

                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Job_Delete", @params);
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + " : " + ex.StackTrace);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        public DataSet SN_Jobs_Fetch(int JobID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@JobID", JobID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Jobs_Fetch", @params);
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + " : " + ex.StackTrace);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        
        public DataSet SN_Jobs_FetchByProviderID(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Jobs_FetchByProviderID", @params);
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + " : " + ex.StackTrace);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        public DataSet SN_Jobs_FetchByCustomerID(int CustomerID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerID", CustomerID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Jobs_FetchByCustomerID", @params);
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + " : " + ex.StackTrace);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        public DataSet SN_Jobs_Insert(SN_JobsInfo _SN_Job)
        {
            try
            {
                var _with1 = _SN_Job;
                SqlParameter[] @params = {
                new SqlParameter("@CustomerID", _SN_Job.CustomerID),
                new SqlParameter("@ProviderID", _SN_Job.ProviderID),
                new SqlParameter("@PackageID", _SN_Job.PackageID),
                new SqlParameter("@Comment", _SN_Job.Comment),
                new SqlParameter("@Amount", _SN_Job.Amount)
            };


                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Jobs_Insert", @params);
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + " : " + ex.StackTrace);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        public bool SN_Jobs_ProviderCompleted(int JobID)
        {
            try
            {
                //var _with1 = _SN_Job;
                SqlParameter[] @params = {
                                            new SqlParameter("@JobID", JobID)
                                        };


                 SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Jobs_ProviderCompleted", @params);
                return true;
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + " : " + ex.StackTrace);
                return false;
            }
            finally
            {
                cn.Close();
            }
        }

        public bool SN_Jobs_Reject(SN_JobsReject _SN_JobsReject)
        {
            try
            {
                SqlParameter[] @params = {
                                            new SqlParameter("@JobID", _SN_JobsReject.JobID),
                                            new SqlParameter("@ProviderComment", _SN_JobsReject.ProviderComment)
                                        };
                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Jobs_Reject", @params);
                return true;
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + " : " + ex.StackTrace);
                return false;
            }
            finally
            {
                cn.Close();
            }
        }



    }
}