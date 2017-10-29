using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GloommeApi.Models;
using System.Dynamic;

namespace GloommeApi.Codes
{
    public class DAL_SN_Messages
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        SocialNetworkEntities2 ctx = new SocialNetworkEntities2();

        public DAL_SN_Messages()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }

        //Message procedure for "SN_Messages_Delete" has not been implemented
        public bool SN_Messages_Delete(int MessageID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@MessageID", MessageID) };

                 SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Message_Delete", @params);
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

        public DataSet SN_Messages_Fetch(int MessageID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@MessageID", MessageID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Messages_Fetch", @params);
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
        
        public DataSet SN_Messages_FetchByProviderID(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Messages_FetchByProviderIDMobile", @params);
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

        public DataSet SN_Messages_FetchByCustomerID(int CustomerID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerID", CustomerID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Messages_FetchByCustomerIDMobile", @params);
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

        public bool SN_Messages_Insert(SN_MessagesInfo _SN_Message)
        {
            try
            {
                //var _with1 = _SN_Message;
                SqlParameter[] @params = {
                new SqlParameter("@CustomerID", _SN_Message.CustomerID),
                new SqlParameter("@ProviderID", _SN_Message.ProviderID),
                new SqlParameter("@JobID", _SN_Message.JobID),
                new SqlParameter("@SourceID", _SN_Message.SourceID),
                new SqlParameter("@IsReade", _SN_Message.IsReade),
                new SqlParameter("@Message", _SN_Message.Message)
            };


                SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Messages_Insert", @params);
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

        public bool SN_Messages_Update(SN_Messages _SN_Message) 
        {
            try
            {
                SqlParameter[] @params = {
                    new SqlParameter("@MessageID", _SN_Message.MessageID),
                    new SqlParameter("@CustomerID", _SN_Message.CustomerID),
                    new SqlParameter("@ProviderID", _SN_Message.ProviderID),
                    new SqlParameter("@JobID", _SN_Message.JobID),
                    new SqlParameter("@SourceID", _SN_Message.SourceID),
                    new SqlParameter("@IsReade", _SN_Message.IsReade),
                    new SqlParameter("@DateCreated", _SN_Message.DateCreated),
                    new SqlParameter("@Message", _SN_Message.Message)
            };



                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Messages_Update", @params);
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

        public dynamic FetchCustomerMessages(int CustomerID)
        {
            List<dynamic> result = new List<dynamic>();
            try
            {

                using (var context = new SocialNetworkEntities2())
                {
                    //result = context.SN_ProviderPackages_FetchByProviderID(providerid)
                    ////      .ToList();
                    //var providers = context.SN_vw_Messages.Where(p => p.CustomerID == CustomerID)
                    //   .Select(m => new { m.ProviderID, m.ProviderName }).GroupBy(p => p.ProviderID).SelectMany(res=>res).ToList();
                    var providers = context.SN_vw_Messages.Where(p => p.CustomerID == CustomerID)
                       .Select(m => new { m.ProviderID, m.ProviderName }).Distinct().ToList();
                    APP_BLL.WriteLog(providers.Count().ToString());
                    foreach (var item in providers)
                    {
                        var mj = context.SN_vw_Messages.Where(j => j.CustomerID == CustomerID && j.ProviderID == item.ProviderID)
                            .Select(j=> new { j.JobID, j.Comment }).Distinct().ToList();
                        List<dynamic> list = new List<dynamic>();
                        foreach (var j in mj)
                        {
                            var msg = context.SN_vw_Messages.Where(p => p.JobID == j.JobID);
                            var Job = new {
                                JobID = j.JobID,
                                Comment = j.Comment,
                                Messages = msg.ToList()
                            };
                            list.Add(Job);
                            //val.Jobs.Add(Job);
                        }
                        dynamic val = new {
                        ProviderID = item.ProviderID,
                        ProviderName = item.ProviderName,
                        Jobs = list
                        };
                        result.Add(val);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + " : " + ex.StackTrace);
                return new { msg = "an error occurred" };
                //return false;
            }
        }
        

    }
}