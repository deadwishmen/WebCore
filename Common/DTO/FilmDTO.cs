using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class FilmDTO
    {
        public long ID { set; get; }
        public string Name { set; get; }
        public string Metatitle { set; get; }
        public string Description { set; get; }
        public long Duration { set; get; }
        public string Quality { set; get; }
        public long View { set; get; }
        public string LinkTrailer { set; get; }

        public DateTime CreatedDate { set; get; }

        public long CreatedBy { set; get; }
        public bool Status { set; get; }
        public long CategoryFilmID { set; get; }
    }
}
