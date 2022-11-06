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
    public class FileBusiness : IFileBusiness
    {
        private readonly IMapper _mapper;
        private readonly IFileRepository _fileRepository;
        private readonly IRateBusiness _rateBusiness;
        public FileBusiness(IFileRepository fileRepository,IRateBusiness rateBusiness)
        {
            _mapper = new ConstantMapper().GetMapper();
            _fileRepository = fileRepository;
            _rateBusiness = rateBusiness;
        }
        public IEnumerable<FileDTO> GetListFile()
        {
            var listFile = _fileRepository.SelectAll();
            var fileDTO = listFile.Select(
                    item => _mapper.Map<File, FileDTO>(item)
                );
            return fileDTO;
        }
        public void CreateFile(FileDTO fileDTO)
        {
            var file = _mapper.Map<FileDTO, File>(fileDTO);
            file.CreatedDate = DateTime.Now;
            file.Status = true;
            file.UpdatedDate = DateTime.Now;
            _fileRepository.Insert(file);
            _fileRepository.Save();
        }
        public FileDTO getFileById(string id)
        {
            var Id = long.Parse(id);
            var fileDto = _fileRepository.SelectById(Id);
            return _mapper.Map<File, FileDTO>(fileDto);
        }
        public int EditFile(FileDTO fileDTO)
        {
            var check = _fileRepository.CheckFile(fileDTO.FileContent);
            fileDTO.UpdatedDate = DateTime.Now;
            if (check == true)
                return 0;
            var file = _mapper.Map<FileDTO, File>(fileDTO);
            _fileRepository.Update(file);
            return 1;
        }
        public void DeleteFile(string id)
        {
            var item = _fileRepository.SelectById(long.Parse(id));
            _fileRepository.DeleteByItem(item);
            _fileRepository.Save();
        }
        public void DeleteFileByFilmId(long id)
        {
            var file = _fileRepository.SelectAll();
            foreach(var item in file.Where(x => x.FilmID == id))
            {
                _fileRepository.DeleteByItem(item);
                _fileRepository.Save();
            }
        }
        public IEnumerable<FileDTO> GetListPage(ref long total, int page, int pageSize)
        {
            total = _fileRepository.GetCount();
            var file = _fileRepository.GetPage(page, pageSize);
            var fileDto = file.Select(item => _mapper.Map<File, FileDTO>(item));
            return fileDto;
        }
        public IEnumerable<FileDTO> GetFileByFilmID(string filmId)
        {
            var id = long.Parse(filmId);
            var file = _fileRepository.GetFileByFilmId(id);
            var fileDto =file.Select(item => _mapper.Map<File, FileDTO>(item));
            return fileDto;
        }
        
    }
}
