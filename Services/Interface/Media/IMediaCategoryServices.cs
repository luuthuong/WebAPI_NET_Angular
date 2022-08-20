using DTO.MediaCategoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface.Media
{
    public interface IMediaCategoryServices
    {
        IEnumerable<MediaCategoryDTOModel> GetAll();
        MediaCategoryDTOModel GetById(string Id);

        bool Create(CreateMediaCategoryRequest request);
        Task<bool> Update(UpdateMediaCategoryRequest request);
        IEnumerable<MediaCategoryDTOModel> GetChildren(string Id);
        Task<bool> Delete(string Id);
        GetFilesInCategoryDTOModel GetFilesInCategory(GetFilesInCategoryRequest request);

        IEnumerable<MediaCategoryDTOModel> SearchCategory(SearchCategoryRequest request);
    }
}
