using System;
using Microsoft.EntityFrameworkCore;

namespace Redis.ExampleApp.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Kalem", Price = 30 },
                new Product() { Id = 2, Name = "Defter", Price = 40 },
                new Product() { Id = 3, Name = "Silgi", Price = 35 }

                );

            base.OnModelCreating(modelBuilder);
        }
    }
}

