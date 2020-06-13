using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Internal;
using System.Text;

namespace TotorialEntityFramework.Models
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }

        public int CourseId { get; set; }
        public Courses Courses { get; set; }

        public StudentAddress Address { get; set; }
        public List<StudentCourse> StudentCourse { get; set; }

        public Students()
        {
            StudentId = 0;
            Name = string.Empty;
            CourseId = 0;
        }
    }

    public class StudentAddress
    {
        public int StudentAddressId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public int AddressOfStudentId { get; set; }
        public Students Students { get; set; }
    }
}
