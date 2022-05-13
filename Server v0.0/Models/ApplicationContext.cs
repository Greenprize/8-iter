using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;
using Server_v0._0;
namespace Server_v0._0.Models
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.IO;

    public class ApplicationContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMaterialConfiguration());
            modelBuilder.Entity<Product>()
                        .HasOne(p => p.ProductType)
                        .WithMany(p => p.Products);
            modelBuilder.Entity<Sale>()
                        .HasOne(p => p.Product)
                        .WithMany(p => p.Sales);
            modelBuilder.Entity<Sale>()
                        .HasOne(p => p.Customer)
                        .WithMany(p => p.Sales);
            modelBuilder.Entity<Customer>()
                        .HasOne(p => p.Discount)
                        .WithMany(p => p.Customers);
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            List<StreamReader> procedures = new List<StreamReader>();
            List<StreamReader> triggers = new List<StreamReader>();
            /*procedures.Add(new StreamReader(@"Procedures/Procedure_change_price.txt"));
            procedures.Add(new StreamReader(@"Procedures/Procedure_all_delete.txt"));*/
            triggers.Add(new StreamReader(@"Triggers/Trigger_set_discount.txt"));
            triggers.Add(new StreamReader(@"Triggers/Trigger_set_prise.txt"));
            /*triggers.Add(new StreamReader(@"Triggers/Trigger_price_count_ins_upd.txt"));
            triggers.Add(new StreamReader(@"Triggers/Trigger_price_count_del.txt"));*/

            foreach (StreamReader reader in procedures)
            {
                try
                {
                    Database.ExecuteSqlRaw(reader.ReadToEnd());
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 2714)
                {
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 4060)
                {
                    Database.EnsureCreated();   // создаем базу данных при первом обращении
                }
            }
            foreach (StreamReader reader in triggers)
            {
                try
                {
                    Database.ExecuteSqlRaw(reader.ReadToEnd());
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 2714)
                {
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 4060)
                {
                    Database.EnsureCreated();   // создаем базу данных при первом обращении
                }
            }
        }
        public DbSet<Server_v0._0.Models.Discount> Discount { get; set; }
        public DbSet<Server_v0._0.Models.Customer> Customer { get; set; }
        public DbSet<Server_v0._0.Models.Sale> Sale { get; set; }
        public DbSet<Server_v0._0.Models.Material> Material { get; set; }
        public DbSet<Server_v0._0.Models.Product> Product { get; set; }
        public DbSet<Server_v0._0.ProductMaterial> ProductMaterial { get; set; }
        public DbSet<Server_v0._0.Models.ProductType> ProductType { get; set; }
    }
}