using AutoMapper;
using Backend.Common.Models;
using Backend.Entities.Entities;

namespace Backend.Business.AutoMapperProfile
{
    public class UserProfile: Profile
    {
        public UserProfile() {
            CreateMap<User, UserModel>().ConvertUsing((entity, _) =>
            {
                return new UserModel()
                {
                    Id= entity.Id,
                    DisplayName = entity.DisplayName,
                    Email = entity.Email,
                    EnableEmailNotification= entity.EnableEmailNotification,
                    CreateDate = entity.CreatedDate,
                    UpdateDate = entity?.UpdatedDate ?? DateTime.MinValue,
                };
            });

            CreateMap<UserUpdateModel, User>().ConvertUsing((model,entity) =>
            {
                if(entity != null)
                {
                    entity.DisplayName = model.DisplayName;
                    entity.Email = model.Email;
                    entity.EnableEmailNotification= model.EnableEmailNotification;
                    entity.UpdatedDate = DateTime.Now;
                    entity.PhoneNumber = model.PhoneNumber;
                    return entity;
                }
                return new User()
                {
                    EnableEmailNotification= entity.EnableEmailNotification,
                    DisplayName= model.DisplayName,
                    Email = model.Email,
                    UpdatedDate = DateTime.Now,
                    PhoneNumber = model.PhoneNumber,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    LockoutEnabled = true
                };
            });

            CreateMap<User, UserInformation>().ConvertUsing((model, entity) =>
            {
                return new UserInformation()
                {
                    Id = entity.Id,
                    CreateDate = entity.CreateDate,
                    UpdateDate = entity.UpdateDate,
                    DisplayName = entity.DisplayName,
                    Roles = entity.Roles
                };
            });
        }
    }
}
