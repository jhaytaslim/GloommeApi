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

        //Complete a posted job by JobID
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
                    response.Add("Message", "Job Completed");
                    //APP_BLL.WriteLog("Yes AGAIN");
                    return Ok(response);
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
                        response.Add("Message", "Job successfully rejected");
                        //APP_BLL.WriteLog("Yes AGAIN");
                        return Ok(response);
                    }
                    return Ok("Retry,an internal error occurred...");
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
                        response.Add("Message", "Job successfully completed");
                        //APP_BLL.WriteLog("Yes AGAIN");
                        return Ok(response);
                    }
                    return Ok("Retry,an internal error occurred...");
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


    }
}
