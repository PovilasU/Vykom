namespace ECommercePlatform.Models
{
    public class Review
    {
        public Guid ReviewId { get; set; } // Primary Key
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Timestamp { get; set; }

        public Guid ProductId { get; set; } // Foreign Key
        public Product Product { get; set; }

        public Guid UserId { get; set; } // Foreign Key
        public User User { get; set; }
    }
}
