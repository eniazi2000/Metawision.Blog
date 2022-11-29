using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Metawision.Blog.Models.DTO;

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
                Id = val.id,
                viewCount = val.viewCount,
                idImage = val.idImage
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
                id = (int)val.Id,
                viewCount = val.viewCount,
                idImage = (int)val.idImage
            };
            return item;
        }
        public static image convertToImage(this imageDTO val)
        {
            image item = new image
            {
                Id = val.Id,
                pic = val.pic,
                idArticle = val.idArticle,
                date = DateTime.Now,
                alt = val.alt
            };
            return item;
        }
        public static imageDTO convertToImage(this image val)
        {
        imageDTO item = new imageDTO
            {
                Id = val.Id,
                pic = val.pic,
                idArticle = (int)val.idArticle,

                alt = val.alt
            };
            return item;
        }
    }
}