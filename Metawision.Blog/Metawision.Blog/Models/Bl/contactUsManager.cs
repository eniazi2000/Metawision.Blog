using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models
{
    public class contactUsManager
    {
        //public static void saveContactUsToDatabase(contact p)
        //{
        //    DataClasses1DataContext database = new DataClasses1DataContext();

        //    p.date = DateTime.Now;
        //    database.contacts.InsertOnSubmit(p);
        //    database.SubmitChanges();
        //}



        public static bool saveContactUsToDatabase(contactUsDTO model)
        {
            try
            {
                contact item = new contact
                {
                    name = model.name,
                    family = model.family,
                    phone = model.phone,
                    email = model.email,
                    date = DateTime.Now,
                    state = 0,
                    txt = model.txt

                };
                DataClasses1DataContext db = new DataClasses1DataContext();
                db.contacts.InsertOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }




        public static List<contact> GetContact()
        {
            DataClasses1DataContext database = new DataClasses1DataContext();
            return database.contacts.OrderByDescending(tp => tp.date).ToList();
        }


        public static void UpdateStateToDatabase(int id)
        {
            DataClasses1DataContext database = new DataClasses1DataContext();

            var item = database.contacts.Where(mg => mg.Id == id).FirstOrDefault();
            if (item != null)
            {
                item.state = 1;
                //database.contacts.InsertOnSubmit(item);
                database.SubmitChanges();



            }

        }







    }
}