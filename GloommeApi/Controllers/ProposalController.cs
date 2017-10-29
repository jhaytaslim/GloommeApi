using GloommeApi.Codes;
using GloommeApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GloommeApi.Controllers
{
    [RoutePrefix("api/Proposal")]
    public class ProposalController : ApiController
    {
        DAL_SN_Proposals DAL = new DAL_SN_Proposals();
        SocialNetworkEntities2 ctx = new SocialNetworkEntities2();

        /// <summary>
        /// Provider's endpoint to post proposal for new jobs
        /// </summary>
        /// <param name="_SN_Proposal_Insert">The ID of the user.</param>
        /// <returns>A data collection about the user's previous proposals.</returns>
        [ResponseType(typeof(SN_Proposals))]
        [HttpPost]
        [Route("ProviderProposal")]
        public IHttpActionResult Post(SN_Proposal_Insert _SN_Proposal_Insert)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ctx.SN_Jobs;
                    //}
                    bool result = DAL.SN_Proposals_Insert(_SN_Proposal_Insert);//.Tables[1];
                    Dictionary<string, string> response = new Dictionary<string, string>();
                    response.Add("response", response.ToString());
                    if (result)
                    {
                        DataTable dtResult = DAL.SN_Proposals_FetchByCustomerPostID(_SN_Proposal_Insert.CustomerPostID).Tables[0];
                        DataTable dt= DAL.SN_Proposals_FetchByProviderID(Convert.ToInt32(dtResult.Rows[0]["ProviderID"])).Tables[0];
                        return Ok(dt);
                    }
                    else
                    {
                        response.Add("message", "No rows returned");
                        return Ok(response);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError();
            }
        }


        /// <summary>
        /// Customer's endpoint to accept proposal for new jobs
        /// </summary>
        /// <param name="ProposalID">The ID of the user.</param>
        /// <returns>A data collection about the customer's previous proposals.</returns>
        [ResponseType(typeof(SN_Proposals))]
        [HttpPost]
        [Route("AcceptProposal")]
        public IHttpActionResult Accept(int ProposalID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ctx.SN_Jobs;
                    //}
                    bool result = DAL.SN_Proposals_Accept(ProposalID);//.Tables[1];
                    Dictionary<string, string> response = new Dictionary<string, string>();
                    response.Add("response", response.ToString());
                    if (result)
                    {
                        DataTable dtResult = DAL.SN_Proposals_Fetch(ProposalID).Tables[0];
                        DataTable dt = DAL.SN_Proposals_FetchByCustomerID(Convert.ToInt32(dtResult.Rows[0]["CustomerID"])).Tables[0];
                        return Ok(dt);
                    }
                    else
                    {
                        response.Add("message", "No rows returned");
                        return Ok(response);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Customer's endpoint to reject proposal for new jobs
        /// </summary>
        /// <param name="ProposalID">The ID of the user.</param>
        /// <returns>A data collection about the customer's previous proposals.</returns>
        [ResponseType(typeof(SN_Proposals))]
        [HttpPost]
        [Route("RejectProposal")]
        public IHttpActionResult Reject(int ProposalID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ctx.SN_Jobs;
                    //}
                    bool result = DAL.SN_Proposal_Reject(ProposalID);//.Tables[1];
                    Dictionary<string, string> response = new Dictionary<string, string>();
                    response.Add("response", response.ToString());
                    if (result)
                    {
                        //DataTable dtResult = DAL.SN_Proposals_Fetch(ProposalID).Tables[0];
                        //DataTable dt = DAL.SN_Proposals_FetchByCustomerID(Convert.ToInt32(dtResult.Rows[0]["CustomerID"])).Tables[0];
                        response.Add("message", "JProposal rejected successfully");
                        return Ok(response);
                    }
                    else
                    {
                        response.Add("message", "No rows returned");
                        return Ok(response);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Gets list of Gigs involving Provider
        /// </summary>
        /// <param name="ProviderID">The ID of the user.</param>
        /// <returns>A data collection about the provider's  sent proposals.</returns>
        [ResponseType(typeof(SN_Proposals))]
        [HttpGet]
        [Route("GetProviderProposal")]
        public IHttpActionResult GetProviderProposal(int ProviderID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataTable  dt = DAL.SN_Proposals_FetchByProviderID(ProviderID).Tables[0];
                    Dictionary<string, string> response = new Dictionary<string, string>();
                    
                    if (dt.Rows.Count>0)
                    {
                        
                        return Ok(dt);
                    }
                    else
                    {
                        response.Add("message", "No rows returned");
                        return Ok(response);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Get list of proposals posted by Customer by customerID
        /// </summary>
        /// <param name="CustomerID">The ID of the user.</param>
        /// <returns>A data collection about the customer's previously received proposals for all Gigs.</returns>
        [ResponseType(typeof(SN_Proposals))]
        [HttpGet]
        [Route("GetCustomerProposal")]
        public IHttpActionResult GetCustomerProposal(int CustomerID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ctx.SN_Jobs;
                    //}
                    DataTable dt = DAL.SN_Proposals_FetchByCustomerID(CustomerID).Tables[0];
                    Dictionary<string, string> response = new Dictionary<string, string>();
                    //response.Add("response", response.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        
                        return Ok(dt);
                    }
                    else
                    {
                        response.Add("message", "No rows returned");
                        return Ok(response);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Get list of proposals posted by Providers for a particular Gig.
        /// </summary>
        /// <param name="CustomerPostID">The ID of the user.</param>
        /// <returns>A data collection about the customer's previously received proposals for a particular Gig Gigs.</returns>
        [ResponseType(typeof(SN_Proposals))]
        [HttpGet]
        [Route("GetGigsProposal")]
        public IHttpActionResult GetGigsProposal(int CustomerPostID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ctx.SN_Jobs;
                    //}
                    DataTable dt = DAL.SN_Proposals_FetchByCustomerPostID(CustomerPostID).Tables[0];
                    Dictionary<string, string> response = new Dictionary<string, string>();
                    //response.Add("response", response.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        return Ok(dt);
                    }
                    else
                    {
                        response.Add("message", "No rows returned");
                        return Ok(response);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError();
            }
        }


    }
}
