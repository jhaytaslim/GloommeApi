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
    /// This is the  invoicing endpoints
    /// </summary>
    [RoutePrefix("api/Invoice")]
    public class InvoiceController : ApiController
    {
        DAL_SN_Invoices DAL = new DAL_SN_Invoices();
        SocialNetworkEntities2 ctx = new SocialNetworkEntities2();

        /// <summary>
        /// Get all invoices for a customer by its ID
        /// </summary>
        /// <param name="CustomerID">The ID of the user.</param>
        /// <returns>A data collection about the user's invoices.</returns>
        [ResponseType(typeof(SN_Invoices))]
        [HttpGet]
        [Route("CustomerInvoices")]
        public IHttpActionResult CustomerInvoices(int CustomerID )
        {
            try
            {
               
                DataSet ds = DAL.SN_Invoices_FetchByCustomerID(CustomerID);//.Tables[1];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].TableName = "CustomerInvoices";
                    //ds.Tables[1].TableName = "prevJobs";

                    //APP_BLL.WriteLog("Yes AGAIN");
                    return Ok(ds.Tables[0]);
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
        /// Get all invoices. For admin usage only.
        /// </summary>
        /// <param name="InvoiceID">The ID of the user.</param>
        /// <returns>A data collection of all user's invoices.</returns>
        [ResponseType(typeof(SN_Invoices))]
        [HttpGet]
        [Route("Invoices")]
        public IHttpActionResult Invoices(int InvoiceID)
        {
            try
            {

                DataSet ds = DAL.SN_Invoices_Fetch(InvoiceID);//.Tables[1];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].TableName = "AllInvoices";
                    //ds.Tables[1].TableName = "prevJobs";

                    //APP_BLL.WriteLog("Yes AGAIN");
                    return Ok(ds.Tables[0]);
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

    }
}
