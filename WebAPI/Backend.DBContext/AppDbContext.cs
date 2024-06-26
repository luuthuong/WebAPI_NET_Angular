﻿using Backend.Common.Constants;
using Backend.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class AppDbContext : DbContextBase<User, Role, UserRole, Guid>
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<SeedDataHistory> SeedDataHistory { get; set; }

        public DbSet<FileMedia> File { get; set; }
        public DbSet<CategoryMedia> CategoryMedia { get; set; }
        public DbSet<FileCategory> FileCategory { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogComment> BlogComment { get; set; }
        public DbSet<BlogCategory> BlogCategory { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var item in builder.Model.GetEntityTypes())
            {
                string tableName = item.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    item.SetTableName(tableName.Substring(6));
                }
            }

            builder.HasDefaultSchema(SchemaConstants.App);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new {ur.RoleId, ur.UserId});
                userRole.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired();
                userRole.HasOne(ur => ur.User).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.UserId).IsRequired();
            });

            builder.Entity<RefreshToken>(refreshToken =>
            {
                refreshToken.HasKey(ur => ur.Id);
                refreshToken.HasOne(token => token.User)
                .WithMany(user => user.RefreshTokens).HasForeignKey(token => token.UserId).IsRequired(true);
            });

            builder.Entity<FileCategory>(x =>
            {
                x.HasKey(item => new { item.CategoryId, item.FileId });
            });

            builder.Entity<CategoryMedia>(x =>
            {
                x.HasOne(item => item.Parent).WithMany().HasForeignKey(item => item.ParentId).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
