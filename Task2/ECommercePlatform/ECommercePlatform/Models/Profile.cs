namespace ECommercePlatform.Models
{
    public class Profile
    {
        public Guid ProfileId { get; set; } // Primary Key
        public string ShippingAddress { get; set; }
        public string PhoneNumber { get; set; }

        public Guid UserId { get; set; } // Foreign Key
        public User User { get; set; }
    }
}
