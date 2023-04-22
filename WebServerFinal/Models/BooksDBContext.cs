using Microsoft.EntityFrameworkCore;

namespace WebServerFinal.Models
{
    public class BooksDBContext : DbContext
    {
        public BooksDBContext(DbContextOptions<BooksDBContext> options) : base(options) { }

        public DbSet<Genres> Genres { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }

        // Seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create Genres
            modelBuilder.Entity<Genres>(entity =>
            {
                // Disallow nulls
                entity.Property(e => e.GenreID).IsRequired();
                entity.Property(e => e.Genre).IsRequired();

                // Seeded data
                entity.HasData(new Genres
                {
                    GenreID = 1,
                    Genre = "Science Fiction"
                });
                entity.HasData(new Genres
                {
                    GenreID = 2,
                    Genre = "Mystery"
                });
                entity.HasData(new Genres
                {
                    GenreID = 3,
                    Genre = "Fantasy"
                });
            });

            // Create Users
            modelBuilder.Entity<Users>(entity =>
            {
                // Disallow nulls
                entity.Property(e => e.UserID).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();

                // Seeded data
                entity.HasData(new Users
                {
                    UserID = 1,
                    Name = "Kenneth Otero",
                    Email = "test@gmail.com",
                    Password = "password"
                });
                entity.HasData(new Users
                {
                    UserID = 2,
                    Name = "Jones Brook",
                    Email = "jones@gmail.com",
                    Password = "password"
                });
                entity.HasData(new Users
                {
                    UserID = 3,
                    Name = "Nolan Brake",
                    Email = "nolan@gmail.com",
                    Password = "password"
                });
            });

            // Create Books
            modelBuilder.Entity<Books>(entity =>
            {
                // Disallow nulls
                entity.Property(e => e.BookID).IsRequired();
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Author).IsRequired();
                entity.Property(e => e.IsRented).IsRequired();
                entity.Property(e => e.GenreID).IsRequired();

                // Seeded data
                entity.HasData(new Books
                {
                    BookID = 1,
                    Title = "Leviathan Wakes",
                    Author = "James S. A. Corey",
                    IsRented = true,
                    GenreID = 1,
                    UserID = 1
                });
                entity.HasData(new Books
                {
                    BookID = 2,
                    Title = "Leviathan Falls",
                    Author = "James S. A. Corey",
                    IsRented = false,
                    GenreID = 1,
                    UserID = null
                });
                entity.HasData(new Books
                {
                    BookID = 3,
                    Title = "Caliban's War",
                    Author = "James S. A. Corey",
                    IsRented = false,
                    GenreID = 1,
                    UserID = 1
                });
            });
        }
    }
}
