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

namespace Business.Implements
{
    public class FilmBusiness : IFilmBusiness
    {
        private readonly IMapper _mapper;
        private readonly IFilmRepository _filmRepository;
        private readonly SetMetatitle _setMetatitle;
        private readonly IRateBusiness _rateBusiness;
        private readonly IFileBusiness _fileBusiness;
        public FilmBusiness(IFilmRepository filmRepository,IRateBusiness rateBusiness,IFileBusiness fileBusiness)
        {
            _mapper = new ConstantMapper().GetMapper();
            _filmRepository = filmRepository;
            _setMetatitle = new SetMetatitle();
            _fileBusiness = fileBusiness;
            _rateBusiness = rateBusiness;
        }
        public bool CreateFilm(FilmDTO filmDTO)
        {
            var film = _mapper.Map<FilmDTO, Film>(filmDTO);
            film.CreatedDate = DateTime.Now;
            film.Metatitle = _setMetatitle.Metatitle(film.Name);
            film.Status = true;
            film.View = 0;
            if (_filmRepository.GetFilm(film.Name))
            {
                _filmRepository.Insert(film);
                _filmRepository.Save();
                return true;
            }
            return false;
        }
        public IEnumerable<FilmDTO> GetFilms()
        {
            var film = _filmRepository.SelectAll();
            var filmDto = film.Select(
                item => _mapper.Map<Film, FilmDTO>(item)
                );
            return filmDto;
        }
        public IEnumerable<FilmDTO> GetListViet(long categoryID)
        {
            var listFilm = _filmRepository.SelectListViet(categoryID);
            var filmDto = listFilm.Select(
                    item => _mapper.Map<Film, FilmDTO>(item)
                    );
            return filmDto;
        }
        public IEnumerable<FilmDTO> GetNewFilm()
        {
            var listFilm = _filmRepository.SelectNewFilm();
            var filmDto = listFilm.Select(
                    item => _mapper.Map<Film, FilmDTO>(item)
                    );
            return filmDto;
        }
        public FilmDTO GetFilmById(string id)
        {
            var Id = long.Parse(id);
            var Film = _filmRepository.SelectById(Id);
            long minutes = Film.Duration / 60;
            return _mapper.Map<Film, FilmDTO>(Film);
        }
        public bool EditFilm(FilmDTO filmDTO)
        {
            var film = _mapper.Map<FilmDTO, Film>(filmDTO);
            var checkName = _filmRepository.CheckName(film.Name);
            if (checkName == true)
            {
                return false;
            }
            film.Metatitle = _setMetatitle.Metatitle(film.Name);
            _filmRepository.Update(film);
            return true;
        }
        public void DeleteFilmByUserId(long id)
        {
            var film = _filmRepository.SelectAll();
            foreach (var item in film.Where(x => x.CreatedBy == id))
            {
                _fileBusiness.DeleteFileByFilmId(item.ID);
                _filmRepository.DeleteByItem(item);
                _filmRepository.Save();
            }
        }
        public void DeleteFilm(string id)
        {
            var film = _filmRepository.SelectById(long.Parse(id));
            _rateBusiness.DeleteRateByFilmId(film.ID);
            _fileBusiness.DeleteFileByFilmId(film.ID);
            _filmRepository.DeleteByItem(film);
            _filmRepository.Save();
        }
        public void DeleteFilmByCategoryFilmId(long categoryId)
        {
            var film = _filmRepository.SelectAll();
            foreach (var item in film.Where(x => x.CategoryFilmID == categoryId))
            {
                _rateBusiness.DeleteRateByFilmId(item.ID);
                _fileBusiness.DeleteFileByFilmId(item.ID);
                _filmRepository.DeleteByItem(item);
                _filmRepository.Save();
            }
        }
        public IEnumerable<FilmDTO> GetListFilmByCategory(string id)
        {
            var Id = long.Parse(id);
            var film = _filmRepository.SelectListCategoryFilmID(Id);
            var filmDto = film.Select(item => _mapper.Map<Film, FilmDTO>(item));
            return filmDto;
        }
        public IEnumerable<FilmDTO> getListFilmByCategoryPage(ref long total,string id,int page,int pageSize)
        {
            var Id = long.Parse(id);
            var film = _filmRepository.SelectListPage(Id, page, pageSize);
            var selectFilm = _filmRepository.SelectByCategoryFilm(Id);
            total = selectFilm.Count();
            var filmDto = film.Select(item => _mapper.Map<Film, FilmDTO>(item));
            return filmDto;
        }
        public IEnumerable<FilmDTO> GetListPage(ref long total, int page, int pageSize)
        {
            total = _filmRepository.GetCount();
            var film = _filmRepository.GetPage(page, pageSize);
            var filmDto = film.Select(item => _mapper.Map<Film, FilmDTO>(item));
            return filmDto;
        }
        public IEnumerable<FilmDTO> SelectListFileByCategoryFilmID(long id)
        {
            var film = _filmRepository.SelectByCategoryFilm(id);
            var filmDto = film.Select(item => _mapper.Map<Film, FilmDTO>(item));
            return filmDto;
        }
        public IEnumerable<FilmDTO> SelectListTrendFilm()
        {
            var film = _filmRepository.SelectListTrendFilm();
            var filmDto = film.Select(item => _mapper.Map<Film, FilmDTO>(item));
            return filmDto;
        }
        public IEnumerable<FilmDTO> SelectSearch(ref long total,string q,int page,int pageSize)
        {
            var film = _filmRepository.SelectFilmBySearch(ref total,q, page, pageSize);
            var filmDto = film.Select(item => _mapper.Map<Film, FilmDTO>(item));
            return filmDto;
        }
        public IEnumerable<FilmDTO> GetListFilmByYear(string year,ref long total,int page,int pageSize)
        {
            int Year = int.Parse(year);
            var film = _filmRepository.SelectByYear(ref total, Year, page, pageSize);
            var filmDto = film.Select(item => _mapper.Map<Film, FilmDTO>(item));
            return filmDto;
        }
        public long GetCountNewFilm()
        {
            return _filmRepository.GetCountNewFilm();
        }
        public IEnumerable<FilmDTO> SelectTrendFilmPageHome(ref long total)
        {
            total = _filmRepository.CountListTrendFilm();
            var film = _filmRepository.SelectTrendFilmPageHome();
            var filmDto = film.Select(item => _mapper.Map<Film, FilmDTO>(item));
            return filmDto;
        }
    }
}
