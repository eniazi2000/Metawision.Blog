using Metawision.blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metawision.blog.Controllers
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
    }
}