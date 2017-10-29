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
    [RoutePrefix("api/Message")]
    public class MessageController : ApiController
    {
        DAL_SN_Messages DAL = new DAL_SN_Messages();
        SocialNetworkEntities2 ctx = new SocialNetworkEntities2();

        /// <summary>
        /// Endpoint to send message.
        /// </summary>
        /// <param name="_SN_MessagesInfo">The ID of the user.</param>
        /// <returns>A response object informing success or failure from system.</returns>
        [ResponseType(typeof(Dictionary<string, string>))]
        [HttpPost]
        [Route("SendMessage")]
        public IHttpActionResult SendMessage(SN_MessagesInfo _SN_MessagesInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = DAL.SN_Messages_Insert(_SN_MessagesInfo);//.Tables[1];
                    Dictionary<string, string> response = new Dictionary<string, string>(2);
                    response.Add("result", result.ToString());
                    if (result)
                    {
                        response.Add("message", "Message Created Successfully");
                        // return Ok(response);
                    }
                    else
                    {
                        response.Add("message", "Message not Created Successfully");

                    }
                    return Ok(response);
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
        /// Get all messages by MessageIDs. For admin usage only.
        /// </summary>
        /// <param name="MessageID">The ID of the user.</param>
        /// <returns>A data collection of all  messages requested.</returns>
        [ResponseType(typeof(SN_Messages))]
        [HttpGet]
        [Route("GetMessage/{MessageID}")]
        public IHttpActionResult GetMessage(int MessageID)
        {
            try
            {

                DataSet ds = DAL.SN_Messages_Fetch(MessageID);//.Tables[1];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].TableName = "AllMessages";

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
        /// Get all messages by ProviderIDs. 
        /// </summary>
        /// <param name="ProviderID">The ID of the user.</param>
        /// <returns>A data collection of all  messages requested by provider.</returns>
        [ResponseType(typeof(SN_Messages))]
        [HttpGet]
        [Route("GetMessage/Provider/{ProviderID}")]
        public IHttpActionResult GetMessageProvider(int ProviderID)
        {
            try
            {
                Dictionary<string,DataSet> ResultDataSet = new Dictionary<string, DataSet>();
                DataSet ds = DAL.SN_Messages_FetchByProviderID(ProviderID);//.Tables[1];
                //if (ds.Tables.Count > 0)
                //{
                //    for (int i = 0; i < ds.Tables.Count; i++)
                //    {
                //        ds.Tables[i].TableName = ds.Tables[i].Rows[0]["CustomerName"].ToString();// +(i+1);
                //    }
                //    //ds.Tables[0].TableName = "AllProviderMessages";

                //    return Ok(ds);
                //}
                if (ds.Tables.Count > 0)
                {
                    int j = 0;
                    foreach (DataTable dt in ds.Tables)
                    {

                        var idColumn = "JobID";
                        var distinctIds = dt.DefaultView
                            .ToTable(true, idColumn)
                            .Rows
                            .Cast<DataRow>()
                            .Select(row => row[idColumn])
                            .ToList();

                        //APP_BLL.WriteLog("dt.Rows.Count :" + dt.Rows.Count);
                        DataSet dsResult = new DataSet();
                        for (int i = 0; i < distinctIds.Count; i++)
                        {
                            int currentID = Convert.ToInt32(distinctIds[i]);
                            DataTable dtNew = new DataTable();
                            dtNew = dt.Clone();

                            dtNew = dt.AsEnumerable()
                                        .Where(r => r.Field<int>("JobID") == currentID)
                                        .CopyToDataTable();
                            // APP_BLL.WriteLog("dtNew.Rows.Count :" + dtNew.Rows.Count);
                            dtNew.TableName = dt.Rows[0]["PostMessage"].ToString() + currentID;
                            dsResult.Tables.Add(dtNew);

                        }
                        j += 1;
                        string dsName = dt.Rows[0]["ProviderName"].ToString()+j;

                        ResultDataSet.Add(dsName,dsResult);
                    }

                    //for (int i = 0; i < ds.Tables.Count; i++)
                    //{
                    //    foreach(DataTable dt in )
                    //    ds.Tables[i].TableName = ds.Tables[i].Rows[0]["ProviderName"].ToString();// +(i+1);
                    //}
                    ////ds.Tables[0].TableName = "AllProviderMessages";

                    return Ok(ResultDataSet);
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
        /// Get all messages by CustomerIDs. 
        /// </summary>
        /// <param name="CustomerID">The ID of the user.</param>
        /// <returns>A data collection of all  messages requested by customer.</returns>
        [ResponseType(typeof(SN_Messages))]
        [HttpGet]
        [Route("GetMessage/Customer/{CustomerID}")]
        public IHttpActionResult GetMessageCustomer(int CustomerID)
        {
            try
            {


                //List<DataSet> ResultDataSet = new List<DataSet>();
                //DataSet ds = DAL.SN_Messages_FetchByCustomerID(CustomerID);//.Tables[1];
                //if (ds.Tables.Count > 0)
                //{
                //    foreach (DataTable dt in ds.Tables)
                //    {

                //        var idColumn = "JobID";
                //        var distinctIds = dt.DefaultView
                //            .ToTable(true, idColumn)
                //            .Rows
                //            .Cast<DataRow>()
                //            .Select(row => row[idColumn])
                //            .ToList();

                //        //APP_BLL.WriteLog("dt.Rows.Count :" + dt.Rows.Count);
                //        DataSet dsResult = new DataSet();
                //        for (int i = 0; i < distinctIds.Count; i++)
                //        {
                //            int currentID =  Convert.ToInt32(distinctIds[i]);
                //            DataTable dtNew = new DataTable();
                //            dtNew=dt.Clone();

                //            dtNew=dt.AsEnumerable()
                //                        .Where(r => r.Field<int>("JobID") == currentID)
                //                        .CopyToDataTable();
                //           // APP_BLL.WriteLog("dtNew.Rows.Count :" + dtNew.Rows.Count);
                //            dtNew.TableName= dt.Rows[0]["PostMessage"].ToString()+ currentID;
                //            dsResult.Tables.Add(dtNew);

                //        }

                //        ResultDataSet.Add(dsResult);
                //    }

                //    //for (int i = 0; i < ds.Tables.Count; i++)
                //    //{
                //    //    foreach(DataTable dt in )
                //    //    ds.Tables[i].TableName = ds.Tables[i].Rows[0]["ProviderName"].ToString();// +(i+1);
                //    //}
                //    ////ds.Tables[0].TableName = "AllProviderMessages";

                //    return Ok(ResultDataSet);
                //}
                if (CustomerID != 0)
                {
                    return Ok(DAL.FetchCustomerMessages(CustomerID));
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
        /// Edit a message sent
        /// </summary>
        /// <param name="_SN_MessagesEdit">The ID of the user.</param>
        /// <returns>An object of message edited</returns>
        //[ResponseType(typeof(SN_Messages))]
        //[HttpPost]
        //[Route("EditMessage")]
        //public IHttpActionResult EditMessage(SN_MessagesEdit _SN_MessagesEdit)
        //{
        //    try
        //    {
        //        DataRow temp = DAL.SN_Messages_Fetch(_SN_MessagesEdit.MessageID).Tables[0].Rows[0];
        //        SN_Messages _SN_Messages = new SN_Messages();
        //        _SN_Messages.CustomerID = Convert.ToInt32(temp["CustomerID"]);
        //        _SN_Messages.SourceID = Convert.ToInt32(temp["SourceID"]);
        //        _SN_Messages.ProviderID = Convert.ToInt32(temp["ProviderID"]);
        //        _SN_Messages.IsReade = Convert.ToBoolean(temp["IsReade"]);
        //        _SN_Messages.MessageID = _SN_MessagesEdit.MessageID;// Convert.ToInt32(temp["CustomerID"]);
        //        _SN_Messages.Message = _SN_MessagesEdit.Message;

        //        bool result = DAL.SN_Messages_Update(_SN_Messages);//.Tables[1];
        //        //Dictionary<string,string> response
        //        if (result)
        //        {
        //            DataTable dt = DAL.SN_Messages_Fetch(_SN_Messages.MessageID).Tables[0];

        //            return Ok(dt);
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

    }
}
