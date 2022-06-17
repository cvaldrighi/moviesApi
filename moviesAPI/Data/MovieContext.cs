using Microsoft.EntityFrameworkCore;
using moviesAPI.ModelConfiguration;
using moviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moviesAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opt) : base(opt)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(new MovieConfiguration().Configure);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>()
                .HasOne(address => address.Cinema)
                .WithOne(cinema => cinema.Address)
                .HasForeignKey<Cinema>(cinema => cinema.AddressId);

            modelBuilder.Entity<Cinema>()
                .HasOne(cinema => cinema.Manager)
                .WithMany(manager => manager.Cinemas)
                .HasForeignKey(cinema => cinema.ManagerId);

            modelBuilder.Entity<Session>()
                .HasOne(session => session.Movie)
                .WithMany(movie => movie.Sessions)
                .HasForeignKey(session => session.MovieId);

            modelBuilder.Entity<Session>()
                .HasOne(session => session.Cinema)
                .WithMany(cinema => cinema.Sessions)
                .HasForeignKey(session => session.CinemaId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
