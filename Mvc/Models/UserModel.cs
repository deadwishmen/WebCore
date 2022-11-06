using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class UserModel
    {
        [Required(ErrorMessage ="Vui lòng nhập tên tài khoản")]
        public string Username { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string Name { set; get; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Vui lòng nhập ngày tháng năm sinh")]
        public DateTime BirthDay { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { set; get; }
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public Boolean Sex { set; get; }
        [Required(ErrorMessage = "Vui lòng Email")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Vui lòng loại người dùng")]
        public int UserType { set; get; }
    }
}