using EFCore03.Data;
using EFCore03.Models;
using EFCore03.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Operations
{
    public static class CreateOperations
    {
        public static void AddInstructor()
        {
            using var db = new AppDbContext();

            var instructor = new Instructor
            {
                FullName = "New Instructor",
                Email = "new.instructor@example.com",
                Bio = "New instructor bio",
                JoinedAt = DateTime.Now
            };

            db.Instructors.Add(instructor);

            db.SaveChanges();

            Console.WriteLine(
                $"Instructor added. ID: {instructor.Id}");
        }

        public static void AddCourse(int instructorId, int categoryId)
        {
            using var db = new AppDbContext();

            if (!db.Instructors.Any(x => x.Id == instructorId))
            {
                Console.WriteLine("Instructor not found.");
                return;
            }

            if (!db.Categories.Any(x => x.Id == categoryId))
            {
                Console.WriteLine("Category not found.");
                return;
            }

            var course = new Course
            {
                Title = "New EF Core Course",
                Description = "New course",
                Price = 600,
                Level = CourseLevel.Beginner,
                IsPublished = false,
                PublishedAt = null,
                InstructorId = instructorId,
                CategoryId = categoryId
            };

            db.Courses.Add(course);

            db.SaveChanges();

            Console.WriteLine("Course added successfully.");
        }

        public static void AddSeveralStudents()
        {
            using var db = new AppDbContext();

            var students = new List<Student>
    {
        new Student
        {
            FullName = "Student Six",
            Email = "student6@example.com",
            DateOfBirth = new DateTime(2003, 5, 10)
        },

        new Student
        {
            FullName = "Student Seven",
            Email = "student7@example.com",
            DateOfBirth = new DateTime(2002, 8, 20)
        },

        new Student
        {
            FullName = "Student Eight",
            Email = "student8@example.com",
            DateOfBirth = new DateTime(2004, 1, 15)
        }
    };

            db.Students.AddRange(students);

            db.SaveChanges();

            foreach (var student in students)
            {
                Console.WriteLine($"Student ID: {student.Id}");
            }
        }


        public static void EnrollStudent(int studentId, int courseId)
        {
            using var db = new AppDbContext();

            if (!db.Students.Any(s => s.Id == studentId))
            {
                Console.WriteLine("Student does not exist.");
                return;
            }

            var course = db.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course does not exist.");
                return;
            }

            if (!course.IsPublished)
            {
                Console.WriteLine("Course is not published.");
                return;
            }

            bool alreadyEnrolled = db.Enrollments.Any(
                e => e.StudentId == studentId &&
                     e.CourseId == courseId);

            if (alreadyEnrolled)
            {
                Console.WriteLine("Student is already enrolled.");
                return;
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrolledAt = DateTime.Now,
                Progress = 0,
                Status = EnrollmentStatus.Active
            };

            db.Enrollments.Add(enrollment);

            db.SaveChanges();

            Console.WriteLine("Enrollment completed successfully.");
        }

    }
}
