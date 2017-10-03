using GloommeApi.Codes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    public class DAL_SN_ProviderCertification
    {


        public IEnumerable<SN_vw_ProviderCertification> CertificationByProvider(int providerid)
        {
            IEnumerable<SN_vw_ProviderCertification> results = new List<SN_vw_ProviderCertification>();
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    results = context.SN_ProviderCertification_FetchByProviderID(providerid)
                          .ToList();
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
            }
            return results;
        }

        public dynamic CreateCertification(SN_ProviderCertification Certification)
        {
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    var sk = context.SN_ProviderCertification.SingleOrDefault(p => p.ProviderID == Certification.ProviderID && p.CertificationName == Certification.CertificationName);
                    if (sk != null)
                    {
                        return new { status = "failed", Message = "Certification Already Exist" };
                    }
                    else
                    {
                        context.SN_ProviderCertification.Add(Certification);
                        context.SaveChanges();
                        return new { status = "success", Skills = CertificationByProvider((int)Certification.ProviderID) };
                    }

                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return ex;
            }
        }

        public Object DeleteCertification(int CertificationID)
        {
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    var Certification = context.SN_ProviderCertification.Find(CertificationID);
                    if (Certification != null)
                    {
                        context.SN_ProviderCertification.Remove(Certification);
                        context.SaveChanges();
                        return new { status = "success", Skills = CertificationByProvider((int)Certification.ProviderID) };
                    }
                    else
                    {
                        return new { status = "failed", Message = "Some went went wrong" };
                    }

                }


            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return ex;
            }
        }
    }
}