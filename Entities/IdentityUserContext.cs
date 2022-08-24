using Entities.Models;
using Entities.Models.Blog;
using Entities.Models.Media;
using Entities.Models.Shop;
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


        public DbSet<ProductModel>? Product { get; set; }
        public DbSet<ProductOrderItemModel>? ProductOrderItem { get; set; }
        public DbSet<ProductCartItemModel>? ProductCartItem { get; set; }
        public DbSet<ProductReviewModel>? ProductReview { get; set; }
        public DbSet<ProductMetaModel>? ProductMeta { get; set; }
        public DbSet<ProductCategoryModel>? ProductCategory { get; set; }
        public DbSet<ProductTagModel>? ProductTag { get; set; }
        public DbSet<ShopCartModel>? ShopCart { get; set; }
        public DbSet<ShopCategoryModel>? ShopCategory { get; set; }
        public DbSet<ShopTagModel>? ShopTag { get; set; }
        public DbSet<ShopOrderModel>? ShopOrder { get; set; }
        public DbSet<ShopTransactionModel>? ShopTransaction { get; set; }
        public DbSet<ProductTypeModel>? ProductType { get; set; }
        public DbSet<ShopTypeModel>? ShopType { get; set; }
        public DbSet<ProductFileCategoryItemModel>? FileCategoryItem { get; set; }
        public DbSet<ShopFileMedia>? ShopFileMedia { get; set; }

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

            //Shop
            builder.Entity<ProductModel>(item =>
            {
                item.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.ClientNoAction);
            });
            builder.Entity<ShopCartModel>(x =>
            {
                x.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
            });
            builder.Entity<ProductCartItemModel>(item =>
            {
                item.HasOne(x => x.Cart).WithMany().HasForeignKey(x => x.CartId);
                item.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
            });
            builder.Entity<ProductReviewModel>(item =>
            {
                item.HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId);
                item.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
            });
            builder.Entity<ProductCategoryModel>(item =>
            {
                item.HasKey(x => new { x.ProductId, x.CategoryId });
                item.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
                item.HasOne(x=>x.Category).WithMany().HasForeignKey(x => x.CategoryId);
            });

            builder.Entity<ShopCategoryModel>(item =>
            {
                item.HasIndex(x => x.Name).IsUnique();
                item.HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId);
            });

            builder.Entity<ProductMetaModel>(item =>
            {
                item.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientCascade);
            });
            builder.Entity<ProductTagModel>(item =>
            {
                item.HasKey(x => new { x.ProductId, x.TagId });
                item.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
                item.HasOne(x => x.Tag).WithMany().HasForeignKey(x => x.TagId);
            });
            builder.Entity<ProductOrderItemModel>(item =>
            {
                item.HasOne(x => x.Order).WithMany().HasForeignKey(x => x.OrderId);
                item.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
            });
            builder.Entity<ShopOrderModel>(item =>
            {
                item.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.ClientCascade);
            });
            builder.Entity<ShopTransactionModel>(item =>
            {
                item.HasOne(x => x.User).WithMany().HasForeignKey(item => item.UserId).OnDelete(DeleteBehavior.ClientCascade);
                item.HasOne(x => x.Order).WithMany().HasForeignKey(item => item.OrderId).OnDelete(DeleteBehavior.ClientCascade);
            });
            builder.Entity<ProductTypeModel>(item =>
            {
                item.HasKey(x => new { x.TypeId, x.ProductId });
                item.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientCascade);
                item.HasOne(x => x.Type).WithMany().HasForeignKey(x => x.TypeId).OnDelete(DeleteBehavior.ClientCascade);
            });
            builder.Entity<ShopTypeModel>(item =>
            {
                item.HasIndex(x => x.Name).IsUnique();
            });
            builder.Entity<ProductFileCategoryItemModel>(item =>
            {
                item.HasKey(x => new { x.FileMediaId, x.CategoryId });
                item.HasOne(x => x.FileMedia).WithMany().HasForeignKey(x => x.FileMediaId).OnDelete(DeleteBehavior.ClientCascade);
                item.HasOne(x => x.MediaCategory).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.ClientCascade);
            });
            builder.Entity<ShopFileMedia>(item =>
            {
                item.HasIndex(x => x.Name).IsUnique();
            });
            builder.Entity<ShopMediaCategoryModel>(item =>
            {
                item.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientNoAction);
            });
        }
    }
}
