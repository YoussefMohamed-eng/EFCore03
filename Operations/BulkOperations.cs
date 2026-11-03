using EFCore03.Data;
using EFCore03.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace EFCore03.Operations
{
    public static  class BulkOperations
    {
        public static void RaisePublishedCoursePrices(
       CourseLevel level)
        {
            using var db = new AppDbContext();

            int affectedRows = db.Courses
                .Where(c => c.IsPublished &&
                            c.Level == level)
                .ExecuteUpdate(setters =>
                    setters.SetProperty(
                        c => c.Price,
                        c => c.Price * 1.10m
                    )
                );

            Console.WriteLine(
                $"Affected Rows: {affectedRows}");
        }
        public static void DeleteDroppedEnrollments()
        {
            using var db = new AppDbContext();

            int affectedRows = db.Enrollments
                .Where(e => e.Status == EnrollmentStatus.Dropped)
                .ExecuteDelete();

            Console.WriteLine(
                $"Deleted Rows: {affectedRows}");
        }
    }
}
