using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IBusiness
{
    public interface IRateBusiness
    {
        IEnumerable<RateDTO> rateDTOs();
        void DeleteRateByUserID(long id);
        void DeleteRate(string id);
        void DeleteRateByFilmId(long id);
        IEnumerable<RateDTO> GetListPage(ref long total, int page, int pageSize);
    }
}
