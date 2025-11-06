using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Persistance.EntityConfigurations;
internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.OrderDate).HasDefaultValueSql("GETDATE()");


        builder.HasOne(o => o.Customer)
              .WithMany(c => c.Orders)
              .HasForeignKey(o => o.CustomerId)
              .OnDelete(DeleteBehavior.Restrict);
    }
}
