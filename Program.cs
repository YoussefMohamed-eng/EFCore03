using EFCore03.Data;
using EFCore03.Models;
using EFCore03.Models.Enums;
using EFCore03.Operations;

namespace EFCore03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new AppDbContext();

            if (!db.Students.Any())
            {
                db.Students.AddRange(
                    new Student
                    {
                        FullName = "Ali Mohamed",
                        Email = "ali@example.com",
                        DateOfBirth = new DateTime(2003, 2, 10)
                    },

                    new Student
                    {
                        FullName = "Sara Ahmed",
                        Email = "sara@example.com",
                        DateOfBirth = new DateTime(2002, 7, 18)
                    },

                    new Student
                    {
                        FullName = "Mostafa Adel",
                        Email = "mostafa@example.com",
                        DateOfBirth = new DateTime(2004, 4, 5)
                    },

                    new Student
                    {
                        FullName = "Nour Hany",
                        Email = "nour@example.com",
                        DateOfBirth = new DateTime(2003, 11, 22)
                    },

                    new Student
                    {
                        FullName = "Yara Samir",
                        Email = "yara@example.com",
                        DateOfBirth = new DateTime(2001, 9, 12)
                    }
                );

                db.SaveChanges();
            }
            if (!db.Enrollments.Any())
            {
                db.Enrollments.AddRange(
                    new Enrollment
                    {
                        StudentId = 1,
                        CourseId = 1,
                        EnrolledAt = new DateTime(2025, 1, 1),
                        Progress = 20,
                        Status = EnrollmentStatus.Active
                    },

                    new Enrollment
                    {
                        StudentId = 2,
                        CourseId = 1,
                        EnrolledAt = new DateTime(2025, 1, 2),
                        Progress = 100,
                        Status = EnrollmentStatus.Completed,
                        FinalGrade = 95
                    },

                    new Enrollment
                    {
                        StudentId = 3,
                        CourseId = 2,
                        EnrolledAt = new DateTime(2025, 1, 3),
                        Progress = 50,
                        Status = EnrollmentStatus.Active
                    },

                    new Enrollment
                    {
                        StudentId = 4,
                        CourseId = 2,
                        EnrolledAt = new DateTime(2025, 1, 4),
                        Progress = 100,
                        Status = EnrollmentStatus.Completed,
                        FinalGrade = 88
                    },

                    new Enrollment
                    {
                        StudentId = 5,
                        CourseId = 3,
                        EnrolledAt = new DateTime(2025, 1, 5),
                        Progress = 10,
                        Status = EnrollmentStatus.Dropped
                    },

                    new Enrollment
                    {
                        StudentId = 1,
                        CourseId = 4,
                        EnrolledAt = new DateTime(2025, 1, 6),
                        Progress = 0,
                        Status = EnrollmentStatus.Active
                    },

                    new Enrollment
                    {
                        StudentId = 2,
                        CourseId = 3,
                        EnrolledAt = new DateTime(2025, 1, 7),
                        Progress = 100,
                        Status = EnrollmentStatus.Completed,
                        FinalGrade = 91
                    },

                    new Enrollment
                    {
                        StudentId = 3,
                        CourseId = 4,
                        EnrolledAt = new DateTime(2025, 1, 8),
                        Progress = 35,
                        Status = EnrollmentStatus.Dropped
                    }
                );

                db.SaveChanges();
            }

            #region Create

  


            Console.WriteLine("===== CREATE =====");

            CreateOperations.AddInstructor();

            CreateOperations.AddCourse(1, 1);

            CreateOperations.AddSeveralStudents();

            CreateOperations.EnrollStudent(1, 1);

            CreateOperations.EnrollStudent(5, 4);

            #endregion


            #region Read

            

            Console.WriteLine("\n===== READ =====");

            ReadOperations.FindCourse(1, "C# Fundamentals");

            ReadOperations.FilterCourses(400, 900);

            ReadOperations.PrintSubCategories(1);

            ReadOperations.PrintCourseRoster(1);

            #endregion


            #region Update

           

            Console.WriteLine("\n===== UPDATE =====");

            UpdateOperations.ChangeCoursePrice(1, 575);

            UpdateOperations.UpdateProgress(1, 1, 100);

            UpdateOperations.PublishCourse(5);

            #endregion


            #region Delete

          


            Console.WriteLine("\n===== DELETE =====");

            DeleteOperations.Unenroll(5, 4);

            DeleteOperations.TryDeleteCategory(1);

            DeleteOperations.SafeDeleteCategory(1);

            DeleteOperations.DeleteCourseWithEnrollments(4);

            #endregion


            #region Bulk

            


            Console.WriteLine("\n===== BULK OPERATIONS =====");

            BulkOperations.RaisePublishedCoursePrices(
                CourseLevel.Beginner);

            BulkOperations.DeleteDroppedEnrollments();

            #endregion

        }
    }
}
