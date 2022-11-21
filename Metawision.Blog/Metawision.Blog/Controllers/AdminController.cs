using Metawision.Blog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult newPost(articleDTO newArticle)
        {
            articleManager.saveArticleToDatabase(newArticle);
            return RedirectToAction("editArticle" , "admin");
            //return View();
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
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditArticle(article model)
        {
            //return RedirectToAction("article" , "home" , new { id = model.Id });
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
        public ActionResult Categories(categoryDTO newCat)
        {
            categoryManager.saveCategoryToDatabase(newCat);
            return View();
        }

    }

}