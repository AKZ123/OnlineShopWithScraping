using ECom.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Database
{
    public class CBContext :DbContext
    {
        public CBContext() : base("ECommarce")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent API is for model configuration
            modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Config> Configurations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ScreperURL> ScreperURLs { get; set; }
    }
}
