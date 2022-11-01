using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models.DTO
{
    public class categoryDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage ="دسته بندی انتخاب نشده است")]
        [DisplayName("دسته بندی ")]
        public int idParent { get; set; }
        [Required(ErrorMessage ="عنوان وارد نشده است")]
        [DisplayName("عنوان")]
        public string title { get; set; }
    }
}