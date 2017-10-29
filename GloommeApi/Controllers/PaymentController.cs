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
    /// <summary>
    /// This is the  payment endpoints
    /// </summary>
    [RoutePrefix("api/Payment")]
    public class PaymentController : ApiController
    {
        DAL_SN_Payment DAL = new DAL_SN_Payment();
        SocialNetworkEntities2 ctx = new SocialNetworkEntities2();

        /// <summary>
        /// Post Customer payment for jobs accepted.
        /// </summary>
        /// <param name="_SN_Payments">Payment object</param>
        /// <returns>current payment by customer</returns>
        [ResponseType(typeof(SN_Payment_InsertInfo))]
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult CustomerPayment(SN_Payment_InsertInfo _SN_Payments)
        {
            try
            {
                if (DAL.SN_Payments_Insert(_SN_Payments))
                {
                    DataSet ds = DAL.SN_Payments_FetchByJobID(_SN_Payments.JobID);//.Tables[1];
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Tables[0].TableName = "Payments";
                        
                        return Ok(ds.Tables[0]);
                    }
                    else
                    {
                        return BadRequest("No rows returned");
                    }
                    
                }
                else
                {
                    return BadRequest("Please try again");
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
