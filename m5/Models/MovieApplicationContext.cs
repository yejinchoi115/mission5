using System;
using Microsoft.EntityFrameworkCore;

namespace m5.Models
{
    public class MovieApplicationContext: DbContext
    {
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options): base(options)
        {

        }
        public DbSet<FormResponse> responses { get; set; }
        public DbSet<Category> Categories { get; set; }


        //seeding data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId=1, Categoryname="Action/Adventure"},
                new Category { CategoryId=2, Categoryname="Comedy"},
                new Category { CategoryId=3, Categoryname="Drama"},
                new Category { CategoryId=4, Categoryname="Family"},
                new Category { CategoryId =5, Categoryname = "Horror/Suspense"},
                new Category { CategoryId=6, Categoryname="Miscellaneous"},
                new Category { CategoryId=7, Categoryname="Television"},
                new Category { CategoryId=8, Categoryname="VHS"}


            );


            mb.Entity<FormResponse>().HasData(

                new FormResponse
                {
                    FormID =1,
                    CategoryId = 1,
                    Title = "Avengers, The",
                    Year ="2012",
                    Director="Joss Whedon",
                    Rating="PG-13",
                    Edited=false,
                    LentTo ="Haneul Song",
                    Notes = "For date"
                },
                 new FormResponse
                 {
                     FormID = 2,
                     CategoryId = 1,
                     Title = "Dark Knight, The",
                     Year = "2008",
                     Director = "Christoper Nolan",
                     Rating = "PG-13",
                     Edited = false,
                     LentTo = "Morgan Jin",
                     Notes = "For fun"
                 },
                  new FormResponse
                  {
                      FormID = 3,
                      CategoryId = 1,
                      Title = "Matrix, The",
                      Year = "1999",
                      Director = "The Wachowski Brothers",
                      Rating = "R",
                      Edited = false,
                      LentTo = "Henry Cho",
                      Notes = "For fun"
                  }

            );
        }

    }
}
