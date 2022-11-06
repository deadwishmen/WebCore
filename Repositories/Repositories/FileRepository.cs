using Entities;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositori.Repositories
{
    public class FileRepository : GenericRepository<File>,IFileRepository
    {
        protected FilmDbContext db = null;
        public FileRepository()
        {
            db = new FilmDbContext();
        }
        public IEnumerable<File> SelectByFilmID(long FilmID)
        {
            return db.Files.Where(x => x.FilmID == FilmID).ToList();
        }
        public bool CheckFile(string link)
        {
            if (db.Files.SingleOrDefault(x => x.FileContent == link) != null)
            {
                return true;
            }
            return false;
        }
        public long GetCount()
        {
            return db.Files.Count();
        }
        public IEnumerable<File> GetPage(int page, int pageSize)
        {
            var model = db.Files.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
            return model;
        }
        public IEnumerable<File> GetFileByFilmId(long id)
        {
            var model = db.Files.Where(x => x.FilmID == id);
            return model;
        }
    }
}
