


using System.Web.Mvc;

namespace Metawision.blog.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id)
        {

            return View(id);
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
        
    }
}