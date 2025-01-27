﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using New_Final_ET.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace New_Final_ET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);


            base.OnModelCreating(modelBuilder);
        }

        internal Task GetAllAsync(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        internal Task GetAll(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        internal Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        internal Task GetAllAsync(object p)
        {
            throw new NotImplementedException();
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
       
    }
}
