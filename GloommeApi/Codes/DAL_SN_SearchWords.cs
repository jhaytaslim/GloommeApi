using GloommeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloommeApi.Codes
{
    public class DAL_SN_SearchWords
    {

        public IEnumerable<SN_vw_ProviderKeyWords> KeywordByProvider(int providerid)
        {
            IEnumerable<SN_vw_ProviderKeyWords> results = new List<SN_vw_ProviderKeyWords>();
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    results = context.SN_ProviderKeyWords_FetchByProviderID(providerid)
                          .ToList();
                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
            }
            return results;
        }

        public dynamic CreateKeyword(SN_ProviderKeyWords Keyword)
        {
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    var sk = context.SN_ProviderKeyWords.SingleOrDefault(p => p.ProviderID == Keyword.ProviderID && p.KeyWord == Keyword.KeyWord);
                    if (sk != null)
                    {
                        return new { status = "failed", Message = "Keyword Already Exist" };
                    }
                    else
                    {
                        context.SN_ProviderKeyWords.Add(Keyword);
                        context.SaveChanges();
                        return new { status = "success", Keywords = KeywordByProvider((int)Keyword.ProviderID) };
                    }

                }
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + ex.StackTrace);
                return ex;
            }
        }

        public Object DeleteKeyword(int KeywordID)
        {
            try
            {
                using (var context = new SocialNetworkEntities2())
                {
                    var Keyword = context.SN_ProviderKeyWords.Find(KeywordID);
                    if (Keyword != null)
                    {
                        context.SN_ProviderKeyWords.Remove(Keyword);
                        context.SaveChanges();
                        return new { status = "success", Keywords = KeywordByProvider((int)Keyword.ProviderID) };
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