using Backend.Common.Constants;
using Backend.Common.Enums;
using Backend.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.DBContext.SeedDataMigrations
{
    public class Init_User_Administrator : DataSeedMigrationBase
    {

        public override string Key { get => "Init_User_Administrator"; }

        public override async Task UpAsync(AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            await AddRole(dbContext, RoleConstants.AdminId, RoleTypeEnum.Admin);
            await AddRole(dbContext, RoleConstants.ReaderId, RoleTypeEnum.Reader);

            await AddUser(userManager, new User
            {
                Id = ValueConstants.AdministratorId,
                DisplayName = "Administrator",
                Email = "administrator@netpower.no",
                UserName = "administrator@netpower.no",
                Status = StatusEnum.Active,
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            }, RoleTypeEnum.Admin);

            await AddUser(userManager, new User
            {
                Id = ValueConstants.ReaderId,
                DisplayName = "Reader",
                Email = "reader@gmail.com",
                UserName = "reader",
                Status = StatusEnum.Active,
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            }, RoleTypeEnum.Reader);
        }

        private async Task AddRole(AppDbContext dbContext, Guid id, RoleTypeEnum roleType)
        {
            var role = new Role
            {
                Id = id,
                Name = roleType.ToString(),
                NormalizedName = roleType.ToString()
            };
            await dbContext.Roles.AddAsync(role);
            await dbContext.SaveChangesAsync();
        }

        private async Task AddUser(UserManager<User> userManager, User user, RoleTypeEnum roleType)
        {
            try
            {
                var existingUser = await userManager.FindByIdAsync(user.Id.ToString());
                if(existingUser == null) {
                    await userManager.CreateAsync(user, "admin123");
                    await userManager.AddToRoleAsync(user, roleType.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
