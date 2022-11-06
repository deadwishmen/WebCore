using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Areas.Admin.Models
{
    public class RateViewModel
    {
        public long ID { set; get; }
        public DateTime CreatedDate { set; get; }
        public long UserID { set; get; }
        public long FilmID { set; get; }
    }
}