using Entities;
using Repositori.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IUserRepository 
    {
        int CheckUser(string username, string password);
        int checkUsername(string username);
        int checkEmail(string email);
        long getIdByUsername(string username);
        IEnumerable<User> SelectAll();
        User SelectById(object id);
        void DeleteByItem(User id);
        void Insert(User obj);
        void Update(User obj);
        void Delete(object id);
        void Save();
        IEnumerable<User> GetPage(int page, int pageSize);
        long GetCount();
    }
}
