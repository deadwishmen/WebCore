using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IFilmRepository
    {
        long CountListTrendFilm();
        IEnumerable<Film> SelectTrendFilmPageHome();
        bool GetFilm(string Name);
        void DeleteByItem(Film id);
        long GetCountNewFilm();
        IEnumerable<Film> SelectByYear(ref long total, int year, int page, int pageSize);
        IEnumerable<Film> SelectFilmBySearch(ref long total, string q, int page, int pageSize);
        IEnumerable<Film> SelectListPage(long id, int page, int pageSize);
        IEnumerable<Film> SelectListTrendFilm();
        IEnumerable<Film> SelectByCategoryFilm(long categoryId);
        IEnumerable<Film> SelectCategoryFilmID(long categoryID);
        IEnumerable<Film> SelectListCategoryFilmID(long categoryID);
        IEnumerable<Film> SelectListViet(long categoryID);
        Film SelectByIdFilm(long FilmID);
        List<Film> SelectNewFilm();
        Film SelectById(object id);
        IEnumerable<Film> SelectAll();
        void Insert(Film obj);
        void Update(Film obj);
        void Delete(object id);
        void Save();
        long GetCount();
        IEnumerable<Film> GetPage(int page, int pageSize);
        bool CheckName(string Name);
    }
}
