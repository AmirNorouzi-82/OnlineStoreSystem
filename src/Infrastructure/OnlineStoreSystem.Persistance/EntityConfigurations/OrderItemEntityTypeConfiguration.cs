using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Persistance.EntityConfigurations;
internal class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(oi => oi.UnitPrice).HasPrecision(10, 2);
        builder.Property(oi => oi.Discount).HasPrecision(5, 2);


        builder.HasOne(oi => oi.Order)
              .WithMany(o => o.OrderItems)
              .HasForeignKey(oi => oi.OrderId)
              .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(oi => oi.Product)
              .WithMany(p => p.OrderItems)
              .HasForeignKey(oi => oi.ProductId)
              .OnDelete(DeleteBehavior.Restrict);



        builder.HasIndex(oi => new { oi.OrderId, oi.ProductId }).IsUnique();
    }
}
