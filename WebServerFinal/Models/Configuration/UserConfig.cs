using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebServerFinal.Models.Configuration
{
    internal class UserConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> entity)
        {
            entity.HasKey(e => e.UserID);
            entity.Property(e => e.UserID).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Password).IsRequired();

            entity.HasData(
                new Users
                {
                    UserID = 1,
                    Name = "Kenneth Otero",
                    Email = "test@gmail.com",
                    Password = "password"
                },
                new Users
                {
                    UserID = 2,
                    Name = "Jones Brook",
                    Email = "jones@gmail.com",
                    Password = "password"
                },
                new Users
                {
                    UserID = 3,
                    Name = "Nolan Brake",
                    Email = "nolan@gmail.com",
                    Password = "password"
                }
                );
        }
    }
}
