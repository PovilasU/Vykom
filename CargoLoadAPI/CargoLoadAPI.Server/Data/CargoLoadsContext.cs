using CargoLoadAPI.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoLoadAPI.Server.Data
{
    public class CargoLoadsContext : DbContext
    {
        public CargoLoadsContext(DbContextOptions<CargoLoadsContext> options)
            : base(options)
        {
        }

        public DbSet<CargoLoad> CargoLoads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the CargoLoad entity if needed
            modelBuilder.Entity<CargoLoad>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DriverName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.VehicleNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.VehicleType).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LoadWeight).IsRequired();
                entity.Property(e => e.IsDangerousGoods).IsRequired();
            });
        }
    }
}
