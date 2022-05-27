using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;
namespace Server_v0._0.Models
{
    using Microsoft.EntityFrameworkCore;
    public class ApplicationContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderComponentConfiguration());
            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Unit)
                        .WithMany(p => p.Products);
            modelBuilder.Entity<Client>()
                        .HasOne(p => p.Discount)
                        .WithMany(p => p.Clients);
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        public DbSet<Server_v0._0.Models.Client> Client { get; set; }
        public DbSet<Server_v0._0.Models.Discount> Discount { get; set; }
        public DbSet<Server_v0._0.Models.OrderComponent> OrderComponent { get; set; }
        public DbSet<Server_v0._0.Models.Product> Product { get; set; }
        public DbSet<Server_v0._0.Models.Sale> Sale { get; set; }
        public DbSet<Server_v0._0.Models.Unit> Unit { get; set; }
    }
}