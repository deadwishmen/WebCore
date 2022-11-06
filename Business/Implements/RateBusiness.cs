using AutoMapper;
using Business.IBusiness;
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
    public class RateBusiness : IRateBusiness
    {
        private readonly IRateRepository _rateRepository;
        private readonly IMapper _mapper;

        public RateBusiness(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository;
            _mapper = new ConstantMapper().GetMapper();
        }

        public IEnumerable<RateDTO> rateDTOs()
        {
            var rate = _rateRepository.SelectAll();
            var rateDto = rate.Select(item => _mapper.Map<Rate, RateDTO>(item));
            return rateDto;
        }
        public void DeleteRateByUserID(long id)
        {
            var Rate = _rateRepository.SelectAll();
            foreach(var item in Rate.Where(x => x.UserID == id))
            {
                _rateRepository.DeleteByItem(item);
                _rateRepository.Save();
            }
        }
        public void DeleteRate(string id)
        {
            var Rate = _rateRepository.SelectById(long.Parse(id));
            _rateRepository.DeleteByItem(Rate);
            _rateRepository.Save();
        }
        public void DeleteRateByFilmId(long id)
        {
            var rate = _rateRepository.SelectAll();
            foreach(var item in rate.Where(x => x.FilmID == id))
            {
                _rateRepository.DeleteByItem(item);
                _rateRepository.Save();
            }
        }
        public IEnumerable<RateDTO> GetListPage(ref long total, int page, int pageSize)
        {
            total = _rateRepository.GetCount();
            var rate = _rateRepository.GetPage(page, pageSize);
            var rateDto = rate.Select(item => _mapper.Map<Rate, RateDTO>(item));
            return rateDto;
        }
    }
}
