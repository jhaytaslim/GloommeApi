using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloommeApi.Codes
{
    public class APP_BLL
    {
        public static void WriteLog(string msg)
        {
            if (msg.ToString().Contains("Thread was being aborted"))
            {
                //do nothing
            }
            else
            {
                HttpContext context = HttpContext.Current;
                //If context.Session["UserName"] Is Nothing Then
                string _path = null;
                _path = "~/App_Logs\\WriteLog.txt";
                string path = context.Server.MapPath(_path);
                System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true);
                writer.WriteLine(msg + "  ErrorDate-" + DateTime.Now);
                writer.Close();
            }
            //End If
        }
    }
}