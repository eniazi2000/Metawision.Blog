using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Metawision.Blog.Models.DTO;



namespace Metawision.Blog.Models
{
    public class articleManager
    {

        public static object ViewBag { get; private set; }

        public static List<article> getAllArticle()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.articles.OrderByDescending(a => a.date).ToList();

        }

        public static List<article> latestThreePosts()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.articles.OrderByDescending(m => m.date).Take(3).ToList();

        }

        public static article lastPost()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.articles.OrderByDescending(m => m.Id).FirstOrDefault();
        }

        public static void addViewCountForAricle(int id)
        {
            DataClasses1DataContext database = new DataClasses1DataContext();
            var p = database.articles.Where(b => b.Id == id).FirstOrDefault();
            p.viewCount = p.viewCount + 1;
            database.SubmitChanges();


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
                    state = model.state,
                    title = model.title,
                    viewCount = model.viewCount
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
        public static bool updateArticleOnDatabaseByID(article model,int id)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var art = db.articles.Where(a => a.Id == id).FirstOrDefault();

                art.body = model.body;
                art.customLink = model.customLink;
                art.idImage = model.idImage;
                art.pic = model.pic;
                art.title = model.title;
                art.viewCount = model.viewCount;
                art.state = model.state;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool updateArticleOnDatabase(articleDTO model)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var articleList = db.articles.ToList();
                var art = articleList.Where(a => a.Id == model.id).FirstOrDefault();
                var dArt = model.convertToArticle();

                art.body = dArt.body;
                art.customLink = dArt.customLink;
                art.idImage = dArt.idImage;
                art.pic = dArt.pic;
                art.title = dArt.title;
                art.viewCount = dArt.viewCount;
                art.state = dArt.state;

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
                if (item != null)
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
                if (item != null)
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




        public static int LikeArticle(int articleId) //آیدی ارتیکل می‌گیره
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var ipAdd = ipAddressManager.GetIp();

                if (ipAdd.Length > 0)
                {
                    var likeItem = db.articleLikes.Where(m => m.idArticle == articleId && m.ipAddress == ipAdd).FirstOrDefault();
                    if (likeItem == null)
                    {


                        articleLike like = new articleLike
                        {

                            ipAddress = ipAdd,
                            date = DateTime.Now,
                            idArticle = articleId,

                        };
                        db.articleLikes.InsertOnSubmit(like);
                        db.SubmitChanges();

                    }
                    else
                    {
                        db.articleLikes.DeleteOnSubmit(likeItem);
                        db.SubmitChanges();

                    }

                    return db.articleLikes.Where(m => m.idArticle == articleId).Count();

                }
                else
                {
                    return -2;
                }
            }

            catch
            {
                return -2;
            }

         }



        public static void articleLikeCount(int id)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var c = db.articleLikes.Where(b => b.Id == id).FirstOrDefault();
            c.likeCount = c.likeCount + 1;
            db.SubmitChanges();

        }

        public static bool UpdateArticle(article m)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var item = db.articles.Where(g => g.Id == m.Id).FirstOrDefault();
                if (item != null)
                {
                    item.title = m.title;
                    item.body = m.body;
                    item.date = DateTime.Now;
                    item.state = m.state;
                    item.pic = m.pic;
                    item.idUser = m.idUser;
                    item.customLink = m.customLink;




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
        









