using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebServerFinal.Models.Configuration
{
    internal class GenreConfig : IEntityTypeConfiguration<Genres>
    {
        public void Configure(EntityTypeBuilder<Genres> entity)
        {
            entity.HasKey(e => e.GenreID);
            entity.Property(e => e.GenreID).ValueGeneratedOnAdd();
            entity.Property(e => e.Genre).IsRequired();

            entity.HasData(
                new Genres
                {
                    GenreID = 1,
                    Genre = "Science Fiction"
                },
                new Genres
                {
                    GenreID = 2,
                    Genre = "Mystery"
                },
                new Genres
                {
                    GenreID = 3,
                    Genre = "Fantasy"
                }
                );
        }
    
    }

}
