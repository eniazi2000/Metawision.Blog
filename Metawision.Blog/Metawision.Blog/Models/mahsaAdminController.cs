using Metawision.Blog.Models;
using Metawision.Blog.Models.Bl;
using Metawision.Blog.Models.DTO;
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

        //[HttpGet]
        //public JsonResult GetServerPhisycalPath()
        //   {
        //       return Json(new { path = Server.MapPath("~/UplodedFiles")}, JsonRequestBehavior.AllowGet);
        //   }






        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string FileName = Path.GetFileName(file.FileName);




                    string mypath = Path.Combine(Server.MapPath("~/UploadedFiles"), FileName);



                    file.SaveAs(mypath);

                }
                //ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                //ViewBag.Message = "File upload failed!!";
                return View();
            }
        }




        [HttpGet]

        public ActionResult UploadImageDTO()
        {
            return View();
        }


        [HttpPost]

        public ActionResult UploadImageDTO(imageDTO model)
        {
            var temp = imageManager.saveImageToDatabase(model);  //check kon
            return View();
        }



        [HttpGet]
        public ActionResult imageList()
        {
            return View();
        }

        //[HttpPost]
        //public JsonResult markContactUsRead(contact model)
        //{
        //    //contactUsManager.saveStateToDatabase(model);
        //    return Json(new { state = true });
        //}

      

        [HttpGet]
        public ActionResult UpdateStateToDatabase(int id)
        {
            contactUsManager.UpdateStateToDatabase(id);
            return View("contactUsList");
        }









    }
    public class mahsaAdminController
    {
    }


}