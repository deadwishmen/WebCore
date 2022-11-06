using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("CategoryFilm")]
    public class CategoryFilm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { set; get; }
        [Column(TypeName = "nvarchar")]
        public string Name { set; get; }
        [Column(TypeName = "nvarchar")]
        public string Metatitle { set; get; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { set; get; }
        public long UserID { set; get; }
        public ICollection<Film> Films { set; get; }
        [ForeignKey("UserID")]
        public virtual User User { set; get; }
    }
}
