using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class CategoryFilmDTO
    {
        public long ID { set; get; }
        public string Name { set; get; }
        public string Metatitle { set; get; }
        public DateTime CreatedDate { set; get; }
        public long UserID { set; get; }
    }
}
