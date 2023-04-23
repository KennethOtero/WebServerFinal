using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebServerFinal.Models.Configuration
{
    internal class BookConfig : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> entity)
        {
            entity.HasKey(e => e.BookID);
            entity.Property(e => e.BookID).ValueGeneratedOnAdd();
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Author).IsRequired();
            entity.Property(e => e.IsRented).IsRequired();
            entity.HasOne(b => b.Genres)
                        .WithMany(g => g.Book)
                        .HasForeignKey(b => b.GenreID);
            entity.HasOne(b => b.Users)
                        .WithOne(u => (Books)u.Books)
                        .HasForeignKey<Books>(b => b.UserID);

            entity.HasData(
                new Books
                {
                    BookID = 1,
                    Title = "Leviathan Wakes",
                    Author = "James S. A. Corey",
                    IsRented = true,
                    GenreID = 1,
                    UserID = 1
                },
                new Books
                {
                    BookID = 2,
                    Title = "Leviathan Falls",
                    Author = "James S. A. Corey",
                    IsRented = false,
                    GenreID = 1,
                    UserID = null
                },
                new Books
                {
                    BookID = 3,
                    Title = "Caliban's War",
                    Author = "James S. A. Corey",
                    IsRented = false,
                    GenreID = 1,
                    UserID = null
                }
                );
        }

    }
}
