using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models.DTO
{
    public class imageDTO
    {
        
   
            public int Id { get; set; }
            [Required(ErrorMessage = "فایلی انتخاب نشده است")]
        [DisplayName(" ")]
        public string pic { get; set; }
        
    }
}