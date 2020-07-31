using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceLayer.Model;

namespace ServiceLayer
{
    public class AppDbContext : DbContext
    {

      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorType> ActorTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ActorType>().HasData(
                new ActorType
                {
                    ActorTypeId = 1,
                    Name = "Actor",
                   
                }
                );
            builder.Entity<Actor>().HasData(
                new Actor
                {
                    ActorId = 1,
                    FirstName = "Allu",
                    LastName = "Arjun",
                    ActorTypeId = 1,
                    InsertedDate = DateTime.Now
                },
                 new Actor
                 {
                     ActorId = 2,
                     FirstName = "Ravi",
                     LastName = "Teja",
                     ActorTypeId = 1,
                     InsertedDate = DateTime.Now
                 }, new Actor
                 {
                     ActorId = 3,
                     FirstName = "Shree",
                     LastName = "Ram",
                     ActorTypeId = 1,
                     InsertedDate = DateTime.Now
                 }, new Actor
                 {
                     ActorId = 4,
                     FirstName = "Jnr",
                     LastName = "Ntr",
                     ActorTypeId = 1,
                     InsertedDate = DateTime.Now
                 }, new Actor
                 {
                     ActorId = 5,
                     FirstName = "Mahesh",
                     LastName = "Babu",
                     ActorTypeId = 1,
                     InsertedDate = DateTime.Now
                 }, new Actor
                 {
                     ActorId = 6,
                     FirstName = "Kamal",
                     LastName = "Hasan",
                     ActorTypeId = 1,
                     InsertedDate = DateTime.Now
                 }

            ); 

            builder.Entity<Movie>().HasData(

                new Movie {
                    MovieId=1,
                    Name="Kalyanam",
                    ReleaseDate=DateTime.Now,
                    Rating=4


                },
                new Movie
                {
                    MovieId = 2,
                    Name = "Don",
                    ReleaseDate = DateTime.Now,
                    Rating = 5


                }
                );

        }
    }
}
