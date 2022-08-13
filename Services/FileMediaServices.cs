using DTO.FileDTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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
            var newFiles = new List<FileModel>();
            foreach (var item in files)
            {
                if (item.File == null) return false;
                using(var ms = new MemoryStream())
                {
                    item.File.CopyToAsync(ms);
                    var fileByte = ms.ToArray();

                    var file = new FileModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = item.Type,
                        Name = item.FileName != null ? item.FileName : item.File.FileName,
                        Image = fileByte,
                        ImageURL = item.FileUrl,
                        CreatedDate = DateTime.Today
                    };
                    newFiles.Add(file);
                }
            }
            return _repository.CreateRange(newFiles);
        }

        public bool AddFileMedia(CreateFileRequest file)
        {
            using (var ms = new MemoryStream())
            {
                if (file.File == null) return false;
                file.File.CopyToAsync(ms);
                var fileByte = ms.ToArray();

                var newFile = new FileModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = file.Type,
                    Name = file.FileName != null ? file.FileName : file.File.FileName,
                    CreatedDate = DateTime.Now,
                    Image = fileByte,
                    ImageURL = file.FileUrl
                };
                return _repository.Create(newFile);
            }
        }

        public bool DeleteFileMedia(DeleteFileRequest requests)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileDTOModel> GetAllFile()
        {
            var files = _repository.GetAll().ToList();
            var fileDTOs = new List<FileDTOModel>();
            foreach (var item in files)
            {
                var fileDTO = new FileDTOModel
                {
                    Id = item.Id,
                    FileName = item.Name
                };
                fileDTOs.Add(fileDTO);
            }
            return fileDTOs;
        }

        public FileDTOModel GetFileById(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
