using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class FileDTO
    {
        public long ID { set; get; }
        public int FileType { set; get; }
        public string FileContent { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime UpdatedDate { set; get; }
        public long CreatedBy { set; get; }
        public string Tag { set; get; }
        public bool Status { set; get; }
        public long FilmID { set; get; }
    }
}
