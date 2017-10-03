using GloommeApi.Codes;
using GloommeApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace GloommeApi.Controllers
{
    [RoutePrefix("api/provider")]
    public class ProviderController : ApiController
    {
        // GET: api/Provider
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Provider/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Provider
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Provider/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Provider/5
        //public void Delete(int id)
        //{
        //}

        DAL_SN_Providers DAL = new DAL_SN_Providers();
        DAL_SN_ProviderCategory DAL_PC = new DAL_SN_ProviderCategory();
        DAL_SN_ProviderAreas DAL_PA = new DAL_SN_ProviderAreas();
        DAL_SN_ProviderSkills DAL_SK = new DAL_SN_ProviderSkills();
        DAL_SN_ProviderCertification DAL_P = new DAL_SN_ProviderCertification();
        DAL_SN_Packages DAL_PP = new DAL_SN_Packages();
        DAL_SN_Bank DAL_PB = new DAL_SN_Bank();
        DAL_SN_SearchWords DAL_PS = new DAL_SN_SearchWords();

        // GET api/<controller>
        [HttpGet]
        [Route("login")]
        public IHttpActionResult ProviderLogin(string username, string password)
        {
            try
            {
                DataTable dt = DAL.SN_Providers_Login(username, password).Tables[0];
                if (dt.Rows.Count > 0)
                {

                    return Ok(new
                    {
                        UserID = dt.Rows[0]["ProviderID"].ToString(),
                        FullName = dt.Rows[0]["Fullname"].ToString(),
                        Email = dt.Rows[0]["EmailAddress"].ToString(),
                        AccountType = "Provider",
                        ProviderType = dt.Rows[0]["ProviderTypeName"].ToString(),
                        CompanyName = dt.Rows[0]["CompanyName"].ToString()
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
        public IHttpActionResult ProviderSignUp(ProviderVM provider)
        {
            try
            {
                DataSet ds = DAL.SN_Providers_Insert(provider);
                DataTable dt1 = ds.Tables[0];
                if (dt1.Rows[0]["IsExisting"].ToString() == "0")
                {
                    DataTable dt = ds.Tables[1];
                    return Ok(new
                    {
                        Email = provider.EmailAddress,
                        UserID = dt.Rows[0]["ProviderID"].ToString(),
                        FullName = dt.Rows[0]["Fullname"].ToString(),
                        AccountType = "Provider",
                        ProviderType = dt.Rows[0]["ProviderTypeName"].ToString(),
                        CompanyName = dt.Rows[0]["CompanyName"].ToString()
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

        #region Categories
        [HttpGet]
        public IHttpActionResult Categories(int categoryID, int providerID)
        {
            try
            {
                int actn = categoryID == 0 ? 0 : 1;
                switch (actn)
                {
                    case 0:
                        DataTable dt = DAL_PC.SN_ProviderCategory_FetchByProviderID(providerID).Tables[0];
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                        Dictionary<string, object> row = null;
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                row = new Dictionary<string, object>();
                                foreach (DataColumn col in dt.Columns)
                                {
                                    row.Add(col.ColumnName.Trim(), dr[col]);
                                }
                                rows.Add(row);
                            }
                        }
                        return Ok(serializer.Serialize(rows));
                    //break;
                    case 1:
                        DataTable dt2 = DAL_PC.SN_ProviderCategory_Fetch(categoryID).Tables[0];
                        JavaScriptSerializer serializer2 = new JavaScriptSerializer();
                        List<Dictionary<string, object>> rows2 = new List<Dictionary<string, object>>();
                        Dictionary<string, object> row2 = null;
                        if (dt2.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt2.Rows)
                            {
                                row2 = new Dictionary<string, object>();
                                foreach (DataColumn col in dt2.Columns)
                                {
                                    row2.Add(col.ColumnName.Trim(), dr[col]);
                                }
                                rows2.Add(row2);
                            }
                        }
                        return Ok(serializer2.Serialize(rows2));
                    default:
                        break;
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult NewProviderCategory(SN_ProviderCategoryVM PCVM)
        {
            try
            {

                DataSet ds = DAL_PC.SN_ProviderCategory_Insert(PCVM);
                DataTable dt1 = ds.Tables[0];
                if (dt1.Rows[0]["OPERATIONRESULT"].ToString() == "0")
                {
                    DataTable dt = ds.Tables[1];
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

                else
                {
                    return BadRequest("This category already exist for you!");
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult RemoveProviderCategory(int providerCategoryID)
        {
            try
            {
                if (providerCategoryID != null && providerCategoryID != 0)
                {
                    DataSet ds = DAL_PC.SN_ProviderCategory_Delete(providerCategoryID);
                    DataTable dt1 = ds.Tables[0];
                    if (dt1.Rows[0]["OPERATIONRESULT"].ToString() == "0")
                    {
                        DataTable dt = ds.Tables[1];
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

                    else
                    {
                        return BadRequest("Error processing your request please try again");
                    }
                }
                return BadRequest("Fatal Error something happened with your request");
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }
        #endregion

        #region Areas
        [HttpGet]
        public IHttpActionResult Areas(int providerID)
        {
            try
            {
                if (providerID != 0 && providerID != null)
                {
                    DataSet ds = DAL_PA.SN_ProviderAreas_FetchByProviderID(providerID);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row = null;
                    DataTable dt = ds.Tables[1];
                    DataTable dt0 = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            List<Dictionary<string, object>> rowsx = new List<Dictionary<string, object>>();
                            Dictionary<string, object> rowx = null;
                            foreach (DataRow drx in dt0.Rows)
                            {
                                if (drx["CategoryID"].ToString() == dr["CategoryID"].ToString())
                                {
                                    APP_BLL.WriteLog("dtable areas = " + dt0.Columns[2].ColumnName + " dtable category = " + dt.Columns[0].ColumnName);

                                    rowx = new Dictionary<string, object>();
                                    foreach (DataColumn col in dt0.Columns)
                                    {
                                        rowx.Add(col.ColumnName.Trim(), drx[col]);
                                    }
                                    rowsx.Add(rowx);
                                }
                            }
                            row = new Dictionary<string, object>();
                            //foreach (DataColumn col in dt.Columns)
                            //{
                            row.Add("CategoryName", dr["CategoryName"].ToString());
                            row.Add("Areas", rowsx);
                            //}
                            rows.Add(row);
                        }
                    }
                    return Ok(serializer.Serialize(rows));
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult AreasByProvider(int providerID)
        {
            try
            {
                if (providerID != 0 && providerID != null)
                {
                    var areas = DAL_PA.FetchProviderAreas_Only(providerID).ToList();
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

        [HttpPost]
        public IHttpActionResult NewArea(SN_ProviderAreasInfo ProviderArea)
        {
            try
            {
                DataSet ds = DAL_PA.SN_ProviderAreas_Insert(ProviderArea);
                DataTable dt1 = ds.Tables[0];
                if (dt1.Rows[0]["OPERATIONRESULT"].ToString() == "0")
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row = null;
                    DataTable dt = ds.Tables[2];
                    DataTable dt0 = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            List<Dictionary<string, object>> rowsx = new List<Dictionary<string, object>>();
                            Dictionary<string, object> rowx = null;
                            foreach (DataRow drx in dt0.Rows)
                            {
                                if (drx["CategoryID"].ToString() == dr["CategoryID"].ToString())
                                {
                                    APP_BLL.WriteLog("dtable areas = " + dt0.Columns[2].ColumnName + " dtable category = " + dt.Columns[0].ColumnName);

                                    rowx = new Dictionary<string, object>();
                                    foreach (DataColumn col in dt0.Columns)
                                    {
                                        rowx.Add(col.ColumnName.Trim(), drx[col]);
                                    }
                                    rowsx.Add(rowx);
                                }
                            }
                            row = new Dictionary<string, object>();
                            //foreach (DataColumn col in dt.Columns)
                            //{
                            row.Add("CategoryName", dr["CategoryName"].ToString());
                            row.Add("Areas", rowsx);
                            //}
                            rows.Add(row);
                        }
                    }
                    return Ok(serializer.Serialize(rows));
                }
                else
                {
                    return BadRequest("Selected area already exist for you");
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteArea(int ProviderAreaID)
        {
            try
            {
                if (ProviderAreaID != null && ProviderAreaID != 0)
                {
                    DataSet ds = DAL_PA.SN_ProviderAreas_Delete(ProviderAreaID);
                    DataTable dt1 = ds.Tables[0];
                    if (dt1.Rows[0]["OPERATIONRESULT"].ToString() == "0")
                    {
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                        Dictionary<string, object> row = null;
                        DataTable dt = ds.Tables[2];
                        DataTable dt0 = ds.Tables[1];
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                List<Dictionary<string, object>> rowsx = new List<Dictionary<string, object>>();
                                Dictionary<string, object> rowx = null;
                                foreach (DataRow drx in dt0.Rows)
                                {
                                    if (drx["CategoryID"].ToString() == dr["CategoryID"].ToString())
                                    {
                                        rowx = new Dictionary<string, object>();
                                        foreach (DataColumn col in dt0.Columns)
                                        {
                                            rowx.Add(col.ColumnName.Trim(), drx[col]);
                                        }
                                        rowsx.Add(rowx);
                                    }
                                }
                                row = new Dictionary<string, object>();
                                //foreach (DataColumn col in dt.Columns)
                                //{
                                row.Add("CategoryName", dr["CategoryName"].ToString());
                                row.Add("Areas", rowsx);
                                //}
                                rows.Add(row);
                            }
                        }
                        return Ok(serializer.Serialize(rows));
                    }

                    else
                    {
                        return BadRequest("Error processing your request please try again");
                    }
                }
                return BadRequest("Fatal Error something happened with your request");
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }
        #endregion

        #region skills
        [HttpGet]
        public IHttpActionResult Skills(int providerID)
        {
            try
            {
                APP_BLL.WriteLog("provider is " + providerID);
                if (providerID != 0 && providerID != null)
                {
                    var skills = DAL_SK.SkillsByProvider(providerID).ToList();
                    APP_BLL.WriteLog(skills.Count.ToString());
                    return Ok(skills);
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

        [HttpPost]
        public IHttpActionResult NewSkills(SN_SkillsInfo Skills)
        {
            try
            {
                if (Skills != null)
                {
                    SN_Skills SN = new SN_Skills
                    {
                        AreaID = Skills.AreaID,
                        ProviderID = Skills.ProviderID,
                        SkillDescription = Skills.SkillDescription,
                        SkillName = Skills.SkillName
                    };
                    dynamic res = DAL_SK.CreateSkills(SN);
                    if (res.status == "success")
                    {
                        return Ok(res);
                    }
                    else
                    {
                        return BadRequest(res.Message);

                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteSkill(int SKillID)
        {
            try
            {
                if (SKillID != null && SKillID != 0)
                {
                    dynamic res = DAL_SK.DeleteSkill(SKillID);
                    if (res.status == "success")
                    {
                        return Ok(res);
                    }
                    else
                    {
                        return BadRequest(res);
                    }
                }
                return BadRequest("Fatal Error something happened with your request");
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }
        #endregion

        #region certification
        [HttpGet]
        public IHttpActionResult Certification(int providerID)
        {
            try
            {
                if (providerID != 0 && providerID != null)
                {
                    var certification = DAL_P.CertificationByProvider(providerID).ToList();
                    return Ok(certification);
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

        [HttpPost]
        public IHttpActionResult NewCertification(ProviderCertification Certification)
        {
            try
            {
                if (Certification != null)
                {
                    SN_ProviderCertification SN = new SN_ProviderCertification
                    {
                        CertificationName = Certification.CertificationName,
                        ProviderID = Certification.ProviderID,
                        YearAchived = Certification.YearAchived,
                        CertificationProvider = Certification.CertificationProvider
                    };
                    dynamic res = DAL_P.CreateCertification(SN);
                    if (res.status == "success")
                    {
                        return Ok(res);
                    }
                    else
                    {
                        return BadRequest(res.Message);

                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteCertification(int CertificationID)
        {
            try
            {
                if (CertificationID != null && CertificationID != 0)
                {
                    dynamic res = DAL_P.DeleteCertification(CertificationID);
                    if (res.status == "success")
                    {
                        return Ok(res);
                    }
                    else
                    {
                        return BadRequest(res);
                    }
                }
                return BadRequest("Fatal Error something happened with your request");
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        #endregion

        #region packages
        [HttpGet]
        public IHttpActionResult Packages(int providerID)
        {
            try
            {
                if (providerID != 0 && providerID != null)
                {
                    var Packages = DAL_PP.PackagesByProvider(providerID).ToList();
                    return Ok(Packages);
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

        [HttpPost]
        public IHttpActionResult NewPackages(ProviderPackages Packages)
        {
            try
            {
                if (Packages != null)
                {
                    SN_ProviderPackages SN = new SN_ProviderPackages
                    {
                        PackageName = Packages.PackageName,
                        ProviderID = Packages.ProviderID,
                        Amount = Packages.Amount,
                        AreaID = Packages.AreaID,
                        CategoryID = Packages.CategoryID,
                        IsActive = true,
                        PackageDescription = Packages.PackageDescription,
                        Timeline = Packages.Timeline,
                        TimelineType = Packages.TimelineType
                    };
                    dynamic res = DAL_PP.CreatePackages(SN);
                    if (res.status == "success")
                    {
                        return Ok(res);
                    }
                    else
                    {
                        return BadRequest(res.Message);

                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeletePackages(int PackagesID)
        {
            try
            {
                if (PackagesID != null && PackagesID != 0)
                {
                    dynamic res = DAL_PP.DeletePackages(PackagesID);
                    if (res.status == "success")
                    {
                        return Ok(res);
                    }
                    else
                    {
                        return BadRequest(res);
                    }
                }
                return BadRequest("Fatal Error something happened with your request");
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        #endregion

        #region Bank
        [HttpGet]
        public IHttpActionResult Banks(int providerID)
        {
            try
            {
                if (providerID != 0 && providerID != null)
                {
                    var Bank = DAL_PB.BankByProvider(providerID).ToList();
                    return Ok(Bank);
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

        [HttpPost]
        public IHttpActionResult NewBank(ProviderBank Bank)
        {
            try
            {
                if (Bank != null)
                {
                    SN_ProviderBanks SN = new SN_ProviderBanks
                    {
                        BankID = Bank.BankID,
                        ProviderID = Bank.ProviderID,
                        AccountName = Bank.AccountName,
                        AccountNo = Bank.AccountNo,
                        SortCode = Bank.SortCode
                    };
                    dynamic res = DAL_PB.CreateBank(SN);
                    if (res.status == "success")
                    {
                        return Ok(res);
                    }
                    else
                    {
                        return BadRequest(res.Message);

                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteBank(int BankID)
        {
            try
            {
                if (BankID != null && BankID != 0)
                {
                    dynamic res = DAL_PB.DeleteBank(BankID);
                    if (res.status == "success")
                    {
                        return Ok(res);
                    }
                    else
                    {
                        return BadRequest(res);
                    }
                }
                return BadRequest("Fatal Error something happened with your request");
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        #endregion

        #region Keyword
        [HttpGet]
        public IHttpActionResult Keyword(int providerID)
        {
            try
            {
                if (providerID != 0 && providerID != null)
                {
                    var Keyword = DAL_PS.KeywordByProvider(providerID).ToList();
                    return Ok(Keyword);
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

        [HttpPost]
        public IHttpActionResult NewKeyword(ProviderKeyWords Keyword)
        {
            try
            {
                if (Keyword != null)
                {
                    SN_ProviderKeyWords SN = new SN_ProviderKeyWords
                    {
                        KeyWord= Keyword.KeyWord,
                        ProviderID = Keyword.ProviderID
                    };
                    dynamic res = DAL_PS.CreateKeyword(SN);
                    if (res.status == "success")
                    {
                        return Ok(res);
                    }
                    else
                    {
                        return BadRequest(res.Message);

                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteKeyword(int KeywordID)
        {
            try
            {
                if (KeywordID != null && KeywordID != 0)
                {
                    dynamic res = DAL_PS.DeleteKeyword(KeywordID);
                    if (res.status == "success")
                    {
                        return Ok(res);
                    }
                    else
                    {
                        return BadRequest(res);
                    }
                }
                return BadRequest("Fatal Error something happened with your request");
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return InternalServerError(ex);
            }
        }

        #endregion
    }
}
