using GloommeApi.Codes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    public class DAL_SN_Packages
    {

        public IEnumerable<SN_vw_ProviderPackages> PackagesByProvider(int providerid)
        {
            IEnumerable<SN_vw_ProviderPackages> results = new List<SN_vw_ProviderPackages>();
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    results = context.SN_ProviderPackages_FetchByProviderID(providerid)
                          .ToList();
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
            }
            return results;
        }

        public dynamic CreatePackages(SN_ProviderPackages Packages)
        {
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    var sk = context.SN_ProviderPackages.SingleOrDefault(p => p.ProviderID == Packages.ProviderID && p.PackageName == Packages.PackageName);
                    if (sk != null)
                    {
                        return new { status = "failed", Message = "Packages Already Exist" };
                    }
                    else
                    {
                        context.SN_ProviderPackages.Add(Packages);
                        context.SaveChanges();
                        return new { status = "success", Packages = PackagesByProvider((int)Packages.ProviderID) };
                    }

                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return ex;
            }
        }

        public Object DeletePackages(int PackagesID)
        {
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    var Packages = context.SN_ProviderPackages.Find(PackagesID);
                    if (Packages != null)
                    {
                        context.SN_ProviderPackages.Remove(Packages);
                        context.SaveChanges();
                        return new { status = "success", Skills = PackagesByProvider((int)Packages.ProviderID) };
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