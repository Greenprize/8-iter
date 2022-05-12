using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server_v0._0.Models
{
    public class GradsOfSemestrConfiguration : IEntityTypeConfiguration<GradsOfSemestr>
    {
        public void Configure(EntityTypeBuilder<GradsOfSemestr> builder)
        {
            builder.HasKey(s => new {s.GradsOfSemestrId });

            builder.HasOne(ss => ss.Student)
                .WithMany(s => s.GradsOfSemestrs)
                .HasForeignKey(ss => ss.StudId);

            builder.HasOne(ss => ss.Time)
                .WithMany(s => s.GradsOfSemestrs)
                .HasForeignKey(ss => ss.TimeId);
        }
    }
}
