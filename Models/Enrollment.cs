using System;
using System.Collections.Generic;
using System.Text;
using EFCore03.Models.Enums;

namespace EFCore03.Models
{
    public class Enrollment
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrolledAt { get; set; }

        public decimal Progress { get; set; }

        public EnrollmentStatus Status { get; set; }

        public decimal? FinalGrade { get; set; }
    }
}
