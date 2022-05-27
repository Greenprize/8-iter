using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server_v0._0.Models
{
    public class OrderComponentConfiguration : IEntityTypeConfiguration<OrderComponent>
    {
        public void Configure(EntityTypeBuilder<OrderComponent> builder)
        {
            builder.HasKey(s => new {s.OrderComponentId });

            builder.HasOne(ss => ss.Sale)
                .WithMany(s => s.OrderComponents)
                .HasForeignKey(ss => ss.SaleId);

            builder.HasOne(ss => ss.Product)
                .WithMany(s => s.OrderComponents)
                .HasForeignKey(ss => ss.ProductId);
        }
    }
}
