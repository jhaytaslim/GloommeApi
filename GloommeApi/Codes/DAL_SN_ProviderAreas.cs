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

    public class DAL_SN_ProviderAreas
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        public DAL_SN_ProviderAreas()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }
        public DataSet SN_ProviderAreas_Delete(int ProviderAreaID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderAreaID", ProviderAreaID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Delete_ProviderAreas", @params); 
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
        public DataSet SN_ProviderAreas_FetchByProviderIDAndCategoryID(int CategoryID, int ProviderID)
        {
            try
            {
                SqlParameter[] @params = {
                new SqlParameter("@ProviderID", ProviderID),
                new SqlParameter("@CategoryID", CategoryID)
            };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_ProviderAreas_FetchByProviderIDAndCategoryID", @params);
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
        public DataSet SN_ProviderAreas_FetchByProviderID(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_ProviderAreas_FetchByProviderID", @params);
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
        public DataSet SN_ProviderAreas_Fetch(int ProviderAreaID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderAreaID", ProviderAreaID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_ProviderAreas_Fetch", @params);
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

        public DataSet SN_ProviderAreas_Insert(SN_ProviderAreasInfo _SN_ProviderAreasInfo)
        {
            try
            {
                var _with1 = _SN_ProviderAreasInfo;
                SqlParameter[] @params = {
                new SqlParameter("@ProviderID", _with1.ProviderID),
                new SqlParameter("@CategoryID", _with1.CategoryID),
                new SqlParameter("@AreaID", _with1.AreaID)
            };

                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_ProviderAreas_Insert", @params); ;
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

        public bool SN_ProviderAreas_Update(SN_ProviderAreasInfo _SN_ProviderAreasInfo)
        {
            try
            {
                var _with2 = _SN_ProviderAreasInfo;
                SqlParameter[] @params = {
                new SqlParameter("@ProviderAreaID", _with2.ProviderAreaID),
                new SqlParameter("@CategoryID", _with2.CategoryID),
                new SqlParameter("@AreaID", _with2.AreaID)
            };

                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_ProviderAreas_Update", @params);
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

        public IEnumerable<SN_vw_ProviderAreas> FetchProviderAreas_Only(int providerID)
        {
            IEnumerable<SN_vw_ProviderAreas> results = new List<SN_vw_ProviderAreas>();
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    results = context.SN_vw_ProviderAreas.Where(p=>p.ProviderID==providerID)
                          .ToList();
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
            }
            return results;
        }

        public IEnumerable<SN_vw_ProviderAreas> FetchProviderAreasByCategory(int providerID, int categoryID)
        {
            IEnumerable<SN_vw_ProviderAreas> results = new List<SN_vw_ProviderAreas>();
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    results = context.SN_vw_ProviderAreas.Where(p => p.ProviderID == providerID && p.CategoryID == categoryID)
                          .ToList();
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
            }
            return results;
        }

    }
    public class DAL_Area
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        public DAL_Area()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }
        public bool SN_Areas_Delete(int AreaID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@AreaID", AreaID) };
                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Areas_Delete", @params);
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

        public DataSet SN_Areas_FetchByCategoryID(int CategoryID, int AreaID)
        {
            try
            {
                SqlParameter[] @params = {
                new SqlParameter("@AreaID", AreaID),
                new SqlParameter("@CategoryID", CategoryID)
            };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Areas_FetchByCategoryID", @params);
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
        public DataSet SN_Areas_Fetch(int AreaID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@AreaID", AreaID) };

                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Areas_Fetch", @params);
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
        public DataSet SN_Areas_FetchByName(string AreaName)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@AreaName", AreaName) };

                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Areas_FetchByName", @params);
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
        //public bool SN_Areas_Insert(SN_AreasInfo _SN_AreasInfo)
        //{
        //    try
        //    {
        //        var _with1 = _SN_AreasInfo;
        //        SqlParameter[] @params = {
        //        new SqlParameter("@AreaName", _with1.AreaName),
        //        new SqlParameter("@CategoryID", _with1.CategoryID),
        //        new SqlParameter("@AreaImageURL", _with1.AreaImageURL),
        //        new SqlParameter("@CreatedBy", _with1.CreatedBy)
        //    };

        //        SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Areas_Insert", @params);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        APP_BLL.WriteLog(ex.Message + " : " + ex.StackTrace);
        //        return false;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //}

        //public bool SN_Areas_Update(SN_AreasInfo _SN_AreasInfo)
        //{
        //    try
        //    {
        //        var _with2 = _SN_AreasInfo;
        //        SqlParameter[] @params = {
        //        new SqlParameter("@AreaID", _with2.AreaID),
        //        new SqlParameter("@AreaName", _with2.AreaName),
        //        new SqlParameter("@AreaImageURL", _with2.AreaImageURL),
        //        new SqlParameter("@CategoryID", _with2.CategoryID)
        //    };

        //        SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Areas_Update", @params);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        APP_BLL.WriteLog(ex.Message + " : " + ex.StackTrace);
        //        return false;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //}
    }

}