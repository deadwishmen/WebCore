using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class FileViewModel
    {
        public long ID { set; get; }
        [Display(Name = "Loại dữ liệu")]
        [Required(ErrorMessage = "Vui lòng chọn loại dữ liệu")]
        public int FileType { set; get; }
        [Display(Name = "Đường link")]
        [Required(ErrorMessage = "Vui lòng nhập đường link file")]
        public string FileContent { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập Tag")]
        public string Tag { set; get; }
        [Required(ErrorMessage = "Vui lòng chọn film")]
        public long FilmID { set; get; }
        public bool Status { set; get; }
    }
}