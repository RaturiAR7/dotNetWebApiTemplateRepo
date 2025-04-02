using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Services
{
    public class ApplicationDbContext:DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
       {
        
       }
       public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var product1=new Product(){Id=1,Name="Samsung 10",Brand="Samsung",Category="Phones",Price=900,Description="New Smartphone",CreateAt=DateTime.Now};
            modelBuilder.Entity<Product>().HasData(product1);
        }
    }
}


