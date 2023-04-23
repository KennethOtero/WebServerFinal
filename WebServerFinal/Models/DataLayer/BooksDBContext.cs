using Microsoft.EntityFrameworkCore;
using WebServerFinal.Models.Configuration;

namespace WebServerFinal.Models.DataLayer
{
    public class BooksDBContext : DbContext
    {
        public BooksDBContext(DbContextOptions<BooksDBContext> options) : base(options) { }

        public DbSet<Genres> Genres { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }

    }
}
