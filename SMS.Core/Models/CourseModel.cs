using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public double NumberOfCradit { get; set; }
        public SemesterModel Semester { get; set; }
        public List<StudentCoursePivote> StudentCourses { get; set; }
        
    }
}
