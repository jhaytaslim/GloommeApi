using GloommeApi.Codes;
using GloommeApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace GloommeApi.Controllers
{
    [RoutePrefix("api/Misc")]
    public class MiscController : ApiController
    {
        DAL_Area DAL_A = new DAL_Area();
        DAL_SN_ProviderAreas DAL = new DAL_SN_ProviderAreas();
        DAL_SN_Bank DAL_M = new DAL_SN_Bank();
        DAL_SN_Categories DSC = new DAL_SN_Categories();


        [HttpGet]
        public IHttpActionResult FetchCategories(int category)
        {
            try
            {
                DAL_Misc DAL = new DAL_Misc();
                DataTable dt = DAL.SN_Category_Fetch(0).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row = null;

                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName.Trim(), dr[col]);
                        }
                        rows.Add(row);
                    }
                    return Ok(serializer.Serialize(rows));
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult FetchCategoryAreas(int categoryid)
        {
            try
            {
                DAL_Misc DAL = new DAL_Misc();
                DataTable dt = DAL_A.SN_Areas_FetchByCategoryID(categoryid,0).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row = null;

                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName.Trim(), dr[col]);
                        }
                        rows.Add(row);
                    }
                    return Ok(serializer.Serialize(rows));
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult FetchProviderAreasByCategory(int providerID, int CategoryID)
        {
            try
            {
                if (providerID != 0 && providerID != null && CategoryID != 0)
                {
                    var areas = DAL.FetchProviderAreasByCategory(providerID,CategoryID).ToList();
                    return Ok(areas);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult Banks()
        {
            try
            {
                    var areas = DAL_M.Banks().ToList();
                    return Ok(areas);
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult FetchCategoriesAll()
        {
            try
            {
                var categories = DSC.SN_Categories_Fetch(0);//.ToList();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult FetchSpecializationByCategory()
        {
            try
            {
                var result = DSC.SN_Categories_Fetch(0);//.ToList();
                return Ok("Not Implemented Yet");
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

    }
}


//JsonSerializer json = new JsonSerializer();
//json.NullValueHandling = NullValueHandling.Ignore;

//                    json.ObjectCreationHandling = ObjectCreationHandling.Replace;
//                    json.MissingMemberHandling = MissingMemberHandling.Ignore;
//                    json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

//                    json.Converters.Add(new DataTableConverter());

//                    StringWriter sw = new StringWriter();
//JsonTextWriter writer = new JsonTextWriter(sw);
//writer.Formatting = Formatting.Indented;

//                    writer.QuoteChar = '"';
//                    var result = json.Serialize((writer, dt);

//string output = sw.ToString();
//writer.Close();
//                    sw.Close();
//                    return Ok(output);