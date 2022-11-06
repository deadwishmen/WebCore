using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Commons
{
    public class ConstantIRepository
    {
        public static IUserRepository userRepository = null;
        public IUserRepository getIuserRepository()
        {
            return userRepository;
        }
    }
}
