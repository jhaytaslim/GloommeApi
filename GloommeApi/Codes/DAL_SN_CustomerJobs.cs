using GloommeApi.Models;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GloommeApi.Codes
{
    public class DAL_SN_CustomerJobs
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        SocialNetworkEntities2 ctx = new SocialNetworkEntities2();

        public DAL_SN_CustomerJobs()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }

        /// <summary>
        /// The actual method for customer to post jobs. not yet completed
        /// </summary>
        /// <param name="_SN_CustomerJobs"></param>
        /// <returns></returns>
        public bool SN_CustomerJobs_Insert(SN_CustomerJobs_Insert _SN_CustomerJobs)
        {
            try
            {
                var _with1 = _SN_CustomerJobs;
                SqlParameter[] @params = {
                new SqlParameter("@CustomerID", _SN_CustomerJobs.CustomerID),
                new SqlParameter("@PostMessage", _SN_CustomerJobs.PostMessage),
                new SqlParameter("@TimeLineInHours", _SN_CustomerJobs.TimeLineInHours),
                new SqlParameter("@FeeFrom", _SN_CustomerJobs.FeeFrom),
                new SqlParameter("@FeeTo", _SN_CustomerJobs.FeeTo),
                new SqlParameter("@IsActive", _SN_CustomerJobs.IsActive),
            };


                SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_CustomerJobs_Insert", @params);
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

        public DataSet SN_CustomerJobs_FetchByCustomerID(int CustomerID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerID", CustomerID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_CustomerJobs_FetchByCustomerID", @params);
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

        public DataSet SN_CustomerJobs_FetchActive(int CustomerostID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerPostID", CustomerostID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_CustomerJobs_FetchActive", @params);
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

    }
}