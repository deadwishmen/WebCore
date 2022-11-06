using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Areas.Admin.Models
{
    public class LoginModel
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public int TypeUser { set; get; }
    }
}