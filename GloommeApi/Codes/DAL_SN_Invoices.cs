using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using GloommeApi.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace GloommeApi.Codes
{
    public class DAL_SN_Invoices
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        SocialNetworkEntities2 ctx = new SocialNetworkEntities2();

        public DAL_SN_Invoices()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }
        
        public DataSet SN_Invoices_Fetch(int InvoiceID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@InvoiceID", InvoiceID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Invoices_Fetch", @params);
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

        public DataSet SN_Invoices_FetchByCustomerID(int CustomerID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerID", CustomerID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Invoices_FetchByCustomerID", @params);
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

        public DataSet SN_Invoices_Insert(SN_Invoices _SN_Invoices)
        {
            try
            {
                //var _with1 = _SN_Job;
                SqlParameter[] @params = {
                new SqlParameter("@JobID", _SN_Invoices.JobID),
                new SqlParameter("@Amount", _SN_Invoices.Amount),
                new SqlParameter("@InvoiceNo", _SN_Invoices.InvoiceNo),
                new SqlParameter("@InvoiceDescription", _SN_Invoices.InvoiceDescription)
            };


                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Invoices_Insert", @params);
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