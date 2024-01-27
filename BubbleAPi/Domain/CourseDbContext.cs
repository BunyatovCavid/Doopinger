using BubbleAPi.Domain.Entities;
using BubbleAPi.Domain.Entities.Cross;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BubbleAPi.Domain
{
    public class CourseDbContext: DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Course_Report> Course_Reports { get; set; }
        public DbSet<User_Role_Cross> User_Role_Crosses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-PFGV5N8DK24;Database=Course;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
