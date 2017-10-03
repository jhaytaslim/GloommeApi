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

        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(SN_JobsInfo _SN_JobsInfo)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    //t<string,string> report=new LinkedList<string,>
                    APP_BLL.WriteLog("Yes");
                    DataTable dt = DAL.SN_Jobs_Insert(_SN_JobsInfo).Tables[0];
                    if (dt.Rows.Count>0)
                    {
                        //List<SN_JobsInfo> result = new List<SN_JobsInfo>();
                        //result = _SN_JobsInfo.ToL;
                        //APP_BLL.WriteLog(result + "");
                        APP_BLL.WriteLog("Yes AGAIN");
                        return Ok(dt);
                    }
                    else
                    {

                        return BadRequest("No rows returned");
                    }
                //}
                //else
                //{
                //    return BadRequest();
                //}
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError();
            }
        }
    }
}
