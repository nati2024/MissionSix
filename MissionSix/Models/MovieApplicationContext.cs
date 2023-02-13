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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    ApplicationId = 1,
                    Category = "Drama",
                    Title = "Pride and Prejudice",
                    Year = 2005,
                    Director = "Joe Wright",
                    Edited = true,
                    Rating = "PG-13"
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    Category = "television",
                    Title = "New Girl",
                    Year = 2011,
                    Director = "Fox",
                    Edited = true,
                    Rating = "PG-13"
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    Category = "Family",
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
