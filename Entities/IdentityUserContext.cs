using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class IdentityUserContext:IdentityDbContext<UserModel>
    {
        public IdentityUserContext(DbContextOptions<IdentityUserContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var item in builder.Model.GetEntityTypes())
            {
                string? tableName = item.GetTableName();
                if (tableName != null && tableName.StartsWith("AspNet"))
                {
                    item.SetTableName(tableName.Substring(6));
                }
            }
        }
    }
}
