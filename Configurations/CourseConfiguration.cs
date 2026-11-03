using EFCore03.Models;
using EFCore03.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Configurations
{
    internal class CourseConfiguration :IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.Price)
                .HasPrecision(10, 2);

            builder.Property(x => x.Level)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(x => x.IsPublished)
                .IsRequired();

            builder.HasOne<Instructor>()
                .WithMany()
                .HasForeignKey(x => x.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
    new Course
    {
        Id = 1,
        Title = "C# Fundamentals",
        Description = "Learn C# basics",
        Price = 500,
        Level = CourseLevel.Beginner,
        IsPublished = true,
        PublishedAt = new DateTime(2024, 1, 5),
        InstructorId = 1,
        CategoryId = 1
    },

    new Course
    {
        Id = 2,
        Title = "OOP with C#",
        Description = "Object oriented programming",
        Price = 650,
        Level = CourseLevel.Intermediate,
        IsPublished = true,
        PublishedAt = new DateTime(2024, 2, 5),
        InstructorId = 1,
        CategoryId = 3
    },

    new Course
    {
        Id = 3,
        Title = "ASP.NET Core Web API",
        Description = "Build APIs",
        Price = 900,
        Level = CourseLevel.Advanced,
        IsPublished = true,
        PublishedAt = new DateTime(2024, 3, 5),
        InstructorId = 2,
        CategoryId = 5
    },

    new Course
    {
        Id = 4,
        Title = "HTML and CSS",
        Description = "Web foundations",
        Price = 400,
        Level = CourseLevel.Beginner,
        IsPublished = true,
        PublishedAt = new DateTime(2024, 4, 5),
        InstructorId = 2,
        CategoryId = 4
    },

    new Course
    {
        Id = 5,
        Title = "Advanced SQL",
        Description = "Database querying",
        Price = 750,
        Level = CourseLevel.Advanced,
        IsPublished = false,
        PublishedAt = null,
        InstructorId = 3,
        CategoryId = 3
    },

    new Course
    {
        Id = 6,
        Title = "UI Design Basics",
        Description = "Design principles",
        Price = 550,
        Level = CourseLevel.Beginner,
        IsPublished = false,
        PublishedAt = null,
        InstructorId = 3,
        CategoryId = 2
    }
);
        }
    }
}
