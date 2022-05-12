using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server_v0._0.Models
{
    public class SyllabusConfiguration : IEntityTypeConfiguration<Syllabus>
    {
        public void Configure(EntityTypeBuilder<Syllabus> builder)
        {
            builder.HasKey(s => new {s.SyllabusId });

            builder.HasOne(ss => ss.Student)
                .WithMany(s => s.Syllabuses)
                .HasForeignKey(ss => ss.StudId);

            builder.HasOne(ss => ss.Subject)
                .WithMany(s => s.Syllabuses)
                .HasForeignKey(ss => ss.SubjectId);
        }
    }
}
