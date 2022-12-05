using Backend.Common;
using Backend.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public static class DataSeedingContext 
    {
        public static async Task InitSeedDataMigrationAsync(this AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            var dataSeedMigrations = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(Utilities.GetLoadableTypes)
                .Where(type => type.IsSubclassOf(typeof(DataSeedMigrationBase)))
                .Select(type => (DataSeedMigrationBase)Activator.CreateInstance(type))
                .OrderBy(x => x.Key)
                .ToList();
            var executedDataSeedKeys = await dbContext.SeedDataHistory.Select(x=> x.Key).ToListAsync();
            var notExecuteDataSeedMigration = dataSeedMigrations.Where(x => !executedDataSeedKeys.Contains(x.Key)).OrderBy(x => x.Key).ToList() ;
            for (int i = 0; i < notExecuteDataSeedMigration.Count; i++)
            {
                await notExecuteDataSeedMigration[i].ExecuteAsync(dbContext, serviceProvider);
            }
        }
    }
}
