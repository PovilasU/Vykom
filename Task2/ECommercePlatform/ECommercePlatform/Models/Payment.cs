namespace ECommercePlatform.Models
{
    public class Payment
    {
        public Guid PaymentId { get; set; } // Primary Key
        public string PaymentMethod { get; set; } // Credit Card, PayPal
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }

        public Guid OrderId { get; set; } // Foreign Key
        public Order Order { get; set; }
    }
}
