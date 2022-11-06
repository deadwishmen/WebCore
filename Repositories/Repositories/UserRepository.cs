using Entities;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositori.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly FilmDbContext db ;
        public UserRepository()
        {
            db = new FilmDbContext();
        }
        public int CheckUser(string username,string password)
        {
            var user = db.Users.SingleOrDefault(u => u.Username == username);
            if (user == null)
            {
                return 1;
            }else
            {
                if (user.Password != password)
                {
                    return 2;
                }
                else
                {
                    return (user.UserType + 2);
                }
            }
        }
        public int checkUsername(string username)
        {
            if (db.Users.SingleOrDefault(u => u.Username == username) != null)
                return 0;
            else
                return 1;
        }
        public int checkEmail(string email)
        {
            if (db.Users.SingleOrDefault(u=> u.Email == email) != null)
                return 0;
            else
                return 1;
        }
        public long getIdByUsername(string username)
        {
            var user = db.Users.SingleOrDefault(u => u.Username == username);
            return user.ID;
        }
        public long GetCount()
        {
            return db.Users.Count();
        }
        public IEnumerable<User> GetPage(int page,int pageSize)
        {
            var model = db.Users.Where(x => x.Status == 1).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
            return model;
        }
    }
}
