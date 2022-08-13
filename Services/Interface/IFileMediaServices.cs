﻿using DTO.FileDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IFileMediaServices
    {
        IEnumerable<FileDTOModel> GetAllFile();
        FileDTOModel GetFileById(string Id );
        bool AddFileMedia(IEnumerable<CreateFileRequest> files);
        bool AddFileMedia(CreateFileRequest file);
        bool DeleteFileMedia(DeleteFileRequest request);

    }
}