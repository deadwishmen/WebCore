using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("File")]
    public class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long ID { set; get; }
        public int FileType { set; get; }
        public string FileContent { set; get; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { set; get; }
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedDate { set; get; }
        public long CreatedBy { set; get; }
        public string Tag { set; get; }
        public bool Status { set; get; }
        public long FilmID { set; get; }
        [ForeignKey("CreatedBy")]
        public virtual User User { set; get; }
        [ForeignKey("FilmID")]
        public virtual Film Film { set; get; }
    }
}
