using Microsoft.ApplicationBlocks.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace GloommeApi.Codes
{
    public class DAL_Misc
    {
        HttpContext context;
        SqlConnection cn = new SqlConnection();
        public DAL_Misc()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        }




        public DataSet SN_Category_Fetch(int CategoryID)
        {
            try
            {
                SqlParameter[] @params = { new SqlParameter("@CategoryID", CategoryID) };
                return SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "SN_Category_Fetch", @params);
            }
            catch (Exception ex)
            {
                APP_BLL.WriteLog(ex.Message + " : " + ex.StackTrace);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

    }
}