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
        public MediaCategoryServices(IMediaCategoryRepository repostiory)
        {
            _repostiory = repostiory;
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
            var result = _repostiory.Create(newMediaCategory);
            _repostiory.Save();
            return result;
        }

        public bool Delete(string Id)
        {
           var category = _repostiory.GetByCondition(item => item.Id == Id).ToList().FirstOrDefault();
           if (category == null) return false;
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
                Name = category.Name,
                Description = category.Description,
                CreatedBy = category.CreatedBy,
                CreatedDate = category.CreatedDate,
                UpdatedDate = category.UpdatedDate
            };
            return categoryModel;
        }

        public bool Update(string Id, UpdateMediaCategoryRequest request)
        {
            var category = _repostiory.GetByCondition(item => item.Id == Id).FirstOrDefault();
            if(category == null) return false;
            category.UpdatedDate = DateTime.Now;
            category.Description = request.Description;
            category.Name = request.Name;
            bool result = _repostiory.Update(category);
            return result;
        }
    }
}
