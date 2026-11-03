using EFCore03.Configurations;
using EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=OnlineLearningPlatformDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(
                new InstructorConfiguration());

            modelBuilder.ApplyConfiguration(
                new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(
                new CourseConfiguration());

            modelBuilder.ApplyConfiguration(
                new StudentConfiguration());

            modelBuilder.ApplyConfiguration(
                new EnrollmentConfiguration());
        }
    }
}
