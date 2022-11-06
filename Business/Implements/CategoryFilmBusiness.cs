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
    public class CategoryFilmBusiness : ICategoryFilmBusiness
    {
        private readonly ICategoryFilmRepository _categoryFilmRepository;
        private readonly IMapper _mapper;
        private readonly IFilmBusiness _filmBusiness;
        public CategoryFilmBusiness(ICategoryFilmRepository categoryFilmRepository,IFilmBusiness filmBusiness)
        {
            _categoryFilmRepository = categoryFilmRepository;
            _mapper = new ConstantMapper().GetMapper();
            _filmBusiness = filmBusiness;
        }

        public IEnumerable<CategoryFilmDTO> GetCategoryFilms()
        {
            var category = _categoryFilmRepository.SelectAll();
            var categoryDto = category.Select(item =>
                _mapper.Map<CategoryFilm, CategoryFilmDTO>(item)
            );
            return categoryDto;
        }
        public bool CreateCategoryFilm(CategoryFilmDTO categoryFilmDTO)
        {
            var categoryFilm = _mapper.Map<CategoryFilmDTO, CategoryFilm>(categoryFilmDTO);
            categoryFilm.CreatedDate = DateTime.Now;
            categoryFilm.Metatitle = new SetMetatitle().Metatitle(categoryFilm.Name);
            var check = _categoryFilmRepository.CheckCreate(categoryFilm);
            if (check == true)
            {
                _categoryFilmRepository.Insert(categoryFilm);
                _categoryFilmRepository.Save();
            }
            return check;
        }
        public IEnumerable<CategoryFilmDTO> GetNameCategoryFilm()
        {
            var category = _categoryFilmRepository.SelectAll();
            var Dto = category.Select(item => _mapper.Map<CategoryFilm, CategoryFilmDTO>(item));
            return Dto;
        }
        public CategoryFilmDTO GetCategoryFilmById(string id)
        {
            var Id = long.Parse(id);
            var categoryDto = _mapper.Map<CategoryFilm,CategoryFilmDTO>(_categoryFilmRepository.SelectById(Id));
            return categoryDto;
        }
        public bool EditCategoryFilm(CategoryFilmDTO categoryFilmDTO)
        {
            var categoryFilm = _mapper.Map<CategoryFilmDTO, CategoryFilm>(categoryFilmDTO);
            categoryFilm.Metatitle = new SetMetatitle().Metatitle(categoryFilm.Name);
            if ( _categoryFilmRepository.CheckName(categoryFilm.Name))
            {
                return false;
            }
            else
            {
                _categoryFilmRepository.Update(categoryFilm);
                return true;
            }

        }
        public void DeleteCategoryFilmByUserID(long id)
        {
            var category = _categoryFilmRepository.SelectAll();
            foreach(var item in category.Where(x => x.UserID == id))
            {
                _categoryFilmRepository.DeleteByItem(item);
                _categoryFilmRepository.Save();
            }
        }
        public void DeleteCategory(string id)
        {
            var category =_categoryFilmRepository.SelectById(long.Parse(id));
            _filmBusiness.DeleteFilmByCategoryFilmId(category.ID);
            _categoryFilmRepository.DeleteByItem(category);
            _categoryFilmRepository.Save();
        }
        public IEnumerable<CategoryFilmDTO> GetListPage(ref long total, int page, int pageSize)
        {
            total = _categoryFilmRepository.GetCount();
            var category = _categoryFilmRepository.GetPage(page, pageSize);
            var categoryDto = category.Select(item => _mapper.Map<CategoryFilm, CategoryFilmDTO>(item));
            return categoryDto;
        }
    }
}
