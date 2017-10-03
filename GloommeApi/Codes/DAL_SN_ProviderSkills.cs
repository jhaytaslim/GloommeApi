using GloommeApi.Models;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GloommeApi.Codes
{
    public class DAL_SN_ProviderSkills
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        public DAL_SN_ProviderSkills()
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

        public IEnumerable<SN_vw_Skills> SkillsByProvider(int providerid)
        {
            IEnumerable<SN_vw_Skills> results = new List<SN_vw_Skills>();
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    results = context.SN_Skills_FetchByProvider(providerid)
                          .ToList();
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
            }
            return results;
        }

        public dynamic CreateSkills(SN_Skills Skills)
        {
            var result = new SN_Skills();
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    var sk = context.SN_Skills.SingleOrDefault(p => p.ProviderID == Skills.ProviderID && p.SkillName == Skills.SkillName);
                    if (sk!=null)
                    {
                        return new { status = "failed", Message = "Skills Already Exist" };
                    }
                    else
                    {
                        result = context.SN_Skills.Add(Skills);
                        context.SaveChanges();
                        APP_BLL.WriteLog(Skills.ProviderID.ToString());
                        return new { status = "success", Skills= SkillsByProvider((int)Skills.ProviderID) };
                    }
                    
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return ex;
            }
        }

        public Object DeleteSkill(int SkillID)
        {
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    var skill = context.SN_Skills.Find(SkillID);
                    if (skill!=null)
                    {
                        context.SN_Skills.Remove(skill);
                        context.SaveChanges();
                        return new { status = "success", Skills = SkillsByProvider((int)skill.ProviderID) };
                    }
                    else
                    {
                        return new { status = "failed", Message = "Some went went wrong" };
                    }

                }


            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return ex;
            }
        }
    }
}