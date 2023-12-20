using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Models
{
    public class StudentCoursePivote
    {
        public int ID { get; set; }
        public StudentModel Student { get; set; }

        public int CourseID { get; set; }
        public CourseModel Course { get; set; }
    }
}
