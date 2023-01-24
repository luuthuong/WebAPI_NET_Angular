using Backend.Common.Constants;
using Backend.Common.Enums;
using Backend.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Backend.DBContext.SeedDataMigrations
{
    public class Init_User_Administrator : DataSeedMigrationBase
    {

        public override string Key { get => "Init_User_Administrator"; }

        public override async Task UpAsync(AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            await AddRole(roleManager, RoleConstants.AdminId, RoleTypeEnum.Admin);
            await AddRole(roleManager, RoleConstants.ReaderId, RoleTypeEnum.Reader);

            await AddUser(userManager, new User
            {
                Id = ValueConstants.AdministratorId,
                DisplayName = "Administrator",
                Email = "administrator@gmail.com",
                UserName = "admin",
                Status = StatusEnum.Active,
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                CreatedDate = DateTime.Now,
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
                SecurityStamp = Guid.NewGuid().ToString("D"),
                CreatedDate = DateTime.Now
            }, RoleTypeEnum.Reader);
            await dbContext.SaveChangesAsync();
        }

        private async Task AddRole(RoleManager<Role> roleManger, Guid id, RoleTypeEnum roleType)
        {
            var role = new Role
            {
                Id = id,
                Name = roleType.ToString(),
                NormalizedName = roleType.ToString()
            };
            await roleManger.CreateAsync(role);
            await roleManger.AddClaimAsync(role, new Claim(ClaimTypeConstants.Role, roleType.ToString()));
        }

        private async Task AddUser(UserManager<User> userManager, User user, RoleTypeEnum roleType)
        {
            try
            {
                var existingUser = await userManager.FindByIdAsync(user.Id.ToString());
                if(existingUser == null) {
                    await userManager.CreateAsync(user, "admin");
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
