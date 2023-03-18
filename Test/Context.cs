using Microsoft.EntityFrameworkCore;

namespace Test
{
    internal class Context : DbContext
    {
        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=demo;username=postgres;password=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>();
        }

        public DbSet<Film> Films { get; set; }
    }
}
