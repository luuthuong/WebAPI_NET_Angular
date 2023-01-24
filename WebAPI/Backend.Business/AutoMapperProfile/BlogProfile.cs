using AutoMapper;
using Backend.Common.Models;
using Backend.Entities.Entities;

namespace Backend.Business.AutoMapperProfile
{
    public class BlogProfile: Profile
    {
        public BlogProfile() {
            CreateMap<Blog, BlogModel>().ConvertUsing((entity, model) =>
            {
                return new BlogModel
                {
                    Id = entity.Id,
                    Title = entity.Title ,
                    CategoryId = entity.CategoryId,
                    Content = entity.Content,
                    CreatedBy = entity.CreateBy,
                    CreatedDate = entity.CreatedDate,
                    UpdatedBy = entity.UpdateBy,
                    UpdatedDate = entity.UpdatedDate,
                    Description = entity.Description,
                    IsPublished= entity.IsPublished,
                    PublishedDate= entity.PublishedDate,
                    MetaTitle= entity.MetaTitle,
                    Slug = entity.Slug,
                    Summary = entity.Summary
                };
            });

            CreateMap<UpdateBlogModel, Blog>().ConvertUsing((model, entity) =>
            {
                if(entity != null)
                {
                    entity.UpdatedDate = DateTime.Now;
                    entity.CategoryId = model.CategoryId;
                    entity.Content = model.Content;
                    entity.Description = model.Description;
                    entity.IsPublished = model.IsPublished;
                    entity.MetaTitle = model.MetaTitle;
                    entity.Slug = model.Slug;
                    entity.Title = model.Title;
                    entity.Summary = model.Summary;
                    return entity;
                }
                return new Blog
                {
                    CreatedDate = DateTime.Now,
                    CategoryId = model.CategoryId,
                    Content = model.Content,
                    Description = model.Description,
                    Title = model.Title,
                    MetaTitle = model.MetaTitle,
                    Slug = model.Slug,
                    Summary = model.Summary,
                    IsPublished = model.IsPublished
                };
            });
        }
    }
}
