using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Metawision.Blog.Models
{
    public class contactUsDTO
    {
        public int id { get; set; }
        //public int state { get; set; }

        [Required(ErrorMessage = "نام اجباری است")]
        //[DisplayName(".")]
        public string name { get; set; }

        [Required(ErrorMessage = "نام خانوادگی اجباری است")]
        //[DisplayName(".")]
        public string family { get; set; }

        [Required(ErrorMessage = "ایمیل اجباری است")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل معتبر نیست")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        //[DisplayName(".")]

        public string email { get; set; }
        [Phone]
        //[DisplayName(".")]

        public string phone { get; set; }
        [Required(ErrorMessage = "متن پیام اجباری است")]
        //[DisplayName(".")]
        public string txt { get; set; }

    }
}