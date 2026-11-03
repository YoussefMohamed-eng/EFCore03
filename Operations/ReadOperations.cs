using EFCore03.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Operations
{
    public static class ReadOperations
    {

        public static void FindCourse(int id, string title)
        {
            using var db = new AppDbContext();

            // Find by Id
            var courseById = db.Courses.Find(id);

            if (courseById == null)
            {
                Console.WriteLine("Course not found by Id.");
            }
            else
            {
                Console.WriteLine(courseById.Title);
            }

            // Find by Title
            var courseByTitle = db.Courses
                .FirstOrDefault(c => c.Title == title);

            if (courseByTitle == null)
            {
                Console.WriteLine("Course not found by Title.");
            }
            else
            {
                Console.WriteLine(courseByTitle.Title);
            }
        }


        public static void FilterCourses(
    decimal minPrice,
    decimal maxPrice)
        {
            using var db = new AppDbContext();

            var courses = db.Courses
                .Where(c => c.Price >= minPrice &&
                            c.Price <= maxPrice)
                .OrderByDescending(c => c.Price)
                .Select(c => new
                {
                    c.Title,
                    c.Level,
                    c.Price
                })
                .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"{course.Title} - {course.Level} - {course.Price}");
            }
        }

        public static void PrintSubCategories(int categoryId)
        {
            using var db = new AppDbContext();

            var subCategories = db.Categories
                .Where(c => c.ParentCategoryId == categoryId)
                .ToList();

            Console.WriteLine("Sub Categories:");

            foreach (var category in subCategories)
            {
                Console.WriteLine(category.Name);
            }

            var topCategories = db.Categories
                .Where(c => c.ParentCategoryId == null)
                .ToList();

            Console.WriteLine("Top Level Categories:");

            foreach (var category in topCategories)
            {
                Console.WriteLine(category.Name);
            }
        }

        public static void PrintCourseRoster(int courseId)
        {
            using var db = new AppDbContext();

            var studentIds = db.Enrollments
                .Where(e => e.CourseId == courseId)
                .Select(e => e.StudentId)
                .ToList();

            var students = db.Students
                .Where(s => studentIds.Contains(s.Id))
                .ToList();

            Console.WriteLine(
                $"Number of students: {students.Count}");

            foreach (var student in students)
            {
                Console.WriteLine(student.FullName);
            }
        }
    }
}
