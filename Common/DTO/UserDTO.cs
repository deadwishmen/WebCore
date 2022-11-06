using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class UserDTO
    {
        public long ID { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string Name { set; get; }
        public DateTime BirthDay { set; get; }
        public DateTime CreatedDate { set; get; }
        public string Phone { set; get; }
        public Boolean Sex { set; get; }
        public string Email { set; get; }
        public int Status { set; get; }
        public int UserType { set; get; }
    }
}
