using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models
{
    public class ipAddressManager
    {

        public static string GetIp()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }









    }








}






//public static void uniqIpPerDay(hitCounter hc)
//{
//    DataClasses1DataContext database = new DataClasses1DataContext();
//    DateTime todey = DateTime.Now.Date;
//    var v = database.hitCounters.Where(a => a.ipAddress == hc.ipAddress &&
//        a.date.AddDays(-1) < todey && a.date.AddDays(1) >= todey).FirstOrDefault();
//    if (v == null)
//    {


//        hitCounter item = new hitCounter
//        {
//            ipAddress = hc.ipAddress
//        };
//        database.hitCounters.InsertOnSubmit(item);
//        database.SubmitChanges();

//    }

//}