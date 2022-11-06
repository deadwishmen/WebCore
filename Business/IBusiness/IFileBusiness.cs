using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IBusiness
{
    public interface IFileBusiness
    {
        IEnumerable<FileDTO> GetListFile();
        void CreateFile(FileDTO fileDTO);
        FileDTO getFileById(string id);
        int EditFile(FileDTO fileDTO);
        void DeleteFile(string id);
        void DeleteFileByFilmId(long id);
        IEnumerable<FileDTO> GetListPage(ref long total, int page, int pageSize);
        IEnumerable<FileDTO> GetFileByFilmID(string filmId);
    }
}
