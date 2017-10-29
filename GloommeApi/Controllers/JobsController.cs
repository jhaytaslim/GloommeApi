using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GloommeApi.Codes;
using GloommeApi.Models;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Http.Description;

namespace GloommeApi.Controllers
{
    [RoutePrefix("api/Jobs")]
    public class JobsController : ApiController
    {
        //DAL_Area DAL_A = new DAL_Area();
        //DAL_SN_ProviderAreas DAL = new DAL_SN_ProviderAreas();
        //DAL_SN_Bank DAL_M = new DAL_SN_Bank();
        //DAL_SN_Categories DSC = new DAL_SN_Categories();
        DAL_SN_Jobs DAL = new DAL_SN_Jobs();
        SocialNetworkEntities2 ctx = new SocialNetworkEntities2();

        /// <summary>
        /// Customer endpoint to post new jobs
        /// </summary>
        /// <param name="_SN_JobsInfo">The ID of the user.</param>
        /// <returns>A data collection about the user's previous jobs.</returns>
        [ResponseType(typeof(SN_Jobs))]
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(SN_JobsInfo _SN_JobsInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ctx.SN_Jobs;
                }
                DataSet ds = DAL.SN_Jobs_Insert(_SN_JobsInfo);//.Tables[1];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].TableName = "reply";
                    ds.Tables[1].TableName = "prevJobs";
                    
