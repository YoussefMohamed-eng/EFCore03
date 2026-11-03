using EFCore03.Data;
using EFCore03.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Operations
{
    public static class UpdateOperations
    {
        public static void ChangeCoursePrice(
      int courseId,
      decimal newPrice)
        {
            using var db = new AppDbContext();

            var course = db.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            if (newPrice < 0)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            course.Price = newPrice;

            db.SaveChanges();

            Console.WriteLine("Price updated successfully.");
        }

        public static void UpdateProgress(
    int studentId,
    int courseId,
    decimal newProgress)
        {
            if (newProgress < 0 || newProgress > 100)
            {
                Console.WriteLine("Progress must be between 0 and 100.");
                return;
            }

            using var db = new AppDbContext();

            var enrollment = db.Enrollments.Find(
                studentId, courseId);

            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            enrollment.Progress = newProgress;

            if (newProgress == 100)
            {
                enrollment.Status = EnrollmentStatus.Completed;
            }

            db.SaveChanges();

            Console.WriteLine("Progress updated successfully.");
        }

        public static void PublishCourse(int courseId)
        {
            using var db = new AppDbContext();

            var course = db.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            course.IsPublished = true;

            course.PublishedAt ??= DateTime.Now;

            db.SaveChanges();

            Console.WriteLine("Course published successfully.");
        }
    }
}
