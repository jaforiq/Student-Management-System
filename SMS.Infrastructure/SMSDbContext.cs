using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SMS.Core;
using SMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure
{
    public class SMSDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public SMSDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
            //_assemblyName = Assembly.GetExecutingAssembly().FullName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("Connector"));

            // in memory database used for simplicity, change to a real db for production applications
            //options.UseInMemoryDatabase("InMemoryDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCoursePivote>()
                .HasKey(sc => new { sc.ID, sc.CourseID });

            modelBuilder.Entity<StudentCoursePivote>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.ID);

            modelBuilder.Entity<StudentCoursePivote>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseID);
        }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<SemesterModel> Semesters { get; set; }
        public DbSet<StudentCoursePivote> StudentCourses { get; set; }
    }
}
