using AutoMapper;
using Business.IBusiness;
using Business.Tool;
using Common.Commons;
using Common.DTO;
using Entities;
using Repositori.Repositories;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        private readonly IRateBusiness _rateBusiness;
        private readonly IFilmBusiness _filmBusiness;
        private readonly ICategoryFilmBusiness _categoryFimBusiness;
        public UserBusiness(IUserRepository userRepository,IFileRepository fileRepository,
            IRateBusiness rateBusiness,IFilmBusiness filmBusiness,ICategoryFilmBusiness categoryFilmBusiness)
        {
            _mapper = new ConstantMapper().GetMapper();
            _userRepository = userRepository;
            _fileRepository = fileRepository;
            _rateBusiness = rateBusiness;
            _filmBusiness = filmBusiness;
            _categoryFimBusiness = categoryFilmBusiness;
        }
        public int LoginUserAdmin(string userName,string passWord)
        {
            passWord = new SHA1().HashPassword(passWord);
            var checkUser = _userRepository.CheckUser(userName, passWord);
            return checkUser;
        }
        public IEnumerable<UserDTO> getUser()
        {
            var user = _userRepository.SelectAll();
            var userDto = user.Select(item => _mapper.Map<User, UserDTO>(item));
            return userDto;
        }
        public long getIdByUsername(string username)
        {
            return _userRepository.getIdByUsername(username);
        }
        public IEnumerable<UserDTO> GetListPage(ref long total,int page, int pageSize)
        {
            total = _userRepository.GetCount();
            var user = _userRepository.GetPage(page,pageSize);
            var userDto = user.Select(item => _mapper.Map<User, UserDTO>(item));
            return userDto;
        }
        public int createUser(UserDTO userDTO)
        {
            var user = _mapper.Map<UserDTO, User>(userDTO);
            user.Password = new SHA1().HashPassword(user.Password);
            user.CreatedDate = DateTime.Now;
            user.IsActive = true;
            user.IsDeleted = false;
            user.Status = 1;
            var checkUsername = _userRepository.checkUsername(user.Username);
            var checkEmail = _userRepository.checkEmail(user.Email);
            if (checkUsername == 1)
            {
                if (checkEmail == 1)
                {
                    _userRepository.Insert(user);
                    _userRepository.Save();
                    return 2;
                }
                else
                    return 1;
            }
            else
            {
                return 0;
            }
        }
        public UserDTO GetUser(string id)
        {
            long Id = long.Parse(id);
            var user = _userRepository.SelectById(Id);
            var userDto = _mapper.Map<User, UserDTO>(user);
            return userDto;
        }
        public int CheckEditUser(UserDTO userDTO)
        {
            var user = _mapper.Map<UserDTO, User>(userDTO);
            if (_userRepository.checkEmail(user.Email) == 0)
            {
                return 0;
            }
            else
            {
                _userRepository.Update(user);
                return 1;
            }
        }
        public bool DeleteUser(string id)
        {
            var user = _userRepository.SelectById(long.Parse(id));
            if (user.UserType == 2)
            {
                _rateBusiness.DeleteRateByUserID(user.ID);
                _userRepository.DeleteByItem(user);
                _userRepository.Save();
            }
            else
            {
                _rateBusiness.DeleteRateByUserID(user.ID);
                _filmBusiness.DeleteFilmByUserId(user.ID);
                _categoryFimBusiness.DeleteCategoryFilmByUserID(user.ID);
                _userRepository.DeleteByItem(user);
                _userRepository.Save();
            }
            return true;
        }
    }
}
