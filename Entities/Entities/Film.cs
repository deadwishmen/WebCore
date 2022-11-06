using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Film")]
    public class Film
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { set; get; }
        [Column(TypeName = "nvarchar")]
        public string Name { set; get; }
        [Column(TypeName = "nvarchar")]
        public string Metatitle { set; get; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(1024)]
        public string Description { set; get; }
        public long Duration { set; get; }
        public string Quality { set; get; }
        public long View { set; get; }
        public string LinkTrailer { set; get; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { set; get; }
        public long CreatedBy { set; get; }
        public bool Status { set; get; }
        public long CategoryFilmID { set; get; }
        [ForeignKey("CategoryFilmID")]
        public virtual CategoryFilm CategoryFilm { set; get; }
        [ForeignKey("CreatedBy")]
        public virtual User User { set; get; }
        public ICollection<File> Files { set; get; }
        public ICollection<Rate> Rates { set; get; }
    }
}
