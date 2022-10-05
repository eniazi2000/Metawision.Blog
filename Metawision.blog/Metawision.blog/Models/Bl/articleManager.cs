using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metawision.blog.Models
{
    public class articleManager
    {
        public static List<article> getAllArticle()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.articles.OrderByDescending(a => a.date).ToList();
        }
        public static article getArticle(int id)
        {
            return getAllArticle().Where(a => a.Id == id).FirstOrDefault();
        }
        public static bool saveArticleToDatabase(articleDTO model)
        {
            try
            {
                article item = new article
                {
                    body = model.body,
                    customLink = model.customLink,
                    date = DateTime.Now,
                    idUser = usersManager.getUserId(),
                    pic = model.pic,
                    state = 0,
                    title = model.title
                };
                DataClasses1DataContext db = new DataClasses1DataContext();
                db.articles.InsertOnSubmit(item);
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