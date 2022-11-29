using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models.bl
{
    public class commentsManager
    {
        public static void saveComments (comment m) // yadet nare bool kon try catch bzar
        {
            DataClasses1DataContext database = new DataClasses1DataContext();
            m.date = DateTime.Now;
            database.comments.InsertOnSubmit(m);
            database.SubmitChanges();

        }
      
        public static List<comment> getArticleAllComments(int articleId)
        {
            DataClasses1DataContext database = new DataClasses1DataContext();
            return database.comments.Where(t => t.idArticle == articleId).ToList();

        }
        public static List<comment> getArticleAllParentComments(int articleId)
        {
            DataClasses1DataContext database = new DataClasses1DataContext();
            return database.comments.Where(t => t.idArticle == articleId && t.replyToId == 0).ToList();

        }
        public static List<comment> getParentCommentChilds(int idParent)
        {
            DataClasses1DataContext database = new DataClasses1DataContext();
            return database.comments.Where(u => u.replyToId == idParent).ToList();
        }
        public static comment GetComment(int Id)
        {
            DataClasses1DataContext database = new DataClasses1DataContext();
            return database.comments.Where(c => c.id == Id).FirstOrDefault();
        }


        public static void addcommentCount(int articleId)
        {
            DataClasses1DataContext database = new DataClasses1DataContext();
            var m = database.comments.Where(cc => cc.idArticle == articleId).FirstOrDefault();
            m.commentCount = m.commentCount + 1;
            database.SubmitChanges();
        }
        


    }
}