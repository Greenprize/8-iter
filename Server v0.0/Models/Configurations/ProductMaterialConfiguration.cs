using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server_v0._0.Models
{
    public class ProductMaterialConfiguration : IEntityTypeConfiguration<ProductMaterial>
    {
        public void Configure(EntityTypeBuilder<ProductMaterial> builder)
        {
            builder.HasKey(s => new {s.ProductMaterialId });

            builder.HasOne(ss => ss.Product)
                .WithMany(s => s.ProductMaterials)
                .HasForeignKey(ss => ss.ProductId);

            builder.HasOne(ss => ss.Material)
                .WithMany(s => s.ProductMaterials)
                .HasForeignKey(ss => ss.MaterialId);
        }
    }
}
