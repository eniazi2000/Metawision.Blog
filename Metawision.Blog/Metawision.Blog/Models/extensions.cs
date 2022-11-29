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

/*
        public static contact convertToContact(this contactUsDTO val)
        {
            contact item = new contact
            {
                Id = val.id,
                name = val.name,
                family = val.family,
                email = val.email,
                phone = val.phone,
                txt = val.txt,
                securityCode = val.securityCode,
                date = DateTime.Now,
                state = val.state,
            };
            return item;
        }


        public static contactUsDTO convertToContact(this contact val)
        {
            contactUsDTO item = new contactUsDTO
            {
                id = val.Id,
                name = val.name,
                family = val.family,
                email = val.email,
                phone = val.phone,
                txt = val.txt,
                securityCode = val.securityCode,
                state = val.state,
            };
            return item;
        }


*/


    }
}