using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionSix.Models
{
    public class MovieApplicationContext : DbContext
    {
        //Constructor
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base (options)
        {
            //leave blank for now
        }
        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }


        //Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "VHS" },
                new Category { CategoryId = 2, CategoryName = "Drama" },
                new Category { CategoryId = 3, CategoryName = "Comedy" },
                new Category { CategoryId = 4, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 5, CategoryName = "Family" },
                new Category { CategoryId = 6, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 7, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 8, CategoryName = "Television" }
                );



            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    ApplicationId = 1,
                    CategoryId = 2,
                    Title = "Pride and Prejudice",
                    Year = 2005,
                    Director = "Joe Wright",
                    Edited = true,
                    Rating = "PG-13"
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    CategoryId = 8,
                    Title = "New Girl",
                    Year = 2011,
                    Director = "Fox",
                    Edited = true,
                    Rating = "PG-13"
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    CategoryId = 5,
                    Title = "Toy Story",
                    Year = 1995,
                    Director = "John Lasseter",
                    Edited = true,
                    Rating = "PG"
                }
                );
        }
    }
}
