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
    public class DAL_SN_Customers
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        public DAL_SN_Customers()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }
        public bool SN_Customers_Delete(int CustomerID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerID", CustomerID) };
                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Customers_Delete", @params);
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
        public DataSet SN_Customers_FetchEmail(int CustomerID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerID", CustomerID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Customers_Fetch", @params);
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
        public DataSet SN_Customers_Fetch(int CustomerID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerID", CustomerID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Customers_Fetch", @params);
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
        public bool SN_Customers_SetStatus(int CustomerID, bool Status)
        {
            try
            {
                SqlParameter[] @params = {
                new SqlParameter("@CustomerID", CustomerID),
                new SqlParameter("@Status", Status)
            };
                int i = SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Customer_SetStatus", @params);
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
        public DataSet SN_Customers_Login(string Username, string Pwd)
        {
            try
            {
                SqlParameter[] @params = {
                new SqlParameter("@Username", Username),
                new SqlParameter("@Password", Pwd)
            };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Customers_Login", @params);
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
        public DataSet SN_Customers_Insert(SN_CustomersInfo _SN_CustomersInfo)
        {
            try
            {
                var _with1 = _SN_CustomersInfo;
                SqlParameter[] @params = {
                new SqlParameter("@Firstname", _with1.Firstname),
                new SqlParameter("@Lastname", _with1.Lastname),
                new SqlParameter("@Midllename", _with1.Midllename),
                new SqlParameter("@DateOfBirth", _with1.DateOfBirth),
                new SqlParameter("@Gender", _with1.Gender),
                new SqlParameter("@EmailAddress", _with1.EmailAddress),
                new SqlParameter("@PhoneNo", _with1.PhoneNo),
                new SqlParameter("@CustomerAddress", _with1.CustomerAddress),
                new SqlParameter("@City", _with1.City),
                new SqlParameter("@State", _with1.State),
                new SqlParameter("@CountryID", _with1.CountryID),
                new SqlParameter("@CustomerPassword", _with1.CustomerPassword),
                new SqlParameter("@IPAddress", "0"),
                new SqlParameter("@Longitude", "0"),
                new SqlParameter("@Latitude", "0"),
                new SqlParameter("@LastLoginDate", DateTime.Now),
                new SqlParameter("@CustomerActive", true)
            };

                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Customers_Insert", @params);

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
        public DataSet SN_Customers_Insert(Customer _SN_CustomersInfo)
        {
            try
            {
                var _with1 = _SN_CustomersInfo;
                SqlParameter[] @params = {
                new SqlParameter("@Firstname", _with1.Firstname),
                new SqlParameter("@Lastname", _with1.Lastname),
                new SqlParameter("@Midllename", _with1.Middlename),
                new SqlParameter("@DateOfBirth", _with1.DateOfBirth),
                new SqlParameter("@Gender", _with1.Gender),
                new SqlParameter("@EmailAddress", _with1.Email),
                new SqlParameter("@PhoneNo", _with1.PhoneNo),
                new SqlParameter("@CustomerAddress", _with1.CustomerAddress),
                new SqlParameter("@City", _with1.City),
                new SqlParameter("@State", _with1.State),
                new SqlParameter("@CustomerPassword", _with1.Password),
                new SqlParameter("@IPAddress", "0"),
                new SqlParameter("@Longitude", "0"),
                new SqlParameter("@Latitude", "0"),
                new SqlParameter("@CountryID", _with1.CountryID),
                new SqlParameter("@LastLoginDate", DateTime.Now),
                new SqlParameter("@CustomerActive",true)
            };

                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Customers_Insert", @params);

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

        public bool SN_Customers_Update(SN_CustomersInfo _SN_CustomersInfo)
        {
            try
            {
                var _with2 = _SN_CustomersInfo;
                SqlParameter[] @params = {
                new SqlParameter("@CustomerID", _with2.CustomerID),
                new SqlParameter("@Firstname", _with2.Firstname),
                new SqlParameter("@Lastname", _with2.Lastname),
                new SqlParameter("@Midllename", _with2.Midllename),
                new SqlParameter("@DateOfBirth", _with2.DateOfBirth),
                new SqlParameter("@Gender", _with2.Gender),
                new SqlParameter("@EmailAddress", _with2.EmailAddress),
                new SqlParameter("@PhoneNo", _with2.PhoneNo),
                new SqlParameter("@CustomerAddress", _with2.CustomerAddress),
                new SqlParameter("@City", _with2.City),
                new SqlParameter("@State", _with2.State),
                new SqlParameter("@CountryID", _with2.CountryID),
                new SqlParameter("@CustomerPassword", _with2.CustomerPassword),
                new SqlParameter("@IPAddress", _with2.IPAddress),
                new SqlParameter("@Longitude", _with2.Longitude),
                new SqlParameter("@Latitude", _with2.Latitude),
                new SqlParameter("@LastLoginDate", _with2.LastLoginDate),
                new SqlParameter("@CustomerActive", _with2.CustomerActive)
            };

                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Customers_Update", @params);
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
        public DataSet SN_CustomerWallet_FetchByCustomerID(int CustomerID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerID", CustomerID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_CustomerWallet_FetchByCustomerID", @params);
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
        public DataSet SN_CustomerWallet_FetchSummary(int CustomerID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerID", CustomerID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_CustomerWallet_FetchSummary", @params);
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