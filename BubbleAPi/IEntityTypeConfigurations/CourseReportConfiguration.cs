using BubbleAPi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BubbleAPi.IEntityTypeConfigurations
{
    public class CourseReportConfiguration : IEntityTypeConfiguration<Course_Report>
    {
        public void Configure(EntityTypeBuilder<Course_Report> builder)
        {
            builder.Property(cr => cr.CourseId).IsRequired();
            builder.Property(cr => cr.Student_Number).HasMaxLength(10);
            builder.Property(cr => cr.Amount).HasMaxLength(10);
            builder.Property(cr => cr.State).HasMaxLength(15);
            builder.Property(cr => cr.Date).HasMaxLength(20);
        }
    }
}
