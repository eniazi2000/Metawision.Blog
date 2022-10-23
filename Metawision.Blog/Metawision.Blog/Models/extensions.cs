using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models
{
    public static class extensions
    {
        public static article convertToArticle(this articleDTO val)
        {
            article item = new article
            {
                body = val.body,
                customLink = val.customLink,
                date = DateTime.Now,
                idUser = val.idUser,
                pic = val.pic,
                state = val.state,
                title = val.title,
                Id = val.id
            };
            return item;
        }
        public static articleDTO convertToArticle(this article val)
        {
            articleDTO item = new articleDTO
            {
                body = val.body,
                customLink = val.customLink,

                idUser = val.idUser,
                pic = val.pic,
                state = val.state,
                title = val.title,
                id = val.Id
            };
            return item;
        }


    }
}