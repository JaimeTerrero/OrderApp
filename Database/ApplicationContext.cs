using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region table
            modelBuilder.Entity<Order>().ToTable("Órdenes");
            modelBuilder.Entity<Client>().ToTable("Clientes");
            modelBuilder.Entity<Product>().ToTable("Productos");
            #endregion

            #region primary keys
            modelBuilder.Entity<Order>().HasKey(order => order.Id);
            modelBuilder.Entity<Client>().HasKey(client => client.Id);
            modelBuilder.Entity<Product>().HasKey(product => product.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<Client>()
                .HasMany<Order>(client => client.Orders)
                .WithOne(order => order.Client)
                .HasForeignKey(order => order.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany<Order>(product => product.Orders)
                .WithOne(order => order.Product)
                .HasForeignKey(order => order.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region property configurations
            
            #region client
            modelBuilder.Entity<Client>().Property(client => client.ClientName).IsRequired().HasMaxLength(120);
            #endregion

            #region order
            modelBuilder.Entity<Order>().Property(order => order.DeliveryDate).IsRequired();
            #endregion

            #region product
            modelBuilder.Entity<Product>().Property(product => product.ProductName).IsRequired().HasMaxLength(100);
            #endregion

            #endregion
        }
    }
}
