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
        public RepositoryContext(DbContextOptions<RepositoryContext> options):base(options){
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FileModel>()
                .HasMany(f => f.Categories)
                .WithMany(c => c.FilesMedia)
                .UsingEntity("FileCategory");
        }
    }
}
