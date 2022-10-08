using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models
{
    public class tagDTO
    {
        public int id { get; set; }
        public int idArticle { get; set; }
        [Required(ErrorMessage ="عنوان برچسب وارد نشده است")]
        [DisplayName("عنوان برچسب")]
        public string title { get; set; }

    }
}