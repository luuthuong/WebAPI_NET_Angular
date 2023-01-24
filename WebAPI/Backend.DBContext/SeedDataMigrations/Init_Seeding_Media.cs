using Backend.Common.Constants;
using Backend.Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext.SeedDataMigrations
{
    public class Init_Seeding_Media : DataSeedMigrationBase
    {
        public override string Key => "Init_FileCategory";

        public override async Task UpAsync(AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            await AddCategory(dbContext);
        }

        public async Task AddCategory(AppDbContext dbContext)
        {
            var categories = new List<CategoryMedia>()
            {
                new CategoryMedia
                {
                    Id = ValueConstants.ProductCategoryMediaId,
                    CreateBy = ValueConstants.AdministratorId,
                    CreateDate = DateTime.Now,
                    Description = "An ambition that directs your talent towards the right goals is essential for success.",
                    Name = "Product",
                },
                new CategoryMedia
                {
                    Id = ValueConstants.BlogCategoryMediaId,
                    CreateBy = ValueConstants.AdministratorId,
                    CreateDate = DateTime.Now,
                    Description = "An ambition that directs your talent towards the right goals is essential for success.",
                    Name = "Blog",
                },
                new CategoryMedia
                {
                    Id = ValueConstants.ProfileCategoryMediaId,
                    CreateBy = ValueConstants.AdministratorId,
                    CreateDate = DateTime.Now,
                    Description = "An ambition that directs your talent towards the right goals is essential for success.",
                    Name = "Profile",
                }
            };
            await dbContext.CategoryMedia.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();
        }
    }
}
