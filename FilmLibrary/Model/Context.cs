using Microsoft.EntityFrameworkCore;
using System;

namespace FilmLibrary.Model
{
    public class Context : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=postgres;username=postgres;password=123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>();
        }
    }
}
