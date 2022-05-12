using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;
namespace Server_v0._0.Models
{
    using Microsoft.EntityFrameworkCore;
    public class ApplicationContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GradsOfSemestrConfiguration());
            modelBuilder.ApplyConfiguration(new SyllabusConfiguration());
            modelBuilder.Entity<Time>()
                        .HasOne(p => p.Semestr)
                        .WithMany(p => p.Times);
            modelBuilder.Entity<Time>()
                        .HasOne(p => p.Subject)
                        .WithMany(p => p.Times);
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        public DbSet<Server_v0._0.Models.Semestr> Semestr { get; set; }
        public DbSet<Server_v0._0.Models.Time> Time { get; set; }
        public DbSet<Server_v0._0.Models.Subject> Subject { get; set; }
        public DbSet<Server_v0._0.Models.GradsOfSemestr> GradsOfSemestr { get; set; }
        public DbSet<Server_v0._0.Models.Student> Student { get; set; }
        public DbSet<Server_v0._0.Models.Syllabus> Syllabus { get; set; }
    }
}