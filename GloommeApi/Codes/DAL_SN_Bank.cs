using GloommeApi.Codes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    public class DAL_SN_Bank
    {

        public IEnumerable<SYS_VW_Banks> Banks()
        {
            IEnumerable<SYS_VW_Banks> results = new List<SYS_VW_Banks>();
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    results = context.SYS_Banks_Fetch(0)
                          .ToList();
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
            }
            return results;
        }

        public IEnumerable<SN_vw_ProviderBanks> BankByProvider(int providerid)
        {
            IEnumerable<SN_vw_ProviderBanks> results = new List<SN_vw_ProviderBanks>();
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    results = context.SN_ProviderBanks_FetchByProviderID(providerid)
                          .ToList();
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
            }
            return results;
        }

        public dynamic CreateBank(SN_ProviderBanks Bank)
        {
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    var sk = context.SN_ProviderBanks.SingleOrDefault(p => p.ProviderID == Bank.ProviderID && p.BankID == Bank.BankID);
                    if (sk != null)
                    {
                        return new { status = "failed", Message = "Bank Already Exist" };
                    }
                    else
                    {
                        context.SN_ProviderBanks.Add(Bank);
                        context.SaveChanges();
                        return new { status = "success", Banks = BankByProvider((int)Bank.ProviderID) };
                    }

                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return ex;
            }
        }

        public Object DeleteBank(int BankID)
        {
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    var Bank = context.SN_ProviderBanks.Find(BankID);
                    if (Bank != null)
                    {
                        context.SN_ProviderBanks.Remove(Bank);
                        context.SaveChanges();
                        return new { status = "success", Banks = BankByProvider((int)Bank.ProviderID) };
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