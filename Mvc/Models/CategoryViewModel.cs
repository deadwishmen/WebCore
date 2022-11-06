using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class CategoryViewModel
    {
        public long ID { set; get; }
        [StringLength(255)]
        [Required(ErrorMessage = "Vui lòng nhập tên loại phim")]
        [Display(Name = "Tên loại phim")]
        public string Name { set; get; }

        public string Metatitle { set; get; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { set; get; }
    }
}