using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server_v0._0.Models
{
    public class Grads_Of_SemestrConfiguration : IEntityTypeConfiguration<Grads_Of_Semestr>
    {
        public void Configure(EntityTypeBuilder<Grads_Of_Semestr> builder)
        {
            builder.HasKey(s => new {s.Grads_Of_Semestr_Id });

            builder.HasOne(ss => ss.Student)
                .WithMany(s => s.Grads_Of_Semestrs)
                .HasForeignKey(ss => ss.Id_Stud);

            builder.HasOne(ss => ss.Time_ss)
                .WithMany(s => s.Grads_Of_Semestrs)
                .HasForeignKey(ss => ss.Id_Time);
        }
    }
}
