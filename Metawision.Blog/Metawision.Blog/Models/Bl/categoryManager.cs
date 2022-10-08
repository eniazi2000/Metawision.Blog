using Metawision.Blog.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models
{
    public class categoryManager
    {

        public static List<category> GetCategories()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.categories.ToList();
        }
        public static List<category> GetCategoryChilds(int idParent)
        {
            return GetCategories().Where(c => c.idParent == idParent).ToList();
        }
        public static bool saveCategoryToDatabase(categoryDTO model)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                category item = new category
                {
                    idParent = model.idParent,
                    title = model.title
                };
                db.categories.InsertOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch
            { 
                return false;
            }
        }
        public static bool deleteCategoryFromDatabase(int id)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var item = db.categories.Where(c => c.id == id).FirstOrDefault();
                if(item==null)
                {
                    return false;
                }
                else
                {
                    db.categories.DeleteOnSubmit(item);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }




    }
}