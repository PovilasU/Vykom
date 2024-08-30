using System;
using System.Collections.Generic;

namespace ECommercePlatform.Models
{
    public class User
    {
        public Guid UserId { get; set; } // Primary Key
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Profile Profile { get; set; } // One-to-One relationship

        public ICollection<Order> Orders { get; set; } // One-to-Many relationship
    }


}
