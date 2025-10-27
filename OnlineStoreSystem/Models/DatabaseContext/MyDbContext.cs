using Microsoft.EntityFrameworkCore;
using OnlineStoreSystem.Models.Entities;

namespace OnlineStoreSystem.Models.DatabaseContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.Register_date).HasDefaultValueSql("GETDATE()");
            });



            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(o => o.OrderDate).HasDefaultValueSql("GETDATE()");


                entity.HasOne(o => o.Customer)
                      .WithMany(c => c.Orders)
                      .HasForeignKey(o => o.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });



            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(oi => oi.UnitPrice).HasPrecision(10, 2);
                entity.Property(oi => oi.Discount).HasPrecision(5, 2);


                entity.HasOne(oi => oi.Order)
                      .WithMany(o => o.OrderItems)
                      .HasForeignKey(oi => oi.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(oi => oi.Product)
                      .WithMany(p => p.OrderItems)
                      .HasForeignKey(oi => oi.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);



                entity.HasIndex(oi => new { oi.OrderId, oi.ProductId }).IsUnique();
            });



        }



    }
}
