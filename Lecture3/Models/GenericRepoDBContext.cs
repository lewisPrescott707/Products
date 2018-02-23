using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lecture3.Models
{
    public class GenericRepoDBContext : DbContext
    {
        public GenericRepoDBContext(DbContextOptions<GenericRepoDBContext> options) 
            : base(options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
