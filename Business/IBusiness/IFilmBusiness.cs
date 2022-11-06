using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IBusiness
{
    public interface IFilmBusiness
    {
        IEnumerable<FilmDTO> SelectTrendFilmPageHome(ref long total);
        long GetCountNewFilm();
        bool CreateFilm(FilmDTO filmDTO);
        IEnumerable<FilmDTO> GetFilms();
        IEnumerable<FilmDTO> GetListViet(long categoryID);
        IEnumerable<FilmDTO> GetNewFilm();
        FilmDTO GetFilmById(string id);
        bool EditFilm(FilmDTO filmDTO);
        void DeleteFilmByUserId(long id);
        void DeleteFilm(string id);
        void DeleteFilmByCategoryFilmId(long categoryId);
        IEnumerable<FilmDTO> GetListFilmByCategory(string id);
        IEnumerable<FilmDTO> getListFilmByCategoryPage(ref long total, string id, int page, int pageSize);
        IEnumerable<FilmDTO> GetListPage(ref long total, int page, int pageSize);
        IEnumerable<FilmDTO> SelectListFileByCategoryFilmID(long id);
        IEnumerable<FilmDTO> SelectListTrendFilm();
        IEnumerable<FilmDTO> SelectSearch(ref long total, string q, int page, int pageSize);
        IEnumerable<FilmDTO> GetListFilmByYear(string year, ref long total, int page, int pageSize);
    }
}
