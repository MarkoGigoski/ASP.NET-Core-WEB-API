using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieAppDomain.Models;
using MovieAppDomain.Enums;

namespace MovieAppDataAccess
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed
            modelBuilder.Entity<Movie>().HasData( new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "Lord of The Rings",
                    Description = "If you dont know you are alien",
                    Genre = GenreEnum.Action,
                    Year = 2001
                },
                new Movie
                {
                    Id = 2,
                    Title = "Blade",
                    Description = "Humans vs Vampires vs Hybrids",
                    Genre = GenreEnum.Action,
                    Year = 2003
                },
                new Movie
                {
                    Id = 3,
                    Title = "Harry Potter",
                    Description = "Wizards and shit",
                    Genre = GenreEnum.SciFi,
                    Year = 2005
                },
                new Movie
                {
                    Id = 4,
                    Title = "Barbie",
                    Description = "Anti Shovinistic fitures",
                    Genre = GenreEnum.Comedy,
                    Year = 2023
                },
                new Movie
                {
                    Id = 5,
                    Title = "Oppenheimer",
                    Description = "Documentary kinda wibes",
                    Genre = GenreEnum.Thriller,
                    Year = 2023

                }
            });
        }
    }
}