                    APP_BLL.WriteLog("Yes AGAIN");
                    return Ok(ds);
                }
                else
                {
                    return BadRequest("No rows returned");
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError();
            }
        }

        /// <summary>
        /// The actual method for customer to post jobs. not yet completed
        /// </summary>
        /// <param name="_SN_CustomerJobs"></param>
        /// <returns></returns>
        //[ResponseType(typeof(SN_CustomerJobs))]
        //[HttpPost]
        //[Route("Post")]
        //public IHttpActionResult CustomerPost(SN_CustomerJobs _SN_CustomerJobs)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            //ctx.SN_Jobs;
        //        }
        //        DataSet ds = DAL.SN_CustomerJobs_Insert(_SN_CustomerJobs);//.Tables[1];
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            ds.Tables[0].TableName = "reply";
        //            ds.Tables[1].TableName = "prevJobs";

        //            APP_BLL.WriteLog("Yes AGAIN");
        //            return Ok(ds);
        //        }
        //        else
        //        {
        //            return BadRequest("No rows returned");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        APP_BLL.WriteLog(ex.Message + ex.StackTrace);
        //        return InternalServerError();
        //    }
        //}

        
        /// <summary>
        /// Endpoint for Provider to notify system of job completion
        /// </summary>
        /// <param name="JobID"></param>
        /// <returns>A collection of jobs done by provider </returns>
        [HttpPost]
        [Route("JobComplete")]
        public IHttpActionResult JobComplete(int JobID)
        {
            try
            {
                bool result = DAL.SN_Jobs_ProviderCompleted(JobID);//.Tables[0];

                Dictionary<string, string> response = new Dictionary<string, string>();
                response.Add("Result", result.ToString());
                if (result)
                {
                    int ProviderID = Convert.ToInt32(DAL.SN_Jobs_Fetch(0).Tables[0].Rows[0]["ProviderID"]);
                    DataTable dt = DAL.SN_Jobs_FetchByType(ProviderID,1).Tables[0];
                    dt.TableName = "JobRequests";
                    //response.Add("Message", "Job Completed");
                    //APP_BLL.WriteLog("Yes AGAIN");
                    return Ok(dt);
                }
                else
                {
                    response.Add("Message", "Unable to complete job");
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Endpoint for Provider to notify system of job rejection
        /// </summary>
        /// <param name="_SN_JobsReject"></param>
        /// <returns>A dictionary object of message and result</returns>
        //[ResponseType(Dictionary < string, string > response)]
        [HttpPost]
        [Route("RejectJob")]
        public IHttpActionResult RejectJob(SN_JobsReject _SN_JobsReject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = DAL.SN_Jobs_Reject(_SN_JobsReject);//.Tables[0];
                    Dictionary<string, string> response = new Dictionary<string, string>();
                    response.Add("Result", result.ToString());
                    if (result)
                    {
                        int ProviderID =Convert.ToInt32( DAL.SN_Jobs_Fetch(_SN_JobsReject.JobID).Tables[0].Rows[0]["ProviderID"]);
                        //get job requests
                        DataTable dt= DAL.SN_Jobs_FetchByType(ProviderID, 1).Tables[0];
                        dt.TableName = "JobRequests";
                        //response.Add("Message", "Job successfully rejected");
                        //APP_BLL.WriteLog("Yes AGAIN");
                        return Ok(dt);
                    }
                    response.Add("Message", "Retry,an internal error occurred...");
                    return Ok(response);
                }
                
                else
                {
                    return BadRequest("No rows returned");
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Endpoint for Customer to retrieve jobs posted
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns>A collection of jobs posted by customer object of message and result</returns>
        [HttpGet]
        [Route("GetCustomerJob")]
        public IHttpActionResult CustomerJob(int CustomerID)
        {
            try
            {
                DataTable dt = DAL.SN_Jobs_FetchByCustomerID(CustomerID).Tables[0];
                return Ok(dt);
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Endpoint for Provider to retrieve jobs posted
        /// </summary>
        /// <param name="ProviderID"></param>
        /// <returns>A collection of jobs posted by Provider object of message and result</returns>
        [HttpGet]
        [Route("GetProviderJob")]
        public IHttpActionResult ProviderJob(int ProviderID)
        {
            try
            {
                DataTable dt = DAL.SN_Jobs_FetchByProviderID(ProviderID).Tables[0];
                return Ok(dt);
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Endpoint for Customer to acknowledge jobs completion
        /// </summary>
        /// <param name="_SN_JobsCustomerComlpeted"></param>
        /// <returns>A collection of jobs posted by customer on Success.</returns>
        [HttpPost]
        [Route("CustomerCompleted")]
        public IHttpActionResult CustomerCompleted(SN_JobsCustomerComlpeted _SN_JobsCustomerComlpeted)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = DAL.SN_Jobs_CustomerCompleted(_SN_JobsCustomerComlpeted);//.Tables[0];
                    Dictionary<string, string> response = new Dictionary<string, string>();
                    response.Add("Result", result.ToString());
                    if (result)
                    {
                        int CustomerID=Convert.ToInt32(DAL.SN_Jobs_Fetch(_SN_JobsCustomerComlpeted.JobID).Tables[0].Rows[0]["CustomerID"]);
                        DataTable dt = DAL.SN_Jobs_FetchByCustomerID(CustomerID).Tables[0];
                        
                        //APP_BLL.WriteLog("Yes AGAIN");
                        return Ok(dt);
                    }
                    response.Add("Message", "Retry, an internal error occurred...");
                    return Ok(response);
                }

                else
                {
                    return BadRequest("No rows returned");
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return BadRequest(); 
            }
        }

        /// <summary>
        /// Endpoint for Provider to retrieve jobs posted by type. TypeID can be: All[0],Request[1],On-going[2],Completed[3]
        /// </summary>
        /// <param name="ProviderID"></param>
        /// <param name="TypeID"></param>
        /// <returns>A collection of jobs posted to Provider by type chosen </returns>
        [HttpGet]
        [Route("GetProviderJob")]
        public IHttpActionResult ProviderJob(int ProviderID,int TypeID)
        {
            try
            {
                DataTable dt = DAL.SN_Jobs_FetchByType(ProviderID, TypeID).Tables[0];
                return Ok(dt);
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Endpoint for Provider to approve jobs. The system generates an invoice at this point.
        /// </summary>
        /// <param name="_SN_ApproveJob"></param>
        /// <returns>A collection of jobs for current provider </returns>
        [HttpPost]
        [Route("ProviderApproveJob")]
        public IHttpActionResult ProviderAccept(SN_ApproveJob _SN_ApproveJob)
        {
            try
            {
                bool result = DAL.SN_Jobs_Accept(_SN_ApproveJob);//.Tables[0];
                Dictionary<string, string> response = new Dictionary<string, string>();
                response.Add("Result", result.ToString());
                if (result)
                {
                    int ProviderID = Convert.ToInt32(DAL.SN_Jobs_Fetch(_SN_ApproveJob.JobID).Tables[0].Rows[0]["CustomerID"]);
                    //get accepted jobs
                    DataTable dt = DAL.SN_Jobs_FetchByType(ProviderID,2).Tables[0];

                    //APP_BLL.WriteLog("Yes AGAIN");
                    return Ok(dt);
                }
                response.Add("Message", "Retry, an internal error occurred...");
                return Ok(response);
                //return Ok(dt);
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }


    }
}
