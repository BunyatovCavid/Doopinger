using BubbleAPi.Domain.Entities;
using BubbleAPi.Domain.Entities.Cross;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace BubbleAPi.IEntityTypeConfigurations
{
    public class User_Role_CrossConfiguration : IEntityTypeConfiguration<User_Role_Cross>
    {
        public void Configure(EntityTypeBuilder<User_Role_Cross> builder)
        {
            builder.HasData(new User_Role_Cross() {  RoleId=1, UserId=1}, new User_Role_Cross() { RoleId=2, UserId=2});

            builder.HasKey(urc => new { urc.UserId, urc.RoleId });
        }
    }
}
