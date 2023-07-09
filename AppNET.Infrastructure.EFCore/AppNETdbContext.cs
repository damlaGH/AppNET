using AppNET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.Infrastructure.EFCore
{
    public class AppNETdbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.; Database=AppNETdb; user id=sa; password=123456!a; TrustServerCertificate=yes");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region product 
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(64).IsRequired();
            //modelBuilder.Entity<Product>().Property(p => p.Stock).HasDefaultValue("((1))");
            modelBuilder.Entity<Product>().Property(p => p.BuyPrice).HasColumnType("decimal(9,2)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.SupplierId).IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne<Category>(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            #endregion

            #region order
            modelBuilder.Entity<Order>().Property(o => o.Id).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.CustomerId).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.ShipDate).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.ShippingCompany).IsRequired();

            modelBuilder.Entity<Order>()
                .HasOne<Customer>(c => c.Customer)
                .WithMany(c => c.Order)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
             .HasOne<Invoice>(i => i.Invoice)
             .WithOne(c => c.Order)
             .HasForeignKey<Invoice>(i => i.InvoiceNumber);

            #endregion

            #region Order Details
            modelBuilder.Entity<OrderDetails>()
                .HasKey(e => new { e.OrderId, e.ProductId });

            modelBuilder.Entity<OrderDetails>()
               .ToTable("Order Details");

            //modelBuilder.Entity<OrderDetails>()
            //  .Property(o => o.Quantity).HasDefaultValue("((1))");
            
            modelBuilder.Entity<OrderDetails>()
                .Property(o => o.Price).HasColumnType("money");

            modelBuilder.Entity<OrderDetails>()
                .HasOne(d => d.Order)
                .WithMany(o => o.OrderDetails)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_Order_Deatils_Orders");

            modelBuilder.Entity<OrderDetails>()
                .HasOne(d => d.Product)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_Order_Details_Products");

            #endregion

            #region customer 

            modelBuilder.Entity<Customer>()
                .HasOne<CustomerAddress>()
                .WithOne(c => c.Customer)
                .HasForeignKey<CustomerAddress>(ad => ad.AddressOfCustomerId);


           
            #endregion

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
