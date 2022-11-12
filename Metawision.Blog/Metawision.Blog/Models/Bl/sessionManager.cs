using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models
{
    public class sessionManager
    {
        public static void SaveDataToSession(String name)
        {
            HttpContext.Current.Session["username"] = name;
        }
        public static string getUsername()
        {
            return HttpContext.Current.Session["username"].ToString();
        }

        public static string getSessionId()
        {
            return HttpContext.Current.Session.SessionID;
        }
    }
}