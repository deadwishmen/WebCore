using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface ICategoryFilmRepository
    {
        long GetCount();
        void DeleteByItem(CategoryFilm id);
        IEnumerable<CategoryFilm> GetPage(int page, int pageSize);
        bool CheckCreate(CategoryFilm categoryFilm);
        IEnumerable<CategoryFilm> SelectAll();
        bool CheckName(string name);
        CategoryFilm SelectById(object id);
        void Insert(CategoryFilm obj);
        void Update(CategoryFilm obj);
        void Delete(object id);
        void Save();
    }
}
