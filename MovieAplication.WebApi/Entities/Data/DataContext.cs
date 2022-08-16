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
            modelBuilder.Entity<Movie>().Property(x => x.Rating).HasColumnType("decimal(12,3)");
            modelBuilder.Entity<Movie>().Property(x => x.Duration).HasColumnType("decimal(12,3)");
            modelBuilder.Entity<Serial>().Property(x => x.Rating).HasColumnType("decimal(12,3)");
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Serial> Serials { get; set; }
    }
}
