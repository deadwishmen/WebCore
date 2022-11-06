using AutoMapper;
using Common.DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class AutoMapperConfiguration: Profile
    {
        public AutoMapperConfiguration()
        {
            EntityToDto();
            DtoToEntity();
        }
        private void EntityToDto()
        {
            CreateMap<User, UserDTO>();
            CreateMap<CategoryFilm, CategoryFilmDTO>();
            CreateMap<File, FileDTO>();
            CreateMap<Rate, RateDTO>();
            CreateMap<Film, FilmDTO>();
        }
        private void DtoToEntity()
        {
            CreateMap<UserDTO, User>();
            CreateMap<CategoryFilmDTO, CategoryFilm>();
            CreateMap<FileDTO, File>();
            CreateMap<RateDTO, Rate>();
            CreateMap<FilmDTO, Film>();
        }
    }
}
