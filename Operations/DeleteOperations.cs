using EFCore03.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Operations
{
    public static class DeleteOperations
    {
        public static void Unenroll(int studentId, int courseId)
        {
            using var db = new AppDbContext();

            var enrollment = db.Enrollments.Find(
                studentId, courseId);

            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            db.Enrollments.Remove(enrollment);

            db.SaveChanges();

            Console.WriteLine("Enrollment deleted.");
        }

        public static void TryDeleteCategory(int categoryId)
        {
            using var db = new AppDbContext();

            var category = db.Categories.Find(categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            db.Categories.Remove(category);

            try
            {
                db.SaveChanges();

                Console.WriteLine("Category deleted.");
            }
            catch (DbUpdateException)
            {
                Console.WriteLine(
                    "Cannot delete category because related records exist.");
            }
        }

        public static void SafeDeleteCategory(int categoryId)
        {
            using var db = new AppDbContext();

            var category = db.Categories.Find(categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            bool hasChildren = db.Categories.Any(
                c => c.ParentCategoryId == categoryId);

            if (hasChildren)
            {
                Console.WriteLine(
                    "Cannot delete: Category has sub-categories.");
                return;
            }

            bool hasCourses = db.Courses.Any(
                c => c.CategoryId == categoryId);

            if (hasCourses)
            {
                Console.WriteLine(
                    "Cannot delete: Category has courses.");
                return;
            }

            db.Categories.Remove(category);

            db.SaveChanges();

            Console.WriteLine("Category deleted safely.");
        }

        public static void DeleteCourseWithEnrollments(int courseId)
        {
            using var db = new AppDbContext();

            int before = db.Enrollments
                .Count(e => e.CourseId == courseId);

            Console.WriteLine(
                $"Enrollments before deletion: {before}");

            var course = db.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            db.Courses.Remove(course);

            db.SaveChanges();

            int after = db.Enrollments
                .Count(e => e.CourseId == courseId);

            Console.WriteLine(
                $"Enrollments after deletion: {after}");

        }
    }
}
