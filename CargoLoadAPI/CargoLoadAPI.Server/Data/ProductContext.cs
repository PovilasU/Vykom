using Microsoft.EntityFrameworkCore;
using CargoLoadAPI.Server.Models;

namespace CargoLoadAPI.Server.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        //public DbSet<Product> Products { get; set; }
    }
}
