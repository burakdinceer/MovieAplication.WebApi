using Microsoft.EntityFrameworkCore;

namespace MovieAplication.WebApi.Entities.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base( options )
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().Property(x => x.Rating).HasColumnType("decimal(12,1)");
            modelBuilder.Entity<Movie>().Property(x => x.Duration).HasColumnType("decimal(12,2)");
            modelBuilder.Entity<Serial>().Property(x => x.Rating).HasColumnType("decimal(12,1)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Serial> Serials { get; set; }
    }
}
