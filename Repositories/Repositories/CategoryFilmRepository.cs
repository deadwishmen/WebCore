using Entities;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositori.Repositories
{
    public class CategoryFilmRepository : GenericRepository<CategoryFilm>, ICategoryFilmRepository
    {
        private readonly FilmDbContext _db; 
        public CategoryFilmRepository()
        {
            _db = new FilmDbContext();
        }
        public bool CheckCreate(CategoryFilm categoryFilm)
        {
            if (_db.CategoryFilms.SingleOrDefault(c => c.Name == categoryFilm.Name) != null)
                return false;
            else
                return true;
        }
        public bool CheckName(string name)
        {
            if (_db.CategoryFilms.SingleOrDefault(x => x.Name == name) != null)
                return true;
            return false;
        }
        public long GetCount()
        {
            return _db.CategoryFilms.Count();
        }
        public IEnumerable<CategoryFilm> GetPage(int page, int pageSize)
        {
            var model = _db.CategoryFilms.Where(x => x.ID != 0).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
            return model;
        }
    }
}
