using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext() : base("FilmDBConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        
        public DbSet<CategoryFilm> CategoryFilms { set; get; }
        public DbSet<File> Files { set; get; }
        public DbSet<Film> Films { set; get; }
        public DbSet<Rate> Rates { set; get; }
        public DbSet<User> Users { set; get; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>().HasRequired<User>(f => f.User).WithMany(u => u.Files).WillCascadeOnDelete(false);
            modelBuilder.Entity<File>().HasRequired<Film>(f => f.Film).WithMany(f => f.Files).WillCascadeOnDelete(false);
            modelBuilder.Entity<Film>().HasRequired<User>(f => f.User).WithMany(u => u.Films).WillCascadeOnDelete(false);
            modelBuilder.Entity<Film>().HasRequired<CategoryFilm>(f => f.CategoryFilm).WithMany(c => c.Films).WillCascadeOnDelete(false);
            modelBuilder.Entity<CategoryFilm>().HasRequired<User>(c => c.User).WithMany(u => u.CategoryFilms).WillCascadeOnDelete(false);
            modelBuilder.Entity<Rate>().HasRequired<User>(r => r.User).WithMany(u => u.Rates).WillCascadeOnDelete(false);
            modelBuilder.Entity<Rate>().HasRequired<Film>(R => R.Film).WithMany(f => f.Rates).WillCascadeOnDelete(false);
        }
    }
}
