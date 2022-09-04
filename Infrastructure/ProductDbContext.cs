using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
// first we need a databaseContext, witch is need to implement a interface
{
    public class ProductDbContext: DbContext
    {
        // we need a constructor. DbContextOptions is configuration. ProductDbContext is our class name. option is just a name  
        public ProductDbContext(DbContextOptions<ProductDbContext>options): base (options)
        {

        }

        //primary key is made on a method call OnModelCreating. the syntax is protected override void.
        //inside this function, we use modelBuilder define things like primary key.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Product is the entity class. and p is for product.
            // we make a primary key for our product table 
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();  //this an about incrementing id now 
        }

        // DbSet can be thought of as a table. call it ProductTable
        public DbSet<Product> ProductTable { get; set; }
    }
}