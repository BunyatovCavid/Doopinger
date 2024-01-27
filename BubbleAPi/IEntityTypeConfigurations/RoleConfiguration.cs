using BubbleAPi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BubbleAPi.IEntityTypeConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role() { Id = 1, Name = "Admin" }, new Role() { Id=2, Name= "User"});

            builder.Property(r => r.Name).HasMaxLength(15).IsRequired();

            builder.HasMany(r => r.User_Role_Crosses)
                .WithOne(rc => rc.Role)
                .HasForeignKey(rc => rc.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
