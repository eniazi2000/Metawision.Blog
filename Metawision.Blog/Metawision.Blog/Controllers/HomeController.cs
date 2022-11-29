


using Metawision.Blog.Models;
using Metawision.Blog.Models.bl;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        [HttpGet]
        public ActionResult showLatestPosts()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult saveComments(comment model)
        //{

        //    commentsManager.saveComments(model);

        //    return RedirectToAction("article", new { id = model.idArticle });
        //}

        [HttpPost]
        public ActionResult saveComments(comment m)
        {
           // captcha validation

            if (!this.IsCaptchaValid(errorText: ""))
            {
                ViewBag.ErrorMessage = "کد امنیتی را به درستی وارد کنید";
                //اینو درست باید بکنم
                return RedirectToAction("article", new { id = m.idArticle });


                //return View("article", m);
            }
            

            else
            {

                commentsManager.saveComments(m);

                return RedirectToAction("article", new { id = m.idArticle });

            }

        }


        [HttpGet]
        public ActionResult contactUs()
        {
            return View();
        }




        [HttpPost]
        public ActionResult contactUs(contactUsDTO n)
        {
            if (!this.IsCaptchaValid(errorText: ""))
            {
                ViewBag.ErrorMessage = "کد امنیتی را به درستی وارد کنید";
                return View("contactUs", n);


            }
            else
            {
                contactUsManager.saveContactUsToDatabase(n);
                return Content("درخواست شما ارسال گردید");

            }
            //var response = Request["g-recaptcha-response"];
            //string secretkey = "6LdewjkjAAAAAG-yBJT5tEk_aoC47LVBfuFtQ17z";
            //var Client = new WebClient();
            //var result = Client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretkey, response));
            //var obj = JObject.Parse(result);
            //var status = (bool)obj.SelectToken("success");
            //ViewBag.Mesaage = status ? "google recaptcha validation success" : "google recaptcha validation failed";

            //return Content("درخواست شما ارسال گردید");



        }


 


        [HttpPost]
        public JsonResult LikeArticle(int id)
        {
            var res = articleManager.LikeArticle(id);

            return Json(new { state = res });
        }




    }
}