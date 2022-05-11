using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;
namespace Server_v0._0.Models
{
    using Microsoft.EntityFrameworkCore;
    public class ApplicationContext : DbContext
    {
        public DbSet<Semestr> Semestrs { get; set; }
        public DbSet<Time_ss> Time_sss { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grads_Of_Semestr> Grads_Of_Semestrs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Syllabus> Syllabuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Grads_Of_SemestrConfiguration());
            modelBuilder.ApplyConfiguration(new SyllabusConfiguration());
            modelBuilder.Entity<Time_ss>()
                        .HasOne(p => p.Semestr)
                        .WithMany(p => p.Time_sss);
            modelBuilder.Entity<Time_ss>()
                        .HasOne(p => p.Subject)
                        .WithMany(p => p.Time_ss);
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}