using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Metawision.Blog.Models;
using Metawision.Blog.Models.Bl;
using Metawision.Blog.Models.DTO;

namespace Metawision.Blog.Controllers
{
    public partial class AdminController : Controller
    {
        [HttpGet]
        public ActionResult adminPanel()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _adminLayout( )
        {
            return View();
        }

        [HttpGet]
        public ActionResult newPostCopy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newPostCopy(articleDTO newArticle)
        {
            articleManager.saveArticleToDatabase(newArticle);
            return View();
        }
        [HttpGet]
        public ActionResult parUploadImageDTO()
        {
            return View();
        }


        [HttpPost]
        public ActionResult parUploadImageDTO(imageDTO model)
        {
            var temp = imageManager.saveImageToDatabase(model);  //check kon
            return View();
        }
    }
}