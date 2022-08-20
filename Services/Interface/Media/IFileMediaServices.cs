using DTO.FileDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface.Media
{
    public interface IFileMediaServices
    {
        IEnumerable<FileDTOModel> GetAllFile();
        FileDTOModel? GetFileById(string Id);
        Task<bool> AddFilesMedia(CreateFileRequest files);
        Task<bool> DeleteFileMedia(DeleteFileRequest request);

        Task<bool> UpdateFileMedia(UpdateFileRequest request);

        IEnumerable<FileDTOModel>? SearchFile(SearchFileRequest request);

    }
}
