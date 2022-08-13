using DTO.FileDTO;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FileMediaServices : IFileMediaServices
    {

        private readonly IFileMediaRepository _repository;
        public FileMediaServices(IFileMediaRepository repository){
            _repository = repository;
        }

        public bool AddFileMedia(IEnumerable<CreateFileRequest> files)
        {
            throw new NotImplementedException();
        }

        public bool AddFileMedia(CreateFileRequest file)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFileMedia(DeleteFileRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileDTOModel> GetAllFile()
        {
            //var files = _repository.GetAll().ToList();
            //var fileDTOs = new List<FileDTOModel>();
            //foreach (var item in files)
            //{
            //    var fileDTO = new FileDTOModel
            //    {
            //        Id = item.Id,
            //        FileName = item.Name
            //    }
            //}
            return null;
        }

        public FileDTOModel GetFileById(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
