using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models
{
    public class articleManager
    {
        public static object ViewBag { get; private set; }

        public static List<article> getAllArticle()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.articles.OrderByDescending(a =>a.date).ToList();
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

        public static bool deletArticle(int index)
        {
            DataClasses1DataContext database = new DataClasses1DataContext();
            try
            {
                var item = database.articles.Where(ar => ar.Id == index).FirstOrDefault();
                if(item !=null)
                {
                    database.articles.DeleteOnSubmit(item);
                    database.SubmitChanges();

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

        public static int nextarticle(int id)
        {
            DataClasses1DataContext database = new DataClasses1DataContext();
            try
            {
                var nextArticle = articleManager.getAllArticle().OrderBy(i => i.Id).Where(i => i.Id > id).FirstOrDefault();

                if (nextArticle != null)
                    return nextArticle.Id;
                else
                    return -1;

            }
            catch
            {
                return -1;
            }
        }


        public static int previousarticle(int id)
        {
            DataClasses1DataContext database = new DataClasses1DataContext();
            try
            {
                var previousArticle = articleManager.getAllArticle().OrderByDescending(i => i.Id).Where(i => i.Id < id).FirstOrDefault();

                if (previousArticle != null)
                    return previousArticle.Id;
                else
                    return -1;

            }
            catch
            {
                return -1;
            }
        }




    }
}