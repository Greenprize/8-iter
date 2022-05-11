using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server_v0._0.Models
{
    public class SyllabusConfiguration : IEntityTypeConfiguration<Syllabus>
    {
        public void Configure(EntityTypeBuilder<Syllabus> builder)
        {
            builder.HasKey(s => new {s.Syllabus_Id });

            builder.HasOne(ss => ss.Student)
                .WithMany(s => s.Syllabuses)
                .HasForeignKey(ss => ss.Id_Stud);

            builder.HasOne(ss => ss.Subject)
                .WithMany(s => s.Syllabuses)
                .HasForeignKey(ss => ss.Id_Subj);
        }
    }
}
