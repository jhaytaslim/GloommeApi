using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using GloommeApi.Codes;
using GloommeApi.Models;

namespace GloommeApi.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        DAL_SN_Customers DAL = new DAL_SN_Customers();
        // GET api/<controller>
        [HttpGet]
        [Route("login")]
        public IHttpActionResult CustomerLogin(string username, string password)
        {
            APP_BLL.WriteLog("something happened");
            try
            {
                DataTable dt = DAL.SN_Customers_Login(username, password).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                    //Session["Fullname"] = dt.Rows[0]["Fullname"].ToString();
                    //Response.Redirect("cpanel/dashboard.aspx");

                    return Ok(new
                    {
                        UserID = dt.Rows[0]["CustomerID"].ToString(),
                        FullName = dt.Rows[0]["Fullname"].ToString(),
                        Email = dt.Rows[0]["EmailAddress"].ToString(),
                        AccountType = "Customer"
                    });
                }
                else
                {
                    return BadRequest("invalid login credentials");
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("SignUp")]
        public IHttpActionResult CustomerSignUp(Customer customer)
        {
            try
            {
                DataSet ds = DAL.SN_Customers_Insert(customer);
                DataTable dt1 = ds.Tables[0];
                if (dt1.Rows[0]["IsExisting"].ToString() == "0")
                {
                    DataTable dt = ds.Tables[1];
                    return Ok(new
                    {
                        Email = customer.Email,
                        UserID = dt.Rows[0]["CustomerID"].ToString(),
                        FullName = dt.Rows[0]["Fullname"].ToString(),
                        AccountType = "Customer"
                    });
                }
                else
                {
                    return BadRequest("User email already exist!");
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        //[HttpGet]
    }
}
