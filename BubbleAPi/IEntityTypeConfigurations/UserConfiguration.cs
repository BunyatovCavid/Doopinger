using BubbleAPi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BubbleAPi.IEntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User() { Id = 1, Name = "Cavid", Password = "c12345" },
                new User() { Name = "Azer", Password = "a12345", Id = 2 });

            builder.Property(u => u.Name).HasMaxLength(20).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(10).IsRequired();

            builder.HasMany(r => r.User_Role_Crosses)
              .WithOne(rc => rc.User)
              .HasForeignKey(rc => rc.UserId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
