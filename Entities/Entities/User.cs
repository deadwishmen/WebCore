using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("User")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public long ID { set; get; }
        [StringLength(50)]
        public string Username { set; get; }
        [StringLength(50)]
        public string Password { set; get; }
        [Column(TypeName = "nvarchar")]
        public string Name { set; get; }
        [Column(TypeName = "Datetime2")]
        public DateTime BirthDay { set; get; }

        [Column(TypeName = "Datetime2")]
        public DateTime CreatedDate { set; get; }
        [StringLength(20)]
        public string Phone { set; get; }
        public Boolean Sex { set; get; }
        public string Email { set; get; }
        public int UserType { set; get; }
        public int Status { set; get; }
        public Boolean IsDeleted { set; get; }
        public Boolean IsActive { set; get; }
        public ICollection<Film> Films { set; get; }
        public ICollection<Rate> Rates { set; get; }
        public ICollection<CategoryFilm> CategoryFilms { set; get; }
        public ICollection<File> Files { set; get; }
    }
}
