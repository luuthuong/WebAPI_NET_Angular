using AutoMapper;
using Backend.Common.Helpers;
using Backend.Common.Models;
using Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.AutoMapperProfile
{
    public class FileProfile: Profile
    {
        public FileProfile() {
            CreateMap<FileMedia, FileModel>().ConvertUsing((entity, model) =>
            {
                return new FileModel()
                {
                    CreatedDate = entity.CreateDate,
                    Id = entity.Id,
                    Title = entity.Title,
                    Extension = entity.Extension,
                    Description = entity.Description,
                    UpdatedBy = entity.UpdatedBy,
                    CreatedBy = entity.CreatedBy,
                    UpdatedDate = entity.UpdateDate,
                    Size = entity.Size,
                    FileContent = entity.FileContent
                };
            });

            CreateMap<UpdateFileModel, FileMedia>().ConvertUsing((model, entity) =>
            {
                if(entity == null)
                {
                    var fileContent = FileHelper.ConvertToByte(model.File).Result;
                    return new FileMedia()
                    {
                        CreateDate = DateTime.Now,
                        Description = model.Description,
                        Title = model.Title,
                        Size = model.File.Length,
                        Extension = model.File.ContentType,
                        FileContent = fileContent
                    };
                }
                entity.Description = model.Description;
                entity.Title = model.Title;
                entity.UpdateDate = DateTime.Now;
                return entity;
            });
        }
    }
}
