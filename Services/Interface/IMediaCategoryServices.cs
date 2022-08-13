using DTO.MediaCategoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IMediaCategoryServices
    {
        IEnumerable<MediaCategoryDTOModel> GetAll();
        MediaCategoryDTOModel GetById(string Id);

        bool Create(CreateMediaCategoryRequest request);
        bool Update(string id, UpdateMediaCategoryRequest request);

        bool Delete(string Id);
    }
}
