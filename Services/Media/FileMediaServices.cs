﻿using Common;
using Common.Helper;
using DTO.FileDTO;
using Entities.Models.Media;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.Media;
using Services.Interface;
using Services.Interface.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Token.Interface;

namespace Services.Media
{
    public class FileMediaServices : IFileMediaServices
    {

        private readonly IFileMediaRepository _fileRepository;
        private readonly IFileCategoryRepository _fileCategoryRepository;
        private readonly ITokenService _tokenService;
        public FileMediaServices(IFileMediaRepository repository, IFileCategoryRepository fileCategoryRepository, ITokenService tokenService)
        {
            _fileRepository = repository;
            _fileCategoryRepository = fileCategoryRepository;
            _tokenService = tokenService;
        }

        public async Task<bool> AddFilesMedia(CreateFileRequest files)
        {
            var newFiles = new List<FileModel>();
            var newFileCategories = new List<FileCategoryModel>();
            if (files.File == null) return false;
            foreach (var item in files.File)
            {
                    var file = new FileModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = item.Headers.ContentType,
                        Name = item.FileName,
                        SrcFile = await FileTransfer.ConvertFileToByte(item),
                        CreatedDate = DateTime.Now
                    };

                    if (!string.IsNullOrEmpty(files.FileCategoryId))
                    {
                        newFileCategories.Add(new FileCategoryModel
                        {
                            CategoryId = files.FileCategoryId,
                            FileId = file.Id
                        });
                    }
                    newFiles.Add(file);
            }
            bool result = await _fileRepository.CreateRange(newFiles);
            return newFileCategories.Count > 0 && result ? await _fileCategoryRepository.CreateRange(newFileCategories) : result;
        }

        public async Task<bool> AddFileToFolder(IEnumerable<IFormFile> files)
        {
            string userId = _tokenService.ResolveUserId();

            var filesModels = new List<FileModel>();
            foreach (var file in files)
            {
               string filePath = await FileTransfer.WriteFileToFolder(file, "Resource/Images");
                var fileModel = new FileModel
                {
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                    FileURL = filePath,
                    Id = Guid.NewGuid().ToString(),
                    Name = file.FileName,
                    Type = file.ContentType
                };
                filesModels.Add(fileModel);
            }
            bool result = await _fileRepository.CreateRange(filesModels);
           return result;
        }

        public async Task<bool> DeleteFileMedia(DeleteFileRequest requests)
        {
            var filesDelete = new List<FileModel>();
            if (requests.IdFile == null) return false;
            foreach (var item in requests.IdFile)
            {
                var result = _fileRepository.GetByCondition(e => e.Id == item).FirstOrDefault();
                if (result != null)
                {
                    filesDelete.Add(result);
                }
                throw new Exception("File Not Found");
            }
            if (filesDelete.Any()) return await _fileRepository.DeleteRange(filesDelete);
            return false;
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
                    FileName = item.Name,
                    FileUrl = item.FileURL,
                    FileCategoryIds = _fileCategoryRepository.GetAll().Where(x => x.FileId == item.Id).Select(x => x.FileId)
                };
                if (item.SrcFile != null)
                {
                    fileDTO.Size = item.SrcFile.Length;
                }
                fileDTOs.Add(fileDTO);
            }
            return fileDTOs.OrderByDescending(x => x.CreatedDate);
        }

        public FileDTOModel? GetFileById(string Id)
        {
            var result = _fileRepository.GetByCondition(x => x.Id == Id).FirstOrDefault();
            if (result == null) return null;
            var file = new FileDTOModel
            {
                Id = result.Id,
                Type = result.Type,
                FileName = result.Name,
                Size = result.SrcFile?.Length,
                CreatedDate = result.CreatedDate,
                FileCategoryIds = _fileCategoryRepository.GetAll().Where(x => x.FileId == result.Id).Select(x => x.FileId)
            };
            return file;
        }

        public IEnumerable<FileDTOModel> SearchFile(SearchFileRequest request)
        {
            if (request == null) return GetAllFile();
            return GetAllFile().Where(x => (x.FileName == null || x.FileName.Contains(request.Name ?? ""))
                                            && (
                                                  request.CreatedDate == null && request.UpdatedDate == null
                                               || request.CreatedDate == null && request.UpdatedDate != null && x.UpdatedDate < request.UpdatedDate
                                               || request.CreatedDate != null && request.UpdatedDate == null && x.CreatedDate > request.CreatedDate
                                               || request.CreatedDate != null && request.UpdatedDate == null && (x.CreatedDate > request.CreatedDate || x.UpdatedDate < request.UpdatedDate))
                                            && (request.CategoryIds == null || x.FileCategoryIds != null && x.FileCategoryIds.Select(x => request.CategoryIds.Contains(x)).Any()));
        }

        public async Task<bool> UpdateFileMedia(UpdateFileRequest request)
        {
            if (request.CategoryIds != null)
            {
                var fileCategory = new List<FileCategoryModel>();
                foreach (var categoryId in request.CategoryIds)
                {
                    fileCategory.Add(new FileCategoryModel
                    {
                        CategoryId = categoryId,
                        FileId = request.FileId
                    });
                }
                return await _fileCategoryRepository.CreateRange(fileCategory);
            }
            return false;
        }
    }
}
