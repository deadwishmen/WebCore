using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IBusiness
{
    public interface IUserBusiness
    {
        int LoginUserAdmin(string userName, string passWord);
        IEnumerable<UserDTO> getUser();
        long getIdByUsername(string username);
        IEnumerable<UserDTO> GetListPage(ref long total, int page, int pageSize);
        int createUser(UserDTO userDTO);
        UserDTO GetUser(string id);
        int CheckEditUser(UserDTO userDTO);
        bool DeleteUser(string id);

    }
}
