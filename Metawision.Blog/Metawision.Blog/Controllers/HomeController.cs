


using Metawision.Blog.Models;
using Metawision.Blog.Models.bl;
using System.Web.Mvc;

namespace Metawision.Blog.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id)
        {

            return View(id);
        }

        [HttpGet]
        public ActionResult Blog()
        {

                return View();
        }

        [HttpGet]
        public ActionResult Page(int id)
        {
            return View(id);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult article (int id)
        {
            if (articleManager.getArticle(id) == null)
            {
                Response.StatusCode = 404;
                return View("PageNotFound");
            }
            else
            {
                return View(id);
            }
        }

        [HttpPost]
       public ActionResult saveComments(comment model)
        {
            
            commentsManager.saveComments(model);
            
            return RedirectToAction("article", new { id = model.idArticle });
        }

    }
}