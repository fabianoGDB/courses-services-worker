using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.Entities
{
    public class StudentClass
    {
        public StudentClass(int studentId, int classId, DateTime createdAt)
        {
            StudentId = studentId;
            ClassId = classId;
            CreatedAt = createdAt;
            Students = new List<Student>();
            Classes = new List<Class>();
        }

        public int StudentId { get; set; }

        public int ClassId { get; set; }

        public DateTime CreatedAt { get; set; }
        public ICollection<Student> Students { get; private set; }
        public ICollection<Class> Classes { get; private set; }
    }
}