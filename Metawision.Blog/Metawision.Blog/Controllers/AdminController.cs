using Metawision.Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metawision.Blog.Controllers
{
    public class AdminController : Controller
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
            return View();
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
        public ActionResult EditArticle(int id)
        {

            return View(id);
        }

        [HttpPost]
        public ActionResult EditArticle(article model)

        {

            return RedirectToAction("article", "home", new { id = model.Id });
        }

        [HttpGet]

        public ActionResult contactUsList()
        {
            return View();
        }

 

    }
}