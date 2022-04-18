using Microsoft.EntityFrameworkCore;

namespace MoviesFan.Models
{
    /// <summary>
    /// Movie EF context
    /// </summary>
    public class MovieContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(e => {
                e.ToTable("Movie");
                e.HasKey(e => e.Id);
                e.Property(e=>e.Id)
                    .HasColumnName("Id")
                    .UseIdentityColumn();
                e.Property(e => e.Title)
                    .HasColumnName("Title");
                e.Property(e => e.Year)
                .HasColumnName("Year");

            });
        }

        public MovieContext(DbContextOptions options):base(options)
        {

        }

        /// <summary>
        /// Movies
        /// </summary>
        public DbSet<Movie>? Movies { get; set; }
    }
}
