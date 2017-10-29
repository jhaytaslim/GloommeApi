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
    [RoutePrefix("api/Gigs")]
    public class CustomerJobController : ApiController
    {
        DAL_SN_CustomerJobs DAL = new DAL_SN_CustomerJobs();
        SocialNetworkEntities2 ctx = new SocialNetworkEntities2();

        /// <summary>
        /// Customer endpoint to post new jobs to the system
        /// </summary>
        /// <param name="_SN_CustomerJobs_Insert">The ID of the user.</param>
        /// <returns>A data collection about the user's previous jobs posted.</returns>
        [ResponseType(typeof(SN_CustomerJobs))]
        [HttpPost]
        [Route("PostGig")]
        public IHttpActionResult Post(SN_CustomerJobs_Insert _SN_CustomerJobs_Insert)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ctx.SN_Jobs;
                }
                bool result = DAL.SN_CustomerJobs_Insert(_SN_CustomerJobs_Insert);//.Tables[1];
                Dictionary<string, string> response = new Dictionary<string, string>();
                if (result)
                {
                    DataTable dt = DAL.SN_CustomerJobs_FetchByCustomerID(_SN_CustomerJobs_Insert.CustomerID).Tables[0];
                    return Ok(dt);
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
        /// Get list of Gigs posted by Customer by customerID
        /// </summary>
        /// <param name="CustomerID">The ID of the user.</param>
        /// <returns>A data collection about the customer's previously posted Gigs.</returns>
        [ResponseType(typeof(SN_CustomerJobs))]
        [HttpGet]
        [Route("GetCustomerGigs")]
        public IHttpActionResult GetCustomerGigs(int CustomerID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ctx.SN_Jobs;
                    //}
                    DataTable dt = DAL.SN_CustomerJobs_FetchByCustomerID(CustomerID).Tables[0];
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
        /// Get list of Gigs posted by Customer by customerID
        /// </summary>
        /// <param name="GigID">The ID of the user.</param>
        /// <returns>A data collection about the customer's previously posted Gigs.</returns>
        [ResponseType(typeof(SN_CustomerJobs))]
        [HttpGet]
        [Route("GetActiveGigs")]
        public IHttpActionResult GetActiveGigs(int GigID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ctx.SN_Jobs;
                    //}
                    DataTable dt = DAL.SN_CustomerJobs_FetchActive(GigID).Tables[0];
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
