using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IBusiness
{
    public interface ICategoryFilmBusiness
    {
        IEnumerable<CategoryFilmDTO> GetCategoryFilms();
        bool CreateCategoryFilm(CategoryFilmDTO categoryFilmDTO);
        IEnumerable<CategoryFilmDTO> GetNameCategoryFilm();
        CategoryFilmDTO GetCategoryFilmById(string id);
        bool EditCategoryFilm(CategoryFilmDTO categoryFilmDTO);
        void DeleteCategoryFilmByUserID(long id);
        void DeleteCategory(string id);
        IEnumerable<CategoryFilmDTO> GetListPage(ref long total, int page, int pageSize);
    }
}
