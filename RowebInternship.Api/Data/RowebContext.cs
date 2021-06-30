using Microsoft.EntityFrameworkCore;
using RowebInternship.Api.Domain;


namespace RowebInternship.Api.Data
{
    public class RowebContext : DbContext
    {
        public RowebContext()
        {
        }

        public RowebContext(DbContextOptions options)
            : base(options)
        {
        }
        

        public DbSet<Category> Categories { get; set; }
        public DbSet <Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryID = 5,
                Name = "Adidas",
                Description = "Superstar"

            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryID = 6,
                Name = "Nike",
                Description = "AirForce1"

            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryID = 7,
                Name = "Puma",
                Description = "Running"

            });


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Adidas",
                Description = "Superstar",
                Price = 400,
                BasePrice = 550,
                Image = "superstar.jpg",
                CategoryID = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Nike",
                Description = "AF1",
                Price = 500,
                BasePrice = 600,
                Image = "af1.jpg",
                CategoryID = 2

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Puma",
                Description = "Running",
                Price = 400,
                BasePrice = 550,
                Image = "puma.jpg",
                CategoryID = 3

            });
        }
    }
}
