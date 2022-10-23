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
        [Required(ErrorMessage ="نام اجباری است")]
        [DisplayName("نام")]
        public string name { get; set; }

        [Required(ErrorMessage = "نام خانوادگی اجباری است")]
        [DisplayName("نام خانوادگی")]
        public string family { get; set; }

        [Required(ErrorMessage = "ایمیل اجباری است")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل معتبر نیست")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }
        [Phone]
        public string phone { get; set; }
        [Required(ErrorMessage = "متن پیام اجباری است")]
        [DisplayName("متن پیام")]
        public string txt { get; set; }

        public int securityCode { get; set; }
    }
}