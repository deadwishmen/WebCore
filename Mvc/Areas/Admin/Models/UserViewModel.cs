using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Areas.Admin.Models
{
    public class UserViewModel
    {
        public long ID { set; get; }
        [StringLength(255)]
        [Required(ErrorMessage = "Vui lòng nhập tài khoản")]
        [Display(Name = "Tài khoản")]
        public string Username { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(20)]
        [MinLength(2, ErrorMessage ="Vui lòng nhập ít nhất 2 kí tự")]
        [Display(Name= "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        [StringLength(255)]
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập ngày tháng năm sinh")]
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { set; get; }
        [StringLength(20)]
        [MinLength(2,ErrorMessage = "Vui lòng nhập ít nhất 2 số")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { set; get; }
        public Boolean Sex { set; get; }
        [StringLength(255)]
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        public string Email { set; get; }
        public int Status { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập loại user")]
        public int UserType { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}