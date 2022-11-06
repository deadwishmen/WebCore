using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Areas.Admin.Models
{
    public class FilmViewModel
    {
        public long ID { set; get; }
        [StringLength(255)]
        [Display(Name = "Tên phim")]
        [Required(ErrorMessage = "Vui lòng nhập tên phim")]
        public string Name { set; get; }
        [StringLength(10000)]
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả phim")]
        public string Description { set; get; }
        [Display(Name = "Thời lượng")]
        [Required(ErrorMessage = "Vui lòng nhập thời lượng phim")]
        public long Duration { set; get; }
        [StringLength(20)]
        [Display(Name = "Chất lượng")]
        [Required(ErrorMessage = "Vui lòng nhập chất lượng phim")]
        public string Quality { set; get; }
        [StringLength(255)]
        [Display(Name = "Link trailer")]
        [Required(ErrorMessage = "Vui lòng nhập link trailer")]
        public string LinkTrailer { set; get; }
        public long CategoryFilmID { set; get; }
        public long View { set; get; }
        public string Metatitle { set; get; }
        public DateTime CreatedDate { set; get; }
        public long CreatedBy { set; get; }
        public bool Status { set; get; }
    }
}