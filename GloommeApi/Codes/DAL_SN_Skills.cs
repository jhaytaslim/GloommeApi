using GloommeApi.Codes;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    public class DAL_SN_Skills
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        public DAL_SN_Skills()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }
        public DataSet SN_Skills_Delete(int SkillID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@SkillID", SkillID) };
                
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Skills_Delete", @params); 
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

        public DataSet SN_Skills_Fetch(int SkillID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@SkillID", SkillID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Skills_Fetch", @params);
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
        public DataSet SN_Skills_FetchByProviderID(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Skills_FetchByProvider", @params);
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
        public DataSet SN_Skills_Insert(SN_SkillsInfo _SN_SkillsInfo)
        {
            try
            {
                var _with1 = _SN_SkillsInfo;
                SqlParameter[] @params = {
                new SqlParameter("@ProviderID", _with1.ProviderID),
                new SqlParameter("@AreaID", 1),
                new SqlParameter("@SkillName", _with1.SkillName),
                new SqlParameter("@SkillDescription", _with1.SkillDescription)
            };

                
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Skills_Insert", @params); 
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

        public bool SN_Skills_Update(SN_SkillsInfo _SN_SkillsInfo)
        {
            try
            {
                var _with2 = _SN_SkillsInfo;
                SqlParameter[] @params = {
                new SqlParameter("@SkillID", _with2.SkillID),
                new SqlParameter("@AreaID", 1),
                new SqlParameter("@SkillName", _with2.SkillName),
                new SqlParameter("@SkillDescription", _with2.SkillDescription)
            };

                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Skills_Update", @params);
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