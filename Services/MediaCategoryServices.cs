using DTO.FileDTO;
using DTO.MediaCategoryDTO;
using Entities.Models;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MediaCategoryServices : IMediaCategoryServices
    {

        private readonly IMediaCategoryRepository _repostiory;
        private readonly IFileMediaRepository _fileRepository;
        private readonly IFileCategoryRepository _fileCategoryRepository;
        public MediaCategoryServices(IMediaCategoryRepository repostiory, 
                                     IFileMediaRepository fileRepository,
                                     IFileCategoryRepository fileCategoryRepository)
        {
            _repostiory = repostiory;
            _fileRepository = fileRepository;
            _fileCategoryRepository = fileCategoryRepository;
        }

        public bool Create(CreateMediaCategoryRequest request)
        {
            var newMediaCategory = new MediaCategoryModel
            {
                CreatedDate = DateTime.Now,
                Description = request.Description,
                Id = Guid.NewGuid().ToString(),
                Name = request.Name
            };
            if (!string.IsNullOrEmpty(request.ParentId))
            {
                newMediaCategory.ParentId = request.ParentId;
            }
            var result = _repostiory.Create(newMediaCategory);
            _repostiory.Save();
            return result;
        }

        public async Task<bool> Delete(string Id)
        {
           var category = _repostiory.GetByCondition(item => item.Id == Id).ToList().FirstOrDefault();
           if (category == null) return false;

           var childrens = _repostiory.GetByCondition(x=>x.ParentId == category.Id);
           if (childrens.Any())
            {
                await _repostiory.DeleteRange(childrens);
            }
           var result = _repostiory.Delete(category);
           return result;
        }

        public IEnumerable<MediaCategoryDTOModel> GetAll()
        {
            var categories = _repostiory.GetAll();
            var categoryModels = new List<MediaCategoryDTOModel>();
            foreach (var item in categories)
            {
                var category = new MediaCategoryDTOModel
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                    Name = item.Name,
                    Description = item.Description,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    UpdatedDate = item.UpdatedDate != DateTime.MinValue ? item.UpdatedDate : null
                };
                categoryModels.Add(category);
            }
            return categoryModels;
        }

        public MediaCategoryDTOModel GetById(string Id)
        {
           var category =  _repostiory.GetByCondition(item => item.Id == Id).FirstOrDefault();
           if (category == null) return new MediaCategoryDTOModel();

            var categoryModel = new MediaCategoryDTOModel
            {
                Id = category.Id,
                ParentId = category.ParentId,
                Name = category.Name,
                Description = category.Description,
                CreatedBy = category.CreatedBy,
                CreatedDate = category.CreatedDate,
                UpdatedDate = category.UpdatedDate
            };
            return categoryModel;
        }

        public IEnumerable<MediaCategoryDTOModel> GetChildren(string? Id)
        {
            var result = _repostiory.GetByCondition(item => item.ParentId == Id);
            var childrens = result.Select(item => new MediaCategoryDTOModel
            {
                Id = item.Id,
                ParentId = item.ParentId,
                Name = item.Name,
                Description = item.Description,
                CreatedBy = item.CreatedBy,
                CreatedDate =item.CreatedDate,
                UpdatedDate = item.UpdatedDate
            });
            return childrens;
        }

        public async Task<bool> Update(UpdateMediaCategoryRequest request)
        {
            var category = _repostiory.GetByCondition(item => item.Id == request.Id).FirstOrDefault();
            if(category == null) return false;
            category.UpdatedDate = DateTime.Now;
            category.Description = request.Description;
            category.Name = request.Name;
            category.ParentId = request.ParentId;
            if (request.Files != null)
            {
                var filesCategory = request.Files.Select(x=> new FileCategoryModel
                {
                    CategoryId = category.Id,
                    FileId = x
                });
                await _fileCategoryRepository.CreateRange(filesCategory);
            }
            bool result = _repostiory.Update(category);
            return result;
        }

        public GetFilesInCategoryDTOModel GetFilesInCategory(GetFilesInCategoryRequest request)
        {
            var result = new GetFilesInCategoryDTOModel();
            var category = _repostiory.GetByCondition(x => x.Id == request.Id).FirstOrDefault();
            result.Id = category?.Id;
            result.Name = category?.Name;
            if (!string.IsNullOrEmpty(result.Id))
            {
                var fileCategory = _fileCategoryRepository.GetByCondition(x => x.CategoryId == result.Id).Select(x=>x.FileId);
                var files = _fileRepository.GetByCondition(x => fileCategory.Contains(x.Id)).Select(x=>new FileDTOModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    FileName = x.Name,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                });
                result.Files = files;
            }
            return result;
        }

        public IEnumerable<MediaCategoryDTOModel> SearchCategory(SearchCategoryRequest request)
        {
            var result = this.GetAll().Where(x=> (x.Name == null || x.Name.Contains(request.Name??""))
                                               &&(request.ParentId == null || request.ParentId == x.ParentId)
                                               &&(
                                                    (request.CreatedDate == null && request.UpdatedDate == null)
                                                  ||((request.CreatedDate != null && request.UpdatedDate == null) && (x.CreatedDate>request.CreatedDate))
                                                  ||((request.CreatedDate == null && request.UpdatedDate != null) && (x.UpdatedDate<request.UpdatedDate))
                                                  ||((request.CreatedDate == null && request.UpdatedDate != null) && (x.CreatedDate>request.CreatedDate || x.UpdatedDate<request.UpdatedDate))));
            return result??Enumerable.Empty<MediaCategoryDTOModel>();
        }
    }
}
