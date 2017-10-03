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
    public class DAL_SN_ProviderCategory
    {
     
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        public DAL_SN_ProviderCategory()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }
        public DataSet SN_ProviderCategory_Delete(int ProviderCategoryID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderCategoryID", ProviderCategoryID) };
                
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Delete_ProviderCategory", @params);
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
        public DataSet SN_ProviderCategory_FetchByProviderID(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_ProviderCategory_FetchByProviderID", @params);
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
        public DataSet SN_ProviderCategory_Fetch(int ProviderCategoryID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderCategoryID", ProviderCategoryID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_ProviderCategory_Fetch", @params);
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

        public DataSet SN_ProviderCategory_Insert(SN_ProviderCategoryVM _SN_ProviderCategoryInfo)
        {
            try
            {
                var _with1 = _SN_ProviderCategoryInfo;
                SqlParameter[] @params = {
                new SqlParameter("@ProviderID", _with1.ProviderID),
                new SqlParameter("@CategoryID", _with1.CategoryID)
            };

                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_ProviderCategory_Insert", @params); ;
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

        public bool SN_ProviderCategory_Update(SN_ProviderCategoryVM _SN_ProviderCategoryInfo)
        {
            try
            {
                var _with2 = _SN_ProviderCategoryInfo;
                SqlParameter[] @params = {
                new SqlParameter("@ProviderCategoryID", _with2.ProviderCategoryID),
                new SqlParameter("@ProviderID", _with2.ProviderID),
                new SqlParameter("@CategoryID", _with2.CategoryID)
            };

                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_ProviderCategory_Update", @params);
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
