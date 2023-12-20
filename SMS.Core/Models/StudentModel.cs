using SMS.Core.Enums;
using SMS.Core.Interface;
using SMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core
{
    public class StudentModel : IStudent
    {
        int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        string midName;
        public string MidName
        {
            get { return midName; }
            set { midName = value; }
        }
        string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        string joiningBatch;
        public string JoiningBatch
        {
            get { return joiningBatch; }
            set { joiningBatch = value; }
        }
        string dept;
        public string DeptSub
        {
            get { return dept; }
            set { dept = value; }
        }
        string degreechoise;
        public string DegreeChoise
        {
            get { return degreechoise; }
            set { degreechoise = value; }
        }

        public List<SemesterModel> Semester { get; set; }

        public List<StudentCoursePivote>StudentCourses { get; set; }

    }
}
