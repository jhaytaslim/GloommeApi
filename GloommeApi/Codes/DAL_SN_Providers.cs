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
    public class DAL_SN_Providers
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        public DAL_SN_Providers()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }
        public bool SN_Providers_Delete(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Providers_Delete", @params);
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
        public bool SN_Providers_UploadPicture(int ProviderID, string ProfilePictureURL)
        {
            try
            {
                SqlParameter[] @params = {
                new SqlParameter("@ProviderID", ProviderID),
                new SqlParameter("@ProfilePictureURL", ProfilePictureURL)
            };
                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Providers_UploadPicture", @params);
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
        public DataSet SN_Providers_Fetch(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Providers_Fetch", @params);
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
        public DataSet SN_Providers_FetchEmail(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Providers_Fetch", @params);
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
        public bool SN_Providers_SetStatus(int ProviderID, bool Status)
        {
            try
            {
                SqlParameter[] @params = {
                new SqlParameter("@ProviderID", ProviderID),
                new SqlParameter("@Status", Status)
            };

                int i = SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Provider_SetStatus", @params);
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
        public DataSet SN_Providers_FetchByArea(int AreaID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@AreaID", AreaID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Providers_FetchByArea", @params);
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
        public DataSet SN_Providers_FetchByCategory(int CategoryID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CategoryID", CategoryID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Providers_FetchByCategory", @params);
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
        public DataSet SN_Providers_FetchSearch(string SearchWord)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@SearchWord", SearchWord) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Providers_Search", @params);
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

        public DataSet SN_Providers_FetchProfile(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Providers_FetchProfile", @params);
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
        public DataSet SN_Providers_Login(string Username, string Pwd)
        {
            try
            {
                SqlParameter[] @params = {
                new SqlParameter("@Username", Username),
                new SqlParameter("@Password", Pwd)
            };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Providers_Login", @params);
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
        public DataSet SN_Providers_Insert(ProviderVM _SN_ProvidersInfo)
        {
            try
            {
                var _with1 = _SN_ProvidersInfo;
                SqlParameter[] @params = {
                new SqlParameter("@AccountTypeID", _with1.AccountTypeID),
                new SqlParameter("@Firstname", _with1.Firstname),
                new SqlParameter("@Lastname", _with1.Lastname),
                new SqlParameter("@MiddleName", _with1.MiddleName),
                new SqlParameter("@CompanyName", _with1.CompanyName),
                new SqlParameter("@CategoryID", _with1.CategoryID),
                new SqlParameter("@ProviderTypeID", _with1.ProviderTypeID),
                new SqlParameter("@ProviderAddress", _with1.ProviderAddress),
                new SqlParameter("@City", _with1.City),
                new SqlParameter("@State", _with1.State),
                new SqlParameter("@CountryID", _with1.CountryID),
                new SqlParameter("@EmailAddress", _with1.EmailAddress),
                new SqlParameter("@ProviderPassword", _with1.ProviderPassword),
                new SqlParameter("@DateOfBirth", _with1.DateOfBirth),
                new SqlParameter("@IPAddress", 0),
                new SqlParameter("@Longitude", 0),
                new SqlParameter("@Latitude", 0)
            };

                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Providers_Insert", @params);

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

        public bool SN_Providers_Update(ProviderVM _SN_ProvidersInfo)
        {
            try
            {
                var _with2 = _SN_ProvidersInfo;
                SqlParameter[] @params = {
                new SqlParameter("@ProviderID", _with2.ProviderID),
                new SqlParameter("@ProviderTypeID", _with2.ProviderTypeID),
                new SqlParameter("@AccountTypeID", _with2.AccountTypeID),
                new SqlParameter("@Firstname", _with2.Firstname),
                new SqlParameter("@Lastname", _with2.Lastname),
                new SqlParameter("@MiddleName", _with2.MiddleName),
                new SqlParameter("@CompanyName", _with2.CompanyName),
                new SqlParameter("@ProviderAddress", _with2.ProviderAddress),
                new SqlParameter("@City", _with2.City),
                new SqlParameter("@State", _with2.State),
                new SqlParameter("@CountryID", _with2.CountryID),
                new SqlParameter("@EmailAddress", _with2.EmailAddress),
                new SqlParameter("@ProviderPassword", _with2.ProviderPassword),
                new SqlParameter("@DateOfBirth", _with2.DateOfBirth),
                new SqlParameter("@IPAddress", _with2.IPAddress),
                new SqlParameter("@Longitude", _with2.Longitude),
                new SqlParameter("@Latitude", _with2.Latitude)
            };

                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Providers_Update", @params);
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
        public DataSet SN_ProviderReceipt_FetchByProviderID(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_ProviderReceipt_FetchSummary", @params);
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
        public DataSet SN_ProviderReceipt_FetchSummary(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_ProviderReceipt_FetchSummary", @params);
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