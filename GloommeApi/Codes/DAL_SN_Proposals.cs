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
    public class DAL_SN_Proposals
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        SocialNetworkEntities2 ctx = new SocialNetworkEntities2();

        public DAL_SN_Proposals()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }

        //Job procedure for "SN_Jobs_Delete" has not been implemented
        public DataSet SN_Proposals_Delete(int ProposalID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProposalID", ProposalID) };

                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Proposals_Delete", @params);
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

        public DataSet SN_Proposals_Fetch(int ProposalID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProposalID", ProposalID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Proposals_Fetch", @params);
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

        public DataSet SN_Proposals_FetchByCustomerID(int CustomerID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerID", CustomerID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Proposals_FetchByCustomerID", @params);
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

        public DataSet SN_Proposals_FetchByProviderID(int ProviderID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@ProviderID", ProviderID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Proposals_FetchByProviderID", @params);
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

        public DataSet SN_Proposals_FetchByCustomerPostID(int CustomerPostID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CustomerPostID", CustomerPostID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Proposals_FetchByCustomerPostID", @params);
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

        public bool SN_Proposals_Insert(SN_Proposal_Insert _SN_Proposal_Insert)
        {
            try
            {
                var _with1 = _SN_Proposal_Insert;
                SqlParameter[] @params = {
                new SqlParameter("@CustomerPostID", _SN_Proposal_Insert.CustomerPostID),
                new SqlParameter("@ProviderID", _SN_Proposal_Insert.ProviderID),
                new SqlParameter("@ProposedAmount", _SN_Proposal_Insert.ProposedAmount),
                new SqlParameter("@ProposedTimeLine", _SN_Proposal_Insert.ProposedTimeLine),
                new SqlParameter("@Remark", _SN_Proposal_Insert.Remark)
            };


                 SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Proposals_Insert", @params);
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

        public bool SN_Proposals_Accept(int ProposalID)
        {
            try
            {
                SqlParameter[] @params = {
                                            new SqlParameter("@ProposalID", ProposalID)
                };


                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Proposal_Accept", @params);
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

        public bool SN_Proposal_Reject(int ProposalID)
        {
            try
            {
                SqlParameter[] @params = {
                                            new SqlParameter("@ProposalID", ProposalID)
                };


                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "SN_Proposal_Reject", @params);
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