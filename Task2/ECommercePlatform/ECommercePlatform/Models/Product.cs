namespace ECommercePlatform.Models
{
    public class Product
    {
        public Guid ProductId { get; set; } // Primary Key
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public Guid CategoryId { get; set; } // Foreign Key
        public Category Category { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ICollection<Review> Reviews { get; set; } // One-to-Many relationship with reviews
    }


}
