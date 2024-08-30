using ECommercePlatform.Models;
using Microsoft.EntityFrameworkCore;


namespace ECommercePlatform.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }

        // DbSets for the entities (representing tables)
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }

        // Configure relationships and constraints in the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Configure GUID columns to use DEFAULT NEWID()
            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryId)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductId)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderId)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Review>()
                .Property(r => r.ReviewId)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentId)
                .HasDefaultValueSql("NEWID()");

            // Configure OrderProduct as a many-to-many relationship
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);
        }
    }
}
