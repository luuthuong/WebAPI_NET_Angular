using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class IdentityUserContext:IdentityDbContext<UserModel,RoleModel,string,
        IdentityUserClaim<string>,IdentityUserRole<string>,
        IdentityUserLogin<string>, IdentityRoleClaim<string>,
        IdentityUserToken<string>>
    {
        public DbSet<PostModel>? Post { get; set; }
        public DbSet<PostCommentModel>? PostComment { get; set; }
        public DbSet<PostCategoryModel>? PostCategory { get; set; }
        public DbSet<BlogCategoryModel>? BlogCategoryModel { get; set; }
        public DbSet<PostMetaModel>? PostMeta { get; set; }

        public DbSet<TagModel>? Tag { get; set; }
        public DbSet<PostTagModel>? PostTag { get; set; }

        public DbSet<FileModel>? Files { get; set; }
        public DbSet<MediaCategoryModel>? MediaCategories { get; set; }

        public DbSet<FileCategoryModel>? FileCategory { get; set; }

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

            builder.HasDefaultSchema("App");

            builder.Entity<PostModel>(p =>
            {
                p.HasOne(x => x.User).WithMany().HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.ClientCascade);
                p.HasOne(x=>x.PostParent).WithMany().HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.ClientNoAction);
            });

            builder.Entity<PostCommentModel>(comment =>
            {
                comment.HasOne(x => x.Post).WithMany().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.ClientCascade);
                comment.HasOne(x => x.ParentComment).WithMany().HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.ClientNoAction);
            });

            builder.Entity<PostCategoryModel>(cate =>
            {
                cate.HasKey(x => new { x.PostId, x.CategoryId });
                cate.HasOne(x => x.Post).WithMany().HasForeignKey(x => x.PostId);
                cate.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);
            });

            builder.Entity<BlogCategoryModel>(blogCate =>
            {
                blogCate.HasIndex("Name").IsUnique();
            });

            builder.Entity<PostMetaModel>(meta =>
            {
                meta.HasOne(x => x.Post).WithMany().HasForeignKey(x=>x.PostId);
            });

            builder.Entity<PostTagModel>(postTag =>
            {
                postTag.HasKey(x => new { x.TagId, x.PostId });
                postTag.HasOne(x => x.Tag).WithMany().HasForeignKey(x => x.TagId);
                postTag.HasOne(x=>x.Post).WithMany().HasForeignKey(x => x.PostId);
            });

            builder.Entity<TagModel>(tag =>
            {
                tag.HasIndex("Name").IsUnique();
            });

            builder.Entity<FileCategoryModel>(f =>
            {
                f.HasKey(e => new { e.CategoryId, e.FileId });
                f.HasOne(e => e.MediaCategory).WithMany().HasForeignKey(e => e.CategoryId);
                f.HasOne(e => e.File).WithMany().HasForeignKey(e => e.FileId);
            });

            builder.Entity<FileModel>(f =>
            {
                f.HasIndex("Name").IsUnique();
            });

            builder.Entity<MediaCategoryModel>(c =>
            {
                c.HasIndex("Name").IsUnique();
                c.HasOne(e => e.Parent).WithMany().HasForeignKey(x => x.ParentId);
                c.HasOne(e => e.User).WithMany().HasForeignKey(x => x.UserId);
            });
        }
    }
}
