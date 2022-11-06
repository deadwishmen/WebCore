using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IRateRepository
    {
        IEnumerable<Rate> SelectAll();
        Rate SelectById(object id);
        void DeleteByItem(Rate id);
        void Insert(Rate obj);
        void Update(Rate obj);
        void Delete(object id);
        void Save();
        IEnumerable<Rate> GetPage(int page, int pageSize);
        long GetCount();
    }
}
