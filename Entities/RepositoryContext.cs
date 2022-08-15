using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RepositoryContext:DbContext
    {
        public DbSet<FileModel>? Files { get; set; }
        public DbSet<MediaCategoryModel>? MediaCategories { get; set; }

        public DbSet<FileCategoryModel>? FileCategory { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options):base(options){
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<FileModel>()
            //    .HasMany(f => f.Categories)
            //    .WithMany(c => c.FilesMedia)
            //    .UsingEntity<FileCategoryModel>();
            modelBuilder.Entity<FileCategoryModel>(f =>
            {
                f.HasKey(e => new { e.CategoryId, e.FileId });
                f.HasOne(e => e.MediaCategory).WithMany().HasForeignKey(e => e.CategoryId);
                f.HasOne(e => e.File).WithMany().HasForeignKey(e => e.FileId);
            });

            modelBuilder.Entity<FileModel>(f =>
            {
                f.HasIndex("Name").IsUnique();
            });
        }
    }
}
