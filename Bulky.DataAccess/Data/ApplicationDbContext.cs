
using Bulky.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Test",
                    Description = "Test",
                    ISBN = "Test",
                    Author = "Test",
                    ListPrice = 1,
                    Price = 1,
                    Price50 = 1,
                    Price100 = 1,
                    CategoryId = 1,
                    ImageUrl = "Test",
                },
                new Product
                {
                Id = 2,
                    Title = "Test",
                    Description = "Test",
                    ISBN = "Test",
                    Author = "Test",
                    ListPrice = 1,
                    Price = 1,
                    Price50 = 1,
                    Price100 = 1,
                    CategoryId = 1,
                    ImageUrl = "Test",
                },
                new Product
                {
                Id = 3,
                    Title = "Test",
                    Description = "Test",
                    ISBN = "Test",
                    Author = "Test",
                    ListPrice = 1,
                    Price = 1,
                    Price50 = 1,
                    Price100 = 1,
                    CategoryId = 1,
                    ImageUrl = "Test",
                },
                new Product
                {
                Id = 4,
                    Title = "Test",
                    Description = "Test",
                    ISBN = "Test",
                    Author = "Test",
                    ListPrice = 1,
                    Price = 1,
                    Price50 = 1,
                    Price100 = 1,
                    CategoryId = 1,
                    ImageUrl = "Test",
                },
                 new Product
                 {
                     Id = 5,
                     Title = "Test",
                     Description = "Test",
                     ISBN = "Test",
                     Author = "Test",
                     ListPrice = 1,
                     Price = 1,
                     Price50 = 1,
                     Price100 = 1,
                     CategoryId = 1,
                     ImageUrl = "Test",
                 }
            );
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

    }
}
