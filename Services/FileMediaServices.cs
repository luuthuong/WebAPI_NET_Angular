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

        private readonly IFileMediaRepository _fileRepository;
        private readonly IFileCategoryRepository _categoryRepository;
        public FileMediaServices(IFileMediaRepository repository, IFileCategoryRepository categoryRepository)
        {
            _fileRepository = repository;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> AddMultiFile(CreateFileRequest  files)
        {
            var newFiles = new List<FileModel>();
            var newFileCategories = new List<FileCategoryModel>();
            if (files.File == null) return false;
            foreach (var item in files.File)
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

                    if (!String.IsNullOrEmpty(files.FileCategoryId))
                    {
                        newFileCategories.Add(new FileCategoryModel
                        {
                            CategoryId = files.FileCategoryId,
                            FileId = file.Id
                        });
                    }
                    newFiles.Add(file);
                }
            }
            bool result = _fileRepository.CreateRange(newFiles);
            return newFileCategories.Count > 0 && result ? _categoryRepository.CreateRange(newFileCategories) : result;
        }

        public bool AddFileMedia(CreateFileRequest file)
        {

            //using (var ms = new MemoryStream())
            //{
            //    if (file.File == null) return false;
            //    file.File.CopyToAsync(ms);
            //    var fileByte = ms.ToArray();

            //    var newFile = new FileModel
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Type =file.File.Headers.ContentType,
            //        Name = file.File.FileName,
            //        CreatedDate = DateTime.Now,
            //        SrcFile = fileByte,
            //        FileURL = file.FileUrl
            //    };
            //    return _repository.Create(newFile);
            //}
            return false;
        }

        public bool DeleteFileMedia(DeleteFileRequest requests)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileDTOModel> GetAllFile()
        {
            var files = _fileRepository.GetAll().ToList();
            var fileDTOs = new List<FileDTOModel>();
            foreach (var item in files)
            {
                var fileDTO = new FileDTOModel
                {
                    Id = item.Id,
                    Type = item.Type,
                    CreatedDate = item.CreatedDate,
                    FileName = item.Name
                };
                if (item.SrcFile != null)
                {
                    fileDTO.Size = item.SrcFile.Length;
                }
                fileDTOs.Add(fileDTO);
            }
            return fileDTOs.OrderByDescending(x=>x.CreatedDate);
        }

        public FileDTOModel GetFileById(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
