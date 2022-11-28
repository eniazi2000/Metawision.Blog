using Metawision.Blog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Metawision.Blog.Models.DTO;
using Metawision.Blog.Models.Bl;


namespace Metawision.Blog.Controllers
{

    public partial class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult newPost()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newPost(articleDTO model)
        {
            articleManager.saveArticleToDatabase(model);
            article art = articleManager.lastPost();
            imageManager.updateImageByArtId(0, art.Id);
            var img = imageManager.getImageByArticleId(art.Id);
            art.idImage = img.Id;
            //articleManager.updateArticleOnDatabaseByID(art, art.Id);
            articleManager.updateArticleOnDatabase(art.convertToArticle());
            return RedirectToAction("EditArticle" , "admin" , new { id = art.Id });
        }
        [HttpGet]
        public ActionResult articleList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DeleteArticle(int id)
        {
            articleManager.deletArticle(id);
            return View("articleList");
        }
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult EditArticle()
        {
            return View();
        }
        //[HttpGet]
        //[ValidateInput(false)]
        //public ActionResult EditArticle(int id)
        //{
        //    var article = articleManager.getArticle(id);
        //    ViewData["articleId"] = article.Id.ToString();
        //    return View(id);
        //}
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditArticle(articleDTO model)
        {
            articleManager.updateArticleOnDatabase(model);
            ViewData["articleId"] = model.id.ToString();
            return View();
        }
        public ActionResult contactUsList()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Categories(categoryDTO model)
        {
            categoryManager.saveCategoryToDatabase(model);
            return View();
        }
        [HttpPost]
        public PartialViewResult parUploadImageDTO(imageDTO model)
        {
            if (model.idArticle == 0)
            {
                imageManager.saveImageToDatabase(model);
            }
            else if (model.idArticle != 0)
            {
                imageManager.updateImageOnDatabase(model);
            }
            return PartialView();
        }
    }
}