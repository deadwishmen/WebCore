using Entities;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositori.Repositories
{
    public class RateRepository : GenericRepository<Rate>, IRateRepository
    {
        private readonly FilmDbContext _db;
        public RateRepository()
        {
            _db = new FilmDbContext();
        }
        public long GetCount()
        {
            return _db.Rates.Where(x => x.CreatedDate != null).Count();
        }
        public IEnumerable<Rate> GetPage(int page,int pageSize)
        {
            var model = _db.Rates.Where(x => x.CreatedDate != null).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
            return model;
        }
    }
}
