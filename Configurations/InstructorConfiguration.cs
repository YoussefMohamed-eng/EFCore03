using EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Bio)
                .HasMaxLength(500);

            builder.Property(x => x.JoinedAt)
                .IsRequired();

            builder.HasData(
    new Instructor
    {
        Id = 1,
        FullName = "Ahmed Hassan",
        Email = "ahmed@example.com",
        Bio = "Backend Instructor",
        JoinedAt = new DateTime(2023, 1, 10)
    },

    new Instructor
    {
        Id = 2,
        FullName = "Mona Ali",
        Email = "mona@example.com",
        Bio = "Programming Instructor",
        JoinedAt = new DateTime(2023, 3, 15)
    },

    new Instructor
    {
        Id = 3,
        FullName = "Omar Samir",
        Email = "omar@example.com",
        Bio = null,
        JoinedAt = new DateTime(2024, 2, 1)
    }
);

        }

    }
}
