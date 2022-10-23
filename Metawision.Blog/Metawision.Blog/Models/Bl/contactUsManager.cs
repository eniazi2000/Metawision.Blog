using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models
{
    public class contactUsManager
    {
        public static void saveContactUsToDatabase(contact p)
        {
            DataClasses1DataContext database = new DataClasses1DataContext();

            p.date = DateTime.Now;
            database.contacts.InsertOnSubmit(p);
            database.SubmitChanges();
        }

        public static List<contact> GetContact()
        {
            DataClasses1DataContext database = new DataClasses1DataContext();
            return database.contacts.OrderByDescending(tp=> tp.date).ToList();
        }




    }
}