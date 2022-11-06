using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class RateDTO
    {
        public long ID { set; get; }
        public DateTime CreatedDate { set; get; }
        public long UserID { set; get; }
        public long FilmID { set; get; }
    }
}
