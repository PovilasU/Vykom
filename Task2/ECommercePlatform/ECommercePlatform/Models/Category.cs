namespace ECommercePlatform.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; } // Primary Key
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; } // One-to-Many relationship
    }
}
