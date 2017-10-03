using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using GloommeApi.Models;

namespace GloommeApi.Codes
{
    public class DAL_SN_Categories
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        public DAL_SN_Categories()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }
        public DataSet SN_Categories_Delete(int CategoryID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CategoryID", CategoryID) };

                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Category_Delete", @params);
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

        public DataSet SN_Categories_Fetch(int CategoryID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CategoryID", CategoryID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Category_Fetch", @params);
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

        //Category procedure for "SN_Categories_FetchByProviderID" has not been implemented
        public DataSet SN_Categories_FetchByProviderID(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Categories_FetchByProvider", @params);
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
        public DataSet SN_Categories_Insert(SN_Category _SN_Category)
        {
            try
            {
                var _with1 = _SN_Category;
                SqlParameter[] @params = {
                new SqlParameter("@CategoryName", _SN_Category.CategoryName),
                new SqlParameter("@DateCreated", _SN_Category.DateCreated),
                new SqlParameter("@CreatedBy", _SN_Category.CreatedBy),
                new SqlParameter("@CategoryImageURL", _SN_Category.CategoryImageURL)
            };


                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Category_Insert", @params);
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

        public bool SN_Categories_Update(SN_Category _SN_Category)
        {
            try
            {
                //var _with2 = _SN_Category;
                SqlParameter[] @params = {
                new SqlParameter("@CategoryID", _SN_Category.CategoryID),
                new SqlParameter("@CategoryName", _SN_Category.CategoryName),
                new SqlParameter("@DateCreated", _SN_Category.DateCreated),
                new SqlParameter("@CreatedBy", _SN_Category.CreatedBy),
                new SqlParameter("@CategoryImageURL", _SN_Category.CategoryImageURL)
            };

                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Category_Update", @params);
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