using Metawision.Blog.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models.Bl
{


    public class imageManager
    { 

     public static List<image> GetImages()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.images.ToList();

        }


        public static bool saveImageToDatabase(imageDTO model)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                image item = new image {

                    pic = model.pic

            };
                db.images.InsertOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}