using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GloommeApi.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using GloommeApi.Models;
namespace GloommeApi.Codes
{
    public class DAL_SN_Payment
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        SocialNetworkEntities2 ctx = new SocialNetworkEntities2();

        public DAL_SN_Payment()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }

        public DataSet SN_Payments_Fetch(int PaymentID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@PaymentID", PaymentID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Payments_Fetch", @params);
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

        public DataSet SN_Payments_FetchByJobID(int JobID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@JobID", JobID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Payments_FetchByJobID", @params);
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

        public bool SN_Payments_Insert(SN_Payment_InsertInfo _SN_Payments)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerID", _SN_Payments.CustomerID),
                                            new SqlParameter("@InvoiceID", _SN_Payments.InvoiceID),
                                            new SqlParameter("@JobID", _SN_Payments.JobID),
                                            new SqlParameter("@PaymentDescription", _SN_Payments.PaymentDescription),
                                            new SqlParameter("@Amount", _SN_Payments.Amount)};
                 SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Payments_Insert", @params);
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