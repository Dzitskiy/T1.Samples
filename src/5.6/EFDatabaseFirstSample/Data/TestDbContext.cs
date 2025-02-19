using System;
using System.Collections.Generic;
using EFDatabaseFirstSample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDatabaseFirstSample.Data
{

    public class TestDbContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }


        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasMany(d => d.Products).WithMany(p => p.Categories)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductCategory",
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductsId"),
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoriesId"),
                        j =>
                        {
                            j.HasKey("CategoriesId", "ProductsId");
                            j.ToTable("ProductCategories");
                            j.HasIndex(new[] { "ProductsId" }, "IX_ProductCategories_ProductsId");
                        });
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Orders_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.User).WithMany(p => p.Orders).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.OrderId, "IX_Products_OrderId");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Order).WithMany(p => p.Products).HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Email).HasMaxLength(256);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserProfiles_UserId").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.HasOne(d => d.User).WithOne(p => p.UserProfile).HasForeignKey<UserProfile>(d => d.UserId);
            });

            
        }

    }
}