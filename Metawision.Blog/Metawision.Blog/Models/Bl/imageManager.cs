using Metawision.Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Metawision.Blog.Models.DTO;

namespace Metawision.Blog.Models.Bl
{


    public class imageManager
    { 

        public static List<image> GetAllImages()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.images.ToList();
        }

        public static image getImageByArticleId(int id)
        {
            return GetAllImages().Where(a => a.idArticle == id).LastOrDefault();
        }

        public static image getLastImageId()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var image = db.images.OrderByDescending(m => m.Id).FirstOrDefault();
            return image;
        }

        public static bool saveImageToDatabase(imageDTO model)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                image item = new image {
                    pic = model.pic,
                    date = DateTime.Now,
                    idArticle = model.idArticle,
                    alt = model.alt
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

        public static bool updateImageOnDatabase(imageDTO model)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var imageList = db.images.ToList();
                var image = imageList.Where(a => a.Id == model.Id).FirstOrDefault();
                var img = model.convertToImage();

                image.alt = img.alt;
                image.idArticle = img.idArticle;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool updateImageByArtId(int id,int artId)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var imageList = db.images.ToList();
                var image = imageList.Where(a => a.idArticle == id).LastOrDefault();
                image.idArticle = artId;
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