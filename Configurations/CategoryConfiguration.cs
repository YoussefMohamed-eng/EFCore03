using EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(x => x.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
    new Category
    {
        Id = 1,
        Name = "Programming",
        ParentCategoryId = null
    },

    new Category
    {
        Id = 2,
        Name = "Design",
        ParentCategoryId = null
    },

    new Category
    {
        Id = 3,
        Name = "Backend",
        ParentCategoryId = 1
    },

    new Category
    {
        Id = 4,
        Name = "Frontend",
        ParentCategoryId = 1
    },

    new Category
    {
        Id = 5,
        Name = "ASP.NET",
        ParentCategoryId = 3
    }
);
        }
    }
}
