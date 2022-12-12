namespace Backend.Entities.Entities
{
    public class Blog: EntityBase
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
        public string Content { get; set; }
        public bool IsPublic { get; set; }
    }
}
