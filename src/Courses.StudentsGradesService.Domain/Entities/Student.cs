using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.Entities
{
    public class Student : User
    {
        public Student(int id, string abbreviatedName, string internEmail, int userId, DateTime createdAt)
        {
            Id = id;
            AbbreviatedName = abbreviatedName;
            InternEmail = internEmail;
            UserId = userId;
            CreatedAt = createdAt;
            Grades = new List<Grade>();
            StudentClasses = new List<StudentClass>();
        }

        protected Student() { }
        public string AbbreviatedName { get; private set; }
        public string InternEmail { get; private set; }
        public int UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public ICollection<Grade> Grades { get; private set; }
        public ICollection<StudentClass> StudentClasses { get; private set; }

        public void AddGrade(Grade grade)
        {
            Grades.Add(grade);
        }
    }
}