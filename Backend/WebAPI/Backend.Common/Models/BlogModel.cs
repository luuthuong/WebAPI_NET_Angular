namespace Backend.Common.Models
{
    public class UpdateBlogModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public bool IsPublished { get; set; }
        public Guid CategoryId { get; set; }
    }
    public class BlogModel : UpdateBlogModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public Guid CreatedBy { get;set; }
        public Guid? UpdatedBy { get; set; }
    }

    public class BlogFilter
    {
        public string SearchText { get; set; }
        public Guid CategoryId { get; set; }
    }
}
