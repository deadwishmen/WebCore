using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IFileRepository
    {
        void DeleteByItem(File id);
        IEnumerable<File> GetFileByFilmId(long id);
        IEnumerable<File> SelectByFilmID(long FilmID);
        bool CheckFile(string link);
        long GetCount();
        IEnumerable<File> SelectAll();
        IEnumerable<File> GetPage(int page, int pageSize);
        File SelectById(object id);
        void Insert(File obj);
        void Update(File obj);
        void Delete(object id);
        void Save();
        
    }
}
