using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
// first we need a databaseContext, witch is need to implement a interface
{
    public class CategoryDbContext : DbContext
    {
        // we need a constructor. DbContextOptions is configuration. ProductDbContext is our class name. option is just a name  
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options)
        {

        }

        //primary key is made on a method call OnModelCreating. the syntax is protected override void.
        //inside this function, we use modelBuilder define things like primary key.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Category is the entity class. and p is for category.
            // we make a primary key for our category table 
            modelBuilder.Entity<Category>()
                .Property(c => c.id)
                .ValueGeneratedOnAdd();  //this an about incrementing id now 
        }

        // DbSet can be thought of as a table. call it CategoryTable
        public DbSet<Category> CategoryTable { get; set; }
    }
}
