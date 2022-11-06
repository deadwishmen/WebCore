using Entities;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositori.Repositories
{
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        protected FilmDbContext db = null;
        public FilmRepository()
        {
            db = new FilmDbContext();
        }
        public bool GetFilm(string Name)
        {
            if (db.Films.SingleOrDefault(f => f.Name == Name) == null)
                return true;
            else
                return false;
        }
        public List<Film> SelectNewFilm()
        {
            var model = db.Films.Where(x => x.ID != 0).OrderByDescending(x => x.CreatedDate).Take(8).ToList();
            return model;
        }

        public long GetCountNewFilm()
        {
            return db.Films.Where(x => x.ID != 0).OrderByDescending(x => x.CreatedDate).Take(8).Count();
        }
        public IEnumerable<Film> SelectCategoryFilmID(long categoryID)
        {
            return db.Films.Where(x => x.CategoryFilmID == categoryID).ToList();
        }
        public IEnumerable<Film> SelectListCategoryFilmID(long categoryID)
        {
            return db.Films.Where(x => x.CategoryFilmID == categoryID).Take(8).ToList();
        }
        public IEnumerable<Film> SelectListViet(long categoryID)
        {
            return db.Films.Where(x => x.CategoryFilmID == categoryID).Take(8).ToList();
        }
        public bool CheckName(string Name)
        {
            if (db.Films.SingleOrDefault(x => x.Name == Name) == null)
                return true;
            return false;
        }
        public Film SelectByIdFilm (long FilmID)
        {
            return db.Films.SingleOrDefault(x => x.ID == FilmID);
        }
        public long GetCount()
        {
            return db.Films.Count();
        }
        public IEnumerable<Film> GetPage(int page, int pageSize)
        {
            var model = db.Films.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
            return model;
        }
        public IEnumerable<Film> SelectByCategoryFilm(long categoryId)
        {
            return db.Films.Where(x => x.CategoryFilmID == categoryId).ToList();
        }
        public IEnumerable<Film> SelectListTrendFilm()
        {
            return db.Films.Where(x => x.Status == true).OrderBy(x => x.View).Take(2);
        }
        public IEnumerable<Film> SelectTrendFilmPageHome()
        {
            return db.Films.Where(x => x.Status == true).OrderBy(x => x.View).Take(8).ToList();
        }
        public long CountListTrendFilm()
        {
            return db.Films.Where(x => x.Status == true).OrderBy(x => x.View).Take(8).Count();
        }
        public IEnumerable<Film> SelectListPage(long id,int page,int pageSize)
        {
            return db.Films.Where(x => x.CategoryFilmID == id).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        }
        public IEnumerable<Film> SelectFilmBySearch(ref long total,string q,int page,int pageSize)
        {
            total = db.Films.Where(x => x.Name.Contains(q)).Count();
            return db.Films.Where(x => x.Name.Contains(q)).OrderBy(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        }
        public IEnumerable<Film> SelectByYear(ref long total,int year,int page,int pageSize)
        {
            var list = db.Films.Where(x => x.CreatedDate.Year == year).OrderBy(x => x.CreatedDate).ToList();
            total = list.Count();
            var model = db.Films.Where(x => x.CreatedDate.Year == year).OrderBy(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }
    }
}
