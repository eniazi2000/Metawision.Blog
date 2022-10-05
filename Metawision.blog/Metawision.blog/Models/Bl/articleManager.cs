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
        public static List<tag> getAllTags()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.tags.ToList();
        }
        public static List<tag> getArticleTags(int articleId)
        {
            return getAllTags().Where(a => a.idArticle == articleId).ToList();
        }
        public static bool saveTagToDatabase(tagDTO model)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                tag item = new tag
                {
                    idArticle = model.idArticle,
                    title = model.title
                };
                db.tags.InsertOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool deelteTagFromDatabase(int idTag)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var item = db.tags.Where(t => t.id == idTag).FirstOrDefault();
            try
            {
                if(item!= null)
                {
                    db.tags.DeleteOnSubmit(item);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


    }
}