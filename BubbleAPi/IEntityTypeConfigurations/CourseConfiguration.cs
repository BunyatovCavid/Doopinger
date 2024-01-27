using BubbleAPi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BubbleAPi.IEntityTypeConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique();
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.State).HasMaxLength(15);
           

            builder.HasMany(c => c.Course_Reports)
                .WithOne(cr => cr.Course)
                .HasForeignKey(cr => cr.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
