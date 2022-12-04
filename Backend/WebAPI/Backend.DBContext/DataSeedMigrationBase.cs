using Backend.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public abstract class DataSeedMigrationBase
    {
        public abstract string Key { get; }
        public abstract Task UpAsync(AppDbContext dbContext, IServiceProvider serviceProvider);
        public async Task ExecuteAsync(AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            if(await dbContext.SeedDataHistory.AsNoTracking().AnyAsync(x => x.Key == Key))
            {
                return;
            }
            var seedData = new SeedDataHistory()
            {
                Key = Key
            };
            await UpAsync(dbContext, serviceProvider);
            await dbContext.AddAsync(seedData);
            await dbContext.SaveChangesAsync();
        }
    }
}
