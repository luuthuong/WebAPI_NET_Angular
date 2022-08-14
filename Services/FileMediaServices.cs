using Common.Helper;
using DTO.FileDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
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

        public async Task<bool> AddMultiFile(IEnumerable<IFormFile> files)
        {
            var newFiles = new List<FileModel>();
            foreach (var item in files)
            {
                using (var ms = new MemoryStream())
                {
                    if (item == null) return false;
                    await item.CopyToAsync(ms);
                    var fileByte = ms.ToArray();
                    var file = new FileModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = item.Headers.ContentType,
                        Name = item.FileName,
                        SrcFile = fileByte,
                        CreatedDate = DateTime.Now
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
                    Type =file.File.Headers.ContentType,
                    Name = file.File.FileName,
                    CreatedDate = DateTime.Now,
                    SrcFile = fileByte,
                    FileURL = file.FileUrl
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
                    Type = item.Type,
                    FileName = item.Name,
                };
                if (item.SrcFile != null)
                {
                    fileDTO.Size = item.SrcFile.Length;
                }
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
