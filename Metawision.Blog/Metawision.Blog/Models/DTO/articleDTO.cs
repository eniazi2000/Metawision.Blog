using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metawision.Blog.Models
{
    public class articleDTO
    {

        public int id { get; set; }
        [Required(ErrorMessage ="عنوان اجباری میباشد")]
        [DisplayName("عنوان")]
        public string title { get; set; }
        [Required(ErrorMessage = "توضیحات اجباری میباشد")]
        [DisplayName("توضیحات")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string body { get; set; }
        public int state { get; set; }
        [Required(ErrorMessage = "تصویر اجباری میباشد")]
        [DisplayName("تصویر")]
        public string pic { get; set; }
        public string idUser { get; set; }
        [DisplayName("لینک جایگزین")]
        public string customLink {get;set;}


    }
}