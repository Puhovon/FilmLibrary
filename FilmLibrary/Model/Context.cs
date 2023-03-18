﻿using Microsoft.EntityFrameworkCore;

namespace FilmLibrary.Model
{
    internal class Context : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=demo;username=postgres;password=123");
        }
    }
}
