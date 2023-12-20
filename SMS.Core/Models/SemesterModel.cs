using SMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Models
{
    public class SemesterModel
    {
        public int Id { get; set; }
        public SemesterCode SemisterCode { get; set; }
        public string Year { get; set; }
        public List<CourseModel> courses { get; set; }

        //public SemesterModel()
        //{
        //    courses = new List<CourseModel>();
        //}
    }
}
