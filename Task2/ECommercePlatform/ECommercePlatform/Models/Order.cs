namespace ECommercePlatform.Models
{
    public class Order
    {
        public Guid OrderId { get; set; } // Primary Key
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } // Pending, Shipped, Delivered

        public Guid UserId { get; set; } // Foreign Key
        public User User { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
        public Payment Payment { get; set; } // One-to-One relationship
    }

}
