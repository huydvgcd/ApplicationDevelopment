using ApplicationDevelopment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDevelopment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            modelBuilder.Entity<OrdersDetail>(entity => {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Cart>().HasKey(cart => new { cart.UserId, cart.BookId });

            // modelBuilder.Entity<Cart>().HasKey(cart => cart.Uid);
            modelBuilder.Entity<Cart>().HasOne<ApplicationUser>(cart => cart.AppUser)
                                        .WithMany(app => app.Carts)
                                        .HasForeignKey(cart => cart.UserId);

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrdersDetail> OrdersDetails { get; set; }


    }
}
