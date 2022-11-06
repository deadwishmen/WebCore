using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Rate")]
    public class Rate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long ID { set; get; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { set; get; }

        public long UserID { set; get; }
        public long FilmID { set; get; }
        [ForeignKey("UserID")]
        public virtual User User { set; get; }
        [ForeignKey("FilmID")]
        public virtual Film Film { set; get; }
    }
}
