using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TotorialEntityFramework.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Section { get; set; }

        public ICollection<Students> Students { get; set; }
        public List<StudentCourse> StudentCourse { get; set; }


        public Courses()
        {
            CourseId = 0;
            CourseName = string.Empty;
        }
    }


    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Students Students { get; set; }

        public int CourseId { get; set; }
        public Courses Courses { get; set; }
    }
}
